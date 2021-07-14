using System;
namespace Algorithms.Matrix
{
    public class MatrixAddition
    {
        public static int[,] Subtract(int[,] A, int[,] B)
        {
            return Add(A, B, true);
        }

        public static int[,] Add(int[,] A, int[,] B, bool negative = false)
        {
            int rowsA = A.GetLength(0);
            int columnsA = A.GetLength(1);

            int rowsB = B.GetLength(0);
            int columnsB = B.GetLength(1);

            int rows = Math.Max(rowsA, rowsB);
            int columns = Math.Max(columnsA, columnsB);

            if(rowsA < rows || columnsA < columns)
            {
                A = Pad(A, rows, columns);
            }

            if (rowsB < rows || columnsB < columns)
            {
                B = Pad(B, rows, columns);
            }

            int[,] C = new int[rows, columns];

            for (int i = 0; i<rows; i++)
            {
                for(int j = 0; j<columns; j++)
                {
                    if (negative)
                    {
                        C[i, j] = A[i, j] - B[i, j];
                    }
                    else
                    {
                        C[i, j] = A[i, j] + B[i, j];
                    }                    
                }
            }

            

            return C;
        }

        public static int[,] Pad(int[,] A, int rows, int columns)
        {
            var result = new int[rows, columns];

            int rowsA = A.GetLength(0);
            int columnsA = A.GetLength(1);

            for(var i=0; i<rowsA; i++)
            {
                for(var j=0; j<columnsA; j++)
                {
                    result[i, j] = A[i, j];
                }
            }           

            return result;
        }
    }
}
