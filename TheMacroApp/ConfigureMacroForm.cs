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
            Keys[] keys = Enum.GetValues<Keys>();

            // set data
            TerminalComboBox.DataSource = options;
            KeyComboBox.DataSource = keys;

            // load from macro
            PathTextBox.Text = _macroData.Path;
            ArgumentsTextBox.Text = _macroData.Args;
            TerminalComboBox.SelectedIndex = Array.IndexOf(options, _macroData.TerminalOption);

            KeyComboBox.SelectedIndex = Array.IndexOf(keys, _macroData.Key.Key);
            AltCheckBox.Checked = _macroData.Key.Modifiers.HasFlag(ModKeys.Alt);
            CtrlCheckBox.Checked = _macroData.Key.Modifiers.HasFlag(ModKeys.Ctrl);
            ShiftCheckBox.Checked = _macroData.Key.Modifiers.HasFlag(ModKeys.Shift);
            WindowsCheckBox.Checked = _macroData.Key.Modifiers.HasFlag(ModKeys.Win);

            // update key view
            OnKeyChange();
        }

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

        private void DoneButton_Click(object sender, EventArgs e)
        {
            ApplyValuesToMacro();

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
            KeyComboBox.SelectedIndex = -1;
            AltCheckBox.Checked = false;
            CtrlCheckBox.Checked = false;
            ShiftCheckBox.Checked = false;
            WindowsCheckBox.Checked = false;
            SetKeyValidity(false);
        }

        private void DiscardButton_Click(object sender, EventArgs e)
        {
            // do not set
            Close();
        }

        private void OnKeyChange()
        {
            MacroKey temp = new MacroKey();
            temp.Key = KeyComboBox.SelectedItem as Keys? ?? Keys.None;
            temp.SetModifiers(AltCheckBox.Checked, CtrlCheckBox.Checked, ShiftCheckBox.Checked, WindowsCheckBox.Checked);

            // if equal to saved key, then it is valid
            // (Windows would say it is not valid, but that is becuase the old key is using that value)
            if(_macroData.Key.IsRegistered && _macroData.Key == temp)
            {
                SetKeyValidity(true);
            }
            else
            {
                // show if valid or not
                SetKeyValidity(temp.CanRegister());
            }            
        }

        private void SetKeyValidity(bool valid)
        {
            if(valid)
            {
                HotKeyErrorLabel.Text = "Hot Key is VALID.";
                HotKeyErrorLabel.ForeColor = Color.White;
                HotKeyErrorLabel.BackColor = Color.Green;
            } else
            {
                HotKeyErrorLabel.Text = "Hot Key is INVALID.";
                HotKeyErrorLabel.ForeColor = Color.White;
                HotKeyErrorLabel.BackColor = Color.Red;
            }
        }

        private void KeyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnKeyChange();
        }

        private void AltCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OnKeyChange();
        }

        private void CtrlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OnKeyChange();
        }

        private void ShiftCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OnKeyChange();
        }

        private void WindowsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OnKeyChange();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            ApplyValuesToMacro();
        }
    }
}
