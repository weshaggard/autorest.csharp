// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using CognitiveSearch;

namespace CognitiveSearch.Models
{
    public partial class PhoneticTokenFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Encoder))
            {
                writer.WritePropertyName("encoder"u8);
                writer.WriteStringValue(Encoder.Value.ToSerialString());
            }
            if (Optional.IsDefined(ReplaceOriginalTokens))
            {
                writer.WritePropertyName("replace"u8);
                writer.WriteBooleanValue(ReplaceOriginalTokens.Value);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static PhoneticTokenFilter DeserializePhoneticTokenFilter(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            PhoneticEncoder? encoder = default;
            bool? replace = default;
            string odataType = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("encoder"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    encoder = property.Value.GetString().ToPhoneticEncoder();
                    continue;
                }
                if (property.NameEquals("replace"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    replace = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new PhoneticTokenFilter(odataType, name, encoder, replace);
        }
    }
}
