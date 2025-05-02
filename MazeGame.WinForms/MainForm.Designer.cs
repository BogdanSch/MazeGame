namespace MazeGame.WinForms
{
    partial class MainForm
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
            gameStatusLabel = new Label();
            gridPanel = new Panel();
            playerInventoryLabel = new Label();
            timeLeftLabel = new Label();
            SuspendLayout();
            // 
            // gameStatusLabel
            // 
            gameStatusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gameStatusLabel.AutoSize = true;
            gameStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gameStatusLabel.ForeColor = SystemColors.Highlight;
            gameStatusLabel.Location = new Point(691, 432);
            gameStatusLabel.Name = "gameStatusLabel";
            gameStatusLabel.Size = new Size(97, 20);
            gameStatusLabel.TabIndex = 0;
            gameStatusLabel.Text = "Game status";
            // 
            // gridPanel
            // 
            gridPanel.Location = new Point(12, 12);
            gridPanel.Name = "gridPanel";
            gridPanel.Size = new Size(776, 379);
            gridPanel.TabIndex = 1;
            // 
            // playerInventoryLabel
            // 
            playerInventoryLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            playerInventoryLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            playerInventoryLabel.ForeColor = Color.Goldenrod;
            playerInventoryLabel.Location = new Point(12, 411);
            playerInventoryLabel.Name = "playerInventoryLabel";
            playerInventoryLabel.Size = new Size(226, 60);
            playerInventoryLabel.TabIndex = 2;
            playerInventoryLabel.Text = "Player Inventory";
            playerInventoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timeLeftLabel
            // 
            timeLeftLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            timeLeftLabel.AutoSize = true;
            timeLeftLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            timeLeftLabel.ForeColor = Color.Goldenrod;
            timeLeftLabel.Location = new Point(403, 432);
            timeLeftLabel.Name = "timeLeftLabel";
            timeLeftLabel.Size = new Size(50, 20);
            timeLeftLabel.TabIndex = 3;
            timeLeftLabel.Text = "Timer";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 479);
            Controls.Add(timeLeftLabel);
            Controls.Add(playerInventoryLabel);
            Controls.Add(gridPanel);
            Controls.Add(gameStatusLabel);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label gameStatusLabel;
        private Panel gridPanel;
        private Label playerInventoryLabel;
        private Label timeLeftLabel;
    }
}