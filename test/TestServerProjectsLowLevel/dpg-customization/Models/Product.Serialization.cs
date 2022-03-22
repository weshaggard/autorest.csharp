// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace dpg_customization_LowLevel.Models
{
    public partial class Product
    {
        internal static Product DeserializeProduct(JsonElement element)
        {
            ProductReceived received = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("received"))
                {
                    received = new ProductReceived(property.Value.GetString());
                    continue;
                }
            }
            return new Product(received);
        }
    }
}