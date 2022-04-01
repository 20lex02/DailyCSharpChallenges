public static class Program {
    public static void Main(string[] args) {
        Console.WriteLine(OverTime(new float[] {9, 17, 30, 1.5f}));
        Console.WriteLine(OverTime(new float[] {16, 18, 30, 1.8f}));
        Console.WriteLine(OverTime(new float[] {13.25f, 15, 30, 1.5f}));
    }

    public static string OverTime(float[] data) {
        if (data.Length != 4) {
            throw new InvalidDataException();
        }

        var entryTime = data[0];
        var exitTime = data[1] > 17 ? 17 : data[1];
        var overTime = data[1];

        var rate = data[2];
        var overtimeMultiplier = data[3];

        var totalPay = (exitTime - entryTime) * rate + (overTime - exitTime) * rate * overtimeMultiplier;

        return "$" + totalPay.ToString("n2");
    }
}