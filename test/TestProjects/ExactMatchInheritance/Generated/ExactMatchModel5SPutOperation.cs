// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace ExactMatchInheritance
{
    public partial class ExactMatchModel5SPutOperation : Operation<ExactMatchModel5>
    {
        private readonly OperationOrResponseInternals<ExactMatchModel5> _operation;

        /// <summary> Initializes a new instance of ExactMatchModel5SPutOperation for mocking. </summary>
        protected ExactMatchModel5SPutOperation()
        {
        }

        internal ExactMatchModel5SPutOperation(ResourceOperationsBase operationsBase, Response<ExactMatchModel5Data> response)
        {
            _operation = new OperationOrResponseInternals<ExactMatchModel5>(Response.FromValue(new ExactMatchModel5(operationsBase, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override ExactMatchModel5 Value => _operation.Value;

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
        public override ValueTask<Response<ExactMatchModel5>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<ExactMatchModel5>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}