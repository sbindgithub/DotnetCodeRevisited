# Launch Settings Explained

## Purpose

`launchSettings.json` is used only during local development.

It helps Visual Studio, Rider, and `dotnet run` know:
- which URL to launch
- whether to use IIS Express
- which environment variables to set
- which browser to open

It is NOT used in production.

---

# File Location

```text
Properties/launchSettings.json
```

---

# Example

```json
{
  "profiles": {
    "CustomerOrder.Api": {
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

---

# Important Properties

| Property | Meaning |
|---|---|
| commandName | How application starts |
| applicationUrl | Local URLs |
| launchBrowser | Opens browser automatically |
| environmentVariables | Sets local environment variables |

---

# Runtime Flow

```text
launchSettings.json
        ↓
Visual Studio / dotnet run
        ↓
Sets process environment variables
        ↓
Application starts
        ↓
Environment.GetEnvironmentVariable()
```

---

# Important Understanding

The application code NEVER directly reads `launchSettings.json`.

Instead:

```csharp
Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
```

reads the environment variable injected by the host process.

---

# Production Reality

`launchSettings.json` is ignored in:
- IIS
- Docker
- Kubernetes
- Azure App Service
- Linux systemd

Production environments set variables externally.

Example:

```bash
export ASPNETCORE_ENVIRONMENT=Production
```

---

# Architect-Level Understanding

`launchSettings.json`
= local developer tooling configuration

NOT:
- production configuration
- deployment configuration
- cloud configuration