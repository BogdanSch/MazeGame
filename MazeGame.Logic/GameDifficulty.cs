namespace MazeGame.Logic
{
    public class GameDifficulty
    {
        public string Name { get; set; } = string.Empty;
        public int RowsCount { get; set; }
        public int ColsCount { get; set; }
        public int GameDurationSeconds { get; set; }
        public GameDifficulty(string name, int rowsCount, int colsCount, int gameDurationSeconds)
        {
            Name = name;
            RowsCount = rowsCount;
            ColsCount = colsCount;
            GameDurationSeconds = gameDurationSeconds;
        }
        public GameDifficulty(int rowsCount, int colsCount, int gameDurationSeconds) : this(string.Empty, rowsCount, colsCount, gameDurationSeconds) { }

        public (int rowsCount, int colsCount, int gameDurationSeconds) GetGameDifficulty()
        {
            return (RowsCount, ColsCount, GameDurationSeconds);
        }
    }
}
