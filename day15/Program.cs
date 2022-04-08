public static class Program {
    public static void Main(string[] args) {
        var dataSource = Enumerable.Range(0, 100);
        var encounteredValues = new HashSet<int>();
        while (encounteredValues.Count() != dataSource.Count()) {
            var randomValue = dataSource.GetRandom();
            encounteredValues.Add(randomValue);
            Console.WriteLine(randomValue);
        } 
    }

    public static T GetRandom<T>(this IEnumerable<T> source, Random? random = null) {
        var _random = random ?? new Random();

        var count = 0;
        var current = default(T);
        foreach (var item in source) {
            count++;
            if (_random.Next(count) == 0) {
                current = item;
            }
        }
        if (count == 0) {
            throw new InvalidOperationException();
        }

        return current!;
    }
}