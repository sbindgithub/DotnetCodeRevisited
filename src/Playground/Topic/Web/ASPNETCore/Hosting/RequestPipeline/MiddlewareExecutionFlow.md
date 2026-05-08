# Middleware Execution Flow

# What is Middleware?

Middleware are components that:
- inspect requests
- modify requests
- short-circuit requests
- process responses

---

# Pipeline Architecture

```text
Request
   ↓
Middleware 1
   ↓
Middleware 2
   ↓
Middleware 3
   ↓
Endpoint
   ↑
Middleware 3
   ↑
Middleware 2
   ↑
Middleware 1
   ↑
Response
```

---

# Example

```csharp
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
```

---

# Middleware Execution Order

Order matters critically.

Wrong order can:
- bypass security
- break routing
- fail authentication

---

# Common Pipeline

```csharp
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
```

---

# Middleware Types

## Terminal Middleware

Ends pipeline.

Example:

```csharp
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello");
});
```

---

## Non-Terminal Middleware

Calls next middleware.

```csharp
await next();
```

---

# Custom Middleware

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
        await _next(context);
    }
}
```

---

# Middleware Registration

```csharp
app.UseMiddleware<LoggingMiddleware>();
```

---

# Architect-Level Understanding

Middleware pipeline is effectively:
- a chain of responsibility pattern
- optimized asynchronous request pipeline
- composable HTTP processing architecture