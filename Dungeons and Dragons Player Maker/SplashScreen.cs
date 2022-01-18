using System;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker;

using DD = Dungeons_and_Dragons_Player_Maker;

using AutoUpdaterDotNET;
using Dungeons_and_Dragons_Player_Maker.Properties;

namespace Dungeons_and_Dragons_Player_Maker {
#pragma warning disable IDE1006 // Naming Styles

    public partial class SplashScreen : Form {
        
        [Obsolete]
        public SplashScreen() {
            InitializeComponent();
            pictureBox1.Load(ImageLocation.GetImage("SPLASH"));
            BackgroundImage = pictureBox1.Image;
            pictureBox1.Visible = false;
            label3.Text = label3.Text + "Version: " + Settings.Default.CurrentVersion;
        }
        private void timer1_Tick(object sender, EventArgs e) {
            Close();
        }

        private void SplashScreen_Load(object sender, EventArgs e) {
            /*timer1.Stop();
            if(DD.Update.Version > new Version(Settings.Default.CurrentVersion) /*&& DD.Update.PublishDate >= Settings.Default.LastUpdated) {
                AutoUpdater.Mandatory = true;
                AutoUpdater.ShowSkipButton = false;
                AutoUpdater.ShowRemindLaterButton = false;
                AutoUpdater.UpdateFormSize = new System.Drawing.Size(800, 600);
                AutoUpdater.InstalledVersion = new Version(Settings.Default.CurrentVersion);
                AutoUpdater.Start(DD.Update.Location);
                Settings.Default.LastUpdated = DateTime.UtcNow;
                Settings.Default.Save();
                timer1.Start();
            } else {
                timer1.Start();
            }*/
        }
    }
}
#pragma warning restore IDE1006 // Naming Styles
