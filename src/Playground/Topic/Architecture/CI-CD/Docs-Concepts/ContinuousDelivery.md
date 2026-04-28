
## 2. `ContinuousDelivery.md`

# Continuous Delivery (CD)

## Definition
Continuous Delivery ensures that code is always in a deployable state. Deployment to production is a manual decision.

## Objective
- Enable safe, repeatable deployments
- Minimize release risk
- Maintain production readiness

## Workflow
1. CI pipeline completes successfully
2. Build artifacts are stored
3. Application is deployed to staging
4. Automated + manual validation
5. Ready for production release (manual trigger)

## Key Concepts
- Artifact Repository (e.g., Azure Artifacts, Nexus)
- Staging Environment
- Release Pipelines
- Approval Gates

## Benefits
- Reduced deployment risk
- Faster release cycles
- Better quality assurance

## Example (Azure DevOps YAML)
```yaml
stages:
- stage: Build
  jobs:
  - job: BuildApp
    steps:
    - script: dotnet build

- stage: Deploy_Staging
  dependsOn: Build
  jobs:
  - job: Deploy
    steps:
    - script: echo "Deploying to staging"