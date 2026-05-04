# OFFSET-FETCH Pagination

## Query

```
SELECT * FROM Products
ORDER BY Id
OFFSET @PageSize * (@PageNumber - 1) ROWS
FETCH NEXT @PageSize ROWS ONLY
```

## Pros
- Simple, widely supported
- Works well for small datasets

## Cons
- Performance degrades on large offsets (full scan)
- Not stable if data changes between requests

## When to Use
- Admin dashboards
- Small/medium datasets

## Interview Insight
OFFSET pagination is not scalable beyond large datasets due to increasing scan cost.
Prefer Keyset Pagination for high-performance systems.