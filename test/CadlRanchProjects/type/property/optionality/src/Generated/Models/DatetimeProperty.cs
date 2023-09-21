// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace _Type.Property.Optionality.Models
{
    /// <summary> Model with a datetime property. </summary>
    public partial class DatetimeProperty
    {
        /// <summary> Initializes a new instance of DatetimeProperty. </summary>
        public DatetimeProperty()
        {
        }

        /// <summary> Initializes a new instance of DatetimeProperty. </summary>
        /// <param name="property"> Property. </param>
        internal DatetimeProperty(DateTimeOffset? property)
        {
            Property = property;
        }

        /// <summary> Property. </summary>
        public DateTimeOffset? Property { get; set; }
    }
}