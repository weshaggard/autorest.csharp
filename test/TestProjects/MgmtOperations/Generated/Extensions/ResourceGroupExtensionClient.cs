// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using MgmtOperations.Models;

namespace MgmtOperations
{
    /// <summary> An internal class to add extension methods to. </summary>
    internal partial class ResourceGroupExtensionClient : ArmResource
    {
        private ClientDiagnostics _availabilitySetClientDiagnostics;
        private AvailabilitySetsRestOperations _availabilitySetRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupExtensionClient(ArmClient armClient, ResourceIdentifier id) : base(armClient, id)
        {
        }

        private ClientDiagnostics AvailabilitySetClientDiagnostics => _availabilitySetClientDiagnostics ??= new ClientDiagnostics("MgmtOperations", AvailabilitySet.ResourceType.Namespace, DiagnosticOptions);
        private AvailabilitySetsRestOperations AvailabilitySetRestClient => _availabilitySetRestClient ??= new AvailabilitySetsRestOperations(AvailabilitySetClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(AvailabilitySet.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            ArmClient.TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/patchAvailabilitySets
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: AvailabilitySets_TestLROMethod
        /// <summary> Update an availability set. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<TestLROMethodAvailabilitySetOperation> TestLROMethodAvailabilitySetAsync(bool waitForCompletion, AvailabilitySetUpdate parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = AvailabilitySetClientDiagnostics.CreateScope("ResourceGroupExtensionClient.TestLROMethodAvailabilitySet");
            scope.Start();
            try
            {
                var response = await AvailabilitySetRestClient.TestLROMethodAsync(Id.SubscriptionId, Id.ResourceGroupName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new TestLROMethodAvailabilitySetOperation(AvailabilitySetClientDiagnostics, Pipeline, AvailabilitySetRestClient.CreateTestLROMethodRequest(Id.SubscriptionId, Id.ResourceGroupName, parameters).Request, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/patchAvailabilitySets
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: AvailabilitySets_TestLROMethod
        /// <summary> Update an availability set. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual TestLROMethodAvailabilitySetOperation TestLROMethodAvailabilitySet(bool waitForCompletion, AvailabilitySetUpdate parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = AvailabilitySetClientDiagnostics.CreateScope("ResourceGroupExtensionClient.TestLROMethodAvailabilitySet");
            scope.Start();
            try
            {
                var response = AvailabilitySetRestClient.TestLROMethod(Id.SubscriptionId, Id.ResourceGroupName, parameters, cancellationToken);
                var operation = new TestLROMethodAvailabilitySetOperation(AvailabilitySetClientDiagnostics, Pipeline, AvailabilitySetRestClient.CreateTestLROMethodRequest(Id.SubscriptionId, Id.ResourceGroupName, parameters).Request, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}