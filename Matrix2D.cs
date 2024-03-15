using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    internal class Matrix2D : IEquatable<Matrix2D>
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
    }
}
