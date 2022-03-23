using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Backgrounds {
    public partial class BackgroundTab : TabPage {

        #region Variables -- Do not change
        private readonly PC PC;
        private readonly Control[] controlsOnControl;
        private readonly ComboBox[] EXOptions;
        private readonly Label[] BackgroundsVisible;
        private int pos = 0;

        public event EventHandler OnReady;
        public event EventHandler OnReset;

        private bool _ready = false;

        private bool InformationFilled { get { return _ready; } set { _ready = value; if (value) { OnReady.Invoke(this, EventArgs.Empty); } else { OnReset.Invoke(this, EventArgs.Empty); } } }
        #endregion

        private static readonly List<string> Backgrounds = new();// { "Acolyte", "Criminal/Spy", "Folk Hero", "Haunted One", "Noble", "Sage", "Soldier", "Urchin"}; //Change this line to add new Backgrounds
        private static readonly List<string> HORROR_BACKGROUNDS = new(){ "Investigator", "Haunted One" };

        [Obsolete]
        public BackgroundTab(PC Player) { //Initializer, do not change
            Text = "Backgrounds";
            BackColor = Color.White;
            InitializeList();
            BackgroundsVisible = new Label[] { B1, B2, B3, B4, B5, B6 };
            EXOptions = new ComboBox[] { EXOption1, EXOption2, EXOption3, EXOption4 };
            controlsOnControl = new Control[] { B1, B2, B3, B4, B5, B6, UP, DOWN, label1, BackgroundBonus, BackgroundData,
                Personality, Ideal,Bond, Flaw, EXOption1, EXOption2,EXOption3, EXOption4 };
            PC = Player;
            InitializeComponent();
            foreach(Label l in BackgroundsVisible) { l.Click += Background_Click; l.MouseEnter += Background_Hover; }
            foreach(ComboBox c in EXOptions) { c.SelectedValueChanged += Option_SelectedValueChanged; }
            UP.Click += UP_Click;
            DOWN.Click += DOWN_Click;
            Personality.SelectedValueChanged += ID_SelectedValueChanged;
            Ideal.SelectedValueChanged += ID_SelectedValueChanged;
            Bond.SelectedValueChanged += ID_SelectedValueChanged;
            Flaw.SelectedValueChanged += ID_SelectedValueChanged;
            Controls.AddRange(controlsOnControl);
            Scale(.75f);
        }
        void InitializeList() {
            foreach (string book in Engine.SaveData.SourceBooks.Keys) {
                if (Engine.SaveData.SourceBooks[book]) {
                    Backgrounds.AddRange(SourceBooks.Sourcebook(book)["Backgrounds"]);
                }
            }
        }

        #region Controls - Do not Change
        private readonly Label label1 = new() {
            Text = "Personality",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(492, 19),
            Location = new Point(6, 443)
        };
        #region Labels -- Names
        private readonly Label B1 = new() {
            Size = new Size(211, 25),
            Text = "Acolyte",
            Location = new Point(6, 46),
        };
        private readonly Label B2 = new() {
            Size = new Size(211, 25),
            Text = "Charlatan",
            Location = new Point(6, 83),
        };
        private readonly Label B3 = new() {
            Size = new Size(211, 25),
            Text = "Criminal/Spy",
            Location = new Point(6, 120),
        };
        private readonly Label B4 = new() {
            Size = new Size(211, 25),
            Text = "Entertainer",
            Location = new Point(6, 157),
        };
        private readonly Label B5 = new() { 
            Size = new Size(211, 25),
            Text = "Folk Hero",
            Location = new Point(6, 194),
        };
        private readonly Label B6 = new() {
            Size = new Size(211, 25),
            Text = "Guild Artisan/Guild Merchant",
            Location = new Point(6, 231),
        };

        private void Background_Hover(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(PC.Background)) { return; }
            try {
                string[] Skills = Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(((Label)sender).Text + "-Skills").Split("_");
                BackgroundBonus.Text = "Background Bonus:\n";
                foreach (string s in Skills) { BackgroundBonus.Text += s + "\n"; }
                BackgroundData.Text = "Background Skill:\n" + Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(((Label)sender).Text);
            } catch (NullReferenceException) {
                BackgroundBonus.Text = "Background Bonus:\nNo Data Currently Available";
                BackgroundData.Text  = "Background Skill:\nNo Data Currently Available";
            }
        }
        private void Background_Click(object sender, EventArgs e) {
            Reset();
            PC.Background = ((Label)sender).Text;
            try {
                string[] Skills = Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background + "-Skills").Split("_");
                BackgroundBonus.Text = "Background Bonus:\n";
                foreach (string s in Skills) { BackgroundBonus.Text += s + "\n"; }
                BackgroundData.Text = "Background Skill:\n" + Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background);
                PopulateBackgroundPersonality();
                foreach (string data in BackgroundBonus.Text.Split("\n")) {
                    for (int i = 0; i < Regex.Matches(data, "<CHOOSE>").Count; i++) {
                        foreach (ComboBox c in EXOptions) {
                            if (!c.Enabled) {
                                if (data.Contains("Languages")) { c.Items.AddRange(Engine.LANGUAGES); }
                                else if (data.Contains("Skills")) { c.Items.AddRange(Engine.SKILLS); }
                                else if (data.Contains("Tools")) { c.Items.AddRange(Engine.TOOLS); c.Items.Remove(data.Split(": ")[1].Split(",")[0]); }
                                c.Enabled = true;
                                break;
                            }
                        }
                    }
                }
            } catch (NullReferenceException) {
                BackgroundData.Text = "Background Skill:\nNo Data Currently Available";
                BackgroundBonus.Text = "Background Bonus:\nNo Data Currently Available";
            }
        }
        private void PopulateBackgroundPersonality(){
            if (HORROR_BACKGROUNDS.Contains(PC.Background)) {
                Personality.Items.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.Horror_Personality.Split("_"));
                Ideal.Items.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.Horror_Ideal.Split("_"));
                Bond.Items.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.Horror_Bond.Split("_"));
                Flaw.Items.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.Horror_Flaw.Split("_"));
            } else {
                Personality.Items.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background + "-Personality").Split("_"));
                Ideal.Items.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background + "-Ideal").Split("_"));
                Bond.Items.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background + "-Bond").Split("_"));
                Flaw.Items.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background + "-Flaw").Split("_")); 
            }
        }
        #endregion
        private readonly Label BackgroundBonus = new() {
            TextAlign = ContentAlignment.MiddleLeft,
            Size = new Size(278, 139),
            Location = new Point(220, 6)
        };
        private readonly Label BackgroundData = new() {
            TextAlign = ContentAlignment.MiddleLeft,
            Size = new Size(492, 153),
            Location = new Point(6, 290)
        };
        private readonly Button UP = new() {
            Text = "UP",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(208, 28),
            Location = new Point(6, 6)
        };
        private readonly Button DOWN = new() {
            Text = "DOWN",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(208, 28),
            Location = new Point(6, 259)
        };

        private void UP_Click(object sender, EventArgs e) {
            pos--;
            if (pos < 0) { pos = Backgrounds.Count - 1; }
            UpdateVisibleBackgrounds();
        }
        private void DOWN_Click(object sender, EventArgs e) {
            pos++;
            if (pos > Backgrounds.Count - 1) { pos = 0; }
            UpdateVisibleBackgrounds();
        }
        private void UpdateVisibleBackgrounds() {
            int j = pos;
            foreach (Label c in BackgroundsVisible) {
                c.Text = Backgrounds[j];
                if (j > Backgrounds.Count - 2) { j = 0; } else { j++; }
            }
        }

        private readonly ComboBox Personality = new() {
            Text = "Select One",
            DropDownWidth = 650,
            Size = new Size(242, 28),
            Location = new Point(6, 465),
        };
        private readonly ComboBox Bond = new() { 
            Text = "Select One",
            DropDownWidth = 650,
            Size = new Size(242, 28),
            Location = new Point(6, 499),
        };
        private readonly ComboBox Ideal = new() {
            Text = "Select One",
            DropDownWidth = 650,
            Size = new Size(242, 28),
            Location = new Point(256, 465),
        };
        private readonly ComboBox Flaw = new() { 
            Text = "Select One",
            DropDownWidth = 650,
            Size = new Size(242, 28),
            Location = new Point(256, 499),
        };
        
        private void ID_SelectedValueChanged(object sender, EventArgs e) {  //Checks if the user has filled out all necessary data.
            if (!Personality.Text.SequenceEqual("Select One") && !Ideal.Text.SequenceEqual("Select One") &&
                !Bond.Text.SequenceEqual("Select One") && !Flaw.Text.SequenceEqual("Select One") && !BackgroundBonus.Text.Contains("<CHOOSE>")) {
                string[] Languages = BackgroundBonus.Text.Split("\n")[1].Split("Languages: ")[1].Split(", ");
                PC.Languages.AddRange(Languages);
                PC.Languages.Remove("None");
                string[] Skills = BackgroundBonus.Text.Split("\n")[2].Split("Skills: ")[1].Split(", ");
                PC.Skills.AddRange(Skills);
                string[] Tools = BackgroundBonus.Text.Split("\n")[3].Split("Tools: ")[1].Split(", ");
                PC.Skills.AddRange(Tools);
                PC.Personality = new[] { Personality.Text, Bond.Text, Ideal.Text, Flaw.Text };
                PC.Inventory.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background + "-Items").Split(", "));
                InformationFilled = true;
            }
        }

        private readonly ComboBox EXOption1 = new() {
            Name = "EXOption1",
            Location = new Point(223, 148),
            Size = new Size(275, 28),
            Enabled = false,
            Text = "Select One"
        };
        private readonly ComboBox EXOption2 = new() {
            Name = "EXOption2",
            Location = new Point(223, 185),
            Size = new Size(275, 28),
            Enabled = false,
            Text = "Select One"
        };
        private readonly ComboBox EXOption3 = new() {
            Name = "EXOption3",
            Location = new Point(223, 222),
            Size = new Size(275, 28),
            Enabled = false,
            Text = "Select One"
        };
        private readonly ComboBox EXOption4 = new() {
            Name = "EXOption4",
            Location = new Point(223, 259),
            Size = new Size(275, 28),
            Enabled = false,
            Text = "Select One"
        };
        private string selectedValueEXOption1;
        private string selectedValueEXOption2;
        private string selectedValueEXOption3;
        private string selectedValueEXOption4;

        private void Option_SelectedValueChanged(object sender, EventArgs e) { //Checks if the data is valid
            ComboBox c = (ComboBox)sender;
            switch (c.Name) {
                case "EXOption1":
                    UpdateSelection(c, ref selectedValueEXOption1);
                    break;
                case "EXOption2":
                    UpdateSelection(c, ref selectedValueEXOption2);
                    break;
                case "EXOption3":
                    UpdateSelection(c, ref selectedValueEXOption3);
                    break;
                case "EXOption4":
                    UpdateSelection(c, ref selectedValueEXOption4);
                    break;
            }
            ID_SelectedValueChanged(sender, e);
        }
        
 
        private void UpdateSelection(ComboBox c, ref string oldValue) { //removes the old value or the choose
 
            if (c.Items.Count == Engine.LANGUAGES.Length) {
                string data = BackgroundBonus.Text.Split("\n")[1];
                string newV = data.Contains("<CHOOSE>") ? new Regex("<CHOOSE>").Replace(data, c.Text, 1) : new Regex(oldValue).Replace(data, c.Text, 1);
                BackgroundBonus.Text = BackgroundBonus.Text.Replace(data, newV);
                oldValue = c.Text;
            } else if (c.Items.Count == Engine.SKILLS.Length) {
                string data = BackgroundBonus.Text.Split("\n")[2];
                string newV = data.Contains("<CHOOSE>") ? new Regex("<CHOOSE>").Replace(data, c.Text, 1) : new Regex(oldValue).Replace(data, c.Text, 1);
                BackgroundBonus.Text = BackgroundBonus.Text.Replace(data, newV);
                oldValue = c.Text;
            } else if (c.Items.Count == Engine.TOOLS.Length) {
                string data = BackgroundBonus.Text.Split("\n")[3];
                string newV = data.Contains("<CHOOSE>") ? new Regex("<CHOOSE>").Replace(data, c.Text, 1) : new Regex(oldValue).Replace(data, c.Text, 1);
                BackgroundBonus.Text = BackgroundBonus.Text.Replace(data, newV);
                oldValue = c.Text;
            }
        }
        
        private void Reset() {
            selectedValueEXOption1 = "";
            selectedValueEXOption2 = "";
            selectedValueEXOption3 = "";
            selectedValueEXOption4 = "";
            
            Personality.Items.Clear();
            Personality.Text = "Select One";
            Bond.Items.Clear();
            Bond.Text = "Select One";
            Ideal.Items.Clear();
            Ideal.Text = "Select One";
            Flaw.Items.Clear();
            Flaw.Text = "Select One";

            foreach(ComboBox c in EXOptions) {
                c.Enabled = false;
                c.Items.Clear();
                c.Text = "Select One";
            }
            
            ID_SelectedValueChanged(null, EventArgs.Empty);
            InformationFilled = false;
        }
        #endregion
    }
}