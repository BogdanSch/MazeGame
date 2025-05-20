
namespace MazeGame.WinForms
{
    partial class GameOverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverForm));
            LblTitle = new Label();
            LblTryAgain = new Label();
            BtnPlay = new Button();
            BtnExit = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            LblScore = new Label();
            PlayerNameTextBox = new TextBox();
            BtnSavePlayerScore = new Button();
            LeaderboardTableLayout = new TableLayoutPanel();
            LblSaveResult = new Label();
            LeaderboardList = new ListBox();
            playerBindingSource = new BindingSource(components);
            tableLayoutPanel1.SuspendLayout();
            LeaderboardTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource).BeginInit();
            SuspendLayout();
            // 
            // LblTitle
            // 
            LblTitle.AutoSize = true;
            LblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblTitle.Location = new Point(138, 9);
            LblTitle.Name = "LblTitle";
            LblTitle.Size = new Size(272, 41);
            LblTitle.TabIndex = 0;
            LblTitle.Text = "Game Over, Dude!";
            // 
            // LblTryAgain
            // 
            LblTryAgain.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(LblTryAgain, 2);
            LblTryAgain.Dock = DockStyle.Fill;
            LblTryAgain.Location = new Point(3, 0);
            LblTryAgain.Name = "LblTryAgain";
            LblTryAgain.Size = new Size(244, 48);
            LblTryAgain.TabIndex = 1;
            LblTryAgain.Text = "Would you like to try again?";
            LblTryAgain.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnPlay
            // 
            BtnPlay.Dock = DockStyle.Fill;
            BtnPlay.Location = new Point(3, 51);
            BtnPlay.Name = "BtnPlay";
            BtnPlay.Size = new Size(119, 31);
            BtnPlay.TabIndex = 2;
            BtnPlay.Text = "Play";
            BtnPlay.UseVisualStyleBackColor = true;
            BtnPlay.Click += BtnPlay_Click;
            // 
            // BtnExit
            // 
            BtnExit.Dock = DockStyle.Fill;
            BtnExit.Location = new Point(128, 51);
            BtnExit.Name = "BtnExit";
            BtnExit.RightToLeft = RightToLeft.No;
            BtnExit.Size = new Size(119, 31);
            BtnExit.TabIndex = 3;
            BtnExit.Text = "Exit";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(BtnPlay, 0, 1);
            tableLayoutPanel1.Controls.Add(LblTryAgain, 0, 0);
            tableLayoutPanel1.Controls.Add(BtnExit, 1, 1);
            tableLayoutPanel1.Location = new Point(147, 408);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 56.47059F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43.52941F));
            tableLayoutPanel1.Size = new Size(250, 85);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // LblScore
            // 
            LblScore.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblScore.Location = new Point(103, 50);
            LblScore.Name = "LblScore";
            LblScore.Size = new Size(349, 61);
            LblScore.TabIndex = 5;
            LblScore.Text = "Your score is: 0 points";
            LblScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PlayerNameTextBox
            // 
            PlayerNameTextBox.Dock = DockStyle.Fill;
            PlayerNameTextBox.Location = new Point(3, 51);
            PlayerNameTextBox.Name = "PlayerNameTextBox";
            PlayerNameTextBox.PlaceholderText = "Enter player's name";
            PlayerNameTextBox.Size = new Size(144, 27);
            PlayerNameTextBox.TabIndex = 6;
            // 
            // BtnSavePlayerScore
            // 
            BtnSavePlayerScore.Location = new Point(153, 51);
            BtnSavePlayerScore.Name = "BtnSavePlayerScore";
            BtnSavePlayerScore.Size = new Size(94, 29);
            BtnSavePlayerScore.TabIndex = 7;
            BtnSavePlayerScore.Text = "Save";
            BtnSavePlayerScore.UseVisualStyleBackColor = true;
            BtnSavePlayerScore.Click += BtnSavePlayerScore_Click;
            // 
            // LeaderboardTableLayout
            // 
            LeaderboardTableLayout.ColumnCount = 2;
            LeaderboardTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            LeaderboardTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            LeaderboardTableLayout.Controls.Add(LblSaveResult, 0, 0);
            LeaderboardTableLayout.Controls.Add(BtnSavePlayerScore, 1, 1);
            LeaderboardTableLayout.Controls.Add(PlayerNameTextBox, 0, 1);
            LeaderboardTableLayout.Location = new Point(144, 127);
            LeaderboardTableLayout.Name = "LeaderboardTableLayout";
            LeaderboardTableLayout.RowCount = 2;
            LeaderboardTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 56.47059F));
            LeaderboardTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 43.52941F));
            LeaderboardTableLayout.Size = new Size(250, 85);
            LeaderboardTableLayout.TabIndex = 8;
            // 
            // LblSaveResult
            // 
            LblSaveResult.AutoSize = true;
            LeaderboardTableLayout.SetColumnSpan(LblSaveResult, 2);
            LblSaveResult.Dock = DockStyle.Fill;
            LblSaveResult.Location = new Point(3, 0);
            LblSaveResult.Name = "LblSaveResult";
            LblSaveResult.Size = new Size(244, 48);
            LblSaveResult.TabIndex = 1;
            LblSaveResult.Text = "Would you like to save your result?";
            LblSaveResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LeaderboardList
            // 
            LeaderboardList.DataSource = playerBindingSource;
            LeaderboardList.DisplayMember = "Name";
            LeaderboardList.FormattingEnabled = true;
            LeaderboardList.Location = new Point(103, 228);
            LeaderboardList.Name = "LeaderboardList";
            LeaderboardList.Size = new Size(349, 164);
            LeaderboardList.TabIndex = 9;
            LeaderboardList.Format += LeaderboardListBox_Format;
            // 
            // playerBindingSource
            // 
            playerBindingSource.DataSource = typeof(Models.Units.Player);
            // 
            // GameOverForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 505);
            Controls.Add(LeaderboardList);
            Controls.Add(LeaderboardTableLayout);
            Controls.Add(LblScore);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(LblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "GameOverForm";
            Text = "Game Over";
            Load += GameOverForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            LeaderboardTableLayout.ResumeLayout(false);
            LeaderboardTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblTitle;
        private Label LblTryAgain;
        private Button BtnPlay;
        private Button BtnExit;
        private TableLayoutPanel tableLayoutPanel1;
        private Label LblScore;
        private TextBox PlayerNameTextBox;
        private Button BtnSavePlayerScore;
        private TableLayoutPanel LeaderboardTableLayout;
        private Label LblSaveResult;
        private ListBox LeaderboardList;
        private BindingSource playerBindingSource;
    }
}