# Controller Activation

ASP.NET Core creates controllers dynamically.

Interface:

IControllerActivator

Methods:
- Create()
- Release()
- ReleaseAsync()

Default Implementation:
DefaultControllerActivator

---

Flow:

Request
  ->
Routing
  ->
ControllerFactory
  ->
ControllerActivator
  ->
Controller Object Creation

---

Controller Dispose

Controllers support Dispose().

Used for:
- Releasing unmanaged resources
- Database connections
- Streams