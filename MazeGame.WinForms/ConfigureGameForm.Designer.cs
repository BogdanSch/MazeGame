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
            gameDurationNumeric = new NumericUpDown();
            lblDuration = new Label();
            configTableLayout = new TableLayoutPanel();
            lblInversedControls = new Label();
            mazeColumnsNumeric = new NumericUpDown();
            lblColumns = new Label();
            mazeRowsNumeric = new NumericUpDown();
            lblRows = new Label();
            inversedModeCheckBox = new CheckBox();
            LblHint = new Label();
            ((System.ComponentModel.ISupportInitialize)gameDurationNumeric).BeginInit();
            configTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mazeColumnsNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mazeRowsNumeric).BeginInit();
            SuspendLayout();
            // 
            // difficultyLabel
            // 
            difficultyLabel.AutoSize = true;
            difficultyLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            difficultyLabel.Location = new Point(172, 169);
            difficultyLabel.Name = "difficultyLabel";
            difficultyLabel.Size = new Size(167, 23);
            difficultyLabel.TabIndex = 0;
            difficultyLabel.Text = "Select difficulty level";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(90, 25);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(328, 41);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Welcome to The Maze";
            // 
            // difficultyComboBox
            // 
            difficultyComboBox.DropDownHeight = 200;
            difficultyComboBox.FormattingEnabled = true;
            difficultyComboBox.IntegralHeight = false;
            difficultyComboBox.Items.AddRange(new object[] { "Easy  ->  Duration: 90s | Maze: 11x11", "Medium  ->  Duration: 70s  | Maze: 15x15", "Difficult  ->  Duration: 60s  | Maze: 19x27", "Hardcore ->  Duration: 65s  | Maze: 21x29", "Custom  ->  Choose your own settings" });
            difficultyComboBox.Location = new Point(106, 195);
            difficultyComboBox.Name = "difficultyComboBox";
            difficultyComboBox.Size = new Size(292, 28);
            difficultyComboBox.TabIndex = 2;
            difficultyComboBox.SelectedIndexChanged += difficultyComboBox_SelectedIndexChanged;
            // 
            // startBtn
            // 
            startBtn.DialogResult = DialogResult.OK;
            startBtn.Location = new Point(161, 428);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(94, 29);
            startBtn.TabIndex = 3;
            startBtn.Text = "Play";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // exitBtn
            // 
            exitBtn.DialogResult = DialogResult.Cancel;
            exitBtn.Location = new Point(261, 428);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(94, 29);
            exitBtn.TabIndex = 4;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // gameDurationNumeric
            // 
            gameDurationNumeric.Dock = DockStyle.Fill;
            gameDurationNumeric.Location = new Point(167, 3);
            gameDurationNumeric.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            gameDurationNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            gameDurationNumeric.Name = "gameDurationNumeric";
            gameDurationNumeric.Size = new Size(159, 27);
            gameDurationNumeric.TabIndex = 5;
            gameDurationNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Dock = DockStyle.Fill;
            lblDuration.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDuration.Location = new Point(3, 0);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(158, 41);
            lblDuration.TabIndex = 6;
            lblDuration.Text = "Game duration in seconds";
            // 
            // configTableLayout
            // 
            configTableLayout.ColumnCount = 2;
            configTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            configTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            configTableLayout.Controls.Add(lblInversedControls, 0, 3);
            configTableLayout.Controls.Add(mazeColumnsNumeric, 1, 2);
            configTableLayout.Controls.Add(lblColumns, 0, 2);
            configTableLayout.Controls.Add(mazeRowsNumeric, 1, 1);
            configTableLayout.Controls.Add(lblRows, 0, 1);
            configTableLayout.Controls.Add(lblDuration, 0, 0);
            configTableLayout.Controls.Add(gameDurationNumeric, 1, 0);
            configTableLayout.Controls.Add(inversedModeCheckBox, 1, 3);
            configTableLayout.Location = new Point(90, 238);
            configTableLayout.Name = "configTableLayout";
            configTableLayout.RowCount = 4;
            configTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            configTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            configTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            configTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            configTableLayout.Size = new Size(329, 166);
            configTableLayout.TabIndex = 7;
            configTableLayout.Visible = false;
            // 
            // lblInversedControls
            // 
            lblInversedControls.AutoSize = true;
            lblInversedControls.Dock = DockStyle.Fill;
            lblInversedControls.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblInversedControls.Location = new Point(3, 123);
            lblInversedControls.Name = "lblInversedControls";
            lblInversedControls.Size = new Size(158, 43);
            lblInversedControls.TabIndex = 11;
            lblInversedControls.Text = "Turn on Inversed controls";
            // 
            // mazeColumnsNumeric
            // 
            mazeColumnsNumeric.Dock = DockStyle.Fill;
            mazeColumnsNumeric.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            mazeColumnsNumeric.Location = new Point(167, 85);
            mazeColumnsNumeric.Maximum = new decimal(new int[] { 55, 0, 0, 0 });
            mazeColumnsNumeric.Minimum = new decimal(new int[] { 11, 0, 0, 0 });
            mazeColumnsNumeric.Name = "mazeColumnsNumeric";
            mazeColumnsNumeric.Size = new Size(159, 27);
            mazeColumnsNumeric.TabIndex = 10;
            mazeColumnsNumeric.Value = new decimal(new int[] { 11, 0, 0, 0 });
            mazeColumnsNumeric.ValueChanged += mazeDimensionNumeric_ValueChanged;
            // 
            // lblColumns
            // 
            lblColumns.AutoSize = true;
            lblColumns.Dock = DockStyle.Fill;
            lblColumns.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblColumns.Location = new Point(3, 82);
            lblColumns.Name = "lblColumns";
            lblColumns.Size = new Size(158, 41);
            lblColumns.TabIndex = 9;
            lblColumns.Text = "Maze columns (Odd number)";
            // 
            // mazeRowsNumeric
            // 
            mazeRowsNumeric.Dock = DockStyle.Fill;
            mazeRowsNumeric.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            mazeRowsNumeric.Location = new Point(167, 44);
            mazeRowsNumeric.Maximum = new decimal(new int[] { 119, 0, 0, 0 });
            mazeRowsNumeric.Minimum = new decimal(new int[] { 11, 0, 0, 0 });
            mazeRowsNumeric.Name = "mazeRowsNumeric";
            mazeRowsNumeric.Size = new Size(159, 27);
            mazeRowsNumeric.TabIndex = 8;
            mazeRowsNumeric.Value = new decimal(new int[] { 11, 0, 0, 0 });
            mazeRowsNumeric.ValueChanged += mazeDimensionNumeric_ValueChanged;
            // 
            // lblRows
            // 
            lblRows.AutoSize = true;
            lblRows.Dock = DockStyle.Fill;
            lblRows.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblRows.Location = new Point(3, 41);
            lblRows.Name = "lblRows";
            lblRows.Size = new Size(158, 41);
            lblRows.TabIndex = 7;
            lblRows.Text = "Maze rows (Odd number)";
            // 
            // inversedModeCheckBox
            // 
            inversedModeCheckBox.AutoSize = true;
            inversedModeCheckBox.Dock = DockStyle.Fill;
            inversedModeCheckBox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            inversedModeCheckBox.Location = new Point(167, 126);
            inversedModeCheckBox.Name = "inversedModeCheckBox";
            inversedModeCheckBox.Size = new Size(159, 37);
            inversedModeCheckBox.TabIndex = 12;
            inversedModeCheckBox.Text = "Inversed mode";
            inversedModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // LblHint
            // 
            LblHint.Location = new Point(50, 66);
            LblHint.Name = "LblHint";
            LblHint.Size = new Size(402, 66);
            LblHint.TabIndex = 8;
            LblHint.Text = "Navigate through the maze. Collect treasures. Avoid traps. Controls: Arrow Keys  or  W A S D. To use a tool press X. Compete with other players. Press Start to begin your adventure!";
            LblHint.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ConfigureGameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 513);
            Controls.Add(LblHint);
            Controls.Add(configTableLayout);
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
            ((System.ComponentModel.ISupportInitialize)gameDurationNumeric).EndInit();
            configTableLayout.ResumeLayout(false);
            configTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mazeColumnsNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)mazeRowsNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label difficultyLabel;
        private Label titleLabel;
        private ComboBox difficultyComboBox;
        private Button startBtn;
        private Button exitBtn;
        private NumericUpDown gameDurationNumeric;
        private Label lblDuration;
        private TableLayoutPanel configTableLayout;
        private Label lblRows;
        private NumericUpDown mazeRowsNumeric;
        private Label lblColumns;
        private NumericUpDown mazeColumnsNumeric;
        private Label lblInversedControls;
        private CheckBox inversedModeCheckBox;
        private Label LblHint;
    }
}