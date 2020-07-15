// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Inheritance.Models
{
    /// <summary> The BaseClassWithExtensibleEnumDiscriminator. </summary>
    internal partial class BaseClassWithExtensibleEnumDiscriminator
    {
        /// <summary> Initializes a new instance of BaseClassWithExtensibleEnumDiscriminator. </summary>
        internal BaseClassWithExtensibleEnumDiscriminator()
        {
        }

        /// <summary> Initializes a new instance of BaseClassWithExtensibleEnumDiscriminator. </summary>
        /// <param name="discriminatorProperty"> . </param>
        internal BaseClassWithExtensibleEnumDiscriminator(BaseClassWithEntensibleEnumDiscriminatorEnum discriminatorProperty)
        {
            DiscriminatorProperty = discriminatorProperty;
        }

        internal BaseClassWithEntensibleEnumDiscriminatorEnum DiscriminatorProperty { get; set; }
    }
}