namespace matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix2D matrix = new Matrix2D(2, 2, 4, 4);
            Matrix2D id = new Matrix2D();

            Console.WriteLine(matrix);
            Console.WriteLine(id);
            Console.WriteLine(Matrix2D.Zero);
        }
    }
}
