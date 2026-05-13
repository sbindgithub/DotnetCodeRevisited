# MVC Design Pattern vs ASP.NET Core Framework

## MVC Design Pattern

MVC is a software design pattern.

M = Model
V = View
C = Controller

Purpose:
- Separation of concerns
- Maintainability
- Testability
- Loose coupling

Flow:
User -> Controller -> Model -> View -> Response

Responsibilities:

Model:
- Business logic
- Data
- Validation

View:
- UI rendering
- Display logic only

Controller:
- Handles request
- Calls business layer
- Returns response

MVC is framework independent.

Examples:
- Java Spring MVC
- ASP.NET MVC
- Django MVC-like architecture

---

## ASP.NET Core Framework

ASP.NET Core is a web application framework by Microsoft.

It supports:
- MVC
- Web API
- Razor Pages
- Minimal APIs
- SignalR
- gRPC

Features:
- Cross platform
- High performance
- Built-in Dependency Injection
- Middleware pipeline
- Unified framework

---

## Key Difference

MVC = Architectural Pattern

ASP.NET Core = Framework implementing multiple architectures including MVC