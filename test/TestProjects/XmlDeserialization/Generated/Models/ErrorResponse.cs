// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace XmlDeserialization.Models
{
    /// <summary> Error Response. </summary>
    internal partial class ErrorResponse
    {
        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        internal ErrorResponse()
        {
        }

        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        /// <param name="code"> Service-defined error code. This code serves as a sub-status for the HTTP error code specified in the response. </param>
        /// <param name="message"> Human-readable representation of the error. </param>
        internal ErrorResponse(string code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary> Service-defined error code. This code serves as a sub-status for the HTTP error code specified in the response. </summary>
        public string Code { get; }
        /// <summary> Human-readable representation of the error. </summary>
        public string Message { get; }
    }
}