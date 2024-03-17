namespace matrix
{
    internal class Program
    {
        static void Main()
        {
            Matrix2D A = new Matrix2D(1, 2, 3, 4);
            Console.WriteLine(A * A);
        }
    }
}
