# Difference Between `var` and `dynamic` in C#

## Core Difference

| var                            | dynamic                        |
| ------------------------------ | ------------------------------ |
| Type decided at compile-time   | Type resolved at runtime       |
| Strongly typed                 | Weakly typed at runtime        |
| Compiler checks errors early   | Errors appear during execution |
| Faster                         | Slower                         |
| IntelliSense support available | Limited IntelliSense           |
| Safer                          | More flexible but risky        |

---

# `var`

`var` means:

> "Compiler, you already know the type. Infer it for me."

Example:

```csharp id="e9d2gm"
var name = "Sarada";
```

Compiler converts it internally to:

```csharp id="rj2ktq"
string name = "Sarada";
```

Type is fixed at compile-time.

You cannot later do:

```csharp id="k1xj0x"
name = 100;
```

Compile-time error.

---

# `dynamic`

`dynamic` means:

> "Compiler, skip type checking now. Decide later during runtime."

Example:

```csharp id="n7ek5k"
dynamic data = "Hello";
```

Later:

```csharp id="zyrrd6"
data = 100;
data = true;
```

Allowed.

Type checking happens only during execution.

---

# Real-Life Analogy

## `var`

Like a school admission form.

Once registered as:

* Science student

you remain Science student.

Fixed identity.

---

## `dynamic`

Like a temporary visitor pass.

Today:

* Developer

Tomorrow:

* Tester

Next day:

* Manager

Identity can change anytime.

---

# Compile-Time vs Runtime

## `var`

Compiler validates:

```csharp id="76whcr"
var x = "Hello";

x.ToUpper();
```

Compiler knows:

* `x` is string
* `ToUpper()` exists

Safe.

---

## `dynamic`

```csharp id="j7wnbd"
dynamic x = "Hello";

x.UnknownMethod();
```

Compiler allows it.

But runtime throws exception:

```text id="aj3gmz"
RuntimeBinderException
```

because method does not exist.

---

# Important Interview Question

## Does `var` mean dynamic typing?

No.

Huge misconception.

`var` is still strongly typed.

Example:

```csharp id="hwwlru"
var age = 10;
```

Compiler treats it as:

```csharp id="zyw0vk"
int age = 10;
```

---

# Performance Difference

## `var`

Fast because:

* type known during compilation
* optimized by compiler

---

## `dynamic`

Slower because:

* runtime binder resolves members dynamically
* extra overhead exists

---

# IntelliSense Difference

## `var`

Full IntelliSense support.

```csharp id="04w0zj"
var s = "Hello";
```

IDE knows `s` is string.

---

## `dynamic`

Weak IntelliSense.

IDE cannot reliably predict members.

---

# Common Usage of `dynamic`

Used when interacting with:

* COM objects
* reflection-heavy code
* JSON objects
* scripting engines
* dynamic languages

Example:

```csharp id="6v7kki"
dynamic json = JsonConvert.DeserializeObject(data);
```

---

# Common Usage of `var`

Used for:

* cleaner syntax
* LINQ queries
* anonymous types

Example:

```csharp id="n17rj6"
var employees = new List<string>();
```

---

# Architect-Level Insight

## Prefer `var`

because:

* type safety
* maintainability
* performance
* readability

---

## Use `dynamic` Carefully

because:

* runtime failures increase
* debugging becomes harder
* refactoring becomes dangerous

`dynamic` reduces compiler protection.

---

# Trick Interview Question

## Is this valid?

```csharp id="qyrgmb"
var x = null;
```

No.

Compiler cannot infer type.

---

## Is this valid?

```csharp id="6st7rt"
dynamic x = null;
```

Yes.

Because dynamic type resolution happens at runtime.

---

# Memory Understanding

## `var`

Only syntax sugar.

No special runtime behavior.

---

## `dynamic`

Uses:

* Dynamic Language Runtime (DLR)
* runtime binder infrastructure

More complex internally.

---

# Summary

| Feature           | var            | dynamic                |
| ----------------- | -------------- | ---------------------- |
| Type Resolution   | Compile-time   | Runtime                |
| Type Safety       | Strong         | Weak                   |
| Performance       | Faster         | Slower                 |
| IntelliSense      | Strong         | Weak                   |
| Runtime Errors    | Fewer          | More                   |
| Flexibility       | Lower          | Higher                 |
| Recommended Usage | Default choice | Special scenarios only |
