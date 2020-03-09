// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Storage.Management.Models
{
    /// <summary> Properties of the storage account. </summary>
    public partial class StorageAccountProperties
    {
        /// <summary> Gets the status of the storage account at the time the operation was called. </summary>
        public ProvisioningState? ProvisioningState { get; internal set; }
        /// <summary> Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object. Note that Standard_ZRS and Premium_LRS accounts only return the blob endpoint. </summary>
        public Endpoints PrimaryEndpoints { get; internal set; }
        /// <summary> Gets the location of the primary data center for the storage account. </summary>
        public string PrimaryLocation { get; internal set; }
        /// <summary> Gets the status indicating whether the primary location of the storage account is available or unavailable. </summary>
        public AccountStatus? StatusOfPrimary { get; internal set; }
        /// <summary> Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp is retained. This element is not returned if there has never been a failover instance. Only available if the accountType is Standard_GRS or Standard_RAGRS. </summary>
        public DateTimeOffset? LastGeoFailoverTime { get; internal set; }
        /// <summary> Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS or Standard_RAGRS. </summary>
        public string SecondaryLocation { get; internal set; }
        /// <summary> Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available if the SKU name is Standard_GRS or Standard_RAGRS. </summary>
        public AccountStatus? StatusOfSecondary { get; internal set; }
        /// <summary> Gets the creation date and time of the storage account in UTC. </summary>
        public DateTimeOffset? CreationTime { get; internal set; }
        /// <summary> Gets the custom domain the user assigned to this storage account. </summary>
        public CustomDomain CustomDomain { get; internal set; }
        /// <summary> Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object from the secondary location of the storage account. Only available if the SKU name is Standard_RAGRS. </summary>
        public Endpoints SecondaryEndpoints { get; internal set; }
        /// <summary> Gets the encryption settings on the account. If unspecified, the account is unencrypted. </summary>
        public Encryption Encryption { get; internal set; }
        /// <summary> Required for storage accounts where kind = BlobStorage. The access tier used for billing. </summary>
        public AccessTier? AccessTier { get; internal set; }
        /// <summary> Provides the identity based authentication settings for Azure Files. </summary>
        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }
        /// <summary> Allows https traffic only to storage service if sets to true. </summary>
        public bool? EnableHttpsTrafficOnly { get; set; }
        /// <summary> Network rule set. </summary>
        public NetworkRuleSet NetworkRuleSet { get; internal set; }
        /// <summary> Account HierarchicalNamespace enabled if sets to true. </summary>
        public bool? IsHnsEnabled { get; set; }
        /// <summary> Geo Replication Stats. </summary>
        public GeoReplicationStats GeoReplicationStats { get; internal set; }
        /// <summary> If the failover is in progress, the value will be true, otherwise, it will be null. </summary>
        public bool? FailoverInProgress { get; internal set; }
        /// <summary> Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled. </summary>
        public LargeFileSharesState? LargeFileSharesState { get; set; }
        /// <summary> List of private endpoint connection associated with the specified storage account. </summary>
        public IList<PrivateEndpointConnection> PrivateEndpointConnections { get; internal set; }
        /// <summary> Maintains information about the network routing choice opted by the user for data transfer. </summary>
        public RoutingPreference RoutingPreference { get; set; }
        /// <summary> Blob restore status. </summary>
        public BlobRestoreStatus BlobRestoreStatus { get; internal set; }
    }
}
