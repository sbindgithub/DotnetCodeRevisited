# Cross-Site Scripting (XSS)

## Attack

Inject script into page:

```html
<script>alert(document.cookie)</script>
```

## Types

* Stored
* Reflected
* DOM-based

## Defense

* **Output encoding** (primary)
* Avoid rendering raw HTML
* Content Security Policy (CSP)

## .NET Notes

* Razor auto-encodes by default: `@Model.Name`
* Use `@Html.Raw()` only when absolutely necessary

## Interview Line

“XSS is prevented by output encoding and CSP; never trust rendered input.”
