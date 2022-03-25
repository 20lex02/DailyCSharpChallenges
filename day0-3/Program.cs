using System.Linq;
public static class Program 
{
    public static void Main(string[] args) {
        WriteArray(TrackRobot(new string[] { "right 10", "up 50", "left 30", "down 10" }));
        WriteArray(TrackRobot(new string[] { }));
        WriteArray(TrackRobot(new string[] { "right 100", "right 100", "up 500", "up 10000" }));
    }

    public static Dictionary<string, int[]> directions = new Dictionary<string, int[]>() {
        {"up", new[] {0, 1} },
        {"down", new [] {0, -1}},
        {"right", new[] {1, 0}},
        {"left", new[] {-1, 0}}
    };

    public static int[] TrackRobot(string[] instructions) {
        var position = new[] {0, 0};
        foreach (var instruction in instructions) {
            if (directions.TryGetValue(instruction.Split(" ")[0], out var direction)) {
                direction = direction.Select(value => value * int.Parse(instruction.Split(" ")[1])).ToArray();
                for (int i = 0; i < position.Length; i++) {
                    position[i] += direction[i];
                }
            }
        }
        return position;
    }

    public static void WriteArray(int[] val) {
        Console.WriteLine("[" + string.Join(",", val) + "]");
    }
}