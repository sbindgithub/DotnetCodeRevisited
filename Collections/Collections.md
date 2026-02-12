# C# Collections – Complete Guide (Beginner to Architect Level)

---

# Table of Contents

1. Introduction to Collections  
2. Arrays vs Collections  
3. Time Complexity Basics (Big-O)  
4. Non-Generic Collections  
5. Generic Collections  
6. Core Collections Deep Dive  
   - List<T>  
   - Dictionary<TKey, TValue>  
   - HashSet<T>  
   - Stack<T>  
   - Queue<T>  
7. Understanding “Access by Index → O(1)”  
8. Interfaces and Abstraction  
9. Concurrent Collections  
10. Immutable Collections  
11. Performance Optimization  
12. Internal Implementation Insights  
13. Decision Matrix  
14. Real-World Scenarios  
15. Interview-Level Questions  

---

- IEnumerable<T>
  - ICollection<T>
    - IDictionary<TKey, TValue>
    - IList<T>
      - List<T>




# 1. Introduction to Collections

A **collection** is a data structure used to store, manage, and manipulate groups of objects.

Collections provide:

- Dynamic resizing
- Type safety
- Built-in operations (searching, sorting, grouping)
- Performance optimization
- Thread safety options
- Memory efficiency control

Collections are fundamental in APIs, microservices, caching layers, and large-scale systems.

---

# 2. Arrays vs Collections

## Arrays

```csharp
int[] numbers = new int[3];
numbers[0] = 10;
```
Characteristics:

Fixed size

Same data type

Fast index access

No automatic resizing

Time Complexity:

| Operation        | Complexity |
|------------------|------------|
| Access by index  | O(1)       |
| Search           | O(n)       |
| Insert           | O(n)       |


Limitation: Size cannot grow dynamically.

# 3. Time Complexity (Big-O Basics)

Big-O describes how performance grows with data size.

| Complexity | Meaning        |
|------------|---------------|
| O(1)       | Constant time |
| O(log n)   | Logarithmic   |
| O(n)       | Linear        |
| O(n²)      | Quadratic     |


Correct collection choice depends on operation frequency and dataset size.

# 4. Non-Generic Collections (Legacy)

Namespace: System.Collections

Examples:

ArrayList

Hashtable

Stack

Queue

Example:
```
using System.Collections;

ArrayList list = new ArrayList();
list.Add(1);
list.Add("Hello");
```
Problems:

No type safety

Boxing/unboxing overhead

Runtime casting required

Modern C# should avoid these.

# 5. Generic Collections

Namespace: System.Collections.Generic

Advantages:

Type-safe

Better performance

Compile-time validation

Common types:

List<T>

Dictionary<TKey, TValue>

HashSet<T>

Stack<T>

Queue<T>

# 6. Core Collections Deep Dive
## 6.1 List<T>

Dynamic array.
```
List<int> numbers = new List<int>();
numbers.Add(10);
numbers.Add(20);
```

Internal structure: Array

Time Complexity:

| Operation         | Time Complexity |
|------------------|-----------------|
| Add (amortized)  | O(1)            |
| Insert           | O(n)            |
| Remove           | O(n)            |
| Search           | O(n)            |
| Index access     | O(1)            |


Use when:

Ordered data required

Frequent index-based access

Default general-purpose choice
- Contains() is O(n)
Linear search. Poor choice for frequent existence checks on large datasets.

- Insert at beginning or middle is O(n)
```
list.Insert(0, value);
```

All elements must shift right. Expensive for large lists.

- Remove from beginning or middle is O(n)
Elements must shift left after removal.

- Not thread-safe
Concurrent reads/writes can cause race conditions or exceptions.

- No built-in uniqueness guarantee
Allows duplicates. You must manually enforce uniqueness.

- Resizing overhead
Internally doubles capacity when full. This causes:

- - Temporary performance spikes

- - Additional memory allocation

- - Copying of entire array

- Lookup by value is inefficient
No hashing mechanism. Always sequential scan.

Architect-level summary:

Use List<T> when:

- Order matters

- Index access is frequent

- Dataset size is moderate

- No heavy existence checking

Avoid it when:

- You need fast lookups

- You need uniqueness

- You need thread safety

- You frequently insert/remove from the beginning

## 6.2 Dictionary<TKey, TValue>
```
Hash-based key-value store.
Dictionary<string, int> marks = new Dictionary<string, int>();
marks["John"] = 85;
```
Internal structure: Hash table

Time Complexity:

| Operation | Average Time Complexity | Worst Case Time Complexity |
|-----------|------------------------|----------------------------|
| Add       | O(1)                   | O(n)                       |
| Lookup    | O(1)                   | O(n)                       |
| Remove    | O(1)                   | O(n)                       |


Use when:

Fast key-based lookup required

Large datasets

Caching

## 6.3 HashSet<T>
A HashSet<T> in C# is a collection of unique elements that provides high-performance set operations. Elements are stored in no particular order, and any attempt to add a duplicate will simply be ignored without throwing an error. 
Stores unique values.
```
HashSet<string> names = new HashSet<string>();
names.Add("John");
names.Add("John"); // Ignored
```

Time Complexity:

Add → O(1)

Contains → O(1)

Use when:

Need uniqueness

Frequent existence checks

Deduplication logic

## 6.4 Stack<T> (LIFO)
```
Stack<int> stack = new Stack<int>();
stack.Push(10);
int value = stack.Pop();
```

Use cases:

Undo functionality

Expression evaluation

Time complexity: O(1)

## 6.5 Queue<T> (FIFO)
```
Queue<string> queue = new Queue<string>();
queue.Enqueue("Task1");
queue.Dequeue();
```
Use cases:

Job processing

Message pipelines

Time complexity: O(1)

# 7. Understanding “Access by Index → O(1)”
What It Means

Accessing an element by position takes constant time regardless of collection size.

Example:
```
var list = new List<int> { 10, 20, 30, 40 };
int value = list[2];   // 30
```
This operation is O(1).

Why?

Because List<T> uses contiguous memory.

The runtime calculates:

```
memory_address = base_address + (index × element_size)
```

No looping. No scanning. Direct access.

Compare with O(n)
```
list.Contains(40);
```

This scans elements sequentially.

Worst case: checks all elements → O(n)

Collections Supporting O(1) Index

- Array
- List<T>

Collections NOT Supporting O(1)

LinkedList<T> → O(n) traversal

# 8. Interfaces and Abstraction

Program against interfaces, not implementations.

Key interfaces:

- IEnumerable<T>
- ICollection<T>
- IList<T>
- IDictionary<TKey,TValue>

Example:
```
public void Process(IEnumerable<int> data)
{
    foreach (var item in data)
    {
        Console.WriteLine(item);
    }
}
```

Benefits:

- Loose coupling
- Better testability
- Flexible design

# 9. Concurrent Collections

Namespace: System.Collections.Concurrent

Used in multi-threaded environments.

Examples:

- ConcurrentDictionary<TKey,TValue>
- ConcurrentQueue<T>
- ConcurrentBag<T>

Example:
```
ConcurrentDictionary<string, int> cache = new();
cache.TryAdd("A", 1);
```

Why not normal Dictionary?

Because Dictionary is not thread-safe.

# 10. Immutable Collections

Namespace: System.Collections.Immutable

Example:
```
var list = ImmutableList.Create(1, 2, 3);
var newList = list.Add(4);
```

Original list remains unchanged.

Used in:

- Functional programming
- Event sourcing
- High-concurrency systems

# 11. Performance Optimization
11.1 Set Initial Capacity
```
var list = new List<int>(10000);
```


Prevents repeated resizing.

## 11.2 Choose Correct Collection

Scenario:
10 million records with frequent existence checks.

Correct:

- HashSet<T> → O(1)

Wrong:

- List<T> → O(n)

# 12. Internal Implementation Insights

| Collection     | Internal Structure |
|----------------|-------------------|
| `List<T>`      | Dynamic array (resizable contiguous memory) |
| `Dictionary<TKey, TValue>` | Hash table (bucket-based indexing) |
| `HashSet<T>`   | Hash table (stores unique keys only) |
| `Stack<T>`     | Array (LIFO behavior on top index) |
| `Queue<T>`     | Circular array (FIFO with head/tail pointers) |


Understanding internals improves architecture decisions.

# 13. Decision Matrix

| Requirement        | Recommended Collection        |
|--------------------|------------------------------|
| Ordered list       | `List<T>`                   |
| Fast key lookup    | `Dictionary<TKey, TValue>`  |
| Uniqueness         | `HashSet<T>`                |
| LIFO               | `Stack<T>`                  |
| FIFO               | `Queue<T>`                  |
| Thread-safe        | `ConcurrentDictionary<TKey, TValue>` |
| Immutable          | `ImmutableList<T>`          |

# 14. Real-World Scenarios

Caching layer → ConcurrentDictionary
Deduplication service → HashSet
Background job processing → ConcurrentQueue
In-memory lookup → Dictionary
High-read shared data → Immutable collections

# 15. Interview-Level Questions

Why is Dictionary O(1)?

- Hash-based bucket indexing.

Why avoid ArrayList?

- No type safety, performance overhead.

Difference between List and HashSet?

- List allows duplicates.

- HashSet ensures uniqueness and faster lookup.

When does Dictionary degrade to O(n)?

- Heavy hash collisions.

Why is index access O(1)?

- Direct memory address calculation.

# Final Principle

Never choose a collection by habit.

Choose it based on:

- Access pattern

- Data size

- Lookup frequency

- Mutation frequency

- Concurrency needs

- Memory constraints

Collections define system performance characteristics.

Understand them deeply.



