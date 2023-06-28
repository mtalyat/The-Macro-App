using System.Runtime.InteropServices;

namespace TheMacroApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // https://stackoverflow.com/questions/995195/how-can-i-make-a-net-windows-forms-application-that-only-runs-in-the-system-tra
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TheMacroApplicationContext ctx = new TheMacroApplicationContext();
            Application.Run(ctx);
            ctx.Dispose();
        }
    }

    // https://stackoverflow.com/questions/995195/how-can-i-make-a-net-windows-forms-application-that-only-runs-in-the-system-tra
    internal class TheMacroApplicationContext : ApplicationContext
    {
        public const string APP_NAME = "The Super Macro App";
        public const string APP_SYSTEM_NAME = "SuperMacroApp";// name that is safe to use in file system

        private NotifyIcon _trayIcon;
        private KeyboardHook _keyboardHook;
        private MainForm? _form;

        public TheMacroApplicationContext()
        {
            // create menu strip
            ContextMenuStrip strip = new ContextMenuStrip()
            {
                Name = APP_NAME
            };
            strip.Items.AddRange(new ToolStripItem[]
            {
                CreateToolStripMenuItem("Exit", "Exits the process.", (object? sender, EventArgs e) => Application.Exit())
            });

            // create tray icon we can interact with
            _trayIcon = new NotifyIcon
            {
                Visible = true,
                Text = APP_NAME,
                Icon = Resources.Icon,
                ContextMenuStrip = strip
            };
            _trayIcon.MouseClick += Open;

            // register hotkeys
            _keyboardHook = new KeyboardHook();
            _keyboardHook.KeyPressed += HotkeyPressed;
            _keyboardHook.RegisterHotKey(ModKeys.Control | ModKeys.Alt, Keys.M);
            _keyboardHook.RegisterHotKey(ModKeys.Control | ModKeys.Alt, Keys.D1);
            _keyboardHook.RegisterHotKey(ModKeys.Control | ModKeys.Alt, Keys.D2);
            _keyboardHook.RegisterHotKey(ModKeys.Control | ModKeys.Alt, Keys.D3);
            _keyboardHook.RegisterHotKey(ModKeys.Control | ModKeys.Alt, Keys.D4);
            _keyboardHook.RegisterHotKey(ModKeys.Control | ModKeys.Alt, Keys.D5);
            _keyboardHook.RegisterHotKey(ModKeys.Control | ModKeys.Alt, Keys.D6);
            _keyboardHook.RegisterHotKey(ModKeys.Control | ModKeys.Alt, Keys.D7);
            _keyboardHook.RegisterHotKey(ModKeys.Control | ModKeys.Alt, Keys.D8);
            _keyboardHook.RegisterHotKey(ModKeys.Control | ModKeys.Alt, Keys.D9);
            _keyboardHook.RegisterHotKey(ModKeys.Control | ModKeys.Alt, Keys.D0);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _keyboardHook.Dispose();
                _trayIcon.Dispose();
            }
        }

        private void HotkeyPressed(object? sender, KeyPressedEventArgs e)
        {
            switch (e.Key)
            {
                case Keys.M: ShowForm(); break;
                case Keys.D0: Manager.RunMacro(0); break;
                case Keys.D1: Manager.RunMacro(1); break;
                case Keys.D2: Manager.RunMacro(2); break;
                case Keys.D3: Manager.RunMacro(3); break;
                case Keys.D4: Manager.RunMacro(4); break;
                case Keys.D5: Manager.RunMacro(5); break;
                case Keys.D6: Manager.RunMacro(6); break;
                case Keys.D7: Manager.RunMacro(7); break;
                case Keys.D8: Manager.RunMacro(8); break;
                case Keys.D9: Manager.RunMacro(9); break;
                default:
                    MessageBox.Show($"Key {e.Key} not registered.");
                    break;
            }
        }

        private void Open(object? sender, MouseEventArgs e)
        {
            // only open on left click
            if (e.Button == MouseButtons.Left)
            {
                ShowForm();
            }
        }

        private ToolStripMenuItem CreateToolStripMenuItem(string text, string toolTip, Action<object?, EventArgs> onClick)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(text, null, onClick.Invoke)
            {
                ToolTipText = toolTip
            };
            return item;
        }

        private void ShowForm()
        {
            if (_form == null)
            {
                // create new form
                _form = new MainForm();
                _form.Show();
                _form.FormClosed += (object? sender, FormClosedEventArgs e) => { _form = null; };
            }
            else if (!_form.Visible)
            {
                // use existing form, show if not visible, or select if it is
                _form.Show();
            }
            _form.Activate();
        }
    }

    // https://stackoverflow.com/questions/2450373/set-global-hotkeys-using-c-sharp
    public sealed class KeyboardHook : IDisposable
    {
        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Represents the window that is used internally to get the messages.
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;

            public Window()
            {
                // create the handle for the window.
                this.CreateHandle(new CreateParams());
            }

            /// <summary>
            /// Overridden to get the notifications.
            /// </summary>
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // check if we got a hot key pressed.
                if (m.Msg == WM_HOTKEY)
                {
                    // get the keys.
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModKeys modifier = (ModKeys)((int)m.LParam & 0xFFFF);

                    // invoke the event to notify the parent.
                    if (KeyPressed != null)
                        KeyPressed(this, new KeyPressedEventArgs(modifier, key));
                }
            }

            public event EventHandler<KeyPressedEventArgs>? KeyPressed;

            #region IDisposable Members

            public void Dispose()
            {
                this.DestroyHandle();
            }

            #endregion
        }

        private Window _window = new Window();
        private int _currentId;

        public KeyboardHook()
        {
            // register the event of the inner native window.
            _window.KeyPressed += delegate (object? sender, KeyPressedEventArgs args)
            {
                if (KeyPressed != null)
                    KeyPressed(this, args);
            };
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        public void RegisterHotKey(ModKeys modifier, Keys key)
        {
            // increment the counter.
            _currentId = _currentId + 1;

            // register the hot key.
            if (!RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
                throw new InvalidOperationException("Couldn’t register the hot key.");
        }

        /// <summary>
        /// A hot key has been pressed.
        /// </summary>
        public event EventHandler<KeyPressedEventArgs>? KeyPressed;

        #region IDisposable Members

        public void Dispose()
        {
            // unregister all the registered hot keys.
            for (int i = _currentId; i > 0; i--)
            {
                UnregisterHotKey(_window.Handle, i);
            }

            // dispose the inner native window.
            _window.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        private ModKeys _modifier;
        private Keys _key;

        internal KeyPressedEventArgs(ModKeys modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public ModKeys Modifier
        {
            get { return _modifier; }
        }

        public Keys Key
        {
            get { return _key; }
        }
    }

    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    [Flags]
    public enum ModKeys : uint
    {
        Alt = 1,
        Control = 1 << 1,
        Shift = 1 << 2,
        Win = 1 << 3
    }
}