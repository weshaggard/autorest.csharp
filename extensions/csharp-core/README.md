# Autorest marker

> see https://aka.ms/autorest

## Configuration

```yaml
# Generate blob storage
#input-file: ./blob-2019-02-02.json
output-folder: ./Generated
clear-output-folder: false
azure-track2-csharp: true
```

```yaml
use-extension:
  "@microsoft.azure/autorest.remodeler": "beta"

pipeline:
  csharp-core:
    input: remodeler
    scope: csharp-core
  csharp-core/emitter:
    input: csharp-core

output-artifact:
  - source-file-csharp
```
