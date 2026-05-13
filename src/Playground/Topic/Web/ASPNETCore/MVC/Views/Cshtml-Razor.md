# CSHTML and Razor

.cshtml files are Razor View files.

Combination of:
- HTML
- C#
- Razor syntax

Example:

@model Student

<h1>@Model.Name</h1>

---

Strongly Typed Model

@model Namespace.Student

Advantages:
- IntelliSense
- Compile-time checking
- Cleaner code

---

Html Helper

@Html.DisplayFor(x => x.Name)

Purpose:
Strongly typed rendering helper