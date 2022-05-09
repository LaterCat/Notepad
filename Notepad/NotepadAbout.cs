using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Notepad
{
    public partial class NotepadAbout : Form
    {
        public NotepadAbout()
        {
            InitializeComponent();
        }

        private void BackNotepad_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void link_Notepad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.bilibili.com/") { UseShellExecute = true });
        }
    }
}
