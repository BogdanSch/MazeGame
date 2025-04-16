namespace MazeGame.Models
{
    public class MessageStyle
    {
        public const string DEFAULT_COLOR = "Grey";
        public string ColorName { get; set; } = string.Empty;
        public bool IsBold { get; set; } = false;

        public MessageStyle(string colorName, bool isBold)
        {
            ColorName = colorName;
            IsBold = isBold;
        }
        public MessageStyle(string colorName) : this(colorName, false) { }
        public MessageStyle() : this(DEFAULT_COLOR) { }
    }
}
