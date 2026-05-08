# Cloud Native Hosting

# What is Cloud Native?

Cloud-native applications are designed for:
- scalability
- resilience
- containerization
- distributed systems

---

# Traditional Hosting

```text
IIS Server
   ↓
Monolithic Application
```

---

# Cloud Native Hosting

```text
Load Balancer
   ↓
Ingress
   ↓
Containers
   ↓
Kubernetes Pods
```

---

# ASP.NET Core Advantages

ASP.NET Core supports:
- Linux
- Containers
- Kubernetes
- Microservices
- Stateless hosting

---

# Container Hosting

Application packaged as:

```text
Docker Image
```

---

# Benefits

- Horizontal scaling
- Immutable deployment
- Faster recovery
- Auto healing
- Infrastructure automation

---

# 12 Factor Principles

Cloud-native apps should:
- externalize config
- remain stateless
- support disposability
- support scaling

---

# Production Stack Example

```text
Azure Front Door
    ↓
Kubernetes Ingress
    ↓
ASP.NET Core Pods
    ↓
Redis Cache
    ↓
SQL Database
```

---

# Important Architect Understanding

Cloud-native architecture changes:
- deployment strategy
- observability
- scaling model
- fault tolerance

Not just hosting location.