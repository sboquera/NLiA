using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NLia
{
    public class ElementaryOperations
    {
        public static double[,] scaleRow(double[,] matrix, double scalar, int row)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            if (row >= rows) throw new Exception($"Can't scale a row with index greater than {rows}");

            for(int ccol = 0; ccol < columns; ccol++)
            {
                matrix[row, ccol] = scalar * matrix[row, ccol];
            }

            return matrix;
        }

        public static double[,] addScaledRow(double[,] matrix, double scalar, int baseRow, int targetRow)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            if (baseRow >= rows) throw new Exception($"Can't scale a row with index greater than {rows}");
            if (targetRow >= rows) throw new Exception($"Can't scale a row with index greater than {rows}");

            for (int ccol = 0; ccol < columns; ccol++)
            {
                matrix[targetRow, ccol] += scalar * matrix[baseRow, ccol];
            }


            return matrix;
        }

        public static double[,] permutate(double[,] matrix, int baseRow, int targetRow)
        {

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            
            if (baseRow >= rows) throw new Exception($"Can't scale a row with index greater than {rows}");
            if (targetRow >= rows) throw new Exception($"Can't scale a row with index greater than {rows}");

            // handle trivial case
            if (baseRow == targetRow) return matrix;

            // handle non trivial case
            for (int ccol = 0; ccol < columns; ccol++)
            {
                double temp = matrix[baseRow, ccol];
                matrix[baseRow, ccol] = matrix[targetRow, ccol];
                matrix[targetRow, ccol] = temp;
            }

            return matrix;
        }


        public static void print(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int crow = 0; crow < rows; crow++)
            {
                for(int ccol = 0; ccol < columns; ccol++)
                {
                    Console.Write($"{matrix[crow, ccol]}  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
