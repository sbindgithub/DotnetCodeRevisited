# Razor Syntax (.cshtml)

Razor allows mixing HTML and C#.

Example:

<h1>@Model.Name</h1>

Code Block:

@{
    var x = 10;
}

Loop:

@foreach(var item in Model)
{
    <p>@item.Name</p>
}

---

Rule:

View should contain only display logic.

Do NOT put:
- Data access logic
- Business logic
- Validation logic

Those belong in:
- Services
- Repository
- Business layer