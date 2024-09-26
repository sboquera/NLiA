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
            this.rref = new double[rows, columns];

        }

        public int findPivot(int column)
        {
            for (int crow = 0; crow < rows; crow++) 
            { 
                if(matrix[crow, column] != 0) return crow;
            }

            return -1;
        }

        public double[,] process()
        {

            for (int ccol = 0; ccol < columns; ccol++) {
                    
            }

            return rref;
        }
        

        


    }
}
