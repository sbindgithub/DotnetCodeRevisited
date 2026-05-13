# Role Of Reflection In MVC

Namespace:

using System.Reflection;

Reflection is used internally by ASP.NET Core MVC for:
- Discovering controllers
- Discovering action methods
- Dependency injection
- Model binding
- Attribute scanning

---

Assembly Loading:

Assembly.Load()

Example:

Assembly myAssembly =
    Assembly.Load("MyProject");

Type myType =
    myAssembly.GetType("Student");

object dynamicObject =
    Activator.CreateInstance(myType);

Type parameterType =
    dynamicObject.GetType();

parameterType.InvokeMember();

---

MVC Internals Use Reflection For:
- Controller activation
- Route discovery
- Attribute routing
- Filters
- Dependency injection