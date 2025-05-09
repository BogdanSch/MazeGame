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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            gameStatusLabel = new Label();
            playerInventoryLabel = new Label();
            timeLeftLabel = new Label();
            tableLayout = new TableLayoutPanel();
            gridPanel = new Panel();
            tableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // gameStatusLabel
            // 
            gameStatusLabel.Dock = DockStyle.Fill;
            gameStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gameStatusLabel.ForeColor = SystemColors.Highlight;
            gameStatusLabel.Location = new Point(593, 361);
            gameStatusLabel.Name = "gameStatusLabel";
            gameStatusLabel.Size = new Size(292, 110);
            gameStatusLabel.TabIndex = 0;
            gameStatusLabel.Text = "Game status";
            gameStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // playerInventoryLabel
            // 
            playerInventoryLabel.BackColor = Color.Transparent;
            playerInventoryLabel.Dock = DockStyle.Fill;
            playerInventoryLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            playerInventoryLabel.ForeColor = Color.Goldenrod;
            playerInventoryLabel.Location = new Point(3, 361);
            playerInventoryLabel.Name = "playerInventoryLabel";
            playerInventoryLabel.Size = new Size(289, 110);
            playerInventoryLabel.TabIndex = 2;
            playerInventoryLabel.Text = "Player Inventory";
            playerInventoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timeLeftLabel
            // 
            timeLeftLabel.AutoSize = true;
            timeLeftLabel.BackColor = Color.Transparent;
            timeLeftLabel.Dock = DockStyle.Fill;
            timeLeftLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            timeLeftLabel.ForeColor = Color.Goldenrod;
            timeLeftLabel.Location = new Point(298, 361);
            timeLeftLabel.Name = "timeLeftLabel";
            timeLeftLabel.Size = new Size(289, 110);
            timeLeftLabel.TabIndex = 3;
            timeLeftLabel.Text = "Timer";
            timeLeftLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayout
            // 
            tableLayout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayout.ColumnCount = 3;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayout.Controls.Add(gameStatusLabel, 2, 1);
            tableLayout.Controls.Add(timeLeftLabel, 1, 1);
            tableLayout.Controls.Add(playerInventoryLabel, 0, 1);
            tableLayout.Controls.Add(gridPanel, 0, 0);
            tableLayout.Location = new Point(12, 12);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 2;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 76.64543F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 23.3545647F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayout.Size = new Size(888, 471);
            tableLayout.TabIndex = 4;
            // 
            // gridPanel
            // 
            gridPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayout.SetColumnSpan(gridPanel, 3);
            gridPanel.Location = new Point(3, 3);
            gridPanel.Name = "gridPanel";
            gridPanel.Size = new Size(882, 355);
            gridPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 495);
            Controls.Add(tableLayout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "The Maze";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label gameStatusLabel;
        private Label playerInventoryLabel;
        private Label timeLeftLabel;
        private TableLayoutPanel tableLayout;
        private Panel gridPanel;
    }
}