using csharp_codewars2.Classes;

namespace csharp_codewars2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        ConwayLifeKata gameOfLife = new ConwayLifeKata();
        gameOfLife.ConwayLife(gameOfLife.matrix, 0);
    }
}
