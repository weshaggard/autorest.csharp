// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class EntityRecognitionSkill : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Categories != null)
            {
                writer.WritePropertyName("categories");
                writer.WriteStartArray();
                foreach (var item in Categories)
                {
                    writer.WriteStringValue(item.ToSerialString());
                }
                writer.WriteEndArray();
            }
            if (DefaultLanguageCode != null)
            {
                writer.WritePropertyName("defaultLanguageCode");
                writer.WriteStringValue(DefaultLanguageCode.Value.ToString());
            }
            if (IncludeTypelessEntities != null)
            {
                writer.WritePropertyName("includeTypelessEntities");
                writer.WriteBooleanValue(IncludeTypelessEntities.Value);
            }
            if (MinimumPrecision != null)
            {
                writer.WritePropertyName("minimumPrecision");
                writer.WriteNumberValue(MinimumPrecision.Value);
            }
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            if (Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Description != null)
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            if (Context != null)
            {
                writer.WritePropertyName("context");
                writer.WriteStringValue(Context);
            }
            writer.WritePropertyName("inputs");
            writer.WriteStartArray();
            foreach (var item in Inputs)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("outputs");
            writer.WriteStartArray();
            foreach (var item0 in Outputs)
            {
                writer.WriteObjectValue(item0);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        internal static EntityRecognitionSkill DeserializeEntityRecognitionSkill(JsonElement element)
        {
            EntityRecognitionSkill result = new EntityRecognitionSkill();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("categories"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Categories = new List<EntityCategory>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Categories.Add(item.GetString().ToEntityCategory());
                    }
                    continue;
                }
                if (property.NameEquals("defaultLanguageCode"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DefaultLanguageCode = new EntityRecognitionSkillLanguage(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("includeTypelessEntities"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.IncludeTypelessEntities = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("minimumPrecision"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.MinimumPrecision = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("context"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Context = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("inputs"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Inputs.Add(InputFieldMappingEntry.DeserializeInputFieldMappingEntry(item));
                    }
                    continue;
                }
                if (property.NameEquals("outputs"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Outputs.Add(OutputFieldMappingEntry.DeserializeOutputFieldMappingEntry(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}