// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class SentimentResponse
    {
        internal static SentimentResponse DeserializeSentimentResponse(JsonElement element)
        {
            IReadOnlyList<DocumentSentiment> documents = default;
            IReadOnlyList<DocumentError> errors = default;
            RequestStatistics statistics = default;
            string modelVersion = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("documents"))
                {
                    List<DocumentSentiment> array = new List<DocumentSentiment>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DocumentSentiment.DeserializeDocumentSentiment(item));
                    }
                    documents = array;
                    continue;
                }
                if (property.NameEquals("errors"))
                {
                    List<DocumentError> array = new List<DocumentError>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DocumentError.DeserializeDocumentError(item));
                    }
                    errors = array;
                    continue;
                }
                if (property.NameEquals("statistics"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    statistics = RequestStatistics.DeserializeRequestStatistics(property.Value);
                    continue;
                }
                if (property.NameEquals("modelVersion"))
                {
                    modelVersion = property.Value.GetString();
                    continue;
                }
            }
            return new SentimentResponse(documents, errors, statistics, modelVersion);
        }
    }
}
