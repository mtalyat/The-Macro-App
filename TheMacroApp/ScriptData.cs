using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheMacroApp
{
    internal class ScriptData : IComparable<ScriptData>
    {
        public const string TEMPLATE_FILE = "{file}";
        public const string TEMPLATE_ARGS = "{args}";
        private const string DEFAULT_FORMAT = $"{TEMPLATE_FILE} {TEMPLATE_ARGS}";

        [JsonInclude]
        public string Name { get; set; }
        [JsonInclude]
        public string[] Extensions { get; private set; }
        [JsonInclude]
        public string ExecutablePath { get; set; }
        [JsonInclude]
        public string Format { get; set; }
        [JsonInclude]
        public bool ShowTerminal { get; set; }

        public ScriptData(string name = "")
        {
            Name = name;
            Extensions = Array.Empty<string>();
            ExecutablePath = string.Empty;
            Format = DEFAULT_FORMAT;
            ShowTerminal = false;
        }

        public void SetExtensions(string extensions)
        {
            // nothing provided
            if(string.IsNullOrWhiteSpace(extensions))
            {
                Extensions = Array.Empty<string>();
                return;
            }

            // something provided
            Extensions = extensions.Split(' ').Select(s =>
            {
                if(!s.StartsWith('.'))
                {
                    return "." + s;
                } else
                {
                    return s;
                }
            }).ToArray();
        }

        public string GetExtensions()
        {
            return string.Join(" ", Extensions);
        }

        public bool ContainsExtension(string extension)
        {
            foreach(string e in Extensions)
            {
                if(e == extension)
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
