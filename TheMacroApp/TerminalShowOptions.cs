using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMacroApp
{
    /// <summary>
    /// Options for what to do with the terminal when a macro is ran.
    /// </summary>
    public enum TerminalShowOptions : int
    {
        /// <summary>
        /// Hide the terminal the whole time.
        /// </summary>
        Hide,

        /// <summary>
        /// Show the terminal the whole time.
        /// </summary>
        Show
    }
}
