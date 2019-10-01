// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

// This file was automatically generated.  Do not edit.

#region Service
namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Azure Blob Storage
    /// </summary>
    internal static partial class BlobRestClient
    {
        #region Service operations
        /// <summary>
        /// Service operations for Azure Blob Storage
        /// </summary>
        public static partial class Service
        {
            #region Service.SetPropertiesAsync
            /// <summary>
            /// Sets properties for a storage account's Blob service endpoint, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success (Accepted)</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetPropertiesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.SetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetPropertiesAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetPropertiesAsync_CreateResponse(_response);
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
            /// Create the Service.SetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.SetPropertiesAsync Request.</returns>
            internal static Azure.Core.Http.Request SetPropertiesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "service");
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                // Create the body
                System.Xml.Linq.XElement _body = BlobServiceProperties.ToXml(blobServiceProperties, "StorageServiceProperties", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Service.SetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.SetPropertiesAsync Azure.Response.</returns>
            internal static Azure.Response SetPropertiesAsync_CreateResponse(
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
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.SetPropertiesAsync

            #region Service.GetPropertiesAsync
            /// <summary>
            /// gets the properties of a storage account's Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<BlobServiceProperties>> GetPropertiesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.GetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetPropertiesAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetPropertiesAsync_CreateResponse(_response);
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
            /// Create the Service.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.GetPropertiesAsync Request.</returns>
            internal static Azure.Core.Http.Request GetPropertiesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "service");
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Service.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.GetPropertiesAsync Azure.Response{BlobServiceProperties}.</returns>
            internal static Azure.Response<BlobServiceProperties> GetPropertiesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        BlobServiceProperties _value = BlobServiceProperties.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<BlobServiceProperties> _result =
                            new Azure.Response<BlobServiceProperties>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.GetPropertiesAsync

            #region Service.GetStatisticsAsync
            /// <summary>
            /// Retrieves statistics related to replication for the Blob service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the storage account.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<BlobServiceStatistics>> GetStatisticsAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.GetStatistics",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetStatisticsAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetStatisticsAsync_CreateResponse(_response);
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
            /// Create the Service.GetStatisticsAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.GetStatisticsAsync Request.</returns>
            internal static Azure.Core.Http.Request GetStatisticsAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "service");
                _request.UriBuilder.AppendQuery("comp", "stats");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Service.GetStatisticsAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.GetStatisticsAsync Azure.Response{BlobServiceStatistics}.</returns>
            internal static Azure.Response<BlobServiceStatistics> GetStatisticsAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        BlobServiceStatistics _value = BlobServiceStatistics.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<BlobServiceStatistics> _result =
                            new Azure.Response<BlobServiceStatistics>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.GetStatisticsAsync

            #region Service.ListContainersSegmentAsync
            /// <summary>
            /// The List Containers Segment operation returns a list of the containers under the specified account
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<ContainersSegment>> ListContainersSegmentAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.ListContainersSegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ListContainersSegmentAsync_CreateRequest(
                        pipeline,
                        url,
                        prefix,
                        marker,
                        maxresults,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ListContainersSegmentAsync_CreateResponse(_response);
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
            /// Create the Service.ListContainersSegmentAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.ListContainersSegmentAsync Request.</returns>
            internal static Azure.Core.Http.Request ListContainersSegmentAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                int? timeout = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "list");
                if (prefix != null) { _request.UriBuilder.AppendQuery("prefix", System.Uri.EscapeDataString(prefix)); }
                if (marker != null) { _request.UriBuilder.AppendQuery("marker", System.Uri.EscapeDataString(marker)); }
                if (maxresults != null) { _request.UriBuilder.AppendQuery("maxresults", System.Uri.EscapeDataString(int)); }
                _request.UriBuilder.AppendQuery("include", "metadata");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Service.ListContainersSegmentAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.ListContainersSegmentAsync Azure.Response{ContainersSegment}.</returns>
            internal static Azure.Response<ContainersSegment> ListContainersSegmentAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        ContainersSegment _value = ContainersSegment.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<ContainersSegment> _result =
                            new Azure.Response<ContainersSegment>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.ListContainersSegmentAsync

            #region Service.GetUserDelegationKeyAsync
            /// <summary>
            /// Retrieves a user delegation key for the Blob service. This is only a valid operation when using bearer token authentication.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<UserDelegationKey>> GetUserDelegationKeyAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.GetUserDelegationKey",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetUserDelegationKeyAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetUserDelegationKeyAsync_CreateResponse(_response);
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
            /// Create the Service.GetUserDelegationKeyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.GetUserDelegationKeyAsync Request.</returns>
            internal static Azure.Core.Http.Request GetUserDelegationKeyAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Post;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "service");
                _request.UriBuilder.AppendQuery("comp", "userdelegationkey");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                // Create the body
                System.Xml.Linq.XElement _body = KeyInfo.ToXml(keyInfo, "keyInfo", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Service.GetUserDelegationKeyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.GetUserDelegationKeyAsync Azure.Response{UserDelegationKey}.</returns>
            internal static Azure.Response<UserDelegationKey> GetUserDelegationKeyAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        UserDelegationKey _value = UserDelegationKey.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<UserDelegationKey> _result =
                            new Azure.Response<UserDelegationKey>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.GetUserDelegationKeyAsync

            #region Service.GetAccountInfoAsync
            /// <summary>
            /// Returns the sku name and account kind
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success (OK)</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> GetAccountInfoAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.GetAccountInfo",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetAccountInfoAsync_CreateRequest(
                        pipeline,
                        url))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetAccountInfoAsync_CreateResponse(_response);
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
            /// Create the Service.GetAccountInfoAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <returns>The Service.GetAccountInfoAsync Request.</returns>
            internal static Azure.Core.Http.Request GetAccountInfoAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default)
            {
                // Validation

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
            /// Create the Service.GetAccountInfoAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.GetAccountInfoAsync Azure.Response.</returns>
            internal static Azure.Response GetAccountInfoAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        AccountInfo _value = new AccountInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("SkuName", out _header))
                        {
                            _value.SkuName = _header;
                        }
                        if (response.Headers.TryGetValue("AccountKind", out _header))
                        {
                            _value.AccountKind = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.GetAccountInfoAsync

            #region Service.SubmitBatchAsync
            /// <summary>
            /// The Batch operation allows multiple API calls to be embedded into a single HTTP request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="multipartContentType">Required. The value of this header must be multipart/mixed with a batch boundary. Example header value: multipart/mixed; boundary=batch_{GUID}</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<string>> SubmitBatchAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                long contentLength,
                string multipartContentType,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.SubmitBatch",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SubmitBatchAsync_CreateRequest(
                        pipeline,
                        url,
                        contentLength,
                        multipartContentType,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SubmitBatchAsync_CreateResponse(_response);
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
            /// Create the Service.SubmitBatchAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="multipartContentType">Required. The value of this header must be multipart/mixed with a batch boundary. Example header value: multipart/mixed; boundary=batch_{GUID}</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.SubmitBatchAsync Request.</returns>
            internal static Azure.Core.Http.Request SubmitBatchAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                long contentLength,
                string multipartContentType,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (contentType == null)
                {
                    throw new System.ArgumentNullException(nameof(contentType));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Post;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "batch");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers

                    foreach (string _item in contentLength)
                    {
                        _request.Headers.SetValue("Content-Length", _item);
                    }


                    foreach (string _item in multipartContentType)
                    {
                        _request.Headers.SetValue("Content-Type", _item);
                    }

                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                // Create the body
                System.Xml.Linq.XElement _body = null;
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Service.SubmitBatchAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.SubmitBatchAsync Azure.Response{string}.</returns>
            internal static Azure.Response<string> SubmitBatchAsync_CreateResponse(
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

                        // Create the response
                        Azure.Response<string> _result =
                            new Azure.Response<string>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.SubmitBatchAsync
        }
        #endregion Service operations

        #region Container operations
        /// <summary>
        /// Container operations for Azure Blob Storage
        /// </summary>
        public static partial class Container
        {
            #region Container.SetMetadataAsync
            /// <summary>
            /// operation sets one or more user-defined name-value pairs for the specified container.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetMetadataAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                string metadata = default,
                System.DateTimeOffset ifModifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.SetMetadata",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetMetadataAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        metadata,
                        ifModifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetMetadataAsync_CreateResponse(_response);
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
            /// Create the Container.SetMetadataAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.SetMetadataAsync Request.</returns>
            internal static Azure.Core.Http.Request SetMetadataAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                string metadata = default,
                System.DateTimeOffset ifModifiedSince = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "metadata");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSMeta != null) {
                    foreach (string _item in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Container.SetMetadataAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.SetMetadataAsync Azure.Response.</returns>
            internal static Azure.Response SetMetadataAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        ContainerInfo _value = new ContainerInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.SetMetadataAsync

            #region Container.GetAccessPolicyAsync
            /// <summary>
            /// gets the permissions for the specified container. The permissions indicate whether container data may be accessed publicly.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<SignedIdentifier>>> GetAccessPolicyAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.GetAccessPolicy",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetAccessPolicyAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetAccessPolicyAsync_CreateResponse(_response);
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
            /// Create the Container.GetAccessPolicyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.GetAccessPolicyAsync Request.</returns>
            internal static Azure.Core.Http.Request GetAccessPolicyAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "acl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Container.GetAccessPolicyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.GetAccessPolicyAsync Azure.Response{System.Collections.Generic.IEnumerable{SignedIdentifier}}.</returns>
            internal static Azure.Response<System.Collections.Generic.IEnumerable<SignedIdentifier>> GetAccessPolicyAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        System.Collections.Generic.IEnumerable<SignedIdentifier> _value =
                            System.Linq.Enumerable.ToList(
                                System.Linq.Enumerable.Select(
                                    _xml.Elements(System.Xml.Linq.XName.Get("SignedIdentifier", "")),
                                    SignedIdentifier.FromXml));

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

                        // Create the response
                        Azure.Response<System.Collections.Generic.IEnumerable<SignedIdentifier>> _result =
                            new Azure.Response<System.Collections.Generic.IEnumerable<SignedIdentifier>>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.GetAccessPolicyAsync

            #region Container.SetAccessPolicyAsync
            /// <summary>
            /// sets the permissions for the specified container. The permissions indicate whether blobs in a container may be accessed publicly.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetAccessPolicyAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.SetAccessPolicy",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetAccessPolicyAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetAccessPolicyAsync_CreateResponse(_response);
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
            /// Create the Container.SetAccessPolicyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.SetAccessPolicyAsync Request.</returns>
            internal static Azure.Core.Http.Request SetAccessPolicyAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "acl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-blob-public-access", xMSBlobPublicAccess);
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                // Create the body
                System.Xml.Linq.XElement _body = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get("SignedIdentifier", ""));
                if (permissions != null)
                {
                    foreach (SignedIdentifier _child in permissions)
                    {
                        _body.Add(SignedIdentifier.ToXml(_child));
                    }
                }
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Container.SetAccessPolicyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.SetAccessPolicyAsync Azure.Response.</returns>
            internal static Azure.Response SetAccessPolicyAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        ContainerInfo _value = new ContainerInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.SetAccessPolicyAsync

            #region Container.AcquireLeaseAsync
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="duration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The lease operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> AcquireLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                long? duration = default,
                string proposedLeaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.AcquireLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AcquireLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        duration,
                        proposedLeaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AcquireLeaseAsync_CreateResponse(_response);
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
            /// Create the Container.AcquireLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="duration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.AcquireLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request AcquireLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                long? duration = default,
                string proposedLeaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "acquire");
                if (xMSLeaseDuration != null) {
                    foreach (string _item in duration)
                    {
                        _request.Headers.SetValue("x-ms-lease-duration", _item);
                    }
                }
                if (xMSProposedLeaseID != null) {
                    foreach (string _item in proposedLeaseId)
                    {
                        _request.Headers.SetValue("x-ms-proposed-lease-id", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Container.AcquireLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.AcquireLeaseAsync Azure.Response.</returns>
            internal static Azure.Response AcquireLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Lease _value = new Lease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseId", out _header))
                        {
                            _value.LeaseId = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.AcquireLeaseAsync

            #region Container.ReleaseLeaseAsync
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ReleaseLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.ReleaseLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ReleaseLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ReleaseLeaseAsync_CreateResponse(_response);
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
            /// Create the Container.ReleaseLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.ReleaseLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request ReleaseLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation
                if (xMSLeaseID == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseID));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "release");

                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }

                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Container.ReleaseLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.ReleaseLeaseAsync Azure.Response.</returns>
            internal static Azure.Response ReleaseLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        ContainerInfo _value = new ContainerInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.ReleaseLeaseAsync

            #region Container.RenewLeaseAsync
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The lease operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> RenewLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.RenewLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = RenewLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return RenewLeaseAsync_CreateResponse(_response);
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
            /// Create the Container.RenewLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.RenewLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request RenewLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation
                if (xMSLeaseID == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseID));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "renew");

                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }

                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Container.RenewLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.RenewLeaseAsync Azure.Response.</returns>
            internal static Azure.Response RenewLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Lease _value = new Lease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseId", out _header))
                        {
                            _value.LeaseId = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.RenewLeaseAsync

            #region Container.BreakLeaseAsync
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="breakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Break operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BreakLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                int? breakPeriod = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.BreakLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BreakLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        breakPeriod,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BreakLeaseAsync_CreateResponse(_response);
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
            /// Create the Container.BreakLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="breakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.BreakLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request BreakLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                int? breakPeriod = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "break");
                if (xMSLeaseBreakPeriod != null) {
                    foreach (string _item in breakPeriod)
                    {
                        _request.Headers.SetValue("x-ms-lease-break-period", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Container.BreakLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.BreakLeaseAsync Azure.Response.</returns>
            internal static Azure.Response BreakLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        BrokenLease _value = new BrokenLease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseTime", out _header))
                        {
                            _value.LeaseTime = int;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.BreakLeaseAsync

            #region Container.ChangeLeaseAsync
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The lease operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ChangeLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId,
                string proposedLeaseId,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.ChangeLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ChangeLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        proposedLeaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ChangeLeaseAsync_CreateResponse(_response);
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
            /// Create the Container.ChangeLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.ChangeLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request ChangeLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId,
                string proposedLeaseId,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation
                if (xMSLeaseID == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseID));
                }
                if (xMSProposedLeaseID == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSProposedLeaseID));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "change");

                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }


                    foreach (string _item in proposedLeaseId)
                    {
                        _request.Headers.SetValue("x-ms-proposed-lease-id", _item);
                    }

                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Container.ChangeLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.ChangeLeaseAsync Azure.Response.</returns>
            internal static Azure.Response ChangeLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Lease _value = new Lease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseId", out _header))
                        {
                            _value.LeaseId = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.ChangeLeaseAsync

            #region Container.ListBlobsFlatSegmentAsync
            /// <summary>
            /// [Update] The List Blobs operation returns a list of the blobs under the specified container
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<BlobsFlatSegment>> ListBlobsFlatSegmentAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<[object Object]> include = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.ListBlobsFlatSegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ListBlobsFlatSegmentAsync_CreateRequest(
                        pipeline,
                        url,
                        prefix,
                        marker,
                        maxresults,
                        include,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ListBlobsFlatSegmentAsync_CreateResponse(_response);
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
            /// Create the Container.ListBlobsFlatSegmentAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.ListBlobsFlatSegmentAsync Request.</returns>
            internal static Azure.Core.Http.Request ListBlobsFlatSegmentAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<[object Object]> include = default,
                int? timeout = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "list");
                if (prefix != null) { _request.UriBuilder.AppendQuery("prefix", System.Uri.EscapeDataString(prefix)); }
                if (marker != null) { _request.UriBuilder.AppendQuery("marker", System.Uri.EscapeDataString(marker)); }
                if (maxresults != null) { _request.UriBuilder.AppendQuery("maxresults", System.Uri.EscapeDataString(int)); }
                if (include != null) { _request.UriBuilder.AppendQuery("include", System.Uri.EscapeDataString(System.Collections.Generic.IEnumerable<[object Object]>)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Container.ListBlobsFlatSegmentAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.ListBlobsFlatSegmentAsync Azure.Response{BlobsFlatSegment}.</returns>
            internal static Azure.Response<BlobsFlatSegment> ListBlobsFlatSegmentAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        BlobsFlatSegment _value = BlobsFlatSegment.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<BlobsFlatSegment> _result =
                            new Azure.Response<BlobsFlatSegment>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.ListBlobsFlatSegmentAsync

            #region Container.ListBlobsHierarchySegmentAsync
            /// <summary>
            /// [Update] The List Blobs operation returns a list of the blobs under the specified container
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="delimiter">When the request includes this parameter, the operation returns a BlobPrefix element in the response body that acts as a placeholder for all blobs whose names begin with the same substring up to the appearance of the delimiter character. The delimiter may be a single character or a string.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<BlobsHierarchySegment>> ListBlobsHierarchySegmentAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string prefix = default,
                string delimiter = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<[object Object]> include = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.ListBlobsHierarchySegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ListBlobsHierarchySegmentAsync_CreateRequest(
                        pipeline,
                        url,
                        prefix,
                        delimiter,
                        marker,
                        maxresults,
                        include,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ListBlobsHierarchySegmentAsync_CreateResponse(_response);
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
            /// Create the Container.ListBlobsHierarchySegmentAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="delimiter">When the request includes this parameter, the operation returns a BlobPrefix element in the response body that acts as a placeholder for all blobs whose names begin with the same substring up to the appearance of the delimiter character. The delimiter may be a single character or a string.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.ListBlobsHierarchySegmentAsync Request.</returns>
            internal static Azure.Core.Http.Request ListBlobsHierarchySegmentAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string prefix = default,
                string delimiter = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<[object Object]> include = default,
                int? timeout = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "list");
                if (prefix != null) { _request.UriBuilder.AppendQuery("prefix", System.Uri.EscapeDataString(prefix)); }
                if (delimiter != null) { _request.UriBuilder.AppendQuery("delimiter", System.Uri.EscapeDataString(delimiter)); }
                if (marker != null) { _request.UriBuilder.AppendQuery("marker", System.Uri.EscapeDataString(marker)); }
                if (maxresults != null) { _request.UriBuilder.AppendQuery("maxresults", System.Uri.EscapeDataString(int)); }
                if (include != null) { _request.UriBuilder.AppendQuery("include", System.Uri.EscapeDataString(System.Collections.Generic.IEnumerable<[object Object]>)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Container.ListBlobsHierarchySegmentAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.ListBlobsHierarchySegmentAsync Azure.Response{BlobsHierarchySegment}.</returns>
            internal static Azure.Response<BlobsHierarchySegment> ListBlobsHierarchySegmentAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        BlobsHierarchySegment _value = BlobsHierarchySegment.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<BlobsHierarchySegment> _result =
                            new Azure.Response<BlobsHierarchySegment>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.ListBlobsHierarchySegmentAsync

            #region Container.CreateAsync
            /// <summary>
            /// creates a new container under the specified account. If the container with the same name already exists, the operation fails
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success, Container created.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> CreateAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string metadata = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CreateAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        metadata,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CreateAsync_CreateResponse(_response);
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
            /// Create the Container.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.CreateAsync Request.</returns>
            internal static Azure.Core.Http.Request CreateAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string metadata = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSMeta != null) {
                    foreach (string _item in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-blob-public-access", xMSBlobPublicAccess);
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Container.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.CreateAsync Azure.Response.</returns>
            internal static Azure.Response CreateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        ContainerInfo _value = new ContainerInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.CreateAsync

            #region Container.GetPropertiesAsync
            /// <summary>
            /// returns all user-defined metadata and system properties for the specified container. The data returned does not include the container's list of blobs
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Success</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.GetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetPropertiesAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetPropertiesAsync_CreateResponse(_response);
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
            /// Create the Container.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.GetPropertiesAsync Request.</returns>
            internal static Azure.Core.Http.Request GetPropertiesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Container.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.GetPropertiesAsync Azure.Response.</returns>
            internal static Azure.Response GetPropertiesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        FlattenedContainerItem _value = new FlattenedContainerItem();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Metadata", out _header))
                        {
                            _value.Metadata = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
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
                        if (response.Headers.TryGetValue("BlobPublicAccess", out _header))
                        {
                            _value.BlobPublicAccess = _header;
                        }
                        if (response.Headers.TryGetValue("HasImmutabilityPolicy", out _header))
                        {
                            _value.HasImmutabilityPolicy = bool;
                        }
                        if (response.Headers.TryGetValue("HasLegalHold", out _header))
                        {
                            _value.HasLegalHold = bool;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.GetPropertiesAsync

            #region Container.DeleteAsync
            /// <summary>
            /// operation marks the specified container for deletion. The container and any blobs contained within it are later deleted during garbage collection
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Accepted</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.Delete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DeleteAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return DeleteAsync_CreateResponse(_response);
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
            /// Create the Container.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.DeleteAsync Request.</returns>
            internal static Azure.Core.Http.Request DeleteAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Delete;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Container.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.DeleteAsync Azure.Response.</returns>
            internal static Azure.Response DeleteAsync_CreateResponse(
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
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.DeleteAsync
        }
        #endregion Container operations

        #region Blob operations
        /// <summary>
        /// Blob operations for Azure Blob Storage
        /// </summary>
        public static partial class Blob
        {
            #region Blob.DownloadAsync
            /// <summary>
            /// The Download operation reads or downloads a blob from the system, including its metadata and properties. You can also call Download to read a snapshot.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="rangeGetContentHash">When set to true and specified together with the Range, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size.</param>
            /// <param name="rangeGetContentCRC64">When set to true and specified together with the Range, the service returns the CRC64 hash for the range, as long as the range is less than or equal to 4 MB in size.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Returns the content of the entire blob.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<string>> DownloadAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string snapshot = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                bool? rangeGetContentHash = default,
                bool? rangeGetContentCRC64 = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.Download",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DownloadAsync_CreateRequest(
                        pipeline,
                        url,
                        snapshot,
                        timeout,
                        range,
                        leaseId,
                        rangeGetContentHash,
                        rangeGetContentCRC64,
                        encryptionKey,
                        encryptionKeySha256,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return DownloadAsync_CreateResponse(_response);
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
            /// Create the Blob.DownloadAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="rangeGetContentHash">When set to true and specified together with the Range, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size.</param>
            /// <param name="rangeGetContentCRC64">When set to true and specified together with the Range, the service returns the CRC64 hash for the range, as long as the range is less than or equal to 4 MB in size.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.DownloadAsync Request.</returns>
            internal static Azure.Core.Http.Request DownloadAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string snapshot = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                bool? rangeGetContentHash = default,
                bool? rangeGetContentCRC64 = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSRange != null) {
                    foreach (string _item in range)
                    {
                        _request.Headers.SetValue("x-ms-range", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSRangeGetContentMd5 != null) {
                    foreach (string _item in rangeGetContentHash)
                    {
                        _request.Headers.SetValue("x-ms-range-get-content-md5", _item);
                    }
                }
                if (xMSRangeGetContentCrc64 != null) {
                    foreach (string _item in rangeGetContentCRC64)
                    {
                        _request.Headers.SetValue("x-ms-range-get-content-crc64", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.DownloadAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.DownloadAsync Azure.Response{string}.</returns>
            internal static Azure.Response<string> DownloadAsync_CreateResponse(
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
                            _value.ContentLength = long;
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
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
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
                            _value.BlobSequenceNumber = long;
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
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("BlobCommittedBlockCount", out _header))
                        {
                            _value.BlobCommittedBlockCount = int;
                        }
                        if (response.Headers.TryGetValue("IsServerEncrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobContentHash", out _header))
                        {
                            _value.BlobContentHash = _header;
                        }

                        // Create the response
                        Azure.Response<string> _result =
                            new Azure.Response<string>(
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
                            _value.ContentLength = long;
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
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
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
                            _value.BlobSequenceNumber = long;
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
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("BlobCommittedBlockCount", out _header))
                        {
                            _value.BlobCommittedBlockCount = int;
                        }
                        if (response.Headers.TryGetValue("IsServerEncrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobContentHash", out _header))
                        {
                            _value.BlobContentHash = _header;
                        }

                        // Create the response
                        Azure.Response<string> _result =
                            new Azure.Response<string>(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        ConditionNotMetError _value = new ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.DownloadAsync

            #region Blob.GetPropertiesAsync
            /// <summary>
            /// The Get Properties operation returns all user-defined metadata, standard HTTP properties, and system properties for the blob. It does not return the content of the blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Returns the properties of the blob.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.GetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetPropertiesAsync_CreateRequest(
                        pipeline,
                        url,
                        snapshot,
                        timeout,
                        leaseId,
                        encryptionKey,
                        encryptionKeySha256,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetPropertiesAsync_CreateResponse(_response);
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
            /// Create the Blob.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.GetPropertiesAsync Request.</returns>
            internal static Azure.Core.Http.Request GetPropertiesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Head;
                _request.UriBuilder.Uri = url;
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.GetPropertiesAsync Azure.Response.</returns>
            internal static Azure.Response GetPropertiesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        BlobProperties _value = new BlobProperties();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("CreationTime", out _header))
                        {
                            _value.CreationTime = _header;
                        }
                        if (response.Headers.TryGetValue("Metadata", out _header))
                        {
                            _value.Metadata = _header;
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
                        if (response.Headers.TryGetValue("IsIncrementalCopy", out _header))
                        {
                            _value.IsIncrementalCopy = bool;
                        }
                        if (response.Headers.TryGetValue("DestinationSnapshot", out _header))
                        {
                            _value.DestinationSnapshot = _header;
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
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long;
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = System.Collections.Generic.IEnumerable<string>;
                        }
                        if (response.Headers.TryGetValue("Content-Disposition", out _header))
                        {
                            _value.ContentDisposition = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Language", out _header))
                        {
                            _value.ContentLanguage = System.Collections.Generic.IEnumerable<string>;
                        }
                        if (response.Headers.TryGetValue("Cache-Control", out _header))
                        {
                            _value.CacheControl = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = long;
                        }
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("BlobCommittedBlockCount", out _header))
                        {
                            _value.BlobCommittedBlockCount = int;
                        }
                        if (response.Headers.TryGetValue("IsServerEncrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }
                        if (response.Headers.TryGetValue("AccessTier", out _header))
                        {
                            _value.AccessTier = _header;
                        }
                        if (response.Headers.TryGetValue("AccessTierInferred", out _header))
                        {
                            _value.AccessTierInferred = bool;
                        }
                        if (response.Headers.TryGetValue("ArchiveStatus", out _header))
                        {
                            _value.ArchiveStatus = _header;
                        }
                        if (response.Headers.TryGetValue("AccessTierChangeTime", out _header))
                        {
                            _value.AccessTierChangeTime = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        ConditionNotMetError _value = new ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        ConditionNotMetError _value = new ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.GetPropertiesAsync

            #region Blob.DeleteAsync
            /// <summary>
            /// If the storage account's soft delete feature is disabled then, when a blob is deleted, it is permanently removed from the storage account. If the storage account's soft delete feature is enabled, then, when a blob is deleted, it is marked for deletion and becomes inaccessible immediately. However, the blob service retains the blob or snapshot for the number of days specified by the DeleteRetentionPolicy section of [Storage service properties] (Set-Blob-Service-Properties.md). After the specified number of days has passed, the blob's data is permanently removed from the storage account. Note that you continue to be charged for the soft-deleted blob's storage until it is permanently removed. Use the List Blobs API and specify the "include=deleted" query parameter to discover which blobs and snapshots have been soft deleted. You can then use the Undelete Blob API to restore a soft-deleted blob. All other operations on a soft-deleted blob or snapshot causes the service to return an HTTP status code of 404 (ResourceNotFound).
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The delete request was accepted and the blob will be deleted.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.Delete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DeleteAsync_CreateRequest(
                        pipeline,
                        url,
                        snapshot,
                        timeout,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return DeleteAsync_CreateResponse(_response);
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
            /// Create the Blob.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.DeleteAsync Request.</returns>
            internal static Azure.Core.Http.Request DeleteAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Delete;
                _request.UriBuilder.Uri = url;
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSDeleteSnapshots != null) { _request.Headers.SetValue("x-ms-delete-snapshots", xMSDeleteSnapshots); }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.DeleteAsync Azure.Response.</returns>
            internal static Azure.Response DeleteAsync_CreateResponse(
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
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.DeleteAsync

            #region Blob.SetAccessControlAsync
            /// <summary>
            /// Set the owner, group, permissions, or access control list for a blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="owner">Optional. The owner of the blob or directory.</param>
            /// <param name="group">Optional. The owning group of the blob or directory.</param>
            /// <param name="posixPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="posixAcl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Set blob access control response.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetAccessControlAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                string owner = default,
                string group = default,
                string posixPermissions = default,
                string posixAcl = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.SetAccessControl",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetAccessControlAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        owner,
                        group,
                        posixPermissions,
                        posixAcl,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetAccessControlAsync_CreateResponse(_response);
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
            /// Create the Blob.SetAccessControlAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="owner">Optional. The owner of the blob or directory.</param>
            /// <param name="group">Optional. The owning group of the blob or directory.</param>
            /// <param name="posixPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="posixAcl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.SetAccessControlAsync Request.</returns>
            internal static Azure.Core.Http.Request SetAccessControlAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                string owner = default,
                string group = default,
                string posixPermissions = default,
                string posixAcl = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Patch;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("action", "setAccessControl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSOwner != null) {
                    foreach (string _item in owner)
                    {
                        _request.Headers.SetValue("x-ms-owner", _item);
                    }
                }
                if (xMSGroup != null) {
                    foreach (string _item in group)
                    {
                        _request.Headers.SetValue("x-ms-group", _item);
                    }
                }
                if (xMSPermissions != null) {
                    foreach (string _item in posixPermissions)
                    {
                        _request.Headers.SetValue("x-ms-permissions", _item);
                    }
                }
                if (xMSAcl != null) {
                    foreach (string _item in posixAcl)
                    {
                        _request.Headers.SetValue("x-ms-acl", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");

                return _request;
            }

            /// <summary>
            /// Create the Blob.SetAccessControlAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.SetAccessControlAsync Azure.Response.</returns>
            internal static Azure.Response SetAccessControlAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        NORESPONSENAME _value = new NORESPONSENAME();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        DataLakeStorageError _value = DataLakeStorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.SetAccessControlAsync

            #region Blob.GetAccessControlAsync
            /// <summary>
            /// Get the owner, group, permissions, or access control list for a blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="upn">Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true", the identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response headers will be transformed from Azure Active Directory Object IDs to User Principal Names.  If "false", the values will be returned as Azure Active Directory Object IDs. The default value is false.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Get blob access control response.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> GetAccessControlAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                bool? upn = default,
                string leaseId = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.GetAccessControl",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetAccessControlAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        upn,
                        leaseId,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetAccessControlAsync_CreateResponse(_response);
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
            /// Create the Blob.GetAccessControlAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="upn">Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true", the identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response headers will be transformed from Azure Active Directory Object IDs to User Principal Names.  If "false", the values will be returned as Azure Active Directory Object IDs. The default value is false.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.GetAccessControlAsync Request.</returns>
            internal static Azure.Core.Http.Request GetAccessControlAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                bool? upn = default,
                string leaseId = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Head;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("action", "getAccessControl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }
                if (upn != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.UriBuilder.AppendQuery("upn", System.Uri.EscapeDataString(bool));
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");

                return _request;
            }

            /// <summary>
            /// Create the Blob.GetAccessControlAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.GetAccessControlAsync Azure.Response.</returns>
            internal static Azure.Response GetAccessControlAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        NORESPONSENAME _value = new NORESPONSENAME();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-owner", out _header))
                        {
                            _value.XMSOwner = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-group", out _header))
                        {
                            _value.XMSGroup = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-permissions", out _header))
                        {
                            _value.XMSPermissions = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-acl", out _header))
                        {
                            _value.XMSAcl = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        DataLakeStorageError _value = DataLakeStorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.GetAccessControlAsync

            #region Blob.RenameAsync
            /// <summary>
            /// Rename a blob/file.  By default, the destination is overwritten and if the destination already exists and has a lease the lease is broken.  This operation supports conditional HTTP requests.  For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations).  To fail if the destination already exists, use a conditional request with If-None-Match: "*".
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="renameSource">The file or directory to be renamed. The value must have the following format: "/{filesysystem}/{path}".  If "x-ms-properties" is specified, the properties will overwrite the existing properties; otherwise, the existing properties will be preserved.</param>
            /// <param name="directoryProperties">Optional.  User-defined properties to be stored with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is base64 encoded.</param>
            /// <param name="posixPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="posixUmask">Only valid if Hierarchical Namespace is enabled for the account. This umask restricts permission settings for file and directory, and will only be applied when default Acl does not exist in parent directory. If the umask bit has set, it means that the corresponding permission will be disabled. Otherwise the corresponding permission will be determined by the permission. A 4-digit octal notation (e.g. 0022) is supported here. If no umask was specified, a default umask - 0027 will be used.</param>
            /// <param name="cacheControl">Cache control for given resource</param>
            /// <param name="contentType">Content type for given resource</param>
            /// <param name="contentEncoding">Content encoding for given resource</param>
            /// <param name="contentLanguage">Content language for given resource</param>
            /// <param name="contentDisposition">Content disposition for given resource</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="sourceLeaseId">A lease ID for the source path. If specified, the source path must have an active lease and the leaase ID must match.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The file was renamed.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> RenameAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string renameSource,
                string directoryProperties = default,
                string posixPermissions = default,
                string posixUmask = default,
                string cacheControl = default,
                string contentType = default,
                string contentEncoding = default,
                string contentLanguage = default,
                string contentDisposition = default,
                string leaseId = default,
                string sourceLeaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.Rename",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = RenameAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        renameSource,
                        directoryProperties,
                        posixPermissions,
                        posixUmask,
                        cacheControl,
                        contentType,
                        contentEncoding,
                        contentLanguage,
                        contentDisposition,
                        leaseId,
                        sourceLeaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return RenameAsync_CreateResponse(_response);
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
            /// Create the Blob.RenameAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="renameSource">The file or directory to be renamed. The value must have the following format: "/{filesysystem}/{path}".  If "x-ms-properties" is specified, the properties will overwrite the existing properties; otherwise, the existing properties will be preserved.</param>
            /// <param name="directoryProperties">Optional.  User-defined properties to be stored with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is base64 encoded.</param>
            /// <param name="posixPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="posixUmask">Only valid if Hierarchical Namespace is enabled for the account. This umask restricts permission settings for file and directory, and will only be applied when default Acl does not exist in parent directory. If the umask bit has set, it means that the corresponding permission will be disabled. Otherwise the corresponding permission will be determined by the permission. A 4-digit octal notation (e.g. 0022) is supported here. If no umask was specified, a default umask - 0027 will be used.</param>
            /// <param name="cacheControl">Cache control for given resource</param>
            /// <param name="contentType">Content type for given resource</param>
            /// <param name="contentEncoding">Content encoding for given resource</param>
            /// <param name="contentLanguage">Content language for given resource</param>
            /// <param name="contentDisposition">Content disposition for given resource</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="sourceLeaseId">A lease ID for the source path. If specified, the source path must have an active lease and the leaase ID must match.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.RenameAsync Request.</returns>
            internal static Azure.Core.Http.Request RenameAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string renameSource,
                string directoryProperties = default,
                string posixPermissions = default,
                string posixUmask = default,
                string cacheControl = default,
                string contentType = default,
                string contentEncoding = default,
                string contentLanguage = default,
                string contentDisposition = default,
                string leaseId = default,
                string sourceLeaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (xMSRenameSource == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSRenameSource));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }
                if (mode != null) { _request.UriBuilder.AppendQuery("mode", System.Uri.EscapeDataString(mode)); }

                // Add request headers

                    foreach (string _item in renameSource)
                    {
                        _request.Headers.SetValue("x-ms-rename-source", _item);
                    }

                if (xMSProperties != null) {
                    foreach (string _item in directoryProperties)
                    {
                        _request.Headers.SetValue("x-ms-properties", _item);
                    }
                }
                if (xMSPermissions != null) {
                    foreach (string _item in posixPermissions)
                    {
                        _request.Headers.SetValue("x-ms-permissions", _item);
                    }
                }
                if (xMSUmask != null) {
                    foreach (string _item in posixUmask)
                    {
                        _request.Headers.SetValue("x-ms-umask", _item);
                    }
                }
                if (xMSCacheControl != null) {
                    foreach (string _item in cacheControl)
                    {
                        _request.Headers.SetValue("x-ms-cache-control", _item);
                    }
                }
                if (xMSContentType != null) {
                    foreach (string _item in contentType)
                    {
                        _request.Headers.SetValue("x-ms-content-type", _item);
                    }
                }
                if (xMSContentEncoding != null) {
                    foreach (string _item in contentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-content-encoding", _item);
                    }
                }
                if (xMSContentLanguage != null) {
                    foreach (string _item in contentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-content-language", _item);
                    }
                }
                if (xMSContentDisposition != null) {
                    foreach (string _item in contentDisposition)
                    {
                        _request.Headers.SetValue("x-ms-content-disposition", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSSourceLeaseID != null) {
                    foreach (string _item in sourceLeaseId)
                    {
                        _request.Headers.SetValue("x-ms-source-lease-id", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                if (xMSSourceIFModifiedSince != null) {
                    foreach (string _item in sourceIfModifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-modified-since", _item);
                    }
                }
                if (xMSSourceIFUnmodifiedSince != null) {
                    foreach (string _item in sourceIfUnmodifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-unmodified-since", _item);
                    }
                }
                if (xMSSourceIFMatch != null) {
                    foreach (string _item in sourceIfMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-match", _item);
                    }
                }
                if (xMSSourceIFNoneMatch != null) {
                    foreach (string _item in sourceIfNoneMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-none-match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.RenameAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.RenameAsync Azure.Response.</returns>
            internal static Azure.Response RenameAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        NORESPONSENAME _value = new NORESPONSENAME();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        DataLakeStorageError _value = DataLakeStorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.RenameAsync

            #region Blob.UndeleteAsync
            /// <summary>
            /// Undelete a blob that was previously soft deleted
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The blob was undeleted successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> UndeleteAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.Undelete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = UndeleteAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return UndeleteAsync_CreateResponse(_response);
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
            /// Create the Blob.UndeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.UndeleteAsync Request.</returns>
            internal static Azure.Core.Http.Request UndeleteAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "undelete");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.UndeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.UndeleteAsync Azure.Response.</returns>
            internal static Azure.Response UndeleteAsync_CreateResponse(
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
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.UndeleteAsync

            #region Blob.SetHttpHeadersAsync
            /// <summary>
            /// The Set HTTP Headers operation sets system properties on the blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The properties were set successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetHttpHeadersAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string blobCacheControl = default,
                string blobContentType = default,
                byte[] blobContentHash = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string blobContentDisposition = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.SetHttpHeaders",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetHttpHeadersAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        blobCacheControl,
                        blobContentType,
                        blobContentHash,
                        blobContentEncoding,
                        blobContentLanguage,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        blobContentDisposition,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetHttpHeadersAsync_CreateResponse(_response);
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
            /// Create the Blob.SetHttpHeadersAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.SetHttpHeadersAsync Request.</returns>
            internal static Azure.Core.Http.Request SetHttpHeadersAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string blobCacheControl = default,
                string blobContentType = default,
                byte[] blobContentHash = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string blobContentDisposition = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSBlobCacheControl != null) {
                    foreach (string _item in blobCacheControl)
                    {
                        _request.Headers.SetValue("x-ms-blob-cache-control", _item);
                    }
                }
                if (xMSBlobContentType != null) {
                    foreach (string _item in blobContentType)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-type", _item);
                    }
                }
                if (xMSBlobContentMd5 != null) {
                    foreach (string _item in blobContentHash)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-md5", _item);
                    }
                }
                if (xMSBlobContentEncoding != null) {
                    foreach (string _item in blobContentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-encoding", _item);
                    }
                }
                if (xMSBlobContentLanguage != null) {
                    foreach (string _item in blobContentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-language", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                if (xMSBlobContentDisposition != null) {
                    foreach (string _item in blobContentDisposition)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-disposition", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.SetHttpHeadersAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.SetHttpHeadersAsync Azure.Response.</returns>
            internal static Azure.Response SetHttpHeadersAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        SetHttpHeadersOperation _value = new SetHttpHeadersOperation();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = long;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.SetHttpHeadersAsync

            #region Blob.SetMetadataAsync
            /// <summary>
            /// The Set Blob Metadata operation sets user-defined metadata for the specified blob as one or more name-value pairs
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The metadata was set successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetMetadataAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string metadata = default,
                string leaseId = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.SetMetadata",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetMetadataAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        metadata,
                        leaseId,
                        encryptionKey,
                        encryptionKeySha256,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetMetadataAsync_CreateResponse(_response);
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
            /// Create the Blob.SetMetadataAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.SetMetadataAsync Request.</returns>
            internal static Azure.Core.Http.Request SetMetadataAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string metadata = default,
                string leaseId = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "metadata");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSMeta != null) {
                    foreach (string _item in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.SetMetadataAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.SetMetadataAsync Azure.Response.</returns>
            internal static Azure.Response SetMetadataAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        SetMetadataOperation _value = new SetMetadataOperation();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("IsServerEncrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.SetMetadataAsync

            #region Blob.AcquireLeaseAsync
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="duration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The lease operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> AcquireLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                long? duration = default,
                string proposedLeaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.AcquireLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AcquireLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        duration,
                        proposedLeaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AcquireLeaseAsync_CreateResponse(_response);
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
            /// Create the Blob.AcquireLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="duration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.AcquireLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request AcquireLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                long? duration = default,
                string proposedLeaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "acquire");
                if (xMSLeaseDuration != null) {
                    foreach (string _item in duration)
                    {
                        _request.Headers.SetValue("x-ms-lease-duration", _item);
                    }
                }
                if (xMSProposedLeaseID != null) {
                    foreach (string _item in proposedLeaseId)
                    {
                        _request.Headers.SetValue("x-ms-proposed-lease-id", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.AcquireLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.AcquireLeaseAsync Azure.Response.</returns>
            internal static Azure.Response AcquireLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Lease _value = new Lease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseId", out _header))
                        {
                            _value.LeaseId = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.AcquireLeaseAsync

            #region Blob.ReleaseLeaseAsync
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ReleaseLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.ReleaseLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ReleaseLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ReleaseLeaseAsync_CreateResponse(_response);
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
            /// Create the Blob.ReleaseLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.ReleaseLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request ReleaseLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (xMSLeaseID == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseID));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "release");

                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }

                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.ReleaseLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.ReleaseLeaseAsync Azure.Response.</returns>
            internal static Azure.Response ReleaseLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        BlobInfo _value = new BlobInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.ReleaseLeaseAsync

            #region Blob.RenewLeaseAsync
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The lease operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> RenewLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.RenewLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = RenewLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return RenewLeaseAsync_CreateResponse(_response);
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
            /// Create the Blob.RenewLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.RenewLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request RenewLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (xMSLeaseID == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseID));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "renew");

                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }

                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.RenewLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.RenewLeaseAsync Azure.Response.</returns>
            internal static Azure.Response RenewLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Lease _value = new Lease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseId", out _header))
                        {
                            _value.LeaseId = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.RenewLeaseAsync

            #region Blob.ChangeLeaseAsync
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The lease operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ChangeLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId,
                string proposedLeaseId,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.ChangeLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ChangeLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        proposedLeaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ChangeLeaseAsync_CreateResponse(_response);
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
            /// Create the Blob.ChangeLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.ChangeLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request ChangeLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId,
                string proposedLeaseId,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (xMSLeaseID == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSLeaseID));
                }
                if (xMSProposedLeaseID == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSProposedLeaseID));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "change");

                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }


                    foreach (string _item in proposedLeaseId)
                    {
                        _request.Headers.SetValue("x-ms-proposed-lease-id", _item);
                    }

                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.ChangeLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.ChangeLeaseAsync Azure.Response.</returns>
            internal static Azure.Response ChangeLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Lease _value = new Lease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseId", out _header))
                        {
                            _value.LeaseId = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.ChangeLeaseAsync

            #region Blob.BreakLeaseAsync
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="breakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The Break operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> BreakLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                int? breakPeriod = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.BreakLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BreakLeaseAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        breakPeriod,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BreakLeaseAsync_CreateResponse(_response);
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
            /// Create the Blob.BreakLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="breakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.BreakLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request BreakLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                int? breakPeriod = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "break");
                if (xMSLeaseBreakPeriod != null) {
                    foreach (string _item in breakPeriod)
                    {
                        _request.Headers.SetValue("x-ms-lease-break-period", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.BreakLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.BreakLeaseAsync Azure.Response.</returns>
            internal static Azure.Response BreakLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        BrokenLease _value = new BrokenLease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("LeaseTime", out _header))
                        {
                            _value.LeaseTime = int;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.BreakLeaseAsync

            #region Blob.CreateSnapshotAsync
            /// <summary>
            /// The Create Snapshot operation creates a read-only snapshot of a blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The snaptshot was taken successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> CreateSnapshotAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string metadata = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.CreateSnapshot",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CreateSnapshotAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        metadata,
                        encryptionKey,
                        encryptionKeySha256,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CreateSnapshotAsync_CreateResponse(_response);
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
            /// Create the Blob.CreateSnapshotAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.CreateSnapshotAsync Request.</returns>
            internal static Azure.Core.Http.Request CreateSnapshotAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string metadata = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "snapshot");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSMeta != null) {
                    foreach (string _item in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.CreateSnapshotAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.CreateSnapshotAsync Azure.Response.</returns>
            internal static Azure.Response CreateSnapshotAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        BlobSnapshotInfo _value = new BlobSnapshotInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Snapshot", out _header))
                        {
                            _value.Snapshot = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("IsServerEncrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.CreateSnapshotAsync

            #region Blob.StartCopyFromUriAsync
            /// <summary>
            /// The Start Copy From URL operation copies a blob or an internet resource to a new blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="copySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> StartCopyFromUriAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string metadata = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.Uri copySource,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.StartCopyFromUri",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = StartCopyFromUriAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        metadata,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        copySource,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return StartCopyFromUriAsync_CreateResponse(_response);
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
            /// Create the Blob.StartCopyFromUriAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="copySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.StartCopyFromUriAsync Request.</returns>
            internal static Azure.Core.Http.Request StartCopyFromUriAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string metadata = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.Uri copySource,
                string leaseId = default,
                string requestId = default)
            {
                // Validation
                if (xMSCopySource == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSCopySource));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSMeta != null) {
                    foreach (string _item in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta", _item);
                    }
                }
                if (xMSAccessTier != null) { _request.Headers.SetValue("x-ms-access-tier", xMSAccessTier); }
                if (xMSRehydratePriority != null) { _request.Headers.SetValue("x-ms-rehydrate-priority", xMSRehydratePriority); }
                if (xMSSourceIFModifiedSince != null) {
                    foreach (string _item in sourceIfModifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-modified-since", _item);
                    }
                }
                if (xMSSourceIFUnmodifiedSince != null) {
                    foreach (string _item in sourceIfUnmodifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-unmodified-since", _item);
                    }
                }
                if (xMSSourceIFMatch != null) {
                    foreach (string _item in sourceIfMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-match", _item);
                    }
                }
                if (xMSSourceIFNoneMatch != null) {
                    foreach (string _item in sourceIfNoneMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-none-match", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }

                    foreach (string _item in copySource)
                    {
                        _request.Headers.SetValue("x-ms-copy-source", _item);
                    }

                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.StartCopyFromUriAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.StartCopyFromUriAsync Azure.Response.</returns>
            internal static Azure.Response StartCopyFromUriAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        BlobCopyInfo _value = new BlobCopyInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("CopyId", out _header))
                        {
                            _value.CopyId = _header;
                        }
                        if (response.Headers.TryGetValue("CopyStatus", out _header))
                        {
                            _value.CopyStatus = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.StartCopyFromUriAsync

            #region Blob.CopyFromUriAsync
            /// <summary>
            /// The Copy From URL operation copies a blob or an internet resource to a new blob. It will not return a response until the copy is complete.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="copySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> CopyFromUriAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string metadata = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.Uri copySource,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.CopyFromUri",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CopyFromUriAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        metadata,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        copySource,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CopyFromUriAsync_CreateResponse(_response);
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
            /// Create the Blob.CopyFromUriAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="copySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.CopyFromUriAsync Request.</returns>
            internal static Azure.Core.Http.Request CopyFromUriAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string metadata = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.Uri copySource,
                string leaseId = default,
                string requestId = default)
            {
                // Validation
                if (xMSCopySource == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSCopySource));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-requires-sync", "true");
                if (xMSMeta != null) {
                    foreach (string _item in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta", _item);
                    }
                }
                if (xMSAccessTier != null) { _request.Headers.SetValue("x-ms-access-tier", xMSAccessTier); }
                if (xMSSourceIFModifiedSince != null) {
                    foreach (string _item in sourceIfModifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-modified-since", _item);
                    }
                }
                if (xMSSourceIFUnmodifiedSince != null) {
                    foreach (string _item in sourceIfUnmodifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-unmodified-since", _item);
                    }
                }
                if (xMSSourceIFMatch != null) {
                    foreach (string _item in sourceIfMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-match", _item);
                    }
                }
                if (xMSSourceIFNoneMatch != null) {
                    foreach (string _item in sourceIfNoneMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-none-match", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }

                    foreach (string _item in copySource)
                    {
                        _request.Headers.SetValue("x-ms-copy-source", _item);
                    }

                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.CopyFromUriAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.CopyFromUriAsync Azure.Response.</returns>
            internal static Azure.Response CopyFromUriAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        BlobCopyInfo _value = new BlobCopyInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("CopyId", out _header))
                        {
                            _value.CopyId = _header;
                        }
                        if (response.Headers.TryGetValue("CopyStatus", out _header))
                        {
                            _value.CopyStatus = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.CopyFromUriAsync

            #region Blob.AbortCopyFromUriAsync
            /// <summary>
            /// The Abort Copy From URL operation aborts a pending Copy From URL operation, and leaves a destination blob with zero length and full metadata.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="copyId">The copy identifier provided in the x-ms-copy-id header of the original Copy Blob operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The delete request was accepted and the blob will be deleted.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> AbortCopyFromUriAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string copyId,
                int? timeout = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.AbortCopyFromUri",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AbortCopyFromUriAsync_CreateRequest(
                        pipeline,
                        url,
                        copyId,
                        timeout,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AbortCopyFromUriAsync_CreateResponse(_response);
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
            /// Create the Blob.AbortCopyFromUriAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="copyId">The copy identifier provided in the x-ms-copy-id header of the original Copy Blob operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.AbortCopyFromUriAsync Request.</returns>
            internal static Azure.Core.Http.Request AbortCopyFromUriAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string copyId,
                int? timeout = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation
                if (copyid == null)
                {
                    throw new System.ArgumentNullException(nameof(copyid));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "copy");
                _request.UriBuilder.AppendQuery("copyid", System.Uri.EscapeDataString(copyid));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-copy-action", "abort");
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.AbortCopyFromUriAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.AbortCopyFromUriAsync Azure.Response.</returns>
            internal static Azure.Response AbortCopyFromUriAsync_CreateResponse(
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
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.AbortCopyFromUriAsync

            #region Blob.SetTierAsync
            /// <summary>
            /// The Set Tier operation sets the tier on a blob. The operation is allowed on a page blob in a premium storage account and on a block blob in a blob storage account (locally redundant storage only). A premium page blob's tier determines the allowed size, IOPS, and bandwidth of the blob. A block blob's tier determines Hot/Cool/Archive storage type. This operation does not update the blob's ETag.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The new tier will take effect immediately.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetTierAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string requestId = default,
                string leaseId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.SetTier",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetTierAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        requestId,
                        leaseId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetTierAsync_CreateResponse(_response);
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
            /// Create the Blob.SetTierAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The Blob.SetTierAsync Request.</returns>
            internal static Azure.Core.Http.Request SetTierAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string requestId = default,
                string leaseId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "tier");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-access-tier", xMSAccessTier);
                if (xMSRehydratePriority != null) { _request.Headers.SetValue("x-ms-rehydrate-priority", xMSRehydratePriority); }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Blob.SetTierAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.SetTierAsync Azure.Response.</returns>
            internal static Azure.Response SetTierAsync_CreateResponse(
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
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.SetTierAsync
        }
        #endregion Blob operations

        #region PageBlob operations
        /// <summary>
        /// PageBlob operations for Azure Blob Storage
        /// </summary>
        public static partial class PageBlob
        {
            #region PageBlob.CreateAsync
            /// <summary>
            /// The Create operation creates a new page blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobContentLength">This header specifies the maximum size for the page blob, up to 1 TB. The page blob size must be aligned to a 512-byte boundary.</param>
            /// <param name="blobSequenceNumber">Set for page blobs only. The sequence number is a user-controlled value that you can use to track requests. The value of the sequence number must be between 0 and 2^63 - 1.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> CreateAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                long contentLength,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                string blobCacheControl = default,
                string metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                long blobContentLength,
                long? blobSequenceNumber = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CreateAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        contentLength,
                        blobContentType,
                        blobContentEncoding,
                        blobContentLanguage,
                        blobContentHash,
                        blobCacheControl,
                        metadata,
                        leaseId,
                        blobContentDisposition,
                        encryptionKey,
                        encryptionKeySha256,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        blobContentLength,
                        blobSequenceNumber,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CreateAsync_CreateResponse(_response);
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
            /// Create the PageBlob.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobContentLength">This header specifies the maximum size for the page blob, up to 1 TB. The page blob size must be aligned to a 512-byte boundary.</param>
            /// <param name="blobSequenceNumber">Set for page blobs only. The sequence number is a user-controlled value that you can use to track requests. The value of the sequence number must be between 0 and 2^63 - 1.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.CreateAsync Request.</returns>
            internal static Azure.Core.Http.Request CreateAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                long contentLength,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                string blobCacheControl = default,
                string metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                long blobContentLength,
                long? blobSequenceNumber = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-blob-type", "PageBlob");

                    foreach (string _item in contentLength)
                    {
                        _request.Headers.SetValue("Content-Length", _item);
                    }

                if (xMSBlobContentType != null) {
                    foreach (string _item in blobContentType)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-type", _item);
                    }
                }
                if (xMSBlobContentEncoding != null) {
                    foreach (string _item in blobContentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-encoding", _item);
                    }
                }
                if (xMSBlobContentLanguage != null) {
                    foreach (string _item in blobContentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-language", _item);
                    }
                }
                if (xMSBlobContentMd5 != null) {
                    foreach (string _item in blobContentHash)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-md5", _item);
                    }
                }
                if (xMSBlobCacheControl != null) {
                    foreach (string _item in blobCacheControl)
                    {
                        _request.Headers.SetValue("x-ms-blob-cache-control", _item);
                    }
                }
                if (xMSMeta != null) {
                    foreach (string _item in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSBlobContentDisposition != null) {
                    foreach (string _item in blobContentDisposition)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-disposition", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }

                    foreach (string _item in blobContentLength)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-length", _item);
                    }

                if (xMSBlobSequenceNumber != null) {
                    foreach (string _item in blobSequenceNumber)
                    {
                        _request.Headers.SetValue("x-ms-blob-sequence-number", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.CreateAsync Azure.Response.</returns>
            internal static Azure.Response CreateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        BlobContentInfo _value = new BlobContentInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = long;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.CreateAsync

            #region PageBlob.UploadPagesAsync
            /// <summary>
            /// The Upload Pages operation writes a range of pages to a page blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="transactionalContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifSequenceNumberLessThanOrEqualTo">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="ifSequenceNumberLessThan">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="ifSequenceNumberEqualTo">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> UploadPagesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                long contentLength,
                byte[] transactionalContentHash = default,
                byte[] transactionalContentCrc64 = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                long? ifSequenceNumberLessThanOrEqualTo = default,
                long? ifSequenceNumberLessThan = default,
                long? ifSequenceNumberEqualTo = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.UploadPages",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = UploadPagesAsync_CreateRequest(
                        pipeline,
                        url,
                        contentLength,
                        transactionalContentHash,
                        transactionalContentCrc64,
                        timeout,
                        range,
                        leaseId,
                        encryptionKey,
                        encryptionKeySha256,
                        ifSequenceNumberLessThanOrEqualTo,
                        ifSequenceNumberLessThan,
                        ifSequenceNumberEqualTo,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return UploadPagesAsync_CreateResponse(_response);
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
            /// Create the PageBlob.UploadPagesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="transactionalContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifSequenceNumberLessThanOrEqualTo">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="ifSequenceNumberLessThan">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="ifSequenceNumberEqualTo">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.UploadPagesAsync Request.</returns>
            internal static Azure.Core.Http.Request UploadPagesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                long contentLength,
                byte[] transactionalContentHash = default,
                byte[] transactionalContentCrc64 = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                long? ifSequenceNumberLessThanOrEqualTo = default,
                long? ifSequenceNumberLessThan = default,
                long? ifSequenceNumberEqualTo = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "page");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-page-write", "update");

                    foreach (string _item in contentLength)
                    {
                        _request.Headers.SetValue("Content-Length", _item);
                    }

                if (contentMD5 != null) {
                    foreach (string _item in transactionalContentHash)
                    {
                        _request.Headers.SetValue("Content-MD5", _item);
                    }
                }
                if (xMSContentCrc64 != null) {
                    foreach (string _item in transactionalContentCrc64)
                    {
                        _request.Headers.SetValue("x-ms-content-crc64", _item);
                    }
                }
                if (xMSRange != null) {
                    foreach (string _item in range)
                    {
                        _request.Headers.SetValue("x-ms-range", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSIFSequenceNumberLE != null) {
                    foreach (string _item in ifSequenceNumberLessThanOrEqualTo)
                    {
                        _request.Headers.SetValue("x-ms-if-sequence-number-le", _item);
                    }
                }
                if (xMSIFSequenceNumberLT != null) {
                    foreach (string _item in ifSequenceNumberLessThan)
                    {
                        _request.Headers.SetValue("x-ms-if-sequence-number-lt", _item);
                    }
                }
                if (xMSIFSequenceNumberEQ != null) {
                    foreach (string _item in ifSequenceNumberEqualTo)
                    {
                        _request.Headers.SetValue("x-ms-if-sequence-number-eq", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                // Create the body
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(body);

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.UploadPagesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.UploadPagesAsync Azure.Response.</returns>
            internal static Azure.Response UploadPagesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        PageInfo _value = new PageInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-content-crc64", out _header))
                        {
                            _value.XMSContentCrc64 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = long;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.UploadPagesAsync

            #region PageBlob.ClearPagesAsync
            /// <summary>
            /// The Clear Pages operation clears a set of pages from a page blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifSequenceNumberLessThanOrEqualTo">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="ifSequenceNumberLessThan">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="ifSequenceNumberEqualTo">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ClearPagesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                long contentLength,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                long? ifSequenceNumberLessThanOrEqualTo = default,
                long? ifSequenceNumberLessThan = default,
                long? ifSequenceNumberEqualTo = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.ClearPages",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ClearPagesAsync_CreateRequest(
                        pipeline,
                        url,
                        contentLength,
                        timeout,
                        range,
                        leaseId,
                        encryptionKey,
                        encryptionKeySha256,
                        ifSequenceNumberLessThanOrEqualTo,
                        ifSequenceNumberLessThan,
                        ifSequenceNumberEqualTo,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ClearPagesAsync_CreateResponse(_response);
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
            /// Create the PageBlob.ClearPagesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifSequenceNumberLessThanOrEqualTo">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="ifSequenceNumberLessThan">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="ifSequenceNumberEqualTo">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.ClearPagesAsync Request.</returns>
            internal static Azure.Core.Http.Request ClearPagesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                long contentLength,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                long? ifSequenceNumberLessThanOrEqualTo = default,
                long? ifSequenceNumberLessThan = default,
                long? ifSequenceNumberEqualTo = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "page");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-page-write", "clear");

                    foreach (string _item in contentLength)
                    {
                        _request.Headers.SetValue("Content-Length", _item);
                    }

                if (xMSRange != null) {
                    foreach (string _item in range)
                    {
                        _request.Headers.SetValue("x-ms-range", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSIFSequenceNumberLE != null) {
                    foreach (string _item in ifSequenceNumberLessThanOrEqualTo)
                    {
                        _request.Headers.SetValue("x-ms-if-sequence-number-le", _item);
                    }
                }
                if (xMSIFSequenceNumberLT != null) {
                    foreach (string _item in ifSequenceNumberLessThan)
                    {
                        _request.Headers.SetValue("x-ms-if-sequence-number-lt", _item);
                    }
                }
                if (xMSIFSequenceNumberEQ != null) {
                    foreach (string _item in ifSequenceNumberEqualTo)
                    {
                        _request.Headers.SetValue("x-ms-if-sequence-number-eq", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.ClearPagesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.ClearPagesAsync Azure.Response.</returns>
            internal static Azure.Response ClearPagesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        PageInfo _value = new PageInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-content-crc64", out _header))
                        {
                            _value.XMSContentCrc64 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = long;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.ClearPagesAsync

            #region PageBlob.UploadPagesFromUriAsync
            /// <summary>
            /// The Upload Pages operation writes a range of pages to a page blob where the contents are read from a URL
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="sourceUri">Specify a URL to the copy source.</param>
            /// <param name="sourceRange">Bytes of source data in the specified range. The length of this range should match the ContentLength header and x-ms-range/Range destination range header.</param>
            /// <param name="sourceContentHash">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="sourceContentcrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">The range of bytes to which the source range would be written. The range should be 512 aligned and range-end is required.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifSequenceNumberLessThanOrEqualTo">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="ifSequenceNumberLessThan">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="ifSequenceNumberEqualTo">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> UploadPagesFromUriAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                System.Uri sourceUri,
                string sourceRange,
                byte[] sourceContentHash = default,
                byte[] sourceContentcrc64 = default,
                long contentLength,
                int? timeout = default,
                string range,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                string leaseId = default,
                long? ifSequenceNumberLessThanOrEqualTo = default,
                long? ifSequenceNumberLessThan = default,
                long? ifSequenceNumberEqualTo = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.UploadPagesFromUri",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = UploadPagesFromUriAsync_CreateRequest(
                        pipeline,
                        url,
                        sourceUri,
                        sourceRange,
                        sourceContentHash,
                        sourceContentcrc64,
                        contentLength,
                        timeout,
                        range,
                        encryptionKey,
                        encryptionKeySha256,
                        leaseId,
                        ifSequenceNumberLessThanOrEqualTo,
                        ifSequenceNumberLessThan,
                        ifSequenceNumberEqualTo,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return UploadPagesFromUriAsync_CreateResponse(_response);
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
            /// Create the PageBlob.UploadPagesFromUriAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="sourceUri">Specify a URL to the copy source.</param>
            /// <param name="sourceRange">Bytes of source data in the specified range. The length of this range should match the ContentLength header and x-ms-range/Range destination range header.</param>
            /// <param name="sourceContentHash">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="sourceContentcrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">The range of bytes to which the source range would be written. The range should be 512 aligned and range-end is required.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifSequenceNumberLessThanOrEqualTo">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="ifSequenceNumberLessThan">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="ifSequenceNumberEqualTo">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.UploadPagesFromUriAsync Request.</returns>
            internal static Azure.Core.Http.Request UploadPagesFromUriAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                System.Uri sourceUri,
                string sourceRange,
                byte[] sourceContentHash = default,
                byte[] sourceContentcrc64 = default,
                long contentLength,
                int? timeout = default,
                string range,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                string leaseId = default,
                long? ifSequenceNumberLessThanOrEqualTo = default,
                long? ifSequenceNumberLessThan = default,
                long? ifSequenceNumberEqualTo = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (xMSCopySource == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSCopySource));
                }
                if (xMSSourceRange == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSSourceRange));
                }
                if (xMSRange == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSRange));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "page");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-page-write", "update");

                    foreach (string _item in sourceUri)
                    {
                        _request.Headers.SetValue("x-ms-copy-source", _item);
                    }


                    foreach (string _item in sourceRange)
                    {
                        _request.Headers.SetValue("x-ms-source-range", _item);
                    }

                if (xMSSourceContentMd5 != null) {
                    foreach (string _item in sourceContentHash)
                    {
                        _request.Headers.SetValue("x-ms-source-content-md5", _item);
                    }
                }
                if (xMSSourceContentCrc64 != null) {
                    foreach (string _item in sourceContentcrc64)
                    {
                        _request.Headers.SetValue("x-ms-source-content-crc64", _item);
                    }
                }

                    foreach (string _item in contentLength)
                    {
                        _request.Headers.SetValue("Content-Length", _item);
                    }


                    foreach (string _item in range)
                    {
                        _request.Headers.SetValue("x-ms-range", _item);
                    }

                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSIFSequenceNumberLE != null) {
                    foreach (string _item in ifSequenceNumberLessThanOrEqualTo)
                    {
                        _request.Headers.SetValue("x-ms-if-sequence-number-le", _item);
                    }
                }
                if (xMSIFSequenceNumberLT != null) {
                    foreach (string _item in ifSequenceNumberLessThan)
                    {
                        _request.Headers.SetValue("x-ms-if-sequence-number-lt", _item);
                    }
                }
                if (xMSIFSequenceNumberEQ != null) {
                    foreach (string _item in ifSequenceNumberEqualTo)
                    {
                        _request.Headers.SetValue("x-ms-if-sequence-number-eq", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                if (xMSSourceIFModifiedSince != null) {
                    foreach (string _item in sourceIfModifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-modified-since", _item);
                    }
                }
                if (xMSSourceIFUnmodifiedSince != null) {
                    foreach (string _item in sourceIfUnmodifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-unmodified-since", _item);
                    }
                }
                if (xMSSourceIFMatch != null) {
                    foreach (string _item in sourceIfMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-match", _item);
                    }
                }
                if (xMSSourceIFNoneMatch != null) {
                    foreach (string _item in sourceIfNoneMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-none-match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.UploadPagesFromUriAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.UploadPagesFromUriAsync Azure.Response.</returns>
            internal static Azure.Response UploadPagesFromUriAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        PageInfo _value = new PageInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-content-crc64", out _header))
                        {
                            _value.XMSContentCrc64 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = long;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        ConditionNotMetError _value = new ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.UploadPagesFromUriAsync

            #region PageBlob.GetPageRangesAsync
            /// <summary>
            /// The Get Page Ranges operation returns the list of valid page ranges for a page blob or snapshot of a page blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Information on the page blob was found.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<PageList>> GetPageRangesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string snapshot = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.GetPageRanges",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetPageRangesAsync_CreateRequest(
                        pipeline,
                        url,
                        snapshot,
                        timeout,
                        range,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetPageRangesAsync_CreateResponse(_response);
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
            /// Create the PageBlob.GetPageRangesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.GetPageRangesAsync Request.</returns>
            internal static Azure.Core.Http.Request GetPageRangesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string snapshot = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "pagelist");
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSRange != null) {
                    foreach (string _item in range)
                    {
                        _request.Headers.SetValue("x-ms-range", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.GetPageRangesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.GetPageRangesAsync Azure.Response{PageList}.</returns>
            internal static Azure.Response<PageList> GetPageRangesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        PageList _value = PageList.FromXml(_xml.Root);

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
                            _value.BlobContentLength = long;
                        }

                        // Create the response
                        Azure.Response<PageList> _result =
                            new Azure.Response<PageList>(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        ConditionNotMetError _value = new ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.GetPageRangesAsync

            #region PageBlob.GetPageRangesDiffAsync
            /// <summary>
            /// The Get Page Ranges Diff operation returns the list of valid page ranges for a page blob that were changed between target blob and previous snapshot.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="prevsnapshot">Optional in version 2015-07-08 and newer. The prevsnapshot parameter is a DateTime value that specifies that the response will contain only pages that were changed between target blob and previous snapshot. Changed pages include both updated and cleared pages. The target blob may be a snapshot, as long as the snapshot specified by prevsnapshot is the older of the two. Note that incremental snapshots are currently supported only for blobs created on or after January 1, 2016.</param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Information on the page blob was found.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<PageList>> GetPageRangesDiffAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string snapshot = default,
                int? timeout = default,
                string prevsnapshot = default,
                string range = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.GetPageRangesDiff",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetPageRangesDiffAsync_CreateRequest(
                        pipeline,
                        url,
                        snapshot,
                        timeout,
                        prevsnapshot,
                        range,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetPageRangesDiffAsync_CreateResponse(_response);
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
            /// Create the PageBlob.GetPageRangesDiffAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="prevsnapshot">Optional in version 2015-07-08 and newer. The prevsnapshot parameter is a DateTime value that specifies that the response will contain only pages that were changed between target blob and previous snapshot. Changed pages include both updated and cleared pages. The target blob may be a snapshot, as long as the snapshot specified by prevsnapshot is the older of the two. Note that incremental snapshots are currently supported only for blobs created on or after January 1, 2016.</param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.GetPageRangesDiffAsync Request.</returns>
            internal static Azure.Core.Http.Request GetPageRangesDiffAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string snapshot = default,
                int? timeout = default,
                string prevsnapshot = default,
                string range = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "pagelist");
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }
                if (prevsnapshot != null) { _request.UriBuilder.AppendQuery("prevsnapshot", System.Uri.EscapeDataString(prevsnapshot)); }

                // Add request headers
                if (xMSRange != null) {
                    foreach (string _item in range)
                    {
                        _request.Headers.SetValue("x-ms-range", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.GetPageRangesDiffAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.GetPageRangesDiffAsync Azure.Response{PageList}.</returns>
            internal static Azure.Response<PageList> GetPageRangesDiffAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        PageList _value = PageList.FromXml(_xml.Root);

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
                            _value.BlobContentLength = long;
                        }

                        // Create the response
                        Azure.Response<PageList> _result =
                            new Azure.Response<PageList>(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        ConditionNotMetError _value = new ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.GetPageRangesDiffAsync

            #region PageBlob.ResizeAsync
            /// <summary>
            /// Resize the Blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobContentLength">This header specifies the maximum size for the page blob, up to 1 TB. The page blob size must be aligned to a 512-byte boundary.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ResizeAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                long blobContentLength,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.Resize",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ResizeAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        encryptionKey,
                        encryptionKeySha256,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        blobContentLength,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ResizeAsync_CreateResponse(_response);
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
            /// Create the PageBlob.ResizeAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobContentLength">This header specifies the maximum size for the page blob, up to 1 TB. The page blob size must be aligned to a 512-byte boundary.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.ResizeAsync Request.</returns>
            internal static Azure.Core.Http.Request ResizeAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                long blobContentLength,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }

                    foreach (string _item in blobContentLength)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-length", _item);
                    }

                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.ResizeAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.ResizeAsync Azure.Response.</returns>
            internal static Azure.Response ResizeAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        PageBlobInfo _value = new PageBlobInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = long;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.ResizeAsync

            #region PageBlob.UpdateSequenceNumberAsync
            /// <summary>
            /// Update the sequence number of the blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobSequenceNumber">Set for page blobs only. The sequence number is a user-controlled value that you can use to track requests. The value of the sequence number must be between 0 and 2^63 - 1.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> UpdateSequenceNumberAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                long? blobSequenceNumber = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.UpdateSequenceNumber",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = UpdateSequenceNumberAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        blobSequenceNumber,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return UpdateSequenceNumberAsync_CreateResponse(_response);
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
            /// Create the PageBlob.UpdateSequenceNumberAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobSequenceNumber">Set for page blobs only. The sequence number is a user-controlled value that you can use to track requests. The value of the sequence number must be between 0 and 2^63 - 1.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.UpdateSequenceNumberAsync Request.</returns>
            internal static Azure.Core.Http.Request UpdateSequenceNumberAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                long? blobSequenceNumber = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-sequence-number-action", xMSSequenceNumberAction);
                if (xMSBlobSequenceNumber != null) {
                    foreach (string _item in blobSequenceNumber)
                    {
                        _request.Headers.SetValue("x-ms-blob-sequence-number", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.UpdateSequenceNumberAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.UpdateSequenceNumberAsync Azure.Response.</returns>
            internal static Azure.Response UpdateSequenceNumberAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        PageBlobInfo _value = new PageBlobInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = long;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.UpdateSequenceNumberAsync

            #region PageBlob.CopyIncrementalAsync
            /// <summary>
            /// The Copy Incremental operation copies a snapshot of the source page blob to a destination page blob. The snapshot is copied such that only the differential changes between the previously copied snapshot are transferred to the destination. The copied snapshots are complete copies of the original snapshot and can be read or copied from as usual. This API is supported since REST version 2016-05-31.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="copySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> CopyIncrementalAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.Uri copySource,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.CopyIncremental",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CopyIncrementalAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        copySource,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CopyIncrementalAsync_CreateResponse(_response);
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
            /// Create the PageBlob.CopyIncrementalAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="copySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.CopyIncrementalAsync Request.</returns>
            internal static Azure.Core.Http.Request CopyIncrementalAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.Uri copySource,
                string requestId = default)
            {
                // Validation
                if (xMSCopySource == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSCopySource));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "incrementalcopy");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }

                    foreach (string _item in copySource)
                    {
                        _request.Headers.SetValue("x-ms-copy-source", _item);
                    }

                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.CopyIncrementalAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.CopyIncrementalAsync Azure.Response.</returns>
            internal static Azure.Response CopyIncrementalAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        BlobCopyInfo _value = new BlobCopyInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("CopyId", out _header))
                        {
                            _value.CopyId = _header;
                        }
                        if (response.Headers.TryGetValue("CopyStatus", out _header))
                        {
                            _value.CopyStatus = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.CopyIncrementalAsync
        }
        #endregion PageBlob operations

        #region AppendBlob operations
        /// <summary>
        /// AppendBlob operations for Azure Blob Storage
        /// </summary>
        public static partial class AppendBlob
        {
            #region AppendBlob.CreateAsync
            /// <summary>
            /// The Create Append Blob operation creates a new append blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> CreateAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                long contentLength,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                string blobCacheControl = default,
                string metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.AppendBlobClient.Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CreateAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        contentLength,
                        blobContentType,
                        blobContentEncoding,
                        blobContentLanguage,
                        blobContentHash,
                        blobCacheControl,
                        metadata,
                        leaseId,
                        blobContentDisposition,
                        encryptionKey,
                        encryptionKeySha256,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CreateAsync_CreateResponse(_response);
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
            /// Create the AppendBlob.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The AppendBlob.CreateAsync Request.</returns>
            internal static Azure.Core.Http.Request CreateAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                long contentLength,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                string blobCacheControl = default,
                string metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-blob-type", "AppendBlob");

                    foreach (string _item in contentLength)
                    {
                        _request.Headers.SetValue("Content-Length", _item);
                    }

                if (xMSBlobContentType != null) {
                    foreach (string _item in blobContentType)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-type", _item);
                    }
                }
                if (xMSBlobContentEncoding != null) {
                    foreach (string _item in blobContentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-encoding", _item);
                    }
                }
                if (xMSBlobContentLanguage != null) {
                    foreach (string _item in blobContentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-language", _item);
                    }
                }
                if (xMSBlobContentMd5 != null) {
                    foreach (string _item in blobContentHash)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-md5", _item);
                    }
                }
                if (xMSBlobCacheControl != null) {
                    foreach (string _item in blobCacheControl)
                    {
                        _request.Headers.SetValue("x-ms-blob-cache-control", _item);
                    }
                }
                if (xMSMeta != null) {
                    foreach (string _item in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSBlobContentDisposition != null) {
                    foreach (string _item in blobContentDisposition)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-disposition", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the AppendBlob.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The AppendBlob.CreateAsync Azure.Response.</returns>
            internal static Azure.Response CreateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        BlobContentInfo _value = new BlobContentInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = long;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion AppendBlob.CreateAsync

            #region AppendBlob.AppendBlockAsync
            /// <summary>
            /// The Append Block operation commits a new block of data to the end of an existing append blob. The Append Block operation is permitted only if the blob was created with x-ms-blob-type set to AppendBlob. Append Block is supported only on version 2015-02-21 version or later.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="transactionalContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="maxSize">Optional conditional header. The max length in bytes permitted for the append blob. If the Append Block operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified in this header, the request will fail with MaxBlobSizeConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="appendPosition">Optional conditional header, used only for the Append Block operation. A number indicating the byte offset to compare. Append Block will succeed only if the append position is equal to this number. If it is not, the request will fail with the AppendPositionConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> AppendBlockAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                long contentLength,
                byte[] transactionalContentHash = default,
                byte[] transactionalContentCrc64 = default,
                string leaseId = default,
                long? maxSize = default,
                long? appendPosition = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.AppendBlobClient.AppendBlock",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AppendBlockAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        contentLength,
                        transactionalContentHash,
                        transactionalContentCrc64,
                        leaseId,
                        maxSize,
                        appendPosition,
                        encryptionKey,
                        encryptionKeySha256,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AppendBlockAsync_CreateResponse(_response);
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
            /// Create the AppendBlob.AppendBlockAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="transactionalContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="maxSize">Optional conditional header. The max length in bytes permitted for the append blob. If the Append Block operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified in this header, the request will fail with MaxBlobSizeConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="appendPosition">Optional conditional header, used only for the Append Block operation. A number indicating the byte offset to compare. Append Block will succeed only if the append position is equal to this number. If it is not, the request will fail with the AppendPositionConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The AppendBlob.AppendBlockAsync Request.</returns>
            internal static Azure.Core.Http.Request AppendBlockAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                long contentLength,
                byte[] transactionalContentHash = default,
                byte[] transactionalContentCrc64 = default,
                string leaseId = default,
                long? maxSize = default,
                long? appendPosition = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "appendblock");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers

                    foreach (string _item in contentLength)
                    {
                        _request.Headers.SetValue("Content-Length", _item);
                    }

                if (contentMD5 != null) {
                    foreach (string _item in transactionalContentHash)
                    {
                        _request.Headers.SetValue("Content-MD5", _item);
                    }
                }
                if (xMSContentCrc64 != null) {
                    foreach (string _item in transactionalContentCrc64)
                    {
                        _request.Headers.SetValue("x-ms-content-crc64", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSBlobConditionMaxsize != null) {
                    foreach (string _item in maxSize)
                    {
                        _request.Headers.SetValue("x-ms-blob-condition-maxsize", _item);
                    }
                }
                if (xMSBlobConditionAppendpos != null) {
                    foreach (string _item in appendPosition)
                    {
                        _request.Headers.SetValue("x-ms-blob-condition-appendpos", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                // Create the body
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(body);

                return _request;
            }

            /// <summary>
            /// Create the AppendBlob.AppendBlockAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The AppendBlob.AppendBlockAsync Azure.Response.</returns>
            internal static Azure.Response AppendBlockAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        BlobAppendInfo _value = new BlobAppendInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-content-crc64", out _header))
                        {
                            _value.XMSContentCrc64 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobAppendOffset", out _header))
                        {
                            _value.BlobAppendOffset = _header;
                        }
                        if (response.Headers.TryGetValue("BlobCommittedBlockCount", out _header))
                        {
                            _value.BlobCommittedBlockCount = int;
                        }
                        if (response.Headers.TryGetValue("IsServerEncrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion AppendBlob.AppendBlockAsync

            #region AppendBlob.AppendBlockFromUriAsync
            /// <summary>
            /// The Append Block operation commits a new block of data to the end of an existing append blob where the contents are read from a source url. The Append Block operation is permitted only if the blob was created with x-ms-blob-type set to AppendBlob. Append Block is supported only on version 2015-02-21 version or later.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="sourceUri">Specify a URL to the copy source.</param>
            /// <param name="sourceRange">Bytes of source data in the specified range.</param>
            /// <param name="sourceContentHash">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="sourceContentcrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="maxSize">Optional conditional header. The max length in bytes permitted for the append blob. If the Append Block operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified in this header, the request will fail with MaxBlobSizeConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="appendPosition">Optional conditional header, used only for the Append Block operation. A number indicating the byte offset to compare. Append Block will succeed only if the append position is equal to this number. If it is not, the request will fail with the AppendPositionConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> AppendBlockFromUriAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                System.Uri sourceUri,
                string sourceRange = default,
                byte[] sourceContentHash = default,
                byte[] sourceContentcrc64 = default,
                int? timeout = default,
                long contentLength,
                byte[] transactionalContentHash = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                string leaseId = default,
                long? maxSize = default,
                long? appendPosition = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.AppendBlobClient.AppendBlockFromUri",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AppendBlockFromUriAsync_CreateRequest(
                        pipeline,
                        url,
                        sourceUri,
                        sourceRange,
                        sourceContentHash,
                        sourceContentcrc64,
                        timeout,
                        contentLength,
                        transactionalContentHash,
                        encryptionKey,
                        encryptionKeySha256,
                        leaseId,
                        maxSize,
                        appendPosition,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AppendBlockFromUriAsync_CreateResponse(_response);
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
            /// Create the AppendBlob.AppendBlockFromUriAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="sourceUri">Specify a URL to the copy source.</param>
            /// <param name="sourceRange">Bytes of source data in the specified range.</param>
            /// <param name="sourceContentHash">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="sourceContentcrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="maxSize">Optional conditional header. The max length in bytes permitted for the append blob. If the Append Block operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified in this header, the request will fail with MaxBlobSizeConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="appendPosition">Optional conditional header, used only for the Append Block operation. A number indicating the byte offset to compare. Append Block will succeed only if the append position is equal to this number. If it is not, the request will fail with the AppendPositionConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The AppendBlob.AppendBlockFromUriAsync Request.</returns>
            internal static Azure.Core.Http.Request AppendBlockFromUriAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                System.Uri sourceUri,
                string sourceRange = default,
                byte[] sourceContentHash = default,
                byte[] sourceContentcrc64 = default,
                int? timeout = default,
                long contentLength,
                byte[] transactionalContentHash = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                string leaseId = default,
                long? maxSize = default,
                long? appendPosition = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (xMSCopySource == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSCopySource));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "appendblock");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers

                    foreach (string _item in sourceUri)
                    {
                        _request.Headers.SetValue("x-ms-copy-source", _item);
                    }

                if (xMSSourceRange != null) {
                    foreach (string _item in sourceRange)
                    {
                        _request.Headers.SetValue("x-ms-source-range", _item);
                    }
                }
                if (xMSSourceContentMd5 != null) {
                    foreach (string _item in sourceContentHash)
                    {
                        _request.Headers.SetValue("x-ms-source-content-md5", _item);
                    }
                }
                if (xMSSourceContentCrc64 != null) {
                    foreach (string _item in sourceContentcrc64)
                    {
                        _request.Headers.SetValue("x-ms-source-content-crc64", _item);
                    }
                }

                    foreach (string _item in contentLength)
                    {
                        _request.Headers.SetValue("Content-Length", _item);
                    }

                if (contentMD5 != null) {
                    foreach (string _item in transactionalContentHash)
                    {
                        _request.Headers.SetValue("Content-MD5", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSBlobConditionMaxsize != null) {
                    foreach (string _item in maxSize)
                    {
                        _request.Headers.SetValue("x-ms-blob-condition-maxsize", _item);
                    }
                }
                if (xMSBlobConditionAppendpos != null) {
                    foreach (string _item in appendPosition)
                    {
                        _request.Headers.SetValue("x-ms-blob-condition-appendpos", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                if (xMSSourceIFModifiedSince != null) {
                    foreach (string _item in sourceIfModifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-modified-since", _item);
                    }
                }
                if (xMSSourceIFUnmodifiedSince != null) {
                    foreach (string _item in sourceIfUnmodifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-unmodified-since", _item);
                    }
                }
                if (xMSSourceIFMatch != null) {
                    foreach (string _item in sourceIfMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-match", _item);
                    }
                }
                if (xMSSourceIFNoneMatch != null) {
                    foreach (string _item in sourceIfNoneMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-none-match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the AppendBlob.AppendBlockFromUriAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The AppendBlob.AppendBlockFromUriAsync Azure.Response.</returns>
            internal static Azure.Response AppendBlockFromUriAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        BlobAppendInfo _value = new BlobAppendInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-content-crc64", out _header))
                        {
                            _value.XMSContentCrc64 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobAppendOffset", out _header))
                        {
                            _value.BlobAppendOffset = _header;
                        }
                        if (response.Headers.TryGetValue("BlobCommittedBlockCount", out _header))
                        {
                            _value.BlobCommittedBlockCount = int;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }
                        if (response.Headers.TryGetValue("IsServerEncrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        ConditionNotMetError _value = new ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion AppendBlob.AppendBlockFromUriAsync
        }
        #endregion AppendBlob operations

        #region BlockBlob operations
        /// <summary>
        /// BlockBlob operations for Azure Blob Storage
        /// </summary>
        public static partial class BlockBlob
        {
            #region BlockBlob.UploadAsync
            /// <summary>
            /// The Upload Block Blob operation updates the content of an existing block blob. Updating an existing block blob overwrites any existing metadata on the blob. Partial updates are not supported with Put Blob; the content of the existing blob is overwritten with the content of the new blob. To perform a partial update of the content of a block blob, use the Put Block List operation.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> UploadAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                long contentLength,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                string blobCacheControl = default,
                string metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlockBlobClient.Upload",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = UploadAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        contentLength,
                        blobContentType,
                        blobContentEncoding,
                        blobContentLanguage,
                        blobContentHash,
                        blobCacheControl,
                        metadata,
                        leaseId,
                        blobContentDisposition,
                        encryptionKey,
                        encryptionKeySha256,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return UploadAsync_CreateResponse(_response);
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
            /// Create the BlockBlob.UploadAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.UploadAsync Request.</returns>
            internal static Azure.Core.Http.Request UploadAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                long contentLength,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                string blobCacheControl = default,
                string metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-blob-type", "BlockBlob");

                    foreach (string _item in contentLength)
                    {
                        _request.Headers.SetValue("Content-Length", _item);
                    }

                if (xMSBlobContentType != null) {
                    foreach (string _item in blobContentType)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-type", _item);
                    }
                }
                if (xMSBlobContentEncoding != null) {
                    foreach (string _item in blobContentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-encoding", _item);
                    }
                }
                if (xMSBlobContentLanguage != null) {
                    foreach (string _item in blobContentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-language", _item);
                    }
                }
                if (xMSBlobContentMd5 != null) {
                    foreach (string _item in blobContentHash)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-md5", _item);
                    }
                }
                if (xMSBlobCacheControl != null) {
                    foreach (string _item in blobCacheControl)
                    {
                        _request.Headers.SetValue("x-ms-blob-cache-control", _item);
                    }
                }
                if (xMSMeta != null) {
                    foreach (string _item in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSBlobContentDisposition != null) {
                    foreach (string _item in blobContentDisposition)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-disposition", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSAccessTier != null) { _request.Headers.SetValue("x-ms-access-tier", xMSAccessTier); }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                // Create the body
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(body);

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.UploadAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.UploadAsync Azure.Response.</returns>
            internal static Azure.Response UploadAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        BlobContentInfo _value = new BlobContentInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = long;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion BlockBlob.UploadAsync

            #region BlockBlob.StageBlockAsync
            /// <summary>
            /// The Stage Block operation creates a new block to be committed as part of a blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blockId">A valid Base64 string value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="transactionalContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> StageBlockAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string blockId,
                long contentLength,
                byte[] transactionalContentHash = default,
                byte[] transactionalContentCrc64 = default,
                int? timeout = default,
                string leaseId = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlockBlobClient.StageBlock",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = StageBlockAsync_CreateRequest(
                        pipeline,
                        url,
                        blockId,
                        contentLength,
                        transactionalContentHash,
                        transactionalContentCrc64,
                        timeout,
                        leaseId,
                        encryptionKey,
                        encryptionKeySha256,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return StageBlockAsync_CreateResponse(_response);
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
            /// Create the BlockBlob.StageBlockAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blockId">A valid Base64 string value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="transactionalContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.StageBlockAsync Request.</returns>
            internal static Azure.Core.Http.Request StageBlockAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string blockId,
                long contentLength,
                byte[] transactionalContentHash = default,
                byte[] transactionalContentCrc64 = default,
                int? timeout = default,
                string leaseId = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                string requestId = default)
            {
                // Validation
                if (blockid == null)
                {
                    throw new System.ArgumentNullException(nameof(blockid));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "block");
                _request.UriBuilder.AppendQuery("blockid", System.Uri.EscapeDataString(blockid));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers

                    foreach (string _item in contentLength)
                    {
                        _request.Headers.SetValue("Content-Length", _item);
                    }

                if (contentMD5 != null) {
                    foreach (string _item in transactionalContentHash)
                    {
                        _request.Headers.SetValue("Content-MD5", _item);
                    }
                }
                if (xMSContentCrc64 != null) {
                    foreach (string _item in transactionalContentCrc64)
                    {
                        _request.Headers.SetValue("x-ms-content-crc64", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                // Create the body
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(body);

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.StageBlockAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.StageBlockAsync Azure.Response.</returns>
            internal static Azure.Response StageBlockAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        BlockInfo _value = new BlockInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-content-crc64", out _header))
                        {
                            _value.XMSContentCrc64 = _header;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion BlockBlob.StageBlockAsync

            #region BlockBlob.StageBlockFromUriAsync
            /// <summary>
            /// The Stage Block operation creates a new block to be committed as part of a blob where the contents are read from a URL.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blockId">A valid Base64 string value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="sourceUri">Specify a URL to the copy source.</param>
            /// <param name="sourceRange">Bytes of source data in the specified range.</param>
            /// <param name="sourceContentHash">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="sourceContentcrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> StageBlockFromUriAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string blockId,
                long contentLength,
                System.Uri sourceUri,
                string sourceRange = default,
                byte[] sourceContentHash = default,
                byte[] sourceContentcrc64 = default,
                int? timeout = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                string leaseId = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlockBlobClient.StageBlockFromUri",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = StageBlockFromUriAsync_CreateRequest(
                        pipeline,
                        url,
                        blockId,
                        contentLength,
                        sourceUri,
                        sourceRange,
                        sourceContentHash,
                        sourceContentcrc64,
                        timeout,
                        encryptionKey,
                        encryptionKeySha256,
                        leaseId,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return StageBlockFromUriAsync_CreateResponse(_response);
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
            /// Create the BlockBlob.StageBlockFromUriAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blockId">A valid Base64 string value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="sourceUri">Specify a URL to the copy source.</param>
            /// <param name="sourceRange">Bytes of source data in the specified range.</param>
            /// <param name="sourceContentHash">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="sourceContentcrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.StageBlockFromUriAsync Request.</returns>
            internal static Azure.Core.Http.Request StageBlockFromUriAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string blockId,
                long contentLength,
                System.Uri sourceUri,
                string sourceRange = default,
                byte[] sourceContentHash = default,
                byte[] sourceContentcrc64 = default,
                int? timeout = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                string leaseId = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (blockid == null)
                {
                    throw new System.ArgumentNullException(nameof(blockid));
                }
                if (xMSCopySource == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSCopySource));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "block");
                _request.UriBuilder.AppendQuery("blockid", System.Uri.EscapeDataString(blockid));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers

                    foreach (string _item in contentLength)
                    {
                        _request.Headers.SetValue("Content-Length", _item);
                    }


                    foreach (string _item in sourceUri)
                    {
                        _request.Headers.SetValue("x-ms-copy-source", _item);
                    }

                if (xMSSourceRange != null) {
                    foreach (string _item in sourceRange)
                    {
                        _request.Headers.SetValue("x-ms-source-range", _item);
                    }
                }
                if (xMSSourceContentMd5 != null) {
                    foreach (string _item in sourceContentHash)
                    {
                        _request.Headers.SetValue("x-ms-source-content-md5", _item);
                    }
                }
                if (xMSSourceContentCrc64 != null) {
                    foreach (string _item in sourceContentcrc64)
                    {
                        _request.Headers.SetValue("x-ms-source-content-crc64", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSSourceIFModifiedSince != null) {
                    foreach (string _item in sourceIfModifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-modified-since", _item);
                    }
                }
                if (xMSSourceIFUnmodifiedSince != null) {
                    foreach (string _item in sourceIfUnmodifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-unmodified-since", _item);
                    }
                }
                if (xMSSourceIFMatch != null) {
                    foreach (string _item in sourceIfMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-match", _item);
                    }
                }
                if (xMSSourceIFNoneMatch != null) {
                    foreach (string _item in sourceIfNoneMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-none-match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.StageBlockFromUriAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.StageBlockFromUriAsync Azure.Response.</returns>
            internal static Azure.Response StageBlockFromUriAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        BlockInfo _value = new BlockInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-content-crc64", out _header))
                        {
                            _value.XMSContentCrc64 = _header;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        ConditionNotMetError _value = new ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ErrorCode", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion BlockBlob.StageBlockFromUriAsync

            #region BlockBlob.CommitBlockListAsync
            /// <summary>
            /// The Commit Block List operation writes a blob by specifying the list of block IDs that make up the blob. In order to be written as part of a blob, a block must have been successfully written to the server in a prior Put Block operation. You can call Put Block List to update a blob by uploading only those blocks that have changed, then committing the new and existing blocks together. You can do this by specifying whether to commit a block from the committed block list or from the uncommitted block list, or to commit the most recently uploaded version of the block, whichever list it may belong to.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="transactionalContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The operation completed successfully.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> CommitBlockListAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string blobCacheControl = default,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                byte[] transactionalContentHash = default,
                byte[] transactionalContentCrc64 = default,
                string metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlockBlobClient.CommitBlockList",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CommitBlockListAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        blobCacheControl,
                        blobContentType,
                        blobContentEncoding,
                        blobContentLanguage,
                        blobContentHash,
                        transactionalContentHash,
                        transactionalContentCrc64,
                        metadata,
                        leaseId,
                        blobContentDisposition,
                        encryptionKey,
                        encryptionKeySha256,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CommitBlockListAsync_CreateResponse(_response);
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
            /// Create the BlockBlob.CommitBlockListAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="transactionalContentCrc64">Specify the transactional crc64 for the body, to be validated by the service.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="encryptionKey">Optional. Specifies the encryption key to use to encrypt the data provided in the request. If not specified, encryption is performed with the root account encryption key.  For more information, see Encryption at Rest for Azure Storage Services.</param>
            /// <param name="encryptionKeySha256">The SHA-256 hash of the provided encryption key. Must be provided if the x-ms-encryption-key header is provided.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.CommitBlockListAsync Request.</returns>
            internal static Azure.Core.Http.Request CommitBlockListAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string blobCacheControl = default,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                byte[] transactionalContentHash = default,
                byte[] transactionalContentCrc64 = default,
                string metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                string encryptionKey = default,
                string encryptionKeySha256 = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "blocklist");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSBlobCacheControl != null) {
                    foreach (string _item in blobCacheControl)
                    {
                        _request.Headers.SetValue("x-ms-blob-cache-control", _item);
                    }
                }
                if (xMSBlobContentType != null) {
                    foreach (string _item in blobContentType)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-type", _item);
                    }
                }
                if (xMSBlobContentEncoding != null) {
                    foreach (string _item in blobContentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-encoding", _item);
                    }
                }
                if (xMSBlobContentLanguage != null) {
                    foreach (string _item in blobContentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-language", _item);
                    }
                }
                if (xMSBlobContentMd5 != null) {
                    foreach (string _item in blobContentHash)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-md5", _item);
                    }
                }
                if (contentMD5 != null) {
                    foreach (string _item in transactionalContentHash)
                    {
                        _request.Headers.SetValue("Content-MD5", _item);
                    }
                }
                if (xMSContentCrc64 != null) {
                    foreach (string _item in transactionalContentCrc64)
                    {
                        _request.Headers.SetValue("x-ms-content-crc64", _item);
                    }
                }
                if (xMSMeta != null) {
                    foreach (string _item in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSBlobContentDisposition != null) {
                    foreach (string _item in blobContentDisposition)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-disposition", _item);
                    }
                }
                if (xMSEncryptionKey != null) {
                    foreach (string _item in encryptionKey)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key", _item);
                    }
                }
                if (xMSEncryptionKeySha256 != null) {
                    foreach (string _item in encryptionKeySha256)
                    {
                        _request.Headers.SetValue("x-ms-encryption-key-sha256", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-encryption-algorithm", "AES256");
                if (xMSAccessTier != null) { _request.Headers.SetValue("x-ms-access-tier", xMSAccessTier); }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                // Create the body
                System.Xml.Linq.XElement _body = BlockLookupList.ToXml(blocks, "BlockList", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.CommitBlockListAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.CommitBlockListAsync Azure.Response.</returns>
            internal static Azure.Response CommitBlockListAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        BlobContentInfo _value = new BlobContentInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("ContentHash", out _header))
                        {
                            _value.ContentHash = _header;
                        }
                        if (response.Headers.TryGetValue("EncryptionKeySha256", out _header))
                        {
                            _value.EncryptionKeySha256 = _header;
                        }
                        if (response.Headers.TryGetValue("BlobSequenceNumber", out _header))
                        {
                            _value.BlobSequenceNumber = long;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion BlockBlob.CommitBlockListAsync

            #region BlockBlob.GetBlockListAsync
            /// <summary>
            /// The Get Block List operation retrieves the list of blocks that have been uploaded as part of a block blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The page range was written.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<BlockList>> GetBlockListAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlockBlobClient.GetBlockList",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetBlockListAsync_CreateRequest(
                        pipeline,
                        url,
                        snapshot,
                        timeout,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetBlockListAsync_CreateResponse(_response);
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
            /// Create the BlockBlob.GetBlockListAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.GetBlockListAsync Request.</returns>
            internal static Azure.Core.Http.Request GetBlockListAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("comp", "blocklist");
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                _request.UriBuilder.AppendQuery("blocklisttype", System.Uri.EscapeDataString(blocklisttype));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.GetBlockListAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.GetBlockListAsync Azure.Response{BlockList}.</returns>
            internal static Azure.Response<BlockList> GetBlockListAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        BlockList _value = BlockList.FromXml(_xml.Root);

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
                            _value.BlobContentLength = long;
                        }

                        // Create the response
                        Azure.Response<BlockList> _result =
                            new Azure.Response<BlockList>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        StorageError _value = StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion BlockBlob.GetBlockListAsync
        }
        #endregion BlockBlob operations

        #region Directory operations
        /// <summary>
        /// Directory operations for Azure Blob Storage
        /// </summary>
        public static partial class Directory
        {
            #region Directory.CreateAsync
            /// <summary>
            /// Create a directory. By default, the destination is overwritten and if the destination already exists and has a lease the lease is broken. This operation supports conditional HTTP requests.  For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations).  To fail if the destination already exists, use a conditional request with If-None-Match: "*".
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="directoryProperties">Optional.  User-defined properties to be stored with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is base64 encoded.</param>
            /// <param name="posixPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="posixUmask">Only valid if Hierarchical Namespace is enabled for the account. This umask restricts permission settings for file and directory, and will only be applied when default Acl does not exist in parent directory. If the umask bit has set, it means that the corresponding permission will be disabled. Otherwise the corresponding permission will be determined by the permission. A 4-digit octal notation (e.g. 0022) is supported here. If no umask was specified, a default umask - 0027 will be used.</param>
            /// <param name="cacheControl">Cache control for given resource</param>
            /// <param name="contentType">Content type for given resource</param>
            /// <param name="contentEncoding">Content encoding for given resource</param>
            /// <param name="contentLanguage">Content language for given resource</param>
            /// <param name="contentDisposition">Content disposition for given resource</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The file or directory was created.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> CreateAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string directoryProperties = default,
                string posixPermissions = default,
                string posixUmask = default,
                string cacheControl = default,
                string contentType = default,
                string contentEncoding = default,
                string contentLanguage = default,
                string contentDisposition = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.DirectoryClient.Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CreateAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        directoryProperties,
                        posixPermissions,
                        posixUmask,
                        cacheControl,
                        contentType,
                        contentEncoding,
                        contentLanguage,
                        contentDisposition,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CreateAsync_CreateResponse(_response);
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
            /// Create the Directory.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="directoryProperties">Optional.  User-defined properties to be stored with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is base64 encoded.</param>
            /// <param name="posixPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="posixUmask">Only valid if Hierarchical Namespace is enabled for the account. This umask restricts permission settings for file and directory, and will only be applied when default Acl does not exist in parent directory. If the umask bit has set, it means that the corresponding permission will be disabled. Otherwise the corresponding permission will be determined by the permission. A 4-digit octal notation (e.g. 0022) is supported here. If no umask was specified, a default umask - 0027 will be used.</param>
            /// <param name="cacheControl">Cache control for given resource</param>
            /// <param name="contentType">Content type for given resource</param>
            /// <param name="contentEncoding">Content encoding for given resource</param>
            /// <param name="contentLanguage">Content language for given resource</param>
            /// <param name="contentDisposition">Content disposition for given resource</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Directory.CreateAsync Request.</returns>
            internal static Azure.Core.Http.Request CreateAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string directoryProperties = default,
                string posixPermissions = default,
                string posixUmask = default,
                string cacheControl = default,
                string contentType = default,
                string contentEncoding = default,
                string contentLanguage = default,
                string contentDisposition = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("resource", "directory");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSProperties != null) {
                    foreach (string _item in directoryProperties)
                    {
                        _request.Headers.SetValue("x-ms-properties", _item);
                    }
                }
                if (xMSPermissions != null) {
                    foreach (string _item in posixPermissions)
                    {
                        _request.Headers.SetValue("x-ms-permissions", _item);
                    }
                }
                if (xMSUmask != null) {
                    foreach (string _item in posixUmask)
                    {
                        _request.Headers.SetValue("x-ms-umask", _item);
                    }
                }
                if (xMSCacheControl != null) {
                    foreach (string _item in cacheControl)
                    {
                        _request.Headers.SetValue("x-ms-cache-control", _item);
                    }
                }
                if (xMSContentType != null) {
                    foreach (string _item in contentType)
                    {
                        _request.Headers.SetValue("x-ms-content-type", _item);
                    }
                }
                if (xMSContentEncoding != null) {
                    foreach (string _item in contentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-content-encoding", _item);
                    }
                }
                if (xMSContentLanguage != null) {
                    foreach (string _item in contentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-content-language", _item);
                    }
                }
                if (xMSContentDisposition != null) {
                    foreach (string _item in contentDisposition)
                    {
                        _request.Headers.SetValue("x-ms-content-disposition", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Directory.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.CreateAsync Azure.Response.</returns>
            internal static Azure.Response CreateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        NORESPONSENAME _value = new NORESPONSENAME();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        DataLakeStorageError _value = DataLakeStorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Directory.CreateAsync

            #region Directory.RenameAsync
            /// <summary>
            /// Rename a directory. By default, the destination is overwritten and if the destination already exists and has a lease the lease is broken. This operation supports conditional HTTP requests. For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations). To fail if the destination already exists, use a conditional request with If-None-Match: "*".
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="marker">When renaming a directory, the number of paths that are renamed with each invocation is limited.  If the number of paths to be renamed exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the rename operation to continue renaming the directory.</param>
            /// <param name="renameSource">The file or directory to be renamed. The value must have the following format: "/{filesysystem}/{path}".  If "x-ms-properties" is specified, the properties will overwrite the existing properties; otherwise, the existing properties will be preserved.</param>
            /// <param name="directoryProperties">Optional.  User-defined properties to be stored with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is base64 encoded.</param>
            /// <param name="posixPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="posixUmask">Only valid if Hierarchical Namespace is enabled for the account. This umask restricts permission settings for file and directory, and will only be applied when default Acl does not exist in parent directory. If the umask bit has set, it means that the corresponding permission will be disabled. Otherwise the corresponding permission will be determined by the permission. A 4-digit octal notation (e.g. 0022) is supported here. If no umask was specified, a default umask - 0027 will be used.</param>
            /// <param name="cacheControl">Cache control for given resource</param>
            /// <param name="contentType">Content type for given resource</param>
            /// <param name="contentEncoding">Content encoding for given resource</param>
            /// <param name="contentLanguage">Content language for given resource</param>
            /// <param name="contentDisposition">Content disposition for given resource</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="sourceLeaseId">A lease ID for the source path. If specified, the source path must have an active lease and the leaase ID must match.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The directory was renamed.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> RenameAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string marker = default,
                string renameSource,
                string directoryProperties = default,
                string posixPermissions = default,
                string posixUmask = default,
                string cacheControl = default,
                string contentType = default,
                string contentEncoding = default,
                string contentLanguage = default,
                string contentDisposition = default,
                string leaseId = default,
                string sourceLeaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.DirectoryClient.Rename",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = RenameAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        marker,
                        renameSource,
                        directoryProperties,
                        posixPermissions,
                        posixUmask,
                        cacheControl,
                        contentType,
                        contentEncoding,
                        contentLanguage,
                        contentDisposition,
                        leaseId,
                        sourceLeaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return RenameAsync_CreateResponse(_response);
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
            /// Create the Directory.RenameAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="marker">When renaming a directory, the number of paths that are renamed with each invocation is limited.  If the number of paths to be renamed exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the rename operation to continue renaming the directory.</param>
            /// <param name="renameSource">The file or directory to be renamed. The value must have the following format: "/{filesysystem}/{path}".  If "x-ms-properties" is specified, the properties will overwrite the existing properties; otherwise, the existing properties will be preserved.</param>
            /// <param name="directoryProperties">Optional.  User-defined properties to be stored with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is base64 encoded.</param>
            /// <param name="posixPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="posixUmask">Only valid if Hierarchical Namespace is enabled for the account. This umask restricts permission settings for file and directory, and will only be applied when default Acl does not exist in parent directory. If the umask bit has set, it means that the corresponding permission will be disabled. Otherwise the corresponding permission will be determined by the permission. A 4-digit octal notation (e.g. 0022) is supported here. If no umask was specified, a default umask - 0027 will be used.</param>
            /// <param name="cacheControl">Cache control for given resource</param>
            /// <param name="contentType">Content type for given resource</param>
            /// <param name="contentEncoding">Content encoding for given resource</param>
            /// <param name="contentLanguage">Content language for given resource</param>
            /// <param name="contentDisposition">Content disposition for given resource</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="sourceLeaseId">A lease ID for the source path. If specified, the source path must have an active lease and the leaase ID must match.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Directory.RenameAsync Request.</returns>
            internal static Azure.Core.Http.Request RenameAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string marker = default,
                string renameSource,
                string directoryProperties = default,
                string posixPermissions = default,
                string posixUmask = default,
                string cacheControl = default,
                string contentType = default,
                string contentEncoding = default,
                string contentLanguage = default,
                string contentDisposition = default,
                string leaseId = default,
                string sourceLeaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset sourceIfModifiedSince = default,
                System.DateTimeOffset sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag sourceIfMatch = default,
                Azure.Core.Http.ETag sourceIfNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (xMSRenameSource == null)
                {
                    throw new System.ArgumentNullException(nameof(xMSRenameSource));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }
                if (continuation != null) { _request.UriBuilder.AppendQuery("continuation", System.Uri.EscapeDataString(continuation)); }
                if (mode != null) { _request.UriBuilder.AppendQuery("mode", System.Uri.EscapeDataString(mode)); }

                // Add request headers

                    foreach (string _item in renameSource)
                    {
                        _request.Headers.SetValue("x-ms-rename-source", _item);
                    }

                if (xMSProperties != null) {
                    foreach (string _item in directoryProperties)
                    {
                        _request.Headers.SetValue("x-ms-properties", _item);
                    }
                }
                if (xMSPermissions != null) {
                    foreach (string _item in posixPermissions)
                    {
                        _request.Headers.SetValue("x-ms-permissions", _item);
                    }
                }
                if (xMSUmask != null) {
                    foreach (string _item in posixUmask)
                    {
                        _request.Headers.SetValue("x-ms-umask", _item);
                    }
                }
                if (xMSCacheControl != null) {
                    foreach (string _item in cacheControl)
                    {
                        _request.Headers.SetValue("x-ms-cache-control", _item);
                    }
                }
                if (xMSContentType != null) {
                    foreach (string _item in contentType)
                    {
                        _request.Headers.SetValue("x-ms-content-type", _item);
                    }
                }
                if (xMSContentEncoding != null) {
                    foreach (string _item in contentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-content-encoding", _item);
                    }
                }
                if (xMSContentLanguage != null) {
                    foreach (string _item in contentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-content-language", _item);
                    }
                }
                if (xMSContentDisposition != null) {
                    foreach (string _item in contentDisposition)
                    {
                        _request.Headers.SetValue("x-ms-content-disposition", _item);
                    }
                }
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSSourceLeaseID != null) {
                    foreach (string _item in sourceLeaseId)
                    {
                        _request.Headers.SetValue("x-ms-source-lease-id", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                if (xMSSourceIFModifiedSince != null) {
                    foreach (string _item in sourceIfModifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-modified-since", _item);
                    }
                }
                if (xMSSourceIFUnmodifiedSince != null) {
                    foreach (string _item in sourceIfUnmodifiedSince)
                    {
                        _request.Headers.SetValue("x-ms-source-if-unmodified-since", _item);
                    }
                }
                if (xMSSourceIFMatch != null) {
                    foreach (string _item in sourceIfMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-match", _item);
                    }
                }
                if (xMSSourceIFNoneMatch != null) {
                    foreach (string _item in sourceIfNoneMatch)
                    {
                        _request.Headers.SetValue("x-ms-source-if-none-match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Directory.RenameAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.RenameAsync Azure.Response.</returns>
            internal static Azure.Response RenameAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        NORESPONSENAME _value = new NORESPONSENAME();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("marker", out _header))
                        {
                            _value.Marker = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        DataLakeStorageError _value = DataLakeStorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Directory.RenameAsync

            #region Directory.DeleteAsync
            /// <summary>
            /// Deletes the directory
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="recursiveDirectoryDelete">If "true", all paths beneath the directory will be deleted. If "false" and the directory is non-empty, an error occurs.</param>
            /// <param name="marker">When renaming a directory, the number of paths that are renamed with each invocation is limited.  If the number of paths to be renamed exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the rename operation to continue renaming the directory.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The directory was deleted.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                bool recursiveDirectoryDelete,
                string marker = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.DirectoryClient.Delete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DeleteAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        recursiveDirectoryDelete,
                        marker,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return DeleteAsync_CreateResponse(_response);
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
            /// Create the Directory.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="recursiveDirectoryDelete">If "true", all paths beneath the directory will be deleted. If "false" and the directory is non-empty, an error occurs.</param>
            /// <param name="marker">When renaming a directory, the number of paths that are renamed with each invocation is limited.  If the number of paths to be renamed exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the rename operation to continue renaming the directory.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Directory.DeleteAsync Request.</returns>
            internal static Azure.Core.Http.Request DeleteAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                bool recursiveDirectoryDelete,
                string marker = default,
                string leaseId = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Delete;
                _request.UriBuilder.Uri = url;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.UriBuilder.AppendQuery("recursive", System.Uri.EscapeDataString(bool));
                #pragma warning restore CA1308 // Normalize strings to uppercase

                if (continuation != null) { _request.UriBuilder.AppendQuery("continuation", System.Uri.EscapeDataString(continuation)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }

                return _request;
            }

            /// <summary>
            /// Create the Directory.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.DeleteAsync Azure.Response.</returns>
            internal static Azure.Response DeleteAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        NORESPONSENAME _value = new NORESPONSENAME();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("marker", out _header))
                        {
                            _value.Marker = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        DataLakeStorageError _value = DataLakeStorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Directory.DeleteAsync

            #region Directory.SetAccessControlAsync
            /// <summary>
            /// Set the owner, group, permissions, or access control list for a directory.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="owner">Optional. The owner of the blob or directory.</param>
            /// <param name="group">Optional. The owning group of the blob or directory.</param>
            /// <param name="posixPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="posixAcl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Set directory access control response.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetAccessControlAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                string owner = default,
                string group = default,
                string posixPermissions = default,
                string posixAcl = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.DirectoryClient.SetAccessControl",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetAccessControlAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        leaseId,
                        owner,
                        group,
                        posixPermissions,
                        posixAcl,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetAccessControlAsync_CreateResponse(_response);
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
            /// Create the Directory.SetAccessControlAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="owner">Optional. The owner of the blob or directory.</param>
            /// <param name="group">Optional. The owning group of the blob or directory.</param>
            /// <param name="posixPermissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="posixAcl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Directory.SetAccessControlAsync Request.</returns>
            internal static Azure.Core.Http.Request SetAccessControlAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                string leaseId = default,
                string owner = default,
                string group = default,
                string posixPermissions = default,
                string posixAcl = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Patch;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("action", "setAccessControl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (xMSOwner != null) {
                    foreach (string _item in owner)
                    {
                        _request.Headers.SetValue("x-ms-owner", _item);
                    }
                }
                if (xMSGroup != null) {
                    foreach (string _item in group)
                    {
                        _request.Headers.SetValue("x-ms-group", _item);
                    }
                }
                if (xMSPermissions != null) {
                    foreach (string _item in posixPermissions)
                    {
                        _request.Headers.SetValue("x-ms-permissions", _item);
                    }
                }
                if (xMSAcl != null) {
                    foreach (string _item in posixAcl)
                    {
                        _request.Headers.SetValue("x-ms-acl", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");

                return _request;
            }

            /// <summary>
            /// Create the Directory.SetAccessControlAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.SetAccessControlAsync Azure.Response.</returns>
            internal static Azure.Response SetAccessControlAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        NORESPONSENAME _value = new NORESPONSENAME();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        DataLakeStorageError _value = DataLakeStorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Directory.SetAccessControlAsync

            #region Directory.GetAccessControlAsync
            /// <summary>
            /// Get the owner, group, permissions, or access control list for a directory.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="upn">Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true", the identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response headers will be transformed from Azure Active Directory Object IDs to User Principal Names.  If "false", the values will be returned as Azure Active Directory Object IDs. The default value is false.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Get directory access control response.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> GetAccessControlAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                bool? upn = default,
                string leaseId = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.DirectoryClient.GetAccessControl",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetAccessControlAsync_CreateRequest(
                        pipeline,
                        url,
                        timeout,
                        upn,
                        leaseId,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetAccessControlAsync_CreateResponse(_response);
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
            /// Create the Directory.GetAccessControlAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="url">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="upn">Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true", the identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response headers will be transformed from Azure Active Directory Object IDs to User Principal Names.  If "false", the values will be returned as Azure Active Directory Object IDs. The default value is false.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Directory.GetAccessControlAsync Request.</returns>
            internal static Azure.Core.Http.Request GetAccessControlAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                string url = default,
                int? timeout = default,
                bool? upn = default,
                string leaseId = default,
                Azure.Core.Http.ETag ifMatch = default,
                Azure.Core.Http.ETag ifNoneMatch = default,
                System.DateTimeOffset ifModifiedSince = default,
                System.DateTimeOffset ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Head;
                _request.UriBuilder.Uri = url;
                _request.UriBuilder.AppendQuery("action", "getAccessControl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(int)); }
                if (upn != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.UriBuilder.AppendQuery("upn", System.Uri.EscapeDataString(bool));
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }

                // Add request headers
                if (xMSLeaseID != null) {
                    foreach (string _item in leaseId)
                    {
                        _request.Headers.SetValue("x-ms-lease-id", _item);
                    }
                }
                if (ifMatch != null) {
                    foreach (string _item in ifMatch)
                    {
                        _request.Headers.SetValue("If-Match", _item);
                    }
                }
                if (ifNoneMatch != null) {
                    foreach (string _item in ifNoneMatch)
                    {
                        _request.Headers.SetValue("If-None-Match", _item);
                    }
                }
                if (ifModifiedSince != null) {
                    foreach (string _item in ifModifiedSince)
                    {
                        _request.Headers.SetValue("If-Modified-Since", _item);
                    }
                }
                if (ifUnmodifiedSince != null) {
                    foreach (string _item in ifUnmodifiedSince)
                    {
                        _request.Headers.SetValue("If-Unmodified-Since", _item);
                    }
                }
                if (xMSClientRequestID != null) {
                    foreach (string _item in requestId)
                    {
                        _request.Headers.SetValue("x-ms-client-request-id", _item);
                    }
                }
                _request.Headers.SetValue("x-ms-version", "2019-02-02");

                return _request;
            }

            /// <summary>
            /// Create the Directory.GetAccessControlAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.GetAccessControlAsync Azure.Response.</returns>
            internal static Azure.Response GetAccessControlAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        NORESPONSENAME _value = new NORESPONSENAME();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = _header;
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-owner", out _header))
                        {
                            _value.XMSOwner = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-group", out _header))
                        {
                            _value.XMSGroup = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-permissions", out _header))
                        {
                            _value.XMSPermissions = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-acl", out _header))
                        {
                            _value.XMSAcl = _header;
                        }

                        // Create the response
                        Azure.Response _result =
                            new Azure.Response(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        DataLakeStorageError _value = DataLakeStorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Directory.GetAccessControlAsync
        }
        #endregion Directory operations
    }
}
#endregion Service

#region Models
#endregion Models

