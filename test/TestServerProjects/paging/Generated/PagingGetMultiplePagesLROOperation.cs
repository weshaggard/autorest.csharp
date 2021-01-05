// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using paging.Models;

namespace paging
{
    /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
    public partial class PagingGetMultiplePagesLROOperation : Operation<AsyncPageable<Product>>, IOperationSource<AsyncPageable<Product>>
    {
        private readonly ArmOperationHelpers<AsyncPageable<Product>> _operation;
        private readonly Func<string, Task<Response>> _nextPageFunc;
        internal PagingGetMultiplePagesLROOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, Func<string, Task<Response>> nextPageFunc)
        {
            _operation = new ArmOperationHelpers<AsyncPageable<Product>>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "PagingGetMultiplePagesLROOperation");
            _nextPageFunc = nextPageFunc;
        }
        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override AsyncPageable<Product> Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<AsyncPageable<Product>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<AsyncPageable<Product>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        AsyncPageable<Product> IOperationSource<AsyncPageable<Product>>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            ProductResult firstPageResult;
            using var document = JsonDocument.Parse(response.ContentStream);
            firstPageResult = ProductResult.DeserializeProductResult(document.RootElement);
            Page<Product> firstPage = Page.FromValues(firstPageResult.Values, firstPageResult.NextLink, response);

            return PageableHelpers.CreateAsyncEnumerable(_ => Task.FromResult(firstPage), (nextLink, _) => GetNextPage(nextLink, cancellationToken));
        }

        async ValueTask<AsyncPageable<Product>> IOperationSource<AsyncPageable<Product>>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            ProductResult firstPageResult;
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            firstPageResult = ProductResult.DeserializeProductResult(document.RootElement);
            Page<Product> firstPage = Page.FromValues(firstPageResult.Values, firstPageResult.NextLink, response);

            return PageableHelpers.CreateAsyncEnumerable(_ => Task.FromResult(firstPage), (nextLink, _) => GetNextPage(nextLink, cancellationToken));
        }

        private async Task<Page<Product>> GetNextPage(string nextLink, CancellationToken cancellationToken)
        {
            Response response = await _nextPageFunc(nextLink).ConfigureAwait(false);
            ProductResult nextPageResult;
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            nextPageResult = ProductResult.DeserializeProductResult(document.RootElement);
            return Page.FromValues(nextPageResult.Values, nextPageResult.NextLink, response);
        }
    }
}