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
    /// <summary>
    /// The main form. Allows the user to view and edit all macros and application data.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The color to display when a macro has nothing exciting about it.
        /// </summary>
        private static readonly Color COLOR_DEFAULT = Color.FromArgb(255, 255, 255, 255);
        /// <summary>
        /// The color to display when a macro is not empty and is registered.
        /// </summary>
        private static readonly Color COLOR_GOOD = Color.FromArgb(255, 240, 255, 240);
        /// <summary>
        /// The color to display when a macro is not empty and is not registered.
        /// </summary>
        private static readonly Color COLOR_BAD = Color.FromArgb(255, 255, 240, 240);
        /// <summary>
        /// The color to display when a macro is empty.
        /// </summary>
        private static readonly Color COLOR_EMPTY = Color.FromArgb(255, 220, 220, 220);

        /// <summary>
        /// The buttons to edit each macro.
        /// </summary>
        private List<Button> _macroButtons;
        private Button? _newButton;

        /// <summary>
        /// A reference to the configure scripts form. There can only be one.
        /// </summary>
        private ConfigureScriptsForm? _configureForm;

        /// <summary>
        /// A reference to the settings form. There can only be one.
        /// </summary>
        private SettingsForm? _settingsForm;

        public MainForm()
        {
            // initialize everything else
            InitializeComponent();

            // initialize self
            Text = Application.ProductName.InsertSpaces();

            // collect buttons for later use
            _macroButtons = new List<Button>();
            _newButton = null;
        }

        #region Macros

        /// <summary>
        /// Sets the macro at the given index.
        /// </summary>
        private void SetMacro(int index, MacroData data)
        {
            // set in manager
            Manager.Data.SetMacro(index, data);

            Manager.Save();

            // set button display
            UpdateMacroButton(index, data);
        }

        /// <summary>
        /// Edits the macro at the given index.
        /// </summary>
        /// <param name="index">The index of the macro to edit.</param>
        private void EditMacro(int index)
        {
            // get existing macro, or create a new one
            MacroData? macroData = Manager.Data.GetMacro(index) ?? new MacroData();

            ConfigureMacroForm cmf = new ConfigureMacroForm(macroData);

            if (cmf.ShowDialog() == DialogResult.OK)
            {
                // macro values have been set
                SetMacro(index, macroData);
            }
        }

        /// <summary>
        /// Delets the macro at the given index.
        /// </summary>
        /// <param name="index">The index of the macro to delete.</param>
        private void DeleteMacro(int index)
        {
            // unregister macro, if it is
            MacroData? data = Manager.Data.GetMacro(index);

            if (data == null)
            {
                return;
            }

            data.Key.UnRegister();

            // delete in mananger
            Manager.Data.DeleteMacro(index);

            // save updates
            Manager.Save();

            // update buttons
            UpdateMacroList();
        }

        #endregion

        #region View

        /// <summary>
        /// Updates the display of the button for the given macro at the given index.
        /// </summary>
        /// <param name="index">The index of the macro/button to update.</param>
        /// <param name="data">The macro data to use to update the button display with.</param>
        private void UpdateMacroButton(int index, MacroData data)
        {
            // set text
            _macroButtons[index].Text = data.ToString();

            // set button color
            _macroButtons[index].BackColor = GetMacroButtonColor(data);
        }

        /// <summary>
        /// Generates a button that can be used to access macro data.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="color">The background color of the button.</param>
        /// <param name="handler">The event to call when it is clicked.</param>
        /// <returns>The Button object generated.</returns>
        private Button CreateMacroButton(string text, Color color, MouseEventHandler handler)
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

        /// <summary>
        /// Gets the color that the button should be, given the macro data.
        /// </summary>
        /// <param name="macro">The macro data to use to determine the color.</param>
        /// <returns>The color of the macro button.</returns>
        private Color GetMacroButtonColor(MacroData? macro)
        {
            if (macro == null)
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

        /// <summary>
        /// Updates the list of macros.
        /// </summary>
        private void UpdateMacroList()
        {
            // get macro keys
            MacroData[] macros = Manager.Data.Macros.ToArray();

            // get scroll
            int scroll = HotKeysFlowLayoutPanel.VerticalScroll.Value;

            Button temp;
            MacroData macro;
            int updateLength = _macroButtons.Count;

            // add new button if it does not exist
            if (_newButton == null)
            {
                _newButton= CreateMacroButton("New...", COLOR_DEFAULT, NewMacroButton_MouseClick);
                HotKeysFlowLayoutPanel.Controls.Add(_newButton);
            }

            if(macros.Length > _macroButtons.Count)
            {
                // add new buttons

                // remove new button temporarily
                HotKeysFlowLayoutPanel.Controls.RemoveAt(HotKeysFlowLayoutPanel.Controls.Count - 1);

                // add missing buttons
                for(int i = _macroButtons.Count; i < macros.Length; i++)
                {
                    // create new button and add to list
                    macro = macros[i];
                    temp = CreateMacroButton(macro.ToString(), GetMacroButtonColor(macro), MacroButton_MouseClick);
                    _macroButtons.Add(temp);
                    HotKeysFlowLayoutPanel.Controls.Add(temp);
                }

                // add new button back
                HotKeysFlowLayoutPanel.Controls.Add(_newButton);
            }
            else if (macros.Length < _macroButtons.Count)
            {
                updateLength = macros.Length;

                // remove buttons

                // remove extra buttons
                for (int i = _macroButtons.Count - 1; i >= macros.Length; i--)
                {
                    temp = _macroButtons[i];
                    _macroButtons.RemoveAt(i);
                    HotKeysFlowLayoutPanel.Controls.RemoveAt(i);
                    temp.Dispose();
                }
            }

            // update any non-new buttons
            for (int i = 0; i < updateLength; i++)
            {
                UpdateMacroButton(i, macros[i]);
            }

            // reassign scroll
            HotKeysFlowLayoutPanel.VerticalScroll.Value = scroll;
        }

        #endregion

        #region Events

        /// <summary>
        /// Loads the data into the form.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // ensure folder exists
            if (!Directory.Exists(Manager.Data.Settings.ScriptFolderPath))
            {
                Directory.CreateDirectory(Manager.Data.Settings.ScriptFolderPath);
            }

            // load buttons
            UpdateMacroList();
        }

        /// <summary>
        /// Saves all application data when the form is closed.
        /// </summary>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Manager.Save();
        }

        /// <summary>
        /// Opens the folder where scripts for the application can easily be stored and accessed,
        /// with the user's documents folder.
        /// </summary>
        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            using (Process process = new Process())
            {
                process.StartInfo = new ProcessStartInfo("explorer.exe", Manager.Data.Settings.ScriptFolderPath);
                process.Start();
            }
        }

        /// <summary>
        /// Called when the mouse clicks a button for a macro.
        /// If left click, the macro will be edited.
        /// If right click, the macro will be deleted.
        /// </summary>
        private void MacroButton_MouseClick(object sender, MouseEventArgs e)
        {
            // get index of macro by using index of button
            int index = _macroButtons.IndexOf((Button)sender);

            switch (e.Button)
            {
                case MouseButtons.Left:
                    EditMacro(index); break;
                case MouseButtons.Right:
                    DeleteMacro(index); break;
            }
        }

        /// <summary>
        /// Called when the new button has been pressed.
        /// Creates a new macro, adds it to the list, and opens the form to edit it.
        /// </summary>
        private void NewMacroButton_MouseClick(object? sender, MouseEventArgs e)
        {
            // create new macro and add it
            Manager.Data.AddMacro(new MacroData());

            // refresh list
            UpdateMacroList();

            // edit new macro
            EditMacro(Manager.Data.Macros.Count - 1);
        }

        /// <summary>
        /// Opens the script data configuration form.
        /// </summary>
        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            if(_configureForm == null)
            {
                _configureForm = new ConfigureScriptsForm();
                _configureForm.Show();
                _configureForm.FormClosed += (object? sender, FormClosedEventArgs e) =>
                {
                    _configureForm = null;
                    UpdateMacroList();
                };
            }
            else
            {
                _configureForm.Activate();
            }
        }

        /// <summary>
        /// Called when a key is pressed when this form is active.
        /// Closes the form when escape is pressed.
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // close form on escape
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        /// <summary>
        /// When the flow layout panel is resized, manually resize all of the buttons.
        /// The buttons cannot use anchors within the layout panel, and the layout panel
        /// does not automatically resize the buttons, so here we are.
        /// </summary>
        private void HotKeysFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            // resize all widths
            foreach(Control control in HotKeysFlowLayoutPanel.Controls)
            {
                control.Size = new Size(HotKeysFlowLayoutPanel.Width - 30, control.Size.Height);
            }
        }

        /// <summary>
        /// Opens the settings menu window.
        /// </summary>
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            if(_settingsForm == null)
            {
                _settingsForm = new SettingsForm(Manager.Data.Settings);
                _settingsForm.Show();
                _settingsForm.FormClosed += (object? sender, FormClosedEventArgs e) =>
                {
                    _settingsForm = null;
                };
            }

            _settingsForm.Activate();
        }

        #endregion
    }
}
