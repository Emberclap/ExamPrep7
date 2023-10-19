using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace _02._Pawn_Wars
{
    public class Program
    {
        static void Main(string[] args)
        {
            int dimension = 8;

            char[,] field = new char[dimension, dimension];

            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;
            for (int rows = 0; rows < field.GetLength(0); rows++)
            {
                char[] col = Console.ReadLine()
                    .ToArray();

                for (int cols = 0; cols < field.GetLength(1); cols++)
                {

                    field[rows, cols] = col[cols];
                    if (col[cols] == 'w')
                    {
                        whiteRow = rows;
                        whiteCol = cols;
                    }
                    else if (col[cols] == 'b')
                    {
                        blackRow = rows;
                        blackCol = cols;

                    }
                }
            }
            int turn = 0;

            while (true)
            {

                    field[whiteRow, whiteCol] = '-';
                    if (whiteCol + 1 < 7 && field[whiteRow-1, whiteCol+1] == 'b' )
                    {
                        whiteRow--;
                        whiteCol++;
                        Console.WriteLine($"Game over! White capture on {Position(whiteRow, whiteCol)}.");
                        break;
                    }
                    else if (whiteCol > 0 && field[whiteRow-1, whiteCol-1] == 'b')
                    {
                        whiteRow--;
                        whiteCol--;
                        Console.WriteLine($"Game over! White capture on {Position(whiteRow, whiteCol)}.");
                        break;
                    }
                    else
                    {
                        whiteRow--;
                    }
                    field[whiteRow, whiteCol] = 'w';
                    if (IsQueen(whiteRow, field))
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {Position(whiteRow, whiteCol)}.");
                        break;
                    }
                
                    field[blackRow, blackCol] = '-';
                    if (blackCol + 1 < 7 && field[blackRow+1, blackCol+1] == 'w')
                    {
                        blackRow++; blackCol++;
                        Console.WriteLine($"Game over! Black capture on {Position(blackRow, blackCol)}.");
                        break;
                    }
                    else if (blackCol - 1 >= 0 && field[blackRow+1, blackCol-1] == 'w')
                    {
                        blackRow++; blackCol--;
                        Console.WriteLine($"Game over! Black capture on {Position(blackRow, blackCol)}.");
                        break;
                    }
                    else
                    {
                        blackRow++;
                    }
                    field[blackRow, blackCol] = 'b';
                    if (IsQueen(blackRow, field))
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {Position(blackRow, blackCol)}.");
                        break;
                    }
                
            }
        }
        public static bool IsQueen(int rowIndex, char[,] matrix)
        {
            if (rowIndex == 0 || rowIndex == 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static string Position(int row, int col)
        {

            var sb = new StringBuilder();

            for (int i = 8; i >= 0; i--)
            {
                if (col == i)
                {
                    sb.Append((char)(i + 97));
                }
            }

            int counter = 8;
            for (int i = 0; i < 8; i++)
            {
                if (row == i)
                {
                    sb.Append(counter);
                }
                counter--;
            }
            return $"{sb}";
        }

    }
}
