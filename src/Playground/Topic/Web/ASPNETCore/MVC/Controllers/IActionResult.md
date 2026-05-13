# IActionResult and Action Results

## IActionResult

Base interface for all action results.

Example:

public IActionResult Index()
{
    return View();
}

---

## JsonResult

Returns JSON response.

Example:

public JsonResult GetStudent()
{
    return Json(student);
}

---

## Without IActionResult

Possible when exact return type is known.

Example:

public string Hello()
{
    return "Hello";
}

Problem:
- Less flexibility
- Harder to change response type later

Best Practice:
Use IActionResult for flexibility.