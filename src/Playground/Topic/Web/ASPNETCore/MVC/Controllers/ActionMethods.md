# Action Methods

Action methods are public methods inside a controller.

Example:

public class StudentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

Rules:
- Must be public
- Cannot be static
- Cannot be overloaded ambiguously

Return Types:
- IActionResult
- JsonResult
- ViewResult
- ContentResult
- EmptyResult

Attribute Routing:

[HttpGet]
[HttpPost]
[HttpPut]
[HttpDelete]

Example:

[HttpGet]
public IActionResult GetStudentById(int id)
{
    return Json(id);
}