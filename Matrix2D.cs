using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    internal class Matrix2D
    {
        private readonly int[,] _Matrix;
        public Matrix2D(int a, int b, int c, int d)
        {
            _Matrix = new int[2, 2];
            _Matrix[0, 0] = a;
            _Matrix[0, 1] = b;
            _Matrix[1, 0] = c;
            _Matrix[1, 1] = d;
        }

        public Matrix2D()
        {
            _Matrix = new int[2, 2];
            _Matrix[0, 0] = 1;
            _Matrix[0, 1] = 0;
            _Matrix[1, 0] = 0;
            _Matrix[1, 1] = 1;
        }

        public static readonly Matrix2D Id = new ();
        public static readonly Matrix2D Zero = new (0, 0, 0, 0);

        public override string ToString()
        {
            return $"[[{_Matrix[0, 0]}, {_Matrix[0, 1]}]\n [{_Matrix[1, 0]}, {_Matrix[1, 1]}]]";
        }
    }
}
