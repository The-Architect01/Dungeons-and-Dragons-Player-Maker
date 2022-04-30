using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes {
    
    public partial class BaseClassCustom : TabPage {
        protected readonly PC PC;

        public event EventHandler OnReady;

        protected bool _ready = false;

        protected virtual bool InformationFilled {
            get { return _ready; }
            set {
                _ready = value;
                if (value) {
                    FireOnReady();
                    OnReady.Invoke(this, EventArgs.Empty);
                }
            }
        }

        protected void CheckComboBoxes(object sender, EventArgs e) {
            List<string> Combos = new List<string>();
            List<ComboBox> comboBoxes = Controls.OfType<ComboBox>().ToList();
            foreach (ComboBox c in comboBoxes) {
                if(c.Items.Count == 0 || c.SelectedIndex == -1 || c.Text == "Select One") { continue; }
                if (!string.IsNullOrEmpty(c.SelectedItem.ToString())) {
                    Combos.Add(c.SelectedItem.ToString());
                }
            }
            InformationFilled = Combos.Distinct().Count() + 
                comboBoxes.Where(c => c.Name.Contains("Expertise") && c.Items.Count != 0 && c.SelectedIndex != -1 && c.Text != "Select One").Distinct().Count() -
                comboBoxes.Where(c => c.Text.Contains("Select One")).Count() ==
                comboBoxes.Count;
        }

        protected virtual void FireOnReady() {OnReady.Invoke(this, EventArgs.Empty);}

        [Obsolete]
        public BaseClassCustom(PC Player) {
            PC = Player;
            Text = "Class Customization Options";
            BackColor = Color.White;
            InitializeComponent();
            //Controls.AddRange(new Control[] { });
            foreach (ComboBox c in Controls.OfType<ComboBox>()) { c.TextChanged += null; }
            Scale(.75f);
        }
    }
}
