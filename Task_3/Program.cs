// See https://aka.ms/new-console-template for more information
using System;

class QueensPlacement
{
    static bool IsSafe(int[,] board, int row, int col)
    {
        // Check if there is a queen in the same row
        for (int i = 0; i < col; i++)
        {
            if (board[row, i] == 1)
                return false;
        }

        // Check upper diagonal on the left side
        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i, j] == 1)
                return false;
        }

        // Check lower diagonal on the left side
        for (int i = row, j = col; i < board.GetLength(0) && j >= 0; i++, j--)
        {
            if (board[i, j] == 1)
                return false;
        }

        return true;
    }

    static int CountWaysToPlaceQueens(int[,] board, int col)
    {
        if (col >= board.GetLength(1))
            return 1; 

        int count = 0;

        for (int i = 0; i < board.GetLength(0); i++)
        {
            if (IsSafe(board, i, col))
            {
                board[i, col] = 1; 

                count += CountWaysToPlaceQueens(board, col + 1);

                board[i, col] = 0; 
            }
        }

        return count;
    }

    static void Main()
    {
        int boardSize = 8; 
        int[,] chessBoard = new int[boardSize, boardSize];

        int ways = CountWaysToPlaceQueens(chessBoard, 0);

        Console.WriteLine($"Number of ways to place two queens on an {boardSize}x{boardSize} chessboard without attacking each other: {ways}");
    }
}

