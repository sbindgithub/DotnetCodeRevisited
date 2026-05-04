# Execution Plan

## What to Check
- Table Scan vs Index Seek
- Key Lookup (expensive)
- Missing Index suggestion
- Estimated vs Actual rows mismatch

## Red Flags
- Table Scan on large table
- High cost operators
- Nested loops on large datasets

## Interview Insight
Execution plan is the single source of truth for SQL performance tuning.