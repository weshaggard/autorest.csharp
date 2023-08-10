// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace _Type.Model.Inheritance.SingleDiscriminator.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class TypeModelInheritanceSingleDiscriminatorModelFactory
    {
        /// <summary> Initializes a new instance of Dinosaur. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="size"></param>
        /// <returns> A new <see cref="Models.Dinosaur"/> instance for mocking. </returns>
        public static Dinosaur Dinosaur(string kind = null, int size = default)
        {
            return new UnknownDinosaur(kind, size);
        }

        /// <summary> Initializes a new instance of TRex. </summary>
        /// <param name="size"></param>
        /// <returns> A new <see cref="Models.TRex"/> instance for mocking. </returns>
        public static TRex TRex(int size = default)
        {
            return new TRex("t-rex", size);
        }
    }
}