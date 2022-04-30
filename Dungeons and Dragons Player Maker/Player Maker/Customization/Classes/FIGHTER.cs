using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes {

    public partial class FIGHTER : BaseClassCustom {

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
            Size = new(308, 25),
            Location = new(10, 150)
        };
        ComboBox Skill1 = new() {
            DataSource = new[] { "Select One", "Arcrobatics", "Animal Handling", "Athletics", "History", "Insight", "Intimidation", "Perception", "Survival"},
            Location = new(10, 178),
            Size = new(151, 28),
            Text = "Select One"
        };
        ComboBox Skill2 = new() {
            DataSource = new[] { "Select One", "Arcrobatics", "Animal Handling", "Athletics", "History", "Insight", "Intimidation", "Perception", "Survival" },
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
            DataSource = new[] { "Select One", "Chain mail", "leather armor, longbow, 20 arrows" },
            Location = new(10, 255),
            Size = new(85, 60),
            DropDownWidth = 110,
            Text = "Select One"
        };
        ComboBox Equip2 = new() {
            DataSource = new[] { "Select One" }.Union(Engine.MARTIAL_WEAPONS).ToArray(),
            Location = new(100, 255),
            Size = new(85, 60),
            DropDownWidth = 110,
            Text = "Select One"
        };
        ComboBox Equip3 = new() {
            DataSource = new[] { "Select One", "Shield" }.Union(Engine.MARTIAL_WEAPONS).ToList(),
            Location = new(190, 255),
            Size = new(85, 60),
            DropDownWidth = 110,
            Text = "Shield"
        };
        ComboBox Equip4 = new() {
            DataSource = new[] { "Select One", "A light crossbow, 20 bolts", "handaxe, handaxe" },
            Location = new(280, 255),
            Size = new(85, 60),
            DropDownWidth = 110,
            Text = "Select One"
        };
        ComboBox Equip5 = new() {
            DataSource = new[] { "Select One", "Dungeoneer's Pack", "Explorer's Pack" },
            Location = new(370, 255),
            Size = new(85, 60),
            DropDownWidth = 110,
            Text = "Select One"
        };

        private readonly Label Expertise = new() {
            Text = "Fight Style",
            Size = new(308, 25),
            Location = new(10, 78)
        };
        ComboBox FightStyle = new() {
            DataSource = new[] { "Archery", "Blind Fighting", "Defense", "Dueling", "Great Weapon Fighting", "Interception", "Protection", "Superior Technique", "Thrown Weapon Fighting", "Two-Weapon Fighting", "Unarmed Fighting" },
            Size = new(151, 28),
            Location = new(10, 106),
            Text = "Select One"
        };
        #endregion

        [Obsolete]
        public FIGHTER(PC Player) : base(Player) {
            Controls.AddRange(new Control[] { Skills, Equipment, Expertise, Skill1, Skill2, Equip1, Equip2, Equip3, Equip4, Equip5, FightStyle });
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