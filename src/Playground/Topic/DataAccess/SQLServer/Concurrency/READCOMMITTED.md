## 11. 🧵 Concurrency: Avoid Dirty Reads

```
SELECT *
FROM Orders WITH (READCOMMITTED);
```

Real Context
Financial systems
Trap Question.
Difference between NOLOCK vs READ COMMITTED SNAPSHOT

“While reading Orders, only return committed data and respect locks.”

What happens internally

Under READ COMMITTED:

SQL Server acquires shared locks (S locks) on rows/pages being read
It waits if another transaction holds an exclusive lock (X lock)
It does not read uncommitted data