namespace MazeGame.WinForms
{
    partial class ConfigureGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureGameForm));
            difficultyLabel = new Label();
            titleLabel = new Label();
            difficultyComboBox = new ComboBox();
            startBtn = new Button();
            exitBtn = new Button();
            SuspendLayout();
            // 
            // difficultyLabel
            // 
            difficultyLabel.AutoSize = true;
            difficultyLabel.Location = new Point(172, 160);
            difficultyLabel.Name = "difficultyLabel";
            difficultyLabel.Size = new Size(146, 20);
            difficultyLabel.TabIndex = 0;
            difficultyLabel.Text = "Select difficulty level";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(161, 39);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(157, 20);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Welcome to The Maze";
            // 
            // difficultyComboBox
            // 
            difficultyComboBox.DropDownHeight = 200;
            difficultyComboBox.FormattingEnabled = true;
            difficultyComboBox.IntegralHeight = false;
            difficultyComboBox.Items.AddRange(new object[] { "Easy  ->  Duration: 90s | Maze: 11x11", "Medium  ->  Duration: 70s  | Maze: 15x15", "Hard  ->  Duration: 60s  | Maze: 19x27", "Custom  ->  Choose your own settings" });
            difficultyComboBox.Location = new Point(106, 195);
            difficultyComboBox.Name = "difficultyComboBox";
            difficultyComboBox.Size = new Size(292, 28);
            difficultyComboBox.TabIndex = 2;
            difficultyComboBox.SelectedIndexChanged += difficultyComboBox_SelectedIndexChanged;
            // 
            // startBtn
            // 
            startBtn.DialogResult = DialogResult.OK;
            startBtn.Location = new Point(161, 340);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(94, 29);
            startBtn.TabIndex = 3;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // exitBtn
            // 
            exitBtn.DialogResult = DialogResult.Cancel;
            exitBtn.Location = new Point(261, 340);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(94, 29);
            exitBtn.TabIndex = 4;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // ConfigureGameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 513);
            Controls.Add(exitBtn);
            Controls.Add(startBtn);
            Controls.Add(difficultyComboBox);
            Controls.Add(titleLabel);
            Controls.Add(difficultyLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(520, 560);
            MinimumSize = new Size(520, 560);
            Name = "ConfigureGameForm";
            Text = "The Maze Configuration";
            FormClosing += ConfigureGameForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label difficultyLabel;
        private Label titleLabel;
        private ComboBox difficultyComboBox;
        private Button startBtn;
        private Button exitBtn;
    }
}