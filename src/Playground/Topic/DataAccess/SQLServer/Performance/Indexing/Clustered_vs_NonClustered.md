# Clustered vs Non-Clustered Index

## Clustered
- Defines physical order of table
- Only one per table
- Best for range queries

## Non-Clustered
- Separate structure with pointer to data
- Multiple allowed
- Good for selective queries

## Interview Insight
Clustered index should be on frequently sorted/range columns (e.g., Id, Date).
Wrong clustered index = table scan penalty.