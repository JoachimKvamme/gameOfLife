using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

                    if (originalCells[row][col] == 1 && count > 2 && count <= 4)
                    {
                        Console.WriteLine("Cellen på" + "[" + row + "]" + "[" + count + "]" + " lever videre");
                    }

                    if (originalCells[row][col] == 1 && (count == 1 || count == 0 || count == 2))
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
            int rowLength = 0;
            foreach (var row in listToGrow)
            {
                row.Insert(0, 0);
                row.Add(0);
                rowLength = row.Count();
            }

            listToGrow.Add(new List<int>());
            listToGrow.Insert(0, new List<int>());



            for (int i = 0; i < rowLength; i++)
            {
                listToGrow[0].Add(0);
                listToGrow[listToGrow.Count - 1].Add(0);
            }


            return listToGrow;
        }

        // Fjerner ledende og følgende nuller fra 2d-lister
        public List<List<int>> TrimList(List<List<int>> listToTrim)
        {
            List<int> firstCol = new List<int>();
            List<int> lastCol = new List<int>();


            List<int> row = new List<int>();

            for (int i = 0; i < listToTrim.Count(); i++)
            {
                if (listToTrim[i].Any(x => x == 1))
                {
                    row.Add(i);
                }
            }

            foreach (var item in listToTrim)
            {
                firstCol.Add(item.IndexOf(1));
                lastCol.Add(item.LastIndexOf(1));
            }

            int firstRow = row.Where(x => x >= 0).Min();
            int lastRow = row.Where(x => x >= 0).Max();

            Console.WriteLine("Første rad: " + firstRow + "\nAndre rad: " + lastRow);


            int firstColIndex = firstCol.Where(x => x >= 0).Min();
            int lastColIndex = lastCol.Where(x => x >= 0).Max();

            Console.WriteLine("Første kolonne: " + firstColIndex + "\nAndre kolonne: " + lastColIndex);

            

            return listToTrim;
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

        private void PrintList(List<int> listToPrint)
        {
            string showMatrix = "";
            foreach (var item in listToPrint)
            {
                showMatrix += " " + item;
            }

            Console.WriteLine(showMatrix);
        }


    }
}