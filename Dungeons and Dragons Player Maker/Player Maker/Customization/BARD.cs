using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization {
    public partial class BARD : TabPage {
        readonly PC PC;

        public event EventHandler OnReady;

        bool _ready = false;
        bool informationFilled {
            get { return _ready; }
            set {
                _ready = value; if (value) {
                    PC.Skills.Add(MusicalInstrument1.Text);
                    PC.Skills.Add(MusicalInstrument2.Text);
                    PC.Skills.Add(MusicalInstrument3.Text);

                    PC.Skills.Add(Skill1.Text);PC.Skills.Add(Skill2.Text);
                    PC.Skills.Add(Skill3.Text);

                    PC.Inventory.Add(Option1.Text); PC.Inventory.Add(Option2.Text);PC.Inventory.Add(Option3.Text);
                    
                    OnReady.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public BARD(PC Player) {
            PC = Player;
            Text = "Class Customization Options";
            BackColor = Color.White;
            InitializeComponent();
            Controls.AddRange(new Control[] { Tools, Skills, Equipment, MusicalInstrument1, MusicalInstrument2, MusicalInstrument3, Skill1, Skill2, Skill3, Option1, Option2, Option3 });
            foreach(ComboBox c in Controls.OfType<ComboBox>()) { c.TextChanged += ComboBox_TextChanged; }
        }

        #region Controls
        readonly Label Tools = new() {
            Text = "Tools",
            Size = new(308, 25),
            Location = new(10, 78)
        };
        readonly ComboBox MusicalInstrument1 = new() {
            DataSource = Engine.ClassOptions(Engine.INSTRUMENTS),
            Size = new(151, 28),
            Location = new(10, 106)
        };
        readonly ComboBox MusicalInstrument2 = new() {
            DataSource = Engine.ClassOptions(Engine.INSTRUMENTS),
            Size = new(151, 28),
            Location = new(167, 106)
        };
        readonly ComboBox MusicalInstrument3 = new() {
            DataSource = Engine.ClassOptions(Engine.INSTRUMENTS),
            Size = new(151, 28),
            Location = new(324, 106)
        };
        readonly Label Skills = new() {
            Text = "Skills",
            Size = new(308, 25),
            Location = new(10, 150)
        };
        readonly ComboBox Skill1 = new() {
            DataSource = Engine.AddChoose("Skills"),
            Size = new(151, 28),
            Location = new(10, 178)
        };
        readonly ComboBox Skill2 = new() {
            DataSource = Engine.AddChoose("Skills"),
            Size = new(151, 28),
            Location = new(167, 178)

        };
        readonly ComboBox Skill3 = new() {
            DataSource = Engine.AddChoose("Skills"),
            Size = new(151, 28),
            Location = new(324,178)
        };
        readonly Label Equipment = new() {
            Text = "Items",
            Size = new(405, 25),
            Location = new(10, 229)
        };
        readonly ComboBox Option1 = new() {
            DataSource = Engine.ClassOptions(Engine.SIMPLE_WEAPONS, "Rapier", "Longsword"),
            Size = new(151, 28),
            Location = new(10, 250)
        };
        readonly ComboBox Option2 = new() {
            DataSource = new[] { "Select One", "Diplomat's pack", "Entertainer's pack" },
            Size = new(151, 28),
            Location = new(167, 250)
        };
        readonly ComboBox Option3 = new() {
            DataSource = Engine.ClassOptions(Engine.INSTRUMENTS),
            Size = new(151, 28),
            Location = new(324,250)
        };
        #endregion

        private void ComboBox_TextChanged(object sender, EventArgs e) {
            if (MusicalInstrument1.Text != "Select One" && MusicalInstrument2.Text != "Select One" && MusicalInstrument3.Text != "Select One" &&
                Skill1.Text != "Select One" && Skill2.Text != "Select One" && Skill3.Text != "Select One" &&
                Option1.Text != "Select One" && Option2.Text != "Select One" && Option3.Text != "Select One") {
                informationFilled = true;
            }
        }


    }
}
