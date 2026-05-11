# HttpContext.md

````md
# HttpContext in ASP.NET Core

## What is HttpContext?

`HttpContext` represents the complete HTTP request-response lifecycle for a single request in ASP.NET Core.

It contains:

- Request data
- Response data
- User information
- Headers
- Cookies
- Session
- Services
- Items shared across middleware

Every incoming request gets its own `HttpContext` instance.

---

# High-Level Flow

Client Request
        ↓
Kestrel Server
        ↓
Create HttpContext
        ↓
Middleware Pipeline
        ↓
Routing
        ↓
Controller / Endpoint
        ↓
Response Returned

---

# Core Properties of HttpContext

| Property | Purpose |
|---|---|
| Request | Incoming HTTP request |
| Response | Outgoing HTTP response |
| User | Authenticated user |
| Session | Session state |
| Items | Per-request temporary storage |
| TraceIdentifier | Unique request ID |
| Connection | Client connection info |
| RequestServices | Dependency Injection scope |

---

# HttpRequest

Represents incoming request data.

## Common Properties

| Property | Example |
|---|---|
| Method | GET / POST |
| Path | /api/orders |
| Query | ?id=10 |
| Headers | Authorization headers |
| Body | JSON payload |
| Cookies | Browser cookies |

---

# Example

```csharp
app.Use(async (context, next) =>
{
    Console.WriteLine(context.Request.Method);
    Console.WriteLine(context.Request.Path);

    await next();
});
````

---

# HttpResponse

Represents outgoing response.

## Common Properties

| Property    | Purpose          |
| ----------- | ---------------- |
| StatusCode  | 200, 404, 500    |
| Headers     | Response headers |
| Body        | Response content |
| ContentType | application/json |

---

# Example

```csharp
app.Run(async context =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/plain";

    await context.Response.WriteAsync("Hello");
});
```

---

# HttpContext.User

Contains authenticated user information.

## Example

```csharp
var username = context.User.Identity.Name;
```

---

# HttpContext.Items

Temporary storage during one request.

Useful for middleware communication.

---

# Example

## Middleware 1

```csharp
app.Use(async (context, next) =>
{
    context.Items["CorrelationId"] = Guid.NewGuid();

    await next();
});
```

## Middleware 2

```csharp
app.Use(async (context, next) =>
{
    var id = context.Items["CorrelationId"];

    await next();
});
```

---

# HttpContext.RequestServices

Access scoped dependency injection container.

---

# Example

```csharp
var service = context.RequestServices
                     .GetRequiredService<IMyService>();
```

---

# HttpContext Lifecycle

## Step 1 — Request Arrives

Kestrel receives request.

## Step 2 — HttpContext Created

ASP.NET Core creates:

* HttpContext
* HttpRequest
* HttpResponse

## Step 3 — Middleware Executes

Each middleware can:

* Read request
* Modify request
* Short-circuit pipeline
* Modify response

## Step 4 — Endpoint Executes

Controller / Minimal API runs.

## Step 5 — Response Sent

Response flows back to client.

## Step 6 — HttpContext Disposed

Request scope ends.

---

# Important Architectural Concepts

## HttpContext is NOT Thread Safe

Never access it across multiple threads.

Bad practice:

```csharp
Task.Run(() =>
{
    var path = context.Request.Path;
});
```

---

# Avoid Storing HttpContext

Never store it in:

* Singleton services
* Static variables
* Background jobs

Reason:
Request scope will end.

---

# IHttpContextAccessor

Used when accessing HttpContext outside controllers/middleware.

---

# Registration

```csharp
builder.Services.AddHttpContextAccessor();
```

---

# Usage

```csharp
public class MyService
{
    private readonly IHttpContextAccessor _accessor;

    public MyService(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public void PrintUser()
    {
        var user = _accessor.HttpContext?.User?.Identity?.Name;
    }
}
```

---

# HttpContext vs ControllerBase

| ControllerBase           | HttpContext              |
| ------------------------ | ------------------------ |
| Higher-level abstraction | Low-level request object |
| Easier for APIs          | Full pipeline access     |
| MVC focused              | Middleware focused       |

---

# Middleware Communication Pattern

Middleware commonly uses:

* HttpContext.Items
* Headers
* Claims
* Features

to exchange data.

---

# Real Enterprise Usage

## Logging

```csharp
context.TraceIdentifier
```

Used for distributed tracing.

---

## Correlation IDs

Track requests across microservices.

---

## Multi-Tenant Systems

Tenant ID extracted from:

* Headers
* Domain
* JWT token

Stored in HttpContext.Items.

---

## Authentication

JWT middleware populates:

```csharp
context.User
```

---

# Performance Notes

HttpContext is optimized heavily internally.

ASP.NET Core uses:

* Object pooling
* Feature interfaces
* Span-based parsing

to reduce allocations.

---

# Internal Architecture

Internally:

```text
DefaultHttpContext
    ↓
IFeatureCollection
    ↓
HttpRequestFeature
HttpResponseFeature
RouteFeature
SessionFeature
...
```

ASP.NET Core composes features dynamically.

This makes the framework modular and high-performance.

---

# Common Interview Questions

## Q1 — Difference between HttpContext and HttpRequest?

| HttpContext          | HttpRequest           |
| -------------------- | --------------------- |
| Entire request scope | Incoming request only |

---

## Q2 — Is HttpContext thread-safe?

No.

---

## Q3 — Why IHttpContextAccessor can be dangerous?

Improper usage creates hidden coupling and testing difficulty.

---

## Q4 — Where should HttpContext be accessed?

Prefer:

* Controllers
* Middleware
* Endpoint filters

Avoid deep business layers.

---

# Architect-Level Insight

`HttpContext` is the backbone of request orchestration in ASP.NET Core.

A strong architect understands:

* Request lifecycle
* Middleware flow
* Scoped services
* Authentication propagation
* Observability/tracing
* Cross-cutting concerns

Most enterprise platform behaviors are ultimately coordinated through `HttpContext`.

```
```
