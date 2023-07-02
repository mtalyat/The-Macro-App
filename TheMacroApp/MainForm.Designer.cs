namespace TheMacroApp
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
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.HotKeysGroupBox = new System.Windows.Forms.GroupBox();
            this.HotKeysFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ConfigureButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.HotKeysGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenFolderButton.Location = new System.Drawing.Point(12, 588);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(1279, 29);
            this.OpenFolderButton.TabIndex = 1;
            this.OpenFolderButton.Text = "Open Scripts Folder";
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // HotKeysGroupBox
            // 
            this.HotKeysGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HotKeysGroupBox.Controls.Add(this.HotKeysFlowLayoutPanel);
            this.HotKeysGroupBox.Location = new System.Drawing.Point(12, 12);
            this.HotKeysGroupBox.Name = "HotKeysGroupBox";
            this.HotKeysGroupBox.Size = new System.Drawing.Size(1279, 500);
            this.HotKeysGroupBox.TabIndex = 2;
            this.HotKeysGroupBox.TabStop = false;
            this.HotKeysGroupBox.Text = "Hot Keys";
            // 
            // HotKeysFlowLayoutPanel
            // 
            this.HotKeysFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HotKeysFlowLayoutPanel.AutoScroll = true;
            this.HotKeysFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.HotKeysFlowLayoutPanel.Location = new System.Drawing.Point(6, 26);
            this.HotKeysFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HotKeysFlowLayoutPanel.Name = "HotKeysFlowLayoutPanel";
            this.HotKeysFlowLayoutPanel.Size = new System.Drawing.Size(1267, 468);
            this.HotKeysFlowLayoutPanel.TabIndex = 0;
            this.HotKeysFlowLayoutPanel.WrapContents = false;
            this.HotKeysFlowLayoutPanel.Resize += new System.EventHandler(this.HotKeysFlowLayoutPanel_Resize);
            // 
            // ConfigureButton
            // 
            this.ConfigureButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigureButton.Location = new System.Drawing.Point(12, 518);
            this.ConfigureButton.Name = "ConfigureButton";
            this.ConfigureButton.Size = new System.Drawing.Size(1279, 29);
            this.ConfigureButton.TabIndex = 0;
            this.ConfigureButton.Text = "Configure Script Types";
            this.ConfigureButton.UseVisualStyleBackColor = true;
            this.ConfigureButton.Click += new System.EventHandler(this.ConfigureButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.Location = new System.Drawing.Point(12, 553);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(1279, 29);
            this.SettingsButton.TabIndex = 3;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 629);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.ConfigureButton);
            this.Controls.Add(this.HotKeysGroupBox);
            this.Controls.Add(this.OpenFolderButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Macro App";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.HotKeysGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button OpenFolderButton;
        private GroupBox HotKeysGroupBox;
        private Button ConfigureButton;
        private FlowLayoutPanel HotKeysFlowLayoutPanel;
        private Button SettingsButton;
    }
}