/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

import {
  AutoRestExtension,
  Channel
} from "@microsoft.azure/autorest-extension-base";

require("source-map-support").install();

export async function main() {
  const extension = new AutoRestExtension();

  extension.Add("csharp-core", async autoRestApi => {
    // read files offered to this plugin
    const inputFileUris = await autoRestApi.ListInputs();
    const inputFiles = await Promise.all(
      inputFileUris.map(uri => autoRestApi.ReadFile(uri))
    );

    autoRestApi.Message({
      Channel: Channel.Information,
      Text:
        "AutoRest offers the following input files: " + inputFiles.join(", ")
    });
    // emit a file (all input files concatenated)
    autoRestApi.WriteFile("concat.txt", inputFiles.join("\n---\n"));
  });

  await extension.Run();
}

main();
