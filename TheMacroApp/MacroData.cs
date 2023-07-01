using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheMacroApp
{
    /// <summary>
    /// Holds data for a hotkey macro.
    /// </summary>
    public class MacroData
    {
        /// <summary>
        /// The default text to display for when a macro is considered empty.
        /// </summary>
        [JsonIgnore]
        public const string EMPTY_TEXT = "None";

        /// <summary>
        /// The path to the macro file to run.
        /// </summary>
        [JsonInclude]
        public string Path;

        /// <summary>
        /// The command line arguments to pass into the file when it is ran.
        /// </summary>
        [JsonInclude]
        public string Args;

        /// <summary>
        /// The options for what to do with the terminal when the macro is ran.
        /// </summary>
        [JsonInclude]
        public TerminalShowOptions TerminalOption;

        /// <summary>
        /// The hotkey combination that will trigger this macro.
        /// </summary>
        [JsonInclude]
        public MacroKey Key;

        /// <summary>
        /// Is this macro empty? Will nothing happen if it is ran?
        /// </summary>
        public bool IsEmpty => string.IsNullOrWhiteSpace(Path) && string.IsNullOrWhiteSpace(Args);

        /// <summary>
        /// Is this macro registered? Will Windows recognize it as a hotkey?
        /// </summary>
        public bool IsRegistered => Key.IsRegistered;

        /// <summary>
        /// Creates an empty macro.
        /// </summary>
        public MacroData()
        {
            Path = string.Empty;
            Args = string.Empty;
            TerminalOption = TerminalShowOptions.Hide;
            Key = new MacroKey();
        }

        /// <summary>
        /// Converts this macro to a command line command.
        /// </summary>
        /// <param name="format">The format to put the string into.</param>
        /// <returns>The command line string, formatted with the path and the command line arguments.</returns>
        public string ToCommand(string format)
        {
            return format.Replace(ScriptData.TEMPLATE_FILE, Path).Replace(ScriptData.TEMPLATE_ARGS, Args);
        }

        /// <summary>
        /// Reset this macro to the default values.
        /// </summary>
        public void Reset()
        {
            Path = string.Empty;
            Args = string.Empty;
            TerminalOption = TerminalShowOptions.Hide;
            Key = new MacroKey();
        }

        public override string ToString()
        {
            // if key is not registered, so invalid
            if(IsEmpty)
            {
                return EMPTY_TEXT;
            }

            // find script data for this
            ScriptData? scriptData = Manager.Data.FindScript(System.IO.Path.GetExtension(Path));

            if (scriptData != null)
            {
                // script data, so use that
                StringBuilder sb = new StringBuilder();

                sb.Append(Key);
                sb.Append(" -> ");

                if (scriptData.ExecutablePath.Length > 0)
                {
                    sb.Append(scriptData.ExecutablePath);
                    sb.Append(' ');
                }
                sb.Append(ToCommand(scriptData.Format));

                return sb.ToString();
            }
            else
            {
                // no script data, so just print key and file with args
                if (string.IsNullOrWhiteSpace(Args))
                {
                    return $"{Key} -> {System.IO.Path.GetFileName(Path)}";
                }
                else
                {
                    return $"{Key} -> {System.IO.Path.GetFileName(Path)} {Args}";
                }
            }
        }
    }
}
