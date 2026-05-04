# EF Core Performance Pitfalls

## Issues
- N+1 queries (lazy loading)
- Over-fetching columns
- Tracking overhead
- Client-side evaluation

## Fixes
- Use Include() wisely
- Use projection (Select)
- Disable tracking
- Use compiled queries

## Interview Insight
EF Core is not slow — misuse of EF Core is slow.