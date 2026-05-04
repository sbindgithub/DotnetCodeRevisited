# HTTPS / TLS

## Purpose

* Encrypt data in transit
* Prevent MITM attacks

## Key Points

* TLS handshake establishes session keys
* Certificates validate server identity

## .NET

```csharp
app.UseHttpsRedirection();
```

## Interview Line

“Always enforce HTTPS; TLS ensures confidentiality and integrity in transit.”
