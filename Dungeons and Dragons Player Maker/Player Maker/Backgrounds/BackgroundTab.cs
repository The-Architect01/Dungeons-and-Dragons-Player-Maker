using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Backgrounds {
    public partial class BackgroundTab : TabPage {

        PC PC;

        Control[] controlsOnControl;
        Label[] BackgroundsVisible;
        readonly static string[] Backgrounds = { "Acolyte", "Criminal/Spy", "Folk Hero", "Haunted One","Noble","Sage","Soldier","Urchin" };
        int pos = 0;

        public event EventHandler OnReady;

        bool _ready = false;
        bool informationFilled { get { return _ready; } set { _ready = value; if (value) { OnReady.Invoke(this, EventArgs.Empty); } } }

        public BackgroundTab(PC Player) {
            Text = "Backgrounds";
            BackColor = Color.White;
            BackgroundsVisible = new Label[] { B1, B2, B3, B4, B5, B6 };
            controlsOnControl = new Control[] { B1, B2, B3, B4, B5, B6, UP, DOWN, label1, BackgroundBonus, BackgroundData, Personality, Ideal,Bond, Flaw };
            PC = Player;
            InitializeComponent();
            foreach(Label l in BackgroundsVisible) { l.Click += Background_Click; l.MouseEnter += Background_Hover; }
            UP.Click += UP_Click;
            DOWN.Click += DOWN_Click;
            Personality.SelectedValueChanged += ID_SelectedValueChanged;
            Ideal.SelectedValueChanged += ID_SelectedValueChanged;
            Bond.SelectedValueChanged += ID_SelectedValueChanged;
            Flaw.SelectedValueChanged += ID_SelectedValueChanged;
            Controls.AddRange(controlsOnControl);
        }

        #region Controls
        Label label1 = new() {
            Text = "Personality",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(492, 19),
            Location = new Point(6, 443)
        };
        #region Labels -- Names
        Label B1 = new() {
            Size = new Size(211, 25),
            Text = "Acolyte",
            Location = new Point(6, 46),
        };
        Label B2 = new() {
            Size = new Size(211, 25),
            Text = "Criminal/Spy",
            Location = new Point(6, 83),
        };
        Label B3 = new() {
            Size = new Size(211, 25),
            Text = "Folk Hero",
            Location = new Point(6, 120),
        };
        Label B4 = new() {
            Size = new Size(211, 25),
            Text = "Haunted One",
            Location = new Point(6, 157),
        };
        Label B5 = new() { 
            Size = new Size(211, 25),
            Text = "Noble",
            Location = new Point(6, 194),
        };
        Label B6 = new() {
            Size = new Size(211, 25),
            Text = "Sage",
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
            PC.Background = ((Label)sender).Text;
            try {
                string[] Skills = Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background + "-Skills").Split("_");
                BackgroundBonus.Text = "Background Bonus:\n";
                foreach (string s in Skills) { BackgroundBonus.Text += s + "\n"; }
                BackgroundData.Text = "Background Skill:\n" + Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background);
                Personality.Items.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background + "-Personality").Split("_"));
                Ideal.Items.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background + "-Ideal").Split("_"));
                Bond.Items.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background + "-Bond").Split("_"));
                Flaw.Items.AddRange(Dungeons_and_Dragons_Player_Maker.Backgrounds.ResourceManager.GetString(PC.Background + "-Flaw").Split("_"));
            } catch (NullReferenceException) {
                BackgroundData.Text = "Background Skill:\nNo Data Currently Available";
                BackgroundBonus.Text = "Background Bonus:\nNo Data Currently Available";
            }
        }
        #endregion
        Label BackgroundBonus = new() {
            TextAlign = ContentAlignment.MiddleLeft,
            Size = new Size(278, 281),
            Location = new Point(220, 6)
        };
        Label BackgroundData = new() {
            TextAlign = ContentAlignment.MiddleLeft,
            Size = new Size(492, 153),
            Location = new Point(6, 290)
        };

        Button UP = new() {
            Text = "UP",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(208, 28),
            Location = new Point(6, 6)
        };
        Button DOWN = new() {
            Text = "DOWN",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(208, 28),
            Location = new Point(6, 259)
        };

        private void UP_Click(object sender, EventArgs e) {
            pos--;
            if (pos < 0) { pos = Backgrounds.Length - 1; }
            UpdateVisibleBackgrounds();
        }
        private void DOWN_Click(object sender, EventArgs e) {
            pos++;
            if (pos > Backgrounds.Length - 1) { pos = 0; }
            UpdateVisibleBackgrounds();
        }
        private void UpdateVisibleBackgrounds() {
            int j = pos;
            foreach (Label c in BackgroundsVisible) {
                c.Text = Backgrounds[j];
                if (j > Backgrounds.Length - 2) { j = 0; } else { j++; }
            }
        }

        ComboBox Personality = new() {
            Text = "Select One",
            DropDownWidth = 650,
            Size = new Size(242, 28),
            Location = new Point(6, 465),
        };
        ComboBox Bond = new() { 
            Text = "Select One",
            DropDownWidth = 650,
            Size = new Size(242, 28),
            Location = new Point(6, 499),
        };
        ComboBox Ideal = new() {
            Text = "Select One",
            DropDownWidth = 650,
            Size = new Size(242, 28),
            Location = new Point(256, 465),
        };
        ComboBox Flaw = new() { 
            Text = "Select One",
            DropDownWidth = 650,
            Size = new Size(242, 28),
            Location = new Point(256, 499),
        };
        private void ID_SelectedValueChanged(object sender, EventArgs e) {
            if (!Personality.Text.SequenceEqual("Select One") && !Ideal.Text.SequenceEqual("Select One") &&
                !Bond.Text.SequenceEqual("Select One") && !Flaw.Text.SequenceEqual("Select One")) {
                informationFilled = true;
            }
        }
        #endregion


    }
}
