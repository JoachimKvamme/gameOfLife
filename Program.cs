using csharp_codewars2.Classes;
using System.Linq;

namespace csharp_codewars2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        ConwayLifeKata gameOfLife = new ConwayLifeKata();
        gameOfLife.ConwayLife(gameOfLife.matrix, 0);

        List<List<int>> ints =
        [[0, 0, 0, 1, 1, 1, 0, 0, 0, 0],
        [0, 1, 0, 0, 1, 1, 0, 0, 0, 0]];
        List<List<int>> ints2 =
        [[0, 0, 0, 1, 1, 1, 0, 0, 0, 0],
        [0, 0, 0, 0, 1, 1, 0, 0, 1, 0]];
        List<List<int>> ints3 =
        [[0, 0, 0, 1, 1, 1, 0, 0, 0, 0],
        [1, 0, 0, 0, 1, 1, 0, 0, 0, 0]];

        gameOfLife.TrimList(ints);
        gameOfLife.TrimList(ints2);
        gameOfLife.TrimList(ints3);

        

    }
}
