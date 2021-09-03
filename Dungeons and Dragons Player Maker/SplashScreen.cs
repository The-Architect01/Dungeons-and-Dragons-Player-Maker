using System;
using System.Windows.Forms;
using System.Reflection;

namespace Dungeons_and_Dragons_Player_Maker {
    public partial class SplashScreen : Form {
        
        [Obsolete]
        public SplashScreen() {
            InitializeComponent();
            label3.Text = label3.Text + "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            Close();
        }
    }
}
