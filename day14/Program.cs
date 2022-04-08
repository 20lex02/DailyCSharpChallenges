public static class Program {
    public static void Main(string[] args) {
        Console.WriteLine(EstimatePi(3));
        Console.WriteLine(EstimatePi(5));
    }

    public static double EstimatePi(int digits) {
        var random = new Random();
        var tolerance = 1 / (Math.Pow(10, digits));
        var approximation = 0d;

        double x, y;
        int numberOfCorrectGuesses = 0, totalGuesses = 0;

        while (Math.Abs( Math.PI - approximation ) > tolerance) {
            x = random.NextDouble() * 2 - 1;
            y = random.NextDouble() * 2 - 1;

            if (x * x + y * y <= 1) {
                numberOfCorrectGuesses++;
            }
            totalGuesses ++;

            approximation = 4 * ((double)numberOfCorrectGuesses / (double)totalGuesses);
        }

        return Math.Round(approximation, digits, MidpointRounding.AwayFromZero);
    }
}