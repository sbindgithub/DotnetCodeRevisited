# Attribute Routing

Attribute routing defines routes directly on controllers or action methods.

---

# Action-Level Route

```csharp
[Route("Student/All")]
public IActionResult GetAllStudents()
{
    return View();
}
```

---

# Route Parameter

```csharp
[Route("Student/{id}")]
public IActionResult Details(int id)
{
    return View();
}
```

---

# Multiple Routes

```csharp
[Route("")]
[Route("Home")]
[Route("Home/Index")]
public IActionResult Index()
{
    return View();
}
```

---

# Controller-Level Route

```csharp
[Route("Home")]
public class HomeController : Controller
{
    [Route("Index")]
    public IActionResult Index()
    {
        return View();
    }
}
```

Generated Route:

```text
/Home/Index
```

---

# Ignore Controller Prefix

```csharp
[Route("~/Privacy")]
```

`~/` ignores controller-level route prefix.

---

# Route Tokens

## Controller Token

```csharp
[Route("[controller]")]
```

## Action Token

```csharp
[Route("[action]")]
```

Example:

```csharp
[Route("[controller]/[action]")]
```

---

# Optional Parameter

```csharp
{id?}
```

Example:

```csharp
{id:int?=100}
```

Meaning:

- integer
- optional
- default value = 100

---

# Important Points

- Attribute routing gives more control.
- Useful for REST APIs.
- Attribute routing takes precedence over convention routing.