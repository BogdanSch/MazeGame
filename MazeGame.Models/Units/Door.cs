namespace MazeGame.Models.Units
{
    public class Door : Unit
    {
        public Key? DoorKey { get; set; }
        private bool _isOpen = false;
        public bool IsOpen { 
            get => _isOpen; 
            set
            {
                _isOpen = value;

                if (value)
                    Symbol = '/';
                else
                    Symbol = DoorKey?.Symbol ?? 'D';
            }
        }
        public Door(char symbol, Key? key)
        {
            Symbol = symbol;
            Name = "Door";
            DoorKey = key;
        }
        public Door(char symbol) : this(symbol, null) { }
    }
}
