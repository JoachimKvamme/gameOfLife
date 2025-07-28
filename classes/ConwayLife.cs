using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_codewars2.Classes
{
    public class ConwayLifeKata
    {

        List<List<int>> matrix =
        [[0, 0, 0, 0],
        [0, 1, 0, 0],
        [0, 1, 0, 0],
        [0, 0, 0, 0,]];

        public int[,] ConwayLife(int[,] cells, int generation)
        {

            int count = 0;

            // Loops trough the original matrix
            for (int row = 0; row < cells.GetLength(0); row++)
            {
                for (int col = 0; col < cells.GetLength(1); col++)
                {
                    // Checks for live cells, then loops through the surrounding cells.
                    if (cells[row, col] == 1)
                    {
                        for (int i = row - 1; i < row + 1; i++)
                        {
                            for (int x = col - 1; i < row + 1; i++)
                            {
                                if (cells[i, x] == 1 && (i, x) != (row, col))
                                {
                                    count += 1;
                                    Console.WriteLine(count);
                                }

                            }

                        }
                        Console.WriteLine("The live cell on coordinates " + row + " " + col + " has " + count + " neighbours.");
                    }
                }
            }


            return cells;
        }

        

    }
}