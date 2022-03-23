using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
                    OnReady.Invoke(this, EventArgs.Empty);
                }
            }
        }

        protected void FireOnReady() {OnReady.Invoke(this, EventArgs.Empty);}

        [Obsolete]
        public BaseClassCustom(PC Player) {
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
