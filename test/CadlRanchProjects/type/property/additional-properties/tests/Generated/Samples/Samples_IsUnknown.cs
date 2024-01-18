// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.AdditionalProperties;
using _Type.Property.AdditionalProperties.Models;

namespace _Type.Property.AdditionalProperties.Samples
{
    public partial class Samples_IsUnknown
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsUnknown_GetIsUnknown_ShortVersion()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            Response response = client.GetIsUnknown(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsUnknown_GetIsUnknown_ShortVersion_Async()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            Response response = await client.GetIsUnknownAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsUnknown_GetIsUnknown_ShortVersion_Convenience()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            Response<IsUnknownAdditionalProperties> response = client.GetIsUnknown();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsUnknown_GetIsUnknown_ShortVersion_Convenience_Async()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            Response<IsUnknownAdditionalProperties> response = await client.GetIsUnknownAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsUnknown_GetIsUnknown_AllParameters()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            Response response = client.GetIsUnknown(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsUnknown_GetIsUnknown_AllParameters_Async()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            Response response = await client.GetIsUnknownAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsUnknown_GetIsUnknown_AllParameters_Convenience()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            Response<IsUnknownAdditionalProperties> response = client.GetIsUnknown();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsUnknown_GetIsUnknown_AllParameters_Convenience_Async()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            Response<IsUnknownAdditionalProperties> response = await client.GetIsUnknownAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsUnknown_Put_ShortVersion()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsUnknown_Put_ShortVersion_Async()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsUnknown_Put_ShortVersion_Convenience()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            IsUnknownAdditionalProperties body = new IsUnknownAdditionalProperties("<name>");
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsUnknown_Put_ShortVersion_Convenience_Async()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            IsUnknownAdditionalProperties body = new IsUnknownAdditionalProperties("<name>");
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsUnknown_Put_AllParameters()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsUnknown_Put_AllParameters_Async()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IsUnknown_Put_AllParameters_Convenience()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            IsUnknownAdditionalProperties body = new IsUnknownAdditionalProperties("<name>");
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IsUnknown_Put_AllParameters_Convenience_Async()
        {
            IsUnknown client = new AdditionalPropertiesClient().GetIsUnknownClient();

            IsUnknownAdditionalProperties body = new IsUnknownAdditionalProperties("<name>");
            Response response = await client.PutAsync(body);
        }
    }
}