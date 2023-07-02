using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheMacroApp
{
    /// <summary>
    /// Holds data for a hotkey combination, used for a macro.
    /// </summary>
    public class MacroKey
    {
        /// <summary>
        /// The text to display if the hotkey is invalid (unable to be registered).
        /// </summary>
        [JsonIgnore]
        public const string INVALID_TEXT = "INVALID";

        /// <summary>
        /// The text to display if the hotkey is valid (able to be registered).
        /// </summary>
        [JsonIgnore]
        public const string VALID_TEXT = "VALID";

        /// <summary>
        /// The key to be pressed on the keyboard.
        /// </summary>
        [JsonInclude]
        public Keys Key;

        /// <summary>
        /// The modifiers to be holding down when the key is pressed.
        /// </summary>
        [JsonInclude]
        public ModKeys Modifiers;

        /// <summary>
        /// The ID of the hotkey once it has been registed. This will be -1 if it is not registed.
        /// </summary>
        [JsonIgnore]
        private int _id;

        /// <summary>
        /// Is the hotkey registered? Does Windows recoginize it as a hotkey?
        /// </summary>
        [JsonIgnore]
        public bool IsRegistered => _id != -1;

        /// <summary>
        /// Creates an empty macro key.
        /// </summary>
        public MacroKey()
        {
            Key = Keys.None;
            Modifiers = ModKeys.None;
            _id = -1;
        }

        public MacroKey(Keys key, ModKeys mod)
        {
            Key = key;
            Modifiers = mod;
        }

        /// <summary>
        /// Creates a macro key from the given keyboard event.
        /// </summary>
        /// <param name="e"></param>
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

        #region Values

        /// <summary>
        /// Sets the modifiers for this hotkey.
        /// </summary>
        /// <param name="alt">Should the alt key be pressed or not?</param>
        /// <param name="ctrl">Should the control key be pressed or not?</param>
        /// <param name="shift">Should the shift key be pressed or not?</param>
        /// <param name="win">Should the Windows key be pressed or not?</param>
        public void SetModifiers(bool alt, bool ctrl, bool shift, bool win)
        {
            Modifiers = 
                (alt ? ModKeys.Alt : ModKeys.None) |
                (ctrl ? ModKeys.Ctrl: ModKeys.None) |
                (shift ? ModKeys.Shift: ModKeys.None) |
                (win ? ModKeys.Win: ModKeys.None);
        }

        #endregion

        #region Registration

        /// <summary>
        /// Checks if this hotkey can be registered on Windows (checks if it is valid or not).
        /// </summary>
        /// <returns>True if the hotkey is valid.</returns>
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

        /// <summary>
        /// Assuming the key combination has changed, the hotkey will be unregisted, and then registered again, with the new data.
        /// </summary>
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

        /// <summary>
        /// Registers the hotkey with Windows.
        /// When the key combination is pressed, Windows will recognize that it belongs to this application.
        /// </summary>
        /// <returns>True if the hotkey is registered.</returns>
        public bool Register()
        {
            if (Modifiers == ModKeys.None || Key == Keys.None)
            {
                // if no modifiers or no key, cannot register
                return false;
            }

            if (MacroApplicationContext.ActiveContext == null)
            {
                // no context to register in
                return false;
            }

            if(IsRegistered)
            {
                return true;
            }

            try
            {
                _id = MacroApplicationContext.ActiveContext.KeyboardHook.RegisterHotKey(Modifiers, Key);
            }
            catch
            {
                // could not register
                return false;
            }

            // did register
            return true;
        }
        
        /// <summary>
        /// Unregisters the hotkey from Windows.
        /// Nothing will happen if the hotkey combination is pressed now.
        /// </summary>
        /// <returns>True if the hotkey is not registered.</returns>
        public bool UnRegister()
        {
            if (MacroApplicationContext.ActiveContext == null)
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
                MacroApplicationContext.ActiveContext.KeyboardHook.UnregisterHotKey(_id);

                _id = -1;
            } catch
            {
                // could not unregister
                return false;
            }

            // unregistered
            return true;
        }

        #endregion

        /// <summary>
        /// Checks if this MacroKey is equal to the given object.
        /// </summary>
        /// <param name="obj">The object to check against.</param>
        /// <returns>True if the object values are the same as this MacroKey.</returns>
        public override bool Equals(object? obj)
        {
            return obj is MacroKey key && key.Key == Key && key.Modifiers == Modifiers;
        }

        /// <summary>
        /// Generates a hash code for this MacroKey.
        /// </summary>
        /// <returns>The hash code.</returns>
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
