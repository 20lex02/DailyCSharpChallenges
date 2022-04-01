public static class Program {
    public static void Main(string[] args) {
        var tree = new BinaryTree<bool>(
            new BinaryTree<bool>.Node(false,
                new BinaryTree<bool>.Node(true),
                new BinaryTree<bool>.Node(false,
                    new BinaryTree<bool>.Node(true,
                        new BinaryTree<bool>.Node(true),
                        new BinaryTree<bool>.Node(true)
                    ),
                    new BinaryTree<bool>.Node(false)
                )
            )
        );

        Console.WriteLine(tree.GetUnivalTreeCount());
    } 

    public class BinaryTree<T> {
        public Node Root;

        public BinaryTree(Node root) {
            Root = root;
        }

        public int GetUnivalTreeCount() {
            var nodes = Root.GetAllDescendants().Where(node => node is not null);

            return nodes.Where(node => node.GetAllDescendants().GoodDistinct((first, second) => Node.ValueEquals(first, second)).Count() <= 1).Count();
        }

        public class Node {
            public Node? Left;
            public Node? Right;
            public T Value;

            public Node(T value, Node? left = null, Node? right = null) {
                Value = value;
                Left = left;
                Right = right;
            }

            public IEnumerable<Node> GetAllDescendants() {
                Node current;
                var uncheckedNodes = new Queue<Node>();
                uncheckedNodes.Enqueue(this);

                while (uncheckedNodes.TryDequeue(out current!)) {
                    if (current.Left is not null) {
                        yield return current.Left;
                        uncheckedNodes.Enqueue(current.Left);
                    }
                    if (current.Right is not null) {
                        yield return current.Right;
                        uncheckedNodes.Enqueue(current.Right);
                    }
                } 
            }

            public static bool ValueEquals(Node? first, Node? second) {
                if (first is null && second is null) {
                    return true;
                }

                if (first is null || second is null) {
                    return false;
                }

                return object.Equals(first.Value, second.Value);
            }
        }
    }

    public static IEnumerable<T> GoodDistinct<T>(this IEnumerable<T> source, Func<T, T, bool> comparator) {
        List<T> distincts = new List<T>();
        foreach (var elem in source) {
            if (distincts.All(distinct => !comparator(distinct, elem))) {
                distincts.Add(elem);
                yield return elem;
            }
        }
    }
}