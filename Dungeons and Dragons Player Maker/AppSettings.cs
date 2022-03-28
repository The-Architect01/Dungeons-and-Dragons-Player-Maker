using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

using Dungeons_and_Dragons_Player_Maker.Homebrew;

namespace Dungeons_and_Dragons_Player_Maker {
    public partial class AppSettings : Form {
        public AppSettings() {
            InitializeComponent();
        }

        private void AppSettings_FormClosing(object sender, FormClosingEventArgs e) {
            var response = MessageBox.Show("Do you want to save your changes?", Text, MessageBoxButtons.YesNoCancel);
            if (response == DialogResult.Yes) {
                Save_Click(this, null);
            }
            if (response == DialogResult.Cancel) { e.Cancel = true; }
        }

        private void Save_Click(object sender, EventArgs e) {
            Engine.SaveData.SourceBooks.Clear();
            foreach (CheckBox cb in groupBox1.Controls.OfType<CheckBox>()) {
                Engine.SaveData.SourceBooks.Add(cb.Name, cb.Checked);
            }
            Engine.SaveData.Name = textBox1.Text;
            IO.SaveDataToDisk();
        }

        private void Revert_Click(object sender, EventArgs e) {
            textBox1.Text = Engine.SaveData.Name;
            foreach (CheckBox cb in groupBox1.Controls.OfType<CheckBox>()) {
                cb.Checked = Engine.SaveData.SourceBooks[cb.Name];
            }
        }

        private void AppSettings_Load(object sender, EventArgs e) {
            try {
                Revert_Click(this, null);
            } catch (KeyNotFoundException) {
                foreach (CheckBox cb in groupBox1.Controls.OfType<CheckBox>()) {
                    try {
                        Engine.SaveData.SourceBooks.Add(cb.Name, false);
                    } catch { }

                }

                Revert_Click(this, null);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Homebrew.HomebrewEngine HBE = new();
            HBE.FormClosed += delegate { Focus(); };
            HBE.Show();
        }

        private void hbwe_Click(object sender, EventArgs e) {
            string dest = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Custom.brew";
            File.Copy(IO.HomebrewPath, dest, true);
            MessageBox.Show("Homebrew has successfully been exported to your desktop.", "Homebrew Wizard");
        }

        private void hbwi_Click(object sender, EventArgs e) {
            FileInput.ShowDialog();
            try {
                Stream Hbrew = FileInput.OpenFile();
                Homebrew.Homebrew deser = null;
                try {
                    deser = JsonSerializer.Deserialize<Homebrew.Homebrew>(new StreamReader(Hbrew).ReadToEnd());
                } catch { } finally { Hbrew.Close(); }
                try {
                    Engine.Homebrew.HomebrewRaces = Homebrew.Homebrew.Merge(Engine.Homebrew.HomebrewRaces, deser.HomebrewRaces);
                    Engine.Homebrew.HomebrewClasses = Homebrew.Homebrew.Merge(Engine.Homebrew.HomebrewClasses, deser.HomebrewClasses);
                    Engine.Homebrew.HomebrewBackgrounds = Homebrew.Homebrew.Merge(Engine.Homebrew.HomebrewBackgrounds, deser.HomebrewBackgrounds);
                    MessageBox.Show("Homebrew has successfully been added to your homebrews.","Homebrew Wizard");
                } catch {
                    MessageBox.Show("Something went wrong importing this homebrew. It could not be added.", "Homebrew Wizard Error");
                }
            } catch (FileNotFoundException) {
                MessageBox.Show("Something is wrong with this homebrew. It cannot be opened.", "Homebrew Wizard Error");
            } catch (Exception) { }
        }
    }
}
