:: =====================================================
:: CaseStudiesStructure.bat
:: =====================================================

@echo off

mkdir CaseStudies
cd CaseStudies

:: =====================================================
:: Production Failures
:: =====================================================

mkdir ProductionFailures
cd ProductionFailures

type nul > RedisConnectionExhaustion.md
type nul > SQLDeadlockIssue.md
type nul > MemoryLeakInAPI.md
type nul > HighCPUUsage.md
type nul > ThreadPoolStarvation.md
type nul > KafkaConsumerLag.md
type nul > ServiceBusDLQIssue.md
type nul > APIThrottling.md
type nul > AzureFunctionTimeout.md
type nul > KubernetesPodCrashLoop.md
type nul > AuthenticationFailure.md
type nul > TokenExpirationIssue.md
type nul > DNSResolutionFailure.md
type nul > CacheStampede.md
type nul > ConnectionPoolExhaustion.md
type nul > FileHandleLeak.md
type nul > StorageAccountLatency.md
type nul > CircuitBreakerFailure.md
type nul > DistributedTransactionFailure.md
type nul > DependencyOutage.md

cd ..

:: =====================================================
:: Scaling Problems
:: =====================================================

mkdir ScalingProblems
cd ScalingProblems

type nul > HorizontalScalingFailure.md
type nul > DatabaseBottleneck.md
type nul > ReadReplicaLag.md
type nul > HotPartitionProblem.md
type nul > LoadBalancerMisconfiguration.md
type nul > SessionAffinityIssue.md
type nul > QueueBackPressure.md
type nul > LargePayloadPerformanceIssue.md
type nul > MultiRegionReplicationProblem.md
type nul > AutoScalingDelay.md

cd ..

:: =====================================================
:: Security Incidents
:: =====================================================

mkdir SecurityIncidents
cd SecurityIncidents

type nul > SQLInjectionIncident.md
type nul > XSSAttack.md
type nul > CSRFIncident.md
type nul > JWTTokenLeak.md
type nul > SecretsExposure.md
type nul > MisconfiguredStorage.md
type nul > PrivilegeEscalation.md
type nul > APIKeyExposure.md
type nul > RansomwareScenario.md
type nul > DDOSAttack.md

cd ..

:: =====================================================
:: Performance Issues
:: =====================================================

mkdir PerformanceIssues
cd PerformanceIssues

type nul > SlowAPIResponse.md
type nul > NPlusOneQueryProblem.md
type nul > ExcessiveGCPressure.md
type nul > BlockingCalls.md
type nul > SerializationOverhead.md
type nul > LargeObjectHeapIssue.md
type nul > SlowDatabaseQuery.md
type nul > ExcessiveLogging.md
type nul > ChattyMicroservices.md
type nul > InefficientCaching.md

cd ..

:: =====================================================
:: Outages
:: =====================================================

mkdir Outages
cd Outages

type nul > AzureRegionOutage.md
type nul > DatabaseFailoverIssue.md
type nul > KubernetesClusterFailure.md
type nul > ThirdPartyDependencyOutage.md
type nul > CDNFailure.md
type nul > DNSOutage.md
type nul > MessageBrokerFailure.md
type nul > PaymentGatewayDowntime.md
type nul > SSLCertificateExpiry.md
type nul > ProductionDeploymentFailure.md

cd ..

:: =====================================================
:: Architecture Reviews
:: =====================================================

mkdir ArchitectureReviews
cd ArchitectureReviews

type nul > MonolithToMicroservices.md
type nul > ModularMonolithReview.md
type nul > EventDrivenArchitectureReview.md
type nul > CQRSReview.md
type nul > BFFArchitectureReview.md
type nul > APIBasedIntegrationReview.md
type nul > MultiTenantArchitecture.md
type nul > ScalabilityAssessment.md
type nul > CloudMigrationReview.md
type nul > CostOptimizationReview.md

cd ..

:: =====================================================
:: Root Cause Analysis
:: =====================================================

mkdir RootCauseAnalysis
cd RootCauseAnalysis

type nul > FiveWhys.md
type nul > FishboneAnalysis.md
type nul > IncidentTimeline.md
type nul > CorrectiveActions.md
type nul > PreventiveActions.md
type nul > MonitoringGapAnalysis.md

cd ..

echo CaseStudies structure created successfully.
pause