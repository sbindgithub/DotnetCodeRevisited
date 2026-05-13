# Convention Routing

Convention routing defines routes centrally in `Program.cs`.

---

# Default Route

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
```

---

# Understanding the Pattern

```text
{controller=Home}/{action=Index}/{id?}
```

| Part | Meaning |
|---|---|
| controller=Home | Default controller |
| action=Index | Default action |
| id? | Optional parameter |

---

# Example

URL:

```text
http://localhost:5000/Home/Details/10
```

Controller:

```csharp
public class HomeController : Controller
{
    public IActionResult Details(int id)
    {
        return View();
    }
}
```

Routing Result:

| URL Part | Maps To |
|---|---|
| Home | HomeController |
| Details | Details() |
| 10 | id |

---

# Base URL Behavior

These URLs are same:

```text
/Home
/Home/Index
```

Because `Index` is default action.

---

# Custom Route

```csharp
app.MapControllerRoute(
    name: "student",
    pattern: "Student/All",
    defaults: new
    {
        controller = "Student",
        action = "Index"
    }
);
```

---

# Important Points

- Custom routes should come before default route.
- Convention routing is easy for large applications.
- SEO-friendly URLs can be created using custom routes.