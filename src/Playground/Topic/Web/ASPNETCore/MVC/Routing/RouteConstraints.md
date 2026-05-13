# Route Constraints

Route constraints restrict route parameter values.

---

# Example

```csharp
pattern:
"{controller=Home}/{action=Index}/{id:int:min(10):max(20)?}"
```

Meaning:

- `id` is optional
- must be integer
- minimum value = 10
- maximum value = 20

---

# Common Constraints

| Constraint | Meaning |
|---|---|
| int | Integer |
| bool | Boolean |
| guid | GUID |
| datetime | DateTime |
| minlength(x) | Minimum length |
| maxlength(x) | Maximum length |
| min(x) | Minimum numeric value |
| max(x) | Maximum numeric value |

---

# Attribute Routing Constraint

```csharp
[Route("Product/{id:int}")]
```

---

# Custom Route Constraint

Implement:

```csharp
IRouteConstraint
```

Main method:

```csharp
bool Match(
    HttpContext httpContext,
    IRouter route,
    string routeKey,
    RouteValueDictionary values,
    RouteDirection routeDirection)
```

---

# Register Custom Constraint

```csharp
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add(
        "alphanumeric",
        typeof(AlphaNumericConstraint));
});
```

---

# Example

```csharp
[Route("Product/{code:alphanumeric}")]
```

---

# Important Points

- Constraints improve route validation.
- Prevent invalid URLs.
- Constraints are checked during route matching.