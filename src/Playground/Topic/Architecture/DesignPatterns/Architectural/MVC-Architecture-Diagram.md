Request Flow:
# MVC Architecture Diagram

```text
+-------------------+
|      Browser      |
+-------------------+
          |
          v
+-------------------+
| Routing Middleware|
+-------------------+
          |
          v
+-------------------+
|    Controller     |
+-------------------+
          |
          +------------------+
          |                  |
          v                  |
+-------------------+        |
|       Model       |        |
+-------------------+        |
          |                  |
          +------------------+
          |
          v
+-------------------+
|       View        |
+-------------------+
          |
          v
+-------------------+
|   HTML Response   |
+-------------------+
```

## Flow Explanation

1. Browser sends HTTP request.
2. Routing middleware maps URL to controller action.
3. Controller handles request.
4. Controller communicates with Model.
5. Model returns data.
6. Controller sends model to View.
7. View generates HTML.
8. HTML response returns to browser.

---

Example:

URL:
https://localhost:5001/student/details/10

Routing:
StudentController -> Details(10)

Controller:
Gets data from Model

Model:
Fetches data from database/service

View:
Renders HTML

Response:
Returned to browser