using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheMacroApp
{
    internal static class Manager
    {
        private static readonly string SAVE_FILE = Path.Join(Application.LocalUserAppDataPath, @"appdata.json");

        public static AppData Data { get; private set; } = new AppData();

        #region Saving and Loading

        public static void Save()
        {
            Data.Save(SAVE_FILE);
        }

        public static void Load()
        {
            // load data from disc
            Data = AppData.Load(SAVE_FILE) ?? new AppData();

            // sort scripts by name
            Data.Scripts.Sort();
        }

        #endregion

        #region Running

        public static void RunMacro(int index)
        {
            // get path for index
            MacroData? macroData = Data.GetMacro(index);

            // if no data saved, do nothing
            if (macroData == null || string.IsNullOrEmpty(macroData.Path))
            {
                return;
            }

            // if no file found, let user know, then do nothing
            if (!File.Exists(macroData.Path))
            {
                ShowWarning($"No script found for macro {index} at path \"{macroData.Path}\".", "No script found.");
                return;
            }

            // run it, according to the file extension
            string extension = Path.GetExtension(macroData.Path);

            // get the data
            ScriptData? scriptData = Data.FindScript(extension);

            if(scriptData != null)
            {
                // found script data, so run it
                RunCommand(macroData, scriptData);
            }
            else
            {
                // invalid file type
                ShowWarning($"Extension \"{extension}\" not recognized. Make sure you add it to the configuration settings.", "Unknown extension.");
            }
        }

        private static void RunCommand(MacroData macroData, ScriptData scriptData)
        {
            using (Process process = new Process())
            {
                // figure out the file name and arguments...
                /*
                 * If no executable provided, assume script is an executable:
                 * - FileName = MacroData.Path
                 * - Arguments = MacroData.Args
                 * 
                 * If executable provided:
                 * - FileName = ScriptData.ExecutablePath
                 * - Arguments = MacroData.ToCommand()
                 */

                string fileName, arguments;
                if(string.IsNullOrEmpty(scriptData.ExecutablePath))
                {
                    fileName = macroData.Path;
                    arguments = macroData.Args;
                }
                else
                {
                    fileName = scriptData.ExecutablePath;
                    arguments = macroData.ToCommand(scriptData.Format);
                }

                bool showTerminal = macroData.TerminalOption == TerminalShowOptions.Show;

                ProcessStartInfo info = new ProcessStartInfo()
                {
                    FileName = fileName,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardInput = false,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    CreateNoWindow = !showTerminal,
                };

                // run command
                process.StartInfo = info;
                if (process.Start())
                {
                    // wait for command to complete
                    //process.WaitForExit();
                }
            }
        }

        #endregion

        #region Utility

        private static void ShowWarning(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion
    }
}
