using MazeGame.Models;
using MazeGame.Models.Units;

namespace MazeGame.WinForms
{
    public partial class GameOverForm : Form
    {
        public int PlayerScore = 0;
        public Player? Player;
        public LeaderboardManager? LeaderboardManager;

        public GameOverForm()
        {
            InitializeComponent();
        }
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private async void GameOverForm_Load(object sender, EventArgs e)
        {
            LblScore.Text = $"Your score is: {PlayerScore} points";

            if (LeaderboardManager != null)
            {
                await LeaderboardManager.FetchBestPlayersScores();
                playerBindingSource.DataSource = LeaderboardManager.BestPlayersScores;
            }
        }
        private void BtnSavePlayerScore_Click(object sender, EventArgs e)
        {
            if(Player == null)
            {
                MessageBox.Show("Error: the player wasn't initialized!");
                Close();
                return;
            }

            string playerName = PlayerNameTextBox.Text.Trim();

            if(string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Please, enter a correct name!");
                return;
            }

            Player.Name = playerName;
            Player.Score = PlayerScore;
            LeaderboardManager?.AddNewPlayerScore(Player);
            LeaderboardManager?.SaveBestPlayersScores();

            playerBindingSource.DataSource = LeaderboardManager?.BestPlayersScores;
            LeaderboardTableLayout.Visible = false;
        }
        private void LeaderboardListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is not Player player) return;
            e.Value = $"{player.Name}\t\t{player.Score} points";
        }
    }
}
