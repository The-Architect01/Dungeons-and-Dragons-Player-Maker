using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Classes {
    public partial class ClassTab : TabPage {
        private readonly PC PC;

        #region Variables - Do not Change
        private readonly Label[] ClassName;
        private int pos = 0;
        private readonly Control[] ControlsOnForm;

        public event EventHandler OnReady;
        public event EventHandler OnReset;

        private bool _ready = false;

        private bool InformationFilled {
            get { return _ready; }
            set {
                _ready = value; if (value) {
                    PC.Class = PC.Class.Split(":")[0] + ":" + SubClasses.Text;
                    OnReady.Invoke(this, EventArgs.Empty);
                } else { OnReset.Invoke(this, EventArgs.Empty); }
            }
        }
        #endregion
        #region Variables -- Change to add new Class and/or subclass
        private static readonly List<string> Classes = new();
        private static readonly List<string> BARD_Subclasses = new();
        private static readonly List<string> BARBARIAN_Subclasses = new();
        private static readonly List<string> CLERIC_Subclasses = new();
        private static readonly List<string> DRUID_Subclasses = new();
        private static readonly List<string> FIGHTER_Subclasses = new();
        private static readonly List<string> MONK_Subclasses = new();
        private static readonly List<string> PALADIN_Subclasses = new();
        private static readonly List<string> RANGER_Subclasses = new();
        private static readonly List<string> ROGUE_Subclasses = new();
        private static readonly List<string> SORCERER_Subclasses = new();
        private static readonly List<string> WARLOCK_Subclasses = new();
        private static readonly List<string> WIZARD_Subclasses = new();
        private static readonly List<string> ARTIFICER_Subclasses = new();
        #endregion
        [Obsolete]
        public ClassTab(PC Player) { //Initalize
            PC = Player;
            InitializeList();
            InitializeComponent();
            ControlsOnForm = new Control[] { C1, C2, C3,C4,C5,C6, UP, DOWN, SubClasses, ClassPreview, ClassInfo, SubClassInfo };
            ClassName = new Label[] { C1, C2, C3, C4, C5, C6 };
            Controls.AddRange(ControlsOnForm);
            Text = "Classes";
            BackColor = Color.White;

            foreach (Label l in ClassName) { l.Click += ClassName_Click; l.MouseEnter += ClassName_Enter; }
            UP.Click += UP_Click; DOWN.Click += DOWN_Click;
            SubClasses.SelectedValueChanged += SubClasses_OnValueChanged;
            Scale(.75f);
        }

        void InitializeList() {
            foreach (string book in Engine.SaveData.SourceBooks.Keys) {
                if (Engine.SaveData.SourceBooks[book]) {
                    foreach (string Class in SourceBooks.Sourcebook(book)["Classes"]) {
                        string BaseClass = Class.Split(":")[0];
                        string Subclass = Class.Split(":")[1];
                        if (!Classes.Contains(BaseClass)) { Classes.Add(BaseClass); }
                        switch (BaseClass.ToUpper()) {
                            case "BARD":
                                BARD_Subclasses.Add(Subclass);
                                break;
                            case "BARBARIAN":
                                BARBARIAN_Subclasses.Add(Subclass);
                                break;
                            case "CLERIC":
                                CLERIC_Subclasses.Add(Subclass);
                                break;
                            case "DRUID":
                                DRUID_Subclasses.Add(Subclass);
                                break;
                            case "FIGHTER":
                                FIGHTER_Subclasses.Add(Subclass);
                                break;
                            case "MONK":
                                MONK_Subclasses.Add(Subclass);
                                break;
                            case "PALADIN":
                                PALADIN_Subclasses.Add(Subclass);
                                break;
                            case "RANGER":
                                RANGER_Subclasses.Add(Subclass);
                                break;
                            case "ROGUE":
                                ROGUE_Subclasses.Add(Subclass);
                                break;
                            case "SORCERER":
                                SORCERER_Subclasses.Add(Subclass);
                                break;
                            case "WARLOCK":
                                WARLOCK_Subclasses.Add(Subclass);
                                break;
                            case "WIZARD":
                                WIZARD_Subclasses.Add(Subclass);
                                break;
                        }
                    }
                }
            }
        }

        #region Controls
        #region Labels -- Class Names
        private readonly Label C1 = new() {
            Size = new Size(211, 25),
            Location = new Point(6, 46),
            Text = "Barbarian",
        };
        private readonly Label C2 = new() {
            Size = new Size(211, 25),
            Location = new Point(6, 83),
            Text = "Bard",
        };
        private readonly Label C3 = new() {
            Size = new Size(211, 25),
            Location = new Point(6, 120),
            Text = "Cleric",
        };
        private readonly Label C4 = new() {
            Size = new Size(211, 25),
            Location = new Point(6, 157),
            Text = "Druid",
        };
        private readonly Label C5 = new() {
            Size = new Size(211, 25),
            Location = new Point(6, 194),
            Text = "Fighter",
        };
        private readonly Label C6 = new() {
            Size = new Size(211, 25),
            Location = new Point(6, 231),
            Text = "Monk",
        };
        private void ClassName_Click(object sender, EventArgs e) {
            PC.Class = ((Label)sender).Text;
            ClassPreview.Load(ImageLocation.GetImage(PC.Class));
            if (PC.Class == "Monk") { ClassInfo.Font = new Font("Segoe UI", 6.75f); } else { ClassInfo.Font = new Font("Segoe UI", 8f); }
            SubClasses.Items.Clear();
            SubClasses.Items.AddRange(GetSubClass(PC.Class));
            SubClasses.SelectedIndex = 0;
            InformationFilled = false;
        }
        private void ClassName_Enter(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(PC.Class)) {
                return;
            } else {
                ClassPreview.Load(ImageLocation.GetImage(((Label)sender).Text));
                ClassUpdate(((Label)sender).Text, "Select One");
            }
        }
        #endregion
        #region Buttons
        private readonly Button UP = new() {
            Text = "UP",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(208, 28),
            Location = new Point(6, 6),
        };
        private readonly Button DOWN = new() {
            Text = "DOWN",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(208, 28),
            Location = new Point(6,259),
        };

        private void UP_Click(object sender, EventArgs e) {
            pos--;
            if (pos < 0) { pos = Classes.Count - 1; }
            UpdateVisibleClasses();
        }
        private void DOWN_Click(object sender, EventArgs e) {
            pos++;
            if (pos > Classes.Count - 1) { pos = 0; }
            UpdateVisibleClasses();
        }
        private void UpdateVisibleClasses() {
            int j = pos;
            foreach (Label c in ClassName) {
                c.Text = Classes[j];
                if (j > Classes.Count - 2) { j = 0; } else { j++; }
            }
        }
        #endregion
        private readonly Label ClassInfo = new() {
            Location = new Point(6, 325),
            Size = new Size(265, 225),
            TextAlign = ContentAlignment.MiddleLeft
        };
        private readonly Label SubClassInfo = new() {
            Location = new Point(270, 325),
            Size = new Size(230, 225),
            Font = new Font("Segoe UI", 7.75f),
            TextAlign = ContentAlignment.MiddleLeft
        };
        private readonly ComboBox SubClasses = new() {
            Location = new Point(6, 294),
            Size = new Size(208, 28),
            Text = "Select One"
        };
        private void SubClasses_OnValueChanged(object sender, EventArgs e) {
            ClassUpdate(PC.Class, SubClasses.Text);
            InformationFilled = true;
        }

        private readonly PictureBox ClassPreview = new() {
            Image = Properties.Resources.Custom,
            //ImageLocation = ImageLocation.GetImage("Barbarian"),
            Size = new Size(275, 316),
            Location = new Point(223, 6),
            SizeMode = PictureBoxSizeMode.Zoom
        };
        #endregion

        private string[] GetSubClass(string Base) {
            return (Base.ToUpper()+"_Subclasses") switch {
                "BARD_Subclasses" => BARD_Subclasses.ToArray(),
                "BARBARIAN_Subclasses" =>BARBARIAN_Subclasses.ToArray(),
                "CLERIC_Subclasses" =>CLERIC_Subclasses.ToArray(),
                "DRUID_Subclasses"=>DRUID_Subclasses.ToArray(),
                "FIGHTER_Subclasses"=>FIGHTER_Subclasses.ToArray(),
                "MONK_Subclasses"=>MONK_Subclasses.ToArray(),
                "PALADIN_Subclasses"=>PALADIN_Subclasses.ToArray(),
                "RANGER_Subclasses"=>RANGER_Subclasses.ToArray(),
                "ROGUE_Subclasses"=>ROGUE_Subclasses.ToArray(),
                "SORCERER_Subclasses"=>SORCERER_Subclasses.ToArray(),
                "WARLOCK_Subclasses"=>WARLOCK_Subclasses.ToArray(),
                "WIZARD_Subclasses"=>WIZARD_Subclasses.ToArray(),
                "ARTIFICER_Subclasses"=>ARTIFICER_Subclasses.ToArray(),
                _=>null,
            };
        }

        private void ClassUpdate(string classBase, string subclass) { //Repopulates data
            string Class = string.IsNullOrEmpty(PC.Class) ? classBase : PC.Class.Split(":")[0];
            try {
                string[] baseClassStats = Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetString(Class + ":Base").Split("_");
                ClassInfo.Text = "Class Skill - Level:\n";
                foreach (string item in baseClassStats) {
                    ClassInfo.Text = ClassInfo.Text + item + "\n";
                }
            } catch (Exception) { ClassInfo.Text = "No Data Found"; }
            try {
                if (subclass.SequenceEqual("Select One")) { SubClassInfo.Text = "No Data Found"; } else {
                    string[] subStats = null;
                    if (Engine.Homebrew.HomebrewClasses.ContainsKey(Class + ":" + subclass)) {
                        subStats = Engine.Homebrew.HomebrewClasses[Class + ":" + subclass].Abilites.Split("_");
                        ClassPreview.Image = Properties.Resources.Custom;
                    } else {
                        subStats = Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetString(Class + ":" + subclass).Split("_");
                        ClassPreview.Load(ImageLocation.GetImage(Class));
                    }
                    SubClassInfo.Text = "Subclass Skill - Level:\n";
                    foreach (string item in subStats) {
                        SubClassInfo.Text = SubClassInfo.Text + item + "\n";
                    }
                }
            } catch (Exception) { SubClassInfo.Text = "No Data Found"; }
        }
    }
}