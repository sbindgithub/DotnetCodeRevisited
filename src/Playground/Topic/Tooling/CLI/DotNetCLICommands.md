# .NET CLI Commands

---

# What is .NET CLI?

.NET CLI (Command Line Interface) is a cross-platform toolchain used to:

- Create projects
- Build applications
- Run applications
- Restore packages
- Manage dependencies
- Publish deployments
- Execute tests

The main command is:

```bash
dotnet
````

---

# Why .NET CLI is Important

Before .NET Core:

* Visual Studio was heavily required
* Windows dependency existed

After .NET CLI:

* Cross-platform development became possible
* Lightweight development workflow introduced
* CI/CD integration improved
* Docker/Kubernetes support became easier
* Cloud-native development accelerated

---

# Check Installed SDK Version

```bash
dotnet --version
```

Shows currently active SDK version.

---

# Show Complete SDK Information

```bash
dotnet --info
```

Displays:

* Installed SDKs
* Installed runtimes
* OS information
* Architecture

---

# Create New Project

## Create Console App

```bash
dotnet new console
```

## Create Web API

```bash
dotnet new webapi
```

## Create MVC App

```bash
dotnet new mvc
```

## Create Class Library

```bash
dotnet new classlib
```

## Create Solution File

```bash
dotnet new sln
```

---

# List Available Templates

```bash
dotnet new list
```

Shows all supported project templates.

---

# Restore NuGet Packages

```bash
dotnet restore
```

Downloads dependencies from NuGet.

Equivalent to:

* NuGet package restore
* dependency resolution

---

# Build Project

```bash
dotnet build
```

Compiles source code into assemblies.

Output:

* DLL
* EXE
* PDB

---

# Run Application

```bash
dotnet run
```

Builds and executes application.

---

# Clean Build Output

```bash
dotnet clean
```

Removes:

* bin/
* obj/

Useful for:

* fixing corrupted builds
* clean CI builds

---

# Add NuGet Package

```bash
dotnet add package Newtonsoft.Json
```

Updates:

* .csproj
* dependency graph

---

# Remove NuGet Package

```bash
dotnet remove package Newtonsoft.Json
```

---

# List Packages

```bash
dotnet list package
```

Displays installed NuGet packages.

---

# Create Solution

```bash
dotnet new sln -n MySolution
```

---

# Add Project to Solution

```bash
dotnet sln add MyProject.csproj
```

---

# Remove Project from Solution

```bash
dotnet sln remove MyProject.csproj
```

---

# Publish Application

## Framework Dependent Deployment

```bash
dotnet publish -c Release
```

Requires .NET runtime installed on server.

---

## Self Contained Deployment

```bash
dotnet publish -c Release -r win-x64 --self-contained true
```

Bundles runtime with application.

Useful for:

* standalone deployment
* isolated runtime execution

---

# Run Unit Tests

```bash
dotnet test
```

Executes automated test cases.

Supports:

* xUnit
* NUnit
* MSTest

---

# Watch Mode

```bash
dotnet watch run
```

Automatically rebuilds when file changes occur.

Useful during development.

---

# Entity Framework Commands

## Install EF Tool

```bash
dotnet tool install --global dotnet-ef
```

---

## Add Migration

```bash
dotnet ef migrations add InitialCreate
```

---

## Update Database

```bash
dotnet ef database update
```

---

# Global Tools

## Install Tool

```bash
dotnet tool install -g <tool-name>
```

Example:

```bash
dotnet tool install -g dotnetsay
```

---

# NuGet Source Management

## List Sources

```bash
dotnet nuget list source
```

## Add Source

```bash
dotnet nuget add source <url>
```

---

# Important Build Configurations

## Debug Build

```bash
dotnet build -c Debug
```

* debugging enabled
* larger binaries
* slower execution

---

## Release Build

```bash
dotnet build -c Release
```

* optimized binaries
* production ready
* smaller output

---

# Common Interview Questions

## Why is .NET CLI important?

Because it enables:

* cross-platform development
* automation
* CI/CD integration
* containerization
* lightweight development

---

## Difference Between Build and Publish

### Build

```bash
dotnet build
```

Only compiles code.

### Publish

```bash
dotnet publish
```

Creates deployable artifacts.

---

## Difference Between Restore and Build

### Restore

Downloads dependencies.

### Build

Compiles project.

---

## Why Self-Contained Deployment?

Because target machine may not have .NET runtime installed.

---

# Architecture Perspective

Modern enterprise systems heavily use .NET CLI in:

* Azure DevOps pipelines
* GitHub Actions
* Docker builds
* Kubernetes deployments
* Jenkins automation
* Linux hosting environments

CLI knowledge is mandatory for architects because enterprise deployment automation depends on it.

---

# Typical Enterprise Build Pipeline

```text
Developer Code
      ↓
dotnet restore
      ↓
dotnet build
      ↓
dotnet test
      ↓
dotnet publish
      ↓
Docker Build
      ↓
CI/CD Deployment
```

---

# Most Important Commands for Interviews

```bash
dotnet new
dotnet restore
dotnet build
dotnet run
dotnet publish
dotnet test
dotnet add package
dotnet ef migrations add
dotnet ef database update
```

---

# Summary

.NET CLI is the backbone of modern .NET development.

It enables:

* automation
* cloud-native development
* cross-platform execution
* CI/CD pipelines
* containerized deployments
* enterprise scalability

```
```
