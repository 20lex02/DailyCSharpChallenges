public static class Program {
    public static void Main(string[] args) {
        Console.WriteLine(GetLongestPath("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext")); // 20
        Console.WriteLine(GetLongestPath("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext")); // 32
        Console.WriteLine(GetLongestPath("dir\n\tsubdir1\n\tsubdir2\n\t\tsubsubdir")); // 0
    }

    public static int GetLongestPath(string fileSystem) {
        var dirs = fileSystem.Split('\n');
        return GetLongestPath(dirs, new string[0], 0, 0);
    }

    public static int GetLongestPath(string[] dirs, string[] root, int i, int currentMax) {
        var current = dirs[i];

        root = root.Append(current).ToArray();

        var currentLength = root.Last().Contains('.') ? root.Select(dir => dir.Trim()).SelectMany(root => root).Count() + root.Count() - 1 : 0;
        currentMax = Math.Max(currentMax, currentLength);

        var currentLevel = current.Where(c => c == '\t').Count();

        var nextDirs = dirs.Select((path, index) => new {path, index})
                           .Skip(i + 1).TakeWhile(dir => dir.path.Where(c => c == '\t').Count() != currentLevel)
                           .Where(dir => dir.path.Where(c => c == '\t').Count() == currentLevel + 1);

        foreach (var nextDir in nextDirs) {
            currentMax = Math.Max(GetLongestPath(dirs, root, nextDir.index, currentMax), currentMax);
        }

        return currentMax;
    }
}