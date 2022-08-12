// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using CadlFirstTest.Models;

namespace CadlFirstTest
{
    /// <summary> The HelloWorld service client. </summary>
    public partial class HelloWorldClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of HelloWorldClient for mocking. </summary>
        protected HelloWorldClient()
        {
        }

        /// <summary> Initializes a new instance of HelloWorldClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public HelloWorldClient(Uri endpoint, string apiVersion) : this(endpoint, apiVersion, new DemoHelloworldClientOptions())
        {
        }

        /// <summary> Initializes a new instance of HelloWorldClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="apiVersion"> The String to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public HelloWorldClient(Uri endpoint, string apiVersion, DemoHelloworldClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            options ??= new DemoHelloworldClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <param name="action"> The String to use. </param>
        /// <param name="exEnum"> The ExtensibleEnum to use. </param>
        /// <param name="enum"> The SimpleEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="action"/> is null. </exception>
        public virtual async Task<Response<Thing>> TopActionValueAsync(string action, ExtensibleEnum exEnum, SimpleEnum? @enum = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(action, nameof(action));

            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopActionValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await TopActionAsync(action, exEnum.ToString(), @enum?.ToSerialString(), context).ConfigureAwait(false);
                return Response.FromValue(Thing.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="action"> The String to use. </param>
        /// <param name="exEnum"> The ExtensibleEnum to use. </param>
        /// <param name="enum"> The SimpleEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="action"/> is null. </exception>
        public virtual Response<Thing> TopActionValue(string action, ExtensibleEnum exEnum, SimpleEnum? @enum = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(action, nameof(action));

            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopActionValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = TopAction(action, exEnum.ToString(), @enum?.ToSerialString(), context);
                return Response.FromValue(Thing.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="action"> The String to use. </param>
        /// <param name="exEnum"> The ExtensibleEnum to use. Allowed values: &quot;1&quot; | &quot;2&quot; | &quot;4&quot;. </param>
        /// <param name="enum"> The SimpleEnum to use. Allowed values: &quot;1&quot; | &quot;2&quot; | &quot;4&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="action"/> or <paramref name="exEnum"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call TopActionAsync with required parameters and parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new HelloWorldClient(endpoint, "<apiVersion>");
        /// 
        /// Response response = await client.TopActionAsync("<action>", "<exEnum>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("name").ToString());
        /// ]]></code>
        /// This sample shows how to call TopActionAsync with all parameters, and how to parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new HelloWorldClient(endpoint, "<apiVersion>");
        /// 
        /// Response response = await client.TopActionAsync("<action>", "<exEnum>", "<enum>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("name").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Thing</c>:
        /// <code>{
        ///   name: string, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> TopActionAsync(string action, string exEnum, string @enum = null, RequestContext context = null)
        {
            Argument.AssertNotNull(action, nameof(action));
            Argument.AssertNotNull(exEnum, nameof(exEnum));

            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopAction");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTopActionRequest(action, exEnum, @enum, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="action"> The String to use. </param>
        /// <param name="exEnum"> The ExtensibleEnum to use. Allowed values: &quot;1&quot; | &quot;2&quot; | &quot;4&quot;. </param>
        /// <param name="enum"> The SimpleEnum to use. Allowed values: &quot;1&quot; | &quot;2&quot; | &quot;4&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="action"/> or <paramref name="exEnum"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call TopAction with required parameters and parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new HelloWorldClient(endpoint, "<apiVersion>");
        /// 
        /// Response response = client.TopAction("<action>", "<exEnum>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("name").ToString());
        /// ]]></code>
        /// This sample shows how to call TopAction with all parameters, and how to parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new HelloWorldClient(endpoint, "<apiVersion>");
        /// 
        /// Response response = client.TopAction("<action>", "<exEnum>", "<enum>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("name").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Thing</c>:
        /// <code>{
        ///   name: string, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response TopAction(string action, string exEnum, string @enum = null, RequestContext context = null)
        {
            Argument.AssertNotNull(action, nameof(action));
            Argument.AssertNotNull(exEnum, nameof(exEnum));

            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopAction");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTopActionRequest(action, exEnum, @enum, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Thing>> TopAction2ValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopAction2Value");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await TopAction2Async(context).ConfigureAwait(false);
                return Response.FromValue(Thing.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Thing> TopAction2Value(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopAction2Value");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = TopAction2(context);
                return Response.FromValue(Thing.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call TopAction2Async and parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new HelloWorldClient(endpoint, "<apiVersion>");
        /// 
        /// Response response = await client.TopAction2Async();
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("name").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Thing</c>:
        /// <code>{
        ///   name: string, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> TopAction2Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopAction2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTopAction2Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call TopAction2 and parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new HelloWorldClient(endpoint, "<apiVersion>");
        /// 
        /// Response response = client.TopAction2();
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("name").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Thing</c>:
        /// <code>{
        ///   name: string, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response TopAction2(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopAction2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTopAction2Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateTopActionRequest(string action, string exEnum, string @enum, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            message.BufferResponse = false;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/partOfUri", false);
            uri.AppendPath("/top/", false);
            uri.AppendPath(action, false);
            uri.AppendQuery("exEnum", exEnum, true);
            uri.AppendQuery("apiVersion", _apiVersion, true);
            if (@enum != null)
            {
                uri.AppendQuery("enum", @enum, true);
            }
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateTopAction2Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            message.BufferResponse = false;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/partOfUri", false);
            uri.AppendPath("/top2", false);
            uri.AppendQuery("apiVersion", _apiVersion, true);
            request.Uri = uri;
            return message;
        }

        private static RequestContext DefaultRequestContext = new RequestContext();
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}