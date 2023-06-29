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
    /// Holds data for a macro.
    /// </summary>
    public class MacroData
    {
        [JsonIgnore]
        public const string EMPTY_TEXT = "None";

        [JsonInclude]
        public string Path;
        [JsonInclude]
        public string Args;
        [JsonInclude]
        public TerminalShowOptions TerminalOption;

        public MacroData()
        {
            Path = string.Empty;
            Args = string.Empty;
            TerminalOption = TerminalShowOptions.Hide;
        }

        public string ToCommand(string format)
        {
            return format.Replace(ScriptData.TEMPLATE_FILE, Path).Replace(ScriptData.TEMPLATE_ARGS, Args);
        }

        public void Reset()
        {
            Path = string.Empty;
            Args = string.Empty;
            TerminalOption = TerminalShowOptions.Hide;
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
