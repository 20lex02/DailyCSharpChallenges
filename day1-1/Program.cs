public static class Program 
{
    public static void Main(string[] args) {
        Console.WriteLine(ReverseAndNot(123));
        Console.WriteLine(ReverseAndNot(152));
        Console.WriteLine(ReverseAndNot(123456789));
    }

    public static string ReverseAndNot(int value) {
        return string.Concat(value.ToString().Reverse()) + value.ToString();
    }
}