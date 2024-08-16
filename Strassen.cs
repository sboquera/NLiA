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
                // Validate
                if (!Strassen.productIsValid(ma, mb)) throw new Exception("Matrix sizes are not compatible for matrix multiplication");
                
                // Declare variables
                double[,] result = new double[ma.GetLength(0), mb.GetLength(1)];

                // Compute product
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

        public static double[,] add(double[,] ma, double[,] mb)
        {
            try
            {
                // Validate
                if (!Strassen.additionIsValid(ma, mb)) throw new Exception("Matrix sizes are not compatible for addition");

                // Declare variables
                double[,] result = new double[ma.GetLength(0), ma.GetLength(1)];

                // Compute addition
                for (int crow = 0; crow < ma.GetLength(0); crow++) { 
                    for(int ccol = 0; ccol < ma.GetLength(1); ccol++)
                    {
                        result[crow, ccol] = ma[crow, ccol] + mb[crow, ccol];
                    }
                }


                return result;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        public static double[,] split(double[,] ma, int r1, int r2, int c1, int c2)
        {
            try
            {
                // Validate
                if (!Strassen.splitIsValid(ma, r1, r2, c1, c2)) throw new Exception("Split indices are outside of the bounds of the array");

                // Declare variables
                int pSizeY = (r2 - r1) + 1;
                int pSizeX = (c2 - c1) + 1;
                double[,] result = new double[pSizeY,pSizeX];

                for (int crow = 0; crow < pSizeY; crow++)
                {
                    for (int ccol = 0; ccol < pSizeX; ccol++) 
                    {
                        result[crow, ccol] = ma[r1 + crow, c1 + ccol];
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

        private static bool additionIsValid(double[,] ma, double[,] mb)
        {
            int aLengthX = ma.GetLength(0);
            int aLengthY = ma.GetLength(1);
            int bLengthX = mb.GetLength(0);
            int bLengthY = mb.GetLength(1);

            if (aLengthY != bLengthY) return false;
            if (aLengthX != bLengthX) return false;


            return true;
        }

        private static bool splitIsValid(double[,] ma, int r1, int r2, int c1, int c2)
        {

            int aLastRow = ma.GetLength(0) - 1;
            int aLastCol = ma.GetLength(1) - 1;
            
            if (r1 < 0 || r1 > aLastRow) return false;
            if (r2 < 0 || r2 > aLastRow) return false;
            if (c1 < 0 || c1 > aLastCol) return false;
            if (c2 < 0 || c2 > aLastCol) return false;
            if (r2 < r1) return false;
            if (c2 < c1) return false;

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
