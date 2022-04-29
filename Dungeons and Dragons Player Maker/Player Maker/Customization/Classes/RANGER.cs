using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes {

    public partial class RANGER : BaseClassCustom {

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
            DataSource = new[] {"Select One", "Animal Handling", "Athletics", "Insight", "Investigation", "Nature", "Perception", "Stealth", "Survival" },
            Location = new(0, 0),
            Size = new(120, 60),
            Text = "Select One"
        };
        ComboBox Skill2 = new() {
            DataSource = new[] {"Select One", "Animal Handling", "Athletics", "Insight", "Investigation", "Nature", "Perception", "Stealth", "Survival" },
            Location = new(0, 0),
            Size = new(120, 60),
            Text = "Select One"
        };
        ComboBox Skill3 = new() {
            DataSource = new[] {"Select One", "Animal Handling", "Athletics", "Insight", "Investigation", "Nature", "Perception", "Stealth", "Survival" },
            Location = new(0, 0),
            Size = new(120, 60),
            Text = "Select One"
        };

        ComboBox Equip1 = new() {
            DataSource = new[] {"Select One", "Scale mail", "Leather armor"},
            Location = new(0, 0),
            Size = new(120, 60),
            Text = "Select One"
        };
        ComboBox Equip2 = new() {
            DataSource = new[] { "Select One" }.Union(Engine.MELEEWEAPONS.Intersect(Engine.SIMPLE_WEAPONS)).ToList(),
            Location = new(0, 0),
            Size = new(120, 60),
            Text = "Shortsword"
        };
        ComboBox Equip3 = new() {
            DataSource = new[] { "Select One" }.Union(Engine.MELEEWEAPONS.Intersect(Engine.SIMPLE_WEAPONS)).ToList(),
            Location = new(0, 0),
            Size = new(120, 60),
            Text = "Shortsword"
        };
        ComboBox Equip4 = new() {
            DataSource = new[] { "Select One", "Dungeoneer's Pack", "Explorer's Pack" },
            Location = new(0, 0),
            Size = new(120, 60),
            Text = "Select One"
        };
        #endregion

        [Obsolete]
        public RANGER(PC Player) : base(Player) {
            Controls.AddRange(new Control[] { Skill1, Skill2, Skill3, Equip1, Equip2, Equip3, Equip4 });
            foreach (ComboBox c in Controls.OfType<ComboBox>()) { c.TextChanged += CheckComboBoxes; }
            Scale(.75f);
        }

        protected override void FireOnReady() {
            if (!PC.Skills.Contains(Skill1.Text.Split(" ")[0])) { PC.Skills.Add(Skill1.Text.Split(" ")[0]); }
            if (!PC.Skills.Contains(Skill2.Text.Split(" ")[0])) { PC.Skills.Add(Skill2.Text.Split(" ")[0]); }
            if (!PC.Skills.Contains(Skill3.Text.Split(" ")[0])) { PC.Skills.Add(Skill3.Text.Split(" ")[0]); }

            if (!PC.Inventory.Contains(Equip1.Text)) { PC.Inventory.Add(Equip1.Text); }
            if (!PC.Inventory.Contains(Equip2.Text)) { PC.Inventory.Add(Equip2.Text); }
            if (!PC.Inventory.Contains(Equip3.Text)) { PC.Inventory.Add(Equip3.Text); }

            base.FireOnReady();
        }

    }
}