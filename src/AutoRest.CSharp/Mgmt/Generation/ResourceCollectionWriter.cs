﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;

namespace AutoRest.CSharp.Mgmt.Generation
{
    /// <summary>
    /// Code writer for resource collection.
    /// A resource collection should have 3 operations:
    /// 1. CreateOrUpdate (4 variants)
    /// 2. Get (2 variants)
    /// 3. List (4 variants)
    /// and the following builder methods:
    /// 1. Construct
    /// </summary>
    internal class ResourceCollectionWriter : MgmtClientBaseWriter
    {
        private CodeWriter _writer;
        private ResourceCollection _resourceCollection;
        private ResourceData _resourceData;
        private Resource _resource;
        private BuildContext<MgmtOutputLibrary> _context;
        private bool _isPaging;

        protected override string ContextProperty => "Parent";

        protected CSharpType TypeOfThis => _resourceCollection.Type;
        protected override string TypeNameOfThis => TypeOfThis.Name;

        public ResourceCollectionWriter(CodeWriter writer, ResourceCollection resourceCollection, BuildContext<MgmtOutputLibrary> context)
        {
            _writer = writer;
            _resourceCollection = resourceCollection;
            var operationGroup = resourceCollection.OperationGroup;
            _resourceData = context.Library.GetResourceData(operationGroup);
            _restClient = context.Library.GetRestClient(operationGroup);
            _resource = context.Library.GetArmResource(operationGroup);
            _context = context;
            _isPaging = _resourceCollection.ListMethods.FirstOrDefault()?.PagingMethod != null;
        }

        public void WriteCollection()
        {
            WriteUsings(_writer);
            _writer.UseNamespace(typeof(IEnumerator).Namespace!);
            _writer.UseNamespace(typeof(IEnumerable<>).Namespace!);

            using (_writer.Namespace(TypeOfThis.Namespace))
            {
                _writer.WriteXmlDocumentationSummary($"{_resourceCollection.Description}");
                _writer.Append($"{_resourceCollection.Declaration.Accessibility} partial class {TypeNameOfThis:D} : ");
                _writer.Append($"{typeof(ArmCollection)}, IEnumerable<{_resource.ResourceName}>");
                var asyncEnum = _isPaging ? $", IAsyncEnumerable<{_resource.ResourceName}>" : string.Empty;
                _writer.Line($"{asyncEnum}");
                using (_writer.Scope())
                {
                    WriteFields(_writer, _restClient!);
                    WriteCollectionCtors(_writer, _restClient!, typeof(ArmResource), "parent");
                    WriteEnumerableImpl(_writer);
                    //TODO: this is a workaround to allow resource collection to accept multiple parent resource types
                    //Eventually we can change ValidResourceType to become ValidResourceTypes and rewrite the base Validate().
                    if (_resourceCollection.OperationGroup.IsScopeResource(_context.Configuration.MgmtConfiguration) || _resourceCollection.OperationGroup.IsExtensionResource(_context.Configuration.MgmtConfiguration) && _resourceCollection.GetValidResourceValue() == ResourceCollection.TenantResourceType)
                    {
                        WriteValidate();
                    }
                    WriteCollectionProperties(_writer, _resourceCollection.GetValidResourceValue());
                    WriteResourceOperations();
                    WriteRemainingMethods();
                    WriteBuilders();
                }
            }
        }

        private void WriteEnumerableImpl(CodeWriter writer)
        {
            string value = _isPaging ? string.Empty : ".Value";

            _writer.Line();
            _writer.Line($"IEnumerator<{_resource.ResourceName}> IEnumerable<{_resource.ResourceName}>.GetEnumerator()");
            using (_writer.Scope())
            {
                _writer.Line($"return GetAll(){value}.GetEnumerator();");
            }
            _writer.Line();
            _writer.Line($"IEnumerator IEnumerable.GetEnumerator()");
            using (_writer.Scope())
            {
                _writer.Line($"return GetAll(){value}.GetEnumerator();");
            }

            if (_isPaging)
            {
                _writer.Line();
                _writer.Line($"IAsyncEnumerator<{_resource.ResourceName}> IAsyncEnumerable<{_resource.ResourceName}>.GetAsyncEnumerator(CancellationToken cancellationToken)");
                using (_writer.Scope())
                {
                    _writer.Line($"return GetAllAsync(cancellationToken: cancellationToken){value}.GetAsyncEnumerator(cancellationToken);");
                }
            }
        }

        private void WriteValidate()
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Verify that the input resource Id is a valid collection for this type.");
            _writer.WriteXmlDocumentationParameter("identifier", $"The input resource Id to check.");
            _writer.Line($"protected override void ValidateResourceType(ResourceIdentifier identifier)");
            using (_writer.Scope())
            {
            }
        }

        private void WriteRemainingMethods()
        {
            _writer.Line();
            foreach (var restMethod in _resourceCollection.RemainingMethods)
            {
                WriteClientMethod(_writer, restMethod, restMethod.Name, _resourceCollection.GetDiagnostic(restMethod.RestClientMethod), _resourceCollection.OperationGroup, _context, true);
                WriteClientMethod(_writer, restMethod, restMethod.Name, _resourceCollection.GetDiagnostic(restMethod.RestClientMethod), _resourceCollection.OperationGroup, _context, false);
            }
        }

        private void WriteResourceOperations()
        {
            _writer.Line();
            _writer.LineRaw($"// Collection level operations.");

            if (_resourceCollection.CreateMethod != null)
            {
                WriteCreateOrUpdateVariants(_resourceCollection.CreateMethod, _resourceCollection.PutMethods);
            }

            if (_resourceCollection.GetMethod != null)
            {
                var getMethods = _resourceCollection.GetMethods.Select(m => m.RestClientMethod).ToList();
                WriteGetVariants(_resourceCollection.GetMethod.RestClientMethod, getMethods);
                WriteGetIfExistsVariants(_resourceCollection.GetMethod.RestClientMethod);
                WriteCheckIfExistsVariants(_resourceCollection.GetMethod.RestClientMethod);
            }

            // TODO: Add back code with refactored base method as in WriteCreateOrUpdateVariants
            // if (_resourceCollection.PutByIdMethod != null)
            // {
            //     WriteCreateByIdVariants(_resourceCollection.PutByIdMethod);
            // }

            // if (_resourceCollection.GetByIdMethod?.RestClientMethod != null && _resourceCollection.GetMethod?.RestClientMethod != _resourceCollection.GetByIdMethod.RestClientMethod)
            // {
            //     WriteGetByIdVariants(_resourceCollection.GetByIdMethod.RestClientMethod);
            // }

            WriteListVariants();
        }

        private void WriteCheckIfExistsVariants(RestClientMethod getMethod)
        {
            IEnumerable<Parameter> passThruParameters = BuildPassThroughParameters(getMethod);

            WriteCheckIfExists(getMethod, passThruParameters, false);
            WriteCheckIfExists(getMethod, passThruParameters, true);
        }

        private void WriteCheckIfExists(RestClientMethod getMethod, IEnumerable<Parameter> passThruParameters, bool isAsync)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Tries to get details for this resource from the service.");
            WriteCollectionMethodScope(isAsync, $"{typeof(bool).WrapResponse(isAsync)}", $"CheckIfExists", passThruParameters, writer =>
            {
                WriteCheckIfExistsBody(getMethod, isAsync);
            }, isOverride: false);
        }

        private void WriteCheckIfExistsBody(RestClientMethod method, bool isAsync)
        {
            IEnumerable<Parameter> passThruParameters = BuildPassThroughParameters(method);
            _writer.Append($"var response = {GetAwait(isAsync)} GetIfExists{GetAsyncSuffix(isAsync)}(");
            foreach (var parameter in passThruParameters)
            {
                _writer.AppendRaw(parameter.Name);
                _writer.AppendRaw(", ");
            }
            _writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");
            _writer.Line($"return Response.FromValue(response.Value != null, response.GetRawResponse());");
        }

        private void WriteGetIfExistsVariants(RestClientMethod getMethod)
        {
            IEnumerable<Parameter> passThruParameters = BuildPassThroughParameters(getMethod);

            WriteGetIfExists(getMethod, passThruParameters, false);
            WriteGetIfExists(getMethod, passThruParameters, true);
        }

        private void WriteGetIfExists(RestClientMethod getMethod, IEnumerable<Parameter> passThruParameters, bool isAsync)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Tries to get details for this resource from the service.");
            WriteCollectionMethodScope(isAsync, $"{_resource.Type.WrapResponse(isAsync)}", "GetIfExists", passThruParameters, writer =>
            {
                WriteGetFromRestClient(getMethod, isAsync);
                WriteEndOfGetIfExists();
            }, isOverride: false);
        }

        private void WriteEndOfGetIfExists()
        {
            _writer.Line($"return response.Value == null");
            _writer.Line($"\t? Response.FromValue<{_resource.Type.Name}>(null, response.GetRawResponse())");
            _writer.Line($"\t: Response.FromValue(new {_resource.Type.Name}(this, response.Value), response.GetRawResponse());");
        }

        private void WriteCreateOrUpdateVariants(RestClientMethod clientMethod, List<RestClientMethod>? clientMethods = null)
        {
            WriteLROMethod(_writer, clientMethod, _context, false, false, true, "CreateOrUpdate", clientMethods);
            WriteLROMethod(_writer, clientMethod, _context, false, true, true, "CreateOrUpdate", clientMethods);
        }

        /// <summary>
        /// Write some scaffolding for collection operation methods.
        /// </summary>
        /// <param name="isAsync"></param>
        /// <param name="returnType">Must be string.</param>
        /// <param name="syncMethodName">Method name in its sync form.</param>
        /// <param name="parameters">Must not contain cancellationToken.</param>
        /// <param name="inner">Main logic of the method writer.</param>
        /// <param name="isOverride"></param>
        private void WriteCollectionMethodScope(bool isAsync, FormattableString returnType, string syncMethodName, IEnumerable<Parameter> parameters, CodeWriterDelegate inner, bool isOverride = false, bool catch404 = false)
        {
            if (isOverride)
            {
                _writer.WriteXmlDocumentationInheritDoc();
            }
            foreach (var parameter in parameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }

            const string cancellationTokenParameter = "cancellationToken";
            _writer.WriteXmlDocumentationParameter(cancellationTokenParameter, $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");

            _writer.Append($"public {GetAsyncKeyword(isAsync)} {GetOverride(isOverride, true)} {returnType} {CreateMethodName(syncMethodName, isAsync)}(");
            foreach (var parameter in parameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Append($"{typeof(CancellationToken)} {cancellationTokenParameter} = default)");
            using var _ = _writer.Scope();
            using (WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceCollection.Type.Name}.{syncMethodName}"), ClientDiagnosticsField, catch404))
            {
                _writer.WriteParameterNullChecks(parameters.ToList());
                inner(_writer);
            }
        }

        private void WriteGetFromRestClient(RestClientMethod method, bool isAsync)
        {
            var parameterMapping = BuildParameterMapping(method);
            _writer.Append($"var response = {GetAwait(isAsync)} {RestClientField}.{method.Name}{GetAsyncSuffix(isAsync)}(");
            WriteArguments(_writer, parameterMapping);
            _writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");
        }
        private void WriteGetVariants(RestClientMethod method, List<RestClientMethod> methods)
        {
            IEnumerable<ParameterMapping> parameterMapping = BuildParameterMapping(method);
            WriteGetMethod(method, parameterMapping, false, methods, "Get");
            WriteGetMethod(method, parameterMapping, true, methods, "Get");
        }

        private void WriteGetMethod(RestClientMethod method, IEnumerable<ParameterMapping> parameterMapping, bool async, List<RestClientMethod> methods, string? methodName = null)
        {
            methodName = methodName ?? method.Name;
            parameterMapping = parameterMapping ?? BuildParameterMapping(method);
            var scopeName = methodName;

            IEnumerable<Parameter> passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets details for this resource from the service.");
            var taskStrStart = async ? $"{typeof(Task)}<" : string.Empty;
            var taskStrEnd = async ? ">" : string.Empty;
            WriteCollectionMethodScope(async, $"{taskStrStart}{typeof(Response)}<{_resource.Type.Name}>{taskStrEnd}", methodName, passThruParameters, writer =>
            {
                if (method.Operation.IsAncestorScope() || methods.Count < 2)
                {
                    WriteGetMethodBody(writer, method, parameterMapping, async);
                }
                else
                {
                    var methodDict = methods.ToDictionary(m => m, m => m.Operation.AncestorResourceType());
                    // There could be methods at resource group scope and at resource scope, both with ResourceGroups AncestorResourceType.
                    RestClientMethod? resourceMethod = null;
                    var resourceGroupMethod = methodDict.FirstOrDefault(kv => kv.Value == ResourceTypeBuilder.ResourceGroups).Key;
                    var resourceGroupMethodsCount = methodDict.Count(kv => kv.Value == ResourceTypeBuilder.ResourceGroups);
                    if (resourceGroupMethodsCount > 1)
                    {
                        // The parent resource type of a resource method is always resourceGroupsResources
                        resourceMethod = methodDict.FirstOrDefault(kv => kv.Key.Operation.ParentResourceType() == ResourceTypeBuilder.ResourceGroupResources).Key;
                        if (resourceMethod != null)
                        {
                            methodDict.Remove(resourceMethod);
                            resourceGroupMethod = methodDict.FirstOrDefault(kv => kv.Value == ResourceTypeBuilder.ResourceGroups).Key;
                        }
                    }
                    if (resourceGroupMethod != null)
                    {
                        methodDict.Remove(resourceGroupMethod);
                        var resourceGroupNameVar = resourceMethod == null ? "_" : "var resourceGroupName";
                        using (writer.Scope($"if (Id.TryGetResourceGroupName(out {resourceGroupNameVar}))"))
                        {
                            if (resourceMethod != null)
                            {
                                using (writer.Scope($"if (Id.ResourceType.Equals({typeof(ResourceGroup)}.ResourceType))"))
                                {
                                    WriteGetMethodBody(writer, resourceGroupMethod, BuildParameterMapping(resourceGroupMethod), async);
                                }
                                using (writer.Scope($"else"))
                                {
                                    WriteGetMethodBody(writer, resourceMethod, BuildParameterMapping(resourceMethod), async, isResourceLevel: true);
                                }
                            }
                            else
                            {
                                WriteGetMethodBody(writer, resourceGroupMethod, BuildParameterMapping(resourceGroupMethod), async);
                            }
                        }
                    } // No else clause with the assumption that resourceMethod only exists when resourceGroupMethod exists.
                    var managementGroupMethod = methodDict.FirstOrDefault(kv => kv.Value == ResourceTypeBuilder.ManagementGroups).Key;
                    var tenantMethod = methodDict.FirstOrDefault(kv => kv.Value == ResourceTypeBuilder.Tenant).Key;
                    var elseStr = resourceGroupMethod != null ? (managementGroupMethod == null && tenantMethod == null ? "else" : "else if") : "if";
                    var subscriptionMethod = methodDict.FirstOrDefault(kv => kv.Value == ResourceTypeBuilder.Subscriptions).Key;
                    if (subscriptionMethod != null)
                    {
                        methodDict.Remove(subscriptionMethod);
                        using (writer.Scope($"{elseStr} (Id.TryGetSubscriptionId(out _))"))
                        {
                            WriteGetMethodBody(writer, subscriptionMethod, BuildParameterMapping(subscriptionMethod), async);
                        }
                    }

                    elseStr = (!elseStr.IsNullOrEmpty() || subscriptionMethod != null) ? "else " : string.Empty;
                    if (managementGroupMethod != null)
                    {
                        methodDict.Remove(managementGroupMethod);
                        using (elseStr.IsNullOrEmpty() ? null : writer.Scope($"{elseStr}"))
                        {
                            if (tenantMethod != null)
                            {
                                methodDict.Remove(tenantMethod);
                                var parent = new CodeWriterDeclaration("parent");
                                writer.Line($"var {parent:D} = Id;");
                                using (writer.Scope($"while ({parent}.Parent != {typeof(ResourceIdentifier)}.RootResourceIdentifier)"))
                                {
                                    writer.Line($"{parent} = {parent}.Parent;");
                                }
                                using (writer.Scope($"if (parent.ResourceType.Equals({typeof(ManagementGroup)}.ResourceType))"))
                                {
                                    WriteGetMethodBody(writer, managementGroupMethod, BuildParameterMapping(managementGroupMethod), async);
                                }
                                using (writer.Scope($"else"))
                                {
                                    WriteGetMethodBody(writer, tenantMethod, BuildParameterMapping(tenantMethod), async);
                                }
                            }
                            else
                            {
                                WriteGetMethodBody(writer, managementGroupMethod, BuildParameterMapping(managementGroupMethod), async);
                            }
                        }
                    }
                    else if (tenantMethod != null)
                    {
                        methodDict.Remove(tenantMethod);
                        using (writer.Scope($"{elseStr}"))
                        {
                            WriteGetMethodBody(writer, tenantMethod, BuildParameterMapping(tenantMethod), async);
                        }
                    }

                    if (methodDict.Count() > 0)
                    {
                        throw new Exception($"When trying to merge methods, multiple methods can be mapped to the same scope. The methods not handled: {String.Join(", ", methodDict.Select(kv => kv.Key.Name).ToList())}.");
                    }
                }
            }, isOverride: false);
        }

        private void WriteGetMethodBody(CodeWriter writer, RestClientMethod method, IEnumerable<ParameterMapping> parameterMapping, bool async, bool isResourceLevel = false)
        {
            if (isResourceLevel)
            {
                writer.UseNamespace("System.Collections.Generic");
                writer.Line($"var parent = Id.Parent;");
                writer.Line($"var parentParts = new List<string>();");
                using (writer.Scope($"while (!parent.ResourceType.Equals({typeof(ResourceGroup)}.ResourceType))"))
                {
                    writer.Line($"parentParts.Insert(0, $\"{{parent.ResourceType.Types[parent.ResourceType.Types.Count - 1]}}/{{parent.Name}}\");");
                    writer.Line($"parent = parent.Parent;");
                }
                writer.Line($"var parentResourcePath = parentParts.Count > 0 ? string.Join(\"/\", parentParts) : \"\";");
                writer.Line($"Id.TryGetSubscriptionId(out var subscriptionId);");
            }
            _writer.Append($"var response = {GetAwait(async)} {RestClientField}.{CreateMethodName($"{method.Name}", async)}(");
            BuildAndWriteParameters(writer, method, parameterMapping, isResourceLevel);
            _writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(async)};");
            WriteEndOfGet(_writer, _resource.Type, async);
        }

        private void WriteGetByIdVariants(RestClientMethod method, bool isAsync)
        {
            var parameterMapping = BuildParameterMapping(method);

            var methodName = "GetById";
            var scopeName = methodName;

            IEnumerable<Parameter> passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets details for this resource from the service by ID.");
            WriteCollectionMethodScope(isAsync, $"{_resource.Type.WrapResponse(isAsync)}", methodName, passThruParameters, writer =>
            {
                _writer.Append($"var response = {GetAwait(isAsync)} {RestClientField}.{method.Name}{GetAsyncSuffix(isAsync)}(");
                BuildAndWriteParameters(writer, method, parameterMapping);
                _writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");
                WriteEndOfGet(_writer, _resource.Type, isAsync);
            }, isOverride: false);
        }

        private void WriteListVariants()
        {
            var pagingMethods = _resourceCollection.ListMethods.Where(m => m.PagingMethod != null).Select(m => m.PagingMethod!).ToList();
            var pagingMethod = pagingMethods.OrderBy(m => m.Name.Length).FirstOrDefault();
            var clientMethods = _resourceCollection.ListMethods.Where(m => m.ClientMethod != null).Select(m => m.ClientMethod!).ToList();
            var clientMethod = clientMethods.OrderBy(m => m.Name.Length).FirstOrDefault();
            if (_resourceCollection.IsScopeOrExtension)
            {
                if (pagingMethod != null)
                {
                    WriteList(_writer, false, _resource.Type, pagingMethod, "GetAll", $".Select(value => new {_resource.Type.Name}({ContextProperty}, value))", pagingMethods);
                    WriteList(_writer, true, _resource.Type, pagingMethod, "GetAll", $".Select(value => new {_resource.Type.Name}({ContextProperty}, value))", pagingMethods);
                }

                _writer.Line();
                if (clientMethod != null)
                {
                    //TODO: merge methods like WriteList
                    WriteClientMethod(_writer, clientMethod, "GetAll", new Diagnostic($"{TypeNameOfThis}.GetAll", Array.Empty<DiagnosticAttribute>()), _resourceCollection.OperationGroup, _context, true);
                    WriteClientMethod(_writer, clientMethod, "GetAll", new Diagnostic($"{TypeNameOfThis}.GetAll", Array.Empty<DiagnosticAttribute>()), _resourceCollection.OperationGroup, _context, false);
                }
            }
            else
            {
                foreach (var listMethod in _resourceCollection.ListMethods)
                {
                    if (listMethod.PagingMethod != null)
                    {
                        WriteList(_writer, false, _resource.Type, listMethod.PagingMethod, "GetAll", $".Select(value => new {_resource.Type.Name}({ContextProperty}, value))");
                        WriteList(_writer, true, _resource.Type, listMethod.PagingMethod, "GetAll", $".Select(value => new {_resource.Type.Name}({ContextProperty}, value))");
                    }

                    if (listMethod.ClientMethod != null)
                    {
                        _writer.Line();
                        WriteClientMethod(_writer, listMethod.ClientMethod, "GetAll", new Diagnostic($"{TypeNameOfThis}.GetAll", Array.Empty<DiagnosticAttribute>()), _resourceCollection.OperationGroup, _context, true);
                        WriteClientMethod(_writer, listMethod.ClientMethod, "GetAll", new Diagnostic($"{TypeNameOfThis}.GetAll", Array.Empty<DiagnosticAttribute>()), _resourceCollection.OperationGroup, _context, false);
                    }
                }
            }
            if (_resourceCollection.GetValidResourceValue().Equals(ResourceCollection.ResourceGroupResourceType) || _resourceCollection.GetValidResourceValue().Equals(ResourceCollection.SubscriptionResourceType))
            {
                WriteListAsGenericResource(isAsync: false);
                WriteListAsGenericResource(isAsync: true);
            }
        }

        private void WriteListAsGenericResource(bool isAsync)
        {
            const string syncMethodName = "GetAllAsGenericResources";
            string listScope = _resourceCollection.GetValidResourceValue() == ResourceCollection.ResourceGroupResourceType ? "resource group" : "subscription";
            var methodName = CreateMethodName(syncMethodName, isAsync);
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of <see cref=\"{_resource.Type}\" /> for this {listScope} represented as generic resources.");
            _writer.WriteXmlDocumentationParameter("nameFilter", $"The filter used in this operation.");
            _writer.WriteXmlDocumentationParameter("expand", $"Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`.");
            _writer.WriteXmlDocumentationParameter("top", $"The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentation("returns", $"{(isAsync ? "An async" : "A")} collection of resource that may take multiple service requests to iterate over.");
            CSharpType returnType = typeof(GenericResource).WrapPageable(isAsync);
            using (_writer.Scope($"public {GetVirtual(true)} {returnType} {methodName}(string nameFilter, string expand = null, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                using (WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceCollection.Type.Name}.{syncMethodName}"), ClientDiagnosticsField))
                {
                    _writer.Line($"var filters = new {typeof(ResourceFilterCollection)}({_resource.Type}.ResourceType);");
                    _writer.Line($"filters.SubstringFilter = nameFilter;");
                    if (listScope.Equals("resource group"))
                    {
                        _writer.Line($"return {typeof(ResourceListOperations)}.{CreateMethodName("GetAtContext", isAsync)}({ContextProperty} as {typeof(ResourceGroup)}, filters, expand, top, cancellationToken);");
                    }
                    else
                    {
                        _writer.Line($"return {typeof(ResourceListOperations)}.{CreateMethodName("GetAtContext", isAsync)}({ContextProperty} as {typeof(Subscription)}, filters, expand, top, cancellationToken);");
                    }
                }
            }
        }

        private void WriteBuilders()
        {
            _writer.Line();
            _writer.Line($"// Builders.");
            _writer.LineRaw($"// public ArmBuilder<{_resourceCollection.ResourceIdentifierType.Name}, {_resource.Type.Name}, {_resourceData.Type.Name}> Construct() {{ }}");
        }

        protected override void MakeResourceNameParamPassThrough(RestClientMethod restMethod, List<ParameterMapping> parameterMapping, Stack<string> parentNameStack)
        {
            // if the method needs resource name (typically all non-list methods), we should make it pass-thru by
            // making the last string-like mandatory parameter (typically the resource name) pass-through
            if (!restMethod.IsListMethod())
            {
                var lastString = parameterMapping.LastOrDefault(parameter => parameter.Parameter.Type.IsStringLike() && IsMandatory(parameter.Parameter));
                if (lastString?.Parameter != null)
                {
                    var paramName = lastString.Parameter.Name;
                    if (!paramName.Equals("resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                    {
                        lastString.IsPassThru = true;
                        parentNameStack.Pop();
                    }
                }
            }
        }

        protected override bool ShouldPassThrough(ref string dotParent, Stack<string> parentNameStack, Parameter parameter, ref string valueExpression)
        {
            bool passThru = false;
            var isAncestorResourceTypeTenant = _resource.OperationGroup.IsAncestorResourceTypeTenant(_context);
            if (string.Equals(parameter.Name, "resourceGroupName", StringComparison.InvariantCultureIgnoreCase) && !isAncestorResourceTypeTenant)
            {
                valueExpression = "Id.ResourceGroupName";
            }
            else
            {
                // collection.Id is the ID of parent resource, so the first name should just be `Id.Name`
                parentNameStack.Push($"Id{dotParent}.Name");
                dotParent += ".Parent";
            }

            return passThru;
        }
    }
}