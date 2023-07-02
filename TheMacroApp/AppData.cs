using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheMacroApp
{
    /// <summary>
    /// Holds data for the entire application.
    /// </summary>
    internal class AppData
    {
        /// <summary>
        /// The list of loaded macro datas.
        /// </summary>
        [JsonInclude]
        public List<MacroData> Macros { get; private set; } = new List<MacroData>();

        /// <summary>
        /// The list of loaded script type datas.
        /// </summary>
        [JsonInclude]
        public List<ScriptData> Scripts { get; private set; } = new List<ScriptData>();

        /// <summary>
        /// The script data to be used if no other scripts can apply.
        /// </summary>
        [JsonIgnore]
        public static readonly ScriptData DefaultScript = new ScriptData("Default", new string[0], "explorer.exe", ScriptData.DEFAULT_FORMAT);

        /// <summary>
        /// The settings for this application.
        /// </summary>
        [JsonInclude]
        public SettingsData Settings = new SettingsData();

        #region Managing

        /// <summary>
        /// Sets the macro at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void SetMacro(int index, MacroData data)
        {
            // if invalid index, do nothing
            if (IsInvalidIndex(index))
            {
                return;
            }

            Macros[index] = data;
        }

        /// <summary>
        /// Adds a new macro to the list.
        /// </summary>
        /// <param name="data">The new macro to add.</param>
        public void AddMacro(MacroData data)
        {
            Macros.Add(data);
        }

        /// <summary>
        /// Deletes the macro at the given index.
        /// </summary>
        /// <param name="index">The index to remove the macro at.</param>
        public void DeleteMacro(int index)
        {
            Macros.RemoveAt(index);
        }

        /// <summary>
        /// Gets the macro at the given index.
        /// </summary>
        /// <param name="index">The index of the macro to get.</param>
        /// <returns>The macro at the given index, or null if the index is out of range.</returns>
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

        /// <summary>
        /// Finds the macro with the given key.
        /// </summary>
        /// <param name="key">The key that belongs to the macro data.</param>
        /// <returns>The macro data that has the same key as the given key, or null if not found.</returns>
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

        /// <summary>
        /// Updates the given script data.
        /// </summary>
        /// <param name="data">The script data to update.</param>
        /// <param name="addIfNotFound">If true, and the script data was not found, add it.</param>
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

        /// <summary>
        /// Deletes the script data with the given name.
        /// </summary>
        /// <param name="name">The name of the script data to delete.</param>
        public void DeleteScript(string name)
        {
            int index = Scripts.FindIndex(s => s.Name == name);
            if (index != -1)
            {
                Scripts.RemoveAt(index);
            }
        }

        /// <summary>
        /// Renames a script data.
        /// </summary>
        /// <param name="oldName">The existing name of the script data.</param>
        /// <param name="newName">The new name of the script data.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Finds the script data with the given extension type.
        /// </summary>
        /// <param name="extension">The extension type to use to search for the script data.</param>
        /// <returns>The script data that contains the given extension, or null if not found.</returns>
        public ScriptData FindScript(string extension)
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
            return DefaultScript;
        }

        #endregion

        #region Saving and Loading

        /// <summary>
        /// Saves this AppData to a file at the given path.
        /// </summary>
        /// <param name="path">The location to save the AppData at.</param>
        public void Save(string path)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(this));
        }

        /// <summary>
        /// Loads an instance of AppData from the file at the given path.
        /// </summary>
        /// <param name="path">The location to load the AppData from.</param>
        /// <returns>The AppData from that location, or null if the file did not exist or was in the incorrect format.</returns>
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
        
        /// <summary>
        /// Checks if the given index is out of range of the macros.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns>True if the index is out of range, otherwise false.</returns>
        private bool IsInvalidIndex(int index)
        {
            return index < 0 || index >= Macros.Count;
        }

        #endregion
    }
}
