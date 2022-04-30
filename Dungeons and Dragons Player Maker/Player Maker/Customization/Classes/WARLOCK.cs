using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes {

    public partial class WARLOCK : BaseClassCustom {

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
            DataSource = new[] { "Arcana", "Deception", "History", "Intimidation", "Investigation", "Nature", "Religion" },
            Location = new(10, 178),
            Size = new(151, 28),
            Text = "Select One"
        };
        ComboBox Skill2 = new() {
            DataSource = new[] { "Arcana", "Deception", "History", "Intimidation", "Investigation", "Nature", "Religion" },
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
            DataSource = new[] { "Light crossbow, 20 bolts" }.Union(Engine.SIMPLE_WEAPONS).ToList(),
            Location = new(10, 252),
            Size = new(151, 28),
            Text = "Select One"
        };
        ComboBox Equip2 = new() {
            DataSource = new[] { "Component pouch", "Arcane focus" },
            Location = new(167, 252),
            Size = new(151, 28),
            Text = "Select One"
        };
        ComboBox Equip3 = new() {
            DataSource = new[] { "Scholar's pack", "Dungeoneer's pack" },
            Location = new(324, 252),
            Size = new(151, 28),
            Text = "Select One"
        };
        #endregion

        [Obsolete]
        public WARLOCK(PC Player) : base(Player) {
            Controls.AddRange(new Control[] { Skills, Equipment, Skill1, Skill2, Equip1, Equip2, Equip3 });
            foreach (ComboBox c in Controls.OfType<ComboBox>()) { c.TextChanged += null; }
            Scale(.75f);
        }
    }
}