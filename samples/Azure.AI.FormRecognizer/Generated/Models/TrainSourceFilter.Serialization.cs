// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.AI.FormRecognizer;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class TrainSourceFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Prefix))
            {
                writer.WritePropertyName("prefix"u8);
                writer.WriteStringValue(Prefix);
            }
            if (Optional.IsDefined(IncludeSubFolders))
            {
                writer.WritePropertyName("includeSubFolders"u8);
                writer.WriteBooleanValue(IncludeSubFolders.Value);
            }
            writer.WriteEndObject();
        }
    }
}
