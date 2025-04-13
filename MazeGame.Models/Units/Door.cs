namespace MazeGame.Models.Units
{
    public class Door : Unit
    {
        public Key? DoorKey { get; set; }
        public bool IsOpen { get; set; } = false;
        public Door(char symbol, Key? key)
        {
            Symbol = symbol;
            Name = "Door";
            DoorKey = key;
        }
        public Door(char symbol) : this(symbol, null) { }
    }
}
