using System;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker {
    public partial class CustomizationTab : TabPage {

        PC PC;

        public event EventHandler OnReady;

        bool _ready = false;
        bool informationFilled { get { return _ready; } set { _ready = value; if (value) { OnReady.Invoke(this, EventArgs.Empty); } } }

        public CustomizationTab() {
            InitializeComponent();
        }
    }
}
