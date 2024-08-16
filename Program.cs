using System.Diagnostics;
using System;
using System.Globalization;

namespace NLiA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Thread th1 = new Thread(new ThreadStart(() => {
                double[,] ma = MatrixGenerator.randomSquared(16384);
                double[,] mb = MatrixGenerator.randomSquared(16384);
                DateTime localDate = DateTime.Now;
                Console.WriteLine($"t: {localDate.Hour}:{localDate.Minute}:{localDate.Second}h");
                Strassen.strassen(ma, mb);
                //Process.Start("shutdown", "/s /t 0");
                localDate = DateTime.Now;
                Console.WriteLine("Multiplication completed");
                Console.WriteLine($"t: {localDate.Hour}:{localDate.Minute}:{localDate.Second}h");
            }));

            th1.Start();
            

        }
    }
}
