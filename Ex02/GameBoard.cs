using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;//Guy Ronen dll

namespace Ex02
{
    public class GameBoard
    {
        private readonly char[,] r_board;

        public int Width { get; }
        public int Height { get; }

        public GameBoard(int i_width, int i_height)
        {
            Width = i_width;
            Height = i_height;
            r_board = new char[Height, Width];
        }

        public void Initialize()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    r_board[row, col] = ' ';
                }
            }
        }

        public bool IsColumnFull(int col)
        {
            return r_board[0, col] != ' ';
        }

        public bool PlaceToken(int col, char token)
        {
            for (int row = Height - 1; row >= 0; row--)
            {
                if (r_board[row, col] == ' ')
                {
                    r_board[row, col] = token;
                    return true;
                }
            }
            return false; 
        }

        public bool CheckWin(char token)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    // Check horizontally
                    if (col + 3 < Width &&
                        r_board[row, col] == token &&
                        r_board[row, col + 1] == token &&
                        r_board[row, col + 2] == token &&
                        r_board[row, col + 3] == token)
                    {
                        return true;
                    }
                    // Check vertically
                    if (row + 3 < Height &&
                        r_board[row, col] == token &&
                        r_board[row + 1, col] == token &&
                        r_board[row + 2, col] == token &&
                        r_board[row + 3, col] == token)
                    {
                        return true;
                    }
                    // Check diagonally (up-right)
                    if (row - 3 >= 0 && col + 3 < Width &&
                        r_board[row, col] == token &&
                        r_board[row - 1, col + 1] == token &&
                        r_board[row - 2, col + 2] == token &&
                        r_board[row - 3, col + 3] == token)
                    {
                        return true;
                    }
                    // Check diagonally (down-right)
                    if (row + 3 < Height && col + 3 < Width &&
                        r_board[row, col] == token &&
                        r_board[row + 1, col + 1] == token &&
                        r_board[row + 2, col + 2] == token &&
                        r_board[row + 3, col + 3] == token)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsBoardFull()
        {
            return !r_board.Cast<char>().Any(cell => cell == ' ');
        }

        public void PrintBoard()
        {
            Screen.Clear();//Method Guy Ronen 
            for (int col = 0; col < Width; col++)
            {
                Console.Write($"  {col + 1} ");
            }
            Console.WriteLine();

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Console.Write("| " + r_board[row, col] + " ");
                }
                Console.WriteLine("|");
                Console.WriteLine(new string('=', (Width * 4) + 1));


            }
       
      
        }

    }
}
