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
            SuspendLayout();
            // 
            // gameStatusLabel
            // 
            gameStatusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gameStatusLabel.AutoSize = true;
            gameStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gameStatusLabel.ForeColor = SystemColors.Highlight;
            gameStatusLabel.Location = new Point(353, 432);
            gameStatusLabel.Name = "gameStatusLabel";
            gameStatusLabel.Size = new Size(97, 20);
            gameStatusLabel.TabIndex = 0;
            gameStatusLabel.Text = "Game status";
            // 
            // gridPanel
            // 
            gridPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gridPanel.Location = new Point(12, 12);
            gridPanel.Name = "gridPanel";
            gridPanel.Size = new Size(776, 391);
            gridPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 479);
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
    }
}