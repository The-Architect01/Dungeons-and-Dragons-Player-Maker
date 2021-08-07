using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization {
    public partial class StatDataPage : TabPage {

        PC PC;

        public StatDataPage(PC Player) {
            PC = Player;
            Text = "Abilities and Stats";
            BackColor = Color.White;
            InitializeComponent();
            StatLocations = new[] { Value1_Options, Value2_Options, Value3_Options, Value4_Options, Value5_Options, Value6_Options };
            foreach(ComboBox c in StatLocations) { c.SelectedValueChanged += StatPlaceChanged; }
            Controls.AddRange(StatLocations);
            Controls.AddRange(new[] {STRValue, CHAValue, WISValue, INTValue, CONValue, DEXValue });
            STRValue.Text = "STR: " + stats["STR"].ToString();DEXValue.Text = "DEX: " + stats["DEX"].ToString();CONValue.Text = "CON: " + stats["CON"].ToString();
            WISValue.Text = "WIS: " + stats["WIS"].ToString();INTValue.Text = "INT: " + stats["INT"].ToString();CHAValue.Text = "CHA: " + stats["CHA"].ToString();
        }

        #region Controls
        Button Confirm = new() {
            Text = "Confirm",
            Size = new Size(),
            Location = new Point(),
            Enabled = false
        };
        private void Confirm_Click(object sender, EventArgs e) {

        }
        Label NameLabel = new() {
            Text = "Name: ",
            Location = new Point(),
            Size = new Size(),
            TextAlign = ContentAlignment.MiddleRight
        };
        TextBox NameTextBox = new() {
            TextAlign = HorizontalAlignment.Left,
            Size = new Size(),
            Location = new Point()
        };
        private void NameTextBox_ValueChanged(object sender, EventArgs e) { PC.Name = NameTextBox.Text; }

        Label AlignmentLabel = new() {
            TextAlign = ContentAlignment.MiddleRight,
            Text = "Alignment: ",
            Size = new Size(),
            Location = new Point()
        };
        ComboBox AlignmentCombBox = new() {
            Items = {"Chaotic Good", "Neutral Good","Lawful Good",
                     "Chaotic Neutral", "Neutral", "Lawful Neutral",
                     "Chaotic Evil", "Neutral Evil","Lawful Evil"},
            Size = new Size(),
            Location = new Point()
        };
        private void Alignment_ValueChanged(object sender, EventArgs e) { PC.Alignment = AlignmentCombBox.Text; }

        #region Labels - Stat Display
        Label STRValue = new() {
            Size = new Size(150, 30),
            Location = new Point(176, 6)
        };
        Label DEXValue = new() {
            Size = new Size(150, 30),
            Location = new Point(176,56)
        };
        Label CONValue = new() {
            Size = new Size(150, 30),
            Location = new Point(176, 106)
        };
        Label INTValue = new() {
            Size = new Size(150, 30),
            Location = new Point(176, 156)
        };
        Label WISValue = new() {
            Size = new Size(150, 30),
            Location = new Point(176, 206)
        };
        Label CHAValue = new() {
            Size = new Size(150, 30),
            Location = new Point(176, 256)
        };
        private void updateStat(string stat) {
            switch (stat) {
                case "STR":
                    STRValue.Text = (stats[stat] + int.Parse(Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(PC.Race).Split("_")[0])).ToString();
                    break;
                case "DEX":
                    DEXValue.Text = (stats[stat] + int.Parse(Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(PC.Race).Split("_")[1])).ToString();
                    break;
                case "CON":
                    CONValue.Text = (stats[stat] + int.Parse(Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(PC.Race).Split("_")[2])).ToString();
                    break;
                case "INT":
                    INTValue.Text = (stats[stat] + int.Parse(Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(PC.Race).Split("_")[3])).ToString();
                    break;
                case "WIS":
                    WISValue.Text = (stats[stat] + int.Parse(Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(PC.Race).Split("_")[4])).ToString();
                    break;
                case "CHA":
                    CHAValue.Text = (stats[stat] + int.Parse(Dungeons_and_Dragons_Player_Maker.Races.ResourceManager.GetString(PC.Race).Split("_")[5])).ToString();
                    break;
            }
        }
        #endregion
        #region Stat Selection
        ComboBox Value1_Options = new() {
            Items = { "---", "STR", "DEX", "CON", "INT", "WIS", "CHA" },
            Size = new Size(150,30),
            Location = new Point(6,6),
            Text = "---"
        };
        ComboBox Value2_Options = new() {
            Items = { "---", "STR", "DEX", "CON", "INT", "WIS", "CHA" },
            Size = new Size(150, 30),
            Location = new Point(6,56),
            Text = "---"
        };
        ComboBox Value3_Options = new() {
            Items = { "---", "STR", "DEX", "CON", "INT", "WIS", "CHA" },
            Size = new Size(150, 30),
            Location = new Point(6,106),
            Text = "---"
        };
        ComboBox Value4_Options = new() {
            Items = { "---", "STR", "DEX", "CON", "INT", "WIS", "CHA" },
            Size = new Size(150, 30),
            Location = new Point(6, 156),
            Text = "---"
        };
        ComboBox Value5_Options = new() {
            Items = { "---", "STR", "DEX", "CON", "INT", "WIS", "CHA" },
            Size = new Size(150, 30),
            Location = new Point(6,206),
            Text = "---"
        };
        ComboBox Value6_Options = new() {
            Items = { "---","STR", "DEX", "CON", "INT", "WIS", "CHA" },
            Size = new Size(150, 30),
            Location = new Point(6,256),
            Text = "---"
        };
        ComboBox[] StatLocations;
        private void StatPlaceChanged(object sender, EventArgs e) {
            foreach(ComboBox c in StatLocations) {
                if (c == (ComboBox)sender) { continue; }
                c.Text = c.Text == "---" ? "---" : c.Text != "---" ? c.Text: (string)c.SelectedItem;
                c.Items.Clear();
                c.Items.AddRange(remainingValues().ToArray());
                c.Items.Remove(c.Text);
            }
            updateStat(((ComboBox)sender).Text);
        }
        private List<string> remainingValues() {
            List<string> statTypes = new List<string>() { "---", "STR", "DEX", "CON", "INT", "WIS", "CHA" };
            foreach(ComboBox c in StatLocations) {
                if(c.Text == "---") { continue; }
                statTypes.Remove(c.Text);
            }
            return statTypes;
        }
        #endregion
        #region Race Bonus
        Panel Region = new() {

        };
        CheckBox STR_PLUS = new() {

        };
        CheckBox DEX_PLUS = new() { };
        CheckBox CON_PLUS = new() { };
        CheckBox INT_PLUS = new() { };
        CheckBox WIS_PLUS = new() { };
        CheckBox CHA_PLUS = new() { };
        private void CheckBonus(object sender, EventArgs e) { }
        #endregion
        #endregion

        Dictionary<string, int> stats = new() {
            { "STR", GenerateStat() },
            { "DEX", GenerateStat() },
            { "CON", GenerateStat() },
            { "INT", GenerateStat() },
            { "WIS", GenerateStat() },
            { "CHA", GenerateStat() }
        };
        private static int GenerateStat() {
            List<int> rolls = new();
            for(int i = 0; i<4; i++) {
                rolls.Add(Engine.RNG.Next(1, 6));
            }
            return rolls.Sum() - rolls.Min();
        }

    }
}
