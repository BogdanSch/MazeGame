using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame.Models.Units
{
    public abstract class Unit
    {
        public virtual string Name { get; set; } = String.Empty;
        public virtual ConsoleColor Color { get; set; } = ConsoleColor.White;
        public char Symbol { get; set; }
        public override string ToString()
        {
            return $"{Name}: {Symbol}";
        }
    }
}
