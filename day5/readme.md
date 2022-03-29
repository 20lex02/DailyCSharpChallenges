## Day 5: Cons pair and despair *(medium)*
`Cons(a,b)` constructs a 2-elements Tuple (or pair), and `Car(pair)` and `Cdr(pair)` returns the first and the last element of the pair.  
Given this implenentation of Cons:
```csharp
public (int, int) Cons(int a, int b) 
{
    return (a, b);
}
```
Implement `Car` and `Cdr`.

### Examples
* `Car(Cons(3, 4))` -> `3`
* `Cdr(Cons(3, 4))` -> `4`

#
Done [X]