// See https://aka.ms/new-console-template for more information
using System;

class SaddlePointProgram
{
    static void Main()
    {
        Console.WriteLine("Enter the number of rows (M):");
        int M = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number of columns (N):");
        int N = int.Parse(Console.ReadLine());

        int[,] matrix = new int[M, N];

        Console.WriteLine($"Enter {M}x{N} matrix elements:");

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"Enter element at position ({i + 1},{j + 1}): ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int saddlePoint = FindSaddlePoint(matrix, M, N);

        if (saddlePoint != -1)
        {
            Console.WriteLine($"Saddle point: {saddlePoint}");
        }
        else
        {
            Console.WriteLine("No saddle point found.");
        }
    }

    static int FindSaddlePoint(int[,] matrix, int M, int N)
    {
        for (int i = 0; i < M; i++)
        {
            int maxInRow = int.MinValue;
            int columnIndex = -1;


            for (int j = 0; j < N; j++)
            {
                if (matrix[i, j] > maxInRow)
                {
                    maxInRow = matrix[i, j];
                    columnIndex = j;
                }
            }


            bool isSaddlePoint = true;

            for (int k = 0; k < M; k++)
            {
                if (matrix[k, columnIndex] < maxInRow)
                {
                    isSaddlePoint = false;
                    break;
                }
            }

            if (isSaddlePoint)
            {
                return maxInRow;
            }
        }

        return -1;
    }
}

