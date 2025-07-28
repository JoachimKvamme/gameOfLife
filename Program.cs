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
        int firstIndex = ints[0].Count() -1;
        int lastIndex = ints[0].Count() - 1;
        foreach (var list in ints)
        {
            if (list.IndexOf(1) < firstIndex)
            {
                firstIndex = list.IndexOf(1);
            }
            if (list.LastIndexOf(1) < lastIndex)
            {
                lastIndex = list.LastIndexOf(1);
            }

        }
        Console.WriteLine(firstIndex);
        Console.WriteLine(lastIndex);
        

        string showints = "";
        foreach (var item in ints)
        {
            foreach (var cell in item)
            {
                showints += cell;
            }
            showints += "\n";
        }

        Console.WriteLine(showints);

    }
}
