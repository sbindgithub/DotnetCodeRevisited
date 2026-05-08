# ASP.NET Core Request Flow - End To End

## High Level Request Journey

```text
Browser / Client
    ↓
DNS Resolution
    ↓
Load Balancer
    ↓
Reverse Proxy (IIS / Nginx / Apache)
    ↓
Kestrel Web Server
    ↓
ASP.NET Core Middleware Pipeline
    ↓
Routing Middleware
    ↓
Authentication Middleware
    ↓
Authorization Middleware
    ↓
Endpoint Execution
    ↓
Controller / Minimal API
    ↓
Service Layer
    ↓
Repository Layer
    ↓
Database
```

---

# Step By Step Internal Execution

## 1. Client Sends HTTP Request

Example:

```http
GET /api/orders HTTP/1.1
Host: myapp.com
Authorization: Bearer token
```

---

## 2. DNS Resolution

DNS converts domain:

```text
myapp.com → IP Address
```

---

## 3. Load Balancer

Responsibilities:
- Traffic distribution
- Health checks
- Failover
- SSL offloading

Examples:
- Azure Load Balancer
- AWS ELB
- Nginx
- HAProxy

---

## 4. Reverse Proxy

Responsibilities:
- SSL termination
- Compression
- Request forwarding
- Static file serving
- Web Application Firewall

Examples:
- IIS
- Nginx
- Apache
- YARP

---

## 5. Kestrel Receives Request

Kestrel:
- Parses HTTP request
- Handles sockets
- Manages connections
- Supports HTTP/1.1, HTTP/2, HTTP/3

---

## 6. Middleware Pipeline Starts

Configured in:

```csharp
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
```

Middleware executes sequentially.

---

## 7. Routing Middleware

Matches endpoint:

```text
/api/orders
```

to:

```csharp
[HttpGet]
public IActionResult Get()
```

---

## 8. Authentication

Validates:
- JWT token
- Cookies
- OAuth/OpenID Connect

Creates:

```csharp
HttpContext.User
```

---

## 9. Authorization

Checks:
- Roles
- Policies
- Claims

---

## 10. Controller Execution

```csharp
public class OrdersController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
```

---

## 11. Service Layer

Contains:
- Business rules
- Domain logic
- Transaction coordination

---

## 12. Repository Layer

Responsible for:
- Database interaction
- EF Core / Dapper execution

---

## 13. Database Execution

Examples:
- SQL Server
- PostgreSQL
- Oracle

---

## 14. Response Returns Back

Reverse order:

```text
Database
   ↑
Repository
   ↑
Service
   ↑
Controller
   ↑
Middleware
   ↑
Kestrel
   ↑
Reverse Proxy
   ↑
Client
```

---

# Interview Question

## Why middleware order matters?

Because ASP.NET Core middleware executes in pipeline order.
Wrong ordering can:
- bypass security
- break routing
- fail authentication
- expose endpoints