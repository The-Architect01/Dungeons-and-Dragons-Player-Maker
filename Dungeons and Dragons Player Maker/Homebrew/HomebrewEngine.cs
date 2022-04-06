using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker.Homebrew {
    public partial class HomebrewEngine : Form {
        public HomebrewEngine() {
            InitializeComponent();
            PopulateRaceArrays();
            PopulateClassArrays();
        }

        [Obsolete]
        private void HomebrewEngine_Load(object sender, EventArgs e) {
            Scale(.75f);
            CenterToScreen();
            #region Races
            Size.SelectedItem = "Medium";
            foreach(RadioButton rb in Stat2.Controls.OfType<RadioButton>()) { rb.CheckedChanged += UpdateStat2; };
            foreach(RadioButton rb in Stat1.Controls.OfType<RadioButton>()) { rb.CheckedChanged += UpdateStat1; };
            #endregion
            #region Backgrounds
            PopulateBGArray();
            #endregion
        }

        #region Races
        void PopulateRaceArrays() {
            Armor.Items.Clear();
            Armor.Items.AddRange(Engine.ARMORS);
            Lang.Items.Clear();
            Lang.Items.AddRange(Engine.LANGUAGES);
            Skills.Items.Clear();
            Skills.Items.AddRange(Engine.SKILLS);
            Tools.Items.Clear();
            Tools.Items.AddRange(Engine.TOOLS);
            Weapons.Items.Clear();
            Weapons.Items.AddRange(Engine.SIMPLE_WEAPONS);
            Weapons.Items.AddRange(Engine.MARTIAL_WEAPONS);
        }

        private void Speed_TextChanged(object sender, EventArgs e) {
            foreach(char character in Speed.Text.ToCharArray()) {
                if (!char.IsNumber(character)) {
                    MessageBox.Show("Please enter only numeric characters!");
                    Speed.Text = "30";
                }
            }
            if(Speed.Text.Length == 0) {
                MessageBox.Show("Please enter a valid speed!");
                Speed.Text = "30";
            }
        }

        void UpdateStat2(object sender, EventArgs e) {
            RadioButton selected = (RadioButton)sender;
            RadioButton op = (RadioButton)Stat1.Controls.Find(selected.Name.Substring(0, 3) + "1", true)[0];
            stat2bonus = selected.Name;
            if (selected.Checked) { op.Enabled = false;op.Checked = false; } else { op.Enabled = true; }
        }
        void UpdateStat1(object sender, EventArgs e) {
            RadioButton selected = (RadioButton)sender;
            RadioButton op = (RadioButton)Stat2.Controls.Find(selected.Name.Substring(0, 3) + "2", true)[0];
            stat1bonus = selected.Name;
            if (selected.Checked) { op.Enabled = false; op.Checked = false; } else { op.Enabled = true; }
        }

        string stat1bonus = string.Empty;
        string stat2bonus = string.Empty;

        private void button1_Click(object sender, EventArgs e) {
            try {
                HomebrewRace Race = new();
                if (string.IsNullOrWhiteSpace(RaceName.Text)) { throw new Exception("No Name Entered."); }
                if (string.IsNullOrWhiteSpace(Subrace.Text)) { Subrace.Text = "Natural"; }
                Race.Name = $"{RaceName.Text}:{Subrace.Text}";
                if (string.IsNullOrEmpty(stat2bonus) || string.IsNullOrEmpty(stat1bonus)) { throw new Exception("No Stat Bonuses."); }
                Race.StatBonus =
                    $"{(STR2.Checked ? "+2" : STR1.Checked ? "+1" : "0")}_" +
                    $"{(DEX2.Checked ? "+2" : DEX1.Checked ? "+1" : "0")}_" +
                    $"{(CON2.Checked ? "+2" : CON1.Checked ? "+1" : "0")}_" +
                    $"{(WIS2.Checked ? "+2" : WIS1.Checked ? "+1" : "0")}_" +
                    $"{(INT2.Checked ? "+2" : INT1.Checked ? "+1" : "0")}_" +
                    $"{(CHA2.Checked ? "+2" : CHA1.Checked ? "+1" : "0")}";

                if (Lang.SelectedItems.Count == 0) { throw new Exception("No Languages Selected"); }
                string Langs = "";
                foreach(string Language in Lang.SelectedItems) {
                    Langs += Language + ", ";
                }
                Race.Languages = Langs.Remove(Langs.Length - 2);

                string Profs = "";
                foreach(string Skill in Skills.SelectedItems) { Profs += Skill + ", "; }
                foreach(string Tool in Tools.SelectedItems) { Profs += Tool + ", "; }
                foreach(string Weapon in Weapons.SelectedItems) { Profs += Weapon + ", "; }
                foreach(string Armor in Armor.SelectedItems) { Profs += Armor + ", "; }
                try { Race.Proficincy = Profs.Remove(Profs.Length - 2); } catch { Race.Proficincy = "None"; }

                string Bonus = "";
                foreach(string bonus in Traits.Lines) {
                    if (bonus.EndsWith(", ")) {
                        Bonus += bonus;
                    }else if (bonus.EndsWith(",")) {
                        Bonus += bonus + " ";
                    } else {
                        Bonus += bonus + ", ";
                    }
                }
                try { Race.Bonus = Bonus.Remove(Bonus.Length - 2); } catch { Race.Bonus = "None"; }

                Race.Save();
                MessageBox.Show($"{Name} has been saved!","Homebrew Wizard");
                button2_Click(null, EventArgs.Empty);
            } catch(Exception ex) {
                MessageBox.Show($"There was an error saving your player race.\n{ex.Message}","Homebrew Wizard");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            Traits.Text = "";
            RaceName.Text = "";
            Subrace.Text = "";
            PopulateRaceArrays();
            Speed.Text = "30";
            Size.SelectedItem = "Medium";
            foreach(RadioButton rb in Stat1.Controls.OfType<RadioButton>()) { rb.Checked = false; rb.Enabled = true; }
            foreach(RadioButton rb in Stat2.Controls.OfType<RadioButton>()) { rb.Checked = false; rb.Enabled = true; }
        }
        #endregion
        #region Backgrounds
        void PopulateBGArray() {
            BGBonus1.Items.Clear();
            BGBonus2.Items.Clear();
            BGBonus1.Items.AddRange(Engine.TOOLS.Union(Engine.LANGUAGES).ToArray());
            BGBonus2.Items.AddRange(Engine.TOOLS.Union(Engine.LANGUAGES).ToArray());
            Personalities = new[] { P1, P2, P3, P4, P5, P6, P7, P8 };
            Bonds = new[] { B1, B2, B3, B4, B5, B6 };
            Ideals = new[] { I1, I2, I3, I4, I5, I6 };
            Flaws = new[] { F1, F2, F3, F4, F5, F6 };
        }

        private void BGSave_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrWhiteSpace(BGName.Text)) { throw new Exception("No background name"); }
                if (BGBonus1.SelectedIndex == -1 || BGBonus2.SelectedIndex == -1
                    || BGSkill1.SelectedIndex == -1 || BGSkill2.SelectedIndex == -1) { throw new Exception("No skills assigned"); }
                foreach (TextBox tb in Personalities) { if (string.IsNullOrWhiteSpace(tb.Text)) { throw new Exception("Not all personality traits assigned"); } }
                foreach (TextBox tb in Bonds) { if (string.IsNullOrWhiteSpace(tb.Text)) { throw new Exception("Not all personality traits assigned"); } }
                foreach (TextBox tb in Ideals) { if (string.IsNullOrWhiteSpace(tb.Text)) { throw new Exception("Not all personality traits assigned"); } }
                foreach (TextBox tb in Flaws) { if (string.IsNullOrWhiteSpace(tb.Text)) { throw new Exception("Not all personality traits assigned"); } }
                HomebrewBackground bg = new();
                bg.Name = BGName.Text;
                
                bg.Skills = $"Skills: {BGSkill1.SelectedItem}, {BGSkill2.SelectedItem}";
                
                bg.Tools = "Tools: ";
                bg.Tools = $"{(Engine.TOOLS.Contains(BGBonus1.SelectedItem) ? bg.Tools + BGBonus1.SelectedItem : bg.Tools)}";
                bg.Tools = $"{((Engine.TOOLS.Contains(BGBonus2.SelectedItem) ? (bg.Tools == "Tools: " ? BGBonus2.SelectedItem : bg.Tools + "_" + BGBonus2.SelectedItem) : bg.Tools + "None"))}";

                bg.Languages = "Languages: ";
                bg.Languages = $"{(Engine.LANGUAGES.Contains(BGBonus1.SelectedItem) ? bg.Languages + BGBonus1.SelectedItem: bg.Languages)}";
                bg.Languages = $"{((Engine.LANGUAGES.Contains(BGBonus2.SelectedItem) ? (bg.Languages == "Languages: " ? BGBonus2.SelectedItem : bg.Languages + "_" + BGBonus2.SelectedItem) : bg.Languages + "None"))}";
                
                bg.Personality = new[] { Personalities[0].Text, Personalities[1].Text, Personalities[2].Text, Personalities[3].Text,
                    Personalities[4].Text, Personalities[5].Text, Personalities[6].Text, Personalities[7].Text};
                bg.Bonds = new[] { Bonds[0].Text, Bonds[1].Text, Bonds[2].Text, Bonds[3].Text, Bonds[4].Text, Bonds[5].Text };
                bg.Ideals = new[] { Ideals[0].Text, Ideals[1].Text, Ideals[2].Text, Ideals[3].Text, Ideals[4].Text, Ideals[5].Text };
                bg.Flaws = new[] { Flaws[0].Text, Flaws[1].Text, Flaws[2].Text, Flaws[3].Text, Flaws[4].Text, Flaws[5].Text };

                bg.Feature = BGFeature.Text;
                
                foreach(string item in BGItems.SelectedItems) { bg.Items += item + ", "; }
                bg.Items = bg.Items.Remove(bg.Items.Length - 2);

                bg.Save();
                MessageBox.Show($"{bg.Name} has been saved!", "Homebrew Wizard");
                IO.SaveDataToDisk();
            } catch (Exception ex) {
                MessageBox.Show($"There was an error saving your background.\n{ex.Message}", "Homebrew Wizard");
            }
        }

        TextBox[] Personalities;
        TextBox[] Bonds;
        TextBox[] Ideals;
        TextBox[] Flaws;

        private void BGReset_Click(object sender, EventArgs e) {
            BGBonus1.SelectedIndex = -1;
            BGBonus2.SelectedIndex = -1;
            BGFeature.Text = "";
            BGSkill1.SelectedIndex = -1;
            BGSkill2.SelectedIndex = -1;
            foreach (TextBox tb in Personalities) { tb.Text = ""; }
            foreach (TextBox tb in Bonds) { tb.Text = ""; }
            foreach (TextBox tb in Ideals) { tb.Text = ""; }
            foreach (TextBox tb in Flaws) { tb.Text = ""; }
            BGName.Text = "";
        }
        #endregion
        #region Classes
        private void PopulateClassArrays() {
            return; //Remove when ERW/TCE/CR have been implemented
            if (Engine.SaveData.SourceBooks["ERW"] || Engine.SaveData.SourceBooks["TCE"]) {
                BaseClass.Items.Insert(0, "Artificer");
            }
            if (Engine.SaveData.SourceBooks["CR"]) {
                BaseClass.Items.Insert(BaseClass.Items.IndexOf("Bard")+1,"Blood Hunter");
            }
        }

        private void IsSpellCaster_CheckedChanged(object sender, EventArgs e) {
            IsSpellCaster.Text = IsSpellCaster.Checked ? "Yes" : "No";
            CastAbility.Enabled = IsSpellCaster.Checked;
        }

        private void BaseClass_SelectedIndexChanged(object sender, EventArgs e) {
            Feature_1.Enabled = Feature_2.Enabled = Feature_3.Enabled = Feature_4.Enabled = Feature_5.Enabled = false;

            if(((ComboBox)sender).SelectedIndex == -1) { return; }
            string RequestedClass = ((ComboBox)sender).SelectedItem.ToString();

            Preview.Load(Player_Maker.ImageLocation.GetImage(RequestedClass));
            try {
                string[] baseClassStats = Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetString(RequestedClass + ":Base").Split("_");
                Class_Data.Text = "Class Skill - Level:\n";
                foreach (string item in baseClassStats) {
                    Class_Data.Text = Class_Data.Text + item + "\n";
                }
            } catch { Class_Data.Text = "No Data Found"; }

            if (RequestedClass == "Monk" || RequestedClass == "Ranger") { Class_Data.Font = new Font("Segoe UI", 7f); } else { Class_Data.Font = new Font("Segoe UI", 8f); }

            switch (RequestedClass) {
                case "Artificer":
                case "Barbarian":
                case "Cleric":
                case "Monk":
                case "Paladin":
                case "Ranger":
                case "Rogue":
                case "Sorcerer":
                case "Warlock":
                case "Wizard":
                    Feature_1.Enabled = Feature_2.Enabled = Feature_3.Enabled = Feature_4.Enabled = true;
                    break;
                case "Bard":
                    Feature_1.Enabled = Feature_2.Enabled = Feature_3.Enabled = true;
                    break;
                case "Druid":
                case "Fighter":
                    Feature_1.Enabled = Feature_2.Enabled = Feature_3.Enabled = Feature_4.Enabled = Feature_5.Enabled = true;
                    break;
            }
            switch (RequestedClass) {
                case "Artificer":
                    Label_1.Text = "Lv. 3";
                    Label_2.Text = "Lv. 5";
                    Label_3.Text = "Lv. 9";
                    Label_4.Text = "Lv. 15";
                    Label_5.Text = "";
                    break;
                case "Barbarian":
                    Label_1.Text = "Lv. 3";
                    Label_2.Text = "Lv. 6";
                    Label_3.Text = "Lv. 10";
                    Label_4.Text = "Lv. 14";
                    Label_5.Text = "";
                    break;
                case "Monk":
                    Label_1.Text = "Lv. 3";
                    Label_2.Text = "Lv. 6";
                    Label_3.Text = "Lv. 11";
                    Label_4.Text = "Lv. 17";
                    Label_5.Text = "";
                    break;
                case "Paladin":
                    Label_1.Text = "Lv. 3";
                    Label_2.Text = "Lv. 7";
                    Label_3.Text = "Lv. 15";
                    Label_4.Text = "Lv. 20";
                    Label_5.Text = "";
                    break;
                case "Ranger":
                    Label_1.Text = "Lv. 3";
                    Label_2.Text = "Lv. 7";
                    Label_3.Text = "Lv. 11";
                    Label_4.Text = "Lv. 15";
                    Label_5.Text = "";
                    break;
                case "Rogue":
                    Label_1.Text = "Lv. 3";
                    Label_2.Text = "Lv. 9";
                    Label_3.Text = "Lv. 13";
                    Label_4.Text = "Lv. 17";
                    Label_5.Text = "";
                    break;
                case "Sorcerer":
                    Label_1.Text = "Lv. 1";
                    Label_2.Text = "Lv. 6";
                    Label_3.Text = "Lv. 14";
                    Label_4.Text = "Lv. 18";
                    Label_5.Text = "";
                    break;
                case "Warlock":
                    Label_1.Text = "Lv. 1";
                    Label_2.Text = "Lv. 6";
                    Label_3.Text = "Lv. 10";
                    Label_4.Text = "Lv. 14";
                    Label_5.Text = "";
                    break;
                case "Wizard":
                    Label_1.Text = "Lv. 2";
                    Label_2.Text = "Lv. 6";
                    Label_3.Text = "Lv. 10";
                    Label_4.Text = "Lv. 14";
                    Label_5.Text = "";
                    break;
                case "Bard":
                    Label_1.Text = "Lv. 3";
                    Label_2.Text = "Lv. 6";
                    Label_3.Text = "Lv. 14";
                    Label_4.Text = "";
                    Label_5.Text = "";
                    break;
                case "Cleric":
                    Label_1.Text = "Lv. 1";
                    Label_2.Text = "Lv. 6";
                    Label_3.Text = "Lv. 8";
                    Label_4.Text = "Lv. 17";
                    Label_5.Text = "";
                    break;
                case "Druid":
                    Label_1.Text = "Lv. 2";
                    Label_2.Text = "Lv. 3";
                    Label_3.Text = "Lv. 6";
                    Label_4.Text = "Lv. 10";
                    Label_5.Text = "Lv. 14";
                    break;
                case "Fighter":
                    Label_1.Text = "Lv. 3";
                    Label_2.Text = "Lv. 7";
                    Label_3.Text = "Lv. 10";
                    Label_4.Text = "Lv. 15";
                    Label_5.Text = "Lv. 18";
                    break;
            }
        }

        private void Cla_Revert_Click(object sender, EventArgs e) {
            BaseClass.SelectedIndex = -1;
            SubclassName.Text = "";
            IsSpellCaster.Checked = false;
            CastAbility.SelectedIndex = -1;
            Class_Data.Text = "No Class Selected";
            Feature_1.Enabled = Feature_2.Enabled = Feature_3.Enabled = Feature_4.Enabled = Feature_5.Enabled = false;
            Feature_1.Text = Feature_2.Text = Feature_3.Text = Feature_4.Text = Feature_5.Text = "";
            Label_1.Text = Label_2.Text = Label_3.Text = Label_4.Text = Label_5.Text = "";
            Preview.Image = Properties.Resources.Custom;
        }

        private List<TextBox> GetBoxes() {
            List<TextBox> value = new();
            if (Feature_1.Enabled) { value.Add(Feature_1); }
            if (Feature_2.Enabled) { value.Add(Feature_2); }
            if (Feature_3.Enabled) { value.Add(Feature_3); }
            if (Feature_4.Enabled) { value.Add(Feature_4); }
            if (Feature_5.Enabled) { value.Add(Feature_5); }
            return value;
        }

        private void Cla_Save_Click(object sender, EventArgs e) {
            List<TextBox> EnabledFeatures = GetBoxes();
            try {
                if (BaseClass.SelectedIndex == -1) { throw new Exception("No Base Class Selected."); }
                if (string.IsNullOrEmpty(SubclassName.Text)) { throw new Exception("No Subclass Name."); }
                if (IsSpellCaster.Checked && CastAbility.SelectedIndex == -1) { throw new Exception("No Cast Ability Assigned."); }
                foreach (TextBox tb in EnabledFeatures) { if (string.IsNullOrEmpty(tb.Text)) { throw new Exception("Not All Features Assigned."); } }
                HomebrewClass Class = new HomebrewClass();
                
                Class.Name = $"{BaseClass.SelectedItem}:{SubclassName.Text}";
                Class.IsSpellcaster = IsSpellCaster.Checked;
                Class.CastingAbility = CastAbility.SelectedItem == null ? null : CastAbility.SelectedItem.ToString();

                Class.Abilites = $"{Feature_1.Text} - {Label_1.Text.Split("Lv. ")[1]}_" +
                                 $"{Feature_2.Text} - {Label_2.Text.Split("Lv. ")[1]}_" +
                                 $"{Feature_3.Text} - {(!string.IsNullOrEmpty(Label_3.Text) ? Label_3.Text.Split("Lv. ")[1] : "")}_" +
                                 $"{Feature_4.Text} - {(!string.IsNullOrEmpty(Label_4.Text) ? Label_4.Text.Split("Lv. ")[1] : "")}_" +
                                 $"{Feature_5.Text} - {(!string.IsNullOrEmpty(Label_5.Text) ? Label_5.Text.Split("Lv. ")[1] : "")}";
                while(Class.Abilites.EndsWith(" ") || Class.Abilites.EndsWith("-") || Class.Abilites.EndsWith("_")) { Class.Abilites = Class.Abilites.Substring(0, Class.Abilites.Length - 1); }
                Class.Save();
                IO.SaveDataToDisk();
                MessageBox.Show($"{SubclassName.Text} saved successfully.","Homebrew Wizard");

            }catch(Exception ex) {
                MessageBox.Show($"There was an error saving your class.\n{ex.Message}", "Homebrew Wizard");
            }
        }
        #endregion
    }
    #region Homebrew

    [Serializable]
    public class HomebrewRace {
        //STR_DEX_CON_WIS_INT_CHA_SPEED_SIZE_LANGUAGE_PROFICINCY_BONUS

        public string Name { get; set; }
        public string StatBonus { get; set; }
        public string Speed { get; set; }
        public string Size { get; set; }
        public string Languages { get; set; }
        public string Proficincy { get; set; }
        public string Bonus { get; set; }

        public override string ToString() {
            return $"{StatBonus}_{Speed}_{Size}_{Languages}_{Proficincy}_{Bonus}";
        }

        public void Save() { Engine.Homebrew.HomebrewRaces.Add(Name, this); IO.SaveDataToDisk(); }
    }
    [Serializable]
    public class HomebrewClass {
        public string Name { get; set;}
        public bool IsSpellcaster { get; set; }
        public string CastingAbility { get; set; }
        public string Abilites { get; set; }

        public void Save() { Engine.Homebrew.HomebrewClasses.Add(Name, this); }
    }
    [Serializable]
    public class HomebrewBackground {
        
        public string Name { get; set; }

        public string Languages { get; set; }
        public string Skills { get; set; }
        public string Tools { get; set; }
        public string Items { get; set; }
        
        public string Feature { get; set; }
        
        public string[] Personality { get; set; }
        public string[] Ideals { get; set; }
        public string[] Bonds { get; set; }
        public string[] Flaws { get; set; }
        
        public void Save() { Engine.Homebrew.HomebrewBackgrounds.Add(Name, this); }
    } 

    [Serializable]
    public class Homebrew {
        public Dictionary<string, HomebrewRace> HomebrewRaces { get; set; } = new();
        public Dictionary<string, HomebrewClass> HomebrewClasses { get; set; } = new();
        public Dictionary<string, HomebrewBackground> HomebrewBackgrounds { get; set; } = new();

        public static Dictionary<V,K> Merge<V,K> (params Dictionary<V,K>[] Dictionaries) {
            Dictionary<V, K> Base = new();
            foreach(Dictionary<V,K> Dict in Dictionaries) {
                foreach(KeyValuePair<V,K> Value in Dict) {
                    if (!Base.ContainsKey(Value.Key)) {
                        Base.Add(Value.Key, Value.Value);
                    }
                }
            }
            return Base;
        }
    }
    #endregion
}