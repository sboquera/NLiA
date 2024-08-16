namespace NLiA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] ma = RandomMatrixGenerator.random(2, 2);
            double[,] mb = RandomMatrixGenerator.random(2, 2);

            double[,] result = Strassen.mul(ma, mb);
            Strassen.print(ma);
            Strassen.print(mb);
            Strassen.print(result);
        }
    }
}
