@echo off
setlocal

:: Ensure base path exists
if not exist Infrastructure mkdir Infrastructure
cd Infrastructure

if not exist DataAccess mkdir DataAccess
cd DataAccess

:: ---------------- SQLServer ----------------
mkdir SQLServer
cd SQLServer

:: Pagination
mkdir Pagination
cd Pagination
type nul > OffsetFetch.md
type nul > KeysetPagination.md
type nul > TotalCountPatterns.md
type nul > InfiniteScrollPatterns.md
cd ..

:: QueryPatterns
mkdir QueryPatterns
cd QueryPatterns
type nul > Filtering.md
type nul > Sorting.md
type nul > Joins.md
type nul > GroupBy_Having.md
type nul > WindowFunctions.md
type nul > CTE.md
type nul > Subqueries_vs_Joins.md
cd ..

:: Performance
mkdir Performance
cd Performance

mkdir Indexing
cd Indexing
type nul > Clustered_vs_NonClustered.md
type nul > CoveringIndex.md
type nul > CompositeIndex.md
type nul > IndexFragmentation.md
cd ..

type nul > ExecutionPlan.md
type nul > QueryOptimization.md
type nul > ParameterSniffing.md
type nul > NPlusOneProblem.md
type nul > CachingStrategies.md
cd ..

:: Transactions
mkdir Transactions
cd Transactions
type nul > ACID.md
type nul > IsolationLevels.md
type nul > Deadlocks.md
type nul > LockingBlocking.md
cd ..

:: Concurrency
mkdir Concurrency
cd Concurrency
type nul > OptimisticConcurrency.md
type nul > PessimisticConcurrency.md
type nul > RowVersioning.md
cd ..

:: StoredProcedures
mkdir StoredProcedures
cd StoredProcedures
type nul > DesignGuidelines.md
type nul > InputOutputParams.md
type nul > ErrorHandling.md
cd ..

:: Security
mkdir Security
cd Security
type nul > SQLInjectionPrevention.md
type nul > LeastPrivilege.md
type nul > DataMasking.md
cd ..

:: DataModeling
mkdir DataModeling
cd DataModeling
type nul > Normalization.md
type nul > Denormalization.md
type nul > IndexStrategy.md
type nul > Partitioning.md
cd ..

cd ..

:: ---------------- ORMs ----------------
mkdir ORMs
cd ORMs

mkdir EFCore
cd EFCore
type nul > DbContextLifecycle.md
type nul > Tracking_vs_NoTracking.md
type nul > Lazy_vs_Eager_Loading.md
type nul > CompiledQueries.md
type nul > Transactions.md
type nul > PerformancePitfalls.md
cd ..

mkdir Dapper
cd Dapper
type nul > Basics.md
type nul > Parameterization.md
type nul > MultiMapping.md
type nul > PerformanceComparison.md
cd ..

cd ..

:: ---------------- Patterns ----------------
mkdir Patterns
cd Patterns
type nul > RepositoryPattern.md
type nul > UnitOfWork.md
type nul > SpecificationPattern.md
type nul > CQRS.md
type nul > OutboxPattern.md
cd ..

:: ---------------- Resilience ----------------
mkdir Resilience
cd Resilience
type nul > RetryPatterns.md
type nul > CircuitBreaker.md
type nul > TimeoutHandling.md
type nul > ConnectionPooling.md
cd ..

:: ---------------- Caching ----------------
mkdir Caching
cd Caching
type nul > InMemoryCache.md
type nul > DistributedCache_Redis.md
type nul > CacheAside.md
type nul > CacheInvalidation.md
cd ..

:: ---------------- MigrationAndVersioning ----------------
mkdir MigrationAndVersioning
cd MigrationAndVersioning
type nul > EFCoreMigrations.md
type nul > SchemaVersioning.md
type nul > BackwardCompatibility.md
cd ..

:: ---------------- Testing ----------------
mkdir Testing
cd Testing
type nul > IntegrationTesting.md
type nul > InMemoryDbTesting.md
type nul > TestContainers.md
cd ..

echo DataAccess structure created successfully.
pause