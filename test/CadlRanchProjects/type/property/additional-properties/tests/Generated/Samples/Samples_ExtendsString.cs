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
    public partial class Samples_ExtendsString
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsString_GetExtendsString_ShortVersion()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            Response response = client.GetExtendsString(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsString_GetExtendsString_ShortVersion_Async()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            Response response = await client.GetExtendsStringAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsString_GetExtendsString_ShortVersion_Convenience()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            Response<ExtendsStringAdditionalProperties> response = client.GetExtendsString();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsString_GetExtendsString_ShortVersion_Convenience_Async()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            Response<ExtendsStringAdditionalProperties> response = await client.GetExtendsStringAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsString_GetExtendsString_AllParameters()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            Response response = client.GetExtendsString(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsString_GetExtendsString_AllParameters_Async()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            Response response = await client.GetExtendsStringAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsString_GetExtendsString_AllParameters_Convenience()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            Response<ExtendsStringAdditionalProperties> response = client.GetExtendsString();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsString_GetExtendsString_AllParameters_Convenience_Async()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            Response<ExtendsStringAdditionalProperties> response = await client.GetExtendsStringAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsString_Put_ShortVersion()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsString_Put_ShortVersion_Async()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsString_Put_ShortVersion_Convenience()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            ExtendsStringAdditionalProperties body = new ExtendsStringAdditionalProperties("<name>");
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsString_Put_ShortVersion_Convenience_Async()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            ExtendsStringAdditionalProperties body = new ExtendsStringAdditionalProperties("<name>");
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsString_Put_AllParameters()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsString_Put_AllParameters_Async()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsString_Put_AllParameters_Convenience()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            ExtendsStringAdditionalProperties body = new ExtendsStringAdditionalProperties("<name>");
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsString_Put_AllParameters_Convenience_Async()
        {
            ExtendsString client = new AdditionalPropertiesClient().GetExtendsStringClient();

            ExtendsStringAdditionalProperties body = new ExtendsStringAdditionalProperties("<name>");
            Response response = await client.PutAsync(body);
        }
    }
}