// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ModelShapes.Models
{
    /// <summary> The InputModel. </summary>
    public partial class InputModel
    {
        /// <summary> Initializes a new instance of InputModel. </summary>
        /// <param name="requiredString"> . </param>
        /// <param name="requiredInt"> . </param>
        /// <param name="requiredStringList"> . </param>
        /// <param name="requiredIntList"> . </param>
        /// <param name="requiredNullableString"> . </param>
        /// <param name="requiredNullableInt"> . </param>
        /// <param name="requiredNullableStringList"> . </param>
        /// <param name="requiredNullableIntList"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/>, <paramref name="requiredStringList"/>, or <paramref name="requiredIntList"/> is null. </exception>
        public InputModel(string requiredString, int requiredInt, IEnumerable<string> requiredStringList, IEnumerable<int> requiredIntList, string requiredNullableString, int? requiredNullableInt, IEnumerable<string> requiredNullableStringList, IEnumerable<int> requiredNullableIntList)
        {
            if (requiredString == null)
            {
                throw new ArgumentNullException(nameof(requiredString));
            }
            if (requiredStringList == null)
            {
                throw new ArgumentNullException(nameof(requiredStringList));
            }
            if (requiredIntList == null)
            {
                throw new ArgumentNullException(nameof(requiredIntList));
            }

            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredStringList = requiredStringList.ToList();
            RequiredIntList = requiredIntList.ToList();
            NonRequiredStringList = new ChangeTrackingList<string>();
            NonRequiredIntList = new ChangeTrackingList<int>();
            RequiredNullableString = requiredNullableString;
            RequiredNullableInt = requiredNullableInt;
            RequiredNullableStringList = requiredNullableStringList?.ToList();
            RequiredNullableIntList = requiredNullableIntList?.ToList();
            NonRequiredNullableStringList = new ChangeTrackingList<string>();
            NonRequiredNullableIntList = new ChangeTrackingList<int>();
        }

        public string RequiredString { get; }
        public int RequiredInt { get; }
        public IList<string> RequiredStringList { get; }
        public IList<int> RequiredIntList { get; }
        public string NonRequiredString { get; set; }
        public int? NonRequiredInt { get; set; }
        public IList<string> NonRequiredStringList { get; }
        public IList<int> NonRequiredIntList { get; }
        public string RequiredNullableString { get; }
        public int? RequiredNullableInt { get; }
        public IList<string> RequiredNullableStringList { get; set; }
        public IList<int> RequiredNullableIntList { get; set; }
        public string NonRequiredNullableString { get; set; }
        public int? NonRequiredNullableInt { get; set; }
        public IList<string> NonRequiredNullableStringList { get; set; }
        public IList<int> NonRequiredNullableIntList { get; set; }
    }
}