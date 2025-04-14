using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame.Models.Units
{
    public class Player : Unit
    {
        public List<Key> CollectedKeys { get; set; } = [];
        public override string Name { get; set; }
        public override ConsoleColor Color { get; set; }
        public Player(string name)
        {
            Name = name;
            Symbol = 'o';
            Color = ConsoleColor.Yellow;
        }
        public void AddKey(Key key)
        {
            CollectedKeys.Add(key);
        }
        public bool HasKey(Key key)
        {
            return CollectedKeys.Contains(key);
        }
        public void RemoveKey(Key key)
        {
            CollectedKeys.Remove(key);
        }
    }
}
