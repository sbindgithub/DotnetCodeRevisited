# InProcess vs OutOfProcess Hosting

# InProcess Hosting

## Architecture

```text
Browser
   ↓
IIS (w3wp.exe)
   ↓
ASP.NET Core App
```

## Characteristics

- Runs inside IIS worker process
- Uses IISHttpServer
- No reverse proxy hop
- Better performance
- Lower latency

## Configuration

```xml
<aspNetCore hostingModel="InProcess" />
```

---

# OutOfProcess Hosting

## Architecture

```text
Browser
   ↓
IIS
   ↓
Reverse Proxy
   ↓
Kestrel (dotnet.exe)
   ↓
ASP.NET Core App
```

## Characteristics

- Separate process isolation
- Uses Kestrel
- IIS acts as reverse proxy
- Better cloud flexibility
- Better container support

## Configuration

```xml
<aspNetCore hostingModel="OutOfProcess" />
```

---

# Internal Process Difference

## InProcess

```text
w3wp.exe
   └── ASP.NET Core App
```

## OutOfProcess

```text
w3wp.exe
   └── Reverse Proxy

dotnet.exe
   └── ASP.NET Core App
```

---

# Performance Comparison

| Feature | InProcess | OutOfProcess |
|---|---|---|
| Performance | Faster | Slightly slower |
| Reverse Proxy | No | Yes |
| Kestrel | Internal integration | Explicit |
| Process Isolation | No | Yes |
| Cloud Native | Limited | Excellent |
| Linux Support | No | Yes |

---

# Real Industry Usage

## Traditional Enterprise

```text
IIS + InProcess
```

## Modern Cloud

```text
Nginx → Kestrel
```

---

# Architect-Level Understanding

InProcess optimizes performance by eliminating reverse proxy overhead.

OutOfProcess optimizes scalability, portability, and cloud-native deployment.