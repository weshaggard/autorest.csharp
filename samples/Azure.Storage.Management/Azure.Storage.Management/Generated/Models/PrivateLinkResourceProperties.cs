// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Storage.Management.Models
{
    /// <summary> Properties of a private link resource. </summary>
    public partial class PrivateLinkResourceProperties
    {
        /// <summary> The private link resource group id. </summary>
        public string GroupId { get; internal set; }
        /// <summary> The private link resource required member names. </summary>
        public IList<string> RequiredMembers { get; internal set; }
        /// <summary> The private link resource Private link DNS zone name. </summary>
        public IList<string> RequiredZoneNames { get; set; }
    }
}
