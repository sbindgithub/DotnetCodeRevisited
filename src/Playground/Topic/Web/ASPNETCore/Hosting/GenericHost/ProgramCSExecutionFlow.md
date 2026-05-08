# Program.cs Execution Flow

# Minimal Hosting Model

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
```

---

# Internal Execution Flow

## 1. CreateBuilder()

Builds:
- configuration
- dependency injection
- logging
- hosting services

---

## 2. Register Services

```csharp
builder.Services.AddControllers();
```

Adds:
- MVC services
- routing
- model binding

---

## 3. Build()

```csharp
var app = builder.Build();
```

Builds middleware pipeline.

---

## 4. Configure Middleware

```csharp
app.UseAuthentication();
```

Registers middleware into request pipeline.

---

## 5. Endpoint Mapping

```csharp
app.MapControllers();
```

Maps routes to endpoints.

---

## 6. Run()

```csharp
app.Run();
```

Starts:
- Kestrel
- HTTP listeners
- request processing loop

---

# Internal Startup Sequence

```text
Program.cs
   ↓
Host Builder
   ↓
Dependency Injection Container
   ↓
Middleware Pipeline
   ↓
Kestrel Startup
   ↓
Request Listening
```

---

# Interview Question

## Why are services registered before Build()?

Because dependency injection container becomes immutable after app.Build().