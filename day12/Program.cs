public static class Program {
    public static void Main(string[] args) {
        Console.WriteLine(StairsPossibilities(4, new[] {1, 2})); // 5
    }

    public static double StairsPossibilities(int numberOfSteps, int[] numberOfStepsAvailable) {
        var maxSize = numberOfSteps / numberOfStepsAvailable.Min();
        var minSize = (int)Math.Ceiling(numberOfSteps / (float)numberOfStepsAvailable.Max());
        var orderedSteps = numberOfStepsAvailable.Distinct().OrderByDescending(n => n).ToList();

        var numberOfPossibilities = 0.0;

        foreach (var possibility in GetPossibilities(numberOfSteps, orderedSteps)) {
            numberOfPossibilities += CaculateNumberOfPossibleArrengements(possibility.Length, possibility.Distinct().Count());
        }
        return numberOfPossibilities;
    }

    public static IEnumerable<int[]> GetPossibilities(int goal, List<int> possibleNumbers) {
        if (possibleNumbers.Any()) {
            // Get the first possible number and remove it from the possibilities
            var startingNumber = possibleNumbers.First();
            possibleNumbers.RemoveAt(0);

            var currentGoalValue = goal;

            if (possibleNumbers.Any()) {
                // If there is any possible number left...
                for (int i = startingNumber; i < goal; i += startingNumber) {
                    // Decrease the current goal by the starting number
                    currentGoalValue -= startingNumber;

                    //Get all direct possibilities
                    var validPossibilities = possibleNumbers.Where(possibility => currentGoalValue % possibility == 0);

                    foreach (var possibleNumber in possibleNumbers) {
                        var rest = currentGoalValue - possibleNumber;
                        // If the rest of the number after removing a possibile number is greater then 0...
                        if (rest > 0) {
                            // Get all its possible values....                (ToList() to make a copy of the list)
                            var restPossibleValues = GetPossibilities(rest, possibleNumbers.ToList());
                            foreach (var possibility in restPossibleValues) {
                                // And return them, preceded by the corresponding number of the starting number and the current possible number
                                yield return Enumerable.Repeat(startingNumber, i / startingNumber).Append(possibleNumber).Concat(possibility).ToArray();
                            }
                        }
                    }
                }
            }
            

            if (goal % startingNumber == 0) {
                // If the goal is directly dividable by the starting number return an array containing it the apropriate number of time
                yield return Enumerable.Repeat(startingNumber, goal / startingNumber).ToArray();
            }

            // Get the possibilities for the next possible numbers and return them
            foreach (var possibility in GetPossibilities(goal, possibleNumbers)) {
                yield return possibility;
            }
        }
    }

    public static double CaculateNumberOfPossibleArrengements(int arrayLength, int numberOfDifferentValues) {
        
        return (Factorial(arrayLength)/Factorial(arrayLength - (numberOfDifferentValues - 1)));
    }

    public static double Factorial(int x) {
        var value = 1.0;
        for (ulong i = 1; i <= (ulong)x; i++) {
            value *= i;
        }
        return value;
    }
}