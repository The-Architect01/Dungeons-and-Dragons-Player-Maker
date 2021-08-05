﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Classes {
    public partial class ClassTab : TabPage {

        PC PC;

        #region Variables
        Label[] ClassName;
        static readonly string[] Classes = { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
        int pos = 0;
        Control[] ControlsOnForm;

        static readonly string[] BARD_Subclasses = { "Lore", "Valor" };
        static readonly string[] BARBARIAN_Subclasses = { "Berserker", "Totem Warrior" };
        static readonly string[] CLERIC_Subclasses = { "Knowledge", "Life", "Light", "Nature", "Tempest", "Trickery", "War" };
        static readonly string[] DRUID_Subclasses = { "Circle of Land - Artic", "Circle of Land - Coast", "Circle of Land - Desert", "Circle of Land - Forest",
        "Circle of Land - Grassland", "Circle of Land - Mountain","Circle of Land - Swamp","Circle of Land - Underdark","Circle of the Moon"};
        static readonly string[] FIGHTER_Subclasses = { "Champion", "Battle Master", "Eldritch Knight" };
        static readonly string[] MONK_Subclasses = { "Way of the Open Hand", "Way of the Shadow", "Way of the Four Elements" };
        static readonly string[] PALADIN_Subclasses = { "Oath of Devotion", "Oath of the Ancients", "Oath of Vengeance" };
        static readonly string[] RANGER_Subclasses = { "Hunter", "Beast Master" };
        static readonly string[] ROGUE_Subclasses = { "Thief", "Assassin", "Arcane Trickster" };
        static readonly string[] SORCERER_Subclasses = { "Draconic Bloodline", "Wild Magic" };
        static readonly string[] WARLOCK_Subclasses = { "The Archfey", "The Fiend", "The Great Old One" };
        static readonly string[] WIZARD_Subclasses = { "Abjuration", "Conjuration", "Divination", "Enchantment", "Evocation", "Illusion", "Necromancy", "Transmuation" };
        static readonly string[] ARTIFICER_Subclasses = { };
        #endregion

        public event EventHandler OnReady;

        bool _ready = false;
        bool informationFilled { get { return _ready; } set { _ready = value; if (value) { OnReady.Invoke(this, EventArgs.Empty); } } }

        public ClassTab(PC Player) {
            PC = Player;
            InitializeComponent();
            ControlsOnForm = new Control[] { C1, C2, C3,C4,C5,C6, UP, DOWN, SubClasses, ClassPreview, ClassInfo, SubClassInfo };
            ClassName = new Label[] { C1, C2, C3, C4, C5, C6 };
            Controls.AddRange(ControlsOnForm);
            Text = "Classes";
            BackColor = Color.White;

            foreach (Label l in ClassName) { l.Click += ClassName_Click; l.MouseEnter += ClassName_Enter; }
            UP.Click += UP_Click; DOWN.Click += DOWN_Click;
            SubClasses.SelectedValueChanged += SubClasses_OnValueChanged;
        }

        #region Controls
        #region Labels -- Class Names
        Label C1 = new() {
            Size = new Size(211, 25),
            Location = new Point(6, 46),
            Text = "Barbarian",
        };
        Label C2 = new() {
            Size = new Size(211, 25),
            Location = new Point(6, 83),
            Text = "Bard",
        };
        Label C3 = new() {
            Size = new Size(211, 25),
            Location = new Point(6, 120),
            Text = "Cleric",
        };
        Label C4 = new() {
            Size = new Size(211, 25),
            Location = new Point(6, 157),
            Text = "Druid",
        };
        Label C5 = new() {
            Size = new Size(211, 25),
            Location = new Point(6, 194),
            Text = "Fighter",
        };
        Label C6 = new() {
            Size = new Size(211, 25),
            Location = new Point(6, 231),
            Text = "Monk",
        };
        private void ClassName_Click(object sender, EventArgs e) {
            PC.Class = ((Label)sender).Text;
            ClassPreview.Image = (Image)Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetObject(PC.Class);
            SubClasses.Items.Clear();
            SubClasses.Items.AddRange((string[])this.GetType().GetField((PC.Class.ToUpper() + "_Subclasses").ToString(),
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static).GetValue(this));
            SubClasses.SelectedIndex = 0;
            classUpdate(PC.Class, SubClasses.Text);
        }
        private void ClassName_Enter(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(PC.Class)) {
                ClassPreview.Image = (Image)Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetObject(PC.Class);
                classUpdate(PC.Class, SubClasses.Text);
            } else {
                ClassPreview.Image = (Image)Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetObject(((Label)sender).Text);
                classUpdate(((Label)sender).Text, "Select One");
            }
        }
        #endregion
        #region Buttons
        Button UP = new() {
            Text = "UP",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(208, 28),
            Location = new Point(6, 6),
        };
        Button DOWN = new() {
            Text = "DOWN",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(208, 28),
            Location = new Point(6,259),
        };

        private void UP_Click(object sender, EventArgs e) {
            pos--;
            if (pos < 0) { pos = Classes.Length - 1; }
            UpdateVisibleClasses();
        }
        private void DOWN_Click(object sender, EventArgs e) {
            pos++;
            if (pos > Classes.Length - 1) { pos = 0; }
            UpdateVisibleClasses();
        }
        private void UpdateVisibleClasses() {
            int j = pos;
            foreach (Label c in ClassName) {
                c.Text = Classes[j];
                if (j > Classes.Length - 2) { j = 0; } else { j++; }
            }
        }
        #endregion
        Label ClassInfo = new() {
            Location = new Point(6, 325),
            Size = new Size(222, 224),
            TextAlign = ContentAlignment.MiddleLeft
        };
        Label SubClassInfo = new() {
            Location = new Point(234, 325),
            Size = new Size(264, 224),
            TextAlign = ContentAlignment.MiddleLeft
        };

        ComboBox SubClasses = new() {
            Location = new Point(6, 294),
            Size = new Size(208, 28),
            Text = "Select One"
        };
        private void SubClasses_OnValueChanged(object sender, EventArgs e) {
            classUpdate(PC.Class, SubClasses.Text);
            informationFilled = true;
        }

        PictureBox ClassPreview = new() {
            Image = Dungeons_and_Dragons_Player_Maker.Classes.Barbarian,
            Size = new Size(275, 316),
            Location = new Point(223, 6),
            SizeMode = PictureBoxSizeMode.Zoom
        };
        #endregion
        private void classUpdate(string classBase, string subclass) {
            string Class = string.IsNullOrEmpty(PC.Class) ? classBase : PC.Class;
            try {
                string[] baseClassStats = Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetString(Class + "-Base").Split("_");
                ClassInfo.Text = "Class Skill - Level:\n";
                foreach (string item in baseClassStats) {
                    ClassInfo.Text = ClassInfo.Text + item + "\n";
                }
            } catch (Exception) { ClassInfo.Text = "No Data Found"; }
            try {
                if (subclass.SequenceEqual("Select One")) { SubClassInfo.Text = "No Data Found"; } else {
                    string[] subStats = Dungeons_and_Dragons_Player_Maker.Classes.ResourceManager.GetString(Class + "-" + subclass).Split("_");
                    SubClassInfo.Text = "Subclass Skill - Level:\n";
                    foreach (string item in subStats) {
                        SubClassInfo.Text = SubClassInfo.Text + item + "\n";
                    }
                }
            } catch (Exception) { SubClassInfo.Text = "No Data Found"; }
        }
    }
}