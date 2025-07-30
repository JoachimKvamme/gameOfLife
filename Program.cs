using csharp_codewars2.Classes;
using System.Linq;

namespace csharp_codewars2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        ConwayLifeKata gameOfLife = new ConwayLifeKata();


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

        for (int i = 0; i < 4; i++)
        {

            startingMatrix = gameOfLife.ExpandList(startingMatrix);
            
        }

        

    }
}
