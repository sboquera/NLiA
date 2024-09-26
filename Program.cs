using System.Diagnostics;
using System;
using System.Globalization;
using NLia;

namespace NLiA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] i3 = MatrixGenerator.identity(3);
            double[,] r1 = new double[,] {
                { 6, 2, -2 },
                { 2, 1, 3 },
                { 8, 4, 5 },
            };
            double[,] r2 = new double[,] {
                { 6, 2, -2, 1 },
                { 2, 1, 3, 1 },
                { 8, 4, 5, 1 },
            };
            double[,] r3 = new double[,] {
                { 23, 18, -10, 4, -8 },
                { 10, 28, -5, 2, -12 },
                { 30, 45, -12, 6, -20 },
                { -30, 18, 15, -3, -8 },
                { 20, 54, -10, 4, -23 },
            };

            RREF reducer = new RREF(r3);
            reducer.process();
            ElementaryOperations.print(r3);
        }
    }
}
