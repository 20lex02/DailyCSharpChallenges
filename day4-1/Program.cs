public static class Program 
{
    public static void Main(string[] args) {
        Console.WriteLine(Simplify("4/6"));
        Console.WriteLine(Simplify("10/11"));
        Console.WriteLine(Simplify("100/400"));
        Console.WriteLine(Simplify("8/4"));
    }

    public static string Simplify(string fraction) {
        var parts = fraction.Split("/");
        var numerator = int.Parse(parts[0]);
        var denominator = int.Parse(parts[1]);

        //  If it can be represented as an integer, do the division and return it
        if (numerator % denominator == 0) {
            return $"{numerator/denominator}";
        }

        var biggestDenominator = GetBiggestCommonDenominator(numerator, denominator);

        return $"{numerator / biggestDenominator}/{denominator / biggestDenominator}";
    }

    /// <summary>
    /// Gets the biggest denominator for two numbers
    /// </summary>
    public static int GetBiggestCommonDenominator(int val1, int val2) {
        // Get the bigger number
        var max = Math.Max(val1, val2);

        // Calculate the biggest denominator which can divide both the numbers
        var biggestDenominator = Enumerable.Range(1, max).Where(i => val1 % i == 0 && val2 % i == 0).Last();

        return biggestDenominator;
    }
}