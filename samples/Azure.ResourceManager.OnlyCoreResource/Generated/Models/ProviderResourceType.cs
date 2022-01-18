// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.OnlyCoreResource.Models
{
    /// <summary> Resource type managed by the resource provider. </summary>
    public partial class ProviderResourceType
    {
        /// <summary> Initializes a new instance of ProviderResourceType. </summary>
        internal ProviderResourceType()
        {
            Locations = new ChangeTrackingList<string>();
            LocationMappings = new ChangeTrackingList<ProviderExtendedLocation>();
            Aliases = new ChangeTrackingList<Alias>();
            ApiVersions = new ChangeTrackingList<string>();
            ApiProfiles = new ChangeTrackingList<ApiProfile>();
            Properties = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of ProviderResourceType. </summary>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="locations"> The collection of locations where this resource type can be created. </param>
        /// <param name="locationMappings"> The location mappings that are supported by this resource type. </param>
        /// <param name="aliases"> The aliases that are supported by this resource type. </param>
        /// <param name="apiVersions"> The API version. </param>
        /// <param name="defaultApiVersion"> The default API version. </param>
        /// <param name="apiProfiles"> The API profiles for the resource provider. </param>
        /// <param name="capabilities"> The additional capabilities offered by this resource type. </param>
        /// <param name="properties"> The properties. </param>
        internal ProviderResourceType(string resourceType, IReadOnlyList<string> locations, IReadOnlyList<ProviderExtendedLocation> locationMappings, IReadOnlyList<Alias> aliases, IReadOnlyList<string> apiVersions, string defaultApiVersion, IReadOnlyList<ApiProfile> apiProfiles, string capabilities, IReadOnlyDictionary<string, string> properties)
        {
            ResourceType = resourceType;
            Locations = locations;
            LocationMappings = locationMappings;
            Aliases = aliases;
            ApiVersions = apiVersions;
            DefaultApiVersion = defaultApiVersion;
            ApiProfiles = apiProfiles;
            Capabilities = capabilities;
            Properties = properties;
        }

        /// <summary> The resource type. </summary>
        public string ResourceType { get; }
        /// <summary> The collection of locations where this resource type can be created. </summary>
        public IReadOnlyList<string> Locations { get; }
        /// <summary> The location mappings that are supported by this resource type. </summary>
        public IReadOnlyList<ProviderExtendedLocation> LocationMappings { get; }
        /// <summary> The aliases that are supported by this resource type. </summary>
        public IReadOnlyList<Alias> Aliases { get; }
        /// <summary> The API version. </summary>
        public IReadOnlyList<string> ApiVersions { get; }
        /// <summary> The default API version. </summary>
        public string DefaultApiVersion { get; }
        /// <summary> The API profiles for the resource provider. </summary>
        public IReadOnlyList<ApiProfile> ApiProfiles { get; }
        /// <summary> The additional capabilities offered by this resource type. </summary>
        public string Capabilities { get; }
        /// <summary> The properties. </summary>
        public IReadOnlyDictionary<string, string> Properties { get; }
    }
}