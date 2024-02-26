using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class GameSetup
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Player1Name { get; private set; }
        public string Player2Name { get; private set; }

        public GameSetup()
        {
            SetupGame();
        }

        private void SetupGame()
        {
            Width = GetBoardDimension("width");
            Height = GetBoardDimension("height");
            ChooseGameMode();
        }

        private int GetBoardDimension(string dimension)
        {
            int m_value;
            while (true)
            {
                Console.Write($"Enter the {dimension} of the board (4-8): ");
                if (int.TryParse(Console.ReadLine(), out m_value) && m_value >= 4 && m_value <= 8)
                {
                    return m_value;
                }
                Console.WriteLine("Invalid input. Please enter a number between 4 and 8.");
            }
        }

        private void ChooseGameMode()
        {
            int m_choice;

            Console.WriteLine("Choose game mode:");
            Console.WriteLine("1. 2 player game");
            Console.WriteLine("2. Playing against the computer");

            while (!int.TryParse(Console.ReadLine(), out m_choice) || (m_choice != 1 && m_choice != 2))
            {
                Console.WriteLine("Invalid input. Please enter 1 or 2.");
                Console.WriteLine("Choose game mode:");
                Console.WriteLine("1. 2 player game");
                Console.WriteLine("2. Playing against the computer");
            }

            if (m_choice == 1)
            {
                Console.Write("Enter player 1 name: ");
                Player1Name = Console.ReadLine();
                Console.Write("Enter player 2 name: ");
                Player2Name = Console.ReadLine();
            }
            else
            {
                Console.Write("Enter your name: ");
                Player1Name = Console.ReadLine();
                Player2Name = "Computer";
            }
        }
    }
}
