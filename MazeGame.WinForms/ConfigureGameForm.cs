using MazeGame.Logic;
using MazeGame.Models;

namespace MazeGame.WinForms
{
    public partial class ConfigureGameForm : Form
    {
        public GameDifficulty GameDifficulty = Game.DifficultyLevels["Easy"];
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
            int difficultyIndex = difficultyComboBox.SelectedIndex;

            configTableLayout.Visible = false;

            switch (difficultyIndex)
            {
                case 0:
                    GameDifficulty = Game.DifficultyLevels["Easy"];
                    (RowsCount, ColsCount, GameDurationSeconds, InversedControls) = GameDifficulty.GetGameDifficultyProperties();
                    break;
                case 1:
                    GameDifficulty = Game.DifficultyLevels["Medium"];
                    (RowsCount, ColsCount, GameDurationSeconds, InversedControls) = GameDifficulty.GetGameDifficultyProperties();
                    break;
                case 2:
                    GameDifficulty = Game.DifficultyLevels["Difficult"];
                    (RowsCount, ColsCount, GameDurationSeconds, InversedControls) = GameDifficulty.GetGameDifficultyProperties();
                    break;
                case 3:
                    GameDifficulty = Game.DifficultyLevels["Hardcore"];
                    (RowsCount, ColsCount, GameDurationSeconds, InversedControls) = GameDifficulty.GetGameDifficultyProperties();
                    break;
                case 4:
                    configTableLayout.Visible = true;
                    break;
                default:
                    MessageBox.Show("Invalid difficulty level selected.");
                    break;
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (configTableLayout.Visible)
            {
                GameDurationSeconds = Convert.ToInt32(gameDurationNumeric.Value);
                RowsCount = Convert.ToInt32(mazeRowsNumeric.Value);
                ColsCount = Convert.ToInt32(mazeColumnsNumeric.Value);
                InversedControls = inversedModeCheckBox.Checked;
                GameDifficulty = new GameDifficulty(RowsCount, ColsCount, GameDurationSeconds, InversedControls);
            }

            DialogResult = DialogResult.OK;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ConfigureGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.None)
                DialogResult = DialogResult.Cancel;
        }

        private void mazeDimensionNumeric_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown? numericUpDown = sender as NumericUpDown;

            if(numericUpDown == null)
            {
                MessageBox.Show("Invalid numeric up down control.");
                return;
            }

            int value = (int)numericUpDown.Value;
            if(value % 2 == 0) value++;

            numericUpDown.Value = value;
        }
    }
}
