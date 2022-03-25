using System;
using System.IO;
using System.Windows.Forms;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
//using System.Runtime.Serialization;
using Dungeons_and_Dragons_Player_Maker.Player_Maker;

namespace Dungeons_and_Dragons_Player_Maker {
    public partial class MainMenu : Form {

        [Obsolete]
        public MainMenu() {
            InitializeComponent();
            pictureBox1.Load(ImageLocation.GetImage("SPLASH"));
            BackgroundImage = pictureBox1.Image;
            pictureBox1.Visible = false;
            Scale(.85f);
            CenterToScreen();
        }

        [Obsolete]
        private void MainMenu_Load(object sender, EventArgs e) {
            if (Engine.SaveData.Characters.Count != 0) {
                PrintOldCharacter.Enabled = true;
                CharactersCreated.Enabled = true;
                CharactersCreated.Items.Clear();
                CharactersCreated.Items.AddRange(Engine.SaveData.CharacterList);
            }
            UserName.Text = Engine.SaveData.Name;
        }

        private void UserName_TextChanged(object sender, EventArgs e) {
            Engine.SaveData.Name = UserName.Text;
            IO.SaveDataToDisk();
        }
        [Obsolete]
        private void NewCharacter_Click(object sender, EventArgs e) {
            if (AppSettings.Visible) { AppSettings.Focus(); return; }
            Hide();
            CreateCharacter createCharacter = new();
            createCharacter.ShowDialog();
            IO.SaveDataToDisk();
            //Engine.CheckSettings();
            Show();
        }

        //[Obsolete]
        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e) {
            IO.SaveDataToDisk();
            //Engine.SaveCharacters();
        }

        [Obsolete]
        private void PrintOldCharacter_Click(object sender, EventArgs e) {
            if (AppSettings.Visible) { AppSettings.Focus(); return; }
            try {
                PrintSheet ps = new(Engine.SaveData.Characters[CharactersCreated.Text]);
                ps.Show();
           } catch (Exception) {
                MessageBox.Show("Something is wrong with this character. It cannot be opened.","Character Wizard Error");
           }
        }

        [Obsolete]
        private void LoadCharacter_Click(object sender, EventArgs e) {
            if (AppSettings.Visible) { AppSettings.Focus(); return; }
            openFileDialog1.ShowDialog();
            try {
                Stream Character = openFileDialog1.OpenFile();
                PC loadedPC = null;
                try {
                    //    BinaryFormatter formatter = new();
                    //    loadedPC = (PC) formatter.Deserialize(Character);
                    loadedPC = JsonSerializer.Deserialize<PC>(new StreamReader(Character).ReadToEnd());
                } catch (Exception) {

                } finally { Character.Close(); }
                try {
                    PrintSheet ps = new(loadedPC);
                    ps.Show();
                } catch (Exception) {
                    MessageBox.Show("Something is wrong with this character. It cannot be opened.", "Character Wizard Error");
                }
            } catch (FileNotFoundException) {
                MessageBox.Show("Something is wrong with this character. It cannot be opened.", "Character Wizard Error");
            } catch (Exception) { }
        }

        [Obsolete]
        private void MainMenu_VisibleChanged(object sender, EventArgs e) {
            if (Engine.SaveData.Characters.Count != 0) {
                PrintOldCharacter.Enabled = true;
                CharactersCreated.Enabled = true;
                CharactersCreated.Items.Clear();
                CharactersCreated.Items.AddRange(Engine.SaveData.CharacterList);
            }
            UserName.Text = Engine.SaveData.Name;
        }

        Form AppSettings = new AppSettings();

        private void Settings_Click(object sender, EventArgs e) {
            try {
                AppSettings.FormClosed += delegate { Focus(); };
                AppSettings.Show();
            } catch (ObjectDisposedException) {
                AppSettings = new AppSettings();
                AppSettings.Show();
            }
        }
    }
}