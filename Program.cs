namespace NLiA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] ma = RandomMatrixGenerator.random(6, 6);
            double[,] mb = RandomMatrixGenerator.random(16, 16);

            double[,] result = Strassen.strassen(ma, mb);

            
            Strassen.print(ma);
            Strassen.print(mb);
            Strassen.print(result);
        }
    }
}
