using System;
using System.Linq;

namespace _02._Armory
{
    public class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());

            char[,] field = new char[dimension, dimension];

            int currentRowIndex = 0;
            int currentColIndex = 0;
            int goldSpend = 0;
            int[] teleport1 = new int[2];
            int[] teleport2 = new int[2];
            for (int rows = 0; rows < field.GetLength(0); rows++)
            {
                char[] col = Console.ReadLine()
                    .ToArray();

                for (int cols = 0; cols < field.GetLength(1); cols++)
                {

                    field[rows, cols] = col[cols];
                    if (col[cols] == 'A')
                    {
                        currentRowIndex = rows;
                        currentColIndex = cols;
                        field[currentRowIndex, currentColIndex] = '-';
                    }
                    else if (col[cols] == 'M')
                    {
                        if (teleport1[0] == 0 && teleport1[1] == 0)
                        {
                            teleport1[0] = rows;
                            teleport1[1] = cols;
                        }
                        else
                        {
                            teleport2[0] = rows;
                            teleport2[1] = cols;
                        }
                    }
                }
            }
            string command = Console.ReadLine();
            bool outOfField = false;
            while (true)
            {

                switch (command)
                {
                    case "up":
                        if (BoundsCheck(currentRowIndex - 1, currentColIndex, field))
                        {

                            currentRowIndex--;
                            (currentRowIndex, currentColIndex, goldSpend, field)
                                = PositionActions(currentRowIndex, currentColIndex, field, goldSpend, teleport1, teleport2);
                        }
                        else { outOfField = true; }

                        break;
                    case "down":
                        if (BoundsCheck(currentRowIndex + 1, currentColIndex, field))
                        {

                            currentRowIndex++;
                            (currentRowIndex, currentColIndex, goldSpend, field)
                                = PositionActions(currentRowIndex, currentColIndex, field, goldSpend, teleport1, teleport2);
                        }
                        else { outOfField = true; }
                        break;
                    case "right":
                        if (BoundsCheck(currentRowIndex, currentColIndex + 1, field))
                        {

                            currentColIndex++;
                            (currentRowIndex, currentColIndex, goldSpend, field)
                                = PositionActions(currentRowIndex, currentColIndex, field, goldSpend, teleport1, teleport2);
                        }
                        else { outOfField = true; }
                        break;
                    case "left":
                        if (BoundsCheck(currentRowIndex, currentColIndex - 1, field))
                        {

                            currentColIndex--;
                            (currentRowIndex, currentColIndex, goldSpend, field)
                                = PositionActions(currentRowIndex, currentColIndex, field, goldSpend, teleport1, teleport2);
                        }
                        else { outOfField = true; }
                        break;

                }
                if (goldSpend < 65 && outOfField == false)
                {
                    command = Console.ReadLine();
                }
                else { break; }
            }
            
            if (outOfField)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else if (goldSpend >= 65)
            {
                field[currentRowIndex, currentColIndex] = 'A';
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {goldSpend} gold coins.");
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write($"{field[row, col]}");
                }
                Console.WriteLine();
            }
        }
        public static bool BoundsCheck(int rowIndex, int colIndex, char[,] matrix)
            {
                if (rowIndex >= 0 && colIndex >= 0 && rowIndex < matrix.GetLength(0) && colIndex < matrix.GetLength(1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        public static Tuple<int, int, int, char[,]> PositionActions(int row, int col, char[,] field, int gold, int[] teleport1, int[] teleport2)
        {
            if (char.IsDigit(field[row, col]))
            {
                int points = int.Parse(field[row, col].ToString());
                gold += points;
                field[row, col] = '-';
            }
            else if (field[row, col] == 'M')
            {

                if (row == teleport1[0] && col == teleport1[1])
                {
                    field[teleport1[0], teleport1[1]] = '-';
                    field[teleport2[0], teleport2[1]] = '-';
                    row = teleport2[0];
                    col = teleport2[1];
                }
                else
                {

                    field[teleport1[0], teleport1[1]] = '-';
                    field[teleport2[0], teleport2[1]] = '-';
                    row = teleport1[0];
                    col = teleport1[1];
                }
            }
            return Tuple.Create(row, col, gold, field);
        }
    }
}

  
