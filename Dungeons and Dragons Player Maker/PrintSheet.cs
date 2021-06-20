using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker {
    public partial class PrintSheet : Form {
        Bitmap bitMap;
        public PrintSheet() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            MessageBox.Show("Click anywhere to print.");
        }



        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            e.Graphics.DrawImage(bitMap, 0, 0,(int)(ClientSize.Width * 1.055m),(int) (ClientSize.Height *1.055m));
        }

        private void CaptureScreen() {
            Graphics graphics = this.CreateGraphics();
            Size s = this.Size;
            bitMap = new Bitmap(s.Width, s.Height, graphics);
            Graphics memoryGraphics = Graphics.FromImage(bitMap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void Form1_Click(object sender, EventArgs e) {
            Panel panel = new Panel();
            //this.Controls.Add(panel);
            //vScrollBar1.Visible = false;
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitMap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitMap);
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.UseAntiAlias = true;
            printPreviewDialog1.ShowDialog();
            //vScrollBar1.Visible = true;
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e) {
         //   Parent.BackgroundImage = 1;
        }

        private void label1_Click(object sender, EventArgs e) {

        }
    }
}
