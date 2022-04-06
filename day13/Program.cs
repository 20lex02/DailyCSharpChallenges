public static class Program {
    public static void Main(string[] args) {
        Console.WriteLine(LongestSubstring(2, "abcba"));
    }
    public static string LongestSubstring(int k, string s) {
        var maximum = new List<char>();
        for (int i = 0; i < s.Length - 1; i++) {
            var currentLetters = new HashSet<char>();
            var current = s.Skip(i).TakeWhile(character => {
                currentLetters.Add(character);
                return currentLetters.Count() <= 2;
            }).ToList();

            maximum = current.Count() > maximum.Count() ? current : maximum;
        }

        return string.Concat(maximum);
    }
}
