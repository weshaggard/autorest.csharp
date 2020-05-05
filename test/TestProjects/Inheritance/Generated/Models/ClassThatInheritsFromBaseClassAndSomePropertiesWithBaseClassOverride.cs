// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Inheritance.Models
{
    /// <summary> The ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride. </summary>
    internal partial class ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride : SomeProperties
    {
        /// <summary> Initializes a new instance of ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride. </summary>
        internal ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride()
        {
        }

        /// <summary> Initializes a new instance of ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride. </summary>
        /// <param name="someProperty"> . </param>
        /// <param name="someOtherProperty"> . </param>
        /// <param name="baseClassProperty"> . </param>
        internal ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride(string someProperty, string someOtherProperty, string baseClassProperty) : base(someProperty, someOtherProperty)
        {
            BaseClassProperty = baseClassProperty;
        }

        public string BaseClassProperty { get; set; }
    }
}