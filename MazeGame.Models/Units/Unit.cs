namespace MazeGame.Models.Units
{
    public abstract class Unit
    {
        public virtual string Name { get; set; } = string.Empty;
        public char Symbol { get; set; }
        public MessageStyle MessageStyle { get; set; } = new();
        public override string ToString()
        {
            return $"{Name}: {Symbol}";
        }
    }
}
