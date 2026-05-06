# .NET Framework vs .NET Core

# Introduction

Microsoft introduced .NET Framework in 2002 primarily for Windows desktop and enterprise applications.

Over time, software engineering evolved toward:

- Cloud computing
- Linux servers
- Containers
- Microservices
- Cross-platform development
- High-performance APIs

The old .NET Framework architecture could not efficiently support these modern requirements.

Microsoft redesigned the platform and introduced:

- .NET Core
- CoreCLR
- ASP.NET Core
- Modern modular runtime

Today, modern .NET (5/6/7/8+) is the evolution of .NET Core.

---

# High-Level Difference

| .NET Framework | .NET Core / Modern .NET |
|---|---|
| Windows only | Cross-platform |
| Monolithic | Modular |
| IIS dependent | Kestrel + flexible hosting |
| Heavy | Lightweight |
| Machine-wide installation | Side-by-side deployment |
| Limited cloud support | Cloud-native |
| Poor container support | Docker/Kubernetes ready |
| Closed source | Open source |
| Lower performance | High performance |

---

# Historical Architecture

## .NET Framework Architecture

```text id="b1f4jm"
Application
    ↓
CLR
    ↓
System.Web
    ↓
Windows APIs
    ↓
Windows OS