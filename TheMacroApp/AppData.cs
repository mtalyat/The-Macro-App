using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheMacroApp
{
    internal class AppData
    {
        public static readonly string FOLDER_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), TheMacroApplicationContext.APP_SYSTEM_NAME);

        [JsonInclude]
        public List<MacroData> Macros { get; private set; } = new List<MacroData>();
        [JsonInclude]
        public List<ScriptData> Scripts { get; private set; } = new List<ScriptData>();

        #region Managing

        public void SetMacro(int index, MacroData data)
        {
            // if invalid index, do nothing
            if (IsInvalidIndex(index))
            {
                return;
            }

            Macros[index] = data;
        }

        public void AddMacro(MacroData data)
        {
            Macros.Add(data);
        }

        public void DeleteMacro(int index)
        {
            Macros.RemoveAt(index);
        }

        public MacroData? GetMacro(int index)
        {
            // return nothing if null
            if (IsInvalidIndex(index))
            {
                return null;
            }

            // return path for macro
            return Macros[index];
        }

        public MacroData? FindMacro(MacroKey key)
        {
            foreach(MacroData macro in Macros)
            {
                if(macro.Key == key)
                {
                    return macro;
                }
            }

            return null;
        }

        public void SetScript(ScriptData data, bool addIfNotFound = true)
        {
            // find script, if exists, override
            // else add new
            int index = Scripts.FindIndex(s => s.Name == data.Name);
            if(index != -1)
            {
                // update
                Scripts[index] = data;
            }
            else if (addIfNotFound)
            {
                // add
                Scripts.Add(data);
            }
        }

        public void DeleteScript(string name)
        {
            int index = Scripts.FindIndex(s => s.Name == name);
            if (index != -1)
            {
                Scripts.RemoveAt(index);
            }
        }

        public bool RenameScript(string oldName, string newName)
        {
            int index = Scripts.FindIndex(s => s.Name == oldName);
            if (index != -1)
            {
                if (Scripts[index].Name != newName)
                {
                    Scripts[index].Name = newName;
                    return true;
                }
            }

            return false;
        }

        public ScriptData[] GetScripts()
        {
            // get all script names
            return Scripts.ToArray();
        }

        public ScriptData? FindScript(string extension)
        {
            foreach(ScriptData data in Scripts)
            {
                if(data.ContainsExtension(extension))
                {
                    // found data that uses this extension
                    return data;
                }
            }

            // not found
            return null;
        }

        #endregion

        #region Saving and Loading

        public void Save(string path)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(this));
        }

        public static AppData? Load(string path)
        {
            if(!File.Exists(path))
            {
                return null;
            }

            string text = File.ReadAllText(path);

            // if no text, return nothing
            if(string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            // return parsed data
            return JsonSerializer.Deserialize<AppData>(File.ReadAllText(path));
        }

        #endregion

        #region Utility

        private bool IsInvalidIndex(int index)
        {
            return index < 0 || index >= Macros.Count;
        }

        #endregion
    }
}
