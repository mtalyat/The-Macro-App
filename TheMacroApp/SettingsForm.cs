using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheMacroApp
{
    public partial class SettingsForm : Form
    {
        private readonly SettingsData _settingsData;

        public SettingsForm(SettingsData data)
        {
            _settingsData = data;

            InitializeComponent();
        }

        #region Data

        /// <summary>
        /// Saves the data in the input controls to the Settings object.
        /// </summary>
        private void SaveData()
        {
            // normal data
            _settingsData.ScriptFolderPath = ScriptFolderTextBox.Text;

            _settingsData.ApplicationKey.Key = KeyComboBox.SelectedItem as Keys? ?? Keys.None;
            _settingsData.ApplicationKey.SetModifiers(AltCheckBox.Checked, CtrlCheckBox.Checked, ShiftCheckBox.Checked, WindowsCheckBox.Checked);
            _settingsData.ApplicationKey.UpdateRegistration();

            // remove from startup, if it exists
            string path = GetStartupFilePath();
            
            // check or uncheck
            if (StartupCheckBox.Checked)
            {
                // create shortcut for this running exe in the startup app, if it does not exist
                if (!File.Exists(path)) CreateShortcut($"{Application.ProductName}.exe", GetStartupFolderPath(), Application.ExecutablePath);
            }
            else
            {
                // remove shortcut, if it exists
                if (File.Exists(path)) File.Delete(path);
            }
        }

        /// <summary>
        /// Loads the data from the Settings object to the input controls.
        /// </summary>
        private void LoadData()
        {
            Keys[] keys = Enum.GetValues<Keys>();

            // load
            KeyComboBox.DataSource = keys;

            // normal data
            ScriptFolderTextBox.Text = _settingsData.ScriptFolderPath;

            KeyComboBox.SelectedIndex = Array.IndexOf(keys, _settingsData.ApplicationKey.Key);
            AltCheckBox.Checked = _settingsData.ApplicationKey.Modifiers.HasFlag(ModKeys.Alt);
            CtrlCheckBox.Checked = _settingsData.ApplicationKey.Modifiers.HasFlag(ModKeys.Ctrl);
            ShiftCheckBox.Checked = _settingsData.ApplicationKey.Modifiers.HasFlag(ModKeys.Shift);
            WindowsCheckBox.Checked = _settingsData.ApplicationKey.Modifiers.HasFlag(ModKeys.Win);

            // if it is in the startup folder, it will start when the computer starts
            StartupCheckBox.Checked = File.Exists(GetStartupFilePath());

            // update valid
            OnKeyChange(this, new EventArgs());
        }

        #endregion

        #region View

        /// <summary>
        /// Sets the attributes of the display letting the user know if the macro key is valid or invalid.
        /// </summary>
        /// <param name="valid"></param>
        private void SetKeyValidity(bool valid)
        {
            if (valid)
            {
                HotKeyErrorLabel.Text = "Hot Key is VALID.";
                HotKeyErrorLabel.ForeColor = Color.White;
                HotKeyErrorLabel.BackColor = Color.Green;
            }
            else
            {
                HotKeyErrorLabel.Text = "Hot Key is INVALID.";
                HotKeyErrorLabel.ForeColor = Color.White;
                HotKeyErrorLabel.BackColor = Color.Red;
            }
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
            if (_settingsData.ApplicationKey.IsRegistered && _settingsData.ApplicationKey == temp)
            {
                SetKeyValidity(true);
            }
            else
            {
                // show if valid or not
                SetKeyValidity(temp.CanRegister());
            }
        }

        #endregion

        #region Startup

        private string GetStartupFolderPath()
        {
            return Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\Start Menu\Programs\Startup");
        }

        private string GetStartupFilePath()
        {
            return Path.Join(GetStartupFolderPath(), "TheMacroApp.exe.lnk");
        }

        //https://www.fluxbytes.com/csharp/create-shortcut-programmatically-in-c/
        /// <summary>
        /// Creates a shortcut at the specified location.
        /// </summary>
        /// <param name="shortcutName">The name of the shortcut.</param>
        /// <param name="shortcutPath">The path to the shortcut.</param>
        /// <param name="targetFileLocation">The file that the shortcut is going to.</param>
        private void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = Path.Combine(shortcutPath, shortcutName + ".lnk");
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = shortcutName;
            //shortcut.IconLocation = "Icon.ico";
            shortcut.TargetPath = targetFileLocation;
            shortcut.Save();
        }

        #endregion

        #region Events

        /// <summary>
        /// Save changes and close.
        /// </summary>
        private void DoneButton_Click(object sender, EventArgs e)
        {
            SaveData();

            Close();
        }

        /// <summary>
        /// Close without saving.
        /// </summary>
        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads the existing settings to the input controls.
        /// </summary>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // check if on startup
            LoadData();
        }

        #endregion

        private void ScriptFolderOpenFileDialogButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                Description = "Select a default script.",
                UseDescriptionForTitle = true,
                InitialDirectory = _settingsData.ScriptFolderPath
            };

            if(fbd.ShowDialog() == DialogResult.OK)
            {
                ScriptFolderTextBox.Text = fbd.SelectedPath;
            }
        }
    }
}
