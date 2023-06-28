using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheMacroApp
{
    public partial class ConfigureForm : Form
    {
        private ScriptData? _selected;

        public ConfigureForm()
        {
            InitializeComponent();
        }

        private void RefreshScriptsListBox()
        {
            // get selected index
            int index = ScriptsListBox.SelectedIndex;

            // load new data
            ScriptsListBox.DataSource = null;
            ScriptsListBox.DataSource = Manager.Data.GetScripts();

            // keep index if possible
            ScriptsListBox.SelectedIndex = Math.Min(index, ScriptsListBox.Items.Count - 1);
            _selected = ScriptsListBox.SelectedItem as ScriptData;
        }

        private void UpdateSelected()
        {
            if(_selected!= null)
            {
                // try to rename, and refresh list if did
                if(Manager.Data.RenameScript(_selected.Name, NameTextBox.Text))
                {
                    RefreshScriptsListBox();
                }

                // set other data
                _selected.SetExtensions(ExtensionsTextBox.Text);
                _selected.ExecutablePath = ExecutableTextBox.Text;
                _selected.Format = FormatTextBox.Text;
                _selected.ShowTerminal = ShowTerminalCheckBox.Checked;

                // set to manager
                Manager.Data.SetScript(_selected, false);
            }
        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            // load all scripts
            RefreshScriptsListBox();

            // set selected to first in list
            ScriptsListBox.SelectedIndex = Math.Min(0, ScriptsListBox.Items.Count - 1);
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            // update selected data, save it, then close
            UpdateSelected();
            Manager.Save();
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // add new script data
            Manager.Data.SetScript(new ScriptData("New Script Type"));

            // refresh so we can see it
            RefreshScriptsListBox();

            // select it
            ScriptsListBox.SelectedIndex = ScriptsListBox.Items.Count - 1;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(_selected == null)
            {
                return;
            }

            // delete selected
            Manager.Data.DeleteScript(_selected?.Name ?? "");

            // update display
            RefreshScriptsListBox();
        }

        private void ScriptsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update old data if able
            UpdateSelected();

            // load new data into boxes, or empty data if nothing selected
            _selected = ScriptsListBox.SelectedItem as ScriptData;

            bool isNotNull = _selected != null;

            // enable if there is something selected
            NameTextBox.Enabled = isNotNull;
            ExtensionsTextBox.Enabled = isNotNull;
            ExecutableTextBox.Enabled = isNotNull;
            FormatTextBox.Enabled = isNotNull;
            ShowTerminalCheckBox.Enabled = isNotNull;

            if(_selected == null)
            {
                NameTextBox.Text = string.Empty;
                ExecutableTextBox.Text = string.Empty;
                ExtensionsTextBox.Text = string.Empty;
                FormatTextBox.Text = string.Empty;
                ShowTerminalCheckBox.Checked = false;
            }
            else
            {
                // only change name box if needed
                if(NameTextBox.Text.CompareTo(_selected.Name) != 0)
                {
                    NameTextBox.Text = _selected.Name;
                }
                ExtensionsTextBox.Text = _selected.GetExtensions();
                ExecutableTextBox.Text = _selected.ExecutablePath;
                FormatTextBox.Text = _selected.Format;
                ShowTerminalCheckBox.Checked = _selected.ShowTerminal;
            }
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            UpdateSelected();
        }

        private void OpenFileDialogForExecutableButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Select a program to run for this type of script.",
                RestoreDirectory = true,
                InitialDirectory = "C:/",
                Filter = "Executable (*.exe)|*.exe|All Files (*.*)|*.*"
            };

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                // found file, set it
                ExecutableTextBox.Text = ofd.FileName;
            }
        }
    }
}
