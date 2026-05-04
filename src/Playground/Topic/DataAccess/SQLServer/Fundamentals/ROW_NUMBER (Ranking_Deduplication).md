```
SELECT *,
       ROW_NUMBER() OVER (PARTITION BY CategoryId ORDER BY Price DESC) AS RowNum
FROM Products;
```

### Use Cases
- Remove duplicates
- Top N per group

DELETE Duplicates (Advanced)
---

### Step 1 — CTE definition

```
WITH CTE AS (
    SELECT *,
           ROW_NUMBER() OVER (PARTITION BY ProductModelID ORDER BY ProductID) AS rn
    FROM SalesLT.Product
)
SELECT * FROM CTE WHERE rn > 1;

```

You are creating a Common Table Expression (CTE) that adds a computed column rn.

The key logic is here:
```

ROW_NUMBER()OVER(PARTITION BY ProductModelID ORDER BY ProductID)
```

### Interpretation:

PARTITION BY ProductModelID
- Groups rows by ProductModelID
- Each group is processed independently
ORDER BY ProductID
- Within each group, rows are sorted by ProductID
ROW_NUMBER()
- Assigns sequential numbers: 1, 2, 3, ...

So for each ProductModelID, numbering restarts from 1.

### Step 2 — What the data looks like inside CTE

| ProductID | ProductModelID | rn |
| --------- | -------------- | -- |
| 101       | 10             | 1  |
| 102       | 10             | 2  |
| 103       | 10             | 3  |
| 201       | 20             | 1  |
| 202       | 20             | 2  |

### Step 3 — Final filter
This removes the first row (rn = 1) from each group.

Result:

| ProductID | ProductModelID | rn |
| --------- | -------------- | -- |
| 102       | 10             | 2  |
| 103       | 10             | 3  |
| 202       | 20             | 2  |

What this query actually does

It returns duplicate rows based on ProductModelID.

Keeps the first occurrence (rn = 1)
Returns all extra rows (rn > 1)