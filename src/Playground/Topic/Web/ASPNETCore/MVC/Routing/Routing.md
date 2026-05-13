# Routing in ASP.NET Core MVC

Routing is the mechanism that maps an incoming HTTP request to a controller action method.

It analyzes:

- URL
- Controller name
- Action name
- Route parameters
- HTTP method

If a matching route is found, the request is processed.

Otherwise, a 404 response is returned.

---

# Routing Flow

```text
Incoming HTTP Request
        |
        v
+----------------------+
|   Routing Engine     |
+----------------------+
        |
        v
+----------------------+
|     URL Parsing      |
+----------------------+
        |
        v
+----------------------+
|  Find Matching Route |
+----------------------+
        |
        v
   Route Found?
    /      \
  NO        YES
  |          |
  v          v
404 Error   Execute Action
```

---

# Types of Routing

1. Convention-Based Routing
2. Attribute Routing

Both can coexist in the same application.

---

# Routing Middleware

```csharp
app.UseRouting();
```

Enables routing middleware.

---

# Endpoint Mapping

```csharp
app.MapControllerRoute();
```

Maps controller routes.

---

# Key Points

- Routing maps URL to action method.
- Routing works after middleware pipeline execution reaches routing middleware.
- Attribute routing takes higher priority than convention routing.