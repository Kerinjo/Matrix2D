namespace matrix
{
    internal class Program
    {
        static void Main()
        {
            Matrix2D m1 = Matrix2D.Parse("[[12, 1], [13, -9]]");
            Matrix2D m2 = Matrix2D.Parse("[[100, 14], [1, 4]]");

            Console.WriteLine(m1 * m2);
            Console.WriteLine(m2.Det());

            Console.WriteLine(Matrix2D.Transpose(m1));

            Console.ReadLine();
        }
    }
}
