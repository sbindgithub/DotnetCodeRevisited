# Dapper Basics

## Example
var result = connection.Query<Product>(
    "SELECT * FROM Products WHERE Id = @Id",
    new { Id = id });

## Pros
- Near ADO.NET performance
- Simple mapping

## Cons
- No change tracking
- Manual query management

## Interview Insight
Dapper is ideal for read-heavy microservices where performance matters.