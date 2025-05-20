using MazeGame.Logic;
using MazeGame.Models;
using MazeGame.Models.Enums;
using MazeGame.Models.GameTools;
using MazeGame.Models.Units;

namespace MazeGame.WinForms
{
    public partial class MainForm : Form
    {
        public Font LargeFont = new("Segoe UI", 14);
        public const int CELL_SIZE = 36;
        public Color WALL_CELL_COLOR = Color.DimGray;
        public Color DEFAULT_CELL_COLOR = Color.Silver;
        public Color INTERACTABLE_CELL_COLOR = Color.Khaki;
        public Color EXIT_CELL_COLOR = Color.Aqua;

        private Game? _game;
        private Label[,]? _labelsGrid;
        private bool _keyHeld = false;
        private bool _inversedControls = false;
        private GameDifficulty? _currentGameDifficulty;
        public MainForm()
        {
            InitializeComponent();
            MinimumSize = MaximumSize;
            SizeGripStyle = SizeGripStyle.Hide;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeGame();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_game == null) return;
            GC.Collect();
        }
        private void InitializeGame()
        {
            using ConfigureGameForm configureGameForm = new();
            DialogResult result = configureGameForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                _currentGameDifficulty = configureGameForm.GameDifficulty;
                _inversedControls = configureGameForm.InversedControls;

                _labelsGrid = new Label[_currentGameDifficulty.RowsCount, _currentGameDifficulty.ColsCount];
                _game = new Game(_currentGameDifficulty, DisplayInventory, DisplayLeftTime);
                _game.StartGame();
                CreateMazeGrid();

                WindowState = FormWindowState.Maximized;
            }
            else
            {
                MessageBox.Show("Game configuration was not set. Exiting the game.");
                Close();
            }
        }
        public void UpdateMazeGrid()
        {
            if (_game == null || _labelsGrid == null)
            {
                MessageBox.Show("Game is not initialized.");
                return;
            }

            Cell[,] mazeGrid = _game.MazeGrid;

            for (int row = 0; row < _game.MazeGrid.GetLength(0); row++)
            {
                for (int col = 0; col < _game.MazeGrid.GetLength(1); col++)
                {
                    Cell cell = mazeGrid[row, col];
                    Label cellLabel = _labelsGrid[row, col];

                    cellLabel.Text = cell.ToString();

                    ApplyCellStyles(cell, cellLabel);
                }
            }
        }
        public void CreateMazeGrid()
        {
            if (_game == null || _labelsGrid == null)
            {
                MessageBox.Show("Game is not initialized.");
                return;
            }

            Cell[,] mazeGrid = _game.MazeGrid;

            gridPanel.Controls.Clear();

            for (int row = 0; row < _game.MazeGrid.GetLength(0); row++)
            {
                for (int col = 0; col < _game.MazeGrid.GetLength(1); col++)
                {
                    Cell cell = mazeGrid[row, col];

                    Label cellLabel = new()
                    {
                        Size = new Size(CELL_SIZE, CELL_SIZE),
                        BackColor = DEFAULT_CELL_COLOR,
                        Text = cell.ToString(),
                        Font = LargeFont,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(col * CELL_SIZE, row * CELL_SIZE)
                    };

                    ApplyCellStyles(cell, cellLabel);

                    _labelsGrid[row, col] = cellLabel;
                    gridPanel.Controls.Add(cellLabel);
                }
            }
        }
        private void ApplyCellStyles(Cell cell, Label cellLabel)
        {
            Color textColor = Color.Black;
            Unit? occupyingUnit = cell.OccupyingUnit;

            MessageStyle? messageStyle = cell.OccupyingUnit?.MessageStyle;
            if (messageStyle != null) textColor = Color.FromName(messageStyle.ColorName);
            cellLabel.ForeColor = textColor;

            if (occupyingUnit is Wall)
            {
                cellLabel.BackColor = WALL_CELL_COLOR;
                cellLabel.Text = string.Empty;
            }
            else if (occupyingUnit is Key || occupyingUnit is Door || occupyingUnit is Tool)
            {
                cellLabel.BackColor = INTERACTABLE_CELL_COLOR;
            }
            else if (occupyingUnit is Exit)
            {
                cellLabel.BackColor = EXIT_CELL_COLOR;
            }
            else
            {
                cellLabel.BackColor = DEFAULT_CELL_COLOR;
            }
        }
        private void DisplayGameState(string gameState)
        {
            gameStatusLabel.Text = gameState;
        }
        public void DisplayInventory(string inventory)
        {
            SafeInvoke(() => playerInventoryLabel.Text = inventory);
        }
        public void DisplayLeftTime(string timeLeft)
        {
            SafeInvoke(() => timeLeftLabel.Text = timeLeft);
        }
        public void SafeInvoke(Action action)
        {
            if (InvokeRequired)
                this?.Invoke(action);
            else
                action();
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_game == null) return;
            if (_keyHeld)
            {
                e.Handled = true;
                return;
            }

            _keyHeld = true;
            if (TryConvertKeyToDirection(e.KeyCode, out Direction direction))
            {
                _game.MovePlayer(direction);
            }
            else if (e.KeyCode == Keys.X)
            {
                _game.UseTool();
            }
            else
            {
                TrySelectTool(e.KeyCode);
            }

            UpdateMazeGrid();
            DisplayGameState(_game.GameState);

            if (_game.IsGameOver)
            {
                HandleGameOver();
            }
        }
        private bool TryConvertKeyToDirection(Keys key, out Direction direction)
        {
            switch (key)
            {
                case Keys.W:
                case Keys.Up:
                    direction = _inversedControls ? Direction.Down : Direction.Up;
                    return true;
                case Keys.S:
                case Keys.Down:
                    direction = _inversedControls ? Direction.Up : Direction.Down;
                    return true;
                case Keys.A:
                case Keys.Left:
                    direction = _inversedControls ? Direction.Right : Direction.Left;
                    return true;
                case Keys.D:
                case Keys.Right:
                    direction = _inversedControls ? Direction.Left : Direction.Right;
                    return true;
                default:
                    direction = Direction.Up;
                    return false;
            }
        }
        private bool TrySelectTool(Keys key)
        {
            if (_game == null) return false;

            switch (key)
            {
                case Keys.D1:
                case Keys.NumPad1:
                    _game.SelectTool(0);
                    return true;
                case Keys.D2:
                case Keys.NumPad2:
                    _game.SelectTool(1);
                    return true;
                case Keys.D3:
                case Keys.NumPad3:
                    _game.SelectTool(2);
                    return true;
                case Keys.D4:
                case Keys.NumPad4:
                    _game.SelectTool(3);
                    return true;
                default:
                    return false;
            }
        }
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            _keyHeld = false;
        }
        private void HandleGameOver()
        {
            if (_game == null || !_game.IsGameOver) return;

            using GameOverForm gameOverForm = new();
            gameOverForm.Player = _game.Player;
            gameOverForm.PlayerScore = _game.Score;
            gameOverForm.LeaderboardManager = _game.LeaderboardManager;
            gameOverForm.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = gameOverForm.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                InitializeGame();
            }
            else
            {
                MessageBox.Show("Exiting the game!");
                Close();
            }
        }
    }
}
