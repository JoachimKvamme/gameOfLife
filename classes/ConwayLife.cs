using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_codewars2.Classes
{
    public class ConwayLifeKata
    {

        public int[,] matrix =
        {{0, 0, 0, 0},
        {0, 1, 1, 0},
        {0, 1, 0, 0},
        {0, 0, 0, 0,} };

        public int[,] ConwayLife(int[,] cellArray, int generation)
        {

            int count = 0;
            
            List<List<int>> cells = Enumerable.Range(0, cellArray.GetLength(0))
                    .Select(row => Enumerable.Range(0, cellArray.GetLength(1))
                    .Select(col => cellArray[row, col]).ToList())
                    .ToList();

            string showMatrix = "";
            foreach (var item in cells)
            {
                foreach (var cell in item)
                {
                    showMatrix += " " + cell;
                }
                showMatrix += "\n";
            }

            Console.WriteLine(showMatrix);

            return cellArray;
        }

        

    }
}