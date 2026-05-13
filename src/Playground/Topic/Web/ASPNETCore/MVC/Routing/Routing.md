# Routing in ASP.NET Core

Routing maps URL to controller action.

Middleware:

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

---

Default Route:

{controller=Home}/{action=Index}/{id?}

Examples:

/student/details/10

Controller = Student
Action = Details
Id = 10

---

Query String Examples:

/student/getstudentbyid/10

/student/getstudentbyid?id=10

/student/getstudentbyid?id=10&gender=male

---

MapDefaultControllerRoute()

Internally maps:

pattern:
"{controller=Home}/{action=Index}/{id?}"

Default Controller:
Home

Default Action:
Index

id is optional due to ?