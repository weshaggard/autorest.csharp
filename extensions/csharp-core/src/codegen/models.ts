// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

import { ITemplate } from "./template";
import {
  ModelState,
  codemodel,
  HttpOperation,
  Schema,
  JsonType,
  XML,
  Property,
  HttpOperationParameter,
  NewResponse,
  Header
} from "@microsoft.azure/autorest.codemodel-v3";
import { Server } from "@microsoft.azure/autorest.codemodel-v3/dist/code-model/components";
import { Dictionary } from "@microsoft.azure/codegen";
import * as naming from "./naming";

// ####################################
// 0. AutoRest abstractions
// ####################################

// ####################################
// 1. Project files/settings
// ####################################

export interface ILogger {
  // Log information, errors, and verbose messages
  log(message: string): void;
  warn(message: string): void;
  error(message: string): void;
  verbose(message: string): void;
}

// A project full of files to translate into generated code
export interface IProject {
  // Generator context
  //context: IAutoRestPluginInitiator;

  // Top level settings
  settings: { [key: string]: any };

  // Swagger source file
  //swagger: any;

  state: ModelState<codemodel.Model>;

  // Swagger cache for resolving references
  // cache: {
  //   info?: IServiceInfo;
  //   parameters: IParameters;
  //   definitions: IModels;
  //   responses: IResponses;
  //   customTypes: IModels;
  //   voidType: IVoidType;
  // };

  logger: ILogger;
}

// ####################################
// 2. Service Model
// ####################################

export interface IServiceModel {
  //  context: IAutoRestPluginInitiator;
  info: IServiceInfo;
  service: IService;
  models?: IModels;
  //  voidType?: IVoidType;
}

export interface IServiceInfo {
  title: string;
  description: string | undefined;
  //namespace: string;
  extensionsName: string;
  modelFactoryName: string;
  public: boolean;
  sync: boolean;
  consumes: string[];
  produces: string[];
  license: {
    name: string;
    header: string;
  };
  version: string;
  host: Server;
  // {
  //  template: ITemplate;
  //  parameters: IParameters;
  //  useSchemePrefix: boolean;
  //  position: string;
  //};
}

export interface IService {
  title: string;
  description: string | undefined;
  namespace: string;
  name: string;
  extensionsName: string;
  groups: {
    [key: string]: IOperationGroup;
  };
  operations: IOperationGroup;
}

export interface IModels {
  [key: string]: IModelType | undefined;
}

export type IModelType = Schema;
// export interface IModelType {
//   type: string;
//   description?: string;
//   external?: boolean;
//   extendedHeaders: IHeader[];
// }

// export interface IVoidType extends IModelType {
//   type2: "void";
//   external?: true;
// }

export function isHeaderIgnored(header: Header) {
  return header.extensions[`x-az-demote-header`];
}
export function hasNoResponseType(response: NewResponse) {
  let notIgnoredHeaders = response.headers.filter(h => !isHeaderIgnored(h));

  // if there are no ignored headers and no schema model then we should treat as a void type
  if (notIgnoredHeaders.length === 0 && response.schema === undefined)
    return true;

  return false;
}

// export interface IObjectType extends IModelType {
//   name: string;
//   namespace: string;
//   properties: IProperties;
//   additionalPropeties?: IModelType;
//   xml?: IXmlSettings;
//   serialize: boolean;
//   deserialize: boolean;
//   disableWarnings?: string;
//   public: boolean;
//}

export function isObjectType(model: IModelType) {
  return model.type === `object`;
}

export function isDictionaryType(model: IModelType): boolean {
  return (
    model.type === "object" &&
    model.properties === undefined &&
    model.additionalProperties !== undefined
  );
}

export type IProperties = Dictionary<Property>;
// export interface IProperties {
//   [name: string]: IProperty | undefined;
// }

export type IProperty = Property;
// export interface IProperty {
//   name: string;
//   clientName: string;
//   description?: string;
//   required?: boolean;
//   readonly: boolean;
//   xml?: IXmlSettings;
//   model: IModelType;
// }

export type IXmlSettings = XML;
// export interface IXmlSettings {f
//   name?: string;
//   namespace?: string;
//   prefix?: string;
//   attribute?: boolean;
//   wrapped?: boolean;
// }

// export interface IEnumType extends IModelType {
//   name: string;
//   namespace: string;
//   modelAsString?: boolean;
//   customSerialization: boolean;
//   constant: boolean;
//   public: boolean;
//   values: IEnumValue[];
// }

// export interface IEnumValue {
//   value: any;
//   name?: string;
//   description?: string;
// }

export function isEnumType(model: IModelType) {
  return model.enum !== undefined && model.enum.length > 0;
}

export function isStringEnumType(model: IModelType) {
  if (model.enum === undefined) return false;

  const msEnum = model.extensions[`x-ms-enum`];
  if (msEnum && msEnum[`modelAsString`]) return true;

  return false;
}

export function enumRequireCustomSerialization(model: IModelType) {
  if (model.enum === undefined) return false;

  return model.enum.some(v => v.value !== naming.enumField(v.name || v.value));
}

export function getEnumName(type: IModelType) {
  return (
    type.extensions[`x-ms-enum`] ||
    type.extensions[`x-ms-client-name`] ||
    type.extensions[`name`] ||
    "UNKNOWN ENUM TYPE NAME"
  );
}

// export interface IPrimitiveType extends IModelType {
//   allowEmpty?: boolean;
//   collectionFormat?: string;
//   maximum?: number;
//   exclusiveMaximum?: boolean;
//   minimum?: number;
//   exclusiveMinimum?: boolean;
//   multipleOf?: number;
//   maxLength?: number;
//   minLength?: number;
//   maxItems?: number;
//   minItems?: number;
//   uniqueItems?: boolean;
//   pattern?: string;
//   defaultValue?: any;
//   xml?: IXmlSettings;
//   itemType?: IModelType;
//   dictionaryPrefix?: string;
// }

export function isPrimitiveType(model: IModelType) {
  return model.type !== JsonType.Object && !isEnumType(model);
}

export interface IParameters {
  [key: string]: IParameter | undefined;
}

export type IParameter = HttpOperationParameter;
// export interface IParameter {
//   name: string;
//   clientName: string;
//   description?: string;
//   required: boolean;
//   location: string;
//   skipUrlEncoding: boolean;
//   parameterGroup?: string;
//   model: IModelType;
//   trace: boolean;
// }

export interface IResponses {
  [code: string]: IResponse | undefined;
}

export type IResponse = NewResponse;
// export interface IResponse {
//   code: string;
//   description?: string;
//   clientName?: string;
//   body?: IModelType;
//   bodyClientName: string;
//   headers: IHeaders;
//   model?: IModelType;
//   exception?: boolean;
//   public: boolean;
// }

export interface IResponseGroup {
  model: IModelType;
  successes: IResponse[];
  failures: IResponse[];
}

export interface IHeaders {
  [key: string]: IHeader | undefined;
}

export type IHeader = Header;
// export interface IHeader {
//   name: string;
//   clientName: string;
//   description?: string;
//   collectionPrefix?: string;
//   model: IModelType;
//   ignore: boolean;
// }

export type IOperationGroup = Dictionary<HttpOperation>;

export type IOperation = HttpOperation;
// export interface IOperation {
//   name: string;
//   group?: string;
//   method: string;
//   path: ITemplate;
//   summary?: string;
//   description?: string;
//   consumes: string;
//   produces: string;
//   request: {
//     all: IParameter[];
//     arguments: IParameter[];
//     constants: IParameter[];
//     paths: IParameter[];
//     queries: IParameter[];
//     headers: IParameter[];
//     body?: IParameter;
//   };
//   response: IResponseGroup;
//   paging?: {
//     nextLinkName: string;
//     itemName?: string;
//     operationName: string;
//   };
// }
