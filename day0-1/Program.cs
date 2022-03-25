using System.Linq;

public static class Program {
    public static void Main(string[] args) {
        WriteArray(GetCapsIndexes("eDaBiT"));
        WriteArray(GetCapsIndexes("eQuINoX"));
        WriteArray(GetCapsIndexes("determine"));
        WriteArray(GetCapsIndexes("STRIKE"));
       WriteArray(GetCapsIndexes("sUn"));
    }

    public static IEnumerable<int> GetCapsIndexes(string stringValue) {
        for (int i = 0; i < stringValue.Length; i++) {
            var characterValue = (int)stringValue[i];
            if (characterValue >= 65 && characterValue <= 90) {
                yield return i;
            }
        }
    }
    public static void WriteArray(IEnumerable<int> val) {
        Console.WriteLine("[" + string.Join(",", val) + "]");
    }
}