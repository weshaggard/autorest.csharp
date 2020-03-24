// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Storage.Management.Models
{
    /// <summary> The LegalHold property of a blob container. </summary>
    public partial class LegalHold
    {
        /// <summary> Initializes a new instance of LegalHold. </summary>
        /// <param name="tags"> Each tag should be 3 to 23 alphanumeric characters and is normalized to lower case at SRP. </param>
        public LegalHold(IList<string> tags)
        {
            Tags = tags;
        }

        /// <summary> Initializes a new instance of LegalHold. </summary>
        /// <param name="hasLegalHold"> The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers with hasLegalHold=true for a given account. </param>
        /// <param name="tags"> Each tag should be 3 to 23 alphanumeric characters and is normalized to lower case at SRP. </param>
        internal LegalHold(bool? hasLegalHold, IList<string> tags)
        {
            HasLegalHold = hasLegalHold;
            Tags = tags;
        }

        /// <summary> The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers with hasLegalHold=true for a given account. </summary>
        public bool? HasLegalHold { get; }
        /// <summary> Each tag should be 3 to 23 alphanumeric characters and is normalized to lower case at SRP. </summary>
        public IList<string> Tags { get; }
    }
}
