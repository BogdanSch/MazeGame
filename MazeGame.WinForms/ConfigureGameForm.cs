using MazeGame.Logic;
using MazeGame.Models;

namespace MazeGame.WinForms
{
    public partial class ConfigureGameForm : Form
    {
        public int GameDurationSeconds = Game.DEFAULT_GAME_DURATION;
        public int RowsCount = Maze.DEFAULT_ROWS_COUNT;
        public int ColsCount = Maze.DEFAULT_COLS_COUNT;
        public bool InversedControls = false;

        public ConfigureGameForm()
        {
            InitializeComponent();
        }

        private void difficultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string comboBoxValue = difficultyComboBox.Text;
            int difficultyIndex = difficultyComboBox.SelectedIndex;

            switch (difficultyIndex)
            {
                case 0:
                    (RowsCount, ColsCount, GameDurationSeconds, InversedControls) = Game.DifficultyLevels["Easy"].GetGameDifficulty();
                    break;
                case 1:
                    (RowsCount, ColsCount, GameDurationSeconds, InversedControls) = Game.DifficultyLevels["Medium"].GetGameDifficulty();
                    break;
                case 2:
                    (RowsCount, ColsCount, GameDurationSeconds, InversedControls) = Game.DifficultyLevels["Difficult"].GetGameDifficulty();
                    break;
                case 3:
                    (RowsCount, ColsCount, GameDurationSeconds, InversedControls) = Game.DifficultyLevels["Hardcore"].GetGameDifficulty();
                    break;
                case 4:
                    break;
                default:
                    MessageBox.Show("Invalid difficulty level selected.");
                    break;
            }
            //MessageBox.Show(comboBoxValue);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ConfigureGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.None)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
