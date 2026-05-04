```
SELECT Name,
       CASE 
           WHEN Price > 100 THEN 'Expensive'
           ELSE 'Affordable'
       END AS PriceCategory
FROM Products;
```
