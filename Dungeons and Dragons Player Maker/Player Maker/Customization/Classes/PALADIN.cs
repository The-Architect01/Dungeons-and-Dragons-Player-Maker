using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes {

    public partial class PALADIN : BaseClassCustom {
        
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
        private readonly Label Skills = new() {
            Text = "Skills",
            Location = new(10, 150),
            Size = new(308, 25),
        };
        ComboBox Skill1 = new() {
            DataSource = new[] { "Select One", "Athletics", "Insight", "Intimidation", "Medicine", "Persuasion", "Religion" },
            Location = new(10, 178),
            Size = new(151, 28),
            Text = "Select One"
        };
        ComboBox Skill2 = new() {
            DataSource = new[] { "Select One", "Athletics", "Insight", "Intimidation", "Medicine", "Persuasion", "Religion" },
            Location = new(167, 178),
            Size = new(151, 28),
            Text = "Select One"
        };

        private readonly Label Equipment = new() {
            Text = "Items",
            Size = new(405, 25),
            Location = new(10, 224)
        };
        ComboBox Equip1 = new() {
            DataSource = new[] { "Select One" }.Union(Engine.MARTIAL_WEAPONS).ToArray(),
            Location = new(10, 255),
            Size = new(110, 60),
            Text = "Select One"
        };
        ComboBox Equip2 = new() {
            DataSource = new[] { "Select One", "Shield" }.Union(Engine.MARTIAL_WEAPONS).ToList(),
            Location = new(128, 255),
            Size = new(110, 60),
            Text = "Shield"
        };
        ComboBox Equip3 = new() {
            DataSource = new[] { "Select One", "Five Javelins" }.Union(Engine.MELEEWEAPONS.Intersect(Engine.SIMPLE_WEAPONS)).ToList(),
            Location = new(245, 255),
            Size = new(110, 60),
            Text = "Select One"
        };
        ComboBox Equip4 = new() {
            DataSource = new[] { "Select One", "Priest's Pack", "Explorer's Pack" },
            Location = new(364, 255),
            Size = new(110, 60),
            Text = "Select One"
        };
        #endregion

        [Obsolete]
        public PALADIN(PC Player) : base(Player) {
            Controls.AddRange(new Control[] { Skills, Equipment, Skill1, Skill2, Equip1, Equip2, Equip3, Equip4 });
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
