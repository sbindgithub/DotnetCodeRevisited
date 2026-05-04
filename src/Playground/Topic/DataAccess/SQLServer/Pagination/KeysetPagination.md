# Keyset Pagination (Seek Method)

## Query
```
SELECT * FROM Products
WHERE Id > @LastSeenId
ORDER BY Id
LIMIT @PageSize
```

## Pros
- Highly performant (uses index seek)
- Stable pagination

## Cons
- Cannot jump to arbitrary page
- Requires deterministic ordering

## When to Use
- Infinite scroll
- APIs with large datasets

## Interview Insight
Keyset pagination is O(page size), OFFSET is O(n).