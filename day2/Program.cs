
public static class Program 
{
    public static void Main(string[] args) 
    {
        WriteArray(ProductIgnore(new[] { 1, 2, 3, 4, 5 })); // [120,60,40,30,24]
        WriteArray(ProductIgnore(new[] { 3, 2, 1 })); // [2, 3, 6]
    }

    public static int[] ProductIgnore(int[] values) 
    {
        // Fill the return array with 1s
        var returnValues = Enumerable.Repeat(1, values.Length).ToArray();

        for (int i = 0; i < values.Length; i++) {
            // Foreach element in the array
            for (int j = 0; j < values.Length; j++) {
                // Foreach element in the array
                if (i == j) {
                    // If they are at the same index, skip it...
                    continue;
                }

                // Else multiply the value of the return values to the passed value
                returnValues[i] *= values[j];
            }
        }

        return returnValues;
    }

    public static void WriteArray(IEnumerable<int> val) 
    {
        Console.WriteLine("[" + string.Join(",", val) + "]");
    }
}