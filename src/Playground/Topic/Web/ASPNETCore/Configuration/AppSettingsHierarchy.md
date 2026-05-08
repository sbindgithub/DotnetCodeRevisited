# AppSettings Hierarchy

## Configuration Precedence

ASP.NET Core configuration follows layered override order.

Later providers override earlier providers.

---

# Default Order

```text
appsettings.json
        ↓
appsettings.{Environment}.json
        ↓
User Secrets
        ↓
Environment Variables
        ↓
Command-line Arguments
```

Last provider wins.

---

# Example

## appsettings.json

```json
{
  "ConnectionStrings": {
    "StoreDb": "DEV_DB"
  }
}
```

## appsettings.Production.json

```json
{
  "ConnectionStrings": {
    "StoreDb": "PROD_DB"
  }
}
```

If environment is:

```text
Production
```

Final value becomes:

```text
PROD_DB
```

---

# Environment Variable Override

Example:

```bash
ConnectionStrings__StoreDb=LIVE_DB
```

Overrides ALL JSON files.

---

# Why This Matters

This enables:
- environment-specific deployments
- secret injection
- containerized deployments
- CI/CD configuration
- immutable infrastructure

---

# Production Best Practice

## Development
- launchSettings.json
- User Secrets

## Production
- environment variables
- secret vaults
- external configuration providers

---

# Important Interview Question

## Which configuration source has highest priority?

Answer:

```text
Command-line arguments
```

because they load last.

---

# Architect-Level Understanding

ASP.NET Core configuration is provider-based and layered.

Applications should NOT assume configuration comes from JSON only.