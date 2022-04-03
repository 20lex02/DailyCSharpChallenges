public static class Program {
    public static void Main(string[] args) {
        Console.WriteLine(NonAdjacentMaximumSum(new int[] {2, 4, 6, 2, 5})); // 13 (6+5)
        Console.WriteLine(NonAdjacentMaximumSum(new int[] {5, 1, 1, 5})); // 10 (5 + 5)
        Console.WriteLine(NonAdjacentMaximumSum(new int[] {9, 2, 5, 8, 8, 3, 3, 5})); // 27 (9 + 8 + 5 + 5)
    }

    public static int NonAdjacentMaximumSum(int[] numbers) {
        var max = 0;
        // Select the number and their indexes
        var numbersIndexes = numbers.Select((value, index) => new {value, index});

        while (numbersIndexes.Any() && numbersIndexes.Max(pair => pair.value) > 0) {
            // While There're still numbers left and the maximum value is above 0,
            // Get the numbers which are equal to the maximum value
            var maximumAvailables = numbersIndexes.Where(pair => pair.value == numbersIndexes.Max(pair => pair.value))
                                                  // And select them, along with the sum of the surrounding values (price)
                                                  .Select(pair => new { price = numbersIndexes.Where(adjacentPair => adjacentPair.index == pair.index + 1 || adjacentPair.index == pair.index + 1)
                                                                                              .Select(adjacentPair => adjacentPair.value).Sum(),  
                                                                        pair });
            
            // Get the number with the lowest price and add it to the maximum
            var lowestPrice = maximumAvailables.MinBy(maximum => maximum.price)!.pair;
            max += lowestPrice.value;

            // Remove the selected value and its neighbors
            numbersIndexes = numbersIndexes.Where(pair => pair.index > lowestPrice.index + 1 || pair.index < lowestPrice.index - 1);
        }
        return max;
    }
}