using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace csharp_codewars2.Classes
{
    public class ConwayLife
    {



        public int[,] cellArray;
        public int cycles;
        public List<List<int>> cells;
        public List<List<int>> newCells;


        public ConwayLife(int[,] _cellArray, int _cycles)
        {
            cellArray = _cellArray;
            cycles = _cycles;
            
            cells = Enumerable.Range(0, cellArray.GetLength(0))
                    .Select(row => Enumerable.Range(0, cellArray.GetLength(1))
                    .Select(col => cellArray[row, col]).ToList())
                    .ToList();
            newCells = Enumerable.Range(0, cellArray.GetLength(0))
                    .Select(row => Enumerable.Range(0, cellArray.GetLength(1))
                    .Select(col => cellArray[row, col]).ToList())
                    .ToList();
        }

        
        public int[,] GetGeneration()
        {
            // Thread.Sleep(500);
            int cyclesRun = 0;


            Console.WriteLine("Utgangsposisjon: ");
            PrintMatrix(cells);

            if (isDead())
            {
                Console.WriteLine("Alle cellene er døde");
            }
            
            while (cyclesRun < cycles && !isDead())
            {

                Console.Clear();
                Console.WriteLine("\x1b[3J");


                cells = DeepCopy(runGeneration(cells));

                if (isDead())
                {
                    Console.WriteLine("Alle cellene er døde");
                    return new int[,] { { } };
                }
                Console.WriteLine("Generasjon #" + cyclesRun);
                PrintMatrix(cells);



                cyclesRun += 1;

                Thread.Sleep(100);

            }

            if (isDead())
            {
                int[,] empty = { { } };
                return empty;
            }

            // løkker gjennom 2d-listen

            int rows = cells.Count();
            int cols = cells[0].Count();

            int[,] finalState = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    finalState[i, j] = cells[i][j];
                }
            }

            return finalState;
        }


        public List<List<int>> runGeneration(List<List<int>> cells)
        {
            int count = 0;

            cells = ExpandList(cells);
            cells = ExpandList(cells);

            List<List<int>> newCells = DeepCopy(cells);




            for (int row = 1; row < cells.Count() - 1; row++)
            {
                for (int col = 1; col < cells[0].Count() - 1; col++)
                {
                    // teller 
                    for (int localRow = row - 1; localRow < row + 2; localRow++)
                    {
                        for (int localCol = col - 1; localCol < col + 2; localCol++)
                        {
                            if (cells[localRow][localCol] == 1)
                            {
                                count += 1;
                            }
                        }
                    }

                    if (count < 3 && cells[row][col] == 1)
                    {
                        /* Console.WriteLine("Cellen på cells[" + row + "][" + col + "] dør av underbefolkning."); */
                        newCells[row][col] = 0;

                    }
                    else if (count > 4 && cells[row][col] == 1)
                    {
                        /* Console.WriteLine("Cellen på cells[" + row + "][" + col + "] dør av overbefolkning."); */

                        newCells[row][col] = 0;

                    }
                    else if (count == 3 && cells[row][col] == 0)
                    {
                        /* Console.WriteLine("Cellen på cells[" + row + "][" + col + "] blir født."); */

                        newCells[row][col] = 1;
                    }

                    /* Console.WriteLine("Området rundt: cells[" + row + "][" + col + "]. Området cells[" + (row - 1) + "]" + "[" + (col - 1) + "]" + "til og med cells[" + (row + 1) + "]" + "[" + (col + 1) + "] inneholder " + count + " levende celler"); */

                    count = 0;
                }
            }

            newCells = DeepCopy(TrimList(newCells));
            
            return newCells;

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

            /* PrintMatrix(listToGrow); */
            return listToGrow;
        }

        // Fjerner ledende og følgende nuller fra 2d-lister
        public List<List<int>> TrimList(List<List<int>> listToTrim)
        {
            List<int> firstCol = new List<int>();
            List<int> lastCol = new List<int>();


            List<int> row = new List<int>();

            if (isDead())
            {
                Console.WriteLine("Kan ikke trimme listen. Det er kun døde celler igjen.");
                return listToTrim;
            }

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

            /* Console.WriteLine("Første rad: " + firstRow + "\nAndre rad: " + lastRow); */


            int firstColIndex = firstCol.Where(x => x >= 0).Min();
            int lastColIndex = lastCol.Where(x => x >= 0).Max();

/*             Console.WriteLine("Første kolonne: " + firstColIndex + "\nAndre kolonne: " + lastColIndex);
 */
            listToTrim = listToTrim[firstRow..(lastRow + 1)];

            for (int i = 0; i < listToTrim.Count(); i++)
            {
                listToTrim[i] = listToTrim[i][firstColIndex..(lastColIndex + 1)];
            }

            /* PrintMatrix(listToTrim); */

            return listToTrim;
        }

        public void PrintMatrix(List<List<int>> listOfLists)
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

        
        public void PrintMatrix(int[,] arrayToPrint)
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

        private bool isDead()
        {

            if (cells.All(x => x.All(y => y == 0)))
            {
                return true;
            }
            return false;
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
        

        public static List<List<int>> DeepCopy(List<List<int>> original)
    {
        var copy = new List<List<int>>();
        foreach (var innerList in original)
        {
            var innerCopy = new List<int>(innerList); // Creates a new list with the same elements
            copy.Add(innerCopy);
        }
        return copy;
    }


    }
}