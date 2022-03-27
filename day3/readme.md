## Day 3: Tree serialization (Medium)
Given the root to a binary tree, implement `Serialize(root)`, which serializes the tree into a string, and `Deserialize(s)`, which deseraializes the string back into the tree.  
### Examples
Given the following `Node` class 
```csharp
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
```
And the following node
```csharp
var node = new Node("root", new("left", new("left.left")), new("right"));
```
The functions should return the following:
* `Deserialize(Serialize(node)).Left.Left.Val` -> `"left.left"`
* `Deserialize(Serialize(node)).Right.Val` -> `"right`
#
Done [X]