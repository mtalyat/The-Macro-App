using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace TheMacroApp
{
    public partial class ConfigureMacroForm : Form
    {
        private readonly MacroData _macroData;

        public ConfigureMacroForm(MacroData macro)
        {
            _macroData = macro;

            InitializeComponent();
        }

        private void ConfigureMacroForm_Load(object sender, EventArgs e)
        {
            TerminalShowOptions[] options = Enum.GetValues<TerminalShowOptions>();

            // set combo box
            TerminalComboBox.DataSource = options;

            // load from macro
            PathTextBox.Text = _macroData.Path;
            ArgumentsTextBox.Text = _macroData.Args;
            TerminalComboBox.SelectedIndex = Array.IndexOf(options, _macroData.TerminalOption);
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            // set values to macro
            _macroData.Path = PathTextBox.Text;
            _macroData.Args = ArgumentsTextBox.Text;
            _macroData.TerminalOption = TerminalComboBox.SelectedItem as TerminalShowOptions? ?? TerminalShowOptions.Hide;

            // set result
            DialogResult = DialogResult.OK;

            // close
            Close();
        }

        private void OpenFileDialogPathButton_Click(object sender, EventArgs e)
        {
            // open file dialog for that macro
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = $"Select a script to run for the macro.",
                Filter = "All Files (*.*) |*.*",
                InitialDirectory = AppData.FOLDER_PATH,
                RestoreDirectory = true,
                CheckFileExists = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // file was found
                PathTextBox.Text = ofd.FileName;
            }
        }

        private void ResetMacroButton_Click(object sender, EventArgs e)
        {
            // clear data from boxes
            PathTextBox.Text = string.Empty;
            ArgumentsTextBox.Text = string.Empty;
            TerminalComboBox.SelectedIndex = 0;
        }

        private void DiscardButton_Click(object sender, EventArgs e)
        {
            // do not set
            Close();
        }
    }
}
