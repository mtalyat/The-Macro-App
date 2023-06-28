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
    public partial class MainForm : Form
    {
        private readonly string FOLDER_PATH;

        private Button[] _macroButtons;

        private ConfigureForm? _configureForm;

        public MainForm()
        {
            FOLDER_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), TheMacroApplicationContext.APP_SYSTEM_NAME);

            // initialize everything else
            InitializeComponent();

            // load data
            Manager.Load();

            // initialize self
            Text = TheMacroApplicationContext.APP_NAME;

            // collect buttons for later use
            _macroButtons = new Button[AppData.MACRO_COUNT]
            {
                Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9
            };
        }

        // when main form loads
        private void MainForm_Load(object sender, EventArgs e)
        {
            // ensure folder exists
            if (!Directory.Exists(FOLDER_PATH))
            {
                Directory.CreateDirectory(FOLDER_PATH);
            }

            // update all buttons with existing macros
            for (int i = 0; i < AppData.MACRO_COUNT; i++)
            {
                SetMacroButtonText(i, Manager.Data.GetMacro(i)?.ToString() ?? MacroData.EMPTY_TEXT);
            }
        }

        // after form has closed
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Manager.Save();
        }

        private void SetMacro(int index, MacroData? data)
        {
            // set in manager
            Manager.Data.SetMacro(index, data);

            Manager.Save();

            // set button display
            SetMacroButtonText(index, data?.ToString() ?? MacroData.EMPTY_TEXT);
        }

        private void SetMacroButtonText(int index, string text)
        {
            _macroButtons[index].Text = text;
        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            using (Process process = new Process())
            {
                process.StartInfo = new ProcessStartInfo("explorer.exe", FOLDER_PATH);
                process.Start();
            }
        }

        private void SelectNewMacro(int index)
        {
            // open file dialog for that macro
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = $"Select a script to run for macro {index}.",
                Filter = "All Files (*.*) |*.*",
                InitialDirectory = FOLDER_PATH,
                RestoreDirectory = true,
                CheckFileExists = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // file was found
                // get command line arguments as well
                EnterTextDialog etd = new EnterTextDialog("Enter command line arguments.");

                if (etd.ShowDialog() == DialogResult.OK)
                {
                    // set to found file
                    SetMacro(index, new MacroData(ofd.FileName, etd.Content));
                }
            }
        }

        private void ClearMacro(int index)
        {
            SetMacro(index, null);
        }

        private void MacroButton_MouseClick(object sender, MouseEventArgs e)
        {
            // get index of macro by using index of button
            int index = Array.IndexOf(_macroButtons, (Button)sender);

            switch (e.Button)
            {
                case MouseButtons.Left:
                    SelectNewMacro(index); break;
                case MouseButtons.Right:
                    ClearMacro(index); break;
            }
        }

        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            if(_configureForm == null)
            {
                _configureForm = new ConfigureForm();
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
    }
}
