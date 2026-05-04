📦 Bulk Insert Optimization

```sql
INSERT INTO Products (Name, Price)
SELECT Name, Price
FROM StagingProducts;
```