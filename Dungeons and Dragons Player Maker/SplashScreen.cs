using System;
using System.Windows.Forms;
using System.Reflection;

namespace Dungeons_and_Dragons_Player_Maker {
#pragma warning disable IDE1006 // Naming Styles

    public partial class SplashScreen : Form {
        
        [Obsolete]
        public SplashScreen() {
            InitializeComponent();
            label3.Text = label3.Text + "Version: " + Properties.Settings.Default.CurrentVersion;
        }

 
        private void timer1_Tick(object sender, EventArgs e) {
            Close();
        }

    }
}
#pragma warning restore IDE1006 // Naming Styles
