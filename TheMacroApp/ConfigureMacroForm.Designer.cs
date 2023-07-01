namespace TheMacroApp
{
    partial class ConfigureMacroForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.TerminalComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OpenFileDialogPathButton = new System.Windows.Forms.Button();
            this.ResetMacroButton = new System.Windows.Forms.Button();
            this.DiscardButton = new System.Windows.Forms.Button();
            this.HotKeyGroupBox = new System.Windows.Forms.GroupBox();
            this.HotKeyErrorLabel = new System.Windows.Forms.Label();
            this.WindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.ShiftCheckBox = new System.Windows.Forms.CheckBox();
            this.CtrlCheckBox = new System.Windows.Forms.CheckBox();
            this.AltCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.KeyComboBox = new System.Windows.Forms.ComboBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.HotKeyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.Location = new System.Drawing.Point(799, 262);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(94, 29);
            this.DoneButton.TabIndex = 0;
            this.DoneButton.Text = "OK";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Arguments:";
            // 
            // ArgumentsTextBox
            // 
            this.ArgumentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArgumentsTextBox.Location = new System.Drawing.Point(124, 45);
            this.ArgumentsTextBox.Name = "ArgumentsTextBox";
            this.ArgumentsTextBox.Size = new System.Drawing.Size(769, 27);
            this.ArgumentsTextBox.TabIndex = 2;
            // 
            // TerminalComboBox
            // 
            this.TerminalComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TerminalComboBox.FormattingEnabled = true;
            this.TerminalComboBox.Location = new System.Drawing.Point(124, 78);
            this.TerminalComboBox.Name = "TerminalComboBox";
            this.TerminalComboBox.Size = new System.Drawing.Size(769, 28);
            this.TerminalComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Terminal:";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathTextBox.Location = new System.Drawing.Point(124, 12);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(736, 27);
            this.PathTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Path:";
            // 
            // OpenFileDialogPathButton
            // 
            this.OpenFileDialogPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenFileDialogPathButton.Location = new System.Drawing.Point(866, 12);
            this.OpenFileDialogPathButton.Name = "OpenFileDialogPathButton";
            this.OpenFileDialogPathButton.Size = new System.Drawing.Size(27, 27);
            this.OpenFileDialogPathButton.TabIndex = 7;
            this.OpenFileDialogPathButton.Text = "...";
            this.OpenFileDialogPathButton.UseVisualStyleBackColor = true;
            this.OpenFileDialogPathButton.Click += new System.EventHandler(this.OpenFileDialogPathButton_Click);
            // 
            // ResetMacroButton
            // 
            this.ResetMacroButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetMacroButton.Location = new System.Drawing.Point(124, 225);
            this.ResetMacroButton.Name = "ResetMacroButton";
            this.ResetMacroButton.Size = new System.Drawing.Size(769, 29);
            this.ResetMacroButton.TabIndex = 8;
            this.ResetMacroButton.Text = "Reset";
            this.ResetMacroButton.UseVisualStyleBackColor = true;
            this.ResetMacroButton.Click += new System.EventHandler(this.ResetMacroButton_Click);
            // 
            // DiscardButton
            // 
            this.DiscardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DiscardButton.Location = new System.Drawing.Point(12, 262);
            this.DiscardButton.Name = "DiscardButton";
            this.DiscardButton.Size = new System.Drawing.Size(94, 29);
            this.DiscardButton.TabIndex = 9;
            this.DiscardButton.Text = "Cancel";
            this.DiscardButton.UseVisualStyleBackColor = true;
            this.DiscardButton.Click += new System.EventHandler(this.DiscardButton_Click);
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
            this.HotKeyGroupBox.Location = new System.Drawing.Point(124, 112);
            this.HotKeyGroupBox.Name = "HotKeyGroupBox";
            this.HotKeyGroupBox.Size = new System.Drawing.Size(769, 107);
            this.HotKeyGroupBox.TabIndex = 10;
            this.HotKeyGroupBox.TabStop = false;
            this.HotKeyGroupBox.Text = "Hot Key";
            // 
            // HotKeyErrorLabel
            // 
            this.HotKeyErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HotKeyErrorLabel.BackColor = System.Drawing.Color.Lime;
            this.HotKeyErrorLabel.Location = new System.Drawing.Point(6, 84);
            this.HotKeyErrorLabel.Name = "HotKeyErrorLabel";
            this.HotKeyErrorLabel.Size = new System.Drawing.Size(757, 20);
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
            this.KeyComboBox.Size = new System.Drawing.Size(660, 28);
            this.KeyComboBox.TabIndex = 0;
            this.KeyComboBox.SelectedIndexChanged += new System.EventHandler(this.OnKeyChange);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(699, 262);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(94, 29);
            this.ApplyButton.TabIndex = 11;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // ConfigureMacroForm
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DiscardButton;
            this.ClientSize = new System.Drawing.Size(905, 303);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.HotKeyGroupBox);
            this.Controls.Add(this.DiscardButton);
            this.Controls.Add(this.ResetMacroButton);
            this.Controls.Add(this.OpenFileDialogPathButton);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TerminalComboBox);
            this.Controls.Add(this.ArgumentsTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DoneButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(246, 350);
            this.Name = "ConfigureMacroForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configure Macro";
            this.Load += new System.EventHandler(this.ConfigureMacroForm_Load);
            this.HotKeyGroupBox.ResumeLayout(false);
            this.HotKeyGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button DoneButton;
        private Label label1;
        private TextBox ArgumentsTextBox;
        private ComboBox TerminalComboBox;
        private Label label2;
        private TextBox PathTextBox;
        private Label label3;
        private Button OpenFileDialogPathButton;
        private Button ResetMacroButton;
        private Button DiscardButton;
        private GroupBox HotKeyGroupBox;
        private Label label4;
        private ComboBox KeyComboBox;
        private CheckBox AltCheckBox;
        private Label label5;
        private CheckBox WindowsCheckBox;
        private CheckBox ShiftCheckBox;
        private CheckBox CtrlCheckBox;
        private Label HotKeyErrorLabel;
        private Button ApplyButton;
    }
}