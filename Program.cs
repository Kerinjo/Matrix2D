namespace matrix
{
    internal class Program
    {
        static void Main()
        {
            Matrix2D matrix = new Matrix2D(2, 2, 4, 4);
            Matrix2D id = new Matrix2D();

            Console.WriteLine(matrix);
            Console.WriteLine(id.Equals(Matrix2D.Id));
            Console.WriteLine(id == Matrix2D.Id);
            Console.WriteLine(id == Matrix2D.Id);

            Matrix2D matrix2 = new Matrix2D(2, 2, 4, 4);
            Console.WriteLine(matrix != matrix2);

            Console.WriteLine(id.GetHashCode());
            Console.WriteLine(Matrix2D.Zero.GetHashCode());
        }
    }
}
