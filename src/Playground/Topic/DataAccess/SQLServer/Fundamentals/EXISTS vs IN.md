-- EXISTS
```
SELECT *
FROM Orders o
WHERE EXISTS (
    SELECT 1 FROM Customers c WHERE c.Id = o.CustomerId
);

```

-- IN
```
SELECT *
FROM Orders
WHERE CustomerId IN (SELECT Id FROM Customers);
```

Difference
EXISTS → stops early (better for large datasets)
IN → loads full list

👉 Answer Like This:

“EXISTS is generally more efficient for correlated subqueries.”