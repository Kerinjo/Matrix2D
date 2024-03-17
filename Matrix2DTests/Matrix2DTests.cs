using Xunit;
using matrix;

public class MatrixDeclaration
{
    [Fact]
    public void DefaultConstructor_ReturnsIdentityMatrix()
    {
        Matrix2D matrix = new Matrix2D();

        Assert.Equal(1, matrix.GetElement(0, 0));
        Assert.Equal(0, matrix.GetElement(0, 1));
        Assert.Equal(0, matrix.GetElement(1, 0));
        Assert.Equal(1, matrix.GetElement(1, 1));
    }

    [Fact]
    public void CustomConstructor_ReturnsSpecifiedMatrix()
    {
        Matrix2D matrix = new Matrix2D(1, 2, 3, 4);

        Assert.Equal(1, matrix.GetElement(0, 0));
        Assert.Equal(2, matrix.GetElement(0, 1));
        Assert.Equal(3, matrix.GetElement(1, 0));
        Assert.Equal(4, matrix.GetElement(1, 1));
    }
}

public class MatrixAddition
{
    [Fact]
    public void Addition_Test()
    {
        Matrix2D matrix1 = new Matrix2D(1, 3, 5, 7);
        Matrix2D matrix2 = new Matrix2D(2, 4, 6, 8);

        Matrix2D result = matrix1 + matrix2;
        Assert.Equal(new Matrix2D(3, 7, 11, 15), result);
    }

    [Fact]
    public void AddZeroMatrix_ReturnsOriginalMatrix()
    {
        Matrix2D matrix = new Matrix2D(3, 4, 15, 20);
        Assert.Equal(matrix, matrix + Matrix2D.Zero);
    }
}

public class MatrixMultiplication
{
    [Fact]
    public void Multiplication_Test()
    {
        Matrix2D matrix1 = new Matrix2D(2, 3, 1, 4);
        Matrix2D matrix2 = new Matrix2D(3, 2, 1, -6);

        Matrix2D result = matrix1 * matrix2;
        Assert.Equal(new Matrix2D(9, -14, 7, -22), result);
    }

    [Fact]
    public void MultiplyByIdentityMatrix_ReturnsOriginalMatrix()
    {
        Matrix2D matrix = new Matrix2D(2, 7, 3, -12);
        Assert.Equal(matrix, matrix * Matrix2D.Id);
    }
}