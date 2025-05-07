using MazeGame.Logic;
using MazeGame.Models;
using MazeGame.Models.Enums;

namespace MazeGame.WinForms
{
    public partial class MainForm : Form
    {
        public const int CELL_SIZE = 36;
        private Game? _game;
        private Label[,]? _gridLabels;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            using ConfigureGameForm configureGameForm = new();
            DialogResult result = configureGameForm.ShowDialog();

            if (result == DialogResult.OK)
            {

                int gameDurationSeconds = configureGameForm.GameDurationSeconds;
                int rowsCount = configureGameForm.RowsCount;
                int colsCount = configureGameForm.ColsCount;

                _gridLabels = new Label[rowsCount, colsCount];
                _game = new Game(rowsCount, colsCount, DisplayInventory, DisplayLeftTime, gameDurationSeconds);
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
            if(_game == null || _gridLabels == null)
            {
                MessageBox.Show("Game is not initialized.");
                return;
            }

            Cell[,] mazeGrid = _game.MazeGrid;

            for (int row = 0; row < _game.MazeGrid.GetLength(0); row++)
            {
                for (int col = 0; col < _game.MazeGrid.GetLength(1); col++)
                {
                    Color textColor = Color.Black;
                    Cell cell = mazeGrid[row, col];
                    Label cellLabel = _gridLabels[row, col];

                    cellLabel.Text = cell.ToString();

                    MessageStyle? messageStyle = cell.OccupyingUnit?.MessageStyle;
                    if (messageStyle != null) textColor = Color.FromName(messageStyle.ColorName);

                    cellLabel.ForeColor = textColor;
                }
            }
        }
        public void CreateMazeGrid()
        {
            if (_game == null || _gridLabels == null)
            {
                MessageBox.Show("Game is not initialized.");
                return;
            }

            Cell[,] mazeGrid = _game.MazeGrid;

            for (int row = 0; row < _game.MazeGrid.GetLength(0); row++)
            {
                for (int col = 0; col < _game.MazeGrid.GetLength(1); col++)
                {
                    Color textColor = Color.Black;
                    Cell cell = mazeGrid[row, col];

                    MessageStyle? messageStyle = cell.OccupyingUnit?.MessageStyle;
                    Label cellLabel = new()
                    {
                        Size = new Size(CELL_SIZE, CELL_SIZE),
                        BackColor = Color.DarkGray,
                        Text = cell.ToString(),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(col * CELL_SIZE, row * CELL_SIZE)
                    };

                    if (messageStyle != null) textColor = Color.FromName(messageStyle.ColorName);
                    cellLabel.ForeColor = textColor;

                    _gridLabels[row, col] = cellLabel;
                    gridPanel.Controls.Add(cellLabel);
                }
            }
        }
        private void DisplayGameState(string gameState)
        {
            SafeInvoke(() => gameStatusLabel.Text = gameState);
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
        }
        private static bool TryConvertKeyToDirection(Keys key, out Direction direction)
        {
            switch (key)
            {
                case Keys.W:
                case Keys.Up:
                    direction = Direction.Up;
                    return true;
                case Keys.S:
                case Keys.Down:
                    direction = Direction.Down;
                    return true;
                case Keys.A:
                case Keys.Left:
                    direction = Direction.Left;
                    return true;
                case Keys.D:
                case Keys.Right:
                    direction = Direction.Right;
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
    }
}
