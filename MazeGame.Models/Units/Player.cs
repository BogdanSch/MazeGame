using MazeGame.Models.GameTools;

namespace MazeGame.Models.Units
{
    public class Player : Unit
    {
        public int Score { get; set; } = 0;
        public List<Key> CollectedKeys { get; set; } = [];
        public List<Tool> CollectedTools { get; set; } = [];
        public int MaxCollectedTools { get; set; } = 4;
        public Tool? ActiveTool { get; set; } = null;
        public override string Name { get; set; }
        public Player(string name)
        {
            Name = name;
            Symbol = 'o';
            MessageStyle = new("Yellow");
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
        public void AddTool(Tool tool)
        {
            if (CollectedTools.Count >= MaxCollectedTools)
                return;
            CollectedTools.Add(tool);
        }
    }
}
