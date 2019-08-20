# Autorest marker

> see https://aka.ms/autorest

```yaml
pipeline:
  csharp-core:
    input: openapi-document/identity
    scope: csharp-core
  csharp/emitter:
    input: csharp-core
```
