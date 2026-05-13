# Encryption and Decryption

Encryption converts plain text into unreadable cipher text.

Decryption converts cipher text back into plain text.

Used to protect sensitive data.

Namespace:
```csharp
System.Security.Cryptography
```

## Types of Encryption

## 1. Symmetric Encryption

Same key is used for:
- Encryption
- Decryption

Fast and commonly used.

Algorithms:
- AES (Recommended)
- DES (Deprecated)

```text
Plain Text
    |
    v
Encrypt using Secret Key
    |
    v
Cipher Text
    |
    v
Decrypt using Same Key
    |
    v
Plain Text
```

## 2. Asymmetric Encryption

Uses two keys:
- Public Key → Encrypt
- Private Key → Decrypt

Algorithms:
- RSA
- ECC

```text
Public Key  -> Encryption
Private Key -> Decryption
```

## AES Example

```csharp
using Aes aes = Aes.Create();
```

## RSA Example

```csharp
using RSA rsa = RSA.Create();
```

## Important Points

- Encryption is two-way.
- Hashing is one-way.
- AES is faster than RSA.
- RSA is used in SSL/TLS and certificates.