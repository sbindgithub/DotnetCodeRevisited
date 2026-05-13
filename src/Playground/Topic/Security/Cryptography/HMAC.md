# HMAC Authentication

HMAC stands for:

Hash-Based Message Authentication Code

Used for:
- Integrity
- Authentication
- Preventing tampering

Common Algorithms:
- HMACSHA256
- HMACSHA512

## HMAC Components

- Secret Key
- Message
- Hash Algorithm

## Flow

```text
Client Request
      |
      v
Create Signature using Secret Key
      |
      v
Send Request + Signature
      |
      v
Server Recalculates Signature
      |
      v
Compare Signatures
```

## Nonce

Nonce = Random unique value.

Purpose:
- Prevent replay attacks.

## Timestamp

Timestamp is added to:
- Prevent old request reuse.

## HMAC Request Example

```text
GET /api/orders

Headers:
x-api-key
x-signature
x-timestamp
x-nonce
```

## Signature Example

```csharp
using var hmac =
    new HMACSHA256(secretKeyBytes);

byte[] hash =
    hmac.ComputeHash(messageBytes);
```

## Important Points

- Data cannot be changed during transmission.
- Secret key must remain private.
- Common in payment gateways and APIs.
- Stronger than simple API key authentication.