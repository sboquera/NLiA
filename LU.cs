using NLia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLiA
{
    public class LU
    {
        double[,] matrix;
        int rows;
        int cols;
        public double[,] L;
        public double[,] U;

        public LU(double[,] matrix)
        {
            this.rows = matrix.GetLength(0);
            this.cols = matrix.GetLength(1);

            this.matrix = matrix;
            this.L = (double[,]) matrix.Clone();
            this.U = MatrixGenerator.identity(rows);
        }

        public void process()
        {
            
            if (rows != cols) throw new Exception("LU decomposition can only be applied to square matrices");

            int crow = 0;
            for (int ccol = 0; ccol < cols; ccol++) {

                int pivotRow = findPivot(ccol, crow);

                if (pivotRow != -1)
                {
                    ElementaryOperations.permutate(matrix, pivotRow, crow);
                    reduceColumn(ccol, crow);
                    crow++;
                }
                
            }
        }

        // find pivot
        public int findPivot(int column, int row)
        {
            for (int crow = row; crow < rows; crow++)
            {
                if (L[crow, column] != 0) return crow;
            }

            return -1;
        }

        public void reduceColumn(int column, int pivotPosition)
        {
            for (int crow = pivotPosition + 1; crow < rows; crow++)
            {
                if (L[crow, column] != 0)
                {
                    double scalarValue = (-1) * L[crow, column] / L[pivotPosition, column];
                    ElementaryOperations.addScaledRow(L, scalarValue, pivotPosition, crow);
                }
                    
            }
        }

    }
}
