public static class Program 
{
    public static void Main(string[] args) {
        Console.WriteLine(SmallestMissingPositive(new[] { 3, 4, -1, 1 }));
        Console.WriteLine(SmallestMissingPositive(new[] { 1, 2, 0 }));
    }

    public static int SmallestMissingPositive(int[] values) {
        var postiveValues = values.Where(num => num > 0);
        var min = 1;
        var max = postiveValues.Max() + 1;

        return Enumerable.Range(min, max).Where(num => !postiveValues.Contains(num)).Min();
    }
}