using System.Linq;
public static class Program 
{
    public static void Main(string[] args) {
        Console.WriteLine(IsSmooth("Marta appreciated deep perpendicular right trapezoids"));
        Console.WriteLine(IsSmooth("Someone is outside the doorway"));
        Console.WriteLine(IsSmooth("She eats super righteously"));
    }

    public static bool IsSmooth(string phrase) 
    {
        var words = phrase.Split(' ');

        for (int i = 0; i < words.Count() - 1; i++) 
        {
            var current = words[i].ToLower();
            var next = words[i+1].ToLower();

            if (current.Last() != next.First()) {
                return false;
            }
        }

        return true;
    }
}