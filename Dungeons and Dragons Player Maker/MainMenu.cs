using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Dungeons_and_Dragons_Player_Maker {
    public partial class MainMenu : Form {

        [Obsolete]
        public MainMenu() {
            InitializeComponent();
            Scale(.85f);
            CenterToScreen();
        }

        private void MainMenu_Load(object sender, EventArgs e) {
            if (Engine.Characters.Count != 0) {
                PrintOldCharacter.Enabled = true;
                CharactersCreated.Enabled = true;
                CharactersCreated.Items.Clear();
                CharactersCreated.Items.AddRange(Engine.CharacterList);
            }
            UserName.Text = Properties.Settings.Default.Name;
        }

        private void UserName_TextChanged(object sender, EventArgs e) {
            Properties.Settings.Default.Name = UserName.Text;
            Properties.Settings.Default.Save();
        }
        [Obsolete]
        private void NewCharacter_Click(object sender, EventArgs e) {
            Hide();
            CreateCharacter createCharacter = new();
            createCharacter.ShowDialog();
            Engine.CheckSettings();
            Show();
        }

        [Obsolete]
        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Engine.SaveCharacters();
        }

        private void PrintOldCharacter_Click(object sender, EventArgs e) {
           try {
                PrintSheet ps = new(Engine.Characters[CharactersCreated.Text]);
                ps.Show();
           } catch (Exception) {
                MessageBox.Show("Something is wrong with this character. It cannot be opened.","Character Wizard Error");
           }
        }

        [Obsolete]
        private void LoadCharacter_Click(object sender, EventArgs e) {
            openFileDialog1.ShowDialog();
            try {
                Stream Character = openFileDialog1.OpenFile();
                PC loadedPC = null;
                try {
                    BinaryFormatter formatter = new();
                    loadedPC = (PC) formatter.Deserialize(Character);
                } catch (SerializationException) {

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

        private void MainMenu_VisibleChanged(object sender, EventArgs e) {
            if (Engine.Characters.Count != 0) {
                PrintOldCharacter.Enabled = true;
                CharactersCreated.Enabled = true;
                CharactersCreated.Items.Clear();
                CharactersCreated.Items.AddRange(Engine.CharacterList);
            }
            UserName.Text = Properties.Settings.Default.Name;
        }
    }
}
