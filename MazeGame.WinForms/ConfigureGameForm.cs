using MazeGame.Logic;
using MazeGame.Models;

namespace MazeGame.WinForms
{
    public partial class ConfigureGameForm : Form
    {
        public int GameDurationSeconds;
        public int RowsCount;
        public int ColsCount;
        public ConfigureGameForm()
        {
            InitializeComponent();
        }

        private void difficultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string comboBoxValue = difficultyComboBox.Text;
            int difficultyIndex = difficultyComboBox.SelectedIndex;

            GameDurationSeconds = Game.DEFAULT_GAME_DURATION;
            RowsCount = Maze.DEFAULT_ROWS_COUNT;
            ColsCount = Maze.DEFAULT_COLS_COUNT;

            switch (difficultyIndex)
            {
                case 0:
                    (RowsCount, ColsCount, GameDurationSeconds) = Game.DifficultyLevels["Easy"].GetGameDifficulty();
                    break;
                case 1:
                    (RowsCount, ColsCount, GameDurationSeconds) = Game.DifficultyLevels["Medium"].GetGameDifficulty();
                    break;
                case 2:
                    (RowsCount, ColsCount, GameDurationSeconds) = Game.DifficultyLevels["Hard"].GetGameDifficulty();
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
