using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization {

    public partial class WIZARD : BaseClassCustom {

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
            DataSource = new[] {"Select One", "Arcana", "History", "Insight", "Investigation", "Medicine", "Religion" },
            Location = new(10, 178),
            Size = new(151, 28),
            Text = "Select One"
        };
        ComboBox Skill2 = new() {
            DataSource = new[] {"Select One", "Arcana", "History", "Insight", "Investigation", "Medicine", "Religion" },
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
            DataSource = new[] {"Select One", "Quarterstaff", "Dagger" },
            Location = new(10, 252),
            Size = new(151, 28),
            Text = "Select One"
        };
        ComboBox Equip2 = new() {
            DataSource = new[] {"Select One", "Component pouch", "Arcane focus" },
            Location = new(167, 252),
            Size = new(151, 28),
            Text = "Select One"
        };
        ComboBox Equip3 = new() {
            DataSource = new[] {"Select One", "Scholar's pack", "Explorer's pack" },
            Location = new(324, 252),
            Size = new(151, 28),
            Text = "Select One"
        };
        #endregion

        [Obsolete]
        public WIZARD(PC Player) : base(Player) {
            Controls.AddRange(new Control[] { Skills, Equipment, Skill1, Skill2, Equip1, Equip2, Equip3 });
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