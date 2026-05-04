## NOLOCK (Dirty Read)
```
SELECT * FROM Products WITH (NOLOCK);
```
`WITH (NOLOCK)` is a **table hint** in SQL Server that changes how the engine handles locking during a read.

---

### What it actually does

```sql
SELECT * FROM Products WITH (NOLOCK);
```

This tells SQL Server:

> “Do not acquire shared locks while reading, and do not respect exclusive locks held by other transactions.”

Under the hood, this is equivalent to:

```sql
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
```

So you are reading **uncommitted data**.

---

### Real-life analogy

Think of a cashier updating a ledger:

* Normal read → You wait until the cashier finishes writing
* `NOLOCK` → You peek while the cashier is still writing

You may see:

* Half-written numbers
* Temporary values
* Data that may later be corrected

---

### What problems it introduces

This is where most developers underestimate the risk.

#### 1. Dirty Reads

You read data that is not committed.

Example:

* Transaction A updates price = 500 → not committed
* You read using `NOLOCK` → see 500
* Transaction A rolls back → actual price = 300

You just read **invalid data**.

---

#### 2. Non-repeatable reads

Same query, different result within seconds.

---

#### 3. Phantom reads

Rows may appear/disappear during scan.

---

#### 4. Missing or duplicate rows (critical)

Due to page splits or concurrent updates:

* Same row can appear twice
* Some rows may be skipped entirely

This is not theoretical — it happens under load.

---

### Why people still use it

Because it reduces blocking.

Without NOLOCK:

* SELECT waits if another transaction is updating

With NOLOCK:

* SELECT runs immediately

So it improves:

* Query responsiveness
* Throughput (at the cost of correctness)

---

### When it is acceptable

Use it only when **data accuracy is not critical**:

* Reporting dashboards (approximate data is fine)
* Monitoring queries
* Large analytical reads where slight inconsistency is acceptable

---

### When it is dangerous (you should push back hard)

Never use in:

* Financial transactions (balances, payments)
* Inventory systems
* Order processing
* Anything requiring correctness

If you use NOLOCK there, you are introducing **silent data bugs**.

---

### Better alternatives (architect-level thinking)

Instead of NOLOCK, use:

1. **Read Committed Snapshot Isolation (RCSI)**

   * Uses row versioning
   * No blocking + consistent data

2. **Snapshot Isolation**

   * Stronger consistency guarantees

These solve blocking **without corrupt reads**.

---

### Bottom line

* `NOLOCK` = fast but unsafe
* You trade **data integrity for performance**
* It is not an optimization — it is a **risk decision**

---

