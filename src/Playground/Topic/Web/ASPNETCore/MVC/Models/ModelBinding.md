# Model Binding

Model Binding converts incoming request data into .NET objects.

Sources:
- Route values
- Query string
- Form data
- Headers
- Body

Example:

public IActionResult Details(int id)
{
}

URL:
student/details/10

id automatically binds to 10.

---

Complex Object Binding:

public IActionResult Save(Student student)
{
}

Framework automatically maps request fields to object properties.