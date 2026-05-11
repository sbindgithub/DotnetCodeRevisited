# Indexers in C#

## What Problem Does It Solve?

Indexers allow objects to behave like arrays.

Instead of:
student.GetMark(0)

We can write:
student[0]

This improves readability and API design.

## Real-Life Analogy

A hotel room number gives direct access to a room.
Indexers provide similar direct access to object data.

## Syntax

Example:

```csharp id="3b7qyv"
class Student
{
    private string[] subjects = new string[3];
    private int[] marks = new int[3];

    // Indexer for subjects
    public string this[int index]
    {
        get
        {
            return subjects[index];
        }
        set
        {
            subjects[index] = value;
        }
    }

    // Another indexer using string parameter
    public int this[string subject]
    {
        get
        {
            if (subject == "Math")
                return marks[0];

            if (subject == "Science")
                return marks[1];

            return marks[2];
        }
        set
        {
            if (subject == "Math")
                marks[0] = value;
            else if (subject == "Science")
                marks[1] = value;
            else
                marks[2] = value;
        }
    }
}
```

Usage:

```csharp id="7rw75u"
Student s = new Student();

s[0] = "Math";

s["Math"] = 95;

Console.WriteLine(s[0]);
Console.WriteLine(s["Math"]);
```

Important concept:
`this` in indexers does NOT mean constructor `this`.

Here:

```csharp id="xjlwmh"
this[int index]
```

means:
“Allow this object to be accessed using an integer index.”

and:

```csharp id="3ax1z4"
this[string subject]
```

means:
“Allow this object to be accessed using a string key.”

This is called:

* overloaded indexers

Same idea as method overloading.

Real-world analogy:

```text id="mjlwm3"
Locker[1]       -> by number
Locker["Math"]  -> by label
```

Both access the same object differently.

This is why C# collections feel powerful:

* arrays use integer index
* dictionaries use key index
* data tables use row/column index
* custom business objects can expose domain-specific indexing

Architect-level understanding:
Indexers are not about arrays.
They are about creating intuitive APIs and hiding internal implementation details.

These are the kinds of indexer questions that separate:

* tutorial-level developers
  from
* deep C# engineers

Most candidates only know:

```csharp
this[int index]
```

That is basic knowledge.

Strong interviewers push into edge cases, compiler behavior, API design, and architecture implications.

Here are the unusual/high-value questions.

---

## 1. Can an indexer be static?

Answer:
No.

C# does not allow static indexers because indexers operate on object instances.

Invalid:

```csharp id="q0r6e9"
public static string this[int index]
```

Reason:
Indexer internally behaves like instance property methods:

* `get_Item()`
* `set_Item()`

Static objects do not support instance-style access syntax.

---

## 2. Why does C# use `this[]` syntax instead of naming indexers?

Because C# maps indexers internally to a property named:

```text id="n1j40f"
Item
```

Example:

```csharp id="m1hyjz"
student[0]
```

becomes internally:

```csharp id="h6zft0"
student.get_Item(0)
```

This is compiler transformation.

Many developers never know this.

---

## 3. Can indexers be overloaded?

Yes.

Example:

```csharp id="0iznhf"
public string this[int index]
public string this[string key]
```

This is one of the most commonly missed advanced questions.

---

## 4. Can indexers have multiple parameters?

Yes.

Example:

```csharp id="4h62xf"
public string this[int row, int column]
```

Used in:

* matrices
* grids
* Excel-like structures
* game boards

Usage:

```csharp id="qgv0ja"
table[2,3]
```

---

## 5. Can indexers return references (`ref`)?

Yes.

Advanced feature.

Example:

```csharp id="d4uj5k"
public ref int this[int index]
{
    get
    {
        return ref data[index];
    }
}
```

This avoids copying and improves performance.

Mostly used in:

* high-performance systems
* game engines
* memory-sensitive applications

Very few candidates know this.

---

## 6. Difference between Property and Indexer?

Property:

```csharp id="nghnfk"
student.Name
```

Indexer:

```csharp id="vf4g2g"
student[0]
```

Key distinction:

* Property represents a single value
* Indexer represents a collection-like access pattern

---

## 7. Can interfaces contain indexers?

Yes.

Example:

```csharp id="frjb7z"
interface IRepository
{
    string this[int index] { get; set; }
}
```

Important in framework/API design.

---

## 8. What is the IL/internal representation of an indexer?

Internally compiled as:

```text id="mewn0j"
get_Item()
set_Item()
```

This is why reflection sees indexers as properties.

Advanced interviewers ask this to test CLR understanding.

---

## 9. Why are indexers considered syntactic sugar?

Because:

```csharp id="p0mjlwm"
student[0]
```

is only shorthand for:

```csharp id="eqe4lj"
student.get_Item(0)
```

Compiler rewrites the syntax.

---

## 10. Can you apply access modifiers differently to get/set in indexers?

Yes.

Example:

```csharp id="hq64pv"
public string this[int index]
{
    get { return data[index]; }
    private set { data[index] = value; }
}
```

Common in immutable or controlled models.

---

## 11. Why are indexers dangerous in domain models?

Architect-level question.

Problem:
Excessive indexer use can hide business meaning.

Bad:

```csharp id="i2ykp0"
order[0]
```

Good:

```csharp id="k8qtd0"
order.OrderItems[0]
```

Indexers can reduce readability if abused.

Strong architects use them carefully.

---

## 12. Can an indexer throw exceptions?

Yes.

Common:

* `IndexOutOfRangeException`
* custom validation exceptions

Good API design requires boundary checking.

---

## 13. Why doesn’t List<T> expose a method instead of indexer?

Because collection semantics are naturally index-based.

Cleaner:

```csharp id="v7ib8n"
list[0]
```

than:

```csharp id="nmw8sj"
list.Get(0)
```

Indexer improves API ergonomics.

---

## 14. Can indexers be virtual/abstract/override?

Yes.

Example:

```csharp id="zltlbm"
public virtual string this[int index]
```

This is rarely used but important in framework extensibility.

---

## 15. Real architect-level question:

“When should you NOT use indexers?”

Answer:
Avoid when:

* access intent is unclear
* domain meaning matters
* object is not naturally collection-like
* readability suffers

Bad API design is worse than verbose code.

That answer signals engineering maturity.
