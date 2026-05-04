# Secrets Management

## Problem

Hardcoding secrets leads to leaks.

## Best Practices

* Use secret stores (Azure Key Vault)
* Rotate secrets
* Use managed identities

## .NET

```csharp
builder.Configuration.AddAzureKeyVault(...);
```

## What NOT to Do

* Secrets in source code
* Secrets in appsettings.json (for prod)

## Interview Line

“Externalize and rotate secrets; use managed identity over credentials.”
