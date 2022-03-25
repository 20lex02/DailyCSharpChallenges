using System.Linq;
public static class Program 
{
    public static void Main(string[] args) {
        Console.WriteLine(Interview(new int [] { 5, 5, 10, 10, 15, 15, 20, 20 }));
        Console.WriteLine(Interview(new int [] { 2, 3, 8, 6, 5, 12, 10, 18 }));
        Console.WriteLine(Interview(new int [] { 5, 5, 10, 10, 25, 15, 20, 20 }));
        Console.WriteLine(Interview(new int [] { 5, 5, 10, 10, 15, 15, 20 }));
    }

    public static string Interview(int[] questionsTime) {
        const string successMessage = "qualified";
        const string failureMessage = "disqualified";
        int[] questionsAmount = new[] { 2, 2, 2, 2};
        int[] maximumTimes = new[] { 5, 10, 15, 20};

        if (questionsTime.Length != questionsAmount.Sum()) {
            return failureMessage;
        }

        for (int i = 0; i < questionsAmount.Count(); i++) {
            var questions = questionsTime.Skip(questionsAmount.Take(i).Sum()).Take(questionsAmount[i]);
            if (questions.Any(time => time > maximumTimes[i])) {
                return failureMessage;
            }
        }

        return successMessage;
    }
}