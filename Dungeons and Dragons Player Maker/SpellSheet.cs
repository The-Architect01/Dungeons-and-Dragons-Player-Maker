using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker {
    public partial class SpellSheet : Form {

        PC PC;
        
        [Obsolete]
        public SpellSheet(PC Player) {
            InitializeComponent();
            PC = Player;
            ClassName.Text = PC.Class;
            switch (PC.Class.Split(":")[0]) {
                case "Bard":
                case "Sorcerer":
                case "Warlock":
                case "Paladin":
                    SpellCastAbility.Text = "CHA";
                    int Cha = int.Parse(PrintSheet.getModifier(PC.Stats[5].ToString()));
                    AtkBonus.Text = $"+ {GetProficiency() + Cha}";
                    SaveDC.Text = $"{8 + GetProficiency() + Cha}";
                    break;
                case "Cleric":
                case "Druid":
                case "Ranger":
                    SpellCastAbility.Text = "WIS";
                    int Wis = int.Parse(PrintSheet.getModifier(PC.Stats[4].ToString()));
                    AtkBonus.Text = $"+ {GetProficiency() + Wis}";
                    SaveDC.Text = $"{8 + GetProficiency() + Wis}";
                    break;
                case "Fighter":
                case "Rogue":
                case "Wizard":
                    SpellCastAbility.Text = "INT";
                    int Int = int.Parse(PrintSheet.getModifier(PC.Stats[3].ToString()));
                    AtkBonus.Text = $"+ {GetProficiency() + Int}";
                    SaveDC.Text = $"{8 + GetProficiency() + Int}";
                    break;
            }

            Scale(.75f);
            CenterToScreen();
        }

        private int GetProficiency() {
            if (5 > PC.Level) { return 2; }
            if (9 > PC.Level) { return  3; }
            if (13 > PC.Level) { return 4; }
            if (17 > PC.Level) { return 5; }
            return 0;
        }

        Bitmap bmp;
        public void Print() {
            Panel panel = new();
            Graphics grp = panel.CreateGraphics();
            Size formSize = new((int)(this.ClientSize.Width * 1.25d), (int)(this.ClientSize.Height * 1.25d));
            bmp = new Bitmap((int)(formSize.Width * 1.5d), (int)(formSize.Height * 1.5d), grp);
            grp = Graphics.FromImage(bmp);
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen((int)(panelLocation.X * 1.25d), (int)(panelLocation.Y * 1.25d), 0, 0, formSize);

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.UseAntiAlias = true;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            e.Graphics.DrawImage(bmp, 0, 0, (int)(bmp.Size.Width * 1.12d), (int)(bmp.Size.Height * 1.12d));
        }

        private void SpellSheet_Load(object sender, EventArgs e) {
            MessageBox.Show("Click Anywhere to print.");
        }

        private void SpellSheet_Click(object sender, EventArgs e) {
            Print();
        }
    }
}