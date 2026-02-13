# Architectural Trade-off

IEnumerable<T>:
- Simple
- Flexible
- But memory heavy

IQueryable<T>:
- Efficient for large datasets
- But restricted to translatable logic

Choosing incorrectly leads to scalability problems.
