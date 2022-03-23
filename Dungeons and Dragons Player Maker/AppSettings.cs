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
            var response = MessageBox.Show("Do you want to save your changes?", Text, MessageBoxButtons.YesNoCancel);
            if(response == DialogResult.Yes) {
                Save_Click(this,null);
            } 
            if (response == DialogResult.Cancel){e.Cancel = true;}
        }

        private void Save_Click(object sender, EventArgs e) {
            Engine.SaveData.SourceBooks.Clear();
            foreach (CheckBox cb in Controls.OfType<CheckBox>()) {
                Engine.SaveData.SourceBooks.Add(cb.Name,cb.Checked);
            }
            Engine.SaveData.Name = textBox1.Text;
        }

        private void Revert_Click(object sender, EventArgs e) {
            textBox1.Text = Engine.SaveData.Name;
            foreach(CheckBox cb in Controls.OfType<CheckBox>()) {
                cb.Checked = Engine.SaveData.SourceBooks[cb.Name];
            }
        }

        private void AppSettings_Load(object sender, EventArgs e) {
            Revert_Click(this,null);
        }

    }
}
