using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization {
    public partial class StatDataPage : TabPage {
        private readonly PC PC;

        [Obsolete]
        public StatDataPage(PC Player) {
            PC = Player;
            Text = "Abilities and Stats";
            BackColor = Color.White;
            
            InitializeComponent();
            
            StatLocations = new[] { Value1_Options, Value2_Options, Value3_Options, Value4_Options, Value5_Options, Value6_Options };
            Controls.AddRange(new Control[]{ STRValue, CHAValue, WISValue, INTValue, CONValue, DEXValue, STRLabel, DEXLabel, CONLabel, WISLabel, INTLabel, CHALabel,
                                             SaveAndPrint, SaveAndClose, Reroll, NameLabel, NameTextBox, AlignmentCombBox, AlignmentLabel, CheckBoxRegion, Roll1, Roll1Value, Roll2, Roll2Value,
                                             Roll3, Roll3Value, Roll4, Roll4Value, Roll5, Roll5Value, Roll6, Roll6Value, SaveAndExport
                              });
            Controls.AddRange(StatLocations);
            
            Roll1Value.Text = stats["Roll 1"].ToString(); Roll2Value.Text = stats["Roll 2"].ToString(); Roll3Value.Text = stats["Roll 3"].ToString();
            Roll4Value.Text = stats["Roll 4"].ToString(); Roll5Value.Text = stats["Roll 5"].ToString(); Roll6Value.Text = stats["Roll 6"].ToString();
            
            AddEvents();

            CheckBoxRegion.Controls.AddRange(new[] {STR_PLUS, DEX_PLUS, CON_PLUS, WIS_PLUS, INT_PLUS, CHA_PLUS});
            this.Enter += OnShown;
            Scale(.75f);
        }

        [Obsolete]
        private void AddEvents() {
            foreach (ComboBox c in StatLocations) { c.SelectedValueChanged += StatPlaceChanged; }
            SaveAndPrint.Click += SaveAndPrint_Click;
            SaveAndClose.Click += SaveAndClose_Click;
            Reroll.Click += ReRoll_Click;
            SaveAndExport.Click += SaveAndExport_Click;
            NameTextBox.TextChanged += NameTextBox_ValueChanged;
            AlignmentCombBox.SelectedValueChanged += Alignment_ValueChanged;
            foreach(CheckBox c in new[] { STR_PLUS, DEX_PLUS, CON_PLUS, WIS_PLUS, INT_PLUS, CHA_PLUS }) {c.CheckedChanged += CheckBonus;}
        }

        #region Controls
        private readonly Button SaveAndPrint = new() {
            Text = "Save + Print",
            Size = new Size(133, 75),
            Location = new Point(29, 385),
            Enabled = false
        };
        [Obsolete]
        private void SaveAndPrint_Click(object sender, EventArgs e) {
            PC.Name = NameTextBox.Text;
            PC.Alignment = AlignmentCombBox.Text;
            int[] stats = { int.Parse(STRValue.Text.Split("+")[0]), int.Parse(DEXValue.Text.Split("+")[0]), int.Parse(CONValue.Text.Split("+")[0]),
                int.Parse(INTValue.Text.Split("+")[0]), int.Parse(WISValue.Text.Split("+")[0]), int.Parse(CHAValue.Text.Split("+")[0]) };
            PC.Stats = stats;
            try {Engine.SaveData.Characters.Add(PC.Name, PC);} catch (Exception) {}
            IO.SaveDataToDisk();
            Form print = new PrintSheet(PC);
            print.Show();

        }

        private readonly Button SaveAndClose = new() {
            Enabled = false,
            Text = "Save + Close",
            Size = new Size(133, 75),
            Location = new Point(313, 385)
        };
        [Obsolete]
        private void SaveAndClose_Click(object sender, EventArgs e) {
            PC.Name = NameTextBox.Text;
            PC.Alignment = AlignmentCombBox.Text;
            int[] stats = { int.Parse(STRValue.Text), int.Parse(DEXValue.Text), int.Parse(CONValue.Text), int.Parse(INTValue.Text), int.Parse(WISValue.Text), int.Parse(CHAValue.Text) };
            PC.Stats = stats;
            try {Engine.SaveData.Characters.Add(PC.Name, PC);} catch (Exception) { }
            IO.SaveDataToDisk();
            FindForm().Close();
        }

        private readonly Button SaveAndExport = new() {
            Size = new Size(133, 75),
            Location = new Point(171, 385),
            Enabled = false,
            Text = "Save + Share"
        };
        [Obsolete]
        private void SaveAndExport_Click(object sender, EventArgs e) {
            PC.Name = NameTextBox.Text;
            PC.Alignment = AlignmentCombBox.Text;
            int[] stats = { int.Parse(STRValue.Text), int.Parse(DEXValue.Text), int.Parse(CONValue.Text), int.Parse(INTValue.Text), int.Parse(WISValue.Text), int.Parse(CHAValue.Text) };
            PC.Stats = stats;
            try { Engine.SaveData.Characters.Add(PC.Name, PC); } catch (Exception) { }
            IO.SaveDataToDisk();
            PC.save();
            MessageBox.Show("Your character has been saved.","Character Wizard");
        }
        #region Personality
        private readonly Label NameLabel = new() {
            Text = "Name: ",
            Location = new Point(118, 15),
            Size = new Size(72, 25),
            TextAlign = ContentAlignment.MiddleRight
        };
        private readonly TextBox NameTextBox = new() {
            TextAlign = HorizontalAlignment.Left,
            Size = new Size(125, 27),
            Location = new Point(196, 15)
        };
        private void NameTextBox_ValueChanged(object sender, EventArgs e) { PC.Name = NameTextBox.Text; 
            if (STRValue.Text != "---" && DEXValue.Text != "---" && CONValue.Text != "---" &&
                 INTValue.Text != "---" && WISValue.Text != "---" && CHAValue.Text != "---" && NameTextBox.Text != "") { SaveAndExport.Enabled = true; SaveAndPrint.Enabled = true; SaveAndClose.Enabled = true; }
        }

        private readonly Label AlignmentLabel = new() {
            TextAlign = ContentAlignment.MiddleRight,
            Text = "Alignment: ",
            Size = new Size(93, 25),
            Location = new Point(97, 48)
        };
        private readonly ComboBox AlignmentCombBox = new() {
            Items = {"Chaotic Good", "Neutral Good","Lawful Good",
                     "Chaotic Neutral", "Neutral", "Lawful Neutral",
                     "Chaotic Evil", "Neutral Evil","Lawful Evil"},
            Size = new Size(125, 28),
            Location = new Point(196, 48),
            Text = "Neutral"
        };
        private void Alignment_ValueChanged(object sender, EventArgs e) { PC.Alignment = AlignmentCombBox.Text; }
        #endregion
        #region Labels - Stat Display
        #region Stat Names
        private readonly Label STRLabel = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "STR",
            Size = new Size(62, 25),
            Location = new Point(29, 102)
        };
        private readonly Label DEXLabel = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "DEX",
            Size = new Size(62, 25),
            Location = new Point(100, 102)
        };
        private readonly Label CONLabel = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "CON",
            Size = new Size(62, 25),
            Location = new Point(171, 102)
        };
        private readonly Label INTLabel = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "INT",
            Size = new Size(62, 25),
            Location = new Point(242, 102)
        };
        private readonly Label WISLabel = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "WIS",
            Size = new Size(62, 25),
            Location = new Point(313, 102)
        };
        private readonly Label CHALabel = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "CHA",
            Size = new Size(62, 25),
            Location = new Point(384, 102)
        };
        #endregion
        #region Stat Values
        private readonly Label STRValue = new() {
            Name = "STRValue",
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "---",
            Size = new Size(62, 25),
            Location = new Point(29, 127)
        };
        private readonly Label DEXValue = new() {
            Name = "DEXValue",
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "---",
            Size = new Size(62, 25),
            Location = new Point(100, 127)
        };
        private readonly Label CONValue = new() {
            Name = "CONValue",
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "---",
            Size = new Size(62, 25),
            Location = new Point(171, 127)
        };
        private readonly Label INTValue = new() {
            Name = "INTValue",
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "---",
            Size = new Size(62, 25),
            Location = new Point(242, 127)
        };
        private readonly Label WISValue = new() {
            Name = "WISValue",
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "---",
            Size = new Size(62, 25),
            Location = new Point(313, 127)
        };
        private readonly Label CHAValue = new() {
            Name = "CHAValue",
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "---",
            Size = new Size(62, 25),
            Location = new Point(384, 127)
        };
 
        private void updateStat(string stat, string RollValue) {
            string[] Stats = null;
            try { Stats = Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(PC.Race).Split("_"); } catch { Stats = Engine.Homebrew.HomebrewRaces[PC.Race].StatBonus.Split("_"); }

            switch (stat) {
                case "STR":     
                    STRValue.Text = (stats[RollValue] + int.Parse(Stats[0])).ToString();
                    break;
                case "DEX":
                    DEXValue.Text = (stats[RollValue] + int.Parse(Stats[1])).ToString();
                    break;
                case "CON":
                    CONValue.Text = (stats[RollValue] + int.Parse(Stats[2])).ToString();
                    break;
                case "INT":
                    INTValue.Text = (stats[RollValue] + int.Parse(Stats[3])).ToString();
                    break;
                case "WIS":
                    WISValue.Text = (stats[RollValue] + int.Parse(Stats[4])).ToString();
                    break;
                case "CHA":
                    CHAValue.Text = (stats[RollValue] + int.Parse(Stats[5])).ToString();
                    break;
            }
            if (STRValue.Text != "---" && DEXValue.Text != "---" && CONValue.Text != "---" &&
                INTValue.Text != "---" && WISValue.Text != "---" && CHAValue.Text != "---" && NameTextBox.Text != "") { SaveAndExport.Enabled = true; SaveAndPrint.Enabled = true; SaveAndClose.Enabled = true; }
        }
        #endregion
        #region Stat Selection
        #region Roll Display
        #region Roll Labels
        private readonly Label Roll1 = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Roll 1",
            Size = new Size(62, 25),
            Location = new Point(29, 241)
        };
        private readonly Label Roll2 = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Roll 2",
            Size = new Size(62, 25),
            Location = new Point(100, 241)
        };
        private readonly Label Roll3 = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Roll 3",
            Size = new Size(62, 25),
            Location = new Point(171, 241)
        };
        private readonly Label Roll4 = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Roll 4",
            Size = new Size(62, 25),
            Location = new Point(242, 241)
        };
        private readonly Label Roll5 = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Roll 5",
            Size = new Size(62, 25),
            Location = new Point(313, 241)
        };
        private readonly Label Roll6 = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Roll 6",
            Size = new Size(62, 25),
            Location = new Point(384, 241)
        };
        #endregion
        #region RollValues
        private readonly Label Roll1Value = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(62, 25),
            Location = new Point(29, 266)
        };
        private readonly Label Roll2Value = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(62, 25),
            Location = new Point(100, 266)
        };
        private readonly Label Roll3Value = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(62, 25),
            Location = new Point(171, 266)
        };
        private readonly Label Roll4Value = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(62, 25),
            Location = new Point(242, 266)
        };
        private readonly Label Roll5Value = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(62, 25),
            Location = new Point(313, 266)
        };
        private readonly Label Roll6Value = new() {
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(62, 25),
            Location = new Point(384, 266)
        };
        #endregion
        #endregion
        private string Value1_Prev = "---";
        private string Value2_Prev = "---";
        private string Value3_Prev = "---";
        private string Value4_Prev = "---";
        private string Value5_Prev = "---";
        private string Value6_Prev = "---";
        private readonly ComboBox Value1_Options = new() {
            Name = "Value1_Options",
            Items = { "---", "STR", "DEX", "CON", "INT", "WIS", "CHA" },
            Size = new Size(62, 28),
            Location = new Point(29, 294),
            Text = "---"
        };
        private readonly ComboBox Value2_Options = new() {
            Name = "Value2_Options",
            Items = { "---", "STR", "DEX", "CON", "INT", "WIS", "CHA" },
            Size = new Size(62, 28),
            Location = new Point(100, 294),
            Text = "---"
        };
        private readonly ComboBox Value3_Options = new() {
            Name = "Value3_Options",
            Items = { "---", "STR", "DEX", "CON", "INT", "WIS", "CHA" },
            Size = new Size(62, 28),
            Location = new Point(171, 295),
            Text = "---"
        };
        private readonly ComboBox Value4_Options = new() {
            Name = "Value4_Options",
            Items = { "---", "STR", "DEX", "CON", "INT", "WIS", "CHA" },
            Size = new Size(62, 28),
            Location = new Point(242, 294),
            Text = "---"
        };
        private readonly ComboBox Value5_Options = new() {
            Name = "Value5_Options",
            Items = { "---", "STR", "DEX", "CON", "INT", "WIS", "CHA" },
            Size = new Size(62, 28),
            Location = new Point(313, 294),
            Text = "---"
        };
        private readonly ComboBox Value6_Options = new() {
            Name = "Value6_Options",
            Items = { "---","STR", "DEX", "CON", "INT", "WIS", "CHA" },
            Size = new Size(62, 28),
            Location = new Point(384, 294),
            Text = "---"
        };
        private readonly ComboBox[] StatLocations;
        private void StatPlaceChanged(object sender, EventArgs e) {
            ComboBox cb = (ComboBox)sender;
            foreach(ComboBox c in StatLocations) {
                if (c == (ComboBox)sender) { continue; }
                c.Text = c.Text == "---" ? "---" : c.Text != "---" ? c.Text: (string)c.SelectedItem;
                c.Items.Clear();
                c.Items.AddRange(remainingValues().ToArray());
                c.Items.Remove(c.Text);
            }
            switch (cb.Name) {
                case "Value1_Options":
                    if (cb.Text != Value1_Prev) {
                        if (cb.Text == "---") { Controls.Find(Value1_Prev + "Value", true)[0].Text = "---"; }
                        Value1_Prev = cb.Text; }
                    break;
                case "Value2_Options":
                    if (cb.Text != Value2_Prev) {
                        if (cb.Text == "---") { Controls.Find(Value2_Prev + "Value", true)[0].Text = "---"; }
                        Value2_Prev = cb.Text; }
                    break;
                case "Value3_Options":
                    if (cb.Text != Value3_Prev) {
                        if (cb.Text == "---") { Controls.Find(Value3_Prev + "Value", true)[0].Text = "---"; }
                        Value3_Prev = cb.Text; }
                    break;
                case "Value4_Options":
                    if (cb.Text != Value4_Prev) {
                        if (cb.Text == "---") { Controls.Find(Value4_Prev + "Value", true)[0].Text = "---"; }
                        Value4_Prev = cb.Text; }
                    break;
                case "Value5_Options":
                    if (cb.Text != Value5_Prev) {
                        if (cb.Text == "---") { Controls.Find(Value5_Prev + "Value", true)[0].Text = "---"; }
                        Value5_Prev = cb.Text; }
                    break;
                case "Value6_Options":
                    if (cb.Text != Value6_Prev) {
                        if (cb.Text == "---") { Controls.Find(Value6_Prev + "Value", true)[0].Text = "---"; }
                        Value6_Prev = cb.Text; }
                    break;
            }
            updateStat(cb.Text, "Roll " + cb.Name.Split("_")[0].Split("Value")[1]);
        }
 
        private List<string> remainingValues() {
 
            List<string> statTypes = new() { "---", "STR", "DEX", "CON", "INT", "WIS", "CHA" };
            foreach(ComboBox c in StatLocations) {
                if(c.Text == "---") { continue; }
                statTypes.Remove(c.Text);
            }
            return statTypes;
        }
        #endregion
        #endregion
        #region Race Bonus
        private readonly Panel CheckBoxRegion = new() {
            Location = new Point(6, 164),
            Size = new Size(472, 40)
        };
        private readonly CheckBox STR_PLUS = new() {
            Name = "STR_PLUS",
            Appearance = Appearance.Button,
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "+ 1",
            Size = new Size(62, 34),
            Location = new Point(23, 3),
            Enabled = false
        };
        private readonly CheckBox DEX_PLUS = new() {
            Name = "DEX_PLUS",
            Appearance = Appearance.Button,
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "+ 1",
            Size = new Size(62, 34),
            Location = new Point(94, 3),
            Enabled = false
        };
        private readonly CheckBox CON_PLUS = new() {
            Name = "CON_PLUS",
            Appearance = Appearance.Button,
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "+ 1",
            Size = new Size(62, 34),
            Location = new Point(165, 3),
            Enabled = false
        };
        private readonly CheckBox INT_PLUS = new() {
            Name = "INT_PLUS",
            Appearance = Appearance.Button,
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "+ 1",
            Size = new Size(62, 34),
            Location = new Point(236, 3),
            Enabled = false
        };
        private readonly CheckBox WIS_PLUS = new() {
            Name = "WIS_PLUS",
            Appearance = Appearance.Button,
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "+ 1",
            Size = new Size(62, 34),
            Location = new Point(307, 3),
            Enabled = false
        };
        private readonly CheckBox CHA_PLUS = new() {
            Name = "CHA_PLUS",
            Appearance = Appearance.Button,
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "+ 1",
            Size = new Size(62, 34),
            Location = new Point(378, 3),
            Enabled = false
        };
        private int numberAllowed = 0;
        private int numberSelected = 0;
        private void CheckBonus(object sender, EventArgs e) {
            numberSelected = 0;
            foreach (CheckBox cb in new[] { STR_PLUS, DEX_PLUS, CON_PLUS, WIS_PLUS, INT_PLUS, CHA_PLUS }) {
                if (cb.Checked) { numberSelected++; }
                if (cb.Checked && numberSelected > numberAllowed) { cb.Checked = false; }
            }
                try {
                    switch (((CheckBox)sender).Name) {
                        case "STR_PLUS":
                            STRValue.Text = STR_PLUS.Checked ? (int.Parse(STRValue.Text) + 1).ToString() : (int.Parse(STRValue.Text)-1).ToString();
                            break;
                        case "DEX_PLUS":
                            DEXValue.Text = DEX_PLUS.Checked ? (int.Parse(DEXValue.Text) + 1).ToString() : (int.Parse(DEXValue.Text)-1).ToString();
                            break;
                        case "CON_PLUS":
                            CONValue.Text = CON_PLUS.Checked ? (int.Parse(CONValue.Text) + 1).ToString() : (int.Parse(CONValue.Text)-1).ToString();
                            break;
                        case "INT_PLUS":
                            INTValue.Text = INT_PLUS.Checked ? (int.Parse(INTValue.Text) + 1).ToString() : (int.Parse(INTValue.Text)-1).ToString();
                            break;
                        case "WIS_PLUS":
                            WISValue.Text = WIS_PLUS.Checked ? (int.Parse(WISValue.Text) + 1).ToString() : (int.Parse(WISValue.Text)-1).ToString();
                            break;
                        case "CHA_PLUS":
                            CHAValue.Text = CHA_PLUS.Checked ? (int.Parse(CHAValue.Text) + 1).ToString() : (int.Parse(CHAValue.Text)-1).ToString();
                            break;
                    }
                } catch (FormatException) { }
        }
        #endregion
        #endregion

        private readonly Button Reroll = new() {
            Size = new Size(94, 29),
            Location = new Point(352, 328),
            Text = "Reroll",
        };
        private void ReRoll_Click(object sender, EventArgs e) {
            STRValue.Text = "---"; DEXValue.Text = "---"; CONValue.Text = "---";
            WISValue.Text = "---"; INTValue.Text = "---"; CHAValue.Text = "---";
            Roll1Value.Text = "---"; Roll2Value.Text = "---"; Roll3Value.Text = "---";
            Roll4Value.Text = "---"; Roll5Value.Text = "---"; Roll6Value.Text = "---";
            Value1_Prev = "---"; Value2_Prev = "---"; Value3_Prev = "---"; Value4_Prev = "---";
            Value5_Prev = "---"; Value6_Prev = "---";
            Value1_Options.Text = "---"; Value2_Options.Text = "---"; Value3_Options.Text = "---";
            Value4_Options.Text = "---"; Value5_Options.Text = "---"; Value6_Options.Text = "---";
            foreach(string key in stats.Keys) {
                stats[key] = GenerateStat();
            }
            Roll1Value.Text = stats["Roll 1"].ToString(); Roll2Value.Text = stats["Roll 2"].ToString();
            Roll3Value.Text = stats["Roll 3"].ToString(); Roll4Value.Text = stats["Roll 4"].ToString();
            Roll5Value.Text = stats["Roll 5"].ToString(); Roll6Value.Text = stats["Roll 6"].ToString();
        }

        private readonly Dictionary<string, int> stats = new() {
            { "Roll 1", GenerateStat() },
            { "Roll 2", GenerateStat() },
            { "Roll 3", GenerateStat() },
            { "Roll 4", GenerateStat() },
            { "Roll 5", GenerateStat() },
            { "Roll 6", GenerateStat() }
        };
        private static int GenerateStat() {
            List<int> rolls = new();
            for(int i = 0; i<4; i++) {
                rolls.Add(Engine.RNG.Next(1, 6));
            }
            return rolls.Sum() - rolls.Min();
        }

        private void OnShown(object sender, EventArgs e) {
            if (PC.Race == "Human:Variant" || PC.Race == "Half-Elf:Natural" || PC.Race == "Half-Elf:Variant") { numberAllowed = 2; foreach (CheckBox c in new[] { STR_PLUS, DEX_PLUS, CON_PLUS, WIS_PLUS, INT_PLUS, CHA_PLUS }) { c.Enabled = true; } }
        }

    }
}