using csharp_codewars2.Classes;
using System.Dynamic;
using System.Linq;

namespace csharp_codewars2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        ConwayLifeKata gameOfLife = new ConwayLifeKata();



        int[,] startingArray = {
            {1,1,1,0,0,0,1,0},
            {1,0,0,0,0,0,0,1},
            {0,1,0,0,0,1,1,1}
        };
        List<List<int>> startingMatrix = [
            [1,1,1,0,0,0,1,0],
            [1,0,0,0,0,0,0,1],
            [0,1,0,0,0,1,1,1]
        ];
        List<List<int>> ints =
        [[0, 0, 0, 1, 1, 1, 0, 0, 0, 0],
        [0, 1, 0, 0, 1, 1, 0, 0, 0, 0]];
        List<List<int>> ints2 =
        [[0, 0, 0, 1, 1, 1, 0, 0, 0, 0],
        [0, 0, 0, 0, 1, 1, 0, 0, 1, 0]];
        List<List<int>> ints3 =
        [[0, 0, 0, 1, 1, 1, 0, 0, 0, 0],
        [1, 0, 0, 0, 1, 1, 0, 0, 0, 0]];

        int[,] empty = { { } };

        gameOfLife.ConwayLife(startingArray, 16);

    }
}
