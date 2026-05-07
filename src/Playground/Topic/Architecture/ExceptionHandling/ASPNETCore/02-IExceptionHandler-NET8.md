`IExceptionHandler` is the modern centralized exception handling mechanism introduced in newer versions of [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?utm_source=chatgpt.com), especially preferred in .NET 8+.

Instead of writing custom middleware manually, Microsoft now recommends implementing:

```csharp id="d9tq2s"
IExceptionHandler
```

This gives:

* cleaner architecture,
* better framework integration,
* standardized exception pipelines,
* and easier extensibility.

Basic flow:

```text id="y4v64k"
Request
   ↓
Controller
   ↓
Service
   ↓
Exception Occurs
   ↓
IExceptionHandler Handles It
   ↓
Standard JSON Response Returned
```

Step 1 — Create Global Exception Handler

Example:

```csharp id="sz58j0"
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(
            exception,
            "Unhandled exception occurred");

        httpContext.Response.StatusCode =
            (int)HttpStatusCode.InternalServerError;

        httpContext.Response.ContentType =
            "application/json";

        var response = new
        {
            Title = "Server Error",
            Status = 500,
            Message = "An unexpected error occurred"
        };

        await httpContext.Response.WriteAsJsonAsync(
            response,
            cancellationToken);

        return true;
    }
}
```

Critical point:

```csharp id="w3r1mk"
return true;
```

means:

```text id="dfmy1e"
"Exception handled successfully"
```

If `false` is returned:

* ASP.NET Core continues searching for another handler.

Step 2 — Register the Handler

In `Program.cs`:

```csharp id="z6w9i8"
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
```

Step 3 — Enable Exception Handling Middleware

```csharp id="u55xdl"
app.UseExceptionHandler();
```

Without this:

* handler never executes.

Full .NET 8 setup:

```csharp id="a3w3l0"
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
```

Example controller:

```csharp id="d7d0eg"
[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        throw new Exception("Database crashed");
    }
}
```

Response:

```json id="2x87q7"
{
  "title": "Server Error",
  "status": 500,
  "message": "An unexpected error occurred"
}
```

NOT:

```json id="2lqu1i"
{
  "message": "Database crashed"
}
```

because internal exceptions should not leak.

Industry-standard improvement:
Map different exception types.

Example:

```csharp id="5grdws"
if(exception is NotFoundException)
{
    httpContext.Response.StatusCode = 404;
}
else if(exception is ValidationException)
{
    httpContext.Response.StatusCode = 400;
}
else
{
    httpContext.Response.StatusCode = 500;
}
```

Enterprise-level version usually includes:

* correlation IDs,
* ProblemDetails,
* Serilog integration,
* OpenTelemetry tracing,
* distributed logging,
* and custom business exception mapping.

Advanced production pattern:

```text id="i9d3y9"
ValidationException        → 400
UnauthorizedAccessException → 401
ForbiddenException          → 403
NotFoundException           → 404
BusinessRuleException       → 409
UnhandledException          → 500
```

Why Microsoft prefers `IExceptionHandler` now:

1. Cleaner than custom middleware
2. Better separation of concerns
3. Framework-native
4. Easier testing
5. Better pipeline extensibility
6. Works well with ProblemDetails
7. More maintainable in large systems

Architect-level insight:

Old approach:

```text id="tzx2q0"
Custom Middleware
```

Modern approach:

```text id="vf4l1m"
IExceptionHandler + ProblemDetails
```

You should still know BOTH because:

* many companies still use middleware,
* but modern enterprise systems are increasingly moving toward `IExceptionHandler`.

Most interview candidates only explain syntax.

Strong candidates explain:

* pipeline behavior,
* centralized handling,
* observability,
* security implications,
* and HTTP contract standardization.
