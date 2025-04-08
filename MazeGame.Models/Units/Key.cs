using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame.Models.Units
{
    public class Key : Unit
    {
        public Key(char keySymbol) 
        {
            Symbol = keySymbol;
        }
    }
}
