# Tracking vs NoTracking

## Tracking
- EF tracks entity changes
- Used for updates

## NoTracking
- Faster, read-only queries

## Example
context.Products.AsNoTracking().ToList();

## Interview Insight
Always use AsNoTracking() for read-heavy queries to reduce memory and CPU overhead.