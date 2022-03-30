using System.Runtime.InteropServices;
public static class Program {
    public static void Main(string[] args) {
        var list = new XORLinkedList1<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);

        Console.WriteLine(list.Get(0));
        Console.WriteLine(list.Get(1));
        Console.WriteLine(list.Get(2));
    }

    public class XORLinkedList1<T> {
        private IntPtr? Root = null;
        private int _length = 0;

        public int Length { get=>_length; }

        public T Get(int index) {
            if (index >= Length) {
                throw new IndexOutOfRangeException();
            }
            
            var (_, nodePtr, _) = GetNodeAndNeighbors(index);

            var node = nodePtr.GetValueReadOnly<Node>();
            return node.Value;
        }

        unsafe public void Add(T value) {
            if (Root is null) {
                Root = GCHandle.ToIntPtr(GCHandle.Alloc(new Node(value), GCHandleType.Pinned));
            }

            var (last, current, _) = GetNodeAndNeighbors(Length - 1);

            var next = GCHandle.ToIntPtr(GCHandle.Alloc(new Node(value, current), GCHandleType.Pinned));

            var currentRaw = (Node*)current.GetRawPointer();

            currentRaw->SetBoth(last, next);

            _length++;
        }

        private (IntPtr last, IntPtr current, IntPtr next) GetNodeAndNeighbors(int index) {
            var last = IntPtr.Zero;
            var current = Root!.Value;
            var next = current.GetValueReadOnly<Node>()!.GetNext(last);
            for (int i = 0; i < index; i++) {
                var nextNext = next.GetValueReadOnly<Node>()!.GetNext(current);
                last = current;
                current = next;
                next = nextNext;
            }
            return (last, current, next);
        }

        private struct Node {
            private IntPtr Both = default(IntPtr);

            private IntPtr ValuePtr = default(IntPtr);

            public T Value {
                get => (T)GCHandle.FromIntPtr(ValuePtr).Target!;
                set {
                    if (ValuePtr != default(IntPtr)) {
                        GCHandle.FromIntPtr(ValuePtr).Free();
                    }
                    ValuePtr = GCHandle.ToIntPtr(GCHandle.Alloc(value));
                }
            }

            public Node(T value, IntPtr? last = null, IntPtr? next = null) {
                Value = value;
                SetBoth(last ?? IntPtr.Zero, next ?? IntPtr.Zero);
            }

            public IntPtr GetNext(IntPtr last) {
                return (IntPtr)((ulong)Both ^ (ulong)last);
            }

            public IntPtr GetLast(IntPtr next) {
                return (IntPtr)((ulong)Both ^ (ulong)next);
            }

            public void SetBoth(IntPtr last, IntPtr next) {
                Both = (IntPtr)((ulong)next ^ (ulong)last);
            }
        }
    }

    public static T? GetValueReadOnly<T>(this IntPtr ptr) {
        return ((T)GCHandle.FromIntPtr(ptr).Target!);
    }

    unsafe public static void* GetRawPointer(this IntPtr ptr) {
        return (void*) GCHandle.FromIntPtr(ptr).AddrOfPinnedObject();
    }
}