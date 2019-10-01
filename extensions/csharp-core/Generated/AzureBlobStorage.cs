// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

// This file was automatically generated.  Do not edit.

#region Service
namespace DefaultNS.AzureBlobStorage
{
    /// <summary>
    /// Azure Blob Storage
    /// </summary>
    public static partial class AzureBlobStorage
    {
        #region service operations operations
        /// <summary>
        /// service operations operations for Azure Blob Storage
        /// </summary>
        public static partial class ServiceOperations
        {
            #region Service.Service_SetProperties
            /// <summary>
            /// Sets properties for a storage account's Blob service endpoint, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success (Accepted)</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ServiceSetPropertiesAsync(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ServiceClient.Service_SetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ServiceSetPropertiesAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        comp,
                        timeout,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ServiceSetPropertiesAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Service.Service_SetProperties request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.Service_SetProperties Request.</returns>
            internal static Azure.Core.Http.Request ServiceSetPropertiesAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "service");
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                // Create the body
                System.Xml.Linq.XElement _body = Object.ToXml(storageServiceProperties, "storageServiceProperties", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Service.Service_SetProperties response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.Service_SetProperties Azure.Response.</returns>
            internal static Azure.Response ServiceSetPropertiesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Service.Service_SetProperties

            #region Service.Service_GetProperties
            /// <summary>
            /// gets the properties of a storage account's Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Object>> ServiceGetPropertiesAsync(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ServiceClient.Service_GetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ServiceGetPropertiesAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        comp,
                        timeout,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ServiceGetPropertiesAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Service.Service_GetProperties request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.Service_GetProperties Request.</returns>
            internal static Azure.Core.Http.Request ServiceGetPropertiesAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "service");
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Service.Service_GetProperties response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.Service_GetProperties Azure.Response{Object}.</returns>
            internal static Azure.Response<Object> ServiceGetPropertiesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }

                        // Create the response
                        Azure.Response<Object> _result =
                            new Azure.Response<Object>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Service.Service_GetProperties

            #region Container.Container_SetMetadata
            /// <summary>
            /// operation sets one or more user-defined name-value pairs for the specified container.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ContainerSetMetadataAsync(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSMeta = default,
                String? ifModifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_SetMetadata",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerSetMetadataAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        comp,
                        timeout,
                        xMSLeaseID,
                        xMSMeta,
                        ifModifiedSince,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerSetMetadataAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_SetMetadata request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_SetMetadata Request.</returns>
            internal static Azure.Core.Http.Request ContainerSetMetadataAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSMeta = default,
                String? ifModifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "metadata");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSMeta != null) { _request.Headers.SetValue("x-ms-meta", xMSMeta); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_SetMetadata response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_SetMetadata Azure.Response.</returns>
            internal static Azure.Response ContainerSetMetadataAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_SetMetadata

            #region Container.Container_GetAccessPolicy
            /// <summary>
            /// gets the permissions for the specified container. The permissions indicate whether container data may be accessed publicly.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Array>> ContainerGetAccessPolicyAsync(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_GetAccessPolicy",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerGetAccessPolicyAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        comp,
                        timeout,
                        xMSLeaseID,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerGetAccessPolicyAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_GetAccessPolicy request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_GetAccessPolicy Request.</returns>
            internal static Azure.Core.Http.Request ContainerGetAccessPolicyAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "acl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_GetAccessPolicy response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_GetAccessPolicy Azure.Response{Array}.</returns>
            internal static Azure.Response<Array> ContainerGetAccessPolicyAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        // TODO: Deserialize unexpected type

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("BlobPublicAccess", out _header))
                        {
                            _value.BlobPublicAccess = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = _header;
                        }

                        // Create the response
                        Azure.Response<Array> _result =
                            new Azure.Response<Array>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_GetAccessPolicy

            #region Container.Container_SetAccessPolicy
            /// <summary>
            /// sets the permissions for the specified container. The permissions indicate whether blobs in a container may be accessed publicly.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobPublicAccess">Specifies whether data in the container may be accessed publicly and the level of access</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ContainerSetAccessPolicyAsync(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSBlobPublicAccess = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_SetAccessPolicy",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerSetAccessPolicyAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        comp,
                        timeout,
                        xMSLeaseID,
                        xMSBlobPublicAccess,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerSetAccessPolicyAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_SetAccessPolicy request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobPublicAccess">Specifies whether data in the container may be accessed publicly and the level of access</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_SetAccessPolicy Request.</returns>
            internal static Azure.Core.Http.Request ContainerSetAccessPolicyAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSBlobPublicAccess = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "acl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSBlobPublicAccess != null) { _request.Headers.SetValue("x-ms-blob-public-access", xMSBlobPublicAccess); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                // Create the body
                System.Xml.Linq.XElement _body = null;
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_SetAccessPolicy response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_SetAccessPolicy Azure.Response.</returns>
            internal static Azure.Response ContainerSetAccessPolicyAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_SetAccessPolicy

            #region Container.Container_AcquireLease
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseDuration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="xMSProposedLeaseID">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Acquire operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ContainerAcquireLeaseAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string restype,
                string xMSLeaseAction,
                Integer? timeout = default,
                Integer? xMSLeaseDuration = default,
                String? xMSProposedLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_AcquireLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerAcquireLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        restype,
                        xMSLeaseAction,
                        timeout,
                        xMSLeaseDuration,
                        xMSProposedLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerAcquireLeaseAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_AcquireLease request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseDuration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="xMSProposedLeaseID">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_AcquireLease Request.</returns>
            internal static Azure.Core.Http.Request ContainerAcquireLeaseAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string restype,
                string xMSLeaseAction,
                Integer? timeout = default,
                Integer? xMSLeaseDuration = default,
                String? xMSProposedLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (xMSLeaseAction == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseAction));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "acquire");
                if (xMSLeaseDuration != null) { _request.Headers.SetValue("x-ms-lease-duration", UNKNOWN ENUM TYPE NAME); }
                if (xMSProposedLeaseID != null) { _request.Headers.SetValue("x-ms-proposed-lease-id", xMSProposedLeaseID); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_AcquireLease response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_AcquireLease Azure.Response.</returns>
            internal static Azure.Response ContainerAcquireLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_AcquireLease

            #region Container.Container_ReleaseLease
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Release operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ContainerReleaseLeaseAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string restype,
                string xMSLeaseAction,
                Integer? timeout = default,
                String xMSLeaseID,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_ReleaseLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerReleaseLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        restype,
                        xMSLeaseAction,
                        timeout,
                        xMSLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerReleaseLeaseAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_ReleaseLease request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_ReleaseLease Request.</returns>
            internal static Azure.Core.Http.Request ContainerReleaseLeaseAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string restype,
                string xMSLeaseAction,
                Integer? timeout = default,
                String xMSLeaseID,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (xMSLeaseAction == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseAction));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "release");
                _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID);
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_ReleaseLease response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_ReleaseLease Azure.Response.</returns>
            internal static Azure.Response ContainerReleaseLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_ReleaseLease

            #region Container.Container_RenewLease
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Renew operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ContainerRenewLeaseAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string restype,
                string xMSLeaseAction,
                Integer? timeout = default,
                String xMSLeaseID,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_RenewLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerRenewLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        restype,
                        xMSLeaseAction,
                        timeout,
                        xMSLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerRenewLeaseAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_RenewLease request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_RenewLease Request.</returns>
            internal static Azure.Core.Http.Request ContainerRenewLeaseAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string restype,
                string xMSLeaseAction,
                Integer? timeout = default,
                String xMSLeaseID,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (xMSLeaseAction == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseAction));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "renew");
                _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID);
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_RenewLease response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_RenewLease Azure.Response.</returns>
            internal static Azure.Response ContainerRenewLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_RenewLease

            #region Container.Container_BreakLease
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseBreakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Break operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ContainerBreakLeaseAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string restype,
                string xMSLeaseAction,
                Integer? timeout = default,
                Integer? xMSLeaseBreakPeriod = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_BreakLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerBreakLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        restype,
                        xMSLeaseAction,
                        timeout,
                        xMSLeaseBreakPeriod,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerBreakLeaseAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_BreakLease request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseBreakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_BreakLease Request.</returns>
            internal static Azure.Core.Http.Request ContainerBreakLeaseAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string restype,
                string xMSLeaseAction,
                Integer? timeout = default,
                Integer? xMSLeaseBreakPeriod = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (xMSLeaseAction == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseAction));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "break");
                if (xMSLeaseBreakPeriod != null) { _request.Headers.SetValue("x-ms-lease-break-period", UNKNOWN ENUM TYPE NAME); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_BreakLease response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_BreakLease Azure.Response.</returns>
            internal static Azure.Response ContainerBreakLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_BreakLease

            #region Container.Container_ChangeLease
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">Specifies the current lease ID on the resource.</param>
            /// <param name="xMSProposedLeaseID">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Change operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ContainerChangeLeaseAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string restype,
                string xMSLeaseAction,
                Integer? timeout = default,
                String xMSLeaseID,
                String xMSProposedLeaseID,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_ChangeLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerChangeLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        restype,
                        xMSLeaseAction,
                        timeout,
                        xMSLeaseID,
                        xMSProposedLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerChangeLeaseAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_ChangeLease request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">Specifies the current lease ID on the resource.</param>
            /// <param name="xMSProposedLeaseID">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_ChangeLease Request.</returns>
            internal static Azure.Core.Http.Request ContainerChangeLeaseAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string restype,
                string xMSLeaseAction,
                Integer? timeout = default,
                String xMSLeaseID,
                String xMSProposedLeaseID,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (xMSLeaseAction == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseAction));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "change");
                _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID);
                _request.Headers.SetValue("x-ms-proposed-lease-id", xMSProposedLeaseID);
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_ChangeLease response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_ChangeLease Azure.Response.</returns>
            internal static Azure.Response ContainerChangeLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_ChangeLease

            #region Container.Container_ListBlobFlatSegment
            /// <summary>
            /// [Update] The List Blobs operation returns a list of the blobs under the specified container
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Object>> ContainerListBlobFlatSegmentAsync(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                String? prefix = default,
                String? marker = default,
                Integer? maxresults = default,
                Array? include = default,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_ListBlobFlatSegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerListBlobFlatSegmentAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        comp,
                        prefix,
                        marker,
                        maxresults,
                        include,
                        timeout,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerListBlobFlatSegmentAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_ListBlobFlatSegment request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_ListBlobFlatSegment Request.</returns>
            internal static Azure.Core.Http.Request ContainerListBlobFlatSegmentAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                String? prefix = default,
                String? marker = default,
                Integer? maxresults = default,
                Array? include = default,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "list");
                if (prefix != null) { _request.UriBuilder.AppendQuery("prefix", System.Uri.EscapeDataString(prefix)); }
                if (marker != null) { _request.UriBuilder.AppendQuery("marker", System.Uri.EscapeDataString(marker)); }
                if (maxresults != null) { _request.UriBuilder.AppendQuery("maxresults", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }
                if (include != null) { _request.UriBuilder.AppendQuery("include", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_ListBlobFlatSegment response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_ListBlobFlatSegment Azure.Response{Object}.</returns>
            internal static Azure.Response<Object> ContainerListBlobFlatSegmentAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = _header;
                        }

                        // Create the response
                        Azure.Response<Object> _result =
                            new Azure.Response<Object>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_ListBlobFlatSegment

            #region Container.Container_ListBlobHierarchySegment
            /// <summary>
            /// [Update] The List Blobs operation returns a list of the blobs under the specified container
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="delimiter">When the request includes this parameter, the operation returns a BlobPrefix element in the response body that acts as a placeholder for all blobs whose names begin with the same substring up to the appearance of the delimiter character. The delimiter may be a single character or a string.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Object>> ContainerListBlobHierarchySegmentAsync(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                String? prefix = default,
                String delimiter,
                String? marker = default,
                Integer? maxresults = default,
                Array? include = default,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_ListBlobHierarchySegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerListBlobHierarchySegmentAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        comp,
                        prefix,
                        delimiter,
                        marker,
                        maxresults,
                        include,
                        timeout,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerListBlobHierarchySegmentAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_ListBlobHierarchySegment request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="delimiter">When the request includes this parameter, the operation returns a BlobPrefix element in the response body that acts as a placeholder for all blobs whose names begin with the same substring up to the appearance of the delimiter character. The delimiter may be a single character or a string.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_ListBlobHierarchySegment Request.</returns>
            internal static Azure.Core.Http.Request ContainerListBlobHierarchySegmentAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                String? prefix = default,
                String delimiter,
                String? marker = default,
                Integer? maxresults = default,
                Array? include = default,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "list");
                if (prefix != null) { _request.UriBuilder.AppendQuery("prefix", System.Uri.EscapeDataString(prefix)); }
                _request.UriBuilder.AppendQuery("delimiter", System.Uri.EscapeDataString(delimiter));
                if (marker != null) { _request.UriBuilder.AppendQuery("marker", System.Uri.EscapeDataString(marker)); }
                if (maxresults != null) { _request.UriBuilder.AppendQuery("maxresults", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }
                if (include != null) { _request.UriBuilder.AppendQuery("include", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_ListBlobHierarchySegment response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_ListBlobHierarchySegment Azure.Response{Object}.</returns>
            internal static Azure.Response<Object> ContainerListBlobHierarchySegmentAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = _header;
                        }

                        // Create the response
                        Azure.Response<Object> _result =
                            new Azure.Response<Object>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_ListBlobHierarchySegment

            #region Service.Service_GetStatistics
            /// <summary>
            /// Retrieves statistics related to replication for the Blob service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the storage account.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Object>> ServiceGetStatisticsAsync(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ServiceClient.Service_GetStatistics",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ServiceGetStatisticsAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        comp,
                        timeout,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ServiceGetStatisticsAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Service.Service_GetStatistics request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.Service_GetStatistics Request.</returns>
            internal static Azure.Core.Http.Request ServiceGetStatisticsAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "service");
                _request.UriBuilder.AppendQuery("comp", "stats");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Service.Service_GetStatistics response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.Service_GetStatistics Azure.Response{Object}.</returns>
            internal static Azure.Response<Object> ServiceGetStatisticsAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = _header;
                        }

                        // Create the response
                        Azure.Response<Object> _result =
                            new Azure.Response<Object>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Service.Service_GetStatistics

            #region Container.Container_GetAccountInfo
            /// <summary>
            /// Returns the sku name and account kind 
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success (OK)</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ContainerGetAccountInfoAsync(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                string xMSVersion,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_GetAccountInfo",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerGetAccountInfoAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        comp,
                        xMSVersion))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerGetAccountInfoAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_GetAccountInfo request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <returns>The Container.Container_GetAccountInfo Request.</returns>
            internal static Azure.Core.Http.Request ContainerGetAccountInfoAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                string xMSVersion)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "account");
                _request.UriBuilder.AppendQuery("comp", "properties");

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_GetAccountInfo response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_GetAccountInfo Azure.Response.</returns>
            internal static Azure.Response ContainerGetAccountInfoAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_GetAccountInfo

            #region Directory.Directory_Create
            /// <summary>
            /// Create a directory. By default, the destination is overwritten and if the destination already exists and has a lease the lease is broken. This operation supports conditional HTTP requests.  For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations).  To fail if the destination already exists, use a conditional request with If-None-Match: "*".
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSProperties">Optional.  User-defined properties to be stored with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is base64 encoded.</param>
            /// <param name="xMSPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="xMSUmask">Only valid if Hierarchical Namespace is enabled for the account. This umask restricts permission settings for file and directory, and will only be applied when default Acl does not exist in parent directory. If the umask bit has set, it means that the corresponding permission will be disabled. Otherwise the corresponding permission will be determined by the permission. A 4-digit octal notation (e.g. 0022) is supported here. If no umask was specified, a default umask - 0027 will be used.</param>
            /// <param name="xMSCacheControl">Cache control for given resource</param>
            /// <param name="xMSContentType">Content type for given resource</param>
            /// <param name="xMSContentEncoding">Content encoding for given resource</param>
            /// <param name="xMSContentLanguage">Content language for given resource</param>
            /// <param name="xMSContentDisposition">Content disposition for given resource</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The file or directory was created.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> DirectoryCreateAsync(
                Object pipeline,
                String? url = default,
                string resource,
                Integer? timeout = default,
                String? xMSProperties = default,
                String? xMSPermissions = default,
                String? xMSUmask = default,
                String? xMSCacheControl = default,
                String? xMSContentType = default,
                String? xMSContentEncoding = default,
                String? xMSContentLanguage = default,
                String? xMSContentDisposition = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.DirectoryClient.Directory_Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DirectoryCreateAsync_CreateRequest(
                        pipeline,
                        url,
                        resource,
                        timeout,
                        xMSProperties,
                        xMSPermissions,
                        xMSUmask,
                        xMSCacheControl,
                        xMSContentType,
                        xMSContentEncoding,
                        xMSContentLanguage,
                        xMSContentDisposition,
                        xMSLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return DirectoryCreateAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Directory.Directory_Create request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSProperties">Optional.  User-defined properties to be stored with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is base64 encoded.</param>
            /// <param name="xMSPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="xMSUmask">Only valid if Hierarchical Namespace is enabled for the account. This umask restricts permission settings for file and directory, and will only be applied when default Acl does not exist in parent directory. If the umask bit has set, it means that the corresponding permission will be disabled. Otherwise the corresponding permission will be determined by the permission. A 4-digit octal notation (e.g. 0022) is supported here. If no umask was specified, a default umask - 0027 will be used.</param>
            /// <param name="xMSCacheControl">Cache control for given resource</param>
            /// <param name="xMSContentType">Content type for given resource</param>
            /// <param name="xMSContentEncoding">Content encoding for given resource</param>
            /// <param name="xMSContentLanguage">Content language for given resource</param>
            /// <param name="xMSContentDisposition">Content disposition for given resource</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Directory.Directory_Create Request.</returns>
            internal static Azure.Core.Http.Request DirectoryCreateAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string resource,
                Integer? timeout = default,
                String? xMSProperties = default,
                String? xMSPermissions = default,
                String? xMSUmask = default,
                String? xMSCacheControl = default,
                String? xMSContentType = default,
                String? xMSContentEncoding = default,
                String? xMSContentLanguage = default,
                String? xMSContentDisposition = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (resource == null)
                {
                    throw new System.ArgumentNullException(nameof(resource));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("resource", "directory");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSProperties != null) { _request.Headers.SetValue("x-ms-properties", xMSProperties); }
                if (xMSPermissions != null) { _request.Headers.SetValue("x-ms-permissions", xMSPermissions); }
                if (xMSUmask != null) { _request.Headers.SetValue("x-ms-umask", xMSUmask); }
                if (xMSCacheControl != null) { _request.Headers.SetValue("x-ms-cache-control", xMSCacheControl); }
                if (xMSContentType != null) { _request.Headers.SetValue("x-ms-content-type", xMSContentType); }
                if (xMSContentEncoding != null) { _request.Headers.SetValue("x-ms-content-encoding", xMSContentEncoding); }
                if (xMSContentLanguage != null) { _request.Headers.SetValue("x-ms-content-language", xMSContentLanguage); }
                if (xMSContentDisposition != null) { _request.Headers.SetValue("x-ms-content-disposition", xMSContentDisposition); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Directory.Directory_Create response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.Directory_Create Azure.Response.</returns>
            internal static Azure.Response DirectoryCreateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Directory.Directory_Create

            #region Directory.Directory_Rename
            /// <summary>
            /// Rename a directory. By default, the destination is overwritten and if the destination already exists and has a lease the lease is broken. This operation supports conditional HTTP requests. For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations). To fail if the destination already exists, use a conditional request with If-None-Match: "*".
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="continuation">When renaming a directory, the number of paths that are renamed with each invocation is limited.  If the number of paths to be renamed exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the rename operation to continue renaming the directory.</param>
            /// <param name="mode">Determines the behavior of the rename operation</param>
            /// <param name="xMSRenameSource">The file or directory to be renamed. The value must have the following format: "/{filesysystem}/{path}".  If "x-ms-properties" is specified, the properties will overwrite the existing properties; otherwise, the existing properties will be preserved.</param>
            /// <param name="xMSProperties">Optional.  User-defined properties to be stored with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is base64 encoded.</param>
            /// <param name="xMSPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="xMSUmask">Only valid if Hierarchical Namespace is enabled for the account. This umask restricts permission settings for file and directory, and will only be applied when default Acl does not exist in parent directory. If the umask bit has set, it means that the corresponding permission will be disabled. Otherwise the corresponding permission will be determined by the permission. A 4-digit octal notation (e.g. 0022) is supported here. If no umask was specified, a default umask - 0027 will be used.</param>
            /// <param name="xMSCacheControl">Cache control for given resource</param>
            /// <param name="xMSContentType">Content type for given resource</param>
            /// <param name="xMSContentEncoding">Content encoding for given resource</param>
            /// <param name="xMSContentLanguage">Content language for given resource</param>
            /// <param name="xMSContentDisposition">Content disposition for given resource</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSSourceLeaseID">A lease ID for the source path. If specified, the source path must have an active lease and the leaase ID must match.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The directory was renamed.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> DirectoryRenameAsync(
                Object pipeline,
                String? url = default,
                Integer? timeout = default,
                String? continuation = default,
                String? mode = default,
                String xMSRenameSource,
                String? xMSProperties = default,
                String? xMSPermissions = default,
                String? xMSUmask = default,
                String? xMSCacheControl = default,
                String? xMSContentType = default,
                String? xMSContentEncoding = default,
                String? xMSContentLanguage = default,
                String? xMSContentDisposition = default,
                String? xMSLeaseID = default,
                String? xMSSourceLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.DirectoryClient.Directory_Rename",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DirectoryRenameAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        continuation,
                        mode,
                        xMSRenameSource,
                        xMSProperties,
                        xMSPermissions,
                        xMSUmask,
                        xMSCacheControl,
                        xMSContentType,
                        xMSContentEncoding,
                        xMSContentLanguage,
                        xMSContentDisposition,
                        xMSLeaseID,
                        xMSSourceLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSSourceIFModifiedSince,
                        xMSSourceIFUnmodifiedSince,
                        xMSSourceIFMatch,
                        xMSSourceIFNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return DirectoryRenameAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Directory.Directory_Rename request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="continuation">When renaming a directory, the number of paths that are renamed with each invocation is limited.  If the number of paths to be renamed exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the rename operation to continue renaming the directory.</param>
            /// <param name="mode">Determines the behavior of the rename operation</param>
            /// <param name="xMSRenameSource">The file or directory to be renamed. The value must have the following format: "/{filesysystem}/{path}".  If "x-ms-properties" is specified, the properties will overwrite the existing properties; otherwise, the existing properties will be preserved.</param>
            /// <param name="xMSProperties">Optional.  User-defined properties to be stored with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is base64 encoded.</param>
            /// <param name="xMSPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="xMSUmask">Only valid if Hierarchical Namespace is enabled for the account. This umask restricts permission settings for file and directory, and will only be applied when default Acl does not exist in parent directory. If the umask bit has set, it means that the corresponding permission will be disabled. Otherwise the corresponding permission will be determined by the permission. A 4-digit octal notation (e.g. 0022) is supported here. If no umask was specified, a default umask - 0027 will be used.</param>
            /// <param name="xMSCacheControl">Cache control for given resource</param>
            /// <param name="xMSContentType">Content type for given resource</param>
            /// <param name="xMSContentEncoding">Content encoding for given resource</param>
            /// <param name="xMSContentLanguage">Content language for given resource</param>
            /// <param name="xMSContentDisposition">Content disposition for given resource</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSSourceLeaseID">A lease ID for the source path. If specified, the source path must have an active lease and the leaase ID must match.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Directory.Directory_Rename Request.</returns>
            internal static Azure.Core.Http.Request DirectoryRenameAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                Integer? timeout = default,
                String? continuation = default,
                String? mode = default,
                String xMSRenameSource,
                String? xMSProperties = default,
                String? xMSPermissions = default,
                String? xMSUmask = default,
                String? xMSCacheControl = default,
                String? xMSContentType = default,
                String? xMSContentEncoding = default,
                String? xMSContentLanguage = default,
                String? xMSContentDisposition = default,
                String? xMSLeaseID = default,
                String? xMSSourceLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }
                if (continuation != null) { _request.UriBuilder.AppendQuery("continuation", System.Uri.EscapeDataString(continuation)); }
                if (mode != null) { _request.UriBuilder.AppendQuery("mode", System.Uri.EscapeDataString(mode)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-rename-source", xMSRenameSource);
                if (xMSProperties != null) { _request.Headers.SetValue("x-ms-properties", xMSProperties); }
                if (xMSPermissions != null) { _request.Headers.SetValue("x-ms-permissions", xMSPermissions); }
                if (xMSUmask != null) { _request.Headers.SetValue("x-ms-umask", xMSUmask); }
                if (xMSCacheControl != null) { _request.Headers.SetValue("x-ms-cache-control", xMSCacheControl); }
                if (xMSContentType != null) { _request.Headers.SetValue("x-ms-content-type", xMSContentType); }
                if (xMSContentEncoding != null) { _request.Headers.SetValue("x-ms-content-encoding", xMSContentEncoding); }
                if (xMSContentLanguage != null) { _request.Headers.SetValue("x-ms-content-language", xMSContentLanguage); }
                if (xMSContentDisposition != null) { _request.Headers.SetValue("x-ms-content-disposition", xMSContentDisposition); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSSourceLeaseID != null) { _request.Headers.SetValue("x-ms-source-lease-id", xMSSourceLeaseID); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                if (xMSSourceIFModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", xMSSourceIFModifiedSince); }
                if (xMSSourceIFUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", xMSSourceIFUnmodifiedSince); }
                if (xMSSourceIFMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", xMSSourceIFMatch); }
                if (xMSSourceIFNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", xMSSourceIFNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Directory.Directory_Rename response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.Directory_Rename Azure.Response.</returns>
            internal static Azure.Response DirectoryRenameAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Directory.Directory_Rename

            #region Directory.Directory_Delete
            /// <summary>
            /// Deletes the directory
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="recursive">If "true", all paths beneath the directory will be deleted. If "false" and the directory is non-empty, an error occurs.</param>
            /// <param name="continuation">When renaming a directory, the number of paths that are renamed with each invocation is limited.  If the number of paths to be renamed exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the rename operation to continue renaming the directory.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The directory was deleted.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> DirectoryDeleteAsync(
                Object pipeline,
                String? url = default,
                Integer? timeout = default,
                Boolean recursive,
                String? continuation = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.DirectoryClient.Directory_Delete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DirectoryDeleteAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        recursive,
                        continuation,
                        xMSLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return DirectoryDeleteAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Directory.Directory_Delete request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="recursive">If "true", all paths beneath the directory will be deleted. If "false" and the directory is non-empty, an error occurs.</param>
            /// <param name="continuation">When renaming a directory, the number of paths that are renamed with each invocation is limited.  If the number of paths to be renamed exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the rename operation to continue renaming the directory.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Directory.Directory_Delete Request.</returns>
            internal static Azure.Core.Http.Request DirectoryDeleteAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                Integer? timeout = default,
                Boolean recursive,
                String? continuation = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Delete;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.UriBuilder.AppendQuery("recursive", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME));
                #pragma warning restore CA1308 // Normalize strings to uppercase

                if (continuation != null) { _request.UriBuilder.AppendQuery("continuation", System.Uri.EscapeDataString(continuation)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Directory.Directory_Delete response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.Directory_Delete Azure.Response.</returns>
            internal static Azure.Response DirectoryDeleteAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Directory.Directory_Delete

            #region Directory.Directory_SetAccessControl
            /// <summary>
            /// Set the owner, group, permissions, or access control list for a directory.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSOwner">Optional. The owner of the blob or directory.</param>
            /// <param name="xMSGroup">Optional. The owning group of the blob or directory.</param>
            /// <param name="xMSPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="xMSAcl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Set directory access control response.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> DirectorySetAccessControlAsync(
                Object pipeline,
                String? url = default,
                string action,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSOwner = default,
                String? xMSGroup = default,
                String? xMSPermissions = default,
                String? xMSAcl = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? xMSClientRequestID = default,
                string xMSVersion,
                string operationName = "DefaultNS.AzureBlobStorage.DirectoryClient.Directory_SetAccessControl",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DirectorySetAccessControlAsync_CreateRequest(
                        pipeline,
                        url,
                        action,
                        timeout,
                        xMSLeaseID,
                        xMSOwner,
                        xMSGroup,
                        xMSPermissions,
                        xMSAcl,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        xMSClientRequestID,
                        xMSVersion))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return DirectorySetAccessControlAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Directory.Directory_SetAccessControl request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSOwner">Optional. The owner of the blob or directory.</param>
            /// <param name="xMSGroup">Optional. The owning group of the blob or directory.</param>
            /// <param name="xMSPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="xMSAcl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <returns>The Directory.Directory_SetAccessControl Request.</returns>
            internal static Azure.Core.Http.Request DirectorySetAccessControlAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string action,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSOwner = default,
                String? xMSGroup = default,
                String? xMSPermissions = default,
                String? xMSAcl = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? xMSClientRequestID = default,
                string xMSVersion)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (action == null)
                {
                    throw new System.ArgumentNullException(nameof(action));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Patch;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("action", "setAccessControl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSOwner != null) { _request.Headers.SetValue("x-ms-owner", xMSOwner); }
                if (xMSGroup != null) { _request.Headers.SetValue("x-ms-group", xMSGroup); }
                if (xMSPermissions != null) { _request.Headers.SetValue("x-ms-permissions", xMSPermissions); }
                if (xMSAcl != null) { _request.Headers.SetValue("x-ms-acl", xMSAcl); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");

                return _request;
            }

            /// <summary>
            /// Create the Directory.Directory_SetAccessControl response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.Directory_SetAccessControl Azure.Response.</returns>
            internal static Azure.Response DirectorySetAccessControlAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Directory.Directory_SetAccessControl

            #region Directory.Directory_GetAccessControl
            /// <summary>
            /// Get the owner, group, permissions, or access control list for a directory.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="upn">Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true", the identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response headers will be transformed from Azure Active Directory Object IDs to User Principal Names.  If "false", the values will be returned as Azure Active Directory Object IDs. The default value is false.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Get directory access control response.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> DirectoryGetAccessControlAsync(
                Object pipeline,
                String? url = default,
                string action,
                Integer? timeout = default,
                Boolean? upn = default,
                String? xMSLeaseID = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? xMSClientRequestID = default,
                string xMSVersion,
                string operationName = "DefaultNS.AzureBlobStorage.DirectoryClient.Directory_GetAccessControl",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DirectoryGetAccessControlAsync_CreateRequest(
                        pipeline,
                        url,
                        action,
                        timeout,
                        upn,
                        xMSLeaseID,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        xMSClientRequestID,
                        xMSVersion))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return DirectoryGetAccessControlAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Directory.Directory_GetAccessControl request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="upn">Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true", the identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response headers will be transformed from Azure Active Directory Object IDs to User Principal Names.  If "false", the values will be returned as Azure Active Directory Object IDs. The default value is false.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <returns>The Directory.Directory_GetAccessControl Request.</returns>
            internal static Azure.Core.Http.Request DirectoryGetAccessControlAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string action,
                Integer? timeout = default,
                Boolean? upn = default,
                String? xMSLeaseID = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? xMSClientRequestID = default,
                string xMSVersion)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (action == null)
                {
                    throw new System.ArgumentNullException(nameof(action));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Head;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("action", "getAccessControl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }
                if (upn != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.UriBuilder.AppendQuery("upn", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME));
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");

                return _request;
            }

            /// <summary>
            /// Create the Directory.Directory_GetAccessControl response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.Directory_GetAccessControl Azure.Response.</returns>
            internal static Azure.Response DirectoryGetAccessControlAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Directory.Directory_GetAccessControl

            #region Blob.Blob_Download
            /// <summary>
            /// The Download operation reads or downloads a blob from the system, including its metadata and properties. You can also call Download to read a snapshot.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSRange">Return only the bytes of the blob in the specified range.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSRangeGetContentMd5">When set to true and specified together with the Range, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size.</param>
            /// <param name="xMSRangeGetContentCrc64">When set to true and specified together with the Range, the service returns the CRC64 hash for the range, as long as the range is less than or equal to 4 MB in size.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Returns the content of the entire blob.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<String>> BlobDownloadAsync(
                Object pipeline,
                String? url = default,
                String? snapshot = default,
                Integer? timeout = default,
                String? xMSRange = default,
                String? xMSLeaseID = default,
                Boolean? xMSRangeGetContentMd5 = default,
                Boolean? xMSRangeGetContentCrc64 = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_Download",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobDownloadAsync_CreateRequest(
                        pipeline,
                        url,
                        snapshot,
                        timeout,
                        xMSRange,
                        xMSLeaseID,
                        xMSRangeGetContentMd5,
                        xMSRangeGetContentCrc64,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobDownloadAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_Download request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSRange">Return only the bytes of the blob in the specified range.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSRangeGetContentMd5">When set to true and specified together with the Range, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size.</param>
            /// <param name="xMSRangeGetContentCrc64">When set to true and specified together with the Range, the service returns the CRC64 hash for the range, as long as the range is less than or equal to 4 MB in size.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_Download Request.</returns>
            internal static Azure.Core.Http.Request BlobDownloadAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                String? snapshot = default,
                Integer? timeout = default,
                String? xMSRange = default,
                String? xMSLeaseID = default,
                Boolean? xMSRangeGetContentMd5 = default,
                Boolean? xMSRangeGetContentCrc64 = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSRange != null) { _request.Headers.SetValue("x-ms-range", xMSRange); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSRangeGetContentMd5 != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Headers.SetValue("x-ms-range-get-content-md5", UNKNOWN ENUM TYPE NAME);
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }
                if (xMSRangeGetContentCrc64 != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Headers.SetValue("x-ms-range-get-content-crc64", UNKNOWN ENUM TYPE NAME);
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_Download response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_Download Azure.Response{String}.</returns>
            internal static Azure.Response<String> BlobDownloadAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        // TODO: Deserialize unexpected type

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("Metadata", out _header))
                        {
                            _value.Metadata = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = (UNKNOWN ENUM TYPE NAME)System.Enum.Parse(typeof(UNKNOWN ENUM TYPE NAME), _header, false);
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Range", out _header))
                        {
                            _value.ContentRange = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentMD5 = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = _header;
                        }
                        if (response.Headers.TryGetValue("Cache-Control", out _header))
                        {
                            _value.CacheControl = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Disposition", out _header))
                        {
                            _value.ContentDisposition = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Language", out _header))
                        {
                            _value.ContentLanguage = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = (BlobSequenceNumber)System.Enum.Parse(typeof(BlobSequenceNumber), _header, false);
                        }
                        if (response.Headers.TryGetValue("BlobType", out _header))
                        {
                            _value.BlobType = _header;
                        }
                        if (response.Headers.TryGetValue("CopyCompletionTime", out _header))
                        {
                            _value.CopyCompletionTime = _header;
                        }
                        if (response.Headers.TryGetValue("CopyStatusDescription", out _header))
                        {
                            _value.CopyStatusDescription = _header;
                        }
                        if (response.Headers.TryGetValue("CopyId", out _header))
                        {
                            _value.CopyId = _header;
                        }
                        if (response.Headers.TryGetValue("CopyProgress", out _header))
                        {
                            _value.CopyProgress = _header;
                        }
                        if (response.Headers.TryGetValue("CopySource", out _header))
                        {
                            _value.CopySource = _header;
                        }
                        if (response.Headers.TryGetValue("CopyStatus", out _header))
                        {
                            _value.CopyStatus = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseDuration", out _header))
                        {
                            _value.LeaseDuration = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseState", out _header))
                        {
                            _value.LeaseState = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseStatus", out _header))
                        {
                            _value.LeaseStatus = _header;
                        }
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = _header;
                        }
                        if (response.Headers.TryGetValue("BlobCommittedBlockCount", out _header))
                        {
                            _value.BlobCommittedBlockCount = (BlobCommittedBlockCount)System.Enum.Parse(typeof(BlobCommittedBlockCount), _header, false);
                        }
                        if (response.Headers.TryGetValue("IsServerEncrypted", out _header))
                        {
                            _value.IsServerEncrypted = (IsServerEncrypted)System.Enum.Parse(typeof(IsServerEncrypted), _header, false);
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobContentMD5", out _header))
                        {
                            _value.BlobContentMD5 = _header;
                        }

                        // Create the response
                        Azure.Response<String> _result =
                            new Azure.Response<String>(
                                response,
                                _value);

                        return _result;
                    }
                    case 206:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        // TODO: Deserialize unexpected type

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("Metadata", out _header))
                        {
                            _value.Metadata = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = (UNKNOWN ENUM TYPE NAME)System.Enum.Parse(typeof(UNKNOWN ENUM TYPE NAME), _header, false);
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Range", out _header))
                        {
                            _value.ContentRange = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentMD5 = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = _header;
                        }
                        if (response.Headers.TryGetValue("Cache-Control", out _header))
                        {
                            _value.CacheControl = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Disposition", out _header))
                        {
                            _value.ContentDisposition = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Language", out _header))
                        {
                            _value.ContentLanguage = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = (BlobSequenceNumber)System.Enum.Parse(typeof(BlobSequenceNumber), _header, false);
                        }
                        if (response.Headers.TryGetValue("BlobType", out _header))
                        {
                            _value.BlobType = _header;
                        }
                        if (response.Headers.TryGetValue("ContentCrc64", out _header))
                        {
                            _value.ContentCrc64 = _header;
                        }
                        if (response.Headers.TryGetValue("CopyCompletionTime", out _header))
                        {
                            _value.CopyCompletionTime = _header;
                        }
                        if (response.Headers.TryGetValue("CopyStatusDescription", out _header))
                        {
                            _value.CopyStatusDescription = _header;
                        }
                        if (response.Headers.TryGetValue("CopyId", out _header))
                        {
                            _value.CopyId = _header;
                        }
                        if (response.Headers.TryGetValue("CopyProgress", out _header))
                        {
                            _value.CopyProgress = _header;
                        }
                        if (response.Headers.TryGetValue("CopySource", out _header))
                        {
                            _value.CopySource = _header;
                        }
                        if (response.Headers.TryGetValue("CopyStatus", out _header))
                        {
                            _value.CopyStatus = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseDuration", out _header))
                        {
                            _value.LeaseDuration = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseState", out _header))
                        {
                            _value.LeaseState = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseStatus", out _header))
                        {
                            _value.LeaseStatus = _header;
                        }
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = _header;
                        }
                        if (response.Headers.TryGetValue("BlobCommittedBlockCount", out _header))
                        {
                            _value.BlobCommittedBlockCount = (BlobCommittedBlockCount)System.Enum.Parse(typeof(BlobCommittedBlockCount), _header, false);
                        }
                        if (response.Headers.TryGetValue("IsServerEncrypted", out _header))
                        {
                            _value.IsServerEncrypted = (IsServerEncrypted)System.Enum.Parse(typeof(IsServerEncrypted), _header, false);
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobContentMD5", out _header))
                        {
                            _value.BlobContentMD5 = _header;
                        }

                        // Create the response
                        Azure.Response<String> _result =
                            new Azure.Response<String>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_Download

            #region Blob.Blob_GetProperties
            /// <summary>
            /// The Get Properties operation returns all user-defined metadata, standard HTTP properties, and system properties for the blob. It does not return the content of the blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Returns the properties of the blob.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobGetPropertiesAsync(
                Object pipeline,
                String? url = default,
                String? snapshot = default,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_GetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobGetPropertiesAsync_CreateRequest(
                        pipeline,
                        url,
                        snapshot,
                        timeout,
                        xMSLeaseID,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobGetPropertiesAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_GetProperties request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_GetProperties Request.</returns>
            internal static Azure.Core.Http.Request BlobGetPropertiesAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                String? snapshot = default,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Head;
                _request.UriBuilder.Uri = url;
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_GetProperties response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_GetProperties Azure.Response.</returns>
            internal static Azure.Response BlobGetPropertiesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_GetProperties

            #region Blob.Blob_Delete
            /// <summary>
            /// If the storage account's soft delete feature is disabled then, when a blob is deleted, it is permanently removed from the storage account. If the storage account's soft delete feature is enabled, then, when a blob is deleted, it is marked for deletion and becomes inaccessible immediately. However, the blob service retains the blob or snapshot for the number of days specified by the DeleteRetentionPolicy section of [Storage service properties] (Set-Blob-Service-Properties.md). After the specified number of days has passed, the blob's data is permanently removed from the storage account. Note that you continue to be charged for the soft-deleted blob's storage until it is permanently removed. Use the List Blobs API and specify the "include=deleted" query parameter to discover which blobs and snapshots have been soft deleted. You can then use the Undelete Blob API to restore a soft-deleted blob. All other operations on a soft-deleted blob or snapshot causes the service to return an HTTP status code of 404 (ResourceNotFound).
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSDeleteSnapshots">Required if the blob has associated snapshots. Specify one of the following two options: include: Delete the base blob and all of its snapshots. only: Delete only the blob's snapshots and not the blob itself</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The delete request was accepted and the blob will be deleted.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobDeleteAsync(
                Object pipeline,
                String? url = default,
                String? snapshot = default,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSDeleteSnapshots = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_Delete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobDeleteAsync_CreateRequest(
                        pipeline,
                        url,
                        snapshot,
                        timeout,
                        xMSLeaseID,
                        xMSDeleteSnapshots,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobDeleteAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_Delete request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSDeleteSnapshots">Required if the blob has associated snapshots. Specify one of the following two options: include: Delete the base blob and all of its snapshots. only: Delete only the blob's snapshots and not the blob itself</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_Delete Request.</returns>
            internal static Azure.Core.Http.Request BlobDeleteAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                String? snapshot = default,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSDeleteSnapshots = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Delete;
                _request.UriBuilder.Uri = url;
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSDeleteSnapshots != null) { _request.Headers.SetValue("x-ms-delete-snapshots", xMSDeleteSnapshots); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_Delete response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_Delete Azure.Response.</returns>
            internal static Azure.Response BlobDeleteAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_Delete

            #region Blob.Blob_SetAccessControl
            /// <summary>
            /// Set the owner, group, permissions, or access control list for a blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSOwner">Optional. The owner of the blob or directory.</param>
            /// <param name="xMSGroup">Optional. The owning group of the blob or directory.</param>
            /// <param name="xMSPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="xMSAcl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Set blob access control response.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobSetAccessControlAsync(
                Object pipeline,
                String? url = default,
                string action,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSOwner = default,
                String? xMSGroup = default,
                String? xMSPermissions = default,
                String? xMSAcl = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? xMSClientRequestID = default,
                string xMSVersion,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_SetAccessControl",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobSetAccessControlAsync_CreateRequest(
                        pipeline,
                        url,
                        action,
                        timeout,
                        xMSLeaseID,
                        xMSOwner,
                        xMSGroup,
                        xMSPermissions,
                        xMSAcl,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        xMSClientRequestID,
                        xMSVersion))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobSetAccessControlAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_SetAccessControl request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSOwner">Optional. The owner of the blob or directory.</param>
            /// <param name="xMSGroup">Optional. The owning group of the blob or directory.</param>
            /// <param name="xMSPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="xMSAcl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <returns>The Blob.Blob_SetAccessControl Request.</returns>
            internal static Azure.Core.Http.Request BlobSetAccessControlAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string action,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSOwner = default,
                String? xMSGroup = default,
                String? xMSPermissions = default,
                String? xMSAcl = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? xMSClientRequestID = default,
                string xMSVersion)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (action == null)
                {
                    throw new System.ArgumentNullException(nameof(action));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Patch;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("action", "setAccessControl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSOwner != null) { _request.Headers.SetValue("x-ms-owner", xMSOwner); }
                if (xMSGroup != null) { _request.Headers.SetValue("x-ms-group", xMSGroup); }
                if (xMSPermissions != null) { _request.Headers.SetValue("x-ms-permissions", xMSPermissions); }
                if (xMSAcl != null) { _request.Headers.SetValue("x-ms-acl", xMSAcl); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_SetAccessControl response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_SetAccessControl Azure.Response.</returns>
            internal static Azure.Response BlobSetAccessControlAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_SetAccessControl

            #region Service.Service_ListContainersSegment
            /// <summary>
            /// The List Containers Segment operation returns a list of the containers under the specified account
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify that the container's metadata be returned as part of the response body.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Object>> ServiceListContainersSegmentAsync(
                Object pipeline,
                String? url = default,
                string comp,
                String? prefix = default,
                String? marker = default,
                Integer? maxresults = default,
                string include = default,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ServiceClient.Service_ListContainersSegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ServiceListContainersSegmentAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        prefix,
                        marker,
                        maxresults,
                        include,
                        timeout,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ServiceListContainersSegmentAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Service.Service_ListContainersSegment request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify that the container's metadata be returned as part of the response body.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.Service_ListContainersSegment Request.</returns>
            internal static Azure.Core.Http.Request ServiceListContainersSegmentAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                String? prefix = default,
                String? marker = default,
                Integer? maxresults = default,
                string include = default,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "list");
                if (prefix != null) { _request.UriBuilder.AppendQuery("prefix", System.Uri.EscapeDataString(prefix)); }
                if (marker != null) { _request.UriBuilder.AppendQuery("marker", System.Uri.EscapeDataString(marker)); }
                if (maxresults != null) { _request.UriBuilder.AppendQuery("maxresults", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }
                _request.UriBuilder.AppendQuery("include", "metadata");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Service.Service_ListContainersSegment response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.Service_ListContainersSegment Azure.Response{Object}.</returns>
            internal static Azure.Response<Object> ServiceListContainersSegmentAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }

                        // Create the response
                        Azure.Response<Object> _result =
                            new Azure.Response<Object>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Service.Service_ListContainersSegment

            #region Blob.Blob_GetAccessControl
            /// <summary>
            /// Get the owner, group, permissions, or access control list for a blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="upn">Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true", the identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response headers will be transformed from Azure Active Directory Object IDs to User Principal Names.  If "false", the values will be returned as Azure Active Directory Object IDs. The default value is false.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Get blob access control response.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobGetAccessControlAsync(
                Object pipeline,
                String? url = default,
                string action,
                Integer? timeout = default,
                Boolean? upn = default,
                String? xMSLeaseID = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? xMSClientRequestID = default,
                string xMSVersion,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_GetAccessControl",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobGetAccessControlAsync_CreateRequest(
                        pipeline,
                        url,
                        action,
                        timeout,
                        upn,
                        xMSLeaseID,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        xMSClientRequestID,
                        xMSVersion))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobGetAccessControlAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_GetAccessControl request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="upn">Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true", the identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response headers will be transformed from Azure Active Directory Object IDs to User Principal Names.  If "false", the values will be returned as Azure Active Directory Object IDs. The default value is false.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <returns>The Blob.Blob_GetAccessControl Request.</returns>
            internal static Azure.Core.Http.Request BlobGetAccessControlAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string action,
                Integer? timeout = default,
                Boolean? upn = default,
                String? xMSLeaseID = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? xMSClientRequestID = default,
                string xMSVersion)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (action == null)
                {
                    throw new System.ArgumentNullException(nameof(action));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Head;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("action", "getAccessControl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }
                if (upn != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.UriBuilder.AppendQuery("upn", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME));
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_GetAccessControl response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_GetAccessControl Azure.Response.</returns>
            internal static Azure.Response BlobGetAccessControlAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_GetAccessControl

            #region Blob.Blob_Rename
            /// <summary>
            /// Rename a blob/file.  By default, the destination is overwritten and if the destination already exists and has a lease the lease is broken.  This operation supports conditional HTTP requests.  For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations).  To fail if the destination already exists, use a conditional request with If-None-Match: "*".
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="mode">Determines the behavior of the rename operation</param>
            /// <param name="xMSRenameSource">The file or directory to be renamed. The value must have the following format: "/{filesysystem}/{path}".  If "x-ms-properties" is specified, the properties will overwrite the existing properties; otherwise, the existing properties will be preserved.</param>
            /// <param name="xMSProperties">Optional.  User-defined properties to be stored with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is base64 encoded.</param>
            /// <param name="xMSPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="xMSUmask">Only valid if Hierarchical Namespace is enabled for the account. This umask restricts permission settings for file and directory, and will only be applied when default Acl does not exist in parent directory. If the umask bit has set, it means that the corresponding permission will be disabled. Otherwise the corresponding permission will be determined by the permission. A 4-digit octal notation (e.g. 0022) is supported here. If no umask was specified, a default umask - 0027 will be used.</param>
            /// <param name="xMSCacheControl">Cache control for given resource</param>
            /// <param name="xMSContentType">Content type for given resource</param>
            /// <param name="xMSContentEncoding">Content encoding for given resource</param>
            /// <param name="xMSContentLanguage">Content language for given resource</param>
            /// <param name="xMSContentDisposition">Content disposition for given resource</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSSourceLeaseID">A lease ID for the source path. If specified, the source path must have an active lease and the leaase ID must match.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The file was renamed.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobRenameAsync(
                Object pipeline,
                String? url = default,
                Integer? timeout = default,
                String? mode = default,
                String xMSRenameSource,
                String? xMSProperties = default,
                String? xMSPermissions = default,
                String? xMSUmask = default,
                String? xMSCacheControl = default,
                String? xMSContentType = default,
                String? xMSContentEncoding = default,
                String? xMSContentLanguage = default,
                String? xMSContentDisposition = default,
                String? xMSLeaseID = default,
                String? xMSSourceLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_Rename",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobRenameAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        mode,
                        xMSRenameSource,
                        xMSProperties,
                        xMSPermissions,
                        xMSUmask,
                        xMSCacheControl,
                        xMSContentType,
                        xMSContentEncoding,
                        xMSContentLanguage,
                        xMSContentDisposition,
                        xMSLeaseID,
                        xMSSourceLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSSourceIFModifiedSince,
                        xMSSourceIFUnmodifiedSince,
                        xMSSourceIFMatch,
                        xMSSourceIFNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobRenameAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_Rename request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="mode">Determines the behavior of the rename operation</param>
            /// <param name="xMSRenameSource">The file or directory to be renamed. The value must have the following format: "/{filesysystem}/{path}".  If "x-ms-properties" is specified, the properties will overwrite the existing properties; otherwise, the existing properties will be preserved.</param>
            /// <param name="xMSProperties">Optional.  User-defined properties to be stored with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is base64 encoded.</param>
            /// <param name="xMSPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="xMSUmask">Only valid if Hierarchical Namespace is enabled for the account. This umask restricts permission settings for file and directory, and will only be applied when default Acl does not exist in parent directory. If the umask bit has set, it means that the corresponding permission will be disabled. Otherwise the corresponding permission will be determined by the permission. A 4-digit octal notation (e.g. 0022) is supported here. If no umask was specified, a default umask - 0027 will be used.</param>
            /// <param name="xMSCacheControl">Cache control for given resource</param>
            /// <param name="xMSContentType">Content type for given resource</param>
            /// <param name="xMSContentEncoding">Content encoding for given resource</param>
            /// <param name="xMSContentLanguage">Content language for given resource</param>
            /// <param name="xMSContentDisposition">Content disposition for given resource</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSSourceLeaseID">A lease ID for the source path. If specified, the source path must have an active lease and the leaase ID must match.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_Rename Request.</returns>
            internal static Azure.Core.Http.Request BlobRenameAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                Integer? timeout = default,
                String? mode = default,
                String xMSRenameSource,
                String? xMSProperties = default,
                String? xMSPermissions = default,
                String? xMSUmask = default,
                String? xMSCacheControl = default,
                String? xMSContentType = default,
                String? xMSContentEncoding = default,
                String? xMSContentLanguage = default,
                String? xMSContentDisposition = default,
                String? xMSLeaseID = default,
                String? xMSSourceLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }
                if (mode != null) { _request.UriBuilder.AppendQuery("mode", System.Uri.EscapeDataString(mode)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-rename-source", xMSRenameSource);
                if (xMSProperties != null) { _request.Headers.SetValue("x-ms-properties", xMSProperties); }
                if (xMSPermissions != null) { _request.Headers.SetValue("x-ms-permissions", xMSPermissions); }
                if (xMSUmask != null) { _request.Headers.SetValue("x-ms-umask", xMSUmask); }
                if (xMSCacheControl != null) { _request.Headers.SetValue("x-ms-cache-control", xMSCacheControl); }
                if (xMSContentType != null) { _request.Headers.SetValue("x-ms-content-type", xMSContentType); }
                if (xMSContentEncoding != null) { _request.Headers.SetValue("x-ms-content-encoding", xMSContentEncoding); }
                if (xMSContentLanguage != null) { _request.Headers.SetValue("x-ms-content-language", xMSContentLanguage); }
                if (xMSContentDisposition != null) { _request.Headers.SetValue("x-ms-content-disposition", xMSContentDisposition); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSSourceLeaseID != null) { _request.Headers.SetValue("x-ms-source-lease-id", xMSSourceLeaseID); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                if (xMSSourceIFModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", xMSSourceIFModifiedSince); }
                if (xMSSourceIFUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", xMSSourceIFUnmodifiedSince); }
                if (xMSSourceIFMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", xMSSourceIFMatch); }
                if (xMSSourceIFNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", xMSSourceIFNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_Rename response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_Rename Azure.Response.</returns>
            internal static Azure.Response BlobRenameAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_Rename

            #region PageBlob.PageBlob_Create
            /// <summary>
            /// The Create operation creates a new page blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSBlobType">Specifies the type of blob to create: block blob, page blob, or append blob.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="xMSBlobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentMd5">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="xMSBlobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSBlobContentLength">This header specifies the maximum size for the page blob, up to 1 TB. The page blob size must be aligned to a 512-byte boundary.</param>
            /// <param name="xMSBlobSequenceNumber">Set for page blobs only. The sequence number is a user-controlled value that you can use to track requests. The value of the sequence number must be between 0 and 2^63 - 1.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The blob was created.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> PageBlobCreateAsync(
                Object pipeline,
                String? url = default,
                string xMSBlobType,
                Integer? timeout = default,
                Integer contentLength,
                String? xMSBlobContentType = default,
                String? xMSBlobContentEncoding = default,
                String? xMSBlobContentLanguage = default,
                String? xMSBlobContentMd5 = default,
                String? xMSBlobCacheControl = default,
                String? xMSMeta = default,
                String? xMSLeaseID = default,
                String? xMSBlobContentDisposition = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                Integer xMSBlobContentLength,
                Integer? xMSBlobSequenceNumber = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.PageBlobClient.PageBlob_Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = PageBlobCreateAsync_CreateRequest(
                        pipeline,
                        url,
                        xMSBlobType,
                        timeout,
                        contentLength,
                        xMSBlobContentType,
                        xMSBlobContentEncoding,
                        xMSBlobContentLanguage,
                        xMSBlobContentMd5,
                        xMSBlobCacheControl,
                        xMSMeta,
                        xMSLeaseID,
                        xMSBlobContentDisposition,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSBlobContentLength,
                        xMSBlobSequenceNumber,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return PageBlobCreateAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_Create request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSBlobType">Specifies the type of blob to create: block blob, page blob, or append blob.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="xMSBlobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentMd5">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="xMSBlobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSBlobContentLength">This header specifies the maximum size for the page blob, up to 1 TB. The page blob size must be aligned to a 512-byte boundary.</param>
            /// <param name="xMSBlobSequenceNumber">Set for page blobs only. The sequence number is a user-controlled value that you can use to track requests. The value of the sequence number must be between 0 and 2^63 - 1.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.PageBlob_Create Request.</returns>
            internal static Azure.Core.Http.Request PageBlobCreateAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string xMSBlobType,
                Integer? timeout = default,
                Integer contentLength,
                String? xMSBlobContentType = default,
                String? xMSBlobContentEncoding = default,
                String? xMSBlobContentLanguage = default,
                String? xMSBlobContentMd5 = default,
                String? xMSBlobCacheControl = default,
                String? xMSMeta = default,
                String? xMSLeaseID = default,
                String? xMSBlobContentDisposition = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                Integer xMSBlobContentLength,
                Integer? xMSBlobSequenceNumber = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (xMSBlobType == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSBlobType));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-blob-type", "PageBlob");
                _request.Headers.SetValue("Content-Length", UNKNOWN ENUM TYPE NAME);
                if (xMSBlobContentType != null) { _request.Headers.SetValue("x-ms-blob-content-type", xMSBlobContentType); }
                if (xMSBlobContentEncoding != null) { _request.Headers.SetValue("x-ms-blob-content-encoding", xMSBlobContentEncoding); }
                if (xMSBlobContentLanguage != null) { _request.Headers.SetValue("x-ms-blob-content-language", xMSBlobContentLanguage); }
                if (xMSBlobContentMd5 != null) { _request.Headers.SetValue("x-ms-blob-content-md5", xMSBlobContentMd5); }
                if (xMSBlobCacheControl != null) { _request.Headers.SetValue("x-ms-blob-cache-control", xMSBlobCacheControl); }
                if (xMSMeta != null) { _request.Headers.SetValue("x-ms-meta", xMSMeta); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSBlobContentDisposition != null) { _request.Headers.SetValue("x-ms-blob-content-disposition", xMSBlobContentDisposition); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-blob-content-length", UNKNOWN ENUM TYPE NAME);
                if (xMSBlobSequenceNumber != null) { _request.Headers.SetValue("x-ms-blob-sequence-number", UNKNOWN ENUM TYPE NAME); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_Create response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.PageBlob_Create Azure.Response.</returns>
            internal static Azure.Response PageBlobCreateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion PageBlob.PageBlob_Create

            #region AppendBlob.AppendBlob_Create
            /// <summary>
            /// The Create Append Blob operation creates a new append blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSBlobType">Specifies the type of blob to create: block blob, page blob, or append blob.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="xMSBlobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentMd5">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="xMSBlobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The blob was created.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> AppendBlobCreateAsync(
                Object pipeline,
                String? url = default,
                string xMSBlobType,
                Integer? timeout = default,
                Integer contentLength,
                String? xMSBlobContentType = default,
                String? xMSBlobContentEncoding = default,
                String? xMSBlobContentLanguage = default,
                String? xMSBlobContentMd5 = default,
                String? xMSBlobCacheControl = default,
                String? xMSMeta = default,
                String? xMSLeaseID = default,
                String? xMSBlobContentDisposition = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.AppendBlobClient.AppendBlob_Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AppendBlobCreateAsync_CreateRequest(
                        pipeline,
                        url,
                        xMSBlobType,
                        timeout,
                        contentLength,
                        xMSBlobContentType,
                        xMSBlobContentEncoding,
                        xMSBlobContentLanguage,
                        xMSBlobContentMd5,
                        xMSBlobCacheControl,
                        xMSMeta,
                        xMSLeaseID,
                        xMSBlobContentDisposition,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AppendBlobCreateAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the AppendBlob.AppendBlob_Create request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSBlobType">Specifies the type of blob to create: block blob, page blob, or append blob.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="xMSBlobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentMd5">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="xMSBlobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The AppendBlob.AppendBlob_Create Request.</returns>
            internal static Azure.Core.Http.Request AppendBlobCreateAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string xMSBlobType,
                Integer? timeout = default,
                Integer contentLength,
                String? xMSBlobContentType = default,
                String? xMSBlobContentEncoding = default,
                String? xMSBlobContentLanguage = default,
                String? xMSBlobContentMd5 = default,
                String? xMSBlobCacheControl = default,
                String? xMSMeta = default,
                String? xMSLeaseID = default,
                String? xMSBlobContentDisposition = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (xMSBlobType == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSBlobType));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-blob-type", "AppendBlob");
                _request.Headers.SetValue("Content-Length", UNKNOWN ENUM TYPE NAME);
                if (xMSBlobContentType != null) { _request.Headers.SetValue("x-ms-blob-content-type", xMSBlobContentType); }
                if (xMSBlobContentEncoding != null) { _request.Headers.SetValue("x-ms-blob-content-encoding", xMSBlobContentEncoding); }
                if (xMSBlobContentLanguage != null) { _request.Headers.SetValue("x-ms-blob-content-language", xMSBlobContentLanguage); }
                if (xMSBlobContentMd5 != null) { _request.Headers.SetValue("x-ms-blob-content-md5", xMSBlobContentMd5); }
                if (xMSBlobCacheControl != null) { _request.Headers.SetValue("x-ms-blob-cache-control", xMSBlobCacheControl); }
                if (xMSMeta != null) { _request.Headers.SetValue("x-ms-meta", xMSMeta); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSBlobContentDisposition != null) { _request.Headers.SetValue("x-ms-blob-content-disposition", xMSBlobContentDisposition); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the AppendBlob.AppendBlob_Create response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The AppendBlob.AppendBlob_Create Azure.Response.</returns>
            internal static Azure.Response AppendBlobCreateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion AppendBlob.AppendBlob_Create

            #region BlockBlob.BlockBlob_Upload
            /// <summary>
            /// The Upload Block Blob operation updates the content of an existing block blob. Updating an existing block blob overwrites any existing metadata on the blob. Partial updates are not supported with Put Blob; the content of the existing blob is overwritten with the content of the new blob. To perform a partial update of the content of a block blob, use the Put Block List operation.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSBlobType">Specifies the type of blob to create: block blob, page blob, or append blob.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="xMSBlobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentMd5">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="xMSBlobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSAccessTier">Optional. Indicates the tier to be set on the blob.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The blob was updated.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlockBlobUploadAsync(
                Object pipeline,
                String? url = default,
                string xMSBlobType,
                Integer? timeout = default,
                Integer contentLength,
                String? xMSBlobContentType = default,
                String? xMSBlobContentEncoding = default,
                String? xMSBlobContentLanguage = default,
                String? xMSBlobContentMd5 = default,
                String? xMSBlobCacheControl = default,
                String? xMSMeta = default,
                String? xMSLeaseID = default,
                String? xMSBlobContentDisposition = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? xMSAccessTier = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlockBlobClient.BlockBlob_Upload",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlockBlobUploadAsync_CreateRequest(
                        pipeline,
                        url,
                        xMSBlobType,
                        timeout,
                        contentLength,
                        xMSBlobContentType,
                        xMSBlobContentEncoding,
                        xMSBlobContentLanguage,
                        xMSBlobContentMd5,
                        xMSBlobCacheControl,
                        xMSMeta,
                        xMSLeaseID,
                        xMSBlobContentDisposition,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        xMSAccessTier,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlockBlobUploadAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the BlockBlob.BlockBlob_Upload request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSBlobType">Specifies the type of blob to create: block blob, page blob, or append blob.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="xMSBlobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentMd5">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="xMSBlobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSAccessTier">Optional. Indicates the tier to be set on the blob.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.BlockBlob_Upload Request.</returns>
            internal static Azure.Core.Http.Request BlockBlobUploadAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string xMSBlobType,
                Integer? timeout = default,
                Integer contentLength,
                String? xMSBlobContentType = default,
                String? xMSBlobContentEncoding = default,
                String? xMSBlobContentLanguage = default,
                String? xMSBlobContentMd5 = default,
                String? xMSBlobCacheControl = default,
                String? xMSMeta = default,
                String? xMSLeaseID = default,
                String? xMSBlobContentDisposition = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? xMSAccessTier = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (xMSBlobType == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSBlobType));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-blob-type", "BlockBlob");
                _request.Headers.SetValue("Content-Length", UNKNOWN ENUM TYPE NAME);
                if (xMSBlobContentType != null) { _request.Headers.SetValue("x-ms-blob-content-type", xMSBlobContentType); }
                if (xMSBlobContentEncoding != null) { _request.Headers.SetValue("x-ms-blob-content-encoding", xMSBlobContentEncoding); }
                if (xMSBlobContentLanguage != null) { _request.Headers.SetValue("x-ms-blob-content-language", xMSBlobContentLanguage); }
                if (xMSBlobContentMd5 != null) { _request.Headers.SetValue("x-ms-blob-content-md5", xMSBlobContentMd5); }
                if (xMSBlobCacheControl != null) { _request.Headers.SetValue("x-ms-blob-cache-control", xMSBlobCacheControl); }
                if (xMSMeta != null) { _request.Headers.SetValue("x-ms-meta", xMSMeta); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSBlobContentDisposition != null) { _request.Headers.SetValue("x-ms-blob-content-disposition", xMSBlobContentDisposition); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSAccessTier != null) { _request.Headers.SetValue("x-ms-access-tier", xMSAccessTier); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                // Create the body
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(body);

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.BlockBlob_Upload response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.BlockBlob_Upload Azure.Response.</returns>
            internal static Azure.Response BlockBlobUploadAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion BlockBlob.BlockBlob_Upload

            #region Blob.Blob_Undelete
            /// <summary>
            /// Undelete a blob that was previously soft deleted
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The blob was undeleted successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobUndeleteAsync(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_Undelete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobUndeleteAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        timeout,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobUndeleteAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_Undelete request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_Undelete Request.</returns>
            internal static Azure.Core.Http.Request BlobUndeleteAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "undelete");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_Undelete response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_Undelete Azure.Response.</returns>
            internal static Azure.Response BlobUndeleteAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_Undelete

            #region Blob.Blob_SetHTTPHeaders
            /// <summary>
            /// The Set HTTP Headers operation sets system properties on the blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSBlobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentMd5">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="xMSBlobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSBlobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The properties were set successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobSetHTTPHeadersAsync(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? xMSBlobCacheControl = default,
                String? xMSBlobContentType = default,
                String? xMSBlobContentMd5 = default,
                String? xMSBlobContentEncoding = default,
                String? xMSBlobContentLanguage = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? xMSBlobContentDisposition = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_SetHTTPHeaders",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobSetHTTPHeadersAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        timeout,
                        xMSBlobCacheControl,
                        xMSBlobContentType,
                        xMSBlobContentMd5,
                        xMSBlobContentEncoding,
                        xMSBlobContentLanguage,
                        xMSLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSBlobContentDisposition,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobSetHTTPHeadersAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_SetHTTPHeaders request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSBlobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentMd5">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="xMSBlobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSBlobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_SetHTTPHeaders Request.</returns>
            internal static Azure.Core.Http.Request BlobSetHTTPHeadersAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? xMSBlobCacheControl = default,
                String? xMSBlobContentType = default,
                String? xMSBlobContentMd5 = default,
                String? xMSBlobContentEncoding = default,
                String? xMSBlobContentLanguage = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? xMSBlobContentDisposition = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSBlobCacheControl != null) { _request.Headers.SetValue("x-ms-blob-cache-control", xMSBlobCacheControl); }
                if (xMSBlobContentType != null) { _request.Headers.SetValue("x-ms-blob-content-type", xMSBlobContentType); }
                if (xMSBlobContentMd5 != null) { _request.Headers.SetValue("x-ms-blob-content-md5", xMSBlobContentMd5); }
                if (xMSBlobContentEncoding != null) { _request.Headers.SetValue("x-ms-blob-content-encoding", xMSBlobContentEncoding); }
                if (xMSBlobContentLanguage != null) { _request.Headers.SetValue("x-ms-blob-content-language", xMSBlobContentLanguage); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                if (xMSBlobContentDisposition != null) { _request.Headers.SetValue("x-ms-blob-content-disposition", xMSBlobContentDisposition); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_SetHTTPHeaders response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_SetHTTPHeaders Azure.Response.</returns>
            internal static Azure.Response BlobSetHTTPHeadersAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_SetHTTPHeaders

            #region Blob.Blob_SetMetadata
            /// <summary>
            /// The Set Blob Metadata operation sets user-defined metadata for the specified blob as one or more name-value pairs
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The metadata was set successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobSetMetadataAsync(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? xMSMeta = default,
                String? xMSLeaseID = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_SetMetadata",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobSetMetadataAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        timeout,
                        xMSMeta,
                        xMSLeaseID,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobSetMetadataAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_SetMetadata request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_SetMetadata Request.</returns>
            internal static Azure.Core.Http.Request BlobSetMetadataAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? xMSMeta = default,
                String? xMSLeaseID = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "metadata");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSMeta != null) { _request.Headers.SetValue("x-ms-meta", xMSMeta); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_SetMetadata response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_SetMetadata Azure.Response.</returns>
            internal static Azure.Response BlobSetMetadataAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_SetMetadata

            #region Blob.Blob_AcquireLease
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseDuration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="xMSProposedLeaseID">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Acquire operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobAcquireLeaseAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSLeaseAction,
                Integer? timeout = default,
                Integer? xMSLeaseDuration = default,
                String? xMSProposedLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_AcquireLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobAcquireLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        xMSLeaseAction,
                        timeout,
                        xMSLeaseDuration,
                        xMSProposedLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobAcquireLeaseAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_AcquireLease request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseDuration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="xMSProposedLeaseID">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_AcquireLease Request.</returns>
            internal static Azure.Core.Http.Request BlobAcquireLeaseAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSLeaseAction,
                Integer? timeout = default,
                Integer? xMSLeaseDuration = default,
                String? xMSProposedLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSLeaseAction == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseAction));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "acquire");
                if (xMSLeaseDuration != null) { _request.Headers.SetValue("x-ms-lease-duration", UNKNOWN ENUM TYPE NAME); }
                if (xMSProposedLeaseID != null) { _request.Headers.SetValue("x-ms-proposed-lease-id", xMSProposedLeaseID); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_AcquireLease response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_AcquireLease Azure.Response.</returns>
            internal static Azure.Response BlobAcquireLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_AcquireLease

            #region Blob.Blob_ReleaseLease
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Release operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobReleaseLeaseAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSLeaseAction,
                Integer? timeout = default,
                String xMSLeaseID,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_ReleaseLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobReleaseLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        xMSLeaseAction,
                        timeout,
                        xMSLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobReleaseLeaseAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_ReleaseLease request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_ReleaseLease Request.</returns>
            internal static Azure.Core.Http.Request BlobReleaseLeaseAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSLeaseAction,
                Integer? timeout = default,
                String xMSLeaseID,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSLeaseAction == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseAction));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "release");
                _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID);
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_ReleaseLease response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_ReleaseLease Azure.Response.</returns>
            internal static Azure.Response BlobReleaseLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_ReleaseLease

            #region Service.Service_GetUserDelegationKey
            /// <summary>
            /// Retrieves a user delegation key for the Blob service. This is only a valid operation when using bearer token authentication.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Object>> ServiceGetUserDelegationKeyAsync(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ServiceClient.Service_GetUserDelegationKey",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ServiceGetUserDelegationKeyAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        comp,
                        timeout,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ServiceGetUserDelegationKeyAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Service.Service_GetUserDelegationKey request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.Service_GetUserDelegationKey Request.</returns>
            internal static Azure.Core.Http.Request ServiceGetUserDelegationKeyAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Post;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "service");
                _request.UriBuilder.AppendQuery("comp", "userdelegationkey");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                // Create the body
                System.Xml.Linq.XElement _body = Object.ToXml(keyInfo, "keyInfo", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Service.Service_GetUserDelegationKey response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.Service_GetUserDelegationKey Azure.Response{Object}.</returns>
            internal static Azure.Response<Object> ServiceGetUserDelegationKeyAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = _header;
                        }

                        // Create the response
                        Azure.Response<Object> _result =
                            new Azure.Response<Object>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Service.Service_GetUserDelegationKey

            #region Blob.Blob_RenewLease
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Renew operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobRenewLeaseAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSLeaseAction,
                Integer? timeout = default,
                String xMSLeaseID,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_RenewLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobRenewLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        xMSLeaseAction,
                        timeout,
                        xMSLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobRenewLeaseAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_RenewLease request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_RenewLease Request.</returns>
            internal static Azure.Core.Http.Request BlobRenewLeaseAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSLeaseAction,
                Integer? timeout = default,
                String xMSLeaseID,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSLeaseAction == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseAction));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "renew");
                _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID);
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_RenewLease response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_RenewLease Azure.Response.</returns>
            internal static Azure.Response BlobRenewLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_RenewLease

            #region Blob.Blob_ChangeLease
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">Specifies the current lease ID on the resource.</param>
            /// <param name="xMSProposedLeaseID">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Change operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobChangeLeaseAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSLeaseAction,
                Integer? timeout = default,
                String xMSLeaseID,
                String xMSProposedLeaseID,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_ChangeLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobChangeLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        xMSLeaseAction,
                        timeout,
                        xMSLeaseID,
                        xMSProposedLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobChangeLeaseAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_ChangeLease request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">Specifies the current lease ID on the resource.</param>
            /// <param name="xMSProposedLeaseID">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_ChangeLease Request.</returns>
            internal static Azure.Core.Http.Request BlobChangeLeaseAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSLeaseAction,
                Integer? timeout = default,
                String xMSLeaseID,
                String xMSProposedLeaseID,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSLeaseAction == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseAction));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "change");
                _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID);
                _request.Headers.SetValue("x-ms-proposed-lease-id", xMSProposedLeaseID);
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_ChangeLease response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_ChangeLease Azure.Response.</returns>
            internal static Azure.Response BlobChangeLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_ChangeLease

            #region Blob.Blob_BreakLease
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseBreakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Break operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobBreakLeaseAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSLeaseAction,
                Integer? timeout = default,
                Integer? xMSLeaseBreakPeriod = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_BreakLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobBreakLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        xMSLeaseAction,
                        timeout,
                        xMSLeaseBreakPeriod,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobBreakLeaseAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_BreakLease request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSLeaseAction">Describes what lease action to take.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseBreakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_BreakLease Request.</returns>
            internal static Azure.Core.Http.Request BlobBreakLeaseAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSLeaseAction,
                Integer? timeout = default,
                Integer? xMSLeaseBreakPeriod = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSLeaseAction == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseAction));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "break");
                if (xMSLeaseBreakPeriod != null) { _request.Headers.SetValue("x-ms-lease-break-period", UNKNOWN ENUM TYPE NAME); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_BreakLease response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_BreakLease Azure.Response.</returns>
            internal static Azure.Response BlobBreakLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_BreakLease

            #region Blob.Blob_CreateSnapshot
            /// <summary>
            /// The Create Snapshot operation creates a read-only snapshot of a blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The snaptshot was taken successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobCreateSnapshotAsync(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? xMSMeta = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_CreateSnapshot",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobCreateSnapshotAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        timeout,
                        xMSMeta,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSLeaseID,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobCreateSnapshotAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_CreateSnapshot request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_CreateSnapshot Request.</returns>
            internal static Azure.Core.Http.Request BlobCreateSnapshotAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? xMSMeta = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "snapshot");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSMeta != null) { _request.Headers.SetValue("x-ms-meta", xMSMeta); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_CreateSnapshot response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_CreateSnapshot Azure.Response.</returns>
            internal static Azure.Response BlobCreateSnapshotAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_CreateSnapshot

            #region Blob.Blob_StartCopyFromURL
            /// <summary>
            /// The Start Copy From URL operation copies a blob or an internet resource to a new blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSAccessTier">Optional. Indicates the tier to be set on the blob.</param>
            /// <param name="xMSRehydratePriority">Optional: Indicates the priority with which to rehydrate an archived blob.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSCopySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The copy blob has been accepted with the specified copy status.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobStartCopyFromURLAsync(
                Object pipeline,
                String? url = default,
                Integer? timeout = default,
                String? xMSMeta = default,
                String? xMSAccessTier = default,
                String? xMSRehydratePriority = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String xMSCopySource,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_StartCopyFromURL",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobStartCopyFromURLAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        xMSMeta,
                        xMSAccessTier,
                        xMSRehydratePriority,
                        xMSSourceIFModifiedSince,
                        xMSSourceIFUnmodifiedSince,
                        xMSSourceIFMatch,
                        xMSSourceIFNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSCopySource,
                        xMSLeaseID,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobStartCopyFromURLAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_StartCopyFromURL request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSAccessTier">Optional. Indicates the tier to be set on the blob.</param>
            /// <param name="xMSRehydratePriority">Optional: Indicates the priority with which to rehydrate an archived blob.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSCopySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_StartCopyFromURL Request.</returns>
            internal static Azure.Core.Http.Request BlobStartCopyFromURLAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                Integer? timeout = default,
                String? xMSMeta = default,
                String? xMSAccessTier = default,
                String? xMSRehydratePriority = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String xMSCopySource,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSMeta != null) { _request.Headers.SetValue("x-ms-meta", xMSMeta); }
                if (xMSAccessTier != null) { _request.Headers.SetValue("x-ms-access-tier", xMSAccessTier); }
                if (xMSRehydratePriority != null) { _request.Headers.SetValue("x-ms-rehydrate-priority", xMSRehydratePriority); }
                if (xMSSourceIFModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", xMSSourceIFModifiedSince); }
                if (xMSSourceIFUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", xMSSourceIFUnmodifiedSince); }
                if (xMSSourceIFMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", xMSSourceIFMatch); }
                if (xMSSourceIFNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", xMSSourceIFNoneMatch); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-copy-source", xMSCopySource);
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_StartCopyFromURL response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_StartCopyFromURL Azure.Response.</returns>
            internal static Azure.Response BlobStartCopyFromURLAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_StartCopyFromURL

            #region Blob.Blob_CopyFromURL
            /// <summary>
            /// The Copy From URL operation copies a blob or an internet resource to a new blob. It will not return a response until the copy is complete.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSAccessTier">Optional. Indicates the tier to be set on the blob.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSCopySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The copy has completed.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobCopyFromURLAsync(
                Object pipeline,
                String? url = default,
                string xMSRequiresSync,
                Integer? timeout = default,
                String? xMSMeta = default,
                String? xMSAccessTier = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String xMSCopySource,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_CopyFromURL",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobCopyFromURLAsync_CreateRequest(
                        pipeline,
                        url,
                        xMSRequiresSync,
                        timeout,
                        xMSMeta,
                        xMSAccessTier,
                        xMSSourceIFModifiedSince,
                        xMSSourceIFUnmodifiedSince,
                        xMSSourceIFMatch,
                        xMSSourceIFNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSCopySource,
                        xMSLeaseID,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobCopyFromURLAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_CopyFromURL request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSAccessTier">Optional. Indicates the tier to be set on the blob.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSCopySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_CopyFromURL Request.</returns>
            internal static Azure.Core.Http.Request BlobCopyFromURLAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string xMSRequiresSync,
                Integer? timeout = default,
                String? xMSMeta = default,
                String? xMSAccessTier = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String xMSCopySource,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (xMSRequiresSync == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSRequiresSync));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-requires-sync", "true");
                if (xMSMeta != null) { _request.Headers.SetValue("x-ms-meta", xMSMeta); }
                if (xMSAccessTier != null) { _request.Headers.SetValue("x-ms-access-tier", xMSAccessTier); }
                if (xMSSourceIFModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", xMSSourceIFModifiedSince); }
                if (xMSSourceIFUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", xMSSourceIFUnmodifiedSince); }
                if (xMSSourceIFMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", xMSSourceIFMatch); }
                if (xMSSourceIFNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", xMSSourceIFNoneMatch); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-copy-source", xMSCopySource);
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_CopyFromURL response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_CopyFromURL Azure.Response.</returns>
            internal static Azure.Response BlobCopyFromURLAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_CopyFromURL

            #region Blob.Blob_AbortCopyFromURL
            /// <summary>
            /// The Abort Copy From URL operation aborts a pending Copy From URL operation, and leaves a destination blob with zero length and full metadata.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="copyid">The copy identifier provided in the x-ms-copy-id header of the original Copy Blob operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The delete request was accepted and the blob will be deleted.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobAbortCopyFromURLAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSCopyAction,
                String copyid,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_AbortCopyFromURL",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobAbortCopyFromURLAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        xMSCopyAction,
                        copyid,
                        timeout,
                        xMSLeaseID,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobAbortCopyFromURLAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_AbortCopyFromURL request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="copyid">The copy identifier provided in the x-ms-copy-id header of the original Copy Blob operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.Blob_AbortCopyFromURL Request.</returns>
            internal static Azure.Core.Http.Request BlobAbortCopyFromURLAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSCopyAction,
                String copyid,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSCopyAction == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSCopyAction));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "copy");
                _request.UriBuilder.AppendQuery("copyid", System.Uri.EscapeDataString(copyid));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-copy-action", "abort");
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_AbortCopyFromURL response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_AbortCopyFromURL Azure.Response.</returns>
            internal static Azure.Response BlobAbortCopyFromURLAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 204:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_AbortCopyFromURL

            #region Blob.Blob_SetTier
            /// <summary>
            /// The Set Tier operation sets the tier on a blob. The operation is allowed on a page blob in a premium storage account and on a block blob in a blob storage account (locally redundant storage only). A premium page blob's tier determines the allowed size, IOPS, and bandwidth of the blob. A block blob's tier determines Hot/Cool/Archive storage type. This operation does not update the blob's ETag.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSAccessTier">Indicates the tier to be set on the blob.</param>
            /// <param name="xMSRehydratePriority">Optional: Indicates the priority with which to rehydrate an archived blob.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The new tier will take effect immediately.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobSetTierAsync(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String xMSAccessTier,
                String? xMSRehydratePriority = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                String? xMSLeaseID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_SetTier",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobSetTierAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        timeout,
                        xMSAccessTier,
                        xMSRehydratePriority,
                        xMSVersion,
                        xMSClientRequestID,
                        xMSLeaseID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobSetTierAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_SetTier request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSAccessTier">Indicates the tier to be set on the blob.</param>
            /// <param name="xMSRehydratePriority">Optional: Indicates the priority with which to rehydrate an archived blob.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The Blob.Blob_SetTier Request.</returns>
            internal static Azure.Core.Http.Request BlobSetTierAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String xMSAccessTier,
                String? xMSRehydratePriority = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                String? xMSLeaseID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "tier");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-access-tier", xMSAccessTier);
                if (xMSRehydratePriority != null) { _request.Headers.SetValue("x-ms-rehydrate-priority", xMSRehydratePriority); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_SetTier response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_SetTier Azure.Response.</returns>
            internal static Azure.Response BlobSetTierAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_SetTier

            #region Blob.Blob_GetAccountInfo
            /// <summary>
            /// Returns the sku name and account kind 
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success (OK)</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlobGetAccountInfoAsync(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                string xMSVersion,
                string operationName = "DefaultNS.AzureBlobStorage.BlobClient.Blob_GetAccountInfo",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlobGetAccountInfoAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        comp,
                        xMSVersion))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlobGetAccountInfoAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Blob.Blob_GetAccountInfo request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <returns>The Blob.Blob_GetAccountInfo Request.</returns>
            internal static Azure.Core.Http.Request BlobGetAccountInfoAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                string xMSVersion)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "account");
                _request.UriBuilder.AppendQuery("comp", "properties");

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");

                return _request;
            }

            /// <summary>
            /// Create the Blob.Blob_GetAccountInfo response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.Blob_GetAccountInfo Azure.Response.</returns>
            internal static Azure.Response BlobGetAccountInfoAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Blob.Blob_GetAccountInfo

            #region BlockBlob.BlockBlob_StageBlock
            /// <summary>
            /// The Stage Block operation creates a new block to be committed as part of a blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blockid">A valid Base64 string value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="contentMD5">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="xMSContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The block was created.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlockBlobStageBlockAsync(
                Object pipeline,
                String? url = default,
                string comp,
                String blockid,
                Integer contentLength,
                String? contentMD5 = default,
                String? xMSContentCrc64 = default,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlockBlobClient.BlockBlob_StageBlock",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlockBlobStageBlockAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        blockid,
                        contentLength,
                        contentMD5,
                        xMSContentCrc64,
                        timeout,
                        xMSLeaseID,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlockBlobStageBlockAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the BlockBlob.BlockBlob_StageBlock request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blockid">A valid Base64 string value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="contentMD5">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="xMSContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.BlockBlob_StageBlock Request.</returns>
            internal static Azure.Core.Http.Request BlockBlobStageBlockAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                String blockid,
                Integer contentLength,
                String? contentMD5 = default,
                String? xMSContentCrc64 = default,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "block");
                _request.UriBuilder.AppendQuery("blockid", System.Uri.EscapeDataString(blockid));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("Content-Length", UNKNOWN ENUM TYPE NAME);
                if (contentMD5 != null) { _request.Headers.SetValue("Content-MD5", contentMD5); }
                if (xMSContentCrc64 != null) { _request.Headers.SetValue("x-ms-content-crc64", xMSContentCrc64); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                // Create the body
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(body);

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.BlockBlob_StageBlock response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.BlockBlob_StageBlock Azure.Response.</returns>
            internal static Azure.Response BlockBlobStageBlockAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion BlockBlob.BlockBlob_StageBlock

            #region Service.Service_GetAccountInfo
            /// <summary>
            /// Returns the sku name and account kind 
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success (OK)</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ServiceGetAccountInfoAsync(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                string xMSVersion,
                string operationName = "DefaultNS.AzureBlobStorage.ServiceClient.Service_GetAccountInfo",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ServiceGetAccountInfoAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        comp,
                        xMSVersion))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ServiceGetAccountInfoAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Service.Service_GetAccountInfo request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <returns>The Service.Service_GetAccountInfo Request.</returns>
            internal static Azure.Core.Http.Request ServiceGetAccountInfoAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                string comp,
                string xMSVersion)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "account");
                _request.UriBuilder.AppendQuery("comp", "properties");

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");

                return _request;
            }

            /// <summary>
            /// Create the Service.Service_GetAccountInfo response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.Service_GetAccountInfo Azure.Response.</returns>
            internal static Azure.Response ServiceGetAccountInfoAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Service.Service_GetAccountInfo

            #region BlockBlob.BlockBlob_StageBlockFromURL
            /// <summary>
            /// The Stage Block operation creates a new block to be committed as part of a blob where the contents are read from a URL.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blockid">A valid Base64 string value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="xMSCopySource">Specify a URL to the copy source.</param>
            /// <param name="xMSSourceRange">Bytes of source data in the specified range.</param>
            /// <param name="xMSSourceContentMd5">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="xMSSourceContentCrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The block was created.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlockBlobStageBlockFromURLAsync(
                Object pipeline,
                String? url = default,
                string comp,
                String blockid,
                Integer contentLength,
                String xMSCopySource,
                String? xMSSourceRange = default,
                String? xMSSourceContentMd5 = default,
                String? xMSSourceContentCrc64 = default,
                Integer? timeout = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? xMSLeaseID = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlockBlobClient.BlockBlob_StageBlockFromURL",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlockBlobStageBlockFromURLAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        blockid,
                        contentLength,
                        xMSCopySource,
                        xMSSourceRange,
                        xMSSourceContentMd5,
                        xMSSourceContentCrc64,
                        timeout,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        xMSLeaseID,
                        xMSSourceIFModifiedSince,
                        xMSSourceIFUnmodifiedSince,
                        xMSSourceIFMatch,
                        xMSSourceIFNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlockBlobStageBlockFromURLAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the BlockBlob.BlockBlob_StageBlockFromURL request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blockid">A valid Base64 string value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="xMSCopySource">Specify a URL to the copy source.</param>
            /// <param name="xMSSourceRange">Bytes of source data in the specified range.</param>
            /// <param name="xMSSourceContentMd5">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="xMSSourceContentCrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.BlockBlob_StageBlockFromURL Request.</returns>
            internal static Azure.Core.Http.Request BlockBlobStageBlockFromURLAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                String blockid,
                Integer contentLength,
                String xMSCopySource,
                String? xMSSourceRange = default,
                String? xMSSourceContentMd5 = default,
                String? xMSSourceContentCrc64 = default,
                Integer? timeout = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? xMSLeaseID = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "block");
                _request.UriBuilder.AppendQuery("blockid", System.Uri.EscapeDataString(blockid));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("Content-Length", UNKNOWN ENUM TYPE NAME);
                _request.Headers.SetValue("x-ms-copy-source", xMSCopySource);
                if (xMSSourceRange != null) { _request.Headers.SetValue("x-ms-source-range", xMSSourceRange); }
                if (xMSSourceContentMd5 != null) { _request.Headers.SetValue("x-ms-source-content-md5", xMSSourceContentMd5); }
                if (xMSSourceContentCrc64 != null) { _request.Headers.SetValue("x-ms-source-content-crc64", xMSSourceContentCrc64); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSSourceIFModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", xMSSourceIFModifiedSince); }
                if (xMSSourceIFUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", xMSSourceIFUnmodifiedSince); }
                if (xMSSourceIFMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", xMSSourceIFMatch); }
                if (xMSSourceIFNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", xMSSourceIFNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.BlockBlob_StageBlockFromURL response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.BlockBlob_StageBlockFromURL Azure.Response.</returns>
            internal static Azure.Response BlockBlobStageBlockFromURLAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion BlockBlob.BlockBlob_StageBlockFromURL

            #region BlockBlob.BlockBlob_CommitBlockList
            /// <summary>
            /// The Commit Block List operation writes a blob by specifying the list of block IDs that make up the blob. In order to be written as part of a blob, a block must have been successfully written to the server in a prior Put Block operation. You can call Put Block List to update a blob by uploading only those blocks that have changed, then committing the new and existing blocks together. You can do this by specifying whether to commit a block from the committed block list or from the uncommitted block list, or to commit the most recently uploaded version of the block, whichever list it may belong to.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSBlobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentMd5">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="contentMD5">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="xMSContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSAccessTier">Optional. Indicates the tier to be set on the blob.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The block list was recorded.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BlockBlobCommitBlockListAsync(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? xMSBlobCacheControl = default,
                String? xMSBlobContentType = default,
                String? xMSBlobContentEncoding = default,
                String? xMSBlobContentLanguage = default,
                String? xMSBlobContentMd5 = default,
                String? contentMD5 = default,
                String? xMSContentCrc64 = default,
                String? xMSMeta = default,
                String? xMSLeaseID = default,
                String? xMSBlobContentDisposition = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? xMSAccessTier = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlockBlobClient.BlockBlob_CommitBlockList",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlockBlobCommitBlockListAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        timeout,
                        xMSBlobCacheControl,
                        xMSBlobContentType,
                        xMSBlobContentEncoding,
                        xMSBlobContentLanguage,
                        xMSBlobContentMd5,
                        contentMD5,
                        xMSContentCrc64,
                        xMSMeta,
                        xMSLeaseID,
                        xMSBlobContentDisposition,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        xMSAccessTier,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlockBlobCommitBlockListAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the BlockBlob.BlockBlob_CommitBlockList request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSBlobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="xMSBlobContentMd5">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="contentMD5">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="xMSContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSAccessTier">Optional. Indicates the tier to be set on the blob.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.BlockBlob_CommitBlockList Request.</returns>
            internal static Azure.Core.Http.Request BlockBlobCommitBlockListAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? xMSBlobCacheControl = default,
                String? xMSBlobContentType = default,
                String? xMSBlobContentEncoding = default,
                String? xMSBlobContentLanguage = default,
                String? xMSBlobContentMd5 = default,
                String? contentMD5 = default,
                String? xMSContentCrc64 = default,
                String? xMSMeta = default,
                String? xMSLeaseID = default,
                String? xMSBlobContentDisposition = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? xMSAccessTier = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "blocklist");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSBlobCacheControl != null) { _request.Headers.SetValue("x-ms-blob-cache-control", xMSBlobCacheControl); }
                if (xMSBlobContentType != null) { _request.Headers.SetValue("x-ms-blob-content-type", xMSBlobContentType); }
                if (xMSBlobContentEncoding != null) { _request.Headers.SetValue("x-ms-blob-content-encoding", xMSBlobContentEncoding); }
                if (xMSBlobContentLanguage != null) { _request.Headers.SetValue("x-ms-blob-content-language", xMSBlobContentLanguage); }
                if (xMSBlobContentMd5 != null) { _request.Headers.SetValue("x-ms-blob-content-md5", xMSBlobContentMd5); }
                if (contentMD5 != null) { _request.Headers.SetValue("Content-MD5", contentMD5); }
                if (xMSContentCrc64 != null) { _request.Headers.SetValue("x-ms-content-crc64", xMSContentCrc64); }
                if (xMSMeta != null) { _request.Headers.SetValue("x-ms-meta", xMSMeta); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSBlobContentDisposition != null) { _request.Headers.SetValue("x-ms-blob-content-disposition", xMSBlobContentDisposition); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSAccessTier != null) { _request.Headers.SetValue("x-ms-access-tier", xMSAccessTier); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                // Create the body
                System.Xml.Linq.XElement _body = Object.ToXml(blocks, "BlockList", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.BlockBlob_CommitBlockList response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.BlockBlob_CommitBlockList Azure.Response.</returns>
            internal static Azure.Response BlockBlobCommitBlockListAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion BlockBlob.BlockBlob_CommitBlockList

            #region BlockBlob.BlockBlob_GetBlockList
            /// <summary>
            /// The Get Block List operation retrieves the list of blocks that have been uploaded as part of a block blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="blocklisttype">Specifies whether to return the list of committed blocks, the list of uncommitted blocks, or both lists together.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The page range was written.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Object>> BlockBlobGetBlockListAsync(
                Object pipeline,
                String? url = default,
                string comp,
                String? snapshot = default,
                String blocklisttype,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.BlockBlobClient.BlockBlob_GetBlockList",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BlockBlobGetBlockListAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        snapshot,
                        blocklisttype,
                        timeout,
                        xMSLeaseID,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BlockBlobGetBlockListAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the BlockBlob.BlockBlob_GetBlockList request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="blocklisttype">Specifies whether to return the list of committed blocks, the list of uncommitted blocks, or both lists together.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.BlockBlob_GetBlockList Request.</returns>
            internal static Azure.Core.Http.Request BlockBlobGetBlockListAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                String? snapshot = default,
                String blocklisttype,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "blocklist");
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                _request.UriBuilder.AppendQuery("blocklisttype", System.Uri.EscapeDataString(blocklisttype));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.BlockBlob_GetBlockList response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.BlockBlob_GetBlockList Azure.Response{Object}.</returns>
            internal static Azure.Response<Object> BlockBlobGetBlockListAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("BlobContentLength", out _header))
                        {
                            _value.BlobContentLength = (UNKNOWN ENUM TYPE NAME)System.Enum.Parse(typeof(UNKNOWN ENUM TYPE NAME), _header, false);
                        }
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = _header;
                        }

                        // Create the response
                        Azure.Response<Object> _result =
                            new Azure.Response<Object>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion BlockBlob.BlockBlob_GetBlockList

            #region PageBlob.PageBlob_UploadPages
            /// <summary>
            /// The Upload Pages operation writes a range of pages to a page blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSPageWrite">Required. You may specify one of the following options:
  - Update: Writes the bytes specified by the request body into the specified range. The Range and Content-Length headers must match to perform the update.
  - Clear: Clears the specified range and releases the space used in storage for that range. To clear a range, set the Content-Length header to zero, and the Range header to a value that indicates the range to clear, up to maximum blob size.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="contentMD5">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="xMSContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSRange">Return only the bytes of the blob in the specified range.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSIFSequenceNumberLE">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="xMSIFSequenceNumberLT">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="xMSIFSequenceNumberEQ">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The page range was written.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> PageBlobUploadPagesAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSPageWrite,
                Integer contentLength,
                String? contentMD5 = default,
                String? xMSContentCrc64 = default,
                Integer? timeout = default,
                String? xMSRange = default,
                String? xMSLeaseID = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                Integer? xMSIFSequenceNumberLE = default,
                Integer? xMSIFSequenceNumberLT = default,
                Integer? xMSIFSequenceNumberEQ = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.PageBlobClient.PageBlob_UploadPages",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = PageBlobUploadPagesAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        xMSPageWrite,
                        contentLength,
                        contentMD5,
                        xMSContentCrc64,
                        timeout,
                        xMSRange,
                        xMSLeaseID,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        xMSIFSequenceNumberLE,
                        xMSIFSequenceNumberLT,
                        xMSIFSequenceNumberEQ,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return PageBlobUploadPagesAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_UploadPages request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSPageWrite">Required. You may specify one of the following options:
  - Update: Writes the bytes specified by the request body into the specified range. The Range and Content-Length headers must match to perform the update.
  - Clear: Clears the specified range and releases the space used in storage for that range. To clear a range, set the Content-Length header to zero, and the Range header to a value that indicates the range to clear, up to maximum blob size.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="contentMD5">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="xMSContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSRange">Return only the bytes of the blob in the specified range.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSIFSequenceNumberLE">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="xMSIFSequenceNumberLT">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="xMSIFSequenceNumberEQ">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.PageBlob_UploadPages Request.</returns>
            internal static Azure.Core.Http.Request PageBlobUploadPagesAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSPageWrite,
                Integer contentLength,
                String? contentMD5 = default,
                String? xMSContentCrc64 = default,
                Integer? timeout = default,
                String? xMSRange = default,
                String? xMSLeaseID = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                Integer? xMSIFSequenceNumberLE = default,
                Integer? xMSIFSequenceNumberLT = default,
                Integer? xMSIFSequenceNumberEQ = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSPageWrite == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSPageWrite));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "page");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-page-write", "update");
                _request.Headers.SetValue("Content-Length", UNKNOWN ENUM TYPE NAME);
                if (contentMD5 != null) { _request.Headers.SetValue("Content-MD5", contentMD5); }
                if (xMSContentCrc64 != null) { _request.Headers.SetValue("x-ms-content-crc64", xMSContentCrc64); }
                if (xMSRange != null) { _request.Headers.SetValue("x-ms-range", xMSRange); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSIFSequenceNumberLE != null) { _request.Headers.SetValue("x-ms-if-sequence-number-le", UNKNOWN ENUM TYPE NAME); }
                if (xMSIFSequenceNumberLT != null) { _request.Headers.SetValue("x-ms-if-sequence-number-lt", UNKNOWN ENUM TYPE NAME); }
                if (xMSIFSequenceNumberEQ != null) { _request.Headers.SetValue("x-ms-if-sequence-number-eq", UNKNOWN ENUM TYPE NAME); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                // Create the body
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(body);

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_UploadPages response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.PageBlob_UploadPages Azure.Response.</returns>
            internal static Azure.Response PageBlobUploadPagesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion PageBlob.PageBlob_UploadPages

            #region PageBlob.PageBlob_ClearPages
            /// <summary>
            /// The Clear Pages operation clears a set of pages from a page blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSPageWrite">Required. You may specify one of the following options:
  - Update: Writes the bytes specified by the request body into the specified range. The Range and Content-Length headers must match to perform the update.
  - Clear: Clears the specified range and releases the space used in storage for that range. To clear a range, set the Content-Length header to zero, and the Range header to a value that indicates the range to clear, up to maximum blob size.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSRange">Return only the bytes of the blob in the specified range.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSIFSequenceNumberLE">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="xMSIFSequenceNumberLT">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="xMSIFSequenceNumberEQ">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The page range was cleared.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> PageBlobClearPagesAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSPageWrite,
                Integer contentLength,
                Integer? timeout = default,
                String? xMSRange = default,
                String? xMSLeaseID = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                Integer? xMSIFSequenceNumberLE = default,
                Integer? xMSIFSequenceNumberLT = default,
                Integer? xMSIFSequenceNumberEQ = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.PageBlobClient.PageBlob_ClearPages",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = PageBlobClearPagesAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        xMSPageWrite,
                        contentLength,
                        timeout,
                        xMSRange,
                        xMSLeaseID,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        xMSIFSequenceNumberLE,
                        xMSIFSequenceNumberLT,
                        xMSIFSequenceNumberEQ,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return PageBlobClearPagesAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_ClearPages request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSPageWrite">Required. You may specify one of the following options:
  - Update: Writes the bytes specified by the request body into the specified range. The Range and Content-Length headers must match to perform the update.
  - Clear: Clears the specified range and releases the space used in storage for that range. To clear a range, set the Content-Length header to zero, and the Range header to a value that indicates the range to clear, up to maximum blob size.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSRange">Return only the bytes of the blob in the specified range.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSIFSequenceNumberLE">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="xMSIFSequenceNumberLT">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="xMSIFSequenceNumberEQ">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.PageBlob_ClearPages Request.</returns>
            internal static Azure.Core.Http.Request PageBlobClearPagesAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSPageWrite,
                Integer contentLength,
                Integer? timeout = default,
                String? xMSRange = default,
                String? xMSLeaseID = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                Integer? xMSIFSequenceNumberLE = default,
                Integer? xMSIFSequenceNumberLT = default,
                Integer? xMSIFSequenceNumberEQ = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSPageWrite == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSPageWrite));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "page");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-page-write", "clear");
                _request.Headers.SetValue("Content-Length", UNKNOWN ENUM TYPE NAME);
                if (xMSRange != null) { _request.Headers.SetValue("x-ms-range", xMSRange); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSIFSequenceNumberLE != null) { _request.Headers.SetValue("x-ms-if-sequence-number-le", UNKNOWN ENUM TYPE NAME); }
                if (xMSIFSequenceNumberLT != null) { _request.Headers.SetValue("x-ms-if-sequence-number-lt", UNKNOWN ENUM TYPE NAME); }
                if (xMSIFSequenceNumberEQ != null) { _request.Headers.SetValue("x-ms-if-sequence-number-eq", UNKNOWN ENUM TYPE NAME); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_ClearPages response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.PageBlob_ClearPages Azure.Response.</returns>
            internal static Azure.Response PageBlobClearPagesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion PageBlob.PageBlob_ClearPages

            #region PageBlob.PageBlob_UploadPagesFromURL
            /// <summary>
            /// The Upload Pages operation writes a range of pages to a page blob where the contents are read from a URL
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSPageWrite">Required. You may specify one of the following options:
  - Update: Writes the bytes specified by the request body into the specified range. The Range and Content-Length headers must match to perform the update.
  - Clear: Clears the specified range and releases the space used in storage for that range. To clear a range, set the Content-Length header to zero, and the Range header to a value that indicates the range to clear, up to maximum blob size.</param>
            /// <param name="xMSCopySource">Specify a URL to the copy source.</param>
            /// <param name="xMSSourceRange">Bytes of source data in the specified range. The length of this range should match the ContentLength header and x-ms-range/Range destination range header.</param>
            /// <param name="xMSSourceContentMd5">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="xMSSourceContentCrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSRange">The range of bytes to which the source range would be written. The range should be 512 aligned and range-end is required.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSIFSequenceNumberLE">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="xMSIFSequenceNumberLT">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="xMSIFSequenceNumberEQ">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The page range was written.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> PageBlobUploadPagesFromURLAsync(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSPageWrite,
                String xMSCopySource,
                String xMSSourceRange,
                String? xMSSourceContentMd5 = default,
                String? xMSSourceContentCrc64 = default,
                Integer contentLength,
                Integer? timeout = default,
                String xMSRange,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? xMSLeaseID = default,
                Integer? xMSIFSequenceNumberLE = default,
                Integer? xMSIFSequenceNumberLT = default,
                Integer? xMSIFSequenceNumberEQ = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.PageBlobClient.PageBlob_UploadPagesFromURL",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = PageBlobUploadPagesFromURLAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        xMSPageWrite,
                        xMSCopySource,
                        xMSSourceRange,
                        xMSSourceContentMd5,
                        xMSSourceContentCrc64,
                        contentLength,
                        timeout,
                        xMSRange,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        xMSLeaseID,
                        xMSIFSequenceNumberLE,
                        xMSIFSequenceNumberLT,
                        xMSIFSequenceNumberEQ,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSSourceIFModifiedSince,
                        xMSSourceIFUnmodifiedSince,
                        xMSSourceIFMatch,
                        xMSSourceIFNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return PageBlobUploadPagesFromURLAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_UploadPagesFromURL request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSPageWrite">Required. You may specify one of the following options:
  - Update: Writes the bytes specified by the request body into the specified range. The Range and Content-Length headers must match to perform the update.
  - Clear: Clears the specified range and releases the space used in storage for that range. To clear a range, set the Content-Length header to zero, and the Range header to a value that indicates the range to clear, up to maximum blob size.</param>
            /// <param name="xMSCopySource">Specify a URL to the copy source.</param>
            /// <param name="xMSSourceRange">Bytes of source data in the specified range. The length of this range should match the ContentLength header and x-ms-range/Range destination range header.</param>
            /// <param name="xMSSourceContentMd5">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="xMSSourceContentCrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSRange">The range of bytes to which the source range would be written. The range should be 512 aligned and range-end is required.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSIFSequenceNumberLE">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="xMSIFSequenceNumberLT">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="xMSIFSequenceNumberEQ">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.PageBlob_UploadPagesFromURL Request.</returns>
            internal static Azure.Core.Http.Request PageBlobUploadPagesFromURLAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                string xMSPageWrite,
                String xMSCopySource,
                String xMSSourceRange,
                String? xMSSourceContentMd5 = default,
                String? xMSSourceContentCrc64 = default,
                Integer contentLength,
                Integer? timeout = default,
                String xMSRange,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? xMSLeaseID = default,
                Integer? xMSIFSequenceNumberLE = default,
                Integer? xMSIFSequenceNumberLT = default,
                Integer? xMSIFSequenceNumberEQ = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSPageWrite == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSPageWrite));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "page");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-page-write", "update");
                _request.Headers.SetValue("x-ms-copy-source", xMSCopySource);
                _request.Headers.SetValue("x-ms-source-range", xMSSourceRange);
                if (xMSSourceContentMd5 != null) { _request.Headers.SetValue("x-ms-source-content-md5", xMSSourceContentMd5); }
                if (xMSSourceContentCrc64 != null) { _request.Headers.SetValue("x-ms-source-content-crc64", xMSSourceContentCrc64); }
                _request.Headers.SetValue("Content-Length", UNKNOWN ENUM TYPE NAME);
                _request.Headers.SetValue("x-ms-range", xMSRange);
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSIFSequenceNumberLE != null) { _request.Headers.SetValue("x-ms-if-sequence-number-le", UNKNOWN ENUM TYPE NAME); }
                if (xMSIFSequenceNumberLT != null) { _request.Headers.SetValue("x-ms-if-sequence-number-lt", UNKNOWN ENUM TYPE NAME); }
                if (xMSIFSequenceNumberEQ != null) { _request.Headers.SetValue("x-ms-if-sequence-number-eq", UNKNOWN ENUM TYPE NAME); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                if (xMSSourceIFModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", xMSSourceIFModifiedSince); }
                if (xMSSourceIFUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", xMSSourceIFUnmodifiedSince); }
                if (xMSSourceIFMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", xMSSourceIFMatch); }
                if (xMSSourceIFNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", xMSSourceIFNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_UploadPagesFromURL response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.PageBlob_UploadPagesFromURL Azure.Response.</returns>
            internal static Azure.Response PageBlobUploadPagesFromURLAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion PageBlob.PageBlob_UploadPagesFromURL

            #region PageBlob.PageBlob_GetPageRanges
            /// <summary>
            /// The Get Page Ranges operation returns the list of valid page ranges for a page blob or snapshot of a page blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSRange">Return only the bytes of the blob in the specified range.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Information on the page blob was found.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Object>> PageBlobGetPageRangesAsync(
                Object pipeline,
                String? url = default,
                string comp,
                String? snapshot = default,
                Integer? timeout = default,
                String? xMSRange = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.PageBlobClient.PageBlob_GetPageRanges",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = PageBlobGetPageRangesAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        snapshot,
                        timeout,
                        xMSRange,
                        xMSLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return PageBlobGetPageRangesAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_GetPageRanges request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSRange">Return only the bytes of the blob in the specified range.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.PageBlob_GetPageRanges Request.</returns>
            internal static Azure.Core.Http.Request PageBlobGetPageRangesAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                String? snapshot = default,
                Integer? timeout = default,
                String? xMSRange = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "pagelist");
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSRange != null) { _request.Headers.SetValue("x-ms-range", xMSRange); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_GetPageRanges response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.PageBlob_GetPageRanges Azure.Response{Object}.</returns>
            internal static Azure.Response<Object> PageBlobGetPageRangesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("BlobContentLength", out _header))
                        {
                            _value.BlobContentLength = (UNKNOWN ENUM TYPE NAME)System.Enum.Parse(typeof(UNKNOWN ENUM TYPE NAME), _header, false);
                        }
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = _header;
                        }

                        // Create the response
                        Azure.Response<Object> _result =
                            new Azure.Response<Object>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion PageBlob.PageBlob_GetPageRanges

            #region PageBlob.PageBlob_GetPageRangesDiff
            /// <summary>
            /// The Get Page Ranges Diff operation returns the list of valid page ranges for a page blob that were changed between target blob and previous snapshot.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="prevsnapshot">Optional in version 2015-07-08 and newer. The prevsnapshot parameter is a DateTime value that specifies that the response will contain only pages that were changed between target blob and previous snapshot. Changed pages include both updated and cleared pages. The target blob may be a snapshot, as long as the snapshot specified by prevsnapshot is the older of the two. Note that incremental snapshots are currently supported only for blobs created on or after January 1, 2016.</param>
            /// <param name="xMSRange">Return only the bytes of the blob in the specified range.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Information on the page blob was found.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Object>> PageBlobGetPageRangesDiffAsync(
                Object pipeline,
                String? url = default,
                string comp,
                String? snapshot = default,
                Integer? timeout = default,
                String? prevsnapshot = default,
                String? xMSRange = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.PageBlobClient.PageBlob_GetPageRangesDiff",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = PageBlobGetPageRangesDiffAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        snapshot,
                        timeout,
                        prevsnapshot,
                        xMSRange,
                        xMSLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return PageBlobGetPageRangesDiffAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_GetPageRangesDiff request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="prevsnapshot">Optional in version 2015-07-08 and newer. The prevsnapshot parameter is a DateTime value that specifies that the response will contain only pages that were changed between target blob and previous snapshot. Changed pages include both updated and cleared pages. The target blob may be a snapshot, as long as the snapshot specified by prevsnapshot is the older of the two. Note that incremental snapshots are currently supported only for blobs created on or after January 1, 2016.</param>
            /// <param name="xMSRange">Return only the bytes of the blob in the specified range.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.PageBlob_GetPageRangesDiff Request.</returns>
            internal static Azure.Core.Http.Request PageBlobGetPageRangesDiffAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                String? snapshot = default,
                Integer? timeout = default,
                String? prevsnapshot = default,
                String? xMSRange = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "pagelist");
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }
                if (prevsnapshot != null) { _request.UriBuilder.AppendQuery("prevsnapshot", System.Uri.EscapeDataString(prevsnapshot)); }

                // Add request headers
                if (xMSRange != null) { _request.Headers.SetValue("x-ms-range", xMSRange); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_GetPageRangesDiff response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.PageBlob_GetPageRangesDiff Azure.Response{Object}.</returns>
            internal static Azure.Response<Object> PageBlobGetPageRangesDiffAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("BlobContentLength", out _header))
                        {
                            _value.BlobContentLength = (UNKNOWN ENUM TYPE NAME)System.Enum.Parse(typeof(UNKNOWN ENUM TYPE NAME), _header, false);
                        }
                        if (response.Headers.TryGetValue("ClientRequestId", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = _header;
                        }

                        // Create the response
                        Azure.Response<Object> _result =
                            new Azure.Response<Object>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion PageBlob.PageBlob_GetPageRangesDiff

            #region PageBlob.PageBlob_Resize
            /// <summary>
            /// Resize the Blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSBlobContentLength">This header specifies the maximum size for the page blob, up to 1 TB. The page blob size must be aligned to a 512-byte boundary.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Blob was resized successfully</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> PageBlobResizeAsync(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                Integer xMSBlobContentLength,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.PageBlobClient.PageBlob_Resize",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = PageBlobResizeAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        timeout,
                        xMSLeaseID,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSBlobContentLength,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return PageBlobResizeAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_Resize request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSBlobContentLength">This header specifies the maximum size for the page blob, up to 1 TB. The page blob size must be aligned to a 512-byte boundary.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.PageBlob_Resize Request.</returns>
            internal static Azure.Core.Http.Request PageBlobResizeAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                Integer xMSBlobContentLength,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-blob-content-length", UNKNOWN ENUM TYPE NAME);
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_Resize response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.PageBlob_Resize Azure.Response.</returns>
            internal static Azure.Response PageBlobResizeAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion PageBlob.PageBlob_Resize

            #region PageBlob.PageBlob_UpdateSequenceNumber
            /// <summary>
            /// Update the sequence number of the blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSSequenceNumberAction">Required if the x-ms-blob-sequence-number header is set for the request. This property applies to page blobs only. This property indicates how the service should modify the blob's sequence number</param>
            /// <param name="xMSBlobSequenceNumber">Set for page blobs only. The sequence number is a user-controlled value that you can use to track requests. The value of the sequence number must be between 0 and 2^63 - 1.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The sequence numbers were updated successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> PageBlobUpdateSequenceNumberAsync(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String xMSSequenceNumberAction,
                Integer? xMSBlobSequenceNumber = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.PageBlobClient.PageBlob_UpdateSequenceNumber",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = PageBlobUpdateSequenceNumberAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        timeout,
                        xMSLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSSequenceNumberAction,
                        xMSBlobSequenceNumber,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return PageBlobUpdateSequenceNumberAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_UpdateSequenceNumber request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSSequenceNumberAction">Required if the x-ms-blob-sequence-number header is set for the request. This property applies to page blobs only. This property indicates how the service should modify the blob's sequence number</param>
            /// <param name="xMSBlobSequenceNumber">Set for page blobs only. The sequence number is a user-controlled value that you can use to track requests. The value of the sequence number must be between 0 and 2^63 - 1.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.PageBlob_UpdateSequenceNumber Request.</returns>
            internal static Azure.Core.Http.Request PageBlobUpdateSequenceNumberAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String xMSSequenceNumberAction,
                Integer? xMSBlobSequenceNumber = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-sequence-number-action", xMSSequenceNumberAction);
                if (xMSBlobSequenceNumber != null) { _request.Headers.SetValue("x-ms-blob-sequence-number", UNKNOWN ENUM TYPE NAME); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_UpdateSequenceNumber response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.PageBlob_UpdateSequenceNumber Azure.Response.</returns>
            internal static Azure.Response PageBlobUpdateSequenceNumberAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion PageBlob.PageBlob_UpdateSequenceNumber

            #region Service.Service_SubmitBatch
            /// <summary>
            /// The Batch operation allows multiple API calls to be embedded into a single HTTP request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="contentType">Required. The value of this header must be multipart/mixed with a batch boundary. Example header value: multipart/mixed; boundary=batch_<GUID></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<String>> ServiceSubmitBatchAsync(
                Object pipeline,
                String? url = default,
                string comp,
                Integer contentLength,
                String contentType,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ServiceClient.Service_SubmitBatch",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ServiceSubmitBatchAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        contentLength,
                        contentType,
                        timeout,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ServiceSubmitBatchAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Service.Service_SubmitBatch request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="contentType">Required. The value of this header must be multipart/mixed with a batch boundary. Example header value: multipart/mixed; boundary=batch_<GUID></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.Service_SubmitBatch Request.</returns>
            internal static Azure.Core.Http.Request ServiceSubmitBatchAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                Integer contentLength,
                String contentType,
                Integer? timeout = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Post;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "batch");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("Content-Length", UNKNOWN ENUM TYPE NAME);
                _request.Headers.SetValue("Content-Type", contentType);
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                // Create the body
                System.Xml.Linq.XElement _body = null;
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Service.Service_SubmitBatch response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.Service_SubmitBatch Azure.Response{String}.</returns>
            internal static Azure.Response<String> ServiceSubmitBatchAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        // TODO: Deserialize unexpected type

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("RequestId", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("Version", out _header))
                        {
                            _value.Version = _header;
                        }

                        // Create the response
                        Azure.Response<String> _result =
                            new Azure.Response<String>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Service.Service_SubmitBatch

            #region PageBlob.PageBlob_CopyIncremental
            /// <summary>
            /// The Copy Incremental operation copies a snapshot of the source page blob to a destination page blob. The snapshot is copied such that only the differential changes between the previously copied snapshot are transferred to the destination. The copied snapshots are complete copies of the original snapshot and can be read or copied from as usual. This API is supported since REST version 2016-05-31.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSCopySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The blob was copied.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> PageBlobCopyIncrementalAsync(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String xMSCopySource,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.PageBlobClient.PageBlob_CopyIncremental",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = PageBlobCopyIncrementalAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        timeout,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSCopySource,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return PageBlobCopyIncrementalAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_CopyIncremental request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSCopySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.PageBlob_CopyIncremental Request.</returns>
            internal static Azure.Core.Http.Request PageBlobCopyIncrementalAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String xMSCopySource,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "incrementalcopy");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-copy-source", xMSCopySource);
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.PageBlob_CopyIncremental response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.PageBlob_CopyIncremental Azure.Response.</returns>
            internal static Azure.Response PageBlobCopyIncrementalAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion PageBlob.PageBlob_CopyIncremental

            #region AppendBlob.AppendBlob_AppendBlock
            /// <summary>
            /// The Append Block operation commits a new block of data to the end of an existing append blob. The Append Block operation is permitted only if the blob was created with x-ms-blob-type set to AppendBlob. Append Block is supported only on version 2015-02-21 version or later.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="contentMD5">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="xMSContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobConditionMaxsize">Optional conditional header. The max length in bytes permitted for the append blob. If the Append Block operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified in this header, the request will fail with MaxBlobSizeConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="xMSBlobConditionAppendpos">Optional conditional header, used only for the Append Block operation. A number indicating the byte offset to compare. Append Block will succeed only if the append position is equal to this number. If it is not, the request will fail with the AppendPositionConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The block was created.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> AppendBlobAppendBlockAsync(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                Integer contentLength,
                String? contentMD5 = default,
                String? xMSContentCrc64 = default,
                String? xMSLeaseID = default,
                Integer? xMSBlobConditionMaxsize = default,
                Integer? xMSBlobConditionAppendpos = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.AppendBlobClient.AppendBlob_AppendBlock",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AppendBlobAppendBlockAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        timeout,
                        contentLength,
                        contentMD5,
                        xMSContentCrc64,
                        xMSLeaseID,
                        xMSBlobConditionMaxsize,
                        xMSBlobConditionAppendpos,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AppendBlobAppendBlockAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the AppendBlob.AppendBlob_AppendBlock request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="contentMD5">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="xMSContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobConditionMaxsize">Optional conditional header. The max length in bytes permitted for the append blob. If the Append Block operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified in this header, the request will fail with MaxBlobSizeConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="xMSBlobConditionAppendpos">Optional conditional header, used only for the Append Block operation. A number indicating the byte offset to compare. Append Block will succeed only if the append position is equal to this number. If it is not, the request will fail with the AppendPositionConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The AppendBlob.AppendBlob_AppendBlock Request.</returns>
            internal static Azure.Core.Http.Request AppendBlobAppendBlockAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                Integer? timeout = default,
                Integer contentLength,
                String? contentMD5 = default,
                String? xMSContentCrc64 = default,
                String? xMSLeaseID = default,
                Integer? xMSBlobConditionMaxsize = default,
                Integer? xMSBlobConditionAppendpos = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "appendblock");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("Content-Length", UNKNOWN ENUM TYPE NAME);
                if (contentMD5 != null) { _request.Headers.SetValue("Content-MD5", contentMD5); }
                if (xMSContentCrc64 != null) { _request.Headers.SetValue("x-ms-content-crc64", xMSContentCrc64); }
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSBlobConditionMaxsize != null) { _request.Headers.SetValue("x-ms-blob-condition-maxsize", UNKNOWN ENUM TYPE NAME); }
                if (xMSBlobConditionAppendpos != null) { _request.Headers.SetValue("x-ms-blob-condition-appendpos", UNKNOWN ENUM TYPE NAME); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                // Create the body
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(body);

                return _request;
            }

            /// <summary>
            /// Create the AppendBlob.AppendBlob_AppendBlock response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The AppendBlob.AppendBlob_AppendBlock Azure.Response.</returns>
            internal static Azure.Response AppendBlobAppendBlockAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion AppendBlob.AppendBlob_AppendBlock

            #region AppendBlob.AppendBlob_AppendBlockFromUrl
            /// <summary>
            /// The Append Block operation commits a new block of data to the end of an existing append blob where the contents are read from a source url. The Append Block operation is permitted only if the blob was created with x-ms-blob-type set to AppendBlob. Append Block is supported only on version 2015-02-21 version or later.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSCopySource">Specify a URL to the copy source.</param>
            /// <param name="xMSSourceRange">Bytes of source data in the specified range.</param>
            /// <param name="xMSSourceContentMd5">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="xMSSourceContentCrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="contentMD5">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobConditionMaxsize">Optional conditional header. The max length in bytes permitted for the append blob. If the Append Block operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified in this header, the request will fail with MaxBlobSizeConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="xMSBlobConditionAppendpos">Optional conditional header, used only for the Append Block operation. A number indicating the byte offset to compare. Append Block will succeed only if the append position is equal to this number. If it is not, the request will fail with the AppendPositionConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The block was created.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> AppendBlobAppendBlockFromUrlAsync(
                Object pipeline,
                String? url = default,
                string comp,
                String xMSCopySource,
                String? xMSSourceRange = default,
                String? xMSSourceContentMd5 = default,
                String? xMSSourceContentCrc64 = default,
                Integer? timeout = default,
                Integer contentLength,
                String? contentMD5 = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? xMSLeaseID = default,
                Integer? xMSBlobConditionMaxsize = default,
                Integer? xMSBlobConditionAppendpos = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.AppendBlobClient.AppendBlob_AppendBlockFromUrl",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AppendBlobAppendBlockFromUrlAsync_CreateRequest(
                        pipeline,
                        url,
                        comp,
                        xMSCopySource,
                        xMSSourceRange,
                        xMSSourceContentMd5,
                        xMSSourceContentCrc64,
                        timeout,
                        contentLength,
                        contentMD5,
                        xMSEncryptionKey,
                        xMSEncryptionKeySha256,
                        xMSEncryptionAlgorithm,
                        xMSLeaseID,
                        xMSBlobConditionMaxsize,
                        xMSBlobConditionAppendpos,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        xMSSourceIFModifiedSince,
                        xMSSourceIFUnmodifiedSince,
                        xMSSourceIFMatch,
                        xMSSourceIFNoneMatch,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AppendBlobAppendBlockFromUrlAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the AppendBlob.AppendBlob_AppendBlockFromUrl request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="xMSCopySource">Specify a URL to the copy source.</param>
            /// <param name="xMSSourceRange">Bytes of source data in the specified range.</param>
            /// <param name="xMSSourceContentMd5">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="xMSSourceContentCrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="contentMD5">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="xMSEncryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="xMSEncryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSEncryptionAlgorithm">The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256". Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSBlobConditionMaxsize">Optional conditional header. The max length in bytes permitted for the append blob. If the Append Block operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified in this header, the request will fail with MaxBlobSizeConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="xMSBlobConditionAppendpos">Optional conditional header, used only for the Append Block operation. A number indicating the byte offset to compare. Append Block will succeed only if the append position is equal to this number. If it is not, the request will fail with the AppendPositionConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSSourceIFModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSSourceIFMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="xMSSourceIFNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The AppendBlob.AppendBlob_AppendBlockFromUrl Request.</returns>
            internal static Azure.Core.Http.Request AppendBlobAppendBlockFromUrlAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string comp,
                String xMSCopySource,
                String? xMSSourceRange = default,
                String? xMSSourceContentMd5 = default,
                String? xMSSourceContentCrc64 = default,
                Integer? timeout = default,
                Integer contentLength,
                String? contentMD5 = default,
                String? xMSEncryptionKey = default,
                String? xMSEncryptionKeySha256 = default,
                string xMSEncryptionAlgorithm = default,
                String? xMSLeaseID = default,
                Integer? xMSBlobConditionMaxsize = default,
                Integer? xMSBlobConditionAppendpos = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                String? ifMatch = default,
                String? ifNoneMatch = default,
                String? xMSSourceIFModifiedSince = default,
                String? xMSSourceIFUnmodifiedSince = default,
                String? xMSSourceIFMatch = default,
                String? xMSSourceIFNoneMatch = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (comp == null)
                {
                    throw new System.ArgumentNullException(nameof(comp));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "appendblock");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-copy-source", xMSCopySource);
                if (xMSSourceRange != null) { _request.Headers.SetValue("x-ms-source-range", xMSSourceRange); }
                if (xMSSourceContentMd5 != null) { _request.Headers.SetValue("x-ms-source-content-md5", xMSSourceContentMd5); }
                if (xMSSourceContentCrc64 != null) { _request.Headers.SetValue("x-ms-source-content-crc64", xMSSourceContentCrc64); }
                _request.Headers.SetValue("Content-Length", UNKNOWN ENUM TYPE NAME);
                if (contentMD5 != null) { _request.Headers.SetValue("Content-MD5", contentMD5); }
                if (xMSEncryptionKey != null) { _request.Headers.SetValue("x-ms-encryption-key", xMSEncryptionKey); }
                if (xMSEncryptionKeySha256 != null) { _request.Headers.SetValue("x-ms-encryption-key-sha256", xMSEncryptionKeySha256); }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (xMSBlobConditionMaxsize != null) { _request.Headers.SetValue("x-ms-blob-condition-maxsize", UNKNOWN ENUM TYPE NAME); }
                if (xMSBlobConditionAppendpos != null) { _request.Headers.SetValue("x-ms-blob-condition-appendpos", UNKNOWN ENUM TYPE NAME); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch); }
                if (xMSSourceIFModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", xMSSourceIFModifiedSince); }
                if (xMSSourceIFUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", xMSSourceIFUnmodifiedSince); }
                if (xMSSourceIFMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", xMSSourceIFMatch); }
                if (xMSSourceIFNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", xMSSourceIFNoneMatch); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the AppendBlob.AppendBlob_AppendBlockFromUrl response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The AppendBlob.AppendBlob_AppendBlockFromUrl Azure.Response.</returns>
            internal static Azure.Response AppendBlobAppendBlockFromUrlAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion AppendBlob.AppendBlob_AppendBlockFromUrl

            #region Container.Container_Create
            /// <summary>
            /// creates a new container under the specified account. If the container with the same name already exists, the operation fails
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSBlobPublicAccess">Specifies whether data in the container may be accessed publicly and the level of access</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success, Container created.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ContainerCreateAsync(
                Object pipeline,
                String? url = default,
                string restype,
                Integer? timeout = default,
                String? xMSMeta = default,
                String? xMSBlobPublicAccess = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerCreateAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        timeout,
                        xMSMeta,
                        xMSBlobPublicAccess,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerCreateAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_Create request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSMeta">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="xMSBlobPublicAccess">Specifies whether data in the container may be accessed publicly and the level of access</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_Create Request.</returns>
            internal static Azure.Core.Http.Request ContainerCreateAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                Integer? timeout = default,
                String? xMSMeta = default,
                String? xMSBlobPublicAccess = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSMeta != null) { _request.Headers.SetValue("x-ms-meta", xMSMeta); }
                if (xMSBlobPublicAccess != null) { _request.Headers.SetValue("x-ms-blob-public-access", xMSBlobPublicAccess); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_Create response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_Create Azure.Response.</returns>
            internal static Azure.Response ContainerCreateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_Create

            #region Container.Container_GetProperties
            /// <summary>
            /// returns all user-defined metadata and system properties for the specified container. The data returned does not include the container's list of blobs
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ContainerGetPropertiesAsync(
                Object pipeline,
                String? url = default,
                string restype,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_GetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerGetPropertiesAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        timeout,
                        xMSLeaseID,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerGetPropertiesAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_GetProperties request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_GetProperties Request.</returns>
            internal static Azure.Core.Http.Request ContainerGetPropertiesAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_GetProperties response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_GetProperties Azure.Response.</returns>
            internal static Azure.Response ContainerGetPropertiesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_GetProperties

            #region Container.Container_Delete
            /// <summary>
            /// operation marks the specified container for deletion. The container and any blobs contained within it are later deleted during garbage collection
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Accepted</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ContainerDeleteAsync(
                Object pipeline,
                String? url = default,
                string restype,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default,
                string operationName = "DefaultNS.AzureBlobStorage.ContainerClient.Container_Delete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ContainerDeleteAsync_CreateRequest(
                        pipeline,
                        url,
                        restype,
                        timeout,
                        xMSLeaseID,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        xMSVersion,
                        xMSClientRequestID))
                    {
                        Azure.Response _response = await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ContainerDeleteAsync_CreateResponse(_response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Container.Container_Delete request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">pipeline</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseID">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="xMSVersion">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSClientRequestID">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.Container_Delete Request.</returns>
            internal static Azure.Core.Http.Request ContainerDeleteAsync_CreateRequest(
                Object pipeline,
                String? url = default,
                string restype,
                Integer? timeout = default,
                String? xMSLeaseID = default,
                String? ifModifiedSince = default,
                String? ifUnmodifiedSince = default,
                string xMSVersion,
                String? xMSClientRequestID = default)
            {
                // Validation
                if (pipeline == null)
                {
                    throw new System.ArgumentNullException(nameof(pipeline));
                }
                if (restype == null)
                {
                    throw new System.ArgumentNullException(nameof(restype));
                }
                if (xMSVersion == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSVersion));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Delete;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(UNKNOWN ENUM TYPE NAME)); }

                // Add request headers
                if (xMSLeaseID != null) { _request.Headers.SetValue("x-ms-lease-id", xMSLeaseID); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) { _request.Headers.SetValue("x-ms-client-request-id", xMSClientRequestID); }

                return _request;
            }

            /// <summary>
            /// Create the Container.Container_Delete response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.Container_Delete Azure.Response.</returns>
            internal static Azure.Response ContainerDeleteAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Object _value = Object.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw new Azure.RequestFailedException(response);
                    }
                }
            }
            #endregion Container.Container_Delete
        }
        #endregion service operations operations
    }
}
#endregion Service

#region Models
#endregion Models

