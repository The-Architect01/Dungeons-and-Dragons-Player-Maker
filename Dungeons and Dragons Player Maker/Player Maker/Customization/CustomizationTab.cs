using System;
using System.Drawing;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization;

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
            Pages.TabPages.Add(new ClassDataTab(PC));
            Pages.TabPages.Add(new StatDataPage(PC));
            Controls.Add(Pages);
        }

        #region Controls
        TabControl Pages = new() {
            Size = new Size(492, 540),
            Location = new Point(6, 6),
        };
        #endregion
    }
}
