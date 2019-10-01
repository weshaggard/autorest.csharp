/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

import {
  AutoRestExtension,
  Channel
} from "@microsoft.azure/autorest-extension-base";
import { IProject, ILogger } from "./codegen/models";
import { create as createServiceModel } from "./codegen/serviceModel";
import { generate } from "./codegen/generator";
//import { ModelState } from "@microsoft.azure/autorest.remodeler";
//import { Model } from "@microsoft.azure/autorest.codemodel-v3";
import { ModelState, codemodel } from "@microsoft.azure/autorest.codemodel-v3";
import { join } from "path";
import { resolveFullPath } from "@microsoft.azure/codegen";

require("source-map-support").install();

export async function main() {
  const extension = new AutoRestExtension();

  extension.Add("csharp-core", async autoRestApi => {
    // read files offered to this plugin
    const inputFileUris = await autoRestApi.ListInputs();
    const inputFiles = await Promise.all(
      inputFileUris.map(uri => autoRestApi.ReadFile(uri))
    );

    const logger: ILogger = {
      log(message: string): void {
        autoRestApi.Message({ Channel: Channel.Information, Text: message });
      },
      warn(message: string): void {
        autoRestApi.Message({ Channel: Channel.Warning, Text: message });
      },
      error(message: string): void {
        autoRestApi.Message({ Channel: Channel.Error, Text: message });
      },
      verbose(message: string): void {
        autoRestApi.Message({ Channel: Channel.Verbose, Text: message });
      }
    };

    const project: IProject = {
      settings: {
        "input-file": await autoRestApi.GetValue("input-file"),
        "output-file": await autoRestApi.GetValue("output-folder"),
        "clear-output-folder": await autoRestApi.GetValue("clear-out-folder"),
        "azure-track2-csharp": await autoRestApi.GetValue(
          "azure-track2-csharp"
        ),
        namespace: await autoRestApi.GetValue("namespace"),
        "client-name": await autoRestApi.GetValue("client-name"),
        "client-extensions-name": await autoRestApi.GetValue(
          "client-extensions-name"
        ),
        "client-model-factory-name": await autoRestApi.GetValue(
          "namespclient-model-factory-nameace"
        ),
        "x-az-skip-path-components": await autoRestApi.GetValue(
          "x-az-skip-path-components"
        ),
        "x-az-include-sync-methods": await autoRestApi.GetValue(
          "x-az-include-sync-methods"
        ),
        "x-az-public": await autoRestApi.GetValue("x-az-public")
      },
      //swagger: inputFiles,
      state: await new ModelState<codemodel.Model>(autoRestApi).init(),
      // cache: {
      //   parameters: {},
      //   definitions: {},
      //   responses: {},
      //   customTypes: {},
      //   voidType: { type: "void", external: true, extendedHeaders: [] }
      // },
      logger: logger
    };

    const model = await createServiceModel(project);

    let [filename, filecontents] = generate(model);
    //filename = join(await autoRestApi.GetValue("output-folder"), filename);
    autoRestApi.WriteFile(
      filename,
      filecontents,
      undefined,
      "source-file-csharp"
    );
  });

  await extension.Run();
}

main();
