
# Middleware Pipeline Overview

# What is Middleware?

Middleware is a software component that handles HTTP requests and responses in the ASP.NET Core request pipeline.

Each middleware:
- receives the incoming request
- can process the request
- can pass the request to the next middleware
- can modify the response before returning it

Middleware forms a sequential execution pipeline.

---

# ASP.NET Core Request Pipeline

Client Request
    ↓
Middleware 1
    ↓
Middleware 2
    ↓
Middleware 3
    ↓
Endpoint / Controller
    ↓
Response Back Through Middleware
    ↓
Client Response

---

# Middleware Execution Flow

Middleware executes in two directions:

## Forward Direction
Request travels from top to bottom.

## Backward Direction
Response travels from bottom to top.

Example:

```csharp
app.Use(async (context, next) =>
{
    Console.WriteLine("Before next");

    await next();

    Console.WriteLine("After next");
});
````

Execution Order:

```text
Before next
↓
Next Middleware Executes
↓
After next
```

This creates the request-response wrapping behavior.

---

# Middleware Registration

Middleware is registered inside `Program.cs`.

Example:

```csharp
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
```

---

# Common Built-in Middleware

| Middleware                | Purpose                       |
| ------------------------- | ----------------------------- |
| UseHttpsRedirection       | Redirect HTTP to HTTPS        |
| UseStaticFiles            | Serves static files           |
| UseRouting                | Matches routes                |
| UseAuthentication         | Validates user identity       |
| UseAuthorization          | Checks permissions            |
| UseCors                   | Handles cross-origin requests |
| UseExceptionHandler       | Handles exceptions            |
| UseDeveloperExceptionPage | Developer error page          |

---

# Custom Middleware

Developers can create custom middleware.

Example:

```csharp
public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine("Request Started");

        await _next(context);

        Console.WriteLine("Request Completed");
    }
}
```

Registration:

```csharp
app.UseMiddleware<LoggingMiddleware>();
```

---

# Terminal Middleware

Terminal middleware stops the pipeline.

It does NOT call:

```csharp
await next();
```

Example:

```csharp
app.Run(async context =>
{
    await context.Response.WriteAsync("Pipeline Ended");
});
```

No middleware executes after this.

---

# app.Use vs app.Run vs app.Map

| Method  | Purpose                                   |
| ------- | ----------------------------------------- |
| app.Use | Adds middleware and can continue pipeline |
| app.Run | Terminal middleware                       |
| app.Map | Branches pipeline based on URL            |

Example:

```csharp
app.Map("/admin", adminApp =>
{
    adminApp.Run(async context =>
    {
        await context.Response.WriteAsync("Admin Area");
    });
});
```

---

# Middleware Ordering

Middleware order is critical.

Correct:

```csharp
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
```

Incorrect ordering may:

* break authentication
* break authorization
* produce 404 errors
* bypass middleware behavior

---

# Short Circuiting

Some middleware can terminate the request early.

Example:
`UseStaticFiles()`

If the file exists:

* file is returned immediately
* remaining middleware is skipped

This improves performance.

---

# HttpContext in Middleware

Middleware interacts using `HttpContext`.

Important members:

| Member   | Purpose                |
| -------- | ---------------------- |
| Request  | Incoming HTTP request  |
| Response | Outgoing HTTP response |
| User     | Authenticated user     |
| Session  | Session data           |
| Items    | Per-request storage    |

Example:

```csharp
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("AppName", "Demo");

    await next();
});
```

---

# Middleware Categories

## Security Middleware

* Authentication
* Authorization
* CORS

## Static File Middleware

* Static files
* Default files
* Directory browsing

## Diagnostic Middleware

* Logging
* Exception handling
* Developer exception page

## Routing Middleware

* Endpoint matching
* Route resolution

---

# Internal Architecture

Internally ASP.NET Core builds middleware into a chained delegate pipeline.

Conceptually:

```text
RequestDelegate1
    → RequestDelegate2
        → RequestDelegate3
            → Endpoint
```

Each middleware wraps the next middleware.

This resembles:

* Chain of Responsibility Pattern
* Decorator Pattern

---

# Production Considerations

## Keep Middleware Lightweight

Heavy middleware affects every request.

## Order Carefully

Security middleware must execute before endpoints.

## Avoid Blocking Calls

Use async/await properly.

## Logging Middleware

Avoid excessive logging in production.

---

# Common Interview Questions

## Why does middleware order matter?

Because middleware executes sequentially and some middleware depends on previous middleware.

---

## What is terminal middleware?

Middleware that does not call the next delegate.

---

## Difference between app.Use and app.Run?

`app.Use`

* can continue pipeline

`app.Run`

* terminates pipeline

---

## What is short-circuiting?

Stopping pipeline execution early and returning a response immediately.

---

## What design pattern does middleware resemble?

* Chain of Responsibility
* Decorator Pattern

---

# Real-World Example

Example Request:

```text
GET /api/products
```

Pipeline Flow:

```text
Kestrel
↓
HTTPS Redirection
↓
Static Files
↓
Routing
↓
Authentication
↓
Authorization
↓
Controller
↓
Response
```

---

# Summary

Middleware is the core execution mechanism of ASP.NET Core.

Understanding middleware is essential for:

* debugging
* performance optimization
* security
* request lifecycle understanding
* production troubleshooting
* architecture design

Without understanding middleware deeply, it is difficult to understand ASP.NET Core internals.

```
```
