using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Dungeons_and_Dragons_Player_Maker.Properties;

namespace Dungeons_and_Dragons_Player_Maker {
    public partial class AppSettings : Form {
        public AppSettings() {
            InitializeComponent();
        }

        private void AppSettings_FormClosing(object sender, FormClosingEventArgs e) {
           // if (string.IsNullOrEmpty(textBox1.Text)) { MessageBox.Show("You need to fill out all fields!"); return; }
            var response = MessageBox.Show("Do you want to save your changes?", Text, MessageBoxButtons.YesNoCancel);
            if(response == DialogResult.Yes) {
                Settings.Default.SourceBooks.Clear();
                foreach(CheckBox cb in Controls.OfType<CheckBox>()) {
                    if (cb.Checked) { Settings.Default.SourceBooks.Add(cb.Name); }
                }
                Settings.Default.Name = textBox1.Text;
            } 
            if (response == DialogResult.Cancel){e.Cancel = true;}
        }

        private void Save_Click(object sender, EventArgs e) {
            Settings.Default.SourceBooks.Clear();
            foreach (CheckBox cb in Controls.OfType<CheckBox>()) {
                if (cb.Checked) { Settings.Default.SourceBooks.Add(cb.Name); }
            }
            Settings.Default.Name = textBox1.Text;
        }

        private void Revert_Click(object sender, EventArgs e) {
            textBox1.Text = Settings.Default.Name;
            foreach(CheckBox cb in Controls.OfType<CheckBox>()) {
                cb.Checked = Settings.Default.SourceBooks.Contains(cb.Name);
            }
        }
    }
}
