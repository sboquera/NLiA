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

            RREF reducer = new RREF(r2);
            reducer.process();
            ElementaryOperations.print(r2);
        }
    }
}
