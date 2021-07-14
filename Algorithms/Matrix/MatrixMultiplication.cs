using System;
namespace Algorithms.Matrix
{
    public class MatrixMultiplication
    {
        public static int[,] BruteForce(int[,] A, int[,] B)
        {
            int rowsA = A.GetLength(0);
            int columnsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int columnsB = B.GetLength(1);

            int[,] C;

            if (columnsA != rowsB) return null;

            C = new int[rowsA, columnsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < columnsB; j++)
                {
                    int dotProduct = 0;

                    for (int k = 0; k < columnsA; k++)
                    {
                        dotProduct += A[i, k] * B[k, j];
                    }

                    C[i, j] = dotProduct;
                }
            }

            return C;
        }

        public static int[,] StrassenMultiplication(int[,] A, int[,] B)
        {
            int rowsA = A.GetLength(0);
            int columnsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int columnsB = B.GetLength(1);
            int N = rowsA;

            int[,] C = new int[N,N];

            if(rowsA != rowsB
                || columnsA != columnsB
                || rowsA != columnsB
                || Math.Log2(N)%1 != 0
              )
            {
                //fallback to brute force method
                return BruteForce(A, B);
            }

            if(N > 1)
            {
                int[,] a = QuarterMatrix(A, true,true);
                int[,] b = QuarterMatrix(A, true, false);
                int[,] c = QuarterMatrix(A, false, true);
                int[,] d = QuarterMatrix(A, false, false);

                int[,] e = QuarterMatrix(B, true, true);
                int[,] f = QuarterMatrix(B, true, false);
                int[,] g = QuarterMatrix(B, false, true);
                int[,] h = QuarterMatrix(B, false, false);

                int[,] p1 = StrassenMultiplication(a, MatrixAddition.Subtract(f,h));
                int[,] p2 = StrassenMultiplication(MatrixAddition.Add(a,b), h);
                int[,] p3 = StrassenMultiplication(MatrixAddition.Add(c,d), e);
                int[,] p4 = StrassenMultiplication(d, MatrixAddition.Subtract(g,e));
                int[,] p5 = StrassenMultiplication(MatrixAddition.Add(a, d), MatrixAddition.Add(e, h));
                int[,] p6 = StrassenMultiplication(MatrixAddition.Subtract(b, d), MatrixAddition.Add(g, h));
                int[,] p7 = StrassenMultiplication(MatrixAddition.Subtract(a, c), MatrixAddition.Add(e, f));

                int[,] C1 = MatrixAddition.Add(p6, MatrixAddition.Subtract(MatrixAddition.Add(p5, p4), p2));
                int[,] C2 = MatrixAddition.Add(p1, p2);
                int[,] C3 = MatrixAddition.Add(p3, p4);
                int[,] C4 = MatrixAddition.Subtract(MatrixAddition.Subtract(MatrixAddition.Add(p1, p5),p7),p3);

                return CombineQuarters(C1, C2, C3, C4);
            }
            else
            {
                C[0, 0] = A[0, 0] * B[0, 0];
            }

            return C;
        }

        private static int[,] QuarterMatrix(int[,] A, bool top, bool left)
        {
            int rows = A.GetLength(0);
            int columns = A.GetLength(1);

            if (rows != columns || Math.Log2(rows) % 1 != 0) return null;

            int size = rows / 2;
            int[,] result = new int[size, size];

            int startRow = 0;
            int startColumn = 0;

            if (!top) startRow = size;
            if (!left) startColumn = size;

            for(int i=0; i<size; i++)
            {
                for(int j=0; j<size; j++)
                {
                    result[i, j] = A[startRow + i, startColumn + j];
                }
            }

            return result;
            
        }

        private static int[,] CombineQuarters(int[,] A, int[,] B, int[,] C, int[,] D)
        {
            int rows = A.GetLength(0);
            int columns = A.GetLength(1);

            if (rows != columns) return null;

            int size = rows;
            int[,] result = new int[size * 2, size * 2];

            if(size == 1)
            {
                result[0, 0] = A[0, 0];
                result[0, 1] = B[0, 0];
                result[1, 0] = C[0, 0];
                result[1, 1] = D[0, 0];
            }
            else
            {
                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                    {
                        result[i, j] = A[i, j];
                        result[i, j + columns] = B[i, j];
                        result[rows + i, j] = C[i, j];
                        result[rows + i, columns + j] = D[i, j];
                    }
                }
            }            

            return result;
        }
    }
}
