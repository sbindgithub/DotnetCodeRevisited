@echo off
SETLOCAL

echo Creating Azure Architect Structure...

REM ROOT
mkdir Cloud\Azure
cd Cloud\Azure

REM ================== FUNDAMENTALS ==================
mkdir Fundamentals
type nul > Fundamentals\RegionsAndAvailability.md
type nul > Fundamentals\ResourceGroups.md
type nul > Fundamentals\SubscriptionManagement.md
type nul > Fundamentals\PricingAndCosting.md

REM ================== COMPUTE ==================
mkdir Compute

mkdir Compute\VirtualMachines
type nul > Compute\VirtualMachines\VMOverview.md
type nul > Compute\VirtualMachines\VMScaling.md
type nul > Compute\VirtualMachines\AvailabilitySetsVsZones.md

mkdir Compute\AppServices
type nul > Compute\AppServices\WebApps.md
type nul > Compute\AppServices\DeploymentSlots.md
type nul > Compute\AppServices\ScalingAndAutoscale.md

mkdir Compute\AzureFunctions
type nul > Compute\AzureFunctions\FunctionTypes.md
type nul > Compute\AzureFunctions\TriggersAndBindings.md
type nul > Compute\AzureFunctions\DurableFunctions.md
type nul > Compute\AzureFunctions\ColdStart.md

REM ================== STORAGE ==================
mkdir Storage
type nul > Storage\BlobStorage.md
type nul > Storage\FileStorage.md
type nul > Storage\QueueStorage.md
type nul > Storage\TableStorage.md
type nul > Storage\StorageSecurity.md

REM ================== NETWORKING ==================
mkdir Networking
type nul > Networking\VirtualNetwork.md
type nul > Networking\Subnets.md
type nul > Networking\NSG.md
type nul > Networking\LoadBalancer.md
type nul > Networking\ApplicationGateway.md
type nul > Networking\VPNAndExpressRoute.md

REM ================== IDENTITY ==================
mkdir Identity
mkdir Identity\AzureAD

type nul > Identity\AzureAD\Overview.md
type nul > Identity\AzureAD\OAuth_OpenID.md
type nul > Identity\AzureAD\ServicePrincipals.md
type nul > Identity\AzureAD\ManagedIdentity.md

type nul > Identity\RBAC.md
type nul > Identity\ConditionalAccess.md

REM ================== DATABASES ==================
mkdir Databases

mkdir Databases\AzureSQL
type nul > Databases\AzureSQL\DTUvsvCore.md
type nul > Databases\AzureSQL\Scaling.md
type nul > Databases\AzureSQL\GeoReplication.md

mkdir Databases\CosmosDB
type nul > Databases\CosmosDB\APIs.md
type nul > Databases\CosmosDB\Partitioning.md
type nul > Databases\CosmosDB\RUModel.md

type nul > Databases\RedisCache.md

REM ================== MESSAGING ==================
mkdir Messaging

mkdir Messaging\ServiceBus
type nul > Messaging\ServiceBus\QueuesVsTopics.md
type nul > Messaging\ServiceBus\DeadLettering.md

type nul > Messaging\EventGrid.md
type nul > Messaging\EventHub.md

REM ================== DEVOPS ==================
mkdir DevOps
mkdir DevOps\AzureDevOps
mkdir DevOps\AzureDevOps\Pipelines

type nul > DevOps\AzureDevOps\Pipelines\BuildPipeline.md
type nul > DevOps\AzureDevOps\Pipelines\ReleasePipeline.md
type nul > DevOps\AzureDevOps\Pipelines\YAMLPipelines.md
type nul > DevOps\AzureDevOps\Pipelines\MultiStagePipelines.md

type nul > DevOps\GitHubActions.md

REM ================== MONITORING ==================
mkdir Monitoring
type nul > Monitoring\ApplicationInsights.md
type nul > Monitoring\LogAnalytics.md
type nul > Monitoring\Alerts.md
type nul > Monitoring\DistributedTracing.md

REM ================== SECURITY ==================
mkdir Security
type nul > Security\KeyVault.md
type nul > Security\SecretsManagement.md
type nul > Security\Certificates.md
type nul > Security\DefenderForCloud.md

REM ================== ARCHITECTURE ==================
mkdir ArchitecturePatterns
type nul > ArchitecturePatterns\MicroservicesOnAzure.md
type nul > ArchitecturePatterns\ServerlessArchitecture.md
type nul > ArchitecturePatterns\EventDrivenArchitecture.md
type nul > ArchitecturePatterns\MultiTenantDesign.md
type nul > ArchitecturePatterns\HighAvailabilityDesign.md

REM ================== REAL WORLD ==================
mkdir RealWorldScenarios
type nul > RealWorldScenarios\CI_CD_EndToEnd.md
type nul > RealWorldScenarios\ScalingFailureCase.md
type nul > RealWorldScenarios\ProductionOutageRCA.md
type nul > RealWorldScenarios\SecureAPIWithAAD.md
type nul > RealWorldScenarios\QueueBasedLoadLeveling.md

echo.
echo ✅ Azure Architect Structure Created EXACTLY as defined
pause