using System.Text.Json;
using System.Text.Json.Serialization;
public static class Program 
{
    public static void Main(string[] args) 
    {
        var node = new Node("root", new("left", new("left.left")), new("right"));
        Console.WriteLine(Deserialize(Serialize(node)).Left!.Left!.Val); // left.left
        Console.WriteLine(Deserialize(Serialize(node)).Right!.Val); // right
    }

    [System.Serializable]
    public class Node 
    {
        public string? Val { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(string val, Node? left = null, Node? right = null) 
        {
            this.Val = val;
            this.Left = left;
            this.Right = right;
        }
    }

    public static string Serialize(Node node) {
        return JsonSerializer.Serialize(node);
    }

    public static Node Deserialize(string s) {
        return JsonSerializer.Deserialize<Node>(s)!;
    }
}