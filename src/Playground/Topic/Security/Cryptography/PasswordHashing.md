```mermaid
flowchart TB

%% ===== TITLE =====
%% Password Hashing in ASP.NET Core Web API

%% ===== LEFT FLOW =====
subgraph REG["Registration Flow"]
direction TB

R1["User inputs password"]
R2["Generate random salt<br/>with HMACSHA512"]
R3["Compute passwordHash =<br/>HMACSHA512 (salt, password)"]
R4["Store salt and passwordHash<br/>in Database"]

R1 --> R2
R2 --> R3
R3 --> R4
end

%% ===== RIGHT FLOW =====
subgraph LOG["Login Flow"]
direction TB

L1["User inputs password"]
L2["Retrieve salt and stored<br/>hash from Database"]
L3["Compute HMACSHA512<br/>(salt, entered password)"]
L4["Compare computed hash<br/>with stored hash"]

L1 --> L2
L2 --> L3
L3 --> L4
end

%% ===== DATABASE =====
DB[(Database)]

R4 --> DB
L4 --> DB

%% ===== STYLING =====
style REG fill:#ffffff,stroke:#ffffff,color:#000000
style LOG fill:#ffffff,stroke:#ffffff,color:#000000

style R1 fill:#dce9f8,stroke:#7f9db9,stroke-width:2px,color:#000
style R2 fill:#dce9f8,stroke:#7f9db9,stroke-width:2px,color:#000
style R3 fill:#dce9f8,stroke:#7f9db9,stroke-width:2px,color:#000
style R4 fill:#dce9f8,stroke:#7f9db9,stroke-width:2px,color:#000

style L1 fill:#dce9f8,stroke:#7f9db9,stroke-width:2px,color:#000
style L2 fill:#dce9f8,stroke:#7f9db9,stroke-width:2px,color:#000
style L3 fill:#dce9f8,stroke:#7f9db9,stroke-width:2px,color:#000
style L4 fill:#dce9f8,stroke:#7f9db9,stroke-width:2px,color:#000

style DB fill:#9eb6d8,stroke:#5a6f89,stroke-width:2px,color:#000

%% ===== LINK STYLING =====
linkStyle default stroke:#444,stroke-width:2px
```

# Password Hashing

Password hashing is used to securely store passwords in the database.

Passwords should never be stored as plain text.

Hashing is one-way:
- Original password cannot be retrieved.
- Used mainly for authentication.

Common Algorithms:
- SHA256
- SHA512
- HMACSHA256
- HMACSHA512
- PBKDF2
- BCrypt

HMACSHA512 is commonly used in ASP.NET Core examples.

## Salt

Salt is a random value added to password before hashing.

Purpose:
- Prevent rainbow table attacks.
- Prevent same passwords from producing same hash.

## Registration Flow

```text
User Password
      |
      v
Generate Salt
      |
      v
Create Hash using HMACSHA512
      |
      v
Store Hash + Salt in DB
```

## Login Flow

```text
Entered Password
        |
        v
Get Salt from DB
        |
        v
Generate New Hash
        |
        v
Compare with Stored Hash
```

## Example

```csharp
using var hmac = new HMACSHA512();

byte[] passwordSalt = hmac.Key;
byte[] passwordHash =
    hmac.ComputeHash(
        Encoding.UTF8.GetBytes(password));
```

## Important Points

- Hashing is not encryption.
- Hash cannot be reversed.
- Salt must be unique per user.
- Use HTTPS during transmission.