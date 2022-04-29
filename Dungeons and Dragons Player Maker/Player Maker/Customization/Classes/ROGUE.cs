using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization {

    public partial class ROGUE : BaseClassCustom {

        #region Controls
        private readonly Label Skills = new() {
            Text = "Skills",
            Size = new(308, 25),
            Location = new(10, 150)
        };
        ComboBox Skill1 = new() {
            DataSource = new[] { "Select One","Acrobatics", "Athletics", "Deception", "Insight", "Intimidation", "Investigation", "Perception", "Performance", "Persuasion", "Sleight of Hand", "Stealth" },
            Location = new(10, 178),
            Size = new(110, 60),
            Text = "Select One"
        };
        ComboBox Skill2 = new() {
            DataSource = new[] { "Select One", "Acrobatics", "Athletics", "Deception", "Insight", "Intimidation", "Investigation", "Perception", "Performance", "Persuasion", "Sleight of Hand", "Stealth" },
            Location = new(128, 178),
            Size = new(110, 60),
            Text = "Select One"
        };
        ComboBox Skill3 = new() {
            DataSource = new[] { "Select One", "Acrobatics", "Athletics", "Deception", "Insight", "Intimidation", "Investigation", "Perception", "Performance", "Persuasion", "Sleight of Hand", "Stealth" },
            Location = new(245, 178),
            Size = new(110, 60),
            Text = "Select One"
        };
        ComboBox Skill4 = new() {
            DataSource = new[] { "Select One", "Acrobatics", "Athletics", "Deception", "Insight", "Intimidation", "Investigation", "Perception", "Performance", "Persuasion", "Sleight of Hand", "Stealth" },
            Location = new(364, 178),
            Size = new(110, 60),
            Text = "Select One"
        };

        private readonly Label Equipment = new() {
            Text = "Items",
            Size = new(405, 25),
            Location = new(10, 224)
        };
        ComboBox Equip1 = new() {
            DataSource = new[] { "Select One", "Rapier", "Shortsword" },
            Size = new(151, 28),
            Location = new(10, 252),
            Text = "Select One"
        };
        ComboBox Equip2 = new() {
            DataSource = new[] { "Select One", "Shortbow, quiver with 20 arrows", "Shortsword" },
            Size = new(151, 28),
            Location = new(167, 252),
            Text = "Select One"
        };
        ComboBox Equip3 = new() {
            DataSource = new[] { "Select One", "Burglar's pack", "Dungeoneer's pack", "Explorer's pack" },
            Size = new(151, 28),
            Location = new(324, 252),
            Text = "Select One"
        };

        private readonly Label Expertise = new() {
            Text = "Expertise",
            Size = new(308, 25),
            Location = new(10, 78)
        };
        ComboBox Expertise1 = new() {
            Name = "Expertise1",
            Size = new(151, 28),
            Location = new(10, 106),
            Text = "Select One",
            Enabled = false,
        };
        ComboBox Expertise2 = new() {
            Name = "Expertise2",
            Size = new(151, 28),
            Location = new(167, 106),
            Text = "Select One",
            Enabled = false,
        };
        #endregion

        [Obsolete]
        public ROGUE(PC Player) : base(Player) {
            Controls.AddRange(new Control[] { Skills, Equipment, Expertise, Skill1, Skill2, Skill3, Skill4, Equip1, Equip2, Equip3, Expertise1, Expertise2 });
            foreach (ComboBox c in new[] { Skill1, Skill2, Skill3, Skill4 }) { c.TextChanged += EnableSkills; }
            foreach (ComboBox c in Controls.OfType<ComboBox>()) { c.TextChanged += CheckComboBoxes; }
            Scale(.75f);
        }

        protected override void FireOnReady() {
            if (!PC.Skills.Contains(Skill1.Text.Split(" ")[0])) { PC.Skills.Add(Skill1.Text.Split(" ")[0]); }
            if (!PC.Skills.Contains(Skill2.Text.Split(" ")[0])) { PC.Skills.Add(Skill2.Text.Split(" ")[0]); }
            if (!PC.Skills.Contains(Skill3.Text.Split(" ")[0])) { PC.Skills.Add(Skill3.Text.Split(" ")[0]); }
            if (!PC.Skills.Contains(Skill4.Text.Split(" ")[0])) { PC.Skills.Add(Skill4.Text.Split(" ")[0]); }

            if (!PC.Inventory.Contains(Equip1.Text)) { PC.Inventory.Add(Equip1.Text); }
            if (!PC.Inventory.Contains(Equip2.Text)) { PC.Inventory.Add(Equip2.Text); }
            if (!PC.Inventory.Contains(Equip3.Text)) { PC.Inventory.Add(Equip3.Text); }

            if (!PC.Expertise.Contains(Expertise1.Text.Split(" ")[0])) { PC.Expertise.Add(Expertise1.Text.Split(" ")[0]); }
            if (!PC.Expertise.Contains(Expertise2.Text.Split(" ")[0])) { PC.Expertise.Add(Expertise2.Text.Split(" ")[0]); }

            base.FireOnReady();
        }

        public void EnableSkills(object sender, EventArgs e) {
            List<string> Combos = new List<string>();
            foreach(ComboBox c in new[] { Skill1, Skill2, Skill3, Skill4 }) {
                if(c.Items.Count == 0 || c.SelectedIndex == -1 || c.Text == "Select One") { continue; }
                Combos.Add(c.Text);
            }
            if(Combos.Distinct().Count() == 4) { 
            //if ((Skill1.SelectedIndex != Skill2.SelectedIndex) && (Skill2.SelectedIndex != Skill3.SelectedIndex) && (Skill3.SelectedIndex != Skill4.SelectedIndex) && Skill4.SelectedIndex != 0) {
                Expertise1.Enabled = Expertise2.Enabled = true;
                string[] Profs = PC.Skills.Intersect(Engine.SKILLS).Union(new[] { Skill1.Text, Skill2.Text, Skill3.Text, Skill4.Text }).ToArray();
                Expertise1.Items.Clear();
                Expertise2.Items.Clear();
                Expertise1.Items.AddRange(Profs);
                Expertise1.Items.Insert(0, "Select One");
                Expertise2.Items.AddRange(Profs);
                Expertise2.Items.Insert(0, "Select One");
            } else { Expertise1.Enabled = Expertise2.Enabled = false; }
        }
    }
}