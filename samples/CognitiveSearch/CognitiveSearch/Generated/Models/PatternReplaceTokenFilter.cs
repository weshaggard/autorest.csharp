// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> A character filter that replaces characters in the input string. It uses a regular expression to identify character sequences to preserve and a replacement pattern to identify characters to replace. For example, given the input text &quot;aa bb aa bb&quot;, pattern &quot;(aa)\s+(bb)&quot;, and replacement &quot;$1#$2&quot;, the result would be &quot;aa#bb aa#bb&quot;. This token filter is implemented using Apache Lucene. </summary>
    public partial class PatternReplaceTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of PatternReplaceTokenFilter. </summary>
        public PatternReplaceTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.PatternReplaceTokenFilter";
        }
        /// <summary> A regular expression pattern. </summary>
        public string Pattern { get; set; }
        /// <summary> The replacement text. </summary>
        public string Replacement { get; set; }
    }
}