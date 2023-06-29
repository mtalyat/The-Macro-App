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
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.Location = new System.Drawing.Point(799, 148);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(94, 29);
            this.DoneButton.TabIndex = 0;
            this.DoneButton.Text = "Done";
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
            this.ResetMacroButton.Location = new System.Drawing.Point(124, 112);
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
            this.DiscardButton.Location = new System.Drawing.Point(12, 148);
            this.DiscardButton.Name = "DiscardButton";
            this.DiscardButton.Size = new System.Drawing.Size(94, 29);
            this.DiscardButton.TabIndex = 9;
            this.DiscardButton.Text = "Cancel";
            this.DiscardButton.UseVisualStyleBackColor = true;
            this.DiscardButton.Click += new System.EventHandler(this.DiscardButton_Click);
            // 
            // ConfigureMacroForm
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DiscardButton;
            this.ClientSize = new System.Drawing.Size(905, 189);
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
            this.MinimumSize = new System.Drawing.Size(246, 236);
            this.Name = "ConfigureMacroForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configure Macro";
            this.Load += new System.EventHandler(this.ConfigureMacroForm_Load);
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
    }
}