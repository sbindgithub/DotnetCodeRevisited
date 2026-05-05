# Configuration (Environment Variables)

## What it is
Environment variables are key-value pairs used to configure applications without changing code.

In Azure App Service, they are called **Application Settings**.

---

## Why It Matters
- Externalizes configuration (12-factor app principle)
- Enables different configs per environment (Dev/Test/Prod)
- Avoids hardcoding secrets

---

## Where Used
- App Service (Application Settings)
- Azure Functions (Application Settings)
- Containers (environment variables)

---

## Examples
ConnectionStrings__DefaultConnection = Server=...
ApiBaseUrl = https://api.prod.com
Logging__LogLevel__Default = Information

---

## Access in .NET

```csharp
var value = Environment.GetEnvironmentVariable("ApiBaseUrl");