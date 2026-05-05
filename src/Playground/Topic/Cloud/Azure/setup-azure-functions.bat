@echo off
SETLOCAL

echo Creating Azure Functions Knowledge Structure...

REM Root folder
mkdir AzureFunctions
cd AzureFunctions

REM ========== FOLDER STRUCTURE ==========
mkdir 01_Concepts
mkdir 02_Triggers
mkdir 03_Bindings
mkdir 04_Advanced
mkdir 05_ProductionConcerns
mkdir 06_Comparisons
mkdir 07_RealWorldScenarios
mkdir Samples

REM ========== CONCEPT FILES ==========
echo # Function Types > 01_Concepts\FunctionTypes.md
echo - HTTP >> 01_Concepts\FunctionTypes.md
echo - Timer >> 01_Concepts\FunctionTypes.md
echo - Queue >> 01_Concepts\FunctionTypes.md

echo # Hosting Plans > 01_Concepts\HostingPlans.md
echo - Consumption >> 01_Concepts\HostingPlans.md
echo - Premium >> 01_Concepts\HostingPlans.md
echo - Dedicated >> 01_Concepts\HostingPlans.md

echo # Cold Start > 01_Concepts\ColdStart.md
echo - Causes >> 01_Concepts\ColdStart.md
echo - Mitigation strategies >> 01_Concepts\ColdStart.md

REM ========== TRIGGER FILES ==========
echo # HTTP Trigger > 02_Triggers\HttpTrigger.md
echo When to use: APIs >> 02_Triggers\HttpTrigger.md

echo # Queue Trigger > 02_Triggers\QueueTrigger.md
echo ## Flow >> 02_Triggers\QueueTrigger.md
echo Producer → Queue → Function → DB >> 02_Triggers\QueueTrigger.md
echo ## Failure Handling >> 02_Triggers\QueueTrigger.md
echo - Retry mechanism >> 02_Triggers\QueueTrigger.md
echo - Poison queue >> 02_Triggers\QueueTrigger.md

echo # Timer Trigger > 02_Triggers\TimerTrigger.md
echo Used for scheduled jobs >> 02_Triggers\TimerTrigger.md

echo # Event Hub Trigger > 02_Triggers\EventHubTrigger.md
echo Used for streaming scenarios >> 02_Triggers\EventHubTrigger.md

REM ========== BINDINGS ==========
echo # Input Bindings > 03_Bindings\InputBindings.md
echo # Output Bindings > 03_Bindings\OutputBindings.md

REM ========== ADVANCED ==========
echo # Durable Functions > 04_Advanced\DurableFunctions.md
echo Orchestration patterns >> 04_Advanced\DurableFunctions.md

echo # Dependency Injection > 04_Advanced\DependencyInjection.md
echo How DI works in Functions >> 04_Advanced\DependencyInjection.md

echo # Logging and Monitoring > 04_Advanced\LoggingAndMonitoring.md
echo Use Application Insights >> 04_Advanced\LoggingAndMonitoring.md

REM ========== PRODUCTION ==========
echo # Retry Policies > 05_ProductionConcerns\RetryPolicies.md
echo Exponential backoff >> 05_ProductionConcerns\RetryPolicies.md

echo # Dead Letter Handling > 05_ProductionConcerns\DeadLetterHandling.md
echo Poison queue usage >> 05_ProductionConcerns\DeadLetterHandling.md

echo # Idempotency > 05_ProductionConcerns\Idempotency.md
echo Prevent duplicate processing >> 05_ProductionConcerns\Idempotency.md

echo # Scaling Behavior > 05_ProductionConcerns\ScalingBehavior.md
echo Queue length based scaling >> 05_ProductionConcerns\ScalingBehavior.md

echo # Timeout Handling > 05_ProductionConcerns\TimeoutHandling.md
echo Function timeout limits >> 05_ProductionConcerns\TimeoutHandling.md

REM ========== COMPARISON ==========
echo # Functions vs App Service > 06_Comparisons\FunctionsVsAppService.md
echo # Functions vs AKS > 06_Comparisons\FunctionsVsAKS.md

REM ========== REAL WORLD ==========
echo # Order Processing System > 07_RealWorldScenarios\OrderProcessingSystem.md
echo API → Queue → Function → DB >> 07_RealWorldScenarios\OrderProcessingSystem.md

echo # Background Jobs > 07_RealWorldScenarios\BackgroundJobs.md
echo # Event Driven Pipeline > 07_RealWorldScenarios\EventDrivenPipeline.md

REM ========== MOVE EXISTING FILES ==========
IF EXIST HttpTriggerExample.cs move HttpTriggerExample.cs Samples\
IF EXIST QueueTriggerExample.cs move QueueTriggerExample.cs Samples\
IF EXIST TimerTriggerExample.cs move TimerTriggerExample.cs Samples\

echo.
echo ✅ Azure Functions structure + starter content created successfully.
pause