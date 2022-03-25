public static class Program 
{
    public static void Main(string[] args) {
        Console.WriteLine(FindBomb("There is a bomb."));
        Console.WriteLine(FindBomb("Hey, did you think there is a bomb?"));
        Console.WriteLine(FindBomb("This goes boom!!!."));
    }

    public static string FindBomb(string value) {
        if (value.ToLower().Contains("bomb")) {
            return "DUCK!!!";
        }
        else {
            return "Dude chill, there is no bomb.";
        }
    }
}
