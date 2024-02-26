using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSetup gameSetup = new GameSetup();
            ConnectFourGame game = new ConnectFourGame(gameSetup.Width, gameSetup.Height, gameSetup.Player1Name, gameSetup.Player2Name);
            game.Start();
        }
    }
}
