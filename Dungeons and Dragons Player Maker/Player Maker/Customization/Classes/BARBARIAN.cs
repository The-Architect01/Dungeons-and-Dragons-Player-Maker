using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization
{
    public partial class BARBARIAN : TabPage {

        private readonly PC PC;

        public event EventHandler OnReady;

        private bool _ready = false;
        private bool InformationFilled {
            get { return _ready; }
            set {
                _ready = value;
                if (value) {
                    OnReady.Invoke(this, EventArgs.Empty);
                }
            }
        }

        [Obsolete]
        public BARBARIAN(PC Player) {
            PC = Player;
            Text = "Class Customization Options";
            BackColor = Color.White;
            InitializeComponent();
            Controls.AddRange(new Control[] { });
            foreach (ComboBox c in Controls.OfType<ComboBox>()) { c.TextChanged += null; }
            Scale(.75f);
        }

    }
}