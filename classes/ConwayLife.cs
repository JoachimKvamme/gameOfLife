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

        public List<List<int>> ConwayLife(List<List<int>> matrix)
        {
            for (int row = 0; row < matrix.Count(); row++)
            {
                for (int field = 0; field < matrix[row].Count(); field++)
                {
                    if (matrix[row][field] == 1)
                    {
                        
                    }
                }
            }

            return [[]];
        }

        

    }
}