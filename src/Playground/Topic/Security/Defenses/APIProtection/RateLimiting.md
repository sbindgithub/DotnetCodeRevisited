# Rate Limiting

## Purpose

* Protect against abuse, brute force, and partial DDoS

## Strategies

* Fixed window
* Sliding window
* Token bucket

## .NET (ASP.NET Core 7+)

```csharp
builder.Services.AddRateLimiter(options =>
{
  options.AddFixedWindowLimiter("fixed", opt =>
  {
    opt.PermitLimit = 100;
    opt.Window = TimeSpan.FromMinutes(1);
  });
});
app.UseRateLimiter();
```

## Interview Line

“Rate limiting is app-level defense; combine with WAF/CDN for DDoS.”
