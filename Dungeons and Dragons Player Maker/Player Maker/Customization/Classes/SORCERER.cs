using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes {

    public partial class SORCERER : BaseClassCustom {

        protected override bool InformationFilled {
            get { return _ready; }
            set {
                _ready = value;
                if (value) {
                    FireOnReady();
                }
            }
        }

        #region Controls
        ComboBox Skill1 = new() {
            DataSource = new[] { "Select One", "Arcana", "Deception", "Insight", "Intimidation", "Persuasion", "Religion" },
            Location = new(0, 0),
            Size = new(120, 60),
            Text = "Select One"
        };
        ComboBox Skill2 = new() {
            DataSource = new[] { "Select One", "Arcana", "Deception", "Insight", "Intimidation", "Persuasion", "Religion" },
            Location = new(0, 0),
            Size = new(120, 60),
            Text = "Select One"
        };

        ComboBox Equip1 = new() {
            DataSource = new[] { "Select One", "Light crossbow, 20 bolts" }.Union(Engine.SIMPLE_WEAPONS).ToList(),
            Location = new(0, 0),
            Size = new(120, 60),
            Text = "Select One"
        };
        ComboBox Equip2 = new() {
            DataSource = new[] { "Select One", "Component pouch", "Arcane focus" },
            Location = new(0, 0),
            Size = new(120, 60),
            Text = "Select One"
        };
        ComboBox Equip3 = new() {
            DataSource = new[] { "Select One", "Dungeoneer's pack", "Explorer's pack" },
            Location = new(0, 0),
            Size = new(120, 60),
            Text = "Select One"
        };
        #endregion

        [Obsolete]
        public SORCERER(PC Player) : base(Player) {
            Controls.AddRange(new Control[] { Skill1, Skill2, Equip1, Equip2, Equip3 });
            foreach (ComboBox c in Controls.OfType<ComboBox>()) { c.TextChanged += CheckComboBoxes; }
            Scale(.75f);
        }

        protected override void FireOnReady() {
            if (!PC.Skills.Contains(Skill1.Text.Split(" ")[0])) { PC.Skills.Add(Skill1.Text.Split(" ")[0]); }
            if (!PC.Skills.Contains(Skill2.Text.Split(" ")[0])) { PC.Skills.Add(Skill2.Text.Split(" ")[0]); }

            if (!PC.Inventory.Contains(Equip1.Text)) { PC.Inventory.Add(Equip1.Text); }
            if (!PC.Inventory.Contains(Equip2.Text)) { PC.Inventory.Add(Equip2.Text); }
            if (!PC.Inventory.Contains(Equip3.Text)) { PC.Inventory.Add(Equip3.Text); }

            base.FireOnReady();
        }
    }
}