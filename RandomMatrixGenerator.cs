using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLiA
{
    public static class RandomMatrixGenerator
    {
        private static Random rand = new Random();

        public static double[,] random(int row, int col)
        {
            double[,] result = new double[row, col];
            for (int crow = 0; crow < row; crow++) 
            {
                for( int ccol = 0; ccol < col; ccol++) 
                {
                    result[crow, ccol] = rand.NextDouble();
                }
            }

            return result;
        }
    }
}
