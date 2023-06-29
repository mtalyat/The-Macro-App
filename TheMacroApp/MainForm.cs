using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheMacroApp
{
    public partial class MainForm : Form
    {
        private Button[] _macroButtons;

        private ConfigureScriptsForm? _configureForm;

        public MainForm()
        {
            // initialize everything else
            InitializeComponent();

            // initialize self
            Text = TheMacroApplicationContext.APP_NAME;

            // collect buttons for later use
            _macroButtons = new Button[0];
        }

        // when main form loads
        private void MainForm_Load(object sender, EventArgs e)
        {
            // ensure folder exists
            if (!Directory.Exists(AppData.FOLDER_PATH))
            {
                Directory.CreateDirectory(AppData.FOLDER_PATH);
            }

            // load buttons
            UpdateHotKeys();
        }

        // after form has closed
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Manager.Save();
        }

        private void SetMacro(int index, MacroData data)
        {
            // set in manager
            Manager.Data.SetMacro(index, data);

            Manager.Save();

            // set button display
            SetMacroButtonText(index, data.ToString());
        }

        private void SetMacroButtonText(int index, string text)
        {
            _macroButtons[index].Text = text;
        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            using (Process process = new Process())
            {
                process.StartInfo = new ProcessStartInfo("explorer.exe", AppData.FOLDER_PATH);
                process.Start();
            }
        }

        private void EditMacro(int index)
        {
            // get existing macro, or create a new one
            MacroData? macroData = Manager.Data.GetMacro(index) ?? new MacroData();

            ConfigureMacroForm cmf = new ConfigureMacroForm(macroData);

            if(cmf.ShowDialog() == DialogResult.OK)
            {
                // macro values have been set
                SetMacro(index, macroData);
            }
        }

        private void DeleteMacro(int index)
        {
            // unregister macro, if it is
            MacroData? data = Manager.Data.GetMacro(index);

            if(data == null)
            {
                return;
            }

            data.Key.UnRegister();

            // delete in mananger
            Manager.Data.DeleteMacro(index);

            // save updates
            Manager.Save();

            // update buttons
            UpdateHotKeys();
        }

        private void MacroButton_MouseClick(object sender, MouseEventArgs e)
        {
            // get index of macro by using index of button
            int index = Array.IndexOf(_macroButtons, (Button)sender);

            switch (e.Button)
            {
                case MouseButtons.Left:
                    EditMacro(index); break;
                case MouseButtons.Right:
                    DeleteMacro(index); break;
            }
        }

        private void NewMacroButton_MouseClick(object sender, MouseEventArgs e)
        {
            // create new macro and add it
            Manager.Data.AddMacro(new MacroData());

            // refresh list
            UpdateHotKeys();

            // edit new macro
            EditMacro(Manager.Data.Macros.Count - 1);
        }

        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            if(_configureForm == null)
            {
                _configureForm = new ConfigureScriptsForm();
                _configureForm.Show();
                _configureForm.FormClosed += (object? sender, FormClosedEventArgs e) => { _configureForm = null; };
            }
            else
            {
                _configureForm.Activate();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // close form on escape
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private Button CreateHotKeyButton(string text, MouseEventHandler handler)
        {
            Button button = new Button()
            {
                Text = text,
                Size = new Size(HotKeysFlowLayoutPanel.Width - 30, 29),
                TextAlign = ContentAlignment.MiddleLeft,
            };
            button.MouseUp += handler;
            return button;
        }

        private void UpdateHotKeys()
        {
            // get macro keys
            MacroData[] macros = Manager.Data.Macros.ToArray();

            // get scroll
            int scroll = HotKeysFlowLayoutPanel.VerticalScroll.Value;

            // remove old buttons
            HotKeysFlowLayoutPanel.Controls.Clear();
            _macroButtons = new Button[macros.Length];

            Button temp;

            // create new buttons for each macro data
            for (int i = 0; i < macros.Length; i++)
            {
                temp = CreateHotKeyButton(macros[i].ToString(), MacroButton_MouseClick);
                _macroButtons[i] = temp;
                HotKeysFlowLayoutPanel.Controls.Add(temp);
            }

            // add one last button for adding new hot keys
            temp = CreateHotKeyButton("New...", NewMacroButton_MouseClick);
            HotKeysFlowLayoutPanel.Controls.Add(temp);

            // reassign scroll
            HotKeysFlowLayoutPanel.VerticalScroll.Value = scroll;
        }

        private void HotKeysFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            // resize all widths
            foreach(Control control in HotKeysFlowLayoutPanel.Controls)
            {
                control.Size = new Size(HotKeysFlowLayoutPanel.Width - 30, control.Size.Height);
            }
        }
    }
}
