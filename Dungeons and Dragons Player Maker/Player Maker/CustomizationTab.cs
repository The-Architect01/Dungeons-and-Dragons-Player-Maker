using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker {
    public partial class CustomizationTab : TabPage {

        PC PC;

        public event EventHandler OnReady;

        bool _ready = false;
        bool informationFilled { get { return _ready; } set { _ready = value; if (value) { OnReady.Invoke(this, EventArgs.Empty); } } }

        public CustomizationTab(PC Player) {
            PC = Player;
            Text = "Customize";
            BackColor = Color.White;
            InitializeComponent();
            Pages.TabPages.Add(ClassData); Pages.TabPages.Add(StatsData);
        }

        #region Controls
        TabControl Pages = new() {
            Size = new Size(492, 540),
            Location = new Point(6, 6),
        };
        TabPage ClassData = new() {
            Text = "Class Customization Options",
        };
        TabPage StatsData = new() {
            Text = "Abilities and Stats",
        };
        #endregion
    }
}
