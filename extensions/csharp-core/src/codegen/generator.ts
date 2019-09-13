// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

import {
    IProject,
    IServiceModel, IService, IServiceInfo,
    IModels, IModelType, IXmlSettings,
    IProperties, IProperty,
    isObjectType, isEnumType, isPrimitiveType,
    IParameters, IParameter,
    IResponses, IResponse,
    IHeaders, IHeader,
    IOperationGroup, IOperation, isDictionaryType, hasNoResponseType, isHeaderIgnored, enumRequireCustomSerialization, getEnumName } from './models';
import IndentWriter from './writer';
import * as naming from './naming';
import * as types from './types';
import { JsonType, RequestBody, NewResponse, Schema, schema } from '@microsoft.azure/autorest.codemodel-v3';
import { keys } from '@microsoft.azure/codegen';
import { getName2 } from './types';

export function generate(model: IServiceModel) : [string, string] {
    const w = new IndentWriter();

    model.info.license.header.split(/\n/g).forEach(
        line => w.line(`// ${line}`));
    w.line();

    w.line(`// This file was automatically generated.  Do not edit.`);
    w.line();

    generateService(w, model);
    generateModels(w, model);

    return [naming.file(model.service.name), w.toString()];
//    await model.writeFile(naming.file(model.service.name), w.toString());
}

function generateService(w: IndentWriter, model: IServiceModel): void {
    const service = model.service;
    w.line(`#region Service`);
    w.line(`namespace ${service.namespace}`);
    w.scope(`{`, `}`, () => {
        w.line(`/// <summary>`);
        w.line(`/// ${service.title}`);
        if (service.description) {
            w.line(`/// ${service.description}`);
        }
        w.line(`/// </summary>`);
        w.line(`${model.info.public ? 'public' : 'internal'} static partial class ${service.name}`);
        w.scope('{', '}', () => {
            const fencepost = IndentWriter.createFenceposter();
            if (Object.keys(service.operations).length > 0) {
                if (fencepost()) { w.line(); }
                generateOperationGroup(w, model, `service operations`, service.operations);
            }
            for (const [name, group] of <[string, IOperationGroup][]>Object.entries(service.groups)) {
                if (fencepost()) { w.line(); }
                generateOperationGroup(w, model, name, group);
            }
        });

        // w.line();
        // w.line(`#region class ${service.extensionsName}`);
        // w.line(`/// <summary>`);
        // w.line(`/// ${service.name} response extensions`);
        // w.line(`/// </summary>`);
        // w.line(`public static partial class ${service.extensionsName}`);
        // w.scope('{', '}', () => {
        //     const fencepost = IndentWriter.createFenceposter();

        //     const responses: IModelType[] = [];
        //     [service.operations, ...Object.values(service.groups)].map(g => Object.values(g).forEach(op => responses.push(op.response.model)));
        //     for (const responseType of responses.filter((t, i) => responses.indexOf(t) === i)) {
        //         let unique = responseType.extendedHeaders.reduce((all: IHeader[], h) => all.some(v => v.name === h.name) ? all : [...all, h], []);
        //         for (const header of unique) {
        //             if (header.name === `x-ms-request-id` || header.name === `Date`) {
        //                 // Ignore headers promoted to Response...  and version.
        //                 continue;
        //             }
        //             const responseTypeName = responseType.type === 'void' ?
        //                 'Azure.Response' : 
        //                 `Azure.Response<${types.getName(responseType)}>`;
        //             if (fencepost()) { w.line(); }
        //             w.line(`/// <summary>`)
        //             w.line(`/// ${header.description || 'Try to get the ' + header.name + ' header.'}`);
        //             w.line(`/// </summary>`)
        //             w.write(`public static ${types.getDeclarationType(header.model, false)} ${naming.method('Get ' + header.clientName, false)}(this ${responseTypeName} response)`);
        //             w.scope(() => {
        //                 const headerAccess = responseType.type === `void` ? ``: `.Raw`;
        //                 w.write(`=> response${headerAccess}.Headers.TryGetValue("${header.name}", out string header) ?`);
        //                 w.scope(() => {  
        //                     w.line(`${types.convertFromString('header', header.model, service)} :`)
        //                     w.line(`default;`);
        //                 });
        //             });
        //         }
        //     }
        // });
        // w.line(`#endregion class ${service.extensionsName}`);
    });
    w.line(`#endregion Service`);
    w.line();
}

function generateOperationGroup(w: IndentWriter, model: IServiceModel, name: string, group: IOperationGroup) {
    w.line(`#region ${name} operations`);
    w.line(`/// <summary>`);
    w.line(`/// ${name} operations for ${model.info.title}`);
    w.line(`/// </summary>`);
    w.line(`public static partial class ${naming.type(name)}`);
    w.scope('{', '}', () => {
        const fencepost = IndentWriter.createFenceposter();
        for (const [name, operation] of <[string, IOperation][]>Object.entries(group)) {
            if (fencepost()) { w.line(); }
            generateOperation(w, model, group, name, operation);
        }
    });
    w.line(`#endregion ${name} operations`);
}

function generateOperation(w: IndentWriter, serviceModel: IServiceModel, group: IOperationGroup, name: string, operation: IOperation) {
    const service = serviceModel.service;
    const methodName = naming.method(operation.operationId, true);
    const groupId = operation.operationId.indexOf("_");
    const groupName =  (groupId > 0 ? operation.operationId.substring(0, groupId) : "");
    const regionName = (groupName !== "" ? groupName + ".": "") + operation.operationId;// (operation.group ? naming.type(operation.group) + '.' : '') + methodName;
    const pipelineName = "pipeline";
    const cancellationName = "cancellationToken";
    const bodyName = "_body";
    const requestName = "_request";
    const headerName = "_header";
    const xmlName = "_xml";
    const textName = "_text";
    const valueName = "_value";
    const pairName = `_headerPair`;
    let responseName = "_response";
    const resultName = "_result";
    const scopeName = "_scope";
    const operationName = "operationName";
    const response = (<[string, NewResponse[]][]>Object.entries(operation.responses))[0][1][0]; //TODO: Take the first response for now but should try to get a better one later.
   // const result = response.schema; //TODO: Translate the correct result
    const sync = serviceModel.info.sync;

    //if (!result || !result.type)
    //    throw "No return result";

    const returnType = hasNoResponseType(response) || response.schema === undefined ?
        'Azure.Response' : `Azure.Response<${types.getName(response.schema)}>`;

    w.line(`#region ${regionName}`);

    // #region Top level method
    w.line(`/// <summary>`);
    w.line(`/// ${operation.description || regionName}`);
    w.line(`/// </summary>`);
    w.line(`/// <param name="pipeline">The pipeline used for sending requests.</param>`);
    for (const arg of operation.parameters) {
        const desc = arg.description || arg.schema.description;
        if (desc)
        {
            w.line(`/// <param name="${naming.parameter(arg.name)}">${desc}</param>`);
        }
    }
    if (sync) {
        w.line(`/// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>`);
    }
    w.line(`/// <param name="${operationName}">Operation name.</param>`);
    w.line(`/// <param name="${cancellationName}">Cancellation token.</param>`);
    w.line(`/// <returns>${response.description || returnType.replace(/</g, '{').replace(/>/g, '}')}</returns>`);
    w.write(`public static async System.Threading.Tasks.Task<${returnType}> ${methodName}(`);        
    w.scope(() => {
        const separateParams = IndentWriter.createFenceposter();
        for (const arg of operation.parameters) {
            if (separateParams()) { w.line(`,`); }
            w.write(`${types.getDeclarationType(arg.schema, arg.required, false, true)} ${naming.parameter(arg.name)}`);
            if (!arg.required) { w.write(` = default`); }
        }
        if (sync) {
            if (separateParams()) {  w.line(`,`); }
            w.write(`bool async = true`);
        }
        if (separateParams()) {  w.line(`,`); }
        w.write(`string ${operationName} = "${serviceModel.service.namespace}.${groupName !== '' ? groupName + "Client" : naming.type(service.name)}.${operation.operationId}"`);
        if (separateParams()) {  w.line(`,`); }
        w.write(`System.Threading.CancellationToken ${cancellationName} = default`);
        w.write(')')
    });
    w.scope('{', '}', () => {
        w.line(`Azure.Core.Pipeline.DiagnosticScope ${scopeName} = ${pipelineName}.Diagnostics.CreateScope(${operationName});`)
        w.line(`try`);
        w.scope('{', '}', () => {
            for (const arg of operation.parameters) {
                if (arg.extensions[`x-az-trace`] === 'true')
                {
                    w.line(`${scopeName}.AddAttribute("${naming.parameter(arg.name)}", ${naming.parameter(arg.name)});`);
                }
            }
            w.line(`${scopeName}.Start();`);
            w.write(`using (Azure.Core.Http.Request ${requestName} = ${methodName}_CreateRequest(`);
            w.scope(() => {
                const separateParams = IndentWriter.createFenceposter();
                for (const arg of operation.parameters) {
                    if (separateParams()) { w.line(`,`); }
                    w.write(`${naming.parameter(arg.name)}`);
                }
                w.write(`))`);
            });
            w.scope('{', '}', () => {
                w.write(`Azure.Response ${responseName} = `);
                const asyncCall = `await ${pipelineName}.SendRequestAsync(${requestName}, ${cancellationName}).ConfigureAwait(false)`;
                if (sync) {
                    w.write('async ?');
                    w.scope(() => {
                        w.line(`// Send the request asynchronously if we're being called via an async path`);
                        w.line(`${asyncCall} :`);
                        w.line(`// Send the request synchronously through the API that blocks if we're being called via a sync path`);
                        w.line(`// (this is safe because the Task will complete before the user can call Wait)`);
                        w.line(`${pipelineName}.SendRequest(${requestName}, ${cancellationName});`);
                    });
                } else {
                    w.line(`${asyncCall};`);
                }
                w.line(`${cancellationName}.ThrowIfCancellationRequested();`);
                w.line(`return ${methodName}_CreateResponse(${responseName});`);
            });
        });
        w.line(`catch (System.Exception ex)`);
        w.scope('{', '}', () => {
            w.line(`${scopeName}.Failed(ex);`);
            w.line(`throw;`);
        });
        w.line(`finally`);
        w.scope('{', '}', () => {
            w.line(`${scopeName}.Dispose();`);
        });
    });
    w.line();
    
    // #endregion Top level method
    
    // #region Create Request
    w.line(`/// <summary>`);
    w.line(`/// Create the ${regionName} request.`);
    w.line(`/// </summary>`);
    w.line(`/// <param name="pipeline">The pipeline used for sending requests.</param>`);
    for (const arg of operation.parameters) {
        const desc = arg.description || arg.schema.description;
        if (desc)
        {
            w.line(`/// <param name="${naming.parameter(arg.name)}">${desc}</param>`);
        }
    }
    w.line(`/// <returns>The ${regionName} Request.</returns>`);
    w.write(`internal static Azure.Core.Http.Request ${methodName}_CreateRequest(`);
    w.scope(() => {
        const separateParams = IndentWriter.createFenceposter();
        for (const arg of operation.parameters) {
            if (separateParams()) { w.line(`,`); }
            w.write(`${types.getDeclarationType(arg.schema, arg.required, false, true)} ${naming.parameter(arg.name)}`);
            if (!arg.required) { w.write(` = default`); }
        }
        w.write(')')
    });
    w.scope('{', '}', () => {
        // Get the value of a parameter (and inline constants as literals)
        const useParameter = (param: IParameter, use: ((value: string) => void)) => {
            const constant = isEnumType(param.schema) && param.schema.enum.length === 1;
            const nullable = !constant && !param.required;
            const name = naming.variable(param.name);
            if (nullable) { w.write(`if (${name} != null) {`); }
            if (constant) {
                use(`"${(param.schema.enum[0] || '')}"`);
            } else if (isDictionaryType(param.schema)) {
                w.scope(() => {
                    w.line(`foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in ${naming.parameter(param.name)})`);
                    w.scope('{', '}', () => {
                        use("_pair");
                    });
                });
            } else if (isPrimitiveType(param.schema) && param.explode /* explode==true -> collectionformat==multi*/) {
                if (!param.schema.items || param.schema.items.type !== `string`) {
                    throw `collectionFormat multi is only supported for strings, at the moment`;
                }
                w.scope(() => {
                    w.line(`foreach (string _item in ${naming.parameter(param.name)})`);
                    w.scope('{', '}', () => {
                        use("_item");
                    });
                });
            } else {
                if (param.schema.type === `boolean`) {
                    w.line();
                    w.line(`#pragma warning disable CA1308 // Normalize strings to uppercase`);
                } else if (nullable) { w.write(` `); }
                use(types.convertToString(name, param.schema, service, param.required));
                if (param.schema.type === `boolean`) {
                    w.line();
                    w.line(`#pragma warning restore CA1308 // Normalize strings to uppercase`);
                } else if (nullable) { w.write(` `); }
            }
            if (nullable) { w.write(`}`); }
            w.line();
        };        

        if (operation.parameters.length > 0) {
            w.line(`// Validation`);
            for (const arg of operation.parameters) {
                generateValidation(w, operation, arg);
            }
            w.line();
        }

        w.line(`// Create the request`);
        w.line(`Azure.Core.Http.Request ${requestName} = ${pipelineName}.CreateRequest();`);
        w.line();

        w.line(`// Set the endpoint`);
        const httpMethod = naming.pascalCase(operation.method);
        w.line(`${requestName}.Method = Azure.Core.Pipeline.RequestMethod.${httpMethod};`);

        if (operation.parameters.length >= 1 && operation.parameters[1].name === 'url')
        {
            const uri = naming.parameter(operation.parameters[1].name);
            w.line(`${requestName}.UriBuilder.Uri = ${uri};`);
        }
        const queries = operation.parameters.filter(p => p.in === `query`)
        if (queries.length > 0) {
            for (const query of queries) {
                const constant = isEnumType(query.schema) && query.schema.enum.length == 1;
                useParameter(query, value => {
                    if (!query.extensions["x-ms-skip-url-encoding"] && !constant) {
                        value = `System.Uri.EscapeDataString(${value})`
                    }
                    w.write(`${requestName}.UriBuilder.AppendQuery("${query.name}", ${value});`);
                });
            }
        }
        // if (operation.request.paths.length > 2) { // We're always ignoring url + pipeline
        //     w.line(`// TODO: Ignoring request path vars: ${operation.request.paths.map(p => p.name).join(', ')}`)
        // }
        w.line();
        const headers = operation.parameters.filter(p => p.in === 'header');
        if (headers.length > 0) {
            w.line(`// Add request headers`);
            for (const header of headers) {
                useParameter(header, value => {
                    let name = `"${header.name}"`;
                    if (isPrimitiveType(header.schema) && isDictionaryType(header.schema)) {
                        name = `"${'x-ms-meta-'}" + ${value}.Key`;
                        value = `${value}.Value`;
                    }
                    w.write(`${requestName}.Headers.SetValue(${name}, ${value});`);
                });
            }
            w.line();
        }

        // Serialize
        const body = operation.requestBody;
        if (body) {
            w.line(`// Create the body`);
            const bodyType = body.schema;
            const requestBodyName = naming.parameter(body.extensions['x-ms-client-name'] || body.extensions['x-ms-requestBody-name'] || 'body');
            if (body.contentType === `application/octet-stream`) { // || bodyType.type === `file`) {
                // Serialize a file
                w.line(`${requestName}.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(${requestBodyName});`);
            } else if (body.contentType === `application/xml`) {
                // Serialize XML
                if (isObjectType(bodyType)) {
                    //if (bodyType.serialize) {
                        let elementName = (bodyType.xml ? bodyType.xml.name : undefined) || requestBodyName;
                        w.line(`System.Xml.Linq.XElement ${bodyName} = ${types.getName(bodyType)}.ToXml(${requestBodyName}, "${elementName}", "");`);
                    // } else {
                    //     w.line(`// TODO:  ${bodyType.name} lacks a ToXml method!`);
                    // }
                } else if (isPrimitiveType(bodyType) && bodyType.items) {
                    if (isObjectType(bodyType.items) /* && bodyType.items.serialize */) {
                        // We're just going to one off this here for now because there's only
                        // one case of serializing raw arrays
                        const { xname } = getXmlShapeFromSchema(bodyType.items);
                        w.line(`System.Xml.Linq.XElement ${bodyName} = new System.Xml.Linq.XElement(${xname});`);

                        const itemType = bodyType.items;
                        const bodyParamName = requestBodyName;
                        w.line(`if (${bodyParamName} != null)`);
                        w.scope(`{`, `}`, () => {
                            w.line(`foreach (${types.getName(itemType)} _child in ${bodyParamName})`);
                            w.scope('{', '}', () => {
                                w.line(`${bodyName}.Add(${types.getName(itemType)}.ToXml(_child));`);
                            });
                        });
                    } else {
                        let itemName =
                            isObjectType(bodyType.items) || isEnumType(bodyType.items) ? bodyType.items.type :
                            isPrimitiveType(bodyType.items) ? bodyType.items.type :
                            "unexpected type";
                        w.line(`// TODO: Serialize array of ${itemName}`);
                    }
                } else {
                    w.line(`System.Xml.Linq.XElement ${bodyName} = null;`);
                }
                
                w.line(`string ${textName} = ${bodyName}.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);`);
                w.line(`${requestName}.Headers.SetValue("Content-Type", "application/xml");`);
                w.line(`${requestName}.Headers.SetValue("Content-Length", ${textName}.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));`);
                w.line(`${requestName}.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(${textName}));`);
            } else {
                throw `Serialization format ${body.contentType} not supported (in ${name})`;
            }
            w.line();
        }

        w.line(`return ${requestName};`);
    });
    w.line();
    // #endregion Create Request

    // #region Create Response
    responseName = `response`;
    w.line(`/// <summary>`);
    w.line(`/// Create the ${regionName} response or throw a failure exception.`);
    w.line(`/// </summary>`);
    w.line(`/// <param name="response">The raw Response.</param>`);
    w.line(`/// <returns>The ${regionName} ${returnType.replace(/</g, '{').replace(/>/g, '}')}.</returns>`);
    w.write(`internal static ${returnType} ${methodName}_CreateResponse(`);
    w.scope(() => {
        w.write(`Azure.Response ${responseName})`);
    });
    w.scope(`{`, `}`, () => {
        w.line(`// Process the response`);
        w.line(`switch (${responseName}.Status)`);
        w.scope('{', '}', () => {

            let responses = <[string, NewResponse[]][]>Object.entries(operation.responses);
            let successes = responses.filter(k => k[0][0] == '2').map<NewResponse>(k => k[1][0]);
            let failures = responses.filter(k => k[0][0] != '2').map<NewResponse>(k => k[1][0]);

            for (const response of successes) {
                //if (!response.schema) { throw `Cannot deserialize without a response model (in ${name})`; }
                //const model = response.schema;

                w.line(`case ${response.responseCode}:`);
                w.scope('{', '}', () => {
                    if (hasNoResponseType(response)) {
                        w.line(`return ${responseName};`);
                    } else {
                        processResponse(response);

                        w.line(`// Create the response`)
                        w.write(`${returnType} ${resultName} =`);
                        w.scope(() => {
                            w.write(`new ${returnType}(`);
                            w.scope(() => {
                                w.line(`${responseName},`);
                                w.line(`${valueName});`);
                            });
                        });
                        w.line();
                        
                        w.line(`return ${resultName};`);
                    }
                });
            }


            for (const response of failures) {
                if (response.responseCode === `default`) {
                    w.line(`default:`);
                } else {
                    w.line(`case ${response.responseCode}:`);
                }
                w.scope('{', '}', () => {
                    processResponse(response);
                    if (response.extensions[`x-az-create-exception`]) {
                        // If we're using x-az-create-exception, we'll pass the response to
                        // an unimplemented method on the partial class
                        w.line(`throw ${valueName}.CreateException(${responseName});`);
                    } else {
                        w.line(`throw new Azure.RequestFailedException(${responseName});`);
                    }
                });
            }
        });
    });
    
    function processResponse(response: IResponse) {
        if (!response.schema) { throw `Cannot deserialize without a response model (in ${name})`; }
        const model = response.schema;

        // Deserialize
        w.line(`// Create the result`);
        if (response.schema) {
            const responseType = response.schema;
            const bodyClientName = response.extensions[`x-az-response-schema-name`] || `Body`;
            if (response.mimeTypes.find(m => m === `stream`)) { // || responseType.type === `file`) {
                // Deserialize a file
                w.line(`${types.getName(model)} ${valueName} = new ${types.getName(model)}();`);
                w.line(`${valueName}.${naming.property(bodyClientName)} = ${responseName}.ContentStream; // You should manually wrap with RetriableStream!`);
            } else if (response.mimeTypes.find(m => m === `xml`)) {
                // Deserialize XML
                w.line(`System.Xml.Linq.XDocument ${xmlName} = System.Xml.Linq.XDocument.Load(${responseName}.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);`);
                if (isObjectType(model) /* && model.deserialize */) {
                    w.line(`${types.getName(model)} ${valueName} = ${types.getName(model)}.FromXml(${xmlName}.Root);`);
                } else {
                    if (model.type === `array` &&
                        isPrimitiveType(responseType) &&
                        responseType.items &&
                        isObjectType(responseType.items)/* &&
                        responseType.itemType.deserialize*/) {
                        // Get the target
                        const itemType = responseType.items;
                        const { xname, wrapped } = getXmlShapeFromSchema(itemType);
                        let target = xmlName;
                        if (wrapped) { target = `${target}.Element(${xname})`; }
                        const { xname: childName } = getXmlShapeFromSchema(itemType);
                        target = `${target}.Elements(${childName})`;
                        w.write(`${types.getName(model)} ${valueName} =`);
                        w.scope(() => {
                            w.scope('System.Linq.Enumerable.ToList(', '', () => {
                                w.scope(`System.Linq.Enumerable.Select(`, ``, () => {
                                    w.line(`${target},`);
                                    w.write(`${types.getName(itemType)}.FromXml));`);
                                });
                            });    
                        });
                    } else if (model.type === `object`) {
                        w.line(`${types.getName(model)} ${valueName} = new ${types.getName(model)}();`);
                        if (isObjectType(responseType)) {
                            w.line(`${valueName}.${naming.property(bodyClientName)} = ${types.getName(responseType)}.FromXml(${xmlName}.Root);`);
                        } else if (isPrimitiveType(responseType) &&
                            responseType.items &&
                            isObjectType(responseType.items)/* &&
                            responseType.items.deserialize*/) {
    
                            // Get the target
                            const itemType = responseType.items;
                            const { xname, wrapped } = getXmlShapeFromSchema(itemType);
                            let target = xmlName;
                            if (wrapped) { target = `${target}.Element(${xname})`; }
                            const { xname: childName } = getXmlShapeFromSchema(itemType);
                            target = `${target}.Elements(${childName})`;
                            w.write(`${valueName}.${naming.property(bodyClientName)} =`);
                            w.scope(() => {
                                w.scope('System.Linq.Enumerable.ToList(', '', () => {
                                    w.scope(`System.Linq.Enumerable.Select(`, ``, () => {
                                        w.line(`${target},`);
                                        w.write(`${types.getName(itemType)}.FromXml));`);
                                    });
                                });    
                            });
                        }
                    } else {
                        w.line(`// TODO: Deserialize unexpected type`);
                    }
                }
            } else {
                throw `Serialization format ${response.mimeTypes.join(', ')} not supported (in ${name})`;
            }
        } else {
            w.line(`${types.getName(model)} ${valueName} = new ${types.getName(model)}();`);
        }
        w.line();

        const headers = response.headers.filter(h => !isHeaderIgnored(h));
        if (headers.length > 0) {
            w.line(`// Get response headers`);
            w.line(`string ${headerName};`);
            for (const header of headers) {
                const headerClientName = header.extensions[`x-ms-client-name`] || header.key;
                if (isPrimitiveType(header.schema) && isDictionaryType(header.schema)) {
                    const prefix = header.schema.extensions[`x-ms-header-collection-prefix`] || `x-ms-meta-`;
                    w.line(`${valueName}.${naming.pascalCase(headerClientName)} = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);`);
                    w.line(`foreach (Azure.Core.Http.HttpHeader ${pairName} in ${responseName}.Headers)`);
                    w.scope(`{`, `}`, () => {
                        w.line(`if (${pairName}.Name.StartsWith("${prefix}", System.StringComparison.InvariantCulture))`);
                        w.scope(`{`, `}`, () => {
                            w.line(`${valueName}.${naming.pascalCase(headerClientName)}[${pairName}.Name.Substring(${prefix.length})] = ${pairName}.Value;`);
                        });
                    });
                } else {
                    w.line(`if (${responseName}.Headers.TryGetValue("${headerClientName}", out ${headerName}))`);
                    w.scope('{', '}', () => {
                        w.write(`${valueName}.${naming.pascalCase(headerClientName)} = `);
                        if (isPrimitiveType(header.schema) && header.schema.format === `multi`) {
                            if (!header.schema.items || header.schema.items.type !== `string`) {
                                throw `collectionFormat multi is only supported for strings, at the moment`;
                            }
                            w.write(`(${headerName} ?? "").Split(',')`);
                        } else {
                            w.write(`${types.convertFromString(headerName, header.schema, service)}`);
                        }
                        w.line(`;`);
                    });    
                }
            }
            w.line();
        }
    }
    // #endregion Create Response

    w.line(`#endregion ${regionName}`);
}

function generateValidation(w: IndentWriter, operation: IOperation, parameter: IParameter) {
    const name = naming.parameter(parameter.name);
    // Null checks
    if (parameter.required && !types.isValueType(parameter.schema)) {
        w.line(`if (${name} == null)`);
        w.scope('{', '}', () => {
            w.line(`throw new System.ArgumentNullException(nameof(${name}));`);
        });
    }

    // We can get more thorough with primitives
    if (isPrimitiveType(parameter.schema)) {
        // TODO: Min/length/...
    }
}

function generateModels(w: IndentWriter, model: IServiceModel): void {
    w.line(`#region Models`);
    const fencepost = IndentWriter.createFenceposter();
    const types = <[string, IModelType][]>Object.entries(model.models || {});
    types.sort((a, b) =>
        a[0] < b[0] ? -1 :
        a[0] > b[0] ? 1 :
        0);
    for (const [name, def] of types) {
        if (fencepost()) { w.line(); }
        if (isEnumType(def))
        {
            const msEnum = def.extensions[`x-ms-enum`];
            if (msEnum && msEnum[`modelAsString`]) {
                generateEnumStrings(w, model, def);
            }
            else {
                generateEnum(w, model, def);
            }
        }
        else if (isObjectType(def)) { generateObject(w, model, def); }
    }
    w.line(`#endregion Models`);
    w.line();
}

function generateEnum(w: IndentWriter, model: IServiceModel, type: IModelType) {
    // Generate the enum
    let enumTypeName = getEnumName(type);
    enumTypeName = naming.type(enumTypeName);
    const enumeTypeIsPublic = type.extensions[`x-az-public`] || true;
    const regionName = `enum ${enumTypeName}`;
    w.line(`#region ${regionName}`);
    w.line(`namespace ${model.service.namespace}`);
    w.scope('{', '}', () => {
        w.line(`/// <summary>`)
    const regionName = `enum ${enumTypeName}`;
    w.line(`/// ${type.description || enumTypeName + ' values'}`);
        w.line(`/// </summary>`)
        const notReallyPlural = naming.type(enumTypeName).endsWith('Status');
        if (notReallyPlural) {  w.line(`#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names`); }
        w.line(`${enumeTypeIsPublic ? 'public' : 'internal'} enum ${enumTypeName}`);
        if (notReallyPlural) {  w.line(`#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names`); }
        const separator = IndentWriter.createFenceposter();
        w.scope(`{`, `}`, () => {
            for (const value of type.enum) {
                if (separator()) { w.line(','); w.line(); }
                w.line(`/// <summary>`);
                w.line(`/// ${value.description || value.value || value.name}`);
                w.line(`/// </summary>`);
                w.write(naming.enumField(value.name || value.value));
            }
        });
    });

    const customSerialization = enumRequireCustomSerialization(type);
    // Generate the custom serializers if needed
    if (customSerialization) {
        const service = model.service;
        w.line();
        w.line(`namespace ${naming.namespace(service.namespace)}`);
        w.scope('{', '}', () => {
            w.line(`internal static partial class ${naming.type(service.name)}`);
            w.scope('{', '}', () => {
                w.line(`public static partial class Serialization`);
                w.scope('{', '}', () => {
                    w.line(`public static string ToString(${types.getName(type)} value)`);
                    w.scope('{', '}', () => {
                        w.line(`switch (value)`);
                        w.scope('{', '}', () => {
                            // Write the values
                            for (const value of type.enum) {
                                w.write(`case ${types.getName(type)}.${naming.enumField(value.name || value.value)}:`);
                                w.scope(() => w.line(`return "${value.value}";`));
                            }
                            // Throw for random values
                            w.write(`default:`);
                            w.scope(() => w.line(`throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown ${enumTypeName} value.");`));
                        });
                    });
                    w.line();

                    w.line(`public static ${types.getName(type)} Parse${enumeTypeIsPublic}(string value)`);
                    w.scope('{', '}', () => {
                        w.line(`switch (value)`);
                        w.scope('{', '}', () => {
                            // Write the values
                            for (const value of type.enum) {
                                w.write(`case "${value.value}":`);
                                w.scope(() => w.line(`return ${types.getName(type)}.${naming.enumField(value.name || value.value)};`));
                            }
                            // Throw for random values
                            w.write(`default:`);
                            w.scope(() => w.line(`throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown ${enumTypeName} value.");`));
                        });
                    });
                });
            });
        });
    }

    w.line(`#endregion ${regionName}`);
}

function generateEnumStrings(w: IndentWriter, model: IServiceModel, type: IModelType) {
    let enumTypeName = type.extensions[`x-ms-enum`] || type.extensions[`x-ms-client-name`] || type.extensions[`name`] || "UNKNOWN ENUM TYPE NAME";
    enumTypeName = naming.type(enumTypeName);
    const enumeTypeIsPublic = type.extensions[`x-az-public`] || true;
    const regionName = `enum strings ${naming.type(enumTypeName)}`;
    w.line(`#region ${regionName}`);
    w.line(`namespace ${model.service.namespace}`);
    w.scope('{', '}', () => {
        w.line(`/// <summary>`);
        w.line(`/// ${type.description || enumTypeName + ' values'}`);
        w.line(`/// </summary>`);
        const enumName = enumTypeName;
        const enumFullName = types.getName(type, false, false);
        w.line(`${enumeTypeIsPublic ? 'public' : 'internal'} partial struct ${enumName} : System.IEquatable<${enumName}>`);
        w.scope(`{`, `}`, () => {
            // Dump out the values
            w.line(`#pragma warning disable CA2211 // Non-constant fields should not be visible`);
            const separator = IndentWriter.createFenceposter();
            for (const value of type.enum) {
                if (separator()) { w.line(); }
                const name = naming.property((value.name || value.value) || '').toString();
                const text = (value.value || '').toString();
                w.line(`/// <summary>`);
                w.line(`/// ${value.description || text}`);
                w.line(`/// </summary>`);
                w.line(`public static ${enumFullName} ${name} = @"${text}";`)
            }
            w.line(`#pragma warning restore CA2211 // Non-constant fields should not be visible`);
            if (separator()) { w.line(); }

            // Dump out the infrastructure
            w.line(`/// <summary>`);
            w.line(`/// The ${enumName} value.`);
            w.line(`/// </summary>`);
            w.line(`private readonly string _value;`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Creates a new ${enumName} instance.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="value">The ${enumName} value.</param>`);
            w.line(`private ${enumName}(string value) { this._value = value; }`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Check if two ${enumName} instances are equal.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="other">The instance to compare to.</param>`);
            w.line(`/// <returns>True if they're equal, false otherwise.</returns>`);
            w.line(`public bool Equals(${enumFullName} other) => this._value.Equals(other._value, System.StringComparison.InvariantCulture);`)
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Check if two ${enumName} instances are equal.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="o">The instance to compare to.</param>`);
            w.line(`/// <returns>True if they're equal, false otherwise.</returns>`);
            w.line(`public override bool Equals(object o) => o is ${enumFullName} other && this.Equals(other);`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Get a hash code for the ${enumName}.`);
            w.line(`/// </summary>`);
            w.line(`/// <returns>Hash code for the ${enumName}.</returns>`);
            w.line(`public override int GetHashCode() => this._value.GetHashCode();`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Convert the ${enumName} to a string.`);
            w.line(`/// </summary>`);
            w.line(`/// <returns>String representation of the ${enumName}.</returns>`);
            w.line(`public override string ToString() => this._value;`);
            w.line(``);
            w.line(`#pragma warning disable CA2225 // Operator overloads have named alternates`);
            w.line(`/// <summary>`);
            w.line(`/// Convert a string a ${enumName}.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="value">The string to convert.</param>`);
            w.line(`/// <returns>The ${enumName} value.</returns>`);
            w.line(`public static implicit operator ${enumName}(string value) => new ${enumFullName}(value);`);
            w.line(`#pragma warning restore CA2225 // Operator overloads have named alternates`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Convert an ${enumName} to a string.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="o">The ${enumName} value.</param>`);
            w.line(`/// <returns>String representation of the ${enumName} value.</returns>`);
            w.line(`public static implicit operator string(${enumFullName} o) => o._value;`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Check if two ${enumName} instances are equal.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="a">The first instance to compare.</param>`);
            w.line(`/// <param name="b">The second instance to compare.</param>`);
            w.line(`/// <returns>True if they're equal, false otherwise.</returns>`);
            w.line(`public static bool operator ==(${enumFullName} a, ${enumFullName} b) => a.Equals(b);`);
            w.line(``);
            w.line(`/// <summary>`);
            w.line(`/// Check if two ${enumName} instances are not equal.`);
            w.line(`/// </summary>`);
            w.line(`/// <param name="a">The first instance to compare.</param>`);
            w.line(`/// <param name="b">The second instance to compare.</param>`);
            w.line(`/// <returns>True if they're not equal, false otherwise.</returns>`);
            w.line(`public static bool operator !=(${enumFullName} a, ${enumFullName} b) => !a.Equals(b);`);
        });
    });
    w.line(`#endregion ${regionName}`);
}

function generateObject(w: IndentWriter, model: IServiceModel, type: IModelType) {
    let objectTypeName = type.extensions[`x-ms-client-name`] || type.extensions[`name`] || "UNKNOWN OBJECT TYPE NAME";
    objectTypeName = naming.type(objectTypeName);
    const disableWarnings = type.extensions[`x-az-disable-warnings`];
    const objectTypeIsPublic = type.extensions[`x-az-public`] || true;
    const service = model.service;
    const regionName = `class ${naming.type(objectTypeName)}`;
    w.line(`#region ${regionName}`);
    w.line(`namespace ${model.service.namespace}`);
    w.scope('{', '}', () => {
        w.line(`/// <summary>`);
        w.line(`/// ${type.description || objectTypeName}`);
        w.line(`/// </summary>`);
        if (disableWarnings) { w.line(`#pragma warning disable ${disableWarnings}`); }
        w.line(`${objectTypeIsPublic ? 'public' : 'internal'} partial class ${naming.type(objectTypeName)}`);
        if (disableWarnings) { w.line(`#pragma warning restore ${disableWarnings}`); }
        const separator = IndentWriter.createFenceposter();
        w.scope('{', '}', () => {
            for (const property of <IProperty[]>Object.values(type.properties)) {
                if (separator()) { w.line(); }
                w.line(`/// <summary>`);
                w.line(`/// ${property.description || property.schema.description || property.serializedName}`);
                w.line(`/// </summary>`);
                if (property.schema.type === `array`) {
                    w.line(`#pragma warning disable CA1819 // Properties should not return arrays`);
                }
                w.write(`public ${types.getPropertyDeclarationType(property, property.schema)} ${naming.property(property.serializedName)} { get; `);
                if (property.details.default.readonly || property.schema.type === `array`) {
                    w.write(`internal `);
                }
                w.line(`set; }`);
                if (property.schema.format === `byte`) {
                    w.line(`#pragma warning restore CA1819 // Properties should not return arrays`);
                }
            }

            // Instantiate nested models if necessary
            const nested = (<IProperty[]>Object.values(type.properties)).filter(p => isObjectType(p.schema) || (isPrimitiveType(p.schema) && (p.schema.items || isDictionaryType(p.schema))));
            if (nested.length > 0) {
                const typeName = naming.type(types.getName2(type));
                const skipInitName = `skipInitialization`;
                if (separator()) { w.line(); }
                w.line(`/// <summary>`);
                w.line(`/// Creates a new ${typeName} instance`);
                w.line(`/// </summary>`);
                if (type /*type.deserialize*/) {
                    // Add an optional overload that prevents initialization for deserialiation
                    w.write(`public ${typeName}()`);
                    w.scope(() => w.write(`: this(false)`));
                    w.scope(`{`, `}`, () => null);
                    w.line();
                    w.line(`/// <summary>`);
                    w.line(`/// Creates a new ${typeName} instance`);
                    w.line(`/// </summary>`);
                    w.line(`/// <param name="${skipInitName}">Whether to skip initializing nested objects.</param>`);
                    w.line(`internal ${typeName}(bool ${skipInitName})`);
                } else {
                    w.line(`public ${typeName}()`);
                }
                w.scope('{', '}', () => {
                    if (type /*.deserialize*/) {
                        w.line(`if (!${skipInitName})`);
                        w.pushScope(`{`);
                    }
                    for (const property of nested) {
                        w.write(`this.${naming.property(property.serializedName)} = `);
                        if (isObjectType(property.schema)) {
                            w.line(`new ${types.getName(property.schema)}();`);
                        } else if (isDictionaryType(property.schema)) {
                            w.line(`new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);`);
                        } else if (isPrimitiveType(property.schema) && property.schema.items) {
                            w.line(`new System.Collections.Generic.List<${types.getName(property.schema.items)}>();`);
                        } else if (isPrimitiveType(property.schema) && property.schema.format === `byte`) {
                            w.line(`System.Array.Empty<byte>();`);
                        }
                    }
                    if (type /*type.deserialize*/) {
                        w.popScope(`}`);
                    }
                });
            }

            // Create serializers if necessary
            for (const serializationType of model.info.consumes) {
                const format =
                    (serializationType === 'application/xml') ? 'Xml' :
                    (serializationType === 'application/json') ? 'Json' :
                    serializationType;
                
                // TODO: JSON, ...
                if (format !== `Xml`) {
                    throw `Currently unsupported serialization format (in ${types.getName(type)})`;
                }
                
                //if (type.serialize) {
                    if (separator()) { w.line(); }
                    generateSerialize(w, service, type, format);
                //}
                
                //if (type.deserialize) {
                    if (separator()) { w.line(); }
                    generateDeserialize(w, service, type, format);
                //}
            }
        });

        // If there are readonly properties, we'll create a model factory
        const props = <IProperty[]>Object.values(type.properties);
        const isPublic = objectTypeIsPublic(type);
        if (isPublic && props.some(p => p.schema.readOnly)) {
            const factoryName = naming.type(model.info.modelFactoryName);
            const typeName = naming.type(getName2(type));
            const modelName = `_model`;
            w.line();
            w.line(`/// <summary>`);
            w.line(`/// ${factoryName} provides utilities for mocking.`);
            w.line(`/// </summary>`);
            w.line(`public static partial class ${factoryName}`);
            w.scope(`{`, `}`, () => {
                w.line(`/// <summary>`);
                w.line(`/// Creates a new ${typeName} instance for mocking.`);
                w.line(`/// </summary>`);
                w.write(`public static ${typeName} ${typeName}(`);
                w.scope(() => {
                    const separator = IndentWriter.createFenceposter();
                    // Sort `= default` parameters last
                    props.sort((a: IProperty, b: IProperty) => type.required.includes(a.serializedName) ? -1 : type.required.includes(b.serializedName) ? 1 : 0);
                    for (const property of props) {
                        if (separator()) { w.line(`,`); }
                        w.write(`${types.getPropertyDeclarationType(property, property.schema)} ${naming.parameter(property.serializedName)}`);
                        if (!type.required.includes(property.serializedName)) { w.write(` = default`); }
                    }
                    w.write(`)`);
                });
                w.scope('{', '}', () => {
                    w.line(`var ${modelName} = new ${typeName}();`);
                    for (const property of props) {
                        w.line(`${modelName}.${naming.property(property.serializedName)} = ${naming.parameter(property.serializedName)};`);
                    }
                    w.line(`return ${modelName};`);
                });
            });
        }
    });
    w.line(`#endregion ${regionName}`);
}

function generateSerialize(w: IndentWriter, service: IService, type: IModelType, format: string) {
    const toName = naming.method(`To ${format}`, false);
    const typeName = naming.type(getName2(type));
    const { name: elementName, ns: elementNamespace } = getXmlNameFromSchema(type);
    w.line(`/// <summary>`);
    w.line(`/// Serialize a ${typeName} instance as XML.`);
    w.line(`/// </summary>`);
    w.line(`/// <param name="value">The ${typeName} instance to serialize.</param>`);
    w.line(`/// <param name="name">An optional name to use for the root element instead of "${elementName}".</param>`);
    w.line(`/// <param name="ns">An optional namespace to use for the root element instead of "${elementNamespace}".</param>`);
    w.line(`/// <returns>The serialized XML element.</returns>`);
    w.line(`internal static System.Xml.Linq.XElement ${toName}(${typeName} value, string name = "${elementName}", string ns = "${elementNamespace}")`);
    w.scope('{', '}', () => {
        w.line(`System.Diagnostics.Debug.Assert(value != null);`)
        const elementName = "_element";
        let elementsName = undefined;

        // Create the element
        w.line(`System.Xml.Linq.XElement ${elementName} = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));`);

        // Serialize each of the properties
        const properties = <IProperty[]>Object.values(type.properties);
        for (const property of properties) {
            let current = elementName;
            let isRequired = type.required.includes(property.serializedName);
            const { xname: childName } = getXmlShape(property.serializedName, type.xml);//{ ...type.xml, name: property.serializedName });
            if (!isRequired) {
                w.line(`if (value.${naming.property(property.serializedName)} != null)`);
                w.pushScope('{');
            }
            const { name: xmlName, ns: xmlNs } = getXmlName(property.serializedName, property.schema.xml);
            const { xname, isAttribute, wrapped } = getXmlShape(property.serializedName, property.schema.xml);
            if (wrapped) {
                if (!elementsName) {
                    elementsName = "_elements";
                    w.write(`System.Xml.Linq.XElement `);
                }
                current = elementsName;
                w.line(`${current} = new System.Xml.Linq.XElement(${xname});`);
            }
            if (isObjectType(property.schema)) {
                //if (!property.model.deserialize) {
                //    throw `Cannot deserialize ${types.getName(type)} if ${types.getName(property.model)} can't be deserialized!`;
                //}
                w.line(`${current}.Add(${types.getName(property.schema)}.${toName}(value.${naming.property(property.serializedName)}, "${xmlName}", "${xmlNs}"));`);
            } else if (isPrimitiveType(property.schema) && property.schema.items) {
                const itemType = property.schema.items;
                const childName = `_child`;
                w.line(`foreach (${types.getName(itemType)} ${childName} in value.${naming.property(property.serializedName)})`);
                w.scope('{', '}', () => {
                    if (isObjectType(itemType) /*&& itemType.serialize*/) {
                        w.line(`${current}.Add(${types.getName(itemType)}.${toName}(${childName}));`);
                    } else if (itemType.type === `string`) {

                        w.line(`${current}.Add(new System.Xml.Linq.XElement(${xname}, ${childName}));`)
                    } else {
                        w.line(`// TODO: Cannot serialize unknown array type`);
                    }
                });
            } else {
                const text = types.convertToString('value.' + naming.property(property.serializedName), property.schema, service, isRequired);
                w.write(`${current}.Add(new System.Xml.Linq.XElement(`);
                w.scope(() => {
                    w.line(`${childName},`);
                    if (property.schema.type === `boolean`) {
                        w.line(`#pragma warning disable CA1308 // Normalize strings to uppercase`);
                    }
                    w.write(`${text}));`);
                    if (property.schema.type === `boolean`) {
                        w.line();
                        w.line(`#pragma warning restore CA1308 // Normalize strings to uppercase`);
                    }
                    
                });
            }
            if (wrapped) {
                w.write(`${elementName}.Add(${current});`);
            }
            if (!isRequired) {
                w.popScope('}');
            }
        }

        w.line(`return ${elementName};`);
    });
}

function generateDeserialize(w: IndentWriter, service: IService, type: IModelType, format: string) {
    const fromName = naming.method(`From ${format}`, false);
    const typeName = naming.type(getName2(type));
    const rootName = 'element';
    w.line(`/// <summary>`);
    w.line(`/// Deserializes XML into a new ${typeName} instance.`);
    w.line(`/// </summary>`);
    w.line(`/// <param name="${rootName}">The XML element to deserialize.</param>`);
    w.line(`/// <returns>A deserialized ${typeName} instance.</returns>`);
    w.line(`internal static ${types.getName(type)} ${fromName}(System.Xml.Linq.XElement ${rootName})`);
    w.scope('{', '}', () => {
        w.line(`System.Diagnostics.Debug.Assert(element != null);`);

        // Optionally declare the _child/_attribute temporaries
        const properties = <IProperty[]>Object.values(type.properties);
        const childName = '_child';
        if (properties.some(p =>
            /* required */ (!type.required.includes(p.serializedName) && (!isPrimitiveType(p.schema) || !p.schema.items || !p.schema.xml || !!p.schema.xml.wrapped)) &&
            /* not attr */ (!p.schema.xml || (p.schema.xml.attribute !== true)) || 
            /* dictionary */ isDictionaryType(p.schema))) {
            w.line(`System.Xml.Linq.XElement ${childName};`);
        }
        const attributeName = '_attribute';
        if (properties.some(p => !type.required.includes(p.serializedName) && (p.schema.xml !== undefined) && (p.schema.xml.attribute === true))) {
            w.line(`System.Xml.Linq.XAttribute ${attributeName};`);
        }

        // Create the model
        const valueName = '_value';
        const skipInit = (<IProperty[]>Object.values(type.properties)).some(p => isObjectType(p.schema) || (isPrimitiveType(p.schema) && (!!p.schema.items || isDictionaryType(p.schema))));
        w.line(`${types.getName(type)} ${valueName} = new ${types.getName(type)}(${skipInit ? 'true' : ''});`);

        // Deserialize each of its properties
        for (const property of properties) {
            let isDict = isDictionaryType(property.schema);
            let isArray = !isDict && isPrimitiveType(property.schema) && property.schema.items !== undefined;
            let isRequired = type.required.includes(property.serializedName);

            let modelType = isArray && property.schema.items ? property.schema.items : property.schema;

            // Get the XML for this propery (attribute and wrapped only come from
            // the property but name also be pulled from the model)
            let { isAttribute, wrapped } = getXmlShape(property.serializedName, property.schema.xml);
            let { xname } = getXmlShapeFromSchema(modelType);
            
            let element = rootName;
            let accessor =
                wrapped && isArray ? 'Element' :
                isAttribute && isArray ? 'Attributes' :
                isAttribute ? 'Attribute' :
                isArray ? 'Elements' :
                'Element';
            element = `${element}.${accessor}(${xname})`;

            // Decide if we have to put it in the _child/_attribute temporaries or can use it directly
            const target = isRequired && !wrapped ? element : (isAttribute ? attributeName : childName);

            // Read and parse the content of an indiviual element or attribute
            const parse = (text: string, model: IModelType): string => {
                if (isObjectType(model)) {
                    //if (!model.deserialize) {
                    //    throw `Cannot deserialize ${types.getName(type)} if ${types.getName(model)} can't be deserialized!`;
                    //}
                    // Change fromName if it ever stops being universal to the format
                    return `${types.getName(model)}.${fromName}(${text})`;
                } else {
                    return types.convertFromString(`${text}.Value`, model, service);
                }
            };

            // Deserialize the XML
            if (isDict) {
                const itemType = property.schema.items;
                if (!itemType || itemType.type !== 'string') {
                    throw `Only string dictionaries are supported for the moment`;
                }
                const pairName = `_pair`;
                w.line(`${valueName}.${naming.property(property.serializedName)} = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);`);
                w.line(`${target} = ${element};`);
                w.line(`if (${target} != null)`);
                w.scope('{', '}', () => {
                    w.line(`foreach (System.Xml.Linq.XElement ${pairName} in ${target}.Elements())`);
                    w.scope(`{`, `}`, () => {
                        w.line(`${valueName}.${naming.property(property.serializedName)}[${pairName}.Name.LocalName] = ${pairName}.Value;`);
                    });    
                });
            } else if (isArray && property.schema.items) {
                // Get the array item type
                let itemType = property.schema.items;
                if (isPrimitiveType(itemType) && itemType.items) {
                    throw `Nested arrays aren't supported!`
                }
                
                // Use LINQ extension methods to map over all the children in a single expression
                const mapAndAssign = (target: string) => {
                    w.write(`${valueName}.${naming.property(property.serializedName)} = `);
                    w.scope('System.Linq.Enumerable.ToList(', '', () => {
                        w.scope(`System.Linq.Enumerable.Select(`, ``, () => {
                            w.line(`${target},`);
                            w.write(`e => ${parse('e', itemType)}));`);
                        });
                    });
                };
                if (wrapped) {
                    const { xname: nested } = getXmlShapeFromSchema(itemType);
                    w.line(`${target} = ${element};`);
                    w.line(`if (${target} != null)`);
                    w.scope('{', '}', () => mapAndAssign(`${target}.Elements(${nested})`));
                    w.line(`else`);
                    w.scope(`{`, `}`, () => {
                        w.write(`${valueName}.${naming.property(property.serializedName)} = `);
                        w.line(`new System.Collections.Generic.List<${types.getName(itemType)}>();`);
                    });
                } else {
                    mapAndAssign(element);
                }
            } else {
                // Assign the value
                const assignment = `${valueName}.${naming.property(property.serializedName)} = ${parse(target, property.schema)};`;
                if (isRequired) {
                    // If a property is required, the XML element will always be there so we can just use it
                    w.line(assignment);
                } else {
                    // Otherwise we'll check if the element is there beforehand
                    w.line(`${target} = ${element};`);
                    w.write(`if (${target} != null`);
                    if (isEnumType(property.schema)) {
                        w.write(` && !string.IsNullOrEmpty(${target}.Value)`);
                    }
                    w.line(`)`);
                    w.scope('{', '}', () => w.line(assignment));
                }
            }
        }
        w.line(`Customize${fromName}(${rootName}, ${valueName});`);
        w.line(`return ${valueName};`);
    });
    w.line();
    w.line(`static partial void Customize${fromName}(System.Xml.Linq.XElement ${rootName}, ${types.getName(type)} value);`);
}

// Get the XML settings for IObjectType, IProperty, etc.
function getXmlShapeFromSchema(schema: Schema) {
  return getXmlShape(getName2(schema), schema.xml);
}
function getXmlShape(defaultName: string, xml?: IXmlSettings) {
    // Get the XML properties
    let { name, ns } = getXmlName(defaultName, xml);
    let isAttribute = (xml ? xml.attribute : undefined) || false;
    let wrapped = (xml ? xml.wrapped : undefined) || false;

    // Create the XML element name
    let xname = `System.Xml.Linq.XName.Get("${name}", "${ns}")`;

    return { xname, isAttribute, wrapped  };
}

// Get the XML settings for IObjectType, IProperty, etc.
function getXmlNameFromSchema(schema: Schema) {
    return getXmlName(getName2(schema), schema.xml);
}

function getXmlName(defaultName: string, xml?: IXmlSettings) {
    // Get the XML properties
    let ns = (xml ? xml.namespace : undefined) || '';
    let name = (xml ? xml.name : undefined) || defaultName;

    return { name, ns};
}
