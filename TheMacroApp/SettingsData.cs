using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheMacroApp
{
    public class SettingsData
    {
        /// <summary>
        /// The path to the folder location for the scripts.
        /// This folder is not required for macro scripts.
        /// </summary>
        [JsonInclude]
        public string ScriptFolderPath { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Application.ProductName);

        /// <summary>
        /// The macro that is used to quickly open the application.
        /// </summary>
        [JsonInclude]
        public MacroKey ApplicationKey { get; set; } = new MacroKey(Keys.M, ModKeys.Ctrl | ModKeys.Alt); // default is Ctrl + Alt + M
    }
}
