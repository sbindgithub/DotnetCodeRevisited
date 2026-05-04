# Retry Pattern

## Use Case
- Transient DB/network failures

## Strategy
- Exponential backoff

## Anti-pattern
- Infinite retries
- Retrying non-transient errors

## Interview Insight
Retries should be controlled and combined with circuit breakers.