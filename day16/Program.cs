using System.Runtime.InteropServices;
public static class Program {
    public static void Main(string[] args) {
        WriteArray((new LogContainer<int>(Enumerable.Range(0, 100))).GetLast(10));
    } 

    public class LogContainer<T> 
    {
        private Node? Latest;
        public int Length;

        public LogContainer() {
            Length = 0;
        }

        public LogContainer(IEnumerable<T> values) {
            foreach (var value in values) {
                Record(value);
            }
        }

        public void Record(T value) {
            var newNode = new Node(value, Latest);
            Latest = newNode;
            Length++;
        }

        public IEnumerable<T> GetLast(int count) {
            var current = Latest!.Value;
            for (int i = 0; i < count; i++) {
                yield return current.Value;
                current = current.Previous!.Value;
            }
        }

        private struct Node 
        {
            public T Value { get; set; }
            public Node? Previous { 
                get => (Node?) PreviousRef?.Target;
                set => PreviousRef = value is null ? null : GCHandle.Alloc(value);
            }
            private GCHandle? PreviousRef = null;

            public Node(T value, Node? previous = null) {
                Value = value;
                Previous = previous;
            }
        }
    }
    public static void WriteArray<T>(IEnumerable<T> val) 
    {
        Console.WriteLine("[" + string.Join(",", val) + "]");
    }
}