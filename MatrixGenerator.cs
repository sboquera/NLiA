using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLiA
{
    public static class MatrixGenerator
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

        public static double[,] randomSquared(int num)
        {
            return random(num, num);
        }

        public static double[,] identity(int num)
        {
            double[,] result = new double[num, num];

            for(int i = 0; i < num; i++){
                result[i, i] = 1;
            }

            return result;
        }
    }
}
