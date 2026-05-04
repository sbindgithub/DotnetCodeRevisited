# SQL Injection

## Attack

User input alters query:

```sql
SELECT * FROM Users WHERE Name = 'a' OR 1=1 --'
```

## Impact

* Data exfiltration
* Auth bypass
* Data modification

## Defense

* **Parameterized queries** (always)
* ORM (EF Core) by default parameterizes
* Input validation (secondary)

## .NET Example

```csharp
var user = await context.Users
  .Where(u => u.Name == input)
  .FirstOrDefaultAsync();
```

Dapper:

```csharp
connection.Query("SELECT * FROM Users WHERE Name=@name",
                 new { name = input });
```

## What NOT to Do

* String concatenation
* Dynamic SQL with raw input

## Interview Line

“Primary defense is parameterization; validation is not sufficient alone.”
