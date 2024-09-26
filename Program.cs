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
            double[,] random3 = MatrixGenerator.randomSquared(3);
            
            ElementaryOperations.print(random3);
            ElementaryOperations.permutate(random3, 0, 2);
            ElementaryOperations.print(random3);
        }
    }
}
