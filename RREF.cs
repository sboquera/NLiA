using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLia
{
    public class RREF
    {
        int rows = 0;
        int columns = 0;
        double[,] matrix;
        double[,] rref;

        public RREF(double[,] matrix) { 

            this.rows = matrix.GetLength(0);
            this.columns = matrix.GetLength(1);
            this.matrix = matrix;
            this.rref = (double[,]) matrix.Clone();
            
        }

        // find pivot
        public int findPivot(int column, int row)
        {
            for (int crow = row; crow < rows; crow++) 
            { 
                if(rref[crow, column] != 0) return crow;
            }

            return -1;
        }



        public double[,] process()
        {
            int crow = 0;
            for (int ccol = 0; ccol < columns; ccol++) {
                
                // find pivot
                int pivotRow = findPivot(ccol, crow);
              
                if(pivotRow != -1) {
                    reduceColumn(ccol, pivotRow);
                    crow++;
                }
            }

            return rref;
        }

        public void reduceColumn(int column, int pivotPosition)
        {
            for (int crow = 0; crow < rows; crow++) {
                if(crow != pivotPosition)
                {
                    if (rref[crow, column] != 0)
                    {
                        double scalarValue = (-1) * rref[crow, column] / rref[pivotPosition, column];
                        ElementaryOperations.addScaledRow(rref, scalarValue, pivotPosition, crow);
                    }
                }
                else
                {
                    double scalarValue = 1 / rref[crow, column];
                    ElementaryOperations.scaleRow(rref, scalarValue, pivotPosition);
                }
            }
        }

    }
}
