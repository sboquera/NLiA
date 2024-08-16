using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLiA
{
    public static class Strassen
    {
        public static double[,] strassen(double[,] ma, double[,] mb)
        {
            try
            {
                if (!Strassen.isSquare(ma)) throw new Exception("Square matrix ma must be squared");
                if (!Strassen.isSquare(mb)) throw new Exception("Square matrix mb must be squared");
                if (!Strassen.productIsValid(ma, mb)) throw new Exception("Matrix sizes are not compatible for matrix multiplication");
                
                double[,] result = new double[ma.GetLength(0), ma.GetLength(1)];





                return result;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        public static double[,] mul(double[,] ma, double[,] mb)
        {
            try
            {
                // Validate size
                if (!Strassen.productIsValid(ma, mb)) throw new Exception("Matrix sizes are not compatible for matrix multiplication");
                
                // Declare variables
                double[,] result = new double[ma.GetLength(0), mb.GetLength(1)];

                for(int crow = 0; crow < ma.GetLength(0); crow++)
                {
                    for(int ccol = 0; ccol < mb.GetLength(1); ccol++)
                    {
                        result[crow, ccol] = 0;
                        for (int i = 0; i < ma.GetLength(1); i++)
                        {
                            result[crow, ccol] = ma[crow, i] * mb[i, ccol];
                        }
                    }
                }


                return result;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        private static bool isSquare(double[,] ma) {
            int aLengthY = ma.GetLength(0);
            int aLengthX = ma.GetLength(1);

            if (aLengthX != aLengthY) return false;

            return true;
        }

        private static bool productIsValid(double[,] ma, double[,] mb)
        {

            int aLengthY = ma.GetLength(1);
            int bLengthX = mb.GetLength(0);
            
            if(aLengthY != bLengthX) return false;

            return true;
        }

        public static void print(double[,] ma)
        {
            Console.WriteLine("M: ");
            for (int crow = 0; crow < ma.GetLength(0); crow++)
            {
                for (int ccol = 0; ccol < ma.GetLength(1); ccol++)
                {
                    Console.Write($"   {ma[crow, ccol]}   ");
                }
                Console.WriteLine();
            }
        }
    }
}
