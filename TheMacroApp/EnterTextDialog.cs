using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheMacroApp
{
    public partial class EnterTextDialog : Form
    {
        public string Content => InputRichTextBox.Text;

        public EnterTextDialog(string title, string defaultText = "")
        {
            InitializeComponent();

            base.Text = title;
            InputRichTextBox.Text = defaultText;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
