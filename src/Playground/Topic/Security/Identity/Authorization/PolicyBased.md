# Authorization: RBAC vs Policy-Based

## RBAC

* Role-Based Access Control
* Simple: User → Role → Permission
* Limitation: coarse-grained

## Policy-Based (ASP.NET Core)

* Evaluate **requirements** against **claims/context**
* Fine-grained and extensible

## .NET Example

```csharp
builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("OnlyHR",
    policy => policy.RequireClaim("department", "HR"));
});

[Authorize(Policy = "OnlyHR")]
public IActionResult Get() { ... }
```

## When to Use

* RBAC: simple apps
* Policy: enterprise rules (claims, resource-based checks)

## Interview Line

“Prefer policy-based for flexibility; RBAC alone becomes rigid at scale.”
