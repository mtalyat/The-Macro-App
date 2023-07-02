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
    /// <summary>
    /// The window that allows users to configure and customize the macros.
    /// </summary>
    public partial class ConfigureMacroForm : Form
    {
        /// <summary>
        /// The macro data to configure.
        /// </summary>
        private readonly MacroData _macroData;

        public ConfigureMacroForm(MacroData macro)
        {
            _macroData = macro;

            InitializeComponent();            
        }

        #region View

        /// <summary>
        /// Takes the values from the input boxes and applies them to the stored macro object.
        /// </summary>
        private void ApplyValuesToMacro()
        {
            // set values to macro
            _macroData.Path = PathTextBox.Text;
            _macroData.Args = ArgumentsTextBox.Text;
            _macroData.TerminalOption = TerminalComboBox.SelectedItem as TerminalShowOptions? ?? TerminalShowOptions.Hide;

            _macroData.Key.Key = KeyComboBox.SelectedItem as Keys? ?? Keys.None;
            _macroData.Key.SetModifiers(AltCheckBox.Checked, CtrlCheckBox.Checked, ShiftCheckBox.Checked, WindowsCheckBox.Checked);

            // officially re-register the key
            _macroData.Key.UpdateRegistration();
        }

        /// <summary>
        /// Creates the filter for the open file dialog, when selecting a macro file to run.
        /// </summary>
        /// <returns>The filter for the OpenFileDialog.</returns>
        private string GenerateOpenFileDialogFilter()
        {
            // dynamically create a filter
            // create one for all configured script types
            // create one for each configured script type
            // create one for all files

            // if no scripts, just return all types
            if (!Manager.Data.Scripts.Any())
            {
                return "All Files (*.*)|*.*";
            }

            StringBuilder output = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            string temp;

            /*
             * Should follow the format:
             * 
             * "Script Name (*.extension;*.extension2)|*.extension;*.extension2"
             */

            output.Append("All Configured Types (");

            // all configured
            foreach (ScriptData scriptData in Manager.Data.Scripts)
            {
                foreach (string extension in scriptData.Extensions)
                {
                    sb.Append('*');
                    sb.Append(extension);
                    sb.Append(';');
                }
            }
            sb.Remove(sb.Length - 1, 1); // remove last ;

            temp = sb.ToString();
            sb.Clear();

            output.Append(temp);
            output.Append(")|");
            output.Append(temp);
            output.Append('|');

            // individual
            foreach (ScriptData scriptData in Manager.Data.Scripts)
            {
                output.Append(scriptData.Name);
                output.Append(" (");
                foreach (string extension in scriptData.Extensions)
                {
                    sb.Append('*');
                    sb.Append(extension);
                    sb.Append(';');
                }
                sb.Remove(sb.Length - 1, 1); // remove last ;
                temp = sb.ToString();
                sb.Clear();
                output.Append(temp);
                output.Append(")|");
                output.Append(temp);
                output.Append('|');
            }

            // all
            output.Append("All Files (*.*)|*.*");

            return output.ToString();
        }

        /// <summary>
        /// Sets the attributes of the display letting the user know if the macro key is valid or invalid.
        /// </summary>
        /// <param name="valid"></param>
        private void SetKeyValidity(bool valid)
        {
            BasicColor color;
            if (valid)
            {
                HotKeyErrorLabel.Text = $"Hot Key is {MacroKey.VALID_TEXT}.";
                color = Manager.Data.Settings.ValidColor.Vivid();
                HotKeyErrorLabel.ForeColor = color.GetTextColor();
                HotKeyErrorLabel.BackColor = color;
            }
            else
            {
                HotKeyErrorLabel.Text = $"Hot Key is {MacroKey.INVALID_TEXT}.";
                color = Manager.Data.Settings.InvalidColor.Vivid();
                HotKeyErrorLabel.ForeColor = color.GetTextColor();
                HotKeyErrorLabel.BackColor = color;
            }
        }

        /// <summary>
        /// If the currently selected file type does not use arguments, update the arguments box.
        /// </summary>
        private void UpdateArgumentTextBoxAccessability()
        {
            // disable path or args based on what the script data format contains
            ScriptData? script = Manager.Data.FindScript(Path.GetExtension(PathTextBox.Text));

            if (script != null && !script.Format.Contains(ScriptData.TEMPLATE_ARGS))
            {
                // no args
                ArgumentsTextBox.ReadOnly = true;
            }
            else
            {
                // no script associated, or yes args
                ArgumentsTextBox.ReadOnly = false;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Loads the form data.
        /// </summary>
        private void ConfigureMacroForm_Load(object sender, EventArgs e)
        {
            TerminalShowOptions[] options = Enum.GetValues<TerminalShowOptions>();
            Keys[] keys = Enum.GetValues<Keys>();

            // set data
            TerminalComboBox.DataSource = options;
            KeyComboBox.DataSource = keys;

            // load from macro
            PathTextBox.Text = _macroData.Path;
            ArgumentsTextBox.Text = _macroData.Args;
            TerminalComboBox.SelectedIndex = Array.IndexOf(options, _macroData.TerminalOption);

            UpdateArgumentTextBoxAccessability();

            KeyComboBox.SelectedIndex = Array.IndexOf(keys, _macroData.Key.Key);
            AltCheckBox.Checked = _macroData.Key.Modifiers.HasFlag(ModKeys.Alt);
            CtrlCheckBox.Checked = _macroData.Key.Modifiers.HasFlag(ModKeys.Ctrl);
            ShiftCheckBox.Checked = _macroData.Key.Modifiers.HasFlag(ModKeys.Shift);
            WindowsCheckBox.Checked = _macroData.Key.Modifiers.HasFlag(ModKeys.Win);

            // update key view
            OnKeyChange(this, new EventArgs());
        }

        /// <summary>
        /// Saves all values to the macro data, then closes the form.
        /// </summary>
        private void DoneButton_Click(object sender, EventArgs e)
        {
            ApplyValuesToMacro();

            // set result
            DialogResult = DialogResult.OK;

            // close
            Close();
        }

        /// <summary>
        /// Allows the user to select a path for the macro file to run.
        /// </summary>
        private void OpenFileDialogPathButton_Click(object sender, EventArgs e)
        {
            // open file dialog for that macro
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = $"Select a script to run for the macro.",
                Filter = GenerateOpenFileDialogFilter(),
                InitialDirectory = Manager.Data.Settings.ScriptFolderPath,
                RestoreDirectory = true,
                CheckFileExists = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // file was found
                PathTextBox.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// Resets the form inputs to the default values.
        /// </summary>
        private void ResetMacroButton_Click(object sender, EventArgs e)
        {
            // clear data from boxes
            PathTextBox.Text = string.Empty;
            ArgumentsTextBox.Text = string.Empty;
            TerminalComboBox.SelectedIndex = 0;
            KeyComboBox.SelectedIndex = -1;
            AltCheckBox.Checked = false;
            CtrlCheckBox.Checked = false;
            ShiftCheckBox.Checked = false;
            WindowsCheckBox.Checked = false;
            SetKeyValidity(false);
        }

        /// <summary>
        /// Sets the form inputs back to the currently saved values in the macro data.
        /// </summary>
        private void DiscardButton_Click(object sender, EventArgs e)
        {
            // do not set
            Close();
        }

        /// <summary>
        /// Called when a value of the macro key has been changed (modifier or key).
        /// </summary>
        private void OnKeyChange(object sender, EventArgs e)
        {
            MacroKey temp = new MacroKey();
            temp.Key = KeyComboBox.SelectedItem as Keys? ?? Keys.None;
            temp.SetModifiers(AltCheckBox.Checked, CtrlCheckBox.Checked, ShiftCheckBox.Checked, WindowsCheckBox.Checked);

            // if equal to saved key, then it is valid
            // (Windows would say it is not valid, but that is becuase the old key is using that value)
            if (_macroData.Key.IsRegistered && _macroData.Key == temp)
            {
                SetKeyValidity(true);
            }
            else
            {
                // show if valid or not
                SetKeyValidity(temp.CanRegister());
            }
        }

        /// <summary>
        /// Called when the path changes. Updates the argument input accessability.
        /// </summary>
        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateArgumentTextBoxAccessability();
        }

        #endregion
    }
}
