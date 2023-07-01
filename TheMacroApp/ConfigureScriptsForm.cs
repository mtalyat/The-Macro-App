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
    /// <summary>
    /// The form for configuring the script data types.
    /// This allows the user to customize how the macro is ran per the file type,
    /// so that when they select a new macro, it is easier to setup.
    /// </summary>
    public partial class ConfigureScriptsForm : Form
    {
        /// <summary>
        /// The script data to configure.
        /// </summary>
        private ScriptData? _selected;

        public ConfigureScriptsForm()
        {
            InitializeComponent();
        }

        #region View

        /// <summary>
        /// Refreshes the list box of script datas.
        /// </summary>
        private void RefreshScriptsListBox()
        {
            // get selected index
            int index = ScriptsListBox.SelectedIndex;

            // load scripts
            ScriptsListBox.DataSource = null;
            ScriptsListBox.DataSource = Manager.Data.GetScripts();

            // keep index if possible
            ScriptsListBox.SelectedIndex = Math.Min(index, ScriptsListBox.Items.Count - 1);
            _selected = ScriptsListBox.SelectedItem as ScriptData;
        }

        /// <summary>
        /// Updates the currently selected script data with the values from the inputs.
        /// </summary>
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

                // set to manager
                Manager.Data.SetScript(_selected, false);
            }
        }

        /// <summary>
        /// Updates the form components with the values from the selected script data.
        /// </summary>
        private void UpdateFormComponents()
        {
            bool isNotNull = _selected != null;

            // enable if there is something selected
            NameTextBox.Enabled = isNotNull;
            ExtensionsTextBox.Enabled = isNotNull;
            ExecutableTextBox.Enabled = isNotNull;
            FormatTextBox.Enabled = isNotNull;

            if (_selected == null)
            {
                NameTextBox.Text = string.Empty;
                ExecutableTextBox.Text = string.Empty;
                ExtensionsTextBox.Text = string.Empty;
                FormatTextBox.Text = string.Empty;
            }
            else
            {
                // only change name box if needed
                if (NameTextBox.Text.CompareTo(_selected.Name) != 0)
                {
                    NameTextBox.Text = _selected.Name;
                }
                ExtensionsTextBox.Text = _selected.GetExtensions();
                ExecutableTextBox.Text = _selected.ExecutablePath;
                FormatTextBox.Text = _selected.Format;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Loads the data into the form.
        /// </summary>
        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            // load all scripts
            RefreshScriptsListBox();

            // set selected to first in list
            ScriptsListBox.SelectedIndex = Math.Min(0, ScriptsListBox.Items.Count - 1);

            UpdateFormComponents();
        }

        /// <summary>
        /// Saves any existing changes and closes the form.
        /// </summary>
        private void DoneButton_Click(object sender, EventArgs e)
        {
            // update selected data, save it, then close
            UpdateSelected();
            Manager.Save();
            Close();
        }

        /// <summary>
        /// Adds a new script data, and selects it.
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            // add new script data
            Manager.Data.SetScript(new ScriptData("New Script Type"));

            // refresh so we can see it
            RefreshScriptsListBox();

            // select it
            ScriptsListBox.SelectedIndex = ScriptsListBox.Items.Count - 1;
        }

        /// <summary>
        /// Deletes the currently selected script data, if there is one.
        /// </summary>
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

        /// <summary>
        /// Called when a new script data is selected. Saves the values to the old one and then
        /// loads the values for the new one.
        /// </summary>
        private void ScriptsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update old data if able
            UpdateSelected();

            // load new data into boxes, or empty data if nothing selected
            _selected = ScriptsListBox.SelectedItem as ScriptData;

            UpdateFormComponents();
        }

        /// <summary>
        /// Called when the name text box is no longer being edited. Renames the currently selected script data.
        /// </summary>
        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            UpdateSelected();
        }

        /// <summary>
        /// Opens an open file dialog to select the location of the executable.
        /// </summary>
        private void OpenFileDialogForExecutableButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Select a program to run for this type of script.",
                RestoreDirectory = true,
                InitialDirectory = "C:/",
                Filter = "Executable (*.exe)|*.exe|All Files (*.*)|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // found file, set it
                ExecutableTextBox.Text = ofd.FileName;
            }
        }

        #endregion
    }
}
