## Day 3-2: Sudoku checker (Very hard)
Sudoku is a game in which you have to fill out a 9 x 9 grid of numbers in such a way that every column, row and 3 x 3 squares contains the number 1 through 9 only once.  
\
Create a function that takes in parameter a 2d nullable integer array (`int?[,]`) and checks wether or not it is valid. In order to be valid, all integers must not be null, and all rows, columns and quadrons (3x3 squares) must have all numbers from 1 to 9, without repetition.
### Examples
Given the following 2d array:
```csharp
var sudokuGridValid = new int?[9,9] 
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
```
The function should return `true`.  
However, if given one of the following arrays:
```csharp
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
var sudokuGridInvali2 = new int?[9,9] 
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
    {8,10,3,  2,9,6,  7,4,5},
    {2,7,4,  3,5,1,  6,9,8}
};
```
The function should return `false`.
### Notes
* You can assume the passed array will always be 9*9
#
Done [X]
