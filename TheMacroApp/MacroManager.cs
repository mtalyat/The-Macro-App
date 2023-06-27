using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMacroApp
{
    /// <summary>
    /// Manages all saved macros.
    /// </summary>
    public static class MacroManager
    {
        public const int MACRO_COUNT = 10;

        #region Running

        public static void Run(int index)
        {
            // get path for index
            MacroData? data = Get(index);

            // if no data saved, do nothing
            if (data == null || string.IsNullOrEmpty(data.Path))
            {
                return;
            }

            // if no file found, let user know, then do nothing
            if (!File.Exists(data.Path))
            {
                ShowWarning($"No script found for macro {index} at path \"{data.Path}\".", "No script found.");
                return;
            }

            // run it, according to the file extension
            string extension = Path.GetExtension(data.Path);
            switch (extension)
            {
                case ".bat":
                case ".cmd":
                    RunCommand(data.Path, data.Args ?? string.Empty);
                    break;
                case ".py":
                    RunCommand(@"C:/Users/mitch/AppData/Local/Programs/Python/Python311/python.exe", data.ToCommand());
                    break;
                default:
                    // invalid file type
                    ShowWarning($"Extension \"{extension}\" not recognized.", "Unknown extension.");
                    break;
            }
        }

        private static void RunCommand(string file, string arguments)
        {
            using (Process process = new Process())
            {
                ProcessStartInfo info = new ProcessStartInfo()
                {
                    FileName = file,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                };

                // run command
                process.StartInfo = info;
                if(process.Start())
                {
                    // wait for command to complete
                    process.WaitForExit();
                }
            }
        }

        #endregion

        #region Managing

        public static void Set(int index, MacroData? data)
        {
            // if invalid index, do nothing
            if (IsInvalidIndex(index))
            {
                return;
            }

            // set settings file
            Settings.Default[GetMacroPathSettingsName(index)] = data?.Path;
            Settings.Default[GetMacroArgsSettingsName(index)] = data?.Args;
            Settings.Default.Save();
        }

        public static MacroData? Get(int index)
        {
            // return nothing if null
            if (IsInvalidIndex(index))
            {
                return null;
            }

            // return path for macro
            return new MacroData(
                Settings.Default[GetMacroPathSettingsName(index)]?.ToString(),
                Settings.Default[GetMacroArgsSettingsName(index)]?.ToString()
                );
        }

        #endregion

        #region Utility

        private static string GetMacroPathSettingsName(int index)
        {
            return $"Macro{index}_Path";
        }

        private static string GetMacroArgsSettingsName(int index)
        {
            return $"Macro{index}_Args";
        }

        private static bool IsInvalidIndex(int index)
        {
            return index < 0 || index >= MACRO_COUNT;
        }

        private static void ShowWarning(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion
    }

    /// <summary>
    /// Holds data for a macro.
    /// </summary>
    public class MacroData
    {
        public const string EMPTY_TEXT = "None";

        public string? Path;
        public string? Args;

        public MacroData(string? path, string? args)
        {
            Path = path;
            Args = args;
        }

        public string ToCommand()
        {
            if(Path == null)
            {
                return string.Empty;
            }

            if (Args == null)
            {
                return Path;
            }
            else
            {
                return $"{Path} {Args}";
            }
        }

        public override string ToString()
        {
            if(string.IsNullOrWhiteSpace(Path))
            {
                // no path, so no args
                return EMPTY_TEXT;
            }

            if (string.IsNullOrWhiteSpace(Args))
            {
                return System.IO.Path.GetFileName(Path);
            }
            else
            {
                return $"{System.IO.Path.GetFileName(Path)} - {Args}";
            }
        }
    }
}
