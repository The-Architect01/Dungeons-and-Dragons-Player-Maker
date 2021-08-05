using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Backgrounds {
    public partial class BackgroundTab : TabPage {

        PC PC;

        Control[] controlsOnControl;
        Label[] BackgroundsVisible;
        readonly static string[] Backgrounds = { };

        public event EventHandler OnReady;

        bool _ready = false;
        bool informationFilled { get { return _ready; } set { _ready = value; if (value) { OnReady.Invoke(this, EventArgs.Empty); } } }

        public BackgroundTab() {
            InitializeComponent();
        }

        #region Controls
        Label label1 = new() {
            Text = "Personality",
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(),
            Location = new Point()
        };
        #region Labels -- Names
        Label B1 = new() { };
        Label B2 = new() { };
        Label B3 = new() { };
        Label B4 = new() { };
        Label B5 = new() { };
        Label B6 = new() { };

        private void Background_Hover(object sender, EventArgs e) { }
        private void Background_Click(object sender, EventArgs e) { }
        #endregion
        Label BackgroundBonus = new() { };
        Label BackgroundData = new() { };

        Button UP = new() { };
        Button DOWN = new() { };

        private void UP_Click(object sender, EventArgs e) { }
        private void DOWN_Click(object sender, EventArgs e) { }
        private void UpdateVisibleBackgrounds() { }

        ComboBox Personality = new() { 
            Text = "Select One",
        };
        ComboBox Bond = new() { 
            Text = "Select One",
        };
        ComboBox Ideal = new() { 
            Text = "Select One",
        };
        ComboBox Flaw = new() { 
            Text = "Select One",
        };
        private void ID_SelectedValueChanged(object sender, EventArgs e) {
            if (!Personality.Text.SequenceEqual("Select One") && !Ideal.Text.SequenceEqual("Select One") &&
                !Bond.Text.SequenceEqual("Select One") && !Flaw.Text.SequenceEqual("Select One")) {
                informationFilled = true;
            }
        }
        #endregion


    }
}
