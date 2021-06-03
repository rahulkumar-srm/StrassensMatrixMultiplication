using System;

namespace StrassensMatrixMultiplication
{
    class Program
    {
        int[,] matrix1;
        int[,] matrix2;
        int n1, n2, m1, m2;

        static void Main(string[] args)
        {
            Program program = new Program();

            program.ReadMatrix();
            int[,] result = program.MultiplyMatrix(program.matrix1, program.matrix2);

            Console.WriteLine("\nResultant matrix : ");
            program.PrintMatrix(result, program.n1, program.m2);

            Console.ReadKey();
        }

        private void ReadMatrix()

        {
            Console.WriteLine("Size of first matrix");
            Console.Write("Enter the number of rows in Matrix 1 : ");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of columns in Matrix 1 : ");
            m1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nSize of second matrix");
            Console.Write("Enter the number of rows in Matrix 2 : ");
            n2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of columns in Matrix 2 : ");
            m2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (m1 != n2)
            {
                Console.WriteLine("Columns of Matrix 1 & Rows of Matrix 1 are not equal.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                matrix1 = new int[n1, m1];
                matrix2 = new int[n2, m2];

                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m1; j++)
                    {
                        Console.Write($"Enter the elements of matrix 1 : ");
                        matrix1[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }

                Console.WriteLine("\nMatrix 1 : ");
                PrintMatrix(matrix1, n1, m1);

                for (int i = 0; i < n2; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        Console.Write($"Enter the elements of matrix 2 : ");
                        matrix2[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }

                Console.WriteLine("\nMatrix 2 : ");
                PrintMatrix(matrix2, n2, m2);
            }
        }

        private void PrintMatrix(int[,] matrix, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private int[,] MultiplyMatrix(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetUpperBound(0) - matrix1.GetLowerBound(0) + 1;
            int size = matrix1.GetUpperBound(1) - matrix1.GetLowerBound(1) + 1;
            int columns = matrix2.GetUpperBound(1) - matrix2.GetLowerBound(1) + 1;

            int[,] result = new int[rows, columns];

            for(int i = 0; i< rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    for(int k = 0; k < size; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }
    }
}
