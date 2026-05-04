# Input Validation

## Principle

* Validate **format, length, range**
* Use **allow-lists**, not block-lists

## Why

* Reduces attack surface (SQLi, XSS, SSRF)
* Prevents malformed data

## .NET

* Data annotations

```csharp
public class UserDto
{
  [Required, MaxLength(100)]
  public string Name { get; set; }
}
```

## Interview Line

“Validate early, encode late; never trust external input.”
