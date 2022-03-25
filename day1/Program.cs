public static class Program 
{
    public static void Main(string[] args) {
        Console.WriteLine(PossibleSum(new[] { 10,15,3,7 }, 17));
        Console.WriteLine(PossibleSum(new[] { 23,2,17,12 }, 46));
    }

    public static bool PossibleSum(int[] numberList, int k) 
    {
        for (int i = 0; i < numberList.Length; i++) 
        {
            if (numberList[(i+1)..].Any(tempNumber => tempNumber == k - numberList[i])) 
            {
                return true;
            }
        }
        return false;
    }
}