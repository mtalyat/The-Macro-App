using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheMacroApp
{
    public class MacroKey
    {
        [JsonIgnore]
        public const string INVALID_TEXT = "INVALID";
        [JsonIgnore]
        public const string VALID_TEXT = "VALID";

        [JsonInclude]
        public Keys Key;
        [JsonInclude]
        public ModKeys Modifiers;
        [JsonIgnore]
        private int _id;
        [JsonIgnore]
        public bool IsRegistered => _id != -1;

        public MacroKey()
        {
            Key = Keys.None;
            Modifiers = ModKeys.None;
            _id = -1;
        }

        public MacroKey(KeyPressedEventArgs e)
        {
            Key = e.Key;
            Modifiers = e.Modifier;
            _id = -1;
        }

        ~MacroKey()
        {
            // if registered, unregister before deconstruction
            if(IsRegistered)
            {
                UnRegister();
            }
        }

        public void SetModifiers(bool alt, bool ctrl, bool shift, bool win)
        {
            Modifiers = 
                (alt ? ModKeys.Alt : ModKeys.None) |
                (ctrl ? ModKeys.Ctrl: ModKeys.None) |
                (shift ? ModKeys.Shift: ModKeys.None) |
                (win ? ModKeys.Win: ModKeys.None);
        }

        public bool CanRegister()
        {
            if(Register())
            {
                // could register, so unregister first
                UnRegister();
                return true;
            }

            return false;
        }

        public void UpdateRegistration()
        {
            // if already registered, unregister first
            if(IsRegistered)
            {
                UnRegister();
            }

            // now register with new keys
            Register();
        }

        public bool Register()
        {
            // if no modifiers or no key, cannot register
            if (Modifiers == ModKeys.None || Key == Keys.None)
            {
                return false;
            }

            if (TheMacroApplicationContext.ActiveContext == null)
            {
                // no context to register in
                return false;
            }

            try
            {
                _id = TheMacroApplicationContext.ActiveContext.KeyboardHook.RegisterHotKey(Modifiers, Key);
            }
            catch
            {
                // could not register
                return false;
            }

            // did register
            return true;
        }
        
        public bool UnRegister()
        {
            if (TheMacroApplicationContext.ActiveContext == null)
            {
                // no context to register in
                return false;
            }

            if(_id == -1)
            {
                // not registered
                return true;
            }

            try
            {
                TheMacroApplicationContext.ActiveContext.KeyboardHook.UnregisterHotKey(_id);

                _id = -1;
            } catch
            {
                // could not unregister
                return false;
            }

            // unregistered
            return true;
        }

        public override bool Equals(object? obj)
        {
            return obj is MacroKey key && key.Key == Key && key.Modifiers == Modifiers;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode() ^ Modifiers.GetHashCode();
        }

        public static bool operator ==(MacroKey left, MacroKey right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MacroKey left, MacroKey right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            // no modifiers: no key combo
            if(Modifiers == ModKeys.None)
            {
                return INVALID_TEXT;
            }

            // print in order of human readability:
            // windows control alt shift key
            StringBuilder sb = new StringBuilder();
            if (Modifiers.HasFlag(ModKeys.Win)) sb.Append("Win + ");
            if (Modifiers.HasFlag(ModKeys.Ctrl)) sb.Append("Ctrl + ");
            if (Modifiers.HasFlag(ModKeys.Alt)) sb.Append("Alt + ");
            if (Modifiers.HasFlag(ModKeys.Shift)) sb.Append("Shift + ");
            sb.Append(Key.ToString());

            return sb.ToString();
        }
    }
}
