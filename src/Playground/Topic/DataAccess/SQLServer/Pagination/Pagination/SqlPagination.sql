SELECT Id, Name, Price
FROM Products
ORDER BY Id
OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY;


SELECT TOP (@PageSize) Id, Name, Price
FROM Products
WHERE Id > @LastId
ORDER BY Id;


--Keyset Pagination (High Performance)
  SELECT TOP 3 * FROM SalesLT.Customer
  WHERE CustomerID>5
  ORDER BY CustomerID


--TOP N Records
  SELECT TOP 10 *
FROM Products
ORDER BY Price DESC;


-- OFFSET-FETCH Pagination and Window Functions, we can use the COUNT(*) OVER() to get the total count of records along with the paginated results.
SELECT COUNT(*) OVER() AS TotalCount
      ,[NameStyle]
      ,[Title]
      ,[FirstName]
FROM SalesLT.Customer
ORDER BY CustomerID
OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY;