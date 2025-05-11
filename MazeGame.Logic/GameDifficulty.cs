namespace MazeGame.Logic
{
    public class GameDifficulty
    {
        public string Name { get; set; } = string.Empty;
        public int RowsCount { get; set; }
        public int ColsCount { get; set; }
        public int GameDurationSeconds { get; set; }
        public bool InversedControls { get; set; } = false;
        public GameDifficulty(string name, int rowsCount, int colsCount, int gameDurationSeconds, bool inversedControl)
        {
            Name = name;
            RowsCount = rowsCount;
            ColsCount = colsCount;
            GameDurationSeconds = gameDurationSeconds;
            InversedControls = inversedControl;
        }
        public GameDifficulty(int rowsCount, int colsCount, int gameDurationSeconds, bool inversedControl) : this(string.Empty, rowsCount, colsCount, gameDurationSeconds, inversedControl) { }
        public GameDifficulty(int rowsCount, int colsCount, int gameDurationSeconds) : this (string.Empty, rowsCount, colsCount, gameDurationSeconds, false) { }

        public (int rowsCount, int colsCount, int gameDurationSeconds, bool invertedControls) GetGameDifficulty()
        {
            return (RowsCount, ColsCount, GameDurationSeconds, InversedControls);
        }
    }
}
