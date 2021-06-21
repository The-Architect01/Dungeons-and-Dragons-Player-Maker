using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker {
    public partial class CreateCharacter : Form {

        string Race = "";
        string Languages = "";
        string Prof = "";
        string Prof2 = "";
        string Class = "";
        string FullClass = "";
        string Background = "";

        readonly Label[] RaceName;

        static readonly string[] Races       = { "Dwarf","Elf","Halfling","Human","Dragonborn","Gnome","Half-Elf","Half-Orc","Tiefling" };
        static readonly string[] Classes     = { };
        static readonly string[] Backgrounds = { };

        static readonly string[] LANGUAGES = { "Common","Dwarvish","Elvish","Giant","Gnomish","Goblin","Halfling","Orc","Abyssal","Celestial",
        "Deep Speech","Draconic","Infernal","Primordial","Sylvan","Undercommon"};
        static readonly string[] SKILLS = { "Athletics","Acrobatics","Sleight of Hand","Stealth","Arcana","History","Investigation","Nature","Religion",
        "Animal Handling","Insight","Medicine","Perception", "Survival","Deception","Intimidation","Performance","Persuasion"};
        static readonly Dictionary<string, int> RacesBonus = new Dictionary<string, int>() { {"Human-Variant",2 }, { "Half-Elf-Natural", 2 } };


        public CreateCharacter() {
            InitializeComponent();
            RaceName = new Label[] { R1, R2, R3, R4, R5, R6 };
            RaceSkill1.Items.AddRange(SKILLS);
            RaceSkill2.Items.AddRange(SKILLS);
            RaceLang.Items.AddRange(LANGUAGES);
        }

        private void CreateCharacter_Load(object sender, EventArgs e) {
            RacePreview.Image = Dungeons_and_Dragons_Player_Maker.Races.Human;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e) {
            if (Race == "" || (Races_SubRace.Contains(Race) && !SubRaces.Items.Contains(SubRaces.Text))) { MessageBox.Show("You haven't selected a valid race!"); e.Cancel = true; }
            //    if (Class == "" || SubClasses.Text == "Select One") { MessageBox.Show("You haven't selected a valid class!"); e.Cancel = true; }
            //     if (Background == "") { MessageBox.Show("You haven't selected a valid background!");e.Cancel = true; }
        }

        #region Races -- Page 1
        static readonly List<string> Races_SubRace  = new List<string>() { "Dwarf", "Elf","Halfling", "Human","Dragonborn","Gnome","Half-Elf" };
        static readonly string[] DWARF_SUBRACE      = { "Hill", "Mountain", "Deep" };
        static readonly string[] ELF_SUBRACE        = { "High", "Wood", "Drow" };
        static readonly string[] HALFLING_SUBRACE   = { "Lightfoot", "Stout" };
        static readonly string[] HUMAN_SUBRACE      = { "Natural", "Variant" };
        static readonly string[] DRAGONBORN_SUBRACE = { "Black", "Blue","Brass","Bronze","Copper","Gold","Green","Red","Silver","White" };
        static readonly string[] GNOME_SUBRACE      = { "Forest","Rock" };
        static readonly string[] HALF_ELF_SUBRACE   = { "Natural", "Variant" };

        static readonly List<string> AdditionalRaceLang = new List<string>() { "Human", "Half-Elf" };
        static readonly List<string> AdditionalRaceSkill1 = new List<string>() { "Half-Elf" };
        static readonly List<string> AdditionalRaceSkill2 = new List<string>() { "Half-Elf" };

        int pos = 0;

        private void SubRaces_SelectedValueChanged(object sender, EventArgs e) { Languages = ""; Prof = ""; Prof2 = ""; updateInfo(Race); }

        private void Race_Hover(object sender, EventArgs e) {
            if (Race != "") {
                RacePreview.Image = (Image)Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetObject(Race);
                updateInfo(Race);
                return;
            } else {
                RacePreview.Image = (Image)Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetObject(((Label)sender).Text);
                updateInfo(((Label)sender).Text);
            }
        }

        private void Race_Click(object sender, EventArgs e) {
            if (!Race.SequenceEqual(((Label)sender).Text)) { Languages = ""; Prof = ""; Prof2 = ""; updateInfo(((Label)sender).Text); }
            Race = ((Label)sender).Text;
            RacePreview.Image = (Image)Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetObject(Race);
            updateInfo(Race);
            if (Races_SubRace.Contains(Race)) { 
                SubRaces.Enabled = true;
                object[] items = null;
                switch (Race) {
                    case "Dwarf":
                        items = DWARF_SUBRACE;
                        break;
                    case "Elf":
                        items = ELF_SUBRACE;
                        break;
                    case "Halfling":
                        items = HALFLING_SUBRACE;
                        break;
                    case "Human":
                        items = HUMAN_SUBRACE;
                        break;
                    case "Dragonborn":
                        items = DRAGONBORN_SUBRACE;
                        break;
                  case "Gnome":
                        items = GNOME_SUBRACE;
                        break;
                    case "Half-Elf":
                        items = HALF_ELF_SUBRACE;
                        break;
                }
                SubRaces.Items.Clear();
                SubRaces.Items.AddRange(items);
                SubRaces.SelectedIndex = 0;
            } else {
                SubRaces.Enabled = false;
                SubRaces.Items.Clear();
                SubRaces.Text = "Normal";
            }
            if (AdditionalRaceLang.Contains(Race))   { RaceLang.Text = "Select One"; RaceLang.Enabled = true; } else { RaceLang.Text = ""; RaceLang.Enabled = false; }
            if (AdditionalRaceSkill1.Contains(Race) && (Race == "Half-Elf" && !SubRaces.Text.SequenceEqual("Variant")))
                { RaceSkill1.Text = "Select One"; RaceSkill1.Enabled = true; } else { RaceSkill1.Text = ""; RaceSkill1.Enabled = false; }
            if (AdditionalRaceSkill2.Contains(Race) && (Race == "Half-Elf" && !SubRaces.Text.SequenceEqual("Variant"))) 
                { RaceSkill2.Text = "Select One"; RaceSkill2.Enabled = true; } else { RaceSkill2.Text = ""; RaceSkill2.Enabled = false; }
        }

        private void updateInfo(string race) {
            string[] info = Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(race + "-" + SubRaces.Text).Split("_");
            string final = "";
            if(info[0] != "0") { final = final + "STR: " + info[0] + " "; }
            if(info[1] != "0") { final = final + "DEX: " + info[1] + " "; }
            if(info[2] != "0") { final = final + "CON: " + info[2] + " "; }
            if(info[3] != "0") { final = final + "WIS: " + info[3] + " "; }
            if(info[4] != "0") { final = final + "INT: " + info[4] + " "; }
            if(info[5] != "0") { final = final + "CHA: " + info[5] + " "; }
            if(final != "") { final = final + "\n"; }
            final = final + "Speed: " + info[6] + "\n";
            final = final + "Size: " + info[7] + "\n";
            final = Languages != "" ? final + Languages + "\n" : final + "Languages: " + info[8] + "\n";
            final = Prof2 != "" ? final + Prof2 + "\n" :
                    Prof != "" ? final + Prof + "\n" :final + "Proficiencies: " + info[9] + "\n";
            final = final + "Notes: " + info[10];
            Info.Text = final;
        }

        private void updateVisRaces() {
            int j = pos;
            foreach(Label r in RaceName) {
                r.Text = Races[j];
                if(j > Races.Length - 2) { j = 0; } else { j ++; }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            pos--;
            if (pos < 0) { pos = Races.Length - 1; }
            updateVisRaces();
        }

        private void button2_Click(object sender, EventArgs e) {
            pos++;
            if (pos > Races.Length - 1) { pos = 0; }
            updateVisRaces();
        }
        
        private void RaceLang_SelectedIndexChanged(object sender, EventArgs e) {
            string defaultLang = Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(Race + "-" + SubRaces.Text).Split("_")[8];
            string[] data = Info.Text.Split("\n");
            string[] languages = data[3].Split(defaultLang);
            languages[1] = RaceLang.Text;
            data[3] = languages[0] + defaultLang + ", " + languages[1];
            Info.Text = data[0] + "\n" + data[1] + "\n" + data[2] + "\n" + data[3] + "\n" + data[4] + "\n" + data[5];
            Languages = data[3];
        }
        
        private void RaceSkill1_SelectedIndexChanged(object sender, EventArgs e) {
            string defaultProf = Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(Race + "-" + SubRaces.Text).Split("_")[9];
            string[] data = Info.Text.Split("\n");
            if (defaultProf.SequenceEqual("None")) {
                data[4] = "Proficiencies: " + RaceSkill1.Text;
                RaceSkill2.Text = "Select One";
            }else {
                string[] profs = data[4].Split(defaultProf);
                profs[1] = RaceSkill1.Text;
                data[4] = profs[0] + defaultProf + ", " + profs[1];
            }
            Info.Text = data[0] + "\n" + data[1] + "\n" + data[2] + "\n" + data[3] + "\n" + data[4] + "\n" + data[5];
            Prof = data[4];
        }
        
        private void RaceSkill2_SelectedIndexChanged(object sender, EventArgs e) {
            string[] data = Info.Text.Split("\n");
            string[] prof2 = data[4].Split(Prof);
            prof2[1] = RaceSkill2.Text;
            data[4] = prof2[0] + Prof + ", " + prof2[1];
            Info.Text = data[0] + "\n" + data[1] + "\n" + data[2] + "\n" + data[3] + "\n" + data[4] + "\n" + data[5];
            Prof2 = data[4];
        }
        #endregion
        #region Classes -- Page 2
        #endregion
        #region Background -- Page 3
        #endregion
        #region Confirmation -- Page 4
        #endregion
        
        
    }
}
