public static class Program 
{
    public static void Main(string[] args) {
        Console.WriteLine(Uncensor("Wh*r* d*d my v*w*ls g*?", "eeioeo"));
        Console.WriteLine(Uncensor("abcd", ""));
        Console.WriteLine(Uncensor("*PP*RC*S*", "UEAE"));
    }

    public static string Uncensor(string censored, string censoredLetters) {
        foreach (var censoredLetter in censoredLetters) {
            var index = censored.IndexOf('*');
            censored = censored.Substring(0, index) + censoredLetter + censored.Substring(index + 1);
        }
        return censored;
    }
}