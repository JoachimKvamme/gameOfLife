using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_codewars2.Classes
{
    public class ConwayLifeKata
    {

        public int[,] matrix =
        {{1, 0, 0, 0},
        {0, 1, 1, 0},
        {0, 1, 0, 0},
        {0, 0, 0, 0,} };

        public int[,] ConwayLife(int[,] cellArray, int generation)
        {
            // Thread.Sleep(500);
            int generationsRun = 0;

            List<List<int>> cells = Enumerable.Range(0, cellArray.GetLength(0))
                    .Select(row => Enumerable.Range(0, cellArray.GetLength(1))
                    .Select(col => cellArray[row, col]).ToList())
                    .ToList();

            if (isDead(cells))
            {
                int[,] empty = { { } };
                return empty;
            }



            while (generationsRun <= generation && !isDead(cells))
            {
                cells = TrimList(cells);
                cells = runGeneration(cells);
                cells = ExpandList(cells);
                Thread.Sleep(1000);
                generationsRun += 1;
                Console.Clear();
                
            }
            

            PrintMatrix(cellArray);
            return cellArray;
        }

        List<List<int>> runGeneration(List<List<int>> cells)
        {
            
            List<List<int>> originalCells = cells;
            int count = 0;

            // Løkker gjennom først radene, deretter kolonnene i den todimensjonale listen.
            for (int row = 1; row < cells.Count() - 1; row++)
            {
                for (int col = 1; col < cells[0].Count() - 1; col++)
                {
                    // Løkker gjennom omlandet til den enkelte cellen.

                    for (int localRow = row - 1; localRow < row + 2; localRow++)
                    {
                        for (int localCell = col - 1; localCell < col + 2; localCell++)
                        {
                            /* Console.WriteLine("Løkken er på: [" + localRow + "] [" + localCell + "] og verdien er: " + cells[localRow][localCell]); */
                            if (originalCells[localRow][localCell] == 1)
                            {
                                count += 1;
                                Console.WriteLine("count: " + count);
                            }
                        }
                    }

                    if (originalCells[row][col] == 1 && count > 4)
                    {
                        cells[row][col] = 0;
                        Console.WriteLine("Cellen på" + "[" + row + "]" + "[" + count + "]" + " dør av overbefolkning.");
                    }

                    if (originalCells[row][col] == 1 && count > 1 && count <= 4)
                    {
                        Console.WriteLine("Cellen på" + "[" + row + "]" + "[" + count + "]" + " lever videre");
                    }

                    if (originalCells[row][col] == 1 && (count == 1 || count == 0))
                    {
                        cells[row][col] = 0;
                        Console.WriteLine("Cellen på" + "[" + row + "]" + "[" + count + "]" + " dør av underbefolkning");
                    }

                    if (originalCells[row][col] == 0 && count == 3)
                    {
                        cells[row][col] = 1;
                        Console.WriteLine("Cellen på" + "[" + row + "]" + "[" + count + "]" + " blir født.");
                    }
                    count = 0;

                }
            }
            PrintMatrix(cells);
            return cells;
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
                    firstIndex = list.FirstOrDefault(1);
                }
                if (list.LastIndexOf(1) > lastIndex)
                {
                    lastIndex = list.LastOrDefault(1);
                }

            }
            Console.WriteLine(firstIndex);
            Console.WriteLine(lastIndex);

            foreach (var row in listToTrim)
            {
                if (firstIndex == -1)
                {
                    croppedList.Add(row.GetRange(firstIndex + 1, (lastIndex + 1) - firstIndex));
                    continue;
                }
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

        private bool isDead(List<List<int>> cells)
        {

            if (cells.All(x => x.All(y => y == 0)))
            {
                return true;
            }
            return false;
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