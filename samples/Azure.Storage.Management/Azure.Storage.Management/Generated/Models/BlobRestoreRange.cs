// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Storage.Management.Models
{
    /// <summary> Blob range. </summary>
    public partial class BlobRestoreRange
    {
        /// <summary> Blob start range. Empty means account start. </summary>
        public string StartRange { get; set; }
        /// <summary> Blob end range. Empty means account end. </summary>
        public string EndRange { get; set; }
    }
}