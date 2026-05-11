# Routing in ASP.NET Core

# What is Routing?

Routing is the process of matching an incoming HTTP request URL to an executable endpoint.

Routing determines:
- which controller executes
- which action method executes
- which endpoint handles the request

Routing is one of the core components of the ASP.NET Core request pipeline.

---

# Example Request

```text
https://localhost:5001/products/details/10
```

Routing extracts:
- controller = Products
- action = Details
- id = 10

---

# Routing Middleware

Routing is enabled using:

```csharp
app.UseRouting();
```

This middleware:
- analyzes the incoming URL
- matches route patterns
- stores route information into `HttpContext`

It does NOT execute the endpoint.

It only performs endpoint matching.

---

# Endpoint Middleware

Endpoint execution happens later:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
```

or in modern ASP.NET Core:

```csharp
app.MapControllers();
```

This executes the matched endpoint.

---

# Routing Flow

```text
Incoming Request
        ↓
UseRouting()
        ↓
Route Matching
        ↓
Endpoint Selected
        ↓
Authentication
        ↓
Authorization
        ↓
MapControllers()
        ↓
Controller Action Executes
```

---

# Conventional Routing

Traditional MVC routing pattern:

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

Default values:
- controller = Home
- action = Index
- id = optional

---

# URL Pattern Tokens

| Token | Meaning |
|---|---|
| controller | Controller name |
| action | Action method |
| id | Route parameter |
| ? | Optional parameter |

Example:

```text
/products/details/10
```

Maps to:

```text
Controller = Products
Action = Details
Id = 10
```

---

# Attribute Routing

Routes can be defined directly on controllers.

Example:

```csharp
[Route("api/products")]
public class ProductsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok();
    }
}
```

Request:

```text
/api/products/10
```

---

# HTTP Verb Routing

Routing can be restricted by HTTP methods.

Example:

```csharp
[HttpGet]
[HttpPost]
[HttpPut]
[HttpDelete]
```

Example:

```csharp
[HttpGet("{id}")]
public IActionResult Get(int id)
{
    return Ok();
}
```

Only GET requests match this route.

---

# Route Parameters

Dynamic values inside URLs.

Example:

```csharp
[HttpGet("{id}")]
```

Request:

```text
/api/products/10
```

Extracted:
- id = 10

---

# Optional Parameters

Example:

```csharp
pattern: "{controller=Home}/{action=Index}/{id?}"
```

`id?`
means optional.

---

# Route Constraints

Used to restrict parameter types.

Example:

```csharp
[HttpGet("{id:int}")]
```

Only integer values match.

Examples:

| Constraint | Meaning |
|---|---|
| int | Integer |
| guid | GUID |
| bool | Boolean |
| alpha | Alphabetic |

---

# Route Data

Matched route values are stored in:

```csharp
HttpContext.GetRouteData()
```

Example values:
- controller
- action
- id

---

# Endpoint Routing

ASP.NET Core uses Endpoint Routing internally.

Endpoints include:
- Controllers
- Razor Pages
- Minimal APIs
- SignalR hubs

Routing selects an endpoint before execution.

---

# Routing and Middleware Order

Correct order:

```csharp
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
```

Why?

`UseRouting()`
must execute first so route metadata becomes available.

Authorization depends on endpoint metadata.

---

# Route Matching Process

Routing internally performs:

## Step 1
Parse URL

## Step 2
Compare against registered route templates

## Step 3
Find best matching endpoint

## Step 4
Store endpoint into `HttpContext`

## Step 5
Execute endpoint later

---

# URL Generation

Routing can also generate URLs.

Example:

```csharp
Url.Action("Details", "Products", new { id = 10 })
```

Generated URL:

```text
/products/details/10
```

---

# Minimal API Routing

Example:

```csharp
app.MapGet("/products/{id}", (int id) =>
{
    return Results.Ok(id);
});
```

---

# Internal Architecture

Internally routing uses:
- route tables
- endpoint metadata
- endpoint matcher
- DFA-based route matching

Routing builds optimized endpoint lookup structures during startup.

---

# Routing vs Endpoint Execution

## UseRouting()

Performs:
- URL matching
- endpoint selection

Does NOT execute controller.

---

## MapControllers()

Executes matched endpoint.

---

# Common Routing Middleware

| Middleware | Purpose |
|---|---|
| UseRouting | Match routes |
| MapControllers | Execute controllers |
| MapGet | Minimal API endpoint |
| MapPost | POST endpoint |

---

# Common Production Problems

## Incorrect Middleware Order

Authentication fails if routing executes later.

---

## Ambiguous Routes

Multiple endpoints match same URL.

---

## Route Conflicts

Two controllers use same route templates.

---

## 404 Errors

Caused by:
- missing routes
- incorrect templates
- middleware ordering issues

---

# Performance Considerations

## Endpoint Routing is Optimized

ASP.NET Core precomputes route structures during startup.

---

## Avoid Excessive Complex Routes

Very large route tables can affect startup performance.

---

# Common Interview Questions

## Difference between UseRouting and UseEndpoints?

`UseRouting`
- selects endpoint

`UseEndpoints`
- executes endpoint

---

## Why must UseRouting come before Authorization?

Authorization uses endpoint metadata produced by routing.

---

## Difference between Conventional and Attribute Routing?

Conventional:
- centralized route templates

Attribute:
- route defined directly on controller/action

---

## What is Endpoint Routing?

Modern routing system introduced in ASP.NET Core.

---

## What is Route Constraint?

Validation rule for route parameters.

---

# Real-World Example

Example Request:

```text
GET /api/orders/1001
```

Flow:

```text
Kestrel
↓
UseRouting()
↓
Endpoint Match
↓
Authentication
↓
Authorization
↓
OrdersController.Get(1001)
↓
Response
```

---

# Summary

Routing is responsible for:
- URL matching
- endpoint selection
- route parameter extraction
- endpoint execution coordination

Routing connects incoming HTTP requests to executable application code.

Without routing:
- controllers cannot execute
- endpoints cannot resolve
- APIs cannot function

```
````
