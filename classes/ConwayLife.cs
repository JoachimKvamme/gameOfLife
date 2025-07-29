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

        // Fjerner ledende og følgende nuller fra 2d-lister
        public List<List<int>> TrimList(List<List<int>> listToTrim)
        {

            List<List<int>> croppedList = new List<List<int>>();
        int firstIndex = listToTrim[0].Count() -1;
        int lastIndex = listToTrim[0].Count() - 1;
        foreach (var list in listToTrim)
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
        
        foreach (var row in listToTrim)
        {
            croppedList.Add(row.GetRange(firstIndex, (lastIndex + 1) - firstIndex));
        }




        string showints = "";
        foreach (var item in croppedList)
        {
            foreach (var cell in item)
            {
                showints += cell;
            }
            showints += "\n";
        }

            Console.WriteLine(showints);
            return croppedList;
        }

    }
}