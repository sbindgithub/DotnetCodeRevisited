# Parameter Sniffing

## Problem
SQL Server caches execution plan based on first parameter value.

## Impact
- Good plan for one input
- Bad plan for another → performance degradation

## Solutions
- OPTION (RECOMPILE)
- OPTIMIZE FOR UNKNOWN
- Use local variables

## Interview Insight
Parameter sniffing is a silent production killer in high-load systems.