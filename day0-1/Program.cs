using System.Linq;

public static class Program {
    public static void Main(string[] args) {
        Console.WriteLine(string.Join(",", GetCapsIndexes("eDaBiT")));
        Console.WriteLine(string.Join(",", GetCapsIndexes("eQuINoX")));
        Console.WriteLine(string.Join(",", GetCapsIndexes("determine")));
        Console.WriteLine(string.Join(",", GetCapsIndexes("STRIKE")));
        Console.WriteLine(string.Join(",", GetCapsIndexes("sUn")));
    }

    public static IEnumerable<int> GetCapsIndexes(string stringValue) {
        for (int i = 0; i < stringValue.Length; i++) {
            var characterValue = (int)stringValue[i];
            if (characterValue >= 65 && characterValue <= 90) {
                yield return i;
            }
        }
    }
}