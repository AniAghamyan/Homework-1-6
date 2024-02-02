// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the number of rows (N): ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number of columns (M): ");
        int m = int.Parse(Console.ReadLine());

        if (n <= 0 || m <= 0)
        {
            Console.WriteLine("Invalid matrix dimensions. Rows and columns must be greater than 0.");
            return;
        }

        int[,] matrix = GenerateRandomMatrix(n, m);

        Console.WriteLine("Generated Matrix:");
        DisplayMatrix(matrix);
    }

    static int[,] GenerateRandomMatrix(int rows, int columns)
    {
        int[,] matrix = new int[rows, columns];
        Random random = new Random();

        
        int totalNumbers = rows * columns;
        int[] uniqueNumbers = new int[totalNumbers];
        for (int i = 0; i < totalNumbers; i++)
        {
            uniqueNumbers[i] = i + 1;
        }

        
        for (int i = totalNumbers - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            int temp = uniqueNumbers[i];
            uniqueNumbers[i] = uniqueNumbers[j];
            uniqueNumbers[j] = temp;
        }

        
        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = uniqueNumbers[index++];
            }
        }

        return matrix;
    }

    static void DisplayMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"{matrix[i, j],-4}");
            }
            Console.WriteLine();
        }
    }
}

