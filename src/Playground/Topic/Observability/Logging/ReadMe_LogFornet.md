## Logging tools

### Log For Net
- Used by dotnet framework

### Serilog
- For Dotnet core
- Used for structured logging
- Supports Asynchronous logging 

### What is structured logging?
Structured logging is a method of generating log data in a consistent, machine-readable format—typically JSON—using key-value pairs rather than free-form text. This approach, as discussed in this New Relic article, makes logs instantly searchable, filterable, and analysable by log management systems. It solves the problem of parsing chaotic log files, enabling faster troubleshooting, distributed tracing, and better insights.

## Serilog Packages

- Install-Package Serilog.AspNetCore
- Install-Package Serilog.Sinks.File
- Install-Package Serilog.Settings.Configuration
- Install-Package Serilog.Sinks.Async

Here is a **clean, architect-level learning reference `.md`** for your Serilog configuration. This is structured so you can **explain it in interviews, debug production issues, and design logging strategy properly**.

---

# Serilog Configuration – Practical Learning Reference

## 1. What This Configuration Is Doing

This setup uses **Serilog with asynchronous logging** and writes logs to:

* File (persistent storage)
* Console (runtime visibility)

It is optimized for:

* Performance (async wrapper)
* Log rotation
* Retention control

---

## 2. High-Level Architecture

```
Application
   ↓
Serilog Logger
   ↓
Async Sink (Non-blocking)
   ↓
 ┌───────────────┬───────────────┐
 │ File Sink     │ Console Sink  │
 └───────────────┴───────────────┘
```

---

## 3. Core Concept: Async Sink

```json
"Name": "Async"
```

### Why it matters

* Logging becomes **non-blocking**
* Improves application throughput
* Prevents I/O bottlenecks

### Without Async

* Each log write blocks execution
* High latency under load

---

## 4. File Sink Configuration

```json
{
  "Name": "File",
  "Args": {
    "path": "D:\\home\\LogFiles\\Application\\MyAppLog-.txt",
    "rollingInterval": "Day",
    "retainedFileCountLimit": 30,
    "fileSizeLimitBytes": 10485760,
    "rollOnFileSizeLimit": true
  }
}
```

### Key Parameters

#### `path`

* Defines log file location
* `MyAppLog-.txt` → enables rolling file naming

#### `rollingInterval: Day`

* Creates a new log file every day

#### `retainedFileCountLimit: 30`

* Keeps logs for 30 days
* Prevents disk overflow

#### `fileSizeLimitBytes: 10485760`

* Max size = 10 MB per file

#### `rollOnFileSizeLimit: true`

* Creates a new file when size limit is reached

---

## 5. Console Sink

```json
{
  "Name": "Console"
}
```

### Purpose

* Real-time debugging
* Useful in:

  * Local development
  * Containers (Docker logs)

---

## 6. Output Template Breakdown

```text
{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] [{Application}] {Message:lj}
```

### Components

| Token       | Meaning                     |
| ----------- | --------------------------- |
| Timestamp   | Log time                    |
| Level:u3    | Short level (INF, ERR, WRN) |
| Application | App name (custom property)  |
| Message:lj  | Log message (JSON-safe)     |

### Example Output

```
2026-04-28 14:32:10 [INF] [OrderService] Order created successfully
```

---

## 7. Important Observations (Critical)

### 1. Logging is structured

* Supports JSON and property-based logs
* Useful for ELK / Seq / Splunk

### 2. File + Console combination

* File → audit trail
* Console → live debugging

### 3. Async wrapper is mandatory in production

Without it:

* Logging becomes a bottleneck

---

## 8. Production Gaps (You Must Address)

This config is good but incomplete.

### Missing:

* Log levels per environment
* Enrichers (CorrelationId, RequestId)
* Centralized logging (Seq / Elastic)
* Exception destructuring

---

## 9. Production-Ready Upgrade (Recommended)

Add:

```json
"Enrich": [
  "FromLogContext",
  "WithMachineName",
  "WithThreadId"
]
```

And:

```json
"MinimumLevel": {
  "Default": "Information",
  "Override": {
    "Microsoft": "Warning",
    "System": "Warning"
  }
}
```

---

## 10. Real-World Usage Pattern (.NET)

```csharp
Log.Information("Processing order {OrderId} for {Customer}", orderId, customerName);
```

### Why this matters

* Enables structured querying:

  * OrderId = 123
  * Customer = "ABC"

---

## 11. Common Mistakes (You Should Avoid)

* ❌ Logging everything as string
* ❌ No async sink
* ❌ No retention policy
* ❌ Logging sensitive data
* ❌ Ignoring log levels

---

## 12. Interview-Level Summary

Serilog configuration should:

* Be **non-blocking**
* Support **structured logging**
* Implement **log rotation & retention**
* Provide **multi-sink output**
* Be **environment-aware**

---

## 13. One-Line Architecture Insight

"Logging is not debugging — it is a production observability system."

