using System.Text.RegularExpressions;

namespace matrix
{
    public class Matrix2D : IEquatable<Matrix2D>
    {
        private readonly int[,] _matrix;
        public Matrix2D(int a, int b, int c, int d)
        {
            _matrix = new int[2, 2];
            _matrix[0, 0] = a;
            _matrix[0, 1] = b;
            _matrix[1, 0] = c;
            _matrix[1, 1] = d;
        }

        public Matrix2D()
        {
            _matrix = new int[2, 2];
            _matrix[0, 0] = 1;
            _matrix[0, 1] = 0;
            _matrix[1, 0] = 0;
            _matrix[1, 1] = 1;
        }

        public static readonly Matrix2D Id = new();
        public static readonly Matrix2D Zero = new(0, 0, 0, 0);

        public override string ToString()
        {
            return $"[[{_matrix[0, 0]}, {_matrix[0, 1]}]\n [{_matrix[1, 0]}, {_matrix[1, 1]}]]";
        }

        public int GetElement(int row, int col) => _matrix[row, col];

        // IEquatable implementation, comparison override
        public bool Equals(Matrix2D other)
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    if (_matrix[i, j] != other._matrix[i, j])
                        return false;
            return true;
        }

        public static bool operator ==(Matrix2D? left, Matrix2D? right) =>
            ReferenceEquals(left, right) || (left?.Equals(right) ?? false);

        public static bool operator !=(Matrix2D left, Matrix2D right) =>
            !(left == right);

        public override int GetHashCode() =>
            HashCode.Combine(_matrix[0, 0], _matrix[0, 1], _matrix[1, 0], _matrix[1, 1]);

        // Arithmetic operators override
        public static Matrix2D operator +(Matrix2D A, Matrix2D B)
        {
            return new Matrix2D(
                A._matrix[0, 0] + B._matrix[0, 0],
                A._matrix[0, 1] + B._matrix[0, 1],
                A._matrix[1, 0] + B._matrix[1, 0],
                A._matrix[1, 1] + B._matrix[1, 1]);
        }

        public static Matrix2D operator -(Matrix2D A, Matrix2D B)
        {
            return new Matrix2D(
                A._matrix[0, 0] - B._matrix[0, 0],
                A._matrix[0, 1] - B._matrix[0, 1],
                A._matrix[1, 0] - B._matrix[1, 0],
                A._matrix[1, 1] - B._matrix[1, 1]);
        }

        public static Matrix2D operator *(Matrix2D A, Matrix2D B)
        {
            int a = A._matrix[0, 0] * B._matrix[0, 0] + A._matrix[0, 1] * B._matrix[1, 0];
            int b = A._matrix[0, 0] * B._matrix[0, 1] + A._matrix[0, 1] * B._matrix[1, 1];
            int c = A._matrix[1, 0] * B._matrix[0, 0] + A._matrix[1, 1] * B._matrix[1, 0];
            int d = A._matrix[1, 0] * B._matrix[0, 1] + A._matrix[1, 1] * B._matrix[1, 1];

            return new Matrix2D(a, b, c, d);
        }

        public static Matrix2D operator *(int k, Matrix2D A)
        {
            return new Matrix2D(
                k * A._matrix[0, 0], k * A._matrix[0, 1],
                k * A._matrix[1, 0], k * A._matrix[1, 1]);
        }

        public static Matrix2D operator *(Matrix2D A, int k)
        {
            return new Matrix2D(
                k * A._matrix[0, 0], k * A._matrix[0, 1],
                k * A._matrix[1, 0], k * A._matrix[1, 1]);
        }

        public static Matrix2D operator -(Matrix2D A)
        {
            return new Matrix2D(
                -A._matrix[0, 0], -A._matrix[0, 1],
                -A._matrix[1, 0], -A._matrix[1, 1]);
        }

        // Some basic instance and class methods
        public static Matrix2D Transpose(Matrix2D A)
        {
            int a = A._matrix[0, 0];
            int b = A._matrix[1, 0];
            int c = A._matrix[0, 1];
            int d = A._matrix[1, 1];

            return new Matrix2D(a, b, c, d);
        }

        public static int Determinant(Matrix2D A) =>
            A._matrix[0, 0] * A._matrix[1, 1] - (A._matrix[0, 1] * A._matrix[1, 0]);

        public int Det() =>
            _matrix[0, 0] * _matrix[1, 1] - (_matrix[0, 1] * _matrix[1, 0]);

        // Conversion
        public static explicit operator int[,](Matrix2D matrix)
        {
            int[,] result = new int[2, 2];
            result[0, 0] = matrix._matrix[0, 0];
            result[0, 1] = matrix._matrix[0, 1];
            result[1, 0] = matrix._matrix[1, 0];
            result[1, 1] = matrix._matrix[1, 1];

            return result;
        }

        // Parse from string
        public static Matrix2D Parse(string text)
        {
            string pattern = @"\[\[-?\d+\s*,\s*-?\d+\],\s*\[-?\d+\s*,\s*-?\d+\]\]";
            if (!Regex.IsMatch(text, pattern))
                throw new FormatException("Wrong format");

            MatchCollection matches = Regex.Matches(text, @"-?\d+");

            Matrix2D matrix = new Matrix2D(
                int.Parse(matches[0].Value), int.Parse(matches[1].Value),
                int.Parse(matches[2].Value), int.Parse(matches[3].Value));

            return matrix;
        }
    }
}
