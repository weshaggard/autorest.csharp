// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class representing collection of FakeParentWithAncestorWithNonResCh and their operations over a Fake. </summary>
    public partial class FakeParentWithAncestorWithNonResChContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly FakeParentWithAncestorWithNonResChesRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorWithNonResChContainer"/> class for mocking. </summary>
        protected FakeParentWithAncestorWithNonResChContainer()
        {
        }

        /// <summary> Initializes a new instance of FakeParentWithAncestorWithNonResChContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal FakeParentWithAncestorWithNonResChContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new FakeParentWithAncestorWithNonResChesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => Fake.ResourceType;

        // Container level operations.

        /// <summary> Create or update. </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<FakeParentWithAncestorWithNonResCh> CreateOrUpdate(string fakeParentWithAncestorWithNonResChName, FakeParentWithAncestorWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(fakeParentWithAncestorWithNonResChName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<FakeParentWithAncestorWithNonResCh>> CreateOrUpdateAsync(string fakeParentWithAncestorWithNonResChName, FakeParentWithAncestorWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(fakeParentWithAncestorWithNonResChName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual FakeParentWithAncestorWithNonResChCreateOrUpdateOperation StartCreateOrUpdate(string fakeParentWithAncestorWithNonResChName, FakeParentWithAncestorWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.Name, fakeParentWithAncestorWithNonResChName, parameters, cancellationToken);
                return new FakeParentWithAncestorWithNonResChCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<FakeParentWithAncestorWithNonResChCreateOrUpdateOperation> StartCreateOrUpdateAsync(string fakeParentWithAncestorWithNonResChName, FakeParentWithAncestorWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.Name, fakeParentWithAncestorWithNonResChName, parameters, cancellationToken).ConfigureAwait(false);
                return new FakeParentWithAncestorWithNonResChCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<FakeParentWithAncestorWithNonResCh> Get(string fakeParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.Get");
            scope.Start();
            try
            {
                if (fakeParentWithAncestorWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentWithAncestorWithNonResChName));
                }

                var response = _restClient.Get(Id.Name, fakeParentWithAncestorWithNonResChName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithNonResCh(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<FakeParentWithAncestorWithNonResCh>> GetAsync(string fakeParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.Get");
            scope.Start();
            try
            {
                if (fakeParentWithAncestorWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentWithAncestorWithNonResChName));
                }

                var response = await _restClient.GetAsync(Id.Name, fakeParentWithAncestorWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new FakeParentWithAncestorWithNonResCh(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<FakeParentWithAncestorWithNonResCh> GetIfExists(string fakeParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.GetIfExists");
            scope.Start();
            try
            {
                if (fakeParentWithAncestorWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentWithAncestorWithNonResChName));
                }

                var response = _restClient.Get(Id.Name, fakeParentWithAncestorWithNonResChName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<FakeParentWithAncestorWithNonResCh>(null, response.GetRawResponse())
                    : Response.FromValue(new FakeParentWithAncestorWithNonResCh(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<FakeParentWithAncestorWithNonResCh>> GetIfExistsAsync(string fakeParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.GetIfExists");
            scope.Start();
            try
            {
                if (fakeParentWithAncestorWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentWithAncestorWithNonResChName));
                }

                var response = await _restClient.GetAsync(Id.Name, fakeParentWithAncestorWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<FakeParentWithAncestorWithNonResCh>(null, response.GetRawResponse())
                    : Response.FromValue(new FakeParentWithAncestorWithNonResCh(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string fakeParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (fakeParentWithAncestorWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentWithAncestorWithNonResChName));
                }

                var response = GetIfExists(fakeParentWithAncestorWithNonResChName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string fakeParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (fakeParentWithAncestorWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentWithAncestorWithNonResChName));
                }

                var response = await GetIfExistsAsync(fakeParentWithAncestorWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<FakeParentWithAncestorWithNonResCh> GetAll(CancellationToken cancellationToken = default)
        {
            Page<FakeParentWithAncestorWithNonResCh> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetTest(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestorWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<FakeParentWithAncestorWithNonResCh> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetTestNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestorWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<FakeParentWithAncestorWithNonResCh> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<FakeParentWithAncestorWithNonResCh>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetTestAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestorWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<FakeParentWithAncestorWithNonResCh>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetTestNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestorWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="FakeParentWithAncestorWithNonResCh" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(FakeParentWithAncestorWithNonResCh.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="FakeParentWithAncestorWithNonResCh" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(FakeParentWithAncestorWithNonResCh.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, FakeParentWithAncestorWithNonResCh, FakeParentWithAncestorWithNonResChData> Construct() { }
    }
}