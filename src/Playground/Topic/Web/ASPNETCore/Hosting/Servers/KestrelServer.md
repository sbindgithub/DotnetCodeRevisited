# Kestrel Web Server

# What is Kestrel?

Kestrel is the cross-platform web server for ASP.NET Core.

Built using:
- asynchronous sockets
- event-driven networking
- high-performance pipelines

---

# Architecture

```text
Client
   ↓
Kestrel
   ↓
Middleware Pipeline
```

---

# Responsibilities

- HTTP parsing
- Connection management
- Request processing
- TLS support
- HTTP/1.1
- HTTP/2
- HTTP/3

---

# Internal Components

```text
Socket Transport
    ↓
Connection Pipeline
    ↓
HTTP Parser
    ↓
Middleware
```

---

# Why Kestrel Was Important

Classic ASP.NET Framework depended heavily on IIS.

Kestrel enabled:
- Linux hosting
- Docker containers
- Kubernetes
- Cross-platform execution

---

# Default ASP.NET Core Server

```csharp
var builder = WebApplication.CreateBuilder(args);
```

Kestrel is enabled automatically.

---

# Explicit Configuration

```csharp
builder.WebHost.UseKestrel();
```

---

# Port Configuration

```csharp
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
});
```

---

# Production Deployment

Kestrel is usually behind:
- IIS
- Nginx
- Apache
- YARP

Reason:
- SSL termination
- Load balancing
- Security filtering

---

# Interview Question

## Why not expose Kestrel directly to internet?

Because reverse proxies provide:
- better security
- centralized SSL
- rate limiting
- DDoS protection
- request filtering