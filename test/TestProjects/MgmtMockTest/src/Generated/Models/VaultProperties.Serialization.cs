// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockTest.Models
{
    public partial class VaultProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Duration))
            {
                writer.WritePropertyName("duration");
                writer.WriteStringValue(Duration.Value, "P");
            }
            if (Optional.IsDefined(CreateOn))
            {
                writer.WritePropertyName("createOn");
                writer.WriteStringValue(CreateOn.Value, "O");
            }
            writer.WritePropertyName("tenantId");
            writer.WriteStringValue(TenantId);
            writer.WritePropertyName("sku");
            writer.WriteObjectValue(Sku);
            if (Optional.IsCollectionDefined(AccessPolicies))
            {
                writer.WritePropertyName("accessPolicies");
                writer.WriteStartArray();
                foreach (var item in AccessPolicies)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(VaultUri))
            {
                writer.WritePropertyName("vaultUri");
                writer.WriteStringValue(VaultUri.AbsoluteUri);
            }
            if (Optional.IsCollectionDefined(Deployments))
            {
                writer.WritePropertyName("deployments");
                writer.WriteStartArray();
                foreach (var item in Deployments)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(EnabledForDiskEncryption))
            {
                writer.WritePropertyName("enabledForDiskEncryption");
                writer.WriteBooleanValue(EnabledForDiskEncryption.Value);
            }
            if (Optional.IsDefined(EnabledForTemplateDeployment))
            {
                writer.WritePropertyName("enabledForTemplateDeployment");
                writer.WriteBooleanValue(EnabledForTemplateDeployment.Value);
            }
            if (Optional.IsDefined(EnableSoftDelete))
            {
                writer.WritePropertyName("enableSoftDelete");
                writer.WriteBooleanValue(EnableSoftDelete.Value);
            }
            if (Optional.IsDefined(SoftDeleteRetentionInDays))
            {
                writer.WritePropertyName("softDeleteRetentionInDays");
                writer.WriteNumberValue(SoftDeleteRetentionInDays.Value);
            }
            if (Optional.IsDefined(EnableRbacAuthorization))
            {
                writer.WritePropertyName("enableRbacAuthorization");
                writer.WriteBooleanValue(EnableRbacAuthorization.Value);
            }
            if (Optional.IsDefined(CreateMode))
            {
                writer.WritePropertyName("createMode");
                writer.WriteStringValue(CreateMode.Value.ToSerialString());
            }
            if (Optional.IsDefined(EnablePurgeProtection))
            {
                writer.WritePropertyName("enablePurgeProtection");
                writer.WriteBooleanValue(EnablePurgeProtection.Value);
            }
            if (Optional.IsDefined(NetworkAcls))
            {
                writer.WritePropertyName("networkAcls");
                writer.WriteObjectValue(NetworkAcls);
            }
            if (Optional.IsDefined(ProvisioningState))
            {
                writer.WritePropertyName("provisioningState");
                writer.WriteStringValue(ProvisioningState.Value.ToString());
            }
            if (Optional.IsDefined(PublicNetworkAccess))
            {
                writer.WritePropertyName("publicNetworkAccess");
                writer.WriteStringValue(PublicNetworkAccess);
            }
            if (Optional.IsDefined(ReadWriteSingleStringProperty))
            {
                writer.WritePropertyName("readWriteSingleStringProperty");
                writer.WriteObjectValue(ReadWriteSingleStringProperty);
            }
            if (Optional.IsDefined(ReadOnlySingleStringProperty))
            {
                writer.WritePropertyName("readOnlySingleStringProperty");
                writer.WriteObjectValue(ReadOnlySingleStringProperty);
            }
            if (Optional.IsDefined(ExtremelyDeepStringProperty))
            {
                writer.WritePropertyName("extremelyDeepStringProperty");
                writer.WriteObjectValue(ExtremelyDeepStringProperty);
            }
            writer.WriteEndObject();
        }

        internal static VaultProperties DeserializeVaultProperties(JsonElement element)
        {
            Optional<TimeSpan> duration = default;
            Optional<DateTimeOffset> createOn = default;
            Guid tenantId = default;
            MgmtMockTestSku sku = default;
            Optional<IList<AccessPolicyEntry>> accessPolicies = default;
            Optional<Uri> vaultUri = default;
            Optional<string> hsmPoolResourceId = default;
            Optional<IList<string>> deployments = default;
            Optional<bool> enabledForDiskEncryption = default;
            Optional<bool> enabledForTemplateDeployment = default;
            Optional<bool> enableSoftDelete = default;
            Optional<int> softDeleteRetentionInDays = default;
            Optional<bool> enableRbacAuthorization = default;
            Optional<CreateMode> createMode = default;
            Optional<bool> enablePurgeProtection = default;
            Optional<NetworkRuleSet> networkAcls = default;
            Optional<VaultProvisioningState> provisioningState = default;
            Optional<IReadOnlyList<PrivateEndpointConnectionItem>> privateEndpointConnections = default;
            Optional<string> publicNetworkAccess = default;
            Optional<SinglePropertyModel> readWriteSingleStringProperty = default;
            Optional<ReadOnlySinglePropertyModel> readOnlySingleStringProperty = default;
            Optional<ExtremelyDeepSinglePropertyModel> extremelyDeepStringProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("duration"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    duration = property.Value.GetTimeSpan("P");
                    continue;
                }
                if (property.NameEquals("createOn"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    createOn = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("tenantId"))
                {
                    tenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("sku"))
                {
                    sku = MgmtMockTestSku.DeserializeMgmtMockTestSku(property.Value);
                    continue;
                }
                if (property.NameEquals("accessPolicies"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<AccessPolicyEntry> array = new List<AccessPolicyEntry>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AccessPolicyEntry.DeserializeAccessPolicyEntry(item));
                    }
                    accessPolicies = array;
                    continue;
                }
                if (property.NameEquals("vaultUri"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        vaultUri = null;
                        continue;
                    }
                    vaultUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("hsmPoolResourceId"))
                {
                    hsmPoolResourceId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("deployments"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    deployments = array;
                    continue;
                }
                if (property.NameEquals("enabledForDiskEncryption"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    enabledForDiskEncryption = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("enabledForTemplateDeployment"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    enabledForTemplateDeployment = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("enableSoftDelete"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    enableSoftDelete = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("softDeleteRetentionInDays"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    softDeleteRetentionInDays = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("enableRbacAuthorization"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    enableRbacAuthorization = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("createMode"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    createMode = property.Value.GetString().ToCreateMode();
                    continue;
                }
                if (property.NameEquals("enablePurgeProtection"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    enablePurgeProtection = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("networkAcls"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    networkAcls = NetworkRuleSet.DeserializeNetworkRuleSet(property.Value);
                    continue;
                }
                if (property.NameEquals("provisioningState"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    provisioningState = new VaultProvisioningState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("privateEndpointConnections"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<PrivateEndpointConnectionItem> array = new List<PrivateEndpointConnectionItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PrivateEndpointConnectionItem.DeserializePrivateEndpointConnectionItem(item));
                    }
                    privateEndpointConnections = array;
                    continue;
                }
                if (property.NameEquals("publicNetworkAccess"))
                {
                    publicNetworkAccess = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("readWriteSingleStringProperty"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    readWriteSingleStringProperty = SinglePropertyModel.DeserializeSinglePropertyModel(property.Value);
                    continue;
                }
                if (property.NameEquals("readOnlySingleStringProperty"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    readOnlySingleStringProperty = ReadOnlySinglePropertyModel.DeserializeReadOnlySinglePropertyModel(property.Value);
                    continue;
                }
                if (property.NameEquals("extremelyDeepStringProperty"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    extremelyDeepStringProperty = ExtremelyDeepSinglePropertyModel.DeserializeExtremelyDeepSinglePropertyModel(property.Value);
                    continue;
                }
            }
            return new VaultProperties(Optional.ToNullable(duration), Optional.ToNullable(createOn), tenantId, sku, Optional.ToList(accessPolicies), vaultUri.Value, hsmPoolResourceId.Value, Optional.ToList(deployments), Optional.ToNullable(enabledForDiskEncryption), Optional.ToNullable(enabledForTemplateDeployment), Optional.ToNullable(enableSoftDelete), Optional.ToNullable(softDeleteRetentionInDays), Optional.ToNullable(enableRbacAuthorization), Optional.ToNullable(createMode), Optional.ToNullable(enablePurgeProtection), networkAcls.Value, Optional.ToNullable(provisioningState), Optional.ToList(privateEndpointConnections), publicNetworkAccess.Value, readWriteSingleStringProperty.Value, readOnlySingleStringProperty.Value, extremelyDeepStringProperty.Value);
        }
    }
}
