
# Creating a Docker Image (Dockerfile Basics)

## 1. What is a Dockerfile

A Dockerfile is a script that defines how to build a Docker image.

It contains step-by-step instructions to:
- Prepare environment
- Copy application
- Run application

---

## 2. Basic Structure of a Dockerfile

### Example (.NET)

```dockerfile
# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ProductManagementApi.csproj", "./"]
RUN dotnet restore "ProductManagementApi.csproj"
COPY . .
RUN dotnet publish "ProductManagementApi.csproj" -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:8081
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProductManagementApi.dll"]
````

---

## 3. Dockerfile Instructions

### FROM

* Defines base image

Example:
FROM mcr.microsoft.com/dotnet/aspnet:8.0

---

### WORKDIR

* Sets working directory inside container

Example:
WORKDIR /app

---

### COPY

* Copies files from host → container

Example:
COPY . .

---

### RUN

* Executes commands during build

Example:
RUN dotnet restore

---

### EXPOSE

* Declares container port (documentation purpose)

Example:
EXPOSE 8081

⚠️ Does NOT publish port to host

---

### ENV

* Sets environment variables

Example:
ENV ASPNETCORE_URLS=http://+:8081

---

### ENTRYPOINT

* Defines startup command

Example:
ENTRYPOINT ["dotnet", "ProductManagementApi.dll"]

---

## 4. Port Mapping (Important Distinction)

### In Dockerfile:

```dockerfile
EXPOSE 8081
```

### At runtime:

```bash
docker run -d -p 8081:8081 myapi
```

Meaning:

Host Machine Port: 8081
Container Port: 8081

Flow:
Client → localhost:8081 → container:8081

---

## 5. Multi-Stage Build (Why Used)

* Reduces image size
* Separates build tools from runtime

Stages:

* build → compile app
* final → run app

---

## 6. .dockerignore

Prevents unnecessary files from being copied

### Example

```
bin/
obj/
.git/
node_modules/
*.log
```

Why:

* Faster build
* Smaller image
* Avoid sensitive data

---

## 7. Build Docker Image

```bash
docker build -t productmanagementapi .
```

* -t → tag name
* . → current directory (Dockerfile location)

---

## 8. Run Container

```bash
docker run -d -p 8081:8081 productmanagementapi
```

---

## 9. Common Mistakes

* Using large base images
* Not using multi-stage builds
* Copying entire project unnecessarily
* Forgetting .dockerignore
* Confusing EXPOSE with port mapping

---

## 10. Architect-Level Understanding

You must answer:

### Q1: Why multi-stage build?

* Reduce image size
* Remove SDK from runtime

---

### Q2: Why EXPOSE is not enough?

* It does not bind to host
* Only documents container port

---

### Q3: What happens during docker build?

1. Reads Dockerfile
2. Executes instructions layer by layer
3. Creates image

---

## 11. Summary

* Dockerfile → blueprint
* Image → built artifact
* Container → running instance
* EXPOSE → container port
* -p → host binding

````

---

## 🔥 What You Must Realize

From your screenshot:

You’re already using **multi-stage build** — that’s good.

But if I ask:

> “Why is your image size still large?”

You should check:
- Base image  
- Unnecessary COPY  
- Missing `.dockerignore`  

---

## 🎯 Next Step

Create:

```text
Cloud/Containers/Docker/Dockerfile_Optimization.md
````

And include:

* Alpine images
* Layer caching
* Reducing build time

---

