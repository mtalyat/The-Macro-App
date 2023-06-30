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
        private static readonly Color COLOR_DEFAULT = Color.FromArgb(255, 255, 255, 255);
        private static readonly Color COLOR_GOOD = Color.FromArgb(255, 240, 255, 240);
        private static readonly Color COLOR_BAD = Color.FromArgb(255, 255, 240, 240);
        private static readonly Color COLOR_EMPTY = Color.FromArgb(255, 220, 220, 220);

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
            UpdateMacroButton(index, data);
        }

        private void UpdateMacroButton(int index, MacroData data)
        {
            // set text
            _macroButtons[index].Text = data.ToString();

            // set button color
            _macroButtons[index].BackColor = GetMacroButtonColor(data);
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

        private void MacroButton_MouseClick(object? sender, MouseEventArgs e)
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

        private void NewMacroButton_MouseClick(object? sender, MouseEventArgs e)
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

        private Button CreateHotKeyButton(string text, Color color, MouseEventHandler handler)
        {
            Button button = new Button()
            {
                Text = text,
                Size = new Size(HotKeysFlowLayoutPanel.Width - 30, 29),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = color
            };
            button.MouseUp += handler;
            return button;
        }

        private Color GetMacroButtonColor(MacroData? macro)
        {
            if(macro == null)
            {
                return COLOR_DEFAULT;
            }

            if (macro.IsEmpty)
            {
                return COLOR_EMPTY;
            }
            else if (macro.IsRegistered)
            {
                return COLOR_GOOD;
            }
            else
            {
                return COLOR_BAD;
            }
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
                MacroData macro = macros[i];
                Color color = GetMacroButtonColor(macro);

                temp = CreateHotKeyButton(macro.ToString(), color, MacroButton_MouseClick);
                _macroButtons[i] = temp;
                HotKeysFlowLayoutPanel.Controls.Add(temp);
            }

            // add one last button for adding new hot keys
            temp = CreateHotKeyButton("New...", COLOR_DEFAULT, NewMacroButton_MouseClick);
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
