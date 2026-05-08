# ASPNETCORE_ENVIRONMENT

## Purpose

`ASPNETCORE_ENVIRONMENT` determines the current runtime environment.

Common values:
- Development
- Staging
- Production

---

# Example

```json
{
  "environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development"
  }
}
```

---

# Usage In Code

```csharp
Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
```

or

```csharp
builder.Environment.EnvironmentName
```

---

# AppSettings Resolution

ASP.NET Core loads configuration based on environment.

Example:

```text
appsettings.json
appsettings.Development.json
appsettings.Staging.json
appsettings.Production.json
```

If environment is:

```text
Development
```

then:

```text
appsettings.Development.json
```

overrides base settings.

---

# Configuration Loading Example

```csharp
var configuration = new ConfigurationBuilder()
   .AddJsonFile("appsettings.json")
   .AddJsonFile(
        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        optional: true)
   .Build();
```

---

# Configuration Flow

```text
ASPNETCORE_ENVIRONMENT
        ↓
Selects environment-specific config
        ↓
appsettings.{Environment}.json
        ↓
Overrides base configuration
```

---

# Production Sources

## IIS

```xml
<environmentVariables>
   <environmentVariable
      name="ASPNETCORE_ENVIRONMENT"
      value="Production" />
</environmentVariables>
```

## Docker

```dockerfile
ENV ASPNETCORE_ENVIRONMENT=Production
```

## Kubernetes

```yaml
env:
- name: ASPNETCORE_ENVIRONMENT
  value: Production
```

---

# Important Interview Point

Environment affects:
- logging
- exception pages
- secrets
- connection strings
- feature flags
- middleware behavior
- diagnostics

---

# Architect-Level Understanding

Environment is NOT a compile-time concept.

It is:
- runtime infrastructure metadata
- deployment-driven behavior selector