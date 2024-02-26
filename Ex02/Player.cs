using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class Player
    {
        public string Name { get; }
        public char Token { get; }

        public Player(string i_name, char token)
        {
            Name = i_name;
            Token = token;
        }
    }

}
