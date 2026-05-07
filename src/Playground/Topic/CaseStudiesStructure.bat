:: =====================================================
:: InterviewPreparationStructure.bat
:: =====================================================

@echo off

mkdir InterviewPreparation
cd InterviewPreparation

:: =====================================================
:: Dotnet
:: =====================================================

mkdir Dotnet
cd Dotnet

mkdir Fundamentals
mkdir AdvancedTopics
mkdir RealLifeScenarios
mkdir ArchitectureDiscussions
mkdir ProductionDebugging
mkdir LeadershipQuestions
mkdir MockAnswers

type nul > Fundamentals\BeginnerQuestions.md
type nul > Fundamentals\IntermediateQuestions.md
type nul > Fundamentals\AdvancedQuestions.md

type nul > AdvancedTopics\CLR.md
type nul > AdvancedTopics\GarbageCollection.md
type nul > AdvancedTopics\AsyncAwait.md
type nul > AdvancedTopics\Threading.md

type nul > RealLifeScenarios\MemoryLeakScenario.md
type nul > RealLifeScenarios\DeadlockScenario.md
type nul > RealLifeScenarios\HighCPUScenario.md
type nul > RealLifeScenarios\ThreadPoolStarvation.md

type nul > ArchitectureDiscussions\CleanArchitecture.md
type nul > ArchitectureDiscussions\Microservices.md
type nul > ArchitectureDiscussions\CQRS.md
type nul > ArchitectureDiscussions\EventDrivenArchitecture.md

type nul > ProductionDebugging\DebuggingStrategies.md
type nul > ProductionDebugging\LogAnalysis.md
type nul > ProductionDebugging\PerformanceInvestigation.md

type nul > LeadershipQuestions\ConflictResolution.md
type nul > LeadershipQuestions\Mentoring.md

type nul > MockAnswers\TellMeAboutYourself.md
type nul > MockAnswers\BiggestChallenge.md

cd ..

:: =====================================================
:: ASPNETCore
:: =====================================================

mkdir ASPNETCore
cd ASPNETCore

mkdir Fundamentals
mkdir Middleware
mkdir Security
mkdir RealLifeScenarios
mkdir SystemDesignRounds
mkdir ArchitectureDiscussions
mkdir ProductionFailures

type nul > Fundamentals\Routing.md
type nul > Fundamentals\ModelBinding.md
type nul > Fundamentals\DependencyInjection.md

type nul > Middleware\CustomMiddleware.md
type nul > Middleware\ExceptionHandling.md

type nul > Security\JWT.md
type nul > Security\OAuth.md
type nul > Security\OpenIDConnect.md

type nul > RealLifeScenarios\RedisFailureInterviewVersion.md
type nul > RealLifeScenarios\AuthenticationFailure.md
type nul > RealLifeScenarios\HighLatencyIssue.md
type nul > RealLifeScenarios\ScalingIssue.md

type nul > SystemDesignRounds\DesignECommerceAPI.md
type nul > SystemDesignRounds\DesignNotificationService.md

type nul > ArchitectureDiscussions\APIversioning.md
type nul > ArchitectureDiscussions\BFFPattern.md

type nul > ProductionFailures\MemoryLeak.md
type nul > ProductionFailures\ConnectionPoolIssue.md

cd ..

:: =====================================================
:: SQL
:: =====================================================

mkdir SQL
cd SQL

mkdir QueryOptimization
mkdir Indexing
mkdir RealLifeScenarios
mkdir ProductionFailures
mkdir Troubleshooting

type nul > QueryOptimization\ExecutionPlans.md
type nul > QueryOptimization\QueryTuning.md

type nul > Indexing\ClusteredIndex.md
type nul > Indexing\NonClusteredIndex.md

type nul > RealLifeScenarios\DeadlockScenario.md
type nul > RealLifeScenarios\BlockingIssue.md

type nul > ProductionFailures\DatabaseOutage.md
type nul > ProductionFailures\ReplicationLag.md

type nul > Troubleshooting\SlowQueries.md
type nul > Troubleshooting\TempDBIssues.md

cd ..

:: =====================================================
:: Azure
:: =====================================================

mkdir Azure
cd Azure

mkdir Compute
mkdir Storage
mkdir Networking
mkdir Security
mkdir RealLifeScenarios
mkdir SystemDesignRounds

type nul > Compute\AppServices.md
type nul > Compute\AzureFunctions.md
type nul > Compute\AKS.md

type nul > Storage\BlobStorage.md
type nul > Storage\CosmosDB.md

type nul > Networking\VNet.md
type nul > Networking\PrivateEndpoints.md

type nul > Security\ManagedIdentity.md
type nul > Security\KeyVault.md

type nul > RealLifeScenarios\AzureRegionFailure.md
type nul > RealLifeScenarios\ServiceBusDLQ.md

type nul > SystemDesignRounds\DesignGlobalApplication.md
type nul > SystemDesignRounds\DesignEventDrivenSystem.md

cd ..

:: =====================================================
:: Microservices
:: =====================================================

mkdir Microservices
cd Microservices

mkdir Fundamentals
mkdir Communication
mkdir Resilience
mkdir DistributedSystems
mkdir RealLifeScenarios

type nul > Fundamentals\ServiceDiscovery.md
type nul > Fundamentals\APIGateway.md

type nul > Communication\SyncVsAsync.md
type nul > Communication\EventDrivenCommunication.md

type nul > Resilience\CircuitBreaker.md
type nul > Resilience\RetryPattern.md

type nul > DistributedSystems\CAPTheorem.md
type nul > DistributedSystems\EventualConsistency.md

type nul > RealLifeScenarios\DistributedTransactionFailure.md
type nul > RealLifeScenarios\MessageDuplication.md

cd ..

:: =====================================================
:: System Design
:: =====================================================

mkdir SystemDesign
cd SystemDesign

mkdir HLD
mkdir LLD
mkdir Scalability
mkdir DistributedSystems
mkdir MockDesigns

type nul > HLD\HighLevelArchitecture.md
type nul > LLD\LowLevelDesign.md

type nul > Scalability\LoadBalancing.md
type nul > Scalability\Caching.md

type nul > DistributedSystems\ConsistencyModels.md
type nul > DistributedSystems\PartitionTolerance.md

type nul > MockDesigns\URLShortener.md
type nul > MockDesigns\PaymentGateway.md
type nul > MockDesigns\BookingSystem.md

cd ..

:: =====================================================
:: Leadership
:: =====================================================

mkdir Leadership
cd Leadership

type nul > TeamManagement.md
type nul > StakeholderManagement.md
type nul > TechnicalDecisionMaking.md
type nul > ConflictHandling.md
type nul > OwnershipExamples.md
type nul > DeliveryPressureHandling.md

cd ..

echo InterviewPreparation structure created successfully.
pause