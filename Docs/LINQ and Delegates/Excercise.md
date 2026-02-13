1️⃣ Filtering – Where

```
	var numbers = new List<int> { 1, 5, 10, 15, 20 };
```
Ans: var greaterThan10=numbers.Where(x=>x>10).ToList();

2️⃣ Filtering – OfType
```
ArrayList items = new ArrayList 
{ 
    1, 
    "hello", 
    2, 
    "world", 
    3 
};
```
Ans: var strings=items.OfType<int>().ToList();

3️⃣ Projection – Select
```
var numbers = new List<int> { 1, 2, 3, 4 };
```
Ans: var numSquares=numbers.Select(x=>x*x).ToList();

4️⃣ Projection – SelectMany
```
var list = new List<List<int>>
{
    new List<int> { 1, 2 },
    new List<int> { 3, 4 },
    new List<int> { 5 }
};
```

