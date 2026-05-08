# Reverse Proxy Architecture

# What is Reverse Proxy?

A reverse proxy receives client requests and forwards them to backend servers.

```text
Client
   ↓
Reverse Proxy
   ↓
Backend Server
```

---

# Common Reverse Proxies

- IIS
- Nginx
- Apache
- YARP
- HAProxy

---

# Why Reverse Proxy is Needed

## SSL Termination

Handles HTTPS certificates centrally.

---

## Load Balancing

Distributes traffic across servers.

---

## Security

Provides:
- WAF (Web Application Firewall)
- request filtering
- IP restrictions

#### Note : A web application firewall (WAF) protects web applications from a variety of application layer attacks such as cross-site scripting (XSS), SQL injection, and cookie poisoning, among others. Attacks to apps are the leading cause of breaches—they are the gateway to your valuable data.
---

## Compression

Compresses HTTP responses.

---

## Static File Optimization

Serves images/js/css efficiently.

---

# ASP.NET Core Reverse Proxy Flow

```text
Browser
   ↓
Nginx
   ↓
Kestrel
   ↓
Middleware
```

---

# Forwarded Headers

Reverse proxy forwards:
- client IP
- protocol
- host

Middleware:

```csharp
app.UseForwardedHeaders();
```

---

# YARP

YARP:
- Yet Another Reverse Proxy
- Microsoft reverse proxy framework

Built on ASP.NET Core.

---

# Interview Question

## Why use reverse proxy if Kestrel already exists?

Because Kestrel focuses on application serving.

Reverse proxies handle:
- internet edge security
- SSL
- traffic routing
- scaling