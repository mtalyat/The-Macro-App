namespace TheMacroApp
{
    partial class ConfigureForm
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
            this.ScriptsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ExtensionsTextBox = new System.Windows.Forms.TextBox();
            this.FormatTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.DoneButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ExecutableTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.OpenFileDialogForExecutableButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ShowTerminalCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ScriptsListBox
            // 
            this.ScriptsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ScriptsListBox.FormattingEnabled = true;
            this.ScriptsListBox.ItemHeight = 20;
            this.ScriptsListBox.Location = new System.Drawing.Point(12, 12);
            this.ScriptsListBox.Name = "ScriptsListBox";
            this.ScriptsListBox.Size = new System.Drawing.Size(189, 204);
            this.ScriptsListBox.TabIndex = 0;
            this.ScriptsListBox.SelectedIndexChanged += new System.EventHandler(this.ScriptsListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Location = new System.Drawing.Point(362, 12);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(804, 27);
            this.NameTextBox.TabIndex = 3;
            this.NameTextBox.Leave += new System.EventHandler(this.NameTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Extensions:";
            // 
            // ExtensionsTextBox
            // 
            this.ExtensionsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExtensionsTextBox.Location = new System.Drawing.Point(362, 45);
            this.ExtensionsTextBox.Name = "ExtensionsTextBox";
            this.ExtensionsTextBox.Size = new System.Drawing.Size(804, 27);
            this.ExtensionsTextBox.TabIndex = 4;
            // 
            // FormatTextBox
            // 
            this.FormatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FormatTextBox.Location = new System.Drawing.Point(362, 151);
            this.FormatTextBox.Name = "FormatTextBox";
            this.FormatTextBox.Size = new System.Drawing.Size(804, 27);
            this.FormatTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Command Format:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(414, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Use {file} for the script file path, and {args} for the arguments.";
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Location = new System.Drawing.Point(12, 228);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(88, 29);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.Location = new System.Drawing.Point(113, 228);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 29);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.Location = new System.Drawing.Point(1072, 228);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(94, 29);
            this.DoneButton.TabIndex = 8;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(362, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(337, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Start extensions with a . and separate with spaces.";
            // 
            // ExecutableTextBox
            // 
            this.ExecutableTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecutableTextBox.Location = new System.Drawing.Point(362, 98);
            this.ExecutableTextBox.Name = "ExecutableTextBox";
            this.ExecutableTextBox.Size = new System.Drawing.Size(771, 27);
            this.ExecutableTextBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Executable:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(362, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(304, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "The executable file path to run, if applicable.";
            // 
            // OpenFileDialogForExecutableButton
            // 
            this.OpenFileDialogForExecutableButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenFileDialogForExecutableButton.Location = new System.Drawing.Point(1139, 98);
            this.OpenFileDialogForExecutableButton.Name = "OpenFileDialogForExecutableButton";
            this.OpenFileDialogForExecutableButton.Size = new System.Drawing.Size(27, 27);
            this.OpenFileDialogForExecutableButton.TabIndex = 6;
            this.OpenFileDialogForExecutableButton.Text = "...";
            this.OpenFileDialogForExecutableButton.UseVisualStyleBackColor = true;
            this.OpenFileDialogForExecutableButton.Click += new System.EventHandler(this.OpenFileDialogForExecutableButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(209, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Show Terminal:";
            // 
            // ShowTerminalCheckBox
            // 
            this.ShowTerminalCheckBox.AutoSize = true;
            this.ShowTerminalCheckBox.Location = new System.Drawing.Point(362, 204);
            this.ShowTerminalCheckBox.Name = "ShowTerminalCheckBox";
            this.ShowTerminalCheckBox.Size = new System.Drawing.Size(18, 17);
            this.ShowTerminalCheckBox.TabIndex = 14;
            this.ShowTerminalCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConfigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DoneButton;
            this.ClientSize = new System.Drawing.Size(1178, 269);
            this.ControlBox = false;
            this.Controls.Add(this.ShowTerminalCheckBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.OpenFileDialogForExecutableButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ExecutableTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FormatTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ExtensionsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScriptsListBox);
            this.MinimumSize = new System.Drawing.Size(760, 226);
            this.Name = "ConfigureForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configure";
            this.Load += new System.EventHandler(this.ConfigureForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox ScriptsListBox;
        private Label label1;
        private TextBox NameTextBox;
        private Label label2;
        private TextBox ExtensionsTextBox;
        private TextBox FormatTextBox;
        private Label label4;
        private Label label3;
        private Button AddButton;
        private Button DeleteButton;
        private Button DoneButton;
        private Label label5;
        private TextBox ExecutableTextBox;
        private Label label6;
        private Label label7;
        private Button OpenFileDialogForExecutableButton;
        private Label label8;
        private CheckBox ShowTerminalCheckBox;
    }
}