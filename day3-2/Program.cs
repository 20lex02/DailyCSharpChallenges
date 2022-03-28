using System.Linq;
public static class Program
{
    public static void Main(string[] args)
    {
        var sudokuGridValid = new int?[9, 9]
        {
            {6,3,9,  5,7,4,  1,8,2},
            {5,4,1,  8,2,9,  3,7,6},
            {7,8,2,  6,1,3,  9,5,4},

            {1,9,8,  4,6,7,  5,2,3},
            {3,6,5,  9,8,2,  4,1,7},
            {4,2,7,  1,3,5,  8,6,9},

            {9,5,6,  7,4,8,  2,3,1},
            {8,1,3,  2,9,6,  7,4,5},
            {2,7,4,  3,5,1,  6,9,8}
        };

        var sudokuGridInvalid1 = new int?[9,9] 
        {
            {6,3,9,  5,7,4,  1,8,2},
            {5,4,1,  8,5,9,  3,7,6},
            {7,8,2,  6,1,3,  9,5,4},

            {1,9,8,  4,6,7,  5,2,3},
            {3,6,5,  9,8,2,  4,3,7},
            {4,2,7,  1,3,5,  8,6,9},

            {9,5,6,  7,4,8,  2,3,1},
            {8,1,3,  2,2,6,  7,4,5},
            {2,7,4,  3,5,1,  6,9,8}
        };

        int? o = null;
        var sudokuGridInvalid2 = new int?[9,9] 
        {
            {6,3,9,  5,7,4,  1,8,2},
            {5,4,1,  8,2,9,  3,7,6},
            {7,8,2,  6,1,3,  9,o,4},

            {1,9,8,  4,6,7,  5,2,3},
            {3,6,5,  9,8,2,  4,1,7},
            {4,2,7,  1,3,5,  8,6,9},

            {9,5,6,  7,4,8,  2,3,1},
            {8,1,3,  2,o,6,  7,4,5},
            {2,7,4,  3,5,1,  6,9,8}
        };

        var sudokuGridInvalid3 = new int?[9,9] 
        {
            {6,3,9,  5,7,4,  1,8,2},
            {5,4,1,  8,2,9,  3,7,6},
            {7,8,2,  6,1,3,  9,0,4},
        
            {1,9,8,  4,6,7,  5,2,3},
            {3,6,5,  9,8,2,  4,1,7},
            {4,2,7,  1,3,5,  8,6,9},
        
            {9,5,6,  7,4,8,  2,3,1},
            {8,10,3, 2,9,6,  7,4,5},
            {2,7,4,  3,5,1,  6,9,8}
        };

        Console.WriteLine(CheckSudoku(sudokuGridValid)); // true
        Console.WriteLine(CheckSudoku(sudokuGridInvalid1)); // false
        Console.WriteLine(CheckSudoku(sudokuGridInvalid2)); // false
        Console.WriteLine(CheckSudoku(sudokuGridInvalid3)); // false
    }

    public static bool CheckSudoku(int?[,] sudokuGrid) {
        if ( !sudokuGrid.Cast<int?>().All(number => number is not null && ((int)number!).InRange(1,9)) ) {
            // If not all numbers are valid, return false
            return false;
        }

        // Separate the grid via lines, columns and quadrants
        var lines = sudokuGrid.GetRows();
        var columns = sudokuGrid.GetColumns();
        var quadrants = sudokuGrid.GetQuadrants(3);

        // Put them all together
        IEnumerable<IEnumerable<int?>> components = lines.AppendAllEnumerables(columns, quadrants);

        // Return true if they are all unique
        return components.All(numbers => numbers.Unique());
    }

    /// <summary>
    /// Checks wether or not an int is within the specified range (inclusive)
    /// </summary>
    /// <param name="min">The minimum value that the number can be (inclusive)</param>
    /// <param name="max">The maximum value that the number can be (inclusive)</param>
    /// <returns>
    /// If the number is within the specified range
    /// </returns>
    public static bool InRange(this int val, int min, int max) {
        return min <= val && val <= max;
    }

    /// <summary>
    /// Gets the rows from a 2d array
    /// </summary>
    /// <returns>
    /// The rows from a 2d array
    /// </returns>
    public static IEnumerable<IEnumerable<T>> GetRows<T>(this T[,] grid) {
        for (int rowIndex = 0; rowIndex < grid.GetLength(0); rowIndex++){
            var value = Enumerable.Range(0, grid.GetLength(1) - 1).Select(i => grid[rowIndex, i]);
            yield return value;
        }
    }

    /// <summary>
    /// Gets the colums from a 2d array
    /// </summary>
    /// <returns>
    /// The columns from a 2d array
    /// </returns>
    public static IEnumerable<IEnumerable<T>> GetColumns<T>(this T[,] grid) {
        for (int colIndex = 0; colIndex < grid.GetLength(1); colIndex++) {
            var value = Enumerable.Range(0, grid.GetLength(0) - 1).Select(i => grid[i, colIndex]);
            yield return value;

        }
    }

    /// <summary>
    /// splits up a 2d array into quadrants of specified size and flattens them.
    /// </summary>
    /// <param name="quadrantsSize">The size of the quadrants</param>
    public static IEnumerable<IEnumerable<T>> GetQuadrants<T>(this T[,] grid, int quadrantsSize) {
        // Get the amount of numbers within one quadrant
        var quadrantLength = quadrantsSize * quadrantsSize;
        // Get the number of quadrants required to fill out the grid
        var quadrantCountX = grid.GetLength(0) / quadrantsSize;
        var quadrantCountY = grid.GetLength(1) / quadrantsSize;

        for (int quadrantIndex = 0; quadrantIndex * quadrantIndex < grid.Length ; quadrantIndex++) {
            // Get the global coordinates for the first number of the quadrant (top-left)
            var globalRowIndex = (quadrantIndex / quadrantCountY) * quadrantCountX;
            var globalColIndex = (quadrantIndex % quadrantCountY) * quadrantCountY;

            // Select all the numbers within the quadrant                              
            yield return Enumerable.Range(0, quadrantLength)
                                           // Add the local position to the global one and return the value at the corresponding coordinates
                .Select(localIndex => grid[globalRowIndex + localIndex / quadrantsSize, globalColIndex + localIndex % quadrantsSize]);
        }
    }

    /// <summary>
    /// Appends all the specified IEnumerables to a data source
    /// </summary>
    /// <param name="enumerablesToAppend">The IEnumerables to append to the data source</param>
    /// <returns>
    /// The appended original source
    /// </returns>
    public static IEnumerable<T> AppendAllEnumerables<T>(this IEnumerable<T> original, params IEnumerable<T>[] enumerablesToAppend) {
        var returnValue = original;
        foreach (var enumerable in enumerablesToAppend) {
            returnValue.AppendEnumerable(enumerable);
        }
        
        return returnValue;
    }

    /// <summary>
    /// Appends the specified IEnumerable to a data source
    /// </summary>
    /// <param name="enumerable">The IEnumerable to append to the data source</param>
    /// <returns>
    /// The appended original source
    /// </returns>
    public static IEnumerable<T> AppendEnumerable<T>(this IEnumerable<T> original, IEnumerable<T> enumerable) {
        var returnValue = original;
        foreach (var value in enumerable) {
            returnValue = returnValue.Append(value);
        }
        
        return returnValue;
    }

    /// <summary>
    /// Checks wether or not all elements are unique
    /// </summary>
    public static bool Unique<T>(this IEnumerable<T> source)
    {
        return source.GroupBy(item => item).Count() == source.Count();
    }
}