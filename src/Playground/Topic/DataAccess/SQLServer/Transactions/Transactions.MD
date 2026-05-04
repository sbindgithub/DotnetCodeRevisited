```
BEGIN TRY
    BEGIN TRANSACTION;

    UPDATE Accounts 
    SET Balance = Balance - 100 
    WHERE Id = 1;

    UPDATE Accounts 
    SET Balance = Balance + 100 
    WHERE Id = 2;

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;

    -- Optional: log error
    SELECT ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
```

Step-by-step execution (real-world thinking)
Case 1 — Success
Both updates succeed
COMMIT executes
Changes are permanent
Case 2 — Failure (e.g., Account 2 does not exist)
First update runs → balance reduced
Second update fails
Control goes to CATCH
ROLLBACK executes

Result:

Account 1 restored to original ₹1000
No money lost
System remains consistent

Why this matters (ACID concept)

This is enforcing Atomicity:

Either all operations succeed, or none of them do.

No partial updates allowed.