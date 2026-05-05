# Logging and Log Levels

## Purpose
Logging helps diagnose issues, monitor system behavior, and analyze failures.

---

## Standard Log Levels (.NET)

- Trace → very detailed (rarely used in production)
- Debug → development-level info
- Information → normal application flow
- Warning → unexpected but non-breaking
- Error → failure in specific operation
- Critical → system-wide failure

---

## Example

```csharp
_logger.LogInformation("Order processed successfully");
_logger.LogWarning("Retrying payment service");
_logger.LogError(ex, "Database connection failed");