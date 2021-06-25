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
        // public PrintSheet() {
        //    InitializeComponent();
        //}

        Label[] skills;


        public PrintSheet(PC pc) {
            InitializeComponent();
            skills = new Label[] { Athletics, Acrobatics,Sleight,Stealth, Arcana, History, Investigation,Nature,Religion,
            Animal, Insight, Medicine,Perception, Survival, Deception, Intimidation, Performance, Persuasion};
            foreach(Label skill in skills) {
                skill.Visible = pc.Skills.Contains(skill.Name) ? true : false;
            }
            Character_Name.Text = pc.Name;
            Background.Text = pc.Background;
            Class.Text = pc.Class;
            Player_Name.Text = pc.creator;
            XP.Text = pc.XP.ToString();
            Alignment.Text = pc.Alignment;
            setProficiencyBonus();
            Strength.Text = pc.Stats[0].ToString();
            Dextarity.Text = pc.Stats[1].ToString();
            Constitution.Text = pc.Stats[2].ToString();
            Intelligence.Text = pc.Stats[3].ToString();
            Wisdom.Text = pc.Stats[4].ToString();
            Charisma.Text = pc.Stats[5].ToString();
            setStatMod();
            populateRace();
            populateClass();
            populateBackground();
        }
        private void populateRace() {
            Speed.Text = Races.ResourceManager.GetString(Race.Text).Split("_")[6];
            
        }
        private void populateClass() {

        }
        private void populateBackground() {

        }
        private void setStatMod() {
            STR_Mod.Text = getModifier(Strength.Text);

        }
        private string getModifier(string stat) {
            if () {

            }return "";
        }
        private void setProficiencyBonus() {

        }

        private void Form1_Load(object sender, EventArgs e) {
            MessageBox.Show("Click anywhere to print.");
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e) {
            e.Graphics.DrawImage(bitMap, 0, 0,(int)(ClientSize.Width * 1.045m),(int) (ClientSize.Height *1.045m));
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
