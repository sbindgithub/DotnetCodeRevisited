# SQL Injection Prevention

## Always Use
- Parameterized queries

## Avoid
- String concatenation

## Example
SELECT * FROM Users WHERE Id = @Id

## Interview Insight
ORMs reduce risk, but raw SQL still requires strict parameterization.