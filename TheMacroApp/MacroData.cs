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
        public const string INVALID_TEXT = "None";

        [JsonInclude]
        public string Path;
        [JsonInclude]
        public string Args;
        [JsonInclude]
        public TerminalShowOptions TerminalOption;
        [JsonInclude]
        public MacroKey Key;

        public bool IsValid => Key.IsRegistered;

        public MacroData()
        {
            Path = string.Empty;
            Args = string.Empty;
            TerminalOption = TerminalShowOptions.Hide;
            Key = new MacroKey();
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
            Key = new MacroKey();
        }

        public override string ToString()
        {
            // if key is not registered, so invalid
            if(!IsValid)
            {
                return INVALID_TEXT;
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
