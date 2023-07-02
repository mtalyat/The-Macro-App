using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheMacroApp
{
    /// <summary>
    /// Holds data about a type of script.
    /// </summary>
    internal class ScriptData : IComparable<ScriptData>
    {
        /// <summary>
        /// The template for the file path within the command format.
        /// </summary>
        public const string TEMPLATE_FILE = "{file}";
        /// <summary>
        /// The template for the command line arguments within the command format.
        /// </summary>
        public const string TEMPLATE_ARGS = "{args}";
        /// <summary>
        /// The default format for the command line format.
        /// </summary>
        public const string DEFAULT_FORMAT = $"{TEMPLATE_FILE} {TEMPLATE_ARGS}";

        /// <summary>
        /// The name of the script.
        /// </summary>
        [JsonInclude]
        public string Name { get; set; }

        /// <summary>
        /// The list of extensions for this type of script.
        /// </summary>
        [JsonInclude]
        public string[] Extensions { get; private set; }

        /// <summary>
        /// The executable path, if applicable.
        /// </summary>
        [JsonInclude]
        public string ExecutablePath { get; set; }

        /// <summary>
        /// The format to put the command line command into.
        /// </summary>
        [JsonInclude]
        public string Format { get; set; }

        /// <summary>
        /// Creates a new script data.
        /// </summary>
        /// <param name="name"></param>
        public ScriptData()
        {
            Name = string.Empty;
            Extensions = Array.Empty<string>();
            ExecutablePath = string.Empty;
            Format = DEFAULT_FORMAT;
        }

        /// <summary>
        /// Creates a new script data.
        /// </summary>
        public ScriptData(string name, string[]? extensions = null, string executablePath = "explorer.exe", string format = DEFAULT_FORMAT)
        {
            Name = name;
            Extensions = extensions ?? Array.Empty<string>();
            ExecutablePath = executablePath;
            Format = format;
        }

        /// <summary>
        /// Sets the list of extensions by splitting the given string using spaces.
        /// </summary>
        /// <param name="extensions">The list of extensions in a string.</param>
        public void SetExtensions(string extensions)
        {
            // nothing provided
            if(string.IsNullOrWhiteSpace(extensions))
            {
                Extensions = Array.Empty<string>();
                return;
            }

            // something provided
            Extensions = extensions.ToLower().Split(' ').Select(s =>
            {
                if(!s.StartsWith('.'))
                {
                    return "." + s;
                } else
                {
                    return s;
                }
            }).ToHashSet().ToArray(); // eliminate duplicates?
        }

        /// <summary>
        /// Gets the list of extensions as a string.
        /// </summary>
        /// <returns>A string with the list of extensions, separated by spaces.</returns>
        public string GetExtensions()
        {
            return string.Join(" ", Extensions);
        }

        /// <summary>
        /// Checks of this script data contains the given extension.
        /// </summary>
        /// <param name="extension">The extension to check.</param>
        /// <returns>True if this script data contains the given extension, otherwise false.</returns>
        public bool ContainsExtension(string extension)
        {
            foreach(string e in Extensions)
            {
                if(e == extension.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(ScriptData? other)
        {
            if(other == null)
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }
    }
}
