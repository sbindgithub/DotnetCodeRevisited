# JWT (JSON Web Token)

## Structure

```text
header.payload.signature
```

* Header: alg, typ
* Payload: claims (sub, exp, roles)
* Signature: HMAC/RSA over header+payload

## Flow

1. User authenticates (credentials/MFA)
2. Server issues JWT (short-lived)
3. Client sends `Authorization: Bearer <token>`
4. API validates signature + claims

## Security Points

* **Validate signature** (never trust unsigned tokens)
* **Validate exp/nbf/aud/iss**
* Prefer **asymmetric keys (RS256)** in distributed systems
* Keep tokens **short-lived**; use refresh tokens

## .NET Setup

```csharp
builder.Services.AddAuthentication("Bearer")
 .AddJwtBearer(o =>
 {
   o.TokenValidationParameters = new TokenValidationParameters
   {
     ValidateIssuer = true,
     ValidateAudience = true,
     ValidateLifetime = true,
     ValidateIssuerSigningKey = true
   };
 });
```

## Common Mistakes

* Storing sensitive data in payload
* Long-lived tokens
* Skipping validation checks

## Interview Line

“JWT is stateless auth; security depends on strict signature and claim validation plus short lifetimes.”
