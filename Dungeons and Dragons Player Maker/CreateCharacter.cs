using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

        readonly Label[] RaceName;
        readonly Label[] ClassName;
        readonly Label[] BackgroundName;

        static readonly string[] Races = { "Dwarf", "Elf", "Halfling", "Human", "Dragonborn", "Gnome", "Half-Elf", "Half-Orc", "Tiefling" };
        static readonly string[] Classes = { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
        static readonly string[] Backgrounds = { };

        static readonly string[] LANGUAGES = { "Common","Dwarvish","Elvish","Giant","Gnomish","Goblin","Halfling","Orc","Abyssal","Celestial",
        "Deep Speech","Draconic","Infernal","Primordial","Sylvan","Undercommon"};
        static readonly string[] SKILLS = { "Athletics","Acrobatics","Sleight of Hand","Stealth","Arcana","History","Investigation","Nature","Religion",
        "Animal Handling","Insight","Medicine","Perception", "Survival","Deception","Intimidation","Performance","Persuasion"};
        static readonly Dictionary<string, int> RacesBonus = new Dictionary<string, int>() { { "Human-Variant", 2 }, { "Half-Elf-Natural", 2 } };


        public CreateCharacter() {
            InitializeComponent();
            RaceName = new Label[] { R1, R2, R3, R4, R5, R6 };
            RaceSkill1.Items.AddRange(SKILLS);
            RaceSkill2.Items.AddRange(SKILLS);
            RaceLang.Items.AddRange(LANGUAGES);
            ClassName = new Label[] { C1, C2, C3, C4, C5, C6 };
        }

        private void CreateCharacter_Load(object sender, EventArgs e) {
            RacePreview.Image = Dungeons_and_Dragons_Player_Maker.Races.Human;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
        }

        private void tabControl1_ControlAdded(object sender, ControlEventArgs e) {
            switch (e.Control) {
                //
            }
        }

        #region Races -- Page 1
        static readonly List<string> Races_SubRace = new List<string>() { "Dwarf", "Elf", "Halfling", "Human", "Dragonborn", "Gnome", "Half-Elf" };
        static readonly string[] DWARF_SUBRACE = { "Hill", "Mountain", "Deep" };
        static readonly string[] ELF_SUBRACE = { "High", "Wood", "Drow" };
        static readonly string[] HALFLING_SUBRACE = { "Lightfoot", "Stout" };
        static readonly string[] HUMAN_SUBRACE = { "Natural", "Variant" };
        static readonly string[] DRAGONBORN_SUBRACE = { "Black", "Blue", "Brass", "Bronze", "Copper", "Gold", "Green", "Red", "Silver", "White" };
        static readonly string[] GNOME_SUBRACE = { "Forest", "Rock" };
        static readonly string[] HALF_ELF_SUBRACE = { "Natural", "Variant" };

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
                SubRaces.Text = "Natural";
            }
            if (AdditionalRaceLang.Contains(Race)) { RaceLang.Text = "Select One"; RaceLang.Enabled = true; } else { RaceLang.Text = ""; RaceLang.Enabled = false; }
            if (AdditionalRaceSkill1.Contains(Race) && (Race == "Half-Elf" && !SubRaces.Text.SequenceEqual("Variant"))) { RaceSkill1.Text = "Select One"; RaceSkill1.Enabled = true; } else { RaceSkill1.Text = ""; RaceSkill1.Enabled = false; }
            if (AdditionalRaceSkill2.Contains(Race) && (Race == "Half-Elf" && !SubRaces.Text.SequenceEqual("Variant"))) { RaceSkill2.Text = "Select One"; RaceSkill2.Enabled = true; } else { RaceSkill2.Text = ""; RaceSkill2.Enabled = false; }
            if (!tabControl1.TabPages.Contains(tabPage2)) { tabControl1.TabPages.Add(tabPage2); }
        }

        private void updateInfo(string race) {
            try {
                string[] info = Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(race + "-" + SubRaces.Text).Split("_");
                string final = "";
                if (info[0] != "0") { final = final + "STR: " + info[0] + " "; }
                if (info[1] != "0") { final = final + "DEX: " + info[1] + " "; }
                if (info[2] != "0") { final = final + "CON: " + info[2] + " "; }
                if (info[3] != "0") { final = final + "WIS: " + info[3] + " "; }
                if (info[4] != "0") { final = final + "INT: " + info[4] + " "; }
                if (info[5] != "0") { final = final + "CHA: " + info[5] + " "; }
                if (final != "") { final = final + "\n"; }
                final = final + "Speed: " + info[6] + "\n";
                final = final + "Size: " + info[7] + "\n";
                final = Languages != "" ? final + Languages + "\n" : final + "Languages: " + info[8] + "\n";
                final = Prof2 != "" ? final + Prof2 + "\n" :
                        Prof != "" ? final + Prof + "\n" : final + "Proficiencies: " + info[9] + "\n";
                final = final + "Notes: " + info[10];
                Info.Text = final;
            } catch (Exception) {
                Info.Text = "No data found.";
            }
        }

        private void updateVisRaces() {
            int j = pos;
            foreach (Label r in RaceName) {
                r.Text = Races[j];
                if (j > Races.Length - 2) { j = 0; } else { j++; }
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
            } else {
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
        int posC = 0;
        string[] BARD_Subclasses = { "Lore", "Valor" };
        string[] BARBARIAN_Subclasses = { "Berserker", "Totem Warrior" };
        string[] CLERIC_Subclasses = { "Knowledge", "Life", "Light", "Nature", "Tempest", "Trickery", "War" };
        string[] DRUID_Subclasses = { "Circle of Land - Artic", "Circle of Land - Coast", "Circle of Land - Desert", "Circle of Land - Forest",
        "Circle of Land - Grassland", "Circle of Land - Mountain","Circle of Land - Swamp","Circle of Land - Underdark","Circle of the Moon"};
        string[] FIGHTER_Subclasses = { "Champion", "Battle Master", "Eldritch Knight" };
        string[] MONK_Subclasses = { "Way of the Open Hand", "Way of the Shadow", "Way of the Four Elements" };
        string[] PALADIN_Subclasses = { "Oath of Devotion", "Oath of the Ancients", "Oath of Vengeance" };
        string[] RANGER_Subclasses = { "Hunter", "Beast Master" };
        string[] ROGUE_Subclasses = { "Thief", "Assassin", "Arcane Trickster" };
        string[] SORCERER_Subclasses = { "Draconic Bloodline", "Wild Magic" };
        string[] WARLOCK_Subclasses = { "The Archfey", "The Fiend", "The Great Old One" };
        string[] WIZARD_Subclasses = { "Abjuration", "Conjuration", "Divination", "Enchantment", "Evocation", "Illusion", "Necromancy", "Transmuation" };
        string[] ARTIFICER_Subclasses = { };

        private void updateClass() {
            int j = posC;
            foreach (Label c in ClassName) {
                c.Text = Classes[j];
                if (j > Classes.Length - 2) { j = 0; } else { j++; }
            }
        }

        private void button4_Click(object sender, EventArgs e) { //UP
            posC--;
            if (posC < 0) { posC = Classes.Length - 1; }
            updateClass();
        }

        private void button3_Click(object sender, EventArgs e) { // Down
            posC++;
            if (posC > Classes.Length - 1) { posC = 0; }
            updateClass();
        }

        private void classClick(object sender, EventArgs e) {
            Class = ((Label)sender).Text;
            ClassPreview.Image = (Image)Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetObject(Class);
            SubClasses.Items.Clear();
            SubClasses.Items.AddRange((string[])this.GetType().GetField((Class.ToUpper() + "_Subclasses").ToString(),
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).GetValue(this));
            SubClasses.SelectedIndex = 0;
            classUpdate(Class, SubClasses.Text);
            if (!tabControl1.TabPages.Contains(tabPage3)) { tabControl1.TabPages.Add(tabPage3); }
        }

        private void classHover(object sender, EventArgs e) {
            if (Class != "") {
                ClassPreview.Image = (Image)Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetObject(Class);
                classUpdate(Class, SubClasses.Text);
            } else {
                ClassPreview.Image = (Image)Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetObject(((Label)sender).Text);
                classUpdate(((Label)sender).Text, "Select One");
            }
        }

        private void classUpdate(string classBase, string subclass) {
            string cLass = Class == "" ? classBase : Class;
            try {
                string[] baseClassStats = Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetString(cLass + "-Base").Split("_");
                BaseClass.Text = "";
                foreach (string item in baseClassStats) {
                    BaseClass.Text = BaseClass.Text + item + "\n";
                }
            } catch (Exception) { BaseClass.Text = "No Data Found"; }
            try {
                if (subclass.SequenceEqual("Select One")) { SubClass.Text = "No Data Found"; } else {
                    string[] subStats = Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetString(cLass + "-" + subclass).Split("_");
                    SubClass.Text = "";
                    foreach (string item in subStats) {
                        SubClass.Text = SubClass.Text + item + "\n";
                    }
                }
            } catch (Exception) { SubClass.Text = "No Data Found"; }
        }
        private void SubClasses_SelectedIndexChanged(object sender, EventArgs e) {
            classUpdate(Class, SubClasses.Text);
            tabControl1.TabPages.Add(tabPage5);
        }

        #endregion

        #region Background -- Page 3
        private void checkIfFinished() {
            if(Background.Text != "" && Personality.Text != "" && Ideal.Text !="" &&
               Bond.Text != "" && Flaw.Text != "") {
                tabControl1.TabPages.Add(tabPage5);
            }
        }
        #endregion

        #region Customize -- Page 4
        #endregion

        #region Confirmation -- Page 5
        #endregion

    }
}
