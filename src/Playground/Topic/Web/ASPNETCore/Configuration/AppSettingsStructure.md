# AppSettings Structure

## Purpose

`appsettings.json` stores application configuration.

---

# Example

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "ConnectionStrings": {
    "StoreDb": "Server=..."
  },
  "Jwt": {
    "Issuer": "Maersk"
  }
}
```

---

# File Types

| File | Purpose |
|---|---|
| appsettings.json | Base configuration |
| appsettings.Development.json | Dev overrides |
| appsettings.Staging.json | Staging overrides |
| appsettings.Production.json | Production overrides |

---

# Accessing Configuration

## IConfiguration

```csharp
var conn = configuration["ConnectionStrings:StoreDb"];
```

---

# Strongly Typed Configuration

## Settings Class

```csharp
public class JwtSettings
{
    public string Issuer { get; set; }
}
```

## Registration

```csharp
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));
```

---

# Recommended Structure

```text
Configuration
 ├── Logging
 ├── ConnectionStrings
 ├── Authentication
 ├── ExternalServices
 ├── FeatureFlags
 └── CacheSettings
```

---

# Avoid

Do NOT:
- store passwords in source control
- hardcode production secrets
- create giant unstructured files

---

# Architect-Level Understanding

`appsettings.json`
is only ONE configuration provider.

ASP.NET Core supports:
- JSON
- Environment Variables
- Azure Key Vault
- User Secrets
- Command Line
- INI/XML/custom providers