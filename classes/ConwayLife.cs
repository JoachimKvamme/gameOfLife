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
            // Thread.Sleep(500);
            int count = 0;

            List<List<int>> cells = Enumerable.Range(0, cellArray.GetLength(0))
                    .Select(row => Enumerable.Range(0, cellArray.GetLength(1))
                    .Select(col => cellArray[row, col]).ToList())
                    .ToList();

            for (int row = 0; row < cells.Count(); row++)
            {

            }

            PrintMatrix(cellArray);
            return cellArray;
        }

        public List<List<int>> ExpandList(List<List<int>> listToGrow)
        {
            List<int> newRow = new List<int>();
            foreach (var row in listToGrow)
            {
                row.Add(0);
                row.Insert(0, 0);

            }
            for (int i = 0; i < listToGrow[0].Count(); i++)
            {
                newRow.Add(0);
            }
            listToGrow.Add(newRow);
            listToGrow.Insert(0, newRow);


            PrintMatrix(listToGrow);

            return listToGrow;
        }

        // Fjerner ledende og følgende nuller fra 2d-lister
        public List<List<int>> TrimList(List<List<int>> listToTrim)
        {

            List<List<int>> croppedList = new List<List<int>>();
            int firstIndex = listToTrim[0].Count() - 1;
            int lastIndex = 0;
            foreach (var list in listToTrim)
            {

                if (list.IndexOf(1) < firstIndex)
                {
                    firstIndex = list.IndexOf(1);
                }
                if (list.LastIndexOf(1) > lastIndex)
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


            PrintMatrix(croppedList);


            return croppedList;
        }

        private void PrintMatrix(List<List<int>> listOfLists)
        {

            string showints = "";
            foreach (var item in listOfLists)
            {
                foreach (var cell in item)
                {
                    showints += " " + cell;
                }
                showints += "\n";
            }

            Console.WriteLine(showints);

        }

        private void PrintMatrix(int[,] arrayToPrint)
        {
            
            string showMatrix = "";
            for (int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                for (int x = 0; x < arrayToPrint.GetLength(1); x++)
                {
                    showMatrix += " " + arrayToPrint[i, x];
                }
                showMatrix += "\n";
                
            }

            Console.WriteLine(showMatrix);
        }

    }
}