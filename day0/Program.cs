public static class Program {
    public static void Main(string[] args) {
        for (int i = 1; i <= 12; i++) {
            Console.WriteLine(GetMonthName(i));
        }
    }

    public static string GetMonthName(int value) {
        var date = new DateTime(1, value, 1);
        return date.ToString("MMMM");
    }
}