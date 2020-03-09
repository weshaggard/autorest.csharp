// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> PrivateLinkConnection properties for the network interface. </summary>
    public partial class NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties
    {
        /// <summary> The group ID for current private link connection. </summary>
        public string GroupId { get; internal set; }
        /// <summary> The required member name for current private link connection. </summary>
        public string RequiredMemberName { get; internal set; }
        /// <summary> List of FQDNs for current private link connection. </summary>
        public IList<string> Fqdns { get; internal set; }
    }
}
