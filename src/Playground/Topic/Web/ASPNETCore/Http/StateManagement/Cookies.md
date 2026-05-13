# Cookies in ASP.NET Core

Cookies are key-value pairs stored in browser.

Types:
- Persistent
- Non-persistent

Max Size:
Approx 4KB

---

Write Cookie:

Response.Cookies.Append("UserId", "101");

Read Cookie:

Request.Cookies["UserId"]

Delete Cookie:

Response.Cookies.Delete("UserId");

---

CookieOptions

var options = new CookieOptions();
options.Expires = DateTime.Now.AddDays(1);

---

Inject IHttpContextAccessor

@inject IHttpContextAccessor HttpContextAccessor

@HttpContextAccessor?.HttpContext?.Request.Cookies["UserName"]

---

Registration:

builder.Services.AddSingleton<IHttpContextAccessor,
    HttpContextAccessor>();

---

Security Concern

Cookies are plain text.

Better alternative:
Session storage