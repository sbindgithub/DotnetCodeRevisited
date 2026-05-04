# Rainbow Table Attack

## Definition

A Rainbow Table attack is a **precomputed hash lookup attack** used to reverse cryptographic hash functions, primarily targeting **unsalted password hashes**.

Instead of hashing passwords on the fly (as in brute force), attackers use a prebuilt table of:

```
plaintext password → hash
```

to quickly find matches.

---

## How It Works

1. Attacker generates hashes for millions/billions of common passwords.
2. Stores them in a lookup table (rainbow table).
3. When a database is leaked:

   * Compare stored hashes with table
   * If match found → original password recovered instantly

---

## Why It Is Dangerous

* Extremely fast lookup (O(1) style access)
* No need to recompute hashes
* Works effectively on:

  * MD5
  * SHA1
  * Unsalted SHA256

---

## Example Scenario

Database:

```
PasswordHash = 5f4dcc3b5aa765d61d8327deb882cf99
```

Rainbow table contains:

```
5f4dcc3b5aa765d61d8327deb882cf99 → password
```

Result:
→ Password is cracked instantly

---

## Limitations of Rainbow Tables

* Ineffective against **salted hashes**
* Storage heavy (huge tables required)
* Less useful with slow hashing algorithms (PBKDF2, bcrypt, Argon2)

---

## Related Attacks

* Brute Force Attack
* Dictionary Attack
* Credential Stuffing

---

## Defense Against Rainbow Table Attacks

### 1. Salting (Critical)

Add a unique random value to each password before hashing:

```
Hash = Hash(password + salt)
```

Effect:

* Same password → different hash per user
* Rainbow tables become useless

---

### 2. Key Stretching

Use slow hashing algorithms:

* PBKDF2
* bcrypt
* Argon2

This increases computation cost, making attacks impractical.

---

## .NET Implementation Mapping

### Recommended Approach

Use:

* `PasswordHasher<T>` (ASP.NET Core Identity)

It automatically:

* Generates salt
* Applies PBKDF2
* Stores versioned hash

### Example

```csharp
var hasher = new PasswordHasher<string>();

string hash = hasher.HashPassword(null, "MySecurePassword");

// Verify
var result = hasher.VerifyHashedPassword(null, hash, "MySecurePassword");
```

---

## What NOT to Do

* Do NOT use:

  * MD5
  * SHA1
  * Plain SHA256 without salt

* Do NOT store:

  * Plain passwords
  * Same salt for all users

---

## Key Insight (Architect View)

Rainbow table attacks exist because:

* Systems optimize for speed (fast hashing)
* Attackers exploit that speed

Modern security flips this:
→ Make hashing intentionally slow + unique per user

---

## Summary

| Aspect          | Impact                  |
| --------------- | ----------------------- |
| Attack Type     | Credential attack       |
| Target          | Unsalted hashes         |
| Speed           | Very fast               |
| Primary Defense | Salt + Slow hashing     |
| .NET Solution   | PasswordHasher (PBKDF2) |
