public static class Program {
    public static void Main(string[] args) {
        Console.WriteLine(LongestSubstring(2, "abcba"));
    }
    public static string LongestSubstring(int k, string s) {
        var maximum = new List<char>();

        if (s.Length <= k) {
            // If the length of the string is less than k, by definition, the longest substring is the string itself.
            return s;
        }

        // for i, while it is smaller than the string's length, minus k - 1 
        // (by definition, a substring that is less than k long cannot be the longest)
        for (int i = 0; i < s.Length - (k - 1); i++) {
            // Create a HashSet of character that will contain all encountered letters...
            var currentLetters = new HashSet<char>();

            // Get the longest substring for the index...
            var current = s.Skip(i).TakeWhile(character => {
                // Take the letters and add them to the encountered letters...
                currentLetters.Add(character);
                // Until the number of different encountered letters is greater than k
                return currentLetters.Count() <= k;
            }).ToList(); // Had to transform it into a list or it would cause problems due to currentLetters being out of scope

            // If the current possibility is greater than the maximum found, update the maximum with the current value
            maximum = current.Count() > maximum.Count() ? current : maximum;
        }

        // Transform the char list to a string and return it
        return string.Concat(maximum);
    }
}
