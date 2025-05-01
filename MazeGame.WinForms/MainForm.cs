using MazeGame.Logic;
using MazeGame.Models;
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
                _game = new Game(rowsCount, colsCount, , gameDurationSeconds);
                _game.StartGame();
            }
            else
            {
                MessageBox.Show("Game configuration was not set. Exiting the game.");
                Close();
            }
        }
        public void DisplayInventory(string inventory) 
        {
            playerInventoryLabel.Text = inventory;
        }
        public void DisplayLeftTime(string timeLeft)
        {
            timeLeftLabel.Text = timeLeft;
        }
        private void DisplayGameState(string gameState)
        {
            gameStatusLabel.Text = gameState;
        }
        public void CreateMazeCells(Cell[,] field)
        {
            if (_game == null)
            {
                MessageBox.Show("Game is not initialized.");
                return;
            }

            for (int row = 0; row < ; row++)
            {
                for (int col = 0; col < _game.Maze.ColsCount; col++)
                {
                    Cell cell = _game.Maze[row, col];
                    Label cellLabel = new();
                    cellLabel.Size = new Size(CELL_SIZE, CELL_SIZE);
                    cellLabel.BackColor = Color.White;
                    cellLabel.Text = cell.ToString();
                    cellLabel.TextAlign = ContentAlignment.MiddleCenter;
                    cellLabel.Location = new Point(col * CELL_SIZE, row * CELL_SIZE);
                }
            }
            
        }
        //private static void DisplayGameAction(string message, MessageStyle? style)
        //{
        //    ConsoleColor color = ConsoleColor.Gray;

        //    if (style != null && Enum.TryParse<ConsoleColor>(style.ColorName, ignoreCase: true, out var parsedColor))
        //        color = parsedColor;

        //    Console.ForegroundColor = color;
        //    //MessageBox.Show();
        //    Console.Write(message);
        //}
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
