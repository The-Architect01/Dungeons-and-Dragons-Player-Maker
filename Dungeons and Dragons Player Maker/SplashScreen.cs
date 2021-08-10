using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using System.Reflection;

namespace Dungeons_and_Dragons_Player_Maker {
    public partial class SplashScreen : Form {
        public SplashScreen() {
            InitializeComponent();
            PrivateFontCollection pfc = new();
            pfc.AddFontFile(Path.GetDirectoryName(Application.ExecutablePath).Split("bin")[0] + "Benguiat Bold.ttf");
            label1.Font = new Font(pfc.Families[0], label1.Font.SizeInPoints);
            label3.Text = label3.Text + "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            Close();
        }
    }
}
