# Session in ASP.NET Core

Session stores data on server side.

Advantages:
- More secure
- Larger size support

Uses:
IDistributedCache

---

Install:

Microsoft.AspNetCore.Session

---

Registration:

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

Middleware:

app.UseSession();

---

Store Values:

HttpContext.Session.SetString("name", "sarada");

HttpContext.Session.SetInt32("age", 42);

---

Read Values:

HttpContext.Session.GetString("name");

HttpContext.Session.GetInt32("age");

---

Pipeline Order

AddSession():
Registers services into DI container.

UseSession():
Enables middleware in request pipeline.