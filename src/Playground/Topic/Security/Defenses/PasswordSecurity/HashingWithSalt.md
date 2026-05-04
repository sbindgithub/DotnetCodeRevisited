# Password Hashing with Salt

## Core Idea

Never store plain passwords. Store:

```text
hash = KDF(password + salt)
```

* **Salt**: random, unique per user
* **KDF**: slow hashing (PBKDF2/bcrypt/Argon2)

## Why Salt

* Same password → different hash per user
* Defeats rainbow tables and hash reuse

## Why Slow Hashing

* Increases cost of brute-force/dictionary attacks
* Tunable work factor

## .NET Implementation

Use ASP.NET Core Identity:

```csharp
var hasher = new PasswordHasher<string>();
var hash = hasher.HashPassword(null, "P@ssw0rd!");
var result = hasher.VerifyHashedPassword(null, hash, "P@ssw0rd!");
```

* Internally uses **PBKDF2**, includes salt and iteration count.

## Storage Pattern

Single field is enough (Identity embeds salt + params in the hash).
If custom:

```text
UserId | Salt | Hash | Iterations
```

## What NOT to Do

* MD5/SHA1/SHA256 (fast, unsalted)
* Global/shared salt
* Reversible encryption for passwords

## Interview Line

“Use per-user salt + PBKDF2/bcrypt/Argon2. In .NET, `PasswordHasher` handles salt and work factor; never use fast hashes.”
