// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace paging.Models
{
    /// <summary> Parameter group. </summary>
    public partial class CustomParameterGroup
    {
        /// <summary> Initializes a new instance of CustomParameterGroup. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> or <paramref name="tenant"/> is null. </exception>
        public CustomParameterGroup(string apiVersion, string tenant)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            ApiVersion = apiVersion;
            Tenant = tenant;
        }

        /// <summary> Sets the api version to use. </summary>
        public string ApiVersion { get; }
        /// <summary> Sets the tenant to use. </summary>
        public string Tenant { get; }
    }
}