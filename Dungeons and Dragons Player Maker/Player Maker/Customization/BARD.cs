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
        string MusicalInstrument1Prev = "Select One";
        string MusicalInstrument2Prev = "Select One";
        string MusicalInstrument3Prev = "Select One";
        readonly Label Tools = new() {
            Text = "Tools",
            Size = new(308, 25),
            Location = new(10, 78)
        };
        readonly ComboBox MusicalInstrument1 = new() {
            Name = "MusicalInstrument1",
            DataSource = Engine.ClassOptions(Engine.INSTRUMENTS),
            Size = new(151, 28),
            Location = new(10, 106)
        };
        readonly ComboBox MusicalInstrument2 = new() {
            Name = "MusicalInstrument2",
            DataSource = Engine.ClassOptions(Engine.INSTRUMENTS),
            Size = new(151, 28),
            Location = new(167, 106)
        };
        readonly ComboBox MusicalInstrument3 = new() {
            Name = "MusicalInstrument3",
            DataSource = Engine.ClassOptions(Engine.INSTRUMENTS),
            Size = new(151, 28),
            Location = new(324, 106)
        };

        string Skill1Prev = "Select One";
        string Skill2Prev = "Select One";
        string Skill3Prev = "Select One";
        readonly Label Skills = new() {
            Text = "Skills",
            Size = new(308, 25),
            Location = new(10, 150)
        };
        readonly ComboBox Skill1 = new() {
            Name = "Skill1",
            DataSource = Engine.AddChoose("Skills"),
            Size = new(151, 28),
            Location = new(10, 178)
        };
        readonly ComboBox Skill2 = new() {
            Name = "Skill2",
            DataSource = Engine.AddChoose("Skills"),
            Size = new(151, 28),
            Location = new(167, 178)

        };
        readonly ComboBox Skill3 = new() {
            Name = "Skill3",
            DataSource = Engine.AddChoose("Skills"),
            Size = new(151, 28),
            Location = new(324,178)
        };

        string Option1Prev = "Select One";
        string Option2Prev = "Select One";
        string Option3Prev = "Select One";
        readonly Label Equipment = new() {
            Text = "Items",
            Size = new(405, 25),
            Location = new(10, 224)
        };
        readonly ComboBox Option1 = new() {
            Name = "Option1",
            DataSource = Engine.ClassOptions(Engine.SIMPLE_WEAPONS, "Rapier", "Longsword"),
            Size = new(151, 28),
            Location = new(10, 252)
        };
        readonly ComboBox Option2 = new() {
            Name = "Option2",
            DataSource = new[] { "Select One", "Diplomat's pack", "Entertainer's pack" },
            Size = new(151, 28),
            Location = new(167, 252)
        };
        readonly ComboBox Option3 = new() {
            Name = "Option3",
            DataSource = Engine.ClassOptions(Engine.INSTRUMENTS),
            Size = new(151, 28),
            Location = new(324,252)
        };
        #endregion

        private void ComboBox_TextChanged(object sender, EventArgs e) {
            switch (((ComboBox)sender).Name) {
                case "Option1":
                    PC.Skills.Remove(Option1Prev);
                    Option1Prev = ((ComboBox)sender).Text;
                    break;
                case "Option2":
                    PC.Skills.Remove(Option2Prev);
                    Option2Prev = ((ComboBox)sender).Text;
                    break;
                case "Option3":
                    PC.Skills.Remove(Option3Prev);
                    Option3Prev = ((ComboBox)sender).Text;
                    break;
                case "Skill1":
                    PC.Skills.Remove(Skill1Prev);
                    Skill1Prev = ((ComboBox)sender).Text;
                    break;
                case "Skill2":
                    PC.Skills.Remove(Skill2Prev);
                    Skill2Prev = ((ComboBox)sender).Text;
                    break;
                case "Skill3":
                    PC.Skills.Remove(Skill3Prev);
                    Skill3Prev = ((ComboBox)sender).Text;
                    break;
                case "MusicalInstrument1":
                    PC.Skills.Remove(MusicalInstrument1Prev);
                    MusicalInstrument1Prev = ((ComboBox)sender).Text;
                    break;
                case "MusicalInstrument2":
                    PC.Skills.Remove(MusicalInstrument2Prev);
                    MusicalInstrument2Prev = ((ComboBox)sender).Text;
                    break;
                case "MusicalInstrument3":
                    PC.Skills.Remove(MusicalInstrument3Prev);
                    MusicalInstrument3Prev = ((ComboBox)sender).Text;
                    break;
            }

            if (MusicalInstrument1.Text != "Select One" && MusicalInstrument2.Text != "Select One" && MusicalInstrument3.Text != "Select One" &&
                Skill1.Text != "Select One" && Skill2.Text != "Select One" && Skill3.Text != "Select One" &&
                Option1.Text != "Select One" && Option2.Text != "Select One" && Option3.Text != "Select One") {
                informationFilled = true;
            }
        }


    }
}
