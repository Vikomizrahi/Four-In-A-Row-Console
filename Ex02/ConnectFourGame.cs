using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{

    public class ConnectFourGame
    {
        private readonly int r_width;
        private readonly int r_height;
        private readonly string r_player1Name;
        private readonly string r_player2Name;
        private readonly Random r_random;
        private int m_player1Score;
        private int m_player2Score;

        public ConnectFourGame(int i_width, int i_height, string i_player1Name, string i_player2Name)
        {
            r_width = i_width;
            r_height = i_height;
            r_player1Name = i_player1Name;
            r_player2Name = i_player2Name;
            r_random = new Random(); 
            m_player1Score = 0;
            m_player2Score = 0;
        }

        public void Start()
        {
            while (true)
            {
                GameBoard board = new GameBoard(r_width, r_height);
                board.Initialize();
                board.PrintBoard();

                Player player1 = new Player(r_player1Name, 'X');
                Player player2 = new Player(r_player2Name, 'O');

                while (true)
                {
                    if (TakeTurn(player1, board))
                    {
                        break; 
                    }

                    if (CheckGameEnd(player1, board)) break;

                    if (r_player2Name == "Computer")
                    {
                        ComputerTurn(player2, board);
                    }
                    else
                    {
                        if (TakeTurn(player2, board))
                        {
                            break; 
                        }
                    }

                    if (CheckGameEnd(player2, board)) break;
                }

                Console.WriteLine($"Score - {r_player1Name}: {m_player1Score}, {r_player2Name}: {m_player2Score}");

                
                Console.Write("Play another round? (Y/N): ");
                string input = Console.ReadLine().Trim();
                if (input.ToLower() != "y")
                {
                    Console.WriteLine("Goodbye!");
                    Console.ReadLine();
                    break;
                    
                }
             
            }
        }

        private bool TakeTurn(Player player, GameBoard board)
        {
            Console.WriteLine($"{player.Name}'s turn.");
            int col;

            do
            {
                Console.Write("Enter column number (1-" + board.Width + ") or 'Q' to quit: ");
                string input = Console.ReadLine().Trim();
                if (input.ToLower() == "q")
                {
                    Console.WriteLine($"{player.Name} quits. The other player receives a point.");
                    IncrementOpponentScore(player);
                    board.Initialize(); 
                    board.PrintBoard();
                    return true;
                }

                if (!int.TryParse(input, out col) || col < 1 || col > board.Width || board.IsColumnFull(col - 1))
                {
                    Console.WriteLine("Invalid input. Please enter a valid column number.");
                }
                else
                {
                    col--; 
                    break;
                }
            } while (true);

            board.PlaceToken(col, player.Token);
            board.PrintBoard();
            return false;
        }

        private void ComputerTurn(Player player, GameBoard board)
        {
            int col;
            do
            {
                col = r_random.Next(0, board.Width);
            } while (board.IsColumnFull(col));

            Console.WriteLine($"Computer places token in column {col + 1}.");
            board.PlaceToken(col, player.Token);
            board.PrintBoard();
        }

        private bool CheckGameEnd(Player player, GameBoard board)
        {
            if (board.CheckWin(player.Token))
            {
                Console.WriteLine($"{player.Name} wins!");
                IncrementPlayerScore(player);
                return true;
            }
            else if (board.IsBoardFull())
            {
                Console.WriteLine("It's a draw!");
                return true;
            }

            return false;
        }

        private void IncrementPlayerScore(Player player)
        {
            if (player.Name == r_player1Name)
            {
                m_player1Score++;
            }
            else
            {
                m_player2Score++;
            }
        }

        private void IncrementOpponentScore(Player currentPlayer)
        {
            if (currentPlayer.Name == r_player1Name)
            {
                m_player2Score++;
            }
            else
            {
                m_player1Score++;
            }
        }
    }
}



