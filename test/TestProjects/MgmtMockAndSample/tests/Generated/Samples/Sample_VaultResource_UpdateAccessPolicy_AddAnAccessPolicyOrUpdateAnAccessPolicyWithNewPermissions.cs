// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class Sample_VaultResource_UpdateAccessPolicy_AddAnAccessPolicyOrUpdateAnAccessPolicyWithNewPermissions
    {
        // Add an access policy, or update an access policy with new permissions
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task UpdateAccessPolicy()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "Vaults_UpdateAccessPolicy" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this VaultResource created on azure
            // for more information of creating VaultResource, please refer to the document of VaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string vaultName = "sample-vault";
            ResourceIdentifier vaultResourceId = MgmtMockAndSample.VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
            MgmtMockAndSample.VaultResource vault = client.GetVaultResource(vaultResourceId);

            // invoke the operation
            MgmtMockAndSample.Models.AccessPolicyUpdateKind operationKind = AccessPolicyUpdateKind.Add;
            MgmtMockAndSample.Models.VaultAccessPolicyParameters vaultAccessPolicyParameters = new VaultAccessPolicyParameters(new VaultAccessPolicyProperties(new MgmtMockAndSample.Models.AccessPolicyEntry[]
            {
new AccessPolicyEntry(Guid.Parse("00000000-0000-0000-0000-000000000000"),"00000000-0000-0000-0000-000000000000",new Permissions()
{
Keys =
{
KeyPermission.Encrypt
},
Secrets =
{
SecretPermission.Get
},
Certificates =
{
CertificatePermission.Get
},
})
            }));
            MgmtMockAndSample.Models.VaultAccessPolicyParameters result = await vault.UpdateAccessPolicyAsync(operationKind, vaultAccessPolicyParameters);

            Console.WriteLine($"Succeeded: {result}");
        }
    }
}