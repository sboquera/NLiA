namespace NLiA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] ma = RandomMatrixGenerator.random(8, 8);
            double[,] mb = RandomMatrixGenerator.random(8, 8);
            double[,] result = Strassen.strassen(ma, mb);

            
            //Strassen.print(ma);
            //Strassen.print(mb);
            //Strassen.print(result);
        }
    }
}
