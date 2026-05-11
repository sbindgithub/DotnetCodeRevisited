# Static Files in ASP.NET Core

## What are Static Files?

Static files are files served directly to the client without server-side processing.

Examples:

- HTML
- CSS
- JavaScript
- Images
- Fonts
- PDFs
- Videos

ASP.NET Core serves these files using the Static File Middleware.

---

# Why Static Files Matter

Without static file middleware:

- CSS won't load
- JavaScript won't execute
- Images won't display
- Frontend applications break

Static file handling is a critical part of web application performance.

---

# Default Static File Folder

ASP.NET Core uses:

```text id="l9u2vz"
wwwroot
````

as the web root directory.

Example:

```text id="l0j7sw"
MyApp
 ├── wwwroot
 │    ├── css
 │    ├── js
 │    ├── images
 │    └── lib
```

---

# Enable Static Files

## Program.cs

```csharp id="e5c9up"
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles();

app.Run();
```

---

# Middleware Pipeline Position

Static file middleware should usually appear early.

---

# Correct Order

```csharp id="rq0b9n"
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();
```

Reason:

Static files do not require MVC/controller execution.

Early handling improves performance.

---

# How Static File Middleware Works

## Request Flow

```text id="ps8g2m"
Browser Request
      ↓
Static File Middleware
      ↓
Checks wwwroot
      ↓
File Found?
   YES → Return File
   NO  → Pass To Next Middleware
```

---

# Example Requests

## CSS File

```text id="v8xq4j"
https://localhost:5001/css/site.css
```

Mapped to:

```text id="q2e7cf"
wwwroot/css/site.css
```

---

# Supported File Types

ASP.NET Core serves known MIME types automatically.

Examples:

| Extension | MIME Type              |
| --------- | ---------------------- |
| .css      | text/css               |
| .js       | application/javascript |
| .png      | image/png              |
| .jpg      | image/jpeg             |
| .html     | text/html              |

---

# Unknown File Types

By default:

Unknown file types are blocked.

Security reason:
Prevent accidental exposure.

---

# Enable Unknown Types (Dangerous)

```csharp id="r3z8ft"
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true
});
```

Usually avoid this in production.

---

# Default Files

ASP.NET Core can automatically serve:

* index.html
* default.html

---

# Example

```csharp id="w4kq8c"
app.UseDefaultFiles();
app.UseStaticFiles();
```

---

# Request Example

Request:

```text id="p4y1jr"
https://localhost:5001/
```

Automatically loads:

```text id="s8f0wa"
wwwroot/index.html
```

---

# StaticFileOptions

Customize static file behavior.

---

# Example

```csharp id="t7n4dl"
app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/content"
});
```

Now files are accessed using:

```text id="x9m2cu"
https://localhost:5001/content/image.png
```

---

# Serving Files Outside wwwroot

Possible using PhysicalFileProvider.

---

# Example

```csharp id="k6v1dp"
using Microsoft.Extensions.FileProviders;

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        @"D:\ExternalFiles"),

    RequestPath = "/files"
});
```

---

# Response Caching

Static files support browser caching.

Critical for performance.

---

# Cache Headers Example

```csharp id="b0f4yx"
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append(
            "Cache-Control",
            "public,max-age=600");
    }
});
```

---

# Static Files and Security

## Common Risks

### 1. Exposing Sensitive Files

Never place:

* appsettings.json
* source code
* secrets
* logs

inside wwwroot.

---

### 2. Directory Browsing

Disabled by default.

Good security practice.

---

# Enable Directory Browsing

```csharp id="g1x8qn"
builder.Services.AddDirectoryBrowser();

app.UseDirectoryBrowser();
```

Rarely recommended for production.

---

# SPA Applications

Angular/React apps rely heavily on static files.

Example:

```text id="o3k9fd"
main.js
runtime.js
styles.css
```

ASP.NET Core often acts only as:

* API backend
* Static file host

---

# Internal Architecture

Static file middleware uses:

```text id="e0r2ws"
IFileProvider
```

to abstract file systems.

This enables:

* Physical files
* Embedded files
* Cloud storage integration

---

# Request Processing Internals

Internally:

```text id="n6v5ua"
UseStaticFiles()
        ↓
StaticFileMiddleware
        ↓
FileExtensionContentTypeProvider
        ↓
IFileProvider
        ↓
Physical File Stream
```

---

# Performance Optimizations

Static file middleware supports:

* Efficient streaming
* Range requests
* Browser caching
* Zero-copy optimizations
* Async file handling

Kestrel is highly optimized for static content delivery.

---

# Static Files vs MVC

| Static Files            | MVC                         |
| ----------------------- | --------------------------- |
| Direct file serving     | Dynamic processing          |
| Fast                    | More overhead               |
| No controller execution | Controller/action execution |
| Cached easily           | Often dynamic               |

---

# Real Enterprise Usage

## CDN Integration

Large systems move static assets to:

* Azure CDN
* CloudFront
* Akamai

Reason:
Reduce latency globally.

---

## Versioned Assets

Example:

```text id="f8v1zl"
site.css?v=5
```

Prevents stale browser cache.

---

# ASP.NET Core Tag Helper

```html id="m4u8wx"
<link rel="stylesheet"
      href="~/css/site.css"
      asp-append-version="true" />
```

Automatically appends file hash.

---

# Common Interview Questions

## Q1 — Why UseStaticFiles before UseRouting?

Because static files should bypass MVC pipeline for performance.

---

## Q2 — Can ASP.NET Core serve files outside wwwroot?

Yes using PhysicalFileProvider.

---

## Q3 — Why are unknown file types blocked?

Security protection.

---

## Q4 — Does static file middleware execute controllers?

No.

It short-circuits pipeline when file exists.

---

# Architect-Level Insight

Static file serving looks simple but directly affects:

* Performance
* Scalability
* CDN strategy
* Security posture
* Browser caching efficiency
* Frontend application delivery

Strong architects optimize static delivery aggressively because frontend latency heavily impacts perceived application speed.

```
```
