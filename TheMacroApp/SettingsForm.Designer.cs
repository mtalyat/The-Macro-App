namespace TheMacroApp
{
    partial class SettingsForm
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
            this.DoneButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.StartupCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ScriptFolderTextBox = new System.Windows.Forms.TextBox();
            this.ScriptFolderOpenFileDialogButton = new System.Windows.Forms.Button();
            this.HotKeyGroupBox = new System.Windows.Forms.GroupBox();
            this.HotKeyErrorLabel = new System.Windows.Forms.Label();
            this.WindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.ShiftCheckBox = new System.Windows.Forms.CheckBox();
            this.CtrlCheckBox = new System.Windows.Forms.CheckBox();
            this.AltCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.KeyComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ValidColorButton = new System.Windows.Forms.Button();
            this.InvalidColorButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.HotKeyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.Location = new System.Drawing.Point(551, 273);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(94, 29);
            this.DoneButton.TabIndex = 101;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.QuitButton.Location = new System.Drawing.Point(12, 273);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(94, 29);
            this.QuitButton.TabIndex = 100;
            this.QuitButton.Text = "Cancel";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // StartupCheckBox
            // 
            this.StartupCheckBox.AutoSize = true;
            this.StartupCheckBox.Location = new System.Drawing.Point(12, 12);
            this.StartupCheckBox.Name = "StartupCheckBox";
            this.StartupCheckBox.Size = new System.Drawing.Size(167, 24);
            this.StartupCheckBox.TabIndex = 0;
            this.StartupCheckBox.Text = "Add to Startup Apps";
            this.StartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 102;
            this.label1.Text = "Default Script Folder:";
            // 
            // ScriptFolderTextBox
            // 
            this.ScriptFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptFolderTextBox.Location = new System.Drawing.Point(186, 42);
            this.ScriptFolderTextBox.Name = "ScriptFolderTextBox";
            this.ScriptFolderTextBox.Size = new System.Drawing.Size(426, 27);
            this.ScriptFolderTextBox.TabIndex = 103;
            // 
            // ScriptFolderOpenFileDialogButton
            // 
            this.ScriptFolderOpenFileDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptFolderOpenFileDialogButton.Location = new System.Drawing.Point(618, 42);
            this.ScriptFolderOpenFileDialogButton.Name = "ScriptFolderOpenFileDialogButton";
            this.ScriptFolderOpenFileDialogButton.Size = new System.Drawing.Size(27, 27);
            this.ScriptFolderOpenFileDialogButton.TabIndex = 104;
            this.ScriptFolderOpenFileDialogButton.Text = "...";
            this.ScriptFolderOpenFileDialogButton.UseVisualStyleBackColor = true;
            this.ScriptFolderOpenFileDialogButton.Click += new System.EventHandler(this.ScriptFolderOpenFileDialogButton_Click);
            // 
            // HotKeyGroupBox
            // 
            this.HotKeyGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HotKeyGroupBox.Controls.Add(this.HotKeyErrorLabel);
            this.HotKeyGroupBox.Controls.Add(this.WindowsCheckBox);
            this.HotKeyGroupBox.Controls.Add(this.ShiftCheckBox);
            this.HotKeyGroupBox.Controls.Add(this.CtrlCheckBox);
            this.HotKeyGroupBox.Controls.Add(this.AltCheckBox);
            this.HotKeyGroupBox.Controls.Add(this.label5);
            this.HotKeyGroupBox.Controls.Add(this.label4);
            this.HotKeyGroupBox.Controls.Add(this.KeyComboBox);
            this.HotKeyGroupBox.Location = new System.Drawing.Point(12, 145);
            this.HotKeyGroupBox.Name = "HotKeyGroupBox";
            this.HotKeyGroupBox.Size = new System.Drawing.Size(633, 121);
            this.HotKeyGroupBox.TabIndex = 105;
            this.HotKeyGroupBox.TabStop = false;
            this.HotKeyGroupBox.Text = "Application Hot Key";
            // 
            // HotKeyErrorLabel
            // 
            this.HotKeyErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HotKeyErrorLabel.BackColor = System.Drawing.Color.Lime;
            this.HotKeyErrorLabel.Location = new System.Drawing.Point(6, 88);
            this.HotKeyErrorLabel.Name = "HotKeyErrorLabel";
            this.HotKeyErrorLabel.Size = new System.Drawing.Size(615, 20);
            this.HotKeyErrorLabel.TabIndex = 7;
            this.HotKeyErrorLabel.Text = "Hot Key is VALID.";
            this.HotKeyErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WindowsCheckBox
            // 
            this.WindowsCheckBox.AutoSize = true;
            this.WindowsCheckBox.Location = new System.Drawing.Point(286, 60);
            this.WindowsCheckBox.Name = "WindowsCheckBox";
            this.WindowsCheckBox.Size = new System.Drawing.Size(92, 24);
            this.WindowsCheckBox.TabIndex = 6;
            this.WindowsCheckBox.Text = "Windows";
            this.WindowsCheckBox.UseVisualStyleBackColor = true;
            this.WindowsCheckBox.CheckedChanged += new System.EventHandler(this.OnKeyChange);
            // 
            // ShiftCheckBox
            // 
            this.ShiftCheckBox.AutoSize = true;
            this.ShiftCheckBox.Location = new System.Drawing.Point(219, 60);
            this.ShiftCheckBox.Name = "ShiftCheckBox";
            this.ShiftCheckBox.Size = new System.Drawing.Size(61, 24);
            this.ShiftCheckBox.TabIndex = 5;
            this.ShiftCheckBox.Text = "Shift";
            this.ShiftCheckBox.UseVisualStyleBackColor = true;
            this.ShiftCheckBox.CheckedChanged += new System.EventHandler(this.OnKeyChange);
            // 
            // CtrlCheckBox
            // 
            this.CtrlCheckBox.AutoSize = true;
            this.CtrlCheckBox.Location = new System.Drawing.Point(159, 60);
            this.CtrlCheckBox.Name = "CtrlCheckBox";
            this.CtrlCheckBox.Size = new System.Drawing.Size(54, 24);
            this.CtrlCheckBox.TabIndex = 4;
            this.CtrlCheckBox.Text = "Ctrl";
            this.CtrlCheckBox.UseVisualStyleBackColor = true;
            this.CtrlCheckBox.CheckedChanged += new System.EventHandler(this.OnKeyChange);
            // 
            // AltCheckBox
            // 
            this.AltCheckBox.AutoSize = true;
            this.AltCheckBox.Location = new System.Drawing.Point(103, 60);
            this.AltCheckBox.Name = "AltCheckBox";
            this.AltCheckBox.Size = new System.Drawing.Size(50, 24);
            this.AltCheckBox.TabIndex = 3;
            this.AltCheckBox.Text = "Alt";
            this.AltCheckBox.UseVisualStyleBackColor = true;
            this.AltCheckBox.CheckedChanged += new System.EventHandler(this.OnKeyChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Modifiers:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Key:";
            // 
            // KeyComboBox
            // 
            this.KeyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyComboBox.FormattingEnabled = true;
            this.KeyComboBox.Location = new System.Drawing.Point(103, 26);
            this.KeyComboBox.Name = "KeyComboBox";
            this.KeyComboBox.Size = new System.Drawing.Size(518, 28);
            this.KeyComboBox.TabIndex = 0;
            this.KeyComboBox.SelectedValueChanged += new System.EventHandler(this.OnKeyChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 106;
            this.label2.Text = "VALID key color:";
            // 
            // ValidColorButton
            // 
            this.ValidColorButton.Location = new System.Drawing.Point(186, 75);
            this.ValidColorButton.Name = "ValidColorButton";
            this.ValidColorButton.Size = new System.Drawing.Size(459, 29);
            this.ValidColorButton.TabIndex = 107;
            this.ValidColorButton.UseVisualStyleBackColor = true;
            this.ValidColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // InvalidColorButton
            // 
            this.InvalidColorButton.Location = new System.Drawing.Point(186, 110);
            this.InvalidColorButton.Name = "InvalidColorButton";
            this.InvalidColorButton.Size = new System.Drawing.Size(459, 29);
            this.InvalidColorButton.TabIndex = 109;
            this.InvalidColorButton.UseVisualStyleBackColor = true;
            this.InvalidColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 108;
            this.label3.Text = "INVALID key color:";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.QuitButton;
            this.ClientSize = new System.Drawing.Size(657, 314);
            this.Controls.Add(this.InvalidColorButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ValidColorButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HotKeyGroupBox);
            this.Controls.Add(this.ScriptFolderOpenFileDialogButton);
            this.Controls.Add(this.ScriptFolderTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartupCheckBox);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.DoneButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.HotKeyGroupBox.ResumeLayout(false);
            this.HotKeyGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button DoneButton;
        private Button QuitButton;
        private CheckBox StartupCheckBox;
        private Label label1;
        private TextBox ScriptFolderTextBox;
        private Button ScriptFolderOpenFileDialogButton;
        private GroupBox HotKeyGroupBox;
        private Label HotKeyErrorLabel;
        private CheckBox WindowsCheckBox;
        private CheckBox ShiftCheckBox;
        private CheckBox CtrlCheckBox;
        private CheckBox AltCheckBox;
        private Label label5;
        private Label label4;
        private ComboBox KeyComboBox;
        private Label label2;
        private Button ValidColorButton;
        private Button InvalidColorButton;
        private Label label3;
    }
}