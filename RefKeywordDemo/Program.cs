using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefExample
{
    class MatrixFind
    {
        public static (int i, int j) Find(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                    if (predicate(matrix[i, j]))
                        return (i, j);
        
                    // Not Found
                return (-1, -1);
        }

        public static ref int Find2(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                    if (predicate(matrix[i, j]))
                        return ref matrix[i, j];
            throw new InvalidOperationException("Not Found");
        }

        static void Main(string[] args)
        {
            //create a 5x5 matrix of ints
            const int MATRIX_ROWS = 5;
            const int MATRIX_COLUMNS = 5;

            int[,] matrix = new int[MATRIX_ROWS, MATRIX_COLUMNS];

            int count = 0;
            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    matrix[i, j] = count++;
                }
            }

            //old way of doing it by dereferencing
            var indices = MatrixFind.Find(matrix, (val) => val == 13);
            Console.WriteLine(indices);
            matrix[indices.i, indices.j] = 24;
            Console.WriteLine(matrix[indices.i, indices.j]);


            // As valItem is not a ref variable , the value from Find2 is copied into it by value
            var valItem = MatrixFind.Find2(matrix, (val) => val == 7);
            Console.WriteLine(valItem);
            valItem = 24;
            // 7 is still displayed because no ref variable is used
            Console.WriteLine(matrix[1, 2]);

            // new way of doing it using a ref variable
            ref var item = ref MatrixFind.Find2(matrix, (val) => val == 7);
            Console.WriteLine(item);
            // this now modifies the item in memory so 55 is displayed instead of 7
            item = 55;
            Console.WriteLine(matrix[1, 2]);
        }
    }
}
