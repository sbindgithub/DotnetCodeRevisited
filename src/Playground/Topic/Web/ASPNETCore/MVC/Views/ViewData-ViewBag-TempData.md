# ViewData vs ViewBag vs TempData

## ViewData

Dictionary object.

Type:
ViewDataDictionary

Based on:
IDictionary<string, object>

Lifetime:
Current request only.

Example:

Controller:

ViewData["Title"] = "Student";

View:

@ViewData["Title"]

---

Complex Object:

ViewData["student"] = model;

@{
 var student = ViewData["student"] as Student;
}

Problem:
- Type casting required
- No compile-time checking

---

## ViewBag

Dynamic wrapper over ViewData.

Example:

ViewBag.Title = "Student";

View:

@ViewBag.Title

Advantages:
- No type casting

Disadvantages:
- Runtime errors possible

---

## TempData

Used across redirect.

Based on:
IDictionary<string, object>

Example:

TempData["Message"] = "Saved";

Methods:
- Keep()
- Keep(key)
- Peek()

Use Case:
Redirect scenarios