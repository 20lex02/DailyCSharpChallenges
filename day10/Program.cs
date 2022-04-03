using System.Threading.Tasks;
public static class Program {
    public static void Main(string[] args) {
        Action twoSecondMessage = () => Console.WriteLine("Something interesting.");
        var task = RunAfter(twoSecondMessage, 2000);
        Console.WriteLine("Something interesting will happen in 2 seconds...");
        task.Wait();
    }

    public static Task RunAfter(Action f, int ms) {
        return Task.Run(() => {
            Thread.Sleep(ms);
            f();
        });
    }
}