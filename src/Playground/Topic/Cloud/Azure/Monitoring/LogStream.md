# Azure App Service Log Stream

## What it is
Log Stream provides **real-time streaming of logs** from your App Service.

It shows logs as they are generated, similar to `tail -f`.

---

## When to Use

- Debugging live issues
- Checking startup errors
- Verifying deployments
- Watching logs during API calls

---

## How to Access

### Portal
App Service → Monitoring → Log Stream

### CLI
az webapp log tail --name <app-name> --resource-group <rg>

---

## What You See

- Application logs (ILogger / Console)
- Startup logs
- Deployment logs

---

## Important Requirement

Log streaming works only if:
- Application logging is enabled
- Log level is set (Information/Warning/etc.)

---

## Limitations

- Not persistent (logs are not stored long-term)
- No filtering or querying
- Not suitable for production monitoring
- Hard to analyze large volumes

---

## Example Use Case

### Scenario: API not starting

Steps:
1. Open Log Stream
2. Restart App Service
3. Observe startup logs

You might see:
- Missing environment variable
- Connection string error
- Dependency injection failure

---

## Common Mistakes

- Relying on Log Stream for production debugging
- Not enabling logging → empty stream
- Expecting historical logs

---

## Log Stream vs Application Insights

| Feature | Log Stream | Application Insights |
|--------|-----------|--------------------|
| Real-time | ✔ | ✔ |
| Historical data | ❌ | ✔ |
| Query (KQL) | ❌ | ✔ |
| Distributed tracing | ❌ | ✔ |
| Production use | ❌ | ✔ |

---

## Architect-Level Thinking

You must answer:

### Q: When would you use Log Stream instead of App Insights?

✔ During:
- Deployment verification
- Immediate issue debugging
- Startup failures

❌ Not for:
- Long-term monitoring
- Performance analysis

---

## Summary

Log Stream = Live console  
App Insights = Observability system

Use Log Stream for **quick visibility**, not for **system analysis**