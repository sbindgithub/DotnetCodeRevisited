# Service Registration

## AddMvc()

builder.Services.AddMvc();

Registers:
- Controllers
- Views
- Razor Pages
- API features
- Model binding
- Validation
- Authorization

---

## AddControllers()

Only API support.

No Views.

Used for REST APIs.

---

## AddControllersWithViews()

Supports:
- Controllers
- Views

No Razor Pages.

---

## AddRazorPages()

Supports Razor Pages only.

No MVC controllers required.