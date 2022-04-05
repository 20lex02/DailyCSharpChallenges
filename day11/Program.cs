public static class Program {
    public static void Main(string[] args) {
        WriteArray(AutoComplete("de", new string[] {"dog", "deer", "deal"}));
    }

    public static string[] AutoComplete(string s, string[] source) {
        var tree = new Tree<string>();
        foreach (var word in source) {
            var current = tree;
            foreach (var letter in word) {
                if (current.Nodes.Any(node => node.Value == letter.ToString())) {
                    current = current.Nodes.Where(node => node.Value == letter.ToString()).First();
                }
                else {
                    var newNode = new Tree<string>(letter.ToString());
                    current.Nodes.Add(newNode);
                    current = newNode;
                }
            }
            current.Nodes.Add(new(word));
        }
        
        var currentNode = tree;
        foreach (var letter in s) {
            if (currentNode.Nodes.Any(node => node.Value == letter.ToString())) {
                currentNode = currentNode.Nodes.Where(node => node.Value == letter.ToString()).First();
            }
            else return new string[0];
        }
        return currentNode.GetBranches().Select(node => node.Value).ToArray()!;
    }

    public static void WriteArray<T>(IEnumerable<T> val) 
    {
        Console.WriteLine("[" + string.Join(",", val) + "]");
    }

    public class Tree<T> {
        public List<Tree<T>> Nodes;
        public T? Value;

        public Tree(T value) {
            this.Value = value;
            this.Nodes = new List<Tree<T>>();
        }

        public Tree() {
            this.Value = default(T);
            this.Nodes = new List<Tree<T>>();
        }

        public IEnumerable<Tree<T>> GetBranches() {
            if (!this.Nodes.Any()) {
                yield return this;
            }
            else {
                foreach (var node in this.Nodes.SelectMany(node => node.GetBranches())) {
                    yield return node;
                }
            }
        }
    }
}