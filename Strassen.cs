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
                // Validate
                if (!Strassen.isSquare(ma)) throw new Exception("Square matrix ma must be squared");
                if (!Strassen.isSquare(mb)) throw new Exception("Square matrix mb must be squared");
                if (!Strassen.productIsValid(ma, mb)) throw new Exception("Matrix sizes are not compatible for matrix multiplication");
                
                // Declare variables
                double[,] result = new double[ma.GetLength(0), ma.GetLength(1)];
                int lengthY = ma.GetLength(0);
                int lengthX = ma.GetLength(1);
                int middlePointY = (lengthY / 2) - 1;
                int middlePointX = (lengthX / 2) - 1;
                
                // Handle base case
                if(lengthX <= 4) return Strassen.mul(ma, mb);

                // Handle general case
                double[,] A11 = Strassen.split(ma, 0, middlePointY, 0, middlePointX);
                double[,] A12 = Strassen.split(ma, 0, middlePointY, middlePointX + 1, lengthX - 1);
                double[,] A21 = Strassen.split(ma, middlePointY + 1, lengthY - 1, 0, middlePointX);
                double[,] A22 = Strassen.split(ma, middlePointY + 1, lengthY - 1, middlePointX + 1, lengthX - 1);

                double[,] B11 = Strassen.split(mb, 0, middlePointY, 0, middlePointX);
                double[,] B12 = Strassen.split(mb, 0, middlePointY, middlePointX + 1, lengthX - 1);
                double[,] B21 = Strassen.split(mb, middlePointY + 1, lengthY - 1, 0, middlePointX);
                double[,] B22 = Strassen.split(mb, middlePointY + 1, lengthY - 1, middlePointX + 1, lengthX - 1);

                double[,] P1 = Strassen.strassen(Strassen.add(A11, A22), Strassen.add(B11, B22));
                double[,] P2 = Strassen.strassen(Strassen.add(A21, A22), B11);
                double[,] P3 = Strassen.strassen(A11, Strassen.sub(B12, B22));
                double[,] P4 = Strassen.strassen(A22, Strassen.sub(B21, B11));
                double[,] P5 = Strassen.strassen(Strassen.add(A11, A12), B22);
                double[,] P6 = Strassen.strassen(Strassen.sub(A21, A11), Strassen.add(B11, B12));
                double[,] P7 = Strassen.strassen(Strassen.sub(A12, A22), Strassen.add(B21, B22));

                double[,] C11 = Strassen.sub(Strassen.add(P1, Strassen.add(P4, P7)), P5);
                double[,] C12 = Strassen.add(P3, P5);
                double[,] C21 = Strassen.add(P2, P4);
                double[,] C22 = Strassen.sub(Strassen.add(P1, Strassen.add(P3, P6)), P2);


                Strassen.join(result, C11, 0, middlePointY, 0, middlePointX);
                Strassen.join(result, C12, 0, middlePointY, middlePointX + 1, lengthX - 1);
                Strassen.join(result, C21, middlePointY + 1, lengthY - 1, 0, middlePointX);
                Strassen.join(result, C22, middlePointY + 1, lengthY - 1, middlePointX + 1, lengthX - 1);

                
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
        
        public static double[,] sub(double[,] ma, double[,] mb)
        {
            try
            {
                // Validate
                if (!Strassen.additionIsValid(ma, mb)) throw new Exception("Matrix sizes are not compatible for addition");

                // Declare variables
                double[,] result = new double[ma.GetLength(0), ma.GetLength(1)];

                // Compute addition
                for (int crow = 0; crow < ma.GetLength(0); crow++)
                {
                    for (int ccol = 0; ccol < ma.GetLength(1); ccol++)
                    {
                        result[crow, ccol] = ma[crow, ccol] - mb[crow, ccol];
                    }
                }


                return result;
            }
            catch (Exception e)
            {
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

        private static double[,] join(double[,] parent, double[,] child, int r1, int r2, int c1, int c2)
        {
            try
            {
                // Validate
                if (!Strassen.joinIsValid(parent, r1, r2, c1, c2)) throw new Exception("Join indices are outside of the bounds of the parent array");
                if (!Strassen.boundIsValid(child, r1, r2, c1, c2)) throw new Exception("Child matrix is not of the correct size");

                // Declare variables
                int pLengthY = (r2 - r1) + 1;
                int pLengthX = (c2 - c1) + 1;
                
                double[,] result = new double[parent.GetLength(0), parent.GetLength(1)];

                for (int crow = 0; crow < pLengthY; crow++)
                {
                    for (int ccol = 0; ccol < pLengthX; ccol++)
                    {
                        parent[r1 + crow, c1 + ccol] = child[crow, ccol];   
                    }
                }

                return parent;
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

        private static bool joinIsValid(double[,] ma, int r1, int r2, int c1, int c2)
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

        private static bool boundIsValid(double[,] ma, int r1, int r2, int c1, int c2)
        {
            int lengthY = ma.GetLength(0);
            int lengthX = ma.GetLength(1);
            int pLengthY = (r2 - r1) + 1;
            int pLengthX = (c2 - c1) + 1;

            if (lengthY != pLengthY) return false;
            if (lengthX != pLengthX) return false;

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
