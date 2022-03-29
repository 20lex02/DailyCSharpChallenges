using System.Linq;
public static class Program 
{
    public static void Main(string[] args) {
        Console.WriteLine(Car(Cons(3, 4))); // 3
        Console.WriteLine(Cdr(Cons(3, 4))); // 4
    }

    public static (int, int) Cons(int a, int b) {
        return (a, b);
    }

    public static int Car((int, int) pair) {
        return pair.Item1;
    }

    public static int Cdr((int, int) pair) {
        return pair.Item2;
    }
}