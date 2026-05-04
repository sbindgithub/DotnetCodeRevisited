

```
MERGE INTO Products AS target
USING (SELECT @Id, @Name, @Price) AS source (Id, Name, Price)
ON target.Id = source.Id
WHEN MATCHED THEN
    UPDATE SET Name = source.Name, Price = source.Price
WHEN NOT MATCHED THEN
    INSERT (Id, Name, Price)
    VALUES (source.Id, source.Name, source.Price);

```
Real Context
Sync systems / APIs
Reality Check

MERGE has issues → many teams avoid it in production