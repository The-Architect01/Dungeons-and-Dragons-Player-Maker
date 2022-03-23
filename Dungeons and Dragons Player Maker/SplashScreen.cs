using System;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker;

using DD = Dungeons_and_Dragons_Player_Maker;
using Dungeons_and_Dragons_Player_Maker.Properties;

namespace Dungeons_and_Dragons_Player_Maker {
#pragma warning disable IDE1006 // Naming Styles

    public partial class SplashScreen : Form {
        
        public SplashScreen() {
            InitializeComponent();
            pictureBox1.Load(ImageLocation.GetImage("SPLASH"));
            BackgroundImage = pictureBox1.Image;
            pictureBox1.Visible = false;
            label3.Text = label3.Text + "Version: " + Engine.SaveData.CurrentVersion;
        }
        private void timer1_Tick(object sender, EventArgs e) {
            Close();
        }
    }
}
#pragma warning restore IDE1006 // Naming Styles
