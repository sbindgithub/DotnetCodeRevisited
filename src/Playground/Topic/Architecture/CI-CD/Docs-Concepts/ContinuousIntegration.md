# Continuous Integration (CI)

## Definition
Continuous Integration (CI) is the practice of frequently merging code changes into a shared repository, followed by automated build and test execution.

## Objective
- Detect integration issues early
- Maintain a stable codebase
- Reduce manual effort in validation

## CI Workflow
1. Developer commits code to repository
2. Pipeline triggers automatically
3. Build process executes
4. Automated tests run
5. Feedback provided immediately

## Key Components
- Source Control (Git)
- Build Server (Azure DevOps, GitHub Actions, Jenkins)
- Automated Tests (Unit, Integration)
- Artifact Generation

## Benefits
- Early bug detection
- Faster feedback loop
- Improved collaboration
- Reduced integration conflicts

## Example (GitHub Actions)
```yaml
name: CI Basic

on:
  push:
    branches: [ "main" ]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
      - uses: actions/checkout@v3
      - name: Build
        run: dotnet build
      - name: Test
        run: dotnet test