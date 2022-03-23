using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Races {
    public partial class RaceTab : TabPage {

        #region Variables
        private readonly PC PC;

        private Label[] RaceName;
        private static readonly List<string> Races = new();
        private static readonly List<string> DWARF_SUBRACE=new();
        private static readonly List<string> ELF_SUBRACE=new();
        private static readonly List<string> HALFLING_SUBRACE=new();
        private static readonly List<string> HUMAN_SUBRACE=new();
        private static readonly List<string> DRAGONBORN_SUBRACE=new();
        private static readonly List<string> GNOME_SUBRACE = new();
        //private static readonly string[] HALF_ELF_SUBRACE = { "Natural", "Variant" };

        private static readonly Dictionary<string, int> RacesBonus = new() { { "Human:Variant", 2 }, { "Half-Elf:Natural", 2 } };
        private static readonly List<string> Races_SubRace = new() { "Dwarf", "Elf", "Halfling", "Human", "Dragonborn", "Gnome" };

        private static readonly List<string> AdditionalRaceLang = new() { "Human", "Half-Elf" };
        private static readonly List<string> AdditionalRaceSkill1 = new() { "Half-Elf" };
        private static readonly List<string> AdditionalRaceSkill2 = new() { "Half-Elf" };
        private int pos = 0;
        private Control[] controlsInForm;
        #endregion

        #region Events
        public event EventHandler OnReady;

        private bool _ready = false;

        private bool InformationFilled { get { return _ready; } 
            set { _ready = value;
                if (value) {
                    PC.Race = PC.Race.Split(":")[0] + ":" + SubRaces.Text;
                    if (Prof1 != "" && Prof2 != "") {
                        PC.Skills.AddRange(new[] { Prof1.Split(" ")[0], Prof2.Split(" ")[0] });
                    }else if(Prof2 != "") {
                        PC.Skills.Add(Prof2.Split(" ")[0]);
                    }else if (Prof1 != "") {
                        PC.Skills.Add(Prof1.Split(" ")[0]);
                    }
                    PC.Skills.AddRange(Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(PC.Race).Split("_")[9].Split(", "));
                    PC.Skills.Remove("None");
                    PC.Languages.AddRange(Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(PC.Race).Split("_")[8].Split(", "));
                    PC.Languages.Add(Languages);
                    
                    OnReady.Invoke(this, EventArgs.Empty); 
                }
            }
        }
#endregion

        public RaceTab(PC character) {
            PC = character;
            InitializeList();
            InitializeArrays();
            InitializeComponent();
            Text = "Races";
            BackColor = Color.White;
            Controls.AddRange(controlsInForm);

        }

        private void InitializeList() {
            foreach(string book in Engine.SaveData.SourceBooks.Keys) {
                if (Engine.SaveData.SourceBooks[book]) {
                    foreach (string Race in SourceBooks.Sourcebook(book)["Races"]) {
                        string BaseRace = Race.Split(":")[0];
                        string Subrace = Race.Split(":")[1];
                        if (!Races.Contains(BaseRace)) { Races.Add(BaseRace); }
                        switch (BaseRace.ToUpper()) {
                            case "DWARF":
                                DWARF_SUBRACE.Add(Subrace);
                                break;
                            case "ELF":
                                ELF_SUBRACE.Add(Subrace);
                                break;
                            case "HALFLING":
                                HALFLING_SUBRACE.Add(Subrace);
                                break;
                            case "HUMAN":
                                HUMAN_SUBRACE.Add(Subrace);
                                break;
                            case "DRAGONBORN":
                                DRAGONBORN_SUBRACE.Add(Subrace);
                                break;
                            case "GNOME":
                                GNOME_SUBRACE.Add(Subrace);
                                break;
                        }
                    }
                }
            }
        }

        private void InitializeArrays() {
            controlsInForm = new Control[] { R1, R2, R3, R4, R5, R6, RacePreview, Info, Label1, UP, DOWN, RaceLang, RaceSkill1, RaceSkill2, SubRaces };
            RaceName = new Label[] { R1, R2, R3, R4, R5, R6 };
            foreach (Label l in RaceName) { l.MouseEnter += RaceName_MouseEnter; l.Click += RaceName_OnClick; }
            UP.Click += UP_OnClick;
            DOWN.Click += DOWN_OnClick;
            SubRaces.SelectedValueChanged += SubRaces_SelectedValueChanged;
            RaceLang.SelectedValueChanged += RaceLang_SelectedValueChanged;
            RaceSkill1.SelectedValueChanged += RaceSkill1_SelectedValueChanged;
            RaceSkill2.SelectedValueChanged += RaceSkill2_SelectedValueChanged;
        }

        #region Controls
        #region Labels -- Race Names
        private readonly Label R1 = new() {
            Text = "Dwarf",
            Size = new Size(211, 25),
            Location = new Point(6, 46),
        };
        private readonly Label R2 = new() {
            Text = "Elf",
            Size = new Size(211, 25),
            Location = new Point(6, 83),
        };
        private readonly Label R3 = new() {
            Text = "Halfling",
            Size = new Size(211, 25),
            Location = new Point(6, 120),
        };
        private readonly Label R4 = new() {
            Text = "Human",
            Size = new Size(211, 25),
            Location = new Point(6, 157),
        };
        private readonly Label R5 = new() {
            Text = "Dragonborn",
            Size = new Size(211, 25),
            Location = new Point(6, 194),
        };
        private readonly Label R6 = new() {
            Text = "Gnome",
            Size = new Size(211, 25),
            Location = new Point(6, 231),
        };
        #region Events
        private void RaceName_MouseEnter(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(PC.Race)) {
                //RacePreview.Image = (Image)Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetObject(PC.Race.Split("-")[0]);
                //updateInfo(PC.Race.Split("-")[0]);
                return;
            } else {
                //RacePreview.Image = (Image)Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetObject(((Label)sender).Text);
                RacePreview.Load(ImageLocation.GetImage(((Label)sender).Text));
                updateInfo(((Label)sender).Text);
            }
        }
        private void RaceName_OnClick(object sender, EventArgs e) {
            if (!PC.Race.SequenceEqual(((Label)sender).Text)) {
                SubRaces.Text = "Natural";
                PC.Languages.Clear();
                PC.Skills.Clear();
                Prof1 = ""; Prof2 = "";
                updateInfo(((Label)sender).Text);
            }
            PC.Race = ((Label)sender).Text;
            //RacePreview.Image = (Image)Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetObject(PC.Race.Split(":")[0]);
            RacePreview.Load(ImageLocation.GetImage(PC.Race.Split(":")[0]));
            updateInfo(PC.Race);
            if (Races_SubRace.Contains(PC.Race.Split(":")[0])){
                SubRaces.Enabled = true;
                object[] items = null;
                switch (PC.Race.Split(":")[0]) {
                    case "Dwarf":
                        items = DWARF_SUBRACE.ToArray();
                        break;
                    case "Elf":
                        items = ELF_SUBRACE.ToArray();
                        break;
                    case "Halfling":
                        items = HALFLING_SUBRACE.ToArray();
                        break;
                    case "Human":
                        items = HUMAN_SUBRACE.ToArray();
                        break;
                    case "Dragonborn":
                        items = DRAGONBORN_SUBRACE.ToArray();
                        break;
                    case "Gnome":
                        items = GNOME_SUBRACE.ToArray();
                        break;
                   // case "Half-Elf":
                    //    items = HALF_ELF_SUBRACE;
                     //   break;
                }
                SubRaces.Items.Clear();
                SubRaces.Items.AddRange(items);
                SubRaces.SelectedIndex = 0;
            } else {
                SubRaces.Enabled = false;
                SubRaces.Items.Clear();
                SubRaces.Text = "Natural";
            }
            if (AdditionalRaceLang.Contains(PC.Race)) { RaceLang.Text = "Select One"; RaceLang.Enabled = true; } else { RaceLang.Text = ""; RaceLang.Enabled = false; }
            if (AdditionalRaceSkill1.Contains(PC.Race) && (PC.Race == "Half-Elf" && !SubRaces.Text.SequenceEqual("Variant"))) { RaceSkill1.Text = "Select One"; RaceSkill1.Enabled = true; } else { RaceSkill1.Text = ""; RaceSkill1.Enabled = false; }
            if (AdditionalRaceSkill2.Contains(PC.Race) && (PC.Race == "Half-Elf" && !SubRaces.Text.SequenceEqual("Variant"))) { RaceSkill2.Text = "Select One"; RaceSkill2.Enabled = true; } else { RaceSkill2.Text = ""; RaceSkill2.Enabled = false; }
            if (!RaceLang.Enabled && !RaceSkill1.Enabled && !RaceSkill2.Enabled) { InformationFilled = true; }
        }
        #endregion
        #endregion

        private readonly Label Info = new() {
            Location = new Point(6, 325),
            Size = new Size(492, 171),
            TextAlign = ContentAlignment.MiddleLeft,
            Text = "STR: +1 DEX: +1 CON: +1 WIS: +1 INT: +1 CHA: +1\nSpeed: 30\nSize: Medium\nLanguages: Common\nProficiencies: None\nNotes: None"
        };
        private readonly Label Label1 = new() {
            Size = new Size(492, 19),
            Location = new Point(6, 496),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Additional Options:",
        };

        #region Buttons
        private readonly Button UP = new() {
            Text = "UP",
            Size = new Size(208, 28),
            Location = new Point(6, 6),
        };
        private readonly Button DOWN = new() {
            Text = "DOWN",
            Size = new Size(208, 28),
            Location = new Point(6, 259),
        };
        #region Events
        private void UP_OnClick(object sender, EventArgs e) {
            pos--;
            if (pos < 0) { pos = Races.Count - 1; }
            UpdateVisibleRaces();
        }
        private void DOWN_OnClick(object sender, EventArgs e) {
            pos++;
            if (pos > Races.Count - 1) { pos = 0; }
            UpdateVisibleRaces();
        }
        private void UpdateVisibleRaces() {
            int j = pos;
            foreach (Label r in RaceName) {
                r.Text = Races[j];
                if (j > Races.Count - 2) { j = 0; } else { j++; }
            }
        }
        #endregion
        #endregion

        #region ComboBoxes
        private string Prof1 = "";
        private string Prof2 = "";
        private string Languages = "";
        private readonly ComboBox RaceLang = new() {
            Size = new Size(151, 28),
            Location = new Point(6, 518),
            Enabled = false,
            DataSource = Engine.AddChoose("Lang")
        };
        private readonly ComboBox RaceSkill1 = new() {
            Size = new Size(151, 28),
            Location = new Point(176, 518),
            Enabled = false,
            DataSource = Engine.AddChoose("Skills")
        };
        private readonly ComboBox RaceSkill2 = new() {
            Size = new Size(151, 28),
            Location = new Point(346, 518),
            Enabled = false,
            DataSource = Engine.AddChoose("Skills")
        };
        private readonly ComboBox SubRaces = new() {
            Text = "Natural",
            Size = new Size(208, 28),
            Location = new Point(6, 294),
            Enabled = false
        };
        #region Events
        private void SubRaces_SelectedValueChanged(object sender, EventArgs e) {
            RaceLang.Text = "Select One";
            RaceSkill1.Text = "Select One"; RaceSkill2.Text = "Select One";
            Prof1 = ""; Prof2 = ""; updateInfo(PC.Race.Split(":")[0]);
            if (!RaceLang.Enabled && !RaceSkill1.Enabled && !RaceSkill2.Enabled) { InformationFilled = true; }
        }
        private void RaceLang_SelectedValueChanged(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(PC.Race)) { return; }
            string defaultLang = Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(PC.Race).Split("_")[8];
            string[] data = Info.Text.Split("\n");
            if (PC.Race == "Human" && SubRaces.Text == "Variant") {
                string[] languages = data[2].Split(defaultLang);
                languages[1] = RaceLang.Text;
                data[2] = languages[0] + defaultLang + ", " + languages[1];
                Info.Text = data[0] + "\n" + data[1] + "\n" + data[2] + "\n" + data[3] + "\n" + data[4];
                Languages = data[2];
            } else {
                string[] languages = data[3].Split(defaultLang);
                languages[1] = RaceLang.Text;
                data[3] = languages[0] + defaultLang + ", " + languages[1];
                Info.Text = data[0] + "\n" + data[1] + "\n" + data[2] + "\n" + data[3] + "\n" + data[4] + "\n" + data[5];
                Languages = data[3];
            }
            if ((!RaceSkill1.Enabled || RaceSkill1.Text != "Select One") && (!RaceSkill2.Enabled || RaceSkill2.Text != "Select One")) { InformationFilled = true; }
        }
        private void RaceSkill1_SelectedValueChanged(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(PC.Race)) { return; }
            string defaultProf = Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(PC.Race + ":" + SubRaces.Text).Split("_")[9];
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
            Prof1 = data[4];
            if ((!RaceLang.Enabled || RaceLang.Text != "Select One") && (!RaceSkill2.Enabled || RaceSkill2.Text != "Select One")) { InformationFilled = true; }
        }
        private void RaceSkill2_SelectedValueChanged(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(PC.Race)) { return; }
            string[] data = Info.Text.Split("\n");
            string[] prof2 = data[4].Split(Prof1);
            prof2[1] = RaceSkill2.Text;
            data[4] = prof2[0] + Prof1 + ", " + prof2[1];
            Info.Text = data[0] + "\n" + data[1] + "\n" + data[2] + "\n" + data[3] + "\n" + data[4] + "\n" + data[5];
            Prof2 = data[4];
            if ((!RaceLang.Enabled || RaceLang.Text != "Select One") && (!RaceSkill1.Enabled || RaceSkill1.Text != "Select One")) { InformationFilled = true; }
        }
        #endregion
        #endregion

        private readonly PictureBox RacePreview = new() {
            //Image = Dungeons_and_Dragons_Player_Maker.Races.Human,
            ImageLocation = ImageLocation.GetImage("HUMAN"), 
            Location = new Point(223, 6),
            Size = new Size(275, 316),
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.Transparent
        };
        #endregion

        private void updateInfo(string RaceName) {
            try {
                string[] info = Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(RaceName + ":" + SubRaces.Text).Split("_");
                string final = "";
                final = final + "STR: " + info[0] + " DEX: " + info[1] + " CON: " + info[2] + " WIS: " + info[3] + " INT: " + info[4] + " CHA: " + info[5] + "\n";
                final = final + "Speed: " + info[6] + "\n";
                final = final + "Size: " + info[7] + "\n";

                final = final + "Languages: " + info[8] + "\n";
                final = Prof2 != "" ? final + Prof2 + "\n" :
                        Prof1 != "" ? final + Prof1 + "\n" : final + "Proficiencies: " + info[9] + "\n";
                final = final + "Notes: " + info[10];
                Info.Text = final;
            } catch (Exception) {
                Info.Text = "No data found.";
            }
        }
    }
}