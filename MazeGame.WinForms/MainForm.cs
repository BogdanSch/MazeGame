using MazeGame.Logic;
using MazeGame.Models;
using MazeGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGame.WinForms
{
    public partial class MainForm : Form
    {
        public const int CELL_SIZE = 30;
        private Game? _game;
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
                _game = new Game(rowsCount, colsCount, DisplayInventory, DisplayLeftTime, gameDurationSeconds);
                _game.StartGame();
                CreateMazeGridLayout();
            }
            else
            {
                MessageBox.Show("Game configuration was not set. Exiting the game.");
                Close();
            }
        }
        public void CreateMazeGridLayout()
        {
            if (_game == null)
            {
                MessageBox.Show("Game is not initialized.");
                return;
            }

            Cell[,] mazeGrid = _game.MazeGrid;

            for (int row = 0; row < _game.MazeGrid.GetLength(0); row++)
            {
                for (int col = 0; col < _game.MazeGrid.GetLength(0); col++)
                {
                    Cell cell = mazeGrid[row, col];
                    Label cellLabel = new Label();
                    cellLabel.Size = new Size(CELL_SIZE, CELL_SIZE);
                    cellLabel.BackColor = Color.White;
                    cellLabel.ForeColor = Color.Black;
                    cellLabel.Text = cell.ToString();
                    cellLabel.TextAlign = ContentAlignment.MiddleCenter;
                    cellLabel.Location = new Point(col * CELL_SIZE, row * CELL_SIZE);
                    gridPanel.Controls.Add(cellLabel);
                }
            }
        }
        private void DisplayGameState(string gameState)
        {
            SafeInvoke(() => gameStatusLabel.Text = gameState);
            //gameStatusLabel.Text = gameState;
        }
        public void DisplayInventory(string inventory) 
        {
            SafeInvoke(() => playerInventoryLabel.Text = inventory);
            //playerInventoryLabel.Text = inventory;
        }
        public void DisplayLeftTime(string timeLeft)
        {
            SafeInvoke(() => timeLeftLabel.Text = timeLeft);
        }
        public void SafeInvoke(Action action)
        {
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_game == null) return;

            _game.MovePlayer(Direction.Up);
            DisplayGameState(_game.GameState);
        }
        private bool TryConvertKeyToDirection(ConsoleKey key, out Direction direction)
        {
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    direction = Direction.Up;
                    return true;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    direction = Direction.Down;
                    return true;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    return true;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    return true;
                default:
                    direction = Direction.Up;
                    return false;
            }
        }
        private static bool TrySelectTool(ConsoleKey key, Game game)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    game.SelectTool(0);
                    return true;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    game.SelectTool(1);
                    return true;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    game.SelectTool(2);
                    return true;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    game.SelectTool(3);
                    return true;
                default:
                    return false;
            }
        }

    }
}
