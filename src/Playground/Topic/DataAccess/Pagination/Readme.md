```
{
  "pageNumber": 2,
  "pageSize": 10,
  "totalRecords": 105,
  "data": [ ... ]
}
```
 # Pagination in Data Access

## 1. Overview

Pagination is a data retrieval technique used to fetch records in chunks (pages) instead of loading the entire dataset at once. It is essential for performance, scalability, and user experience in backend systems.

---

## 2. Why Pagination Matters

* Reduces database load
* Improves API response time
* Prevents memory overuse
* Enables better UI/UX (page navigation, infinite scroll)

---

## 3. Basic Pagination Formula

* PageNumber = 1-based index
* PageSize = number of records per page

```
OFFSET = (PageNumber - 1) * PageSize
```

---

## 4. SQL Server Implementation (OFFSET-FETCH)

```sql
SELECT Id, Name, Price
FROM Products
ORDER BY Id
OFFSET (@PageNumber - 1) * @PageSize ROWS
FETCH NEXT @PageSize ROWS ONLY;
```

### Notes:

* `ORDER BY` is mandatory
* Works efficiently for small to medium datasets
* Performance degrades for large offsets

---

## 5. Stored Procedure Example

```sql
CREATE PROCEDURE GetPagedProducts
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name, Price
    FROM Products
    ORDER BY Id
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END
```

---

## 6. C# Example (ADO.NET)

```csharp
public async Task<List<Product>> GetPagedProducts(int pageNumber, int pageSize)
{
    var products = new List<Product>();

    using (SqlConnection con = new SqlConnection(connectionString))
    {
        await con.OpenAsync();

        using (SqlCommand cmd = new SqlCommand("GetPagedProducts", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
            cmd.Parameters.AddWithValue("@PageSize", pageSize);

            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    products.Add(new Product
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"])
                    });
                }
            }
        }
    }

    return products;
}
```

---

## 7. Limitations of OFFSET Pagination

* Slow for large page numbers (e.g., page 10000)
* Requires scanning skipped rows
* Not suitable for real-time/high-scale systems

---

## 8. Keyset Pagination (Better Alternative)

Instead of OFFSET, use a cursor-based approach:

```sql
SELECT TOP (@PageSize) *
FROM Products
WHERE Id > @LastSeenId
ORDER BY Id;
```

### Advantages:

* Faster for large datasets
* Uses index efficiently
* Scales better in production systems

---

## 9. When to Use What

| Scenario          | Recommended Approach    |
| ----------------- | ----------------------- |
| Small dataset     | OFFSET-FETCH            |
| Medium dataset    | OFFSET-FETCH with index |
| Large dataset     | Keyset pagination       |
| Real-time systems | Keyset pagination       |

---

## 10. Best Practices

* Always use `ORDER BY`
* Ensure indexed columns for sorting
* Return total count if needed (separate query)
* Validate pageNumber and pageSize
* Avoid very large page sizes

---

## 11. API Design Considerations

### Option 1: Route-based

```
/api/products/page/2/size/10
```

### Option 2: Query-based (preferred)

```
/api/products?pageNumber=2&pageSize=10
```

---

## 12. Summary

Pagination is not just about splitting data — it directly impacts:

* Performance
* Scalability
* Database efficiency

For real-world systems, OFFSET is only the starting point. Advanced systems rely on keyset pagination for better performance.

