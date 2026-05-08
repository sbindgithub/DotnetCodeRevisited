# Kubernetes Hosting

# What is Kubernetes?

Kubernetes orchestrates containers.

Responsibilities:
- scaling
- self healing
- deployment
- networking

---

# ASP.NET Core in Kubernetes

```text
Ingress
   ↓
Service
   ↓
Pod
   ↓
Kestrel
   ↓
ASP.NET Core App
```

---

# Core Kubernetes Components

## Pod

Smallest deployable unit.

Contains:
- container
- networking
- storage

---

## Service

Stable network endpoint for pods.

---

## Ingress

HTTP routing layer.

---

## Deployment

Controls:
- replica count
- rollout
- rollback

---

# Scaling

```bash
kubectl scale deployment api --replicas=5
```

---

# Self Healing

If pod crashes:
- Kubernetes recreates pod automatically.

---

# Rolling Deployment

Supports zero downtime deployment.

---

# Health Checks

## Liveness Probe

Checks if container is alive.

## Readiness Probe

Checks if container is ready for traffic.

---

# Architect-Level Understanding

Kubernetes shifts operational responsibility from:
- servers
to:
- orchestration platform

This fundamentally changes deployment and scaling architecture.