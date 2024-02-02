// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main()
    {
        int[,] chessboard = new int[8, 8];

        
        Random random = new Random();

        
        int startX = random.Next(8);
        int startY = random.Next(8);

        Console.WriteLine($"Starting position: {startY + 1}, {startX + 1}\n");

        
        chessboard[startX, startY] = 1;

        
        int[] moveX = { -2, -1, 1, 2, 2, 1, -1, -2 };
        int[] moveY = { -1, -2, -2, -1, 1, 2, 2, 1 };

        
        for (int i = 0; i < 8; i++)
        {
            int nextX = startX + moveX[i];
            int nextY = startY + moveY[i];

            if (IsValidMove(nextX, nextY))
            {
                chessboard[nextX, nextY] = 1;
            }
        }

        
        DisplayChessboard(chessboard);
    }

    static void DisplayChessboard(int[,] chessboard)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write($"{chessboard[i, j],-3}");
            }
            Console.WriteLine();
        }
    }

    static bool IsValidMove(int x, int y)
    {
        return x >= 0 && x < 8 && y >= 0 && y < 8;
    }
}


