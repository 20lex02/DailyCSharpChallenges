public static class Program {
    public static void Main(string[] args) {
        WriteArray(SubMaximums(new[] {10, 5, 2, 7, 8, 7}, 3)); // [10,7,8,8]
        WriteArray(SubMaximums(new[] {3, 14, 15, 92, 65, 35, 89, 79, 32, 38, 46, 26, 43, 38}, 5)); // [92,92,92,92,89,89,89,79,46,46]
    
        SubMaximumsBonus(new[] {10, 5, 2, 7, 8, 7}, 3);
        SubMaximumsBonus(new[] {3, 14, 15, 92, 65, 35, 89, 79, 32, 38, 46, 26, 43, 38}, 5);
    }

    public static int[] SubMaximums(int[] array, int k) {
        var results = new List<int>();
        for (int i = 0; i <= array.Length - k; i++) {
            results.Add(array.Skip(i).Take(k).Max());
        }

        return results.ToArray();
    }

    public static void SubMaximumsBonus(int[] array, int k) {
        var queue = new Queue<int>(array.Take(k));
        for (int i = k; i < array.Length; i++) {
            Console.Write(queue.Max() + ", ");
            queue.Dequeue();
            queue.Enqueue(array[i]);
        }
        Console.Write(queue.Max() + "\n");
    }

    public static void WriteArray<T>(IEnumerable<T> val) 
    {
        Console.WriteLine("[" + string.Join(",", val) + "]");
    }
}