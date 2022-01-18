// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.OnlyCoreResource.Models
{
    internal static partial class DeploymentModeExtensions
    {
        public static string ToSerialString(this DeploymentMode value) => value switch
        {
            DeploymentMode.Incremental => "Incremental",
            DeploymentMode.Complete => "Complete",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown DeploymentMode value.")
        };

        public static DeploymentMode ToDeploymentMode(this string value)
        {
            if (string.Equals(value, "Incremental", StringComparison.InvariantCultureIgnoreCase)) return DeploymentMode.Incremental;
            if (string.Equals(value, "Complete", StringComparison.InvariantCultureIgnoreCase)) return DeploymentMode.Complete;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown DeploymentMode value.");
        }
    }
}