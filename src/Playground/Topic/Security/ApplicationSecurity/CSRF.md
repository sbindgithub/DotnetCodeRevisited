# CSRF (Cross-Site Request Forgery)

## Attack

Victim’s browser sends authenticated request without consent.

## Defense

* **Anti-forgery tokens**
* SameSite cookies
* Verify origin/referrer

## .NET Example

```csharp
[ValidateAntiForgeryToken]
public IActionResult Post(...) { ... }
```

Razor:

```html
<form method="post">
  @Html.AntiForgeryToken()
</form>
```

## Interview Line

“CSRF exploits cookies; fix with anti-forgery tokens and SameSite.”
