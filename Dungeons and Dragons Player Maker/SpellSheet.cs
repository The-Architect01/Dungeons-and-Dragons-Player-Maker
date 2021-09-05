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
            switch (PC.Class.Split("-")[0]) {
                case "Bard":  case "Sorcerer": case "Warlock": case "Paladin":
                    SpellCastAbility.Text = "CHA";
                    AtkBonus.Text = "+ " + GetProficiency() + PrintSheet.getModifier(PC.Stats[5].ToString());
                    SaveDC.Text = ( 8 + GetProficiency() + int.Parse(PrintSheet.getModifier(PC.Stats[5].ToString())) ).ToString();
                    break;
                case "Cleric": case "Druid":  case "Ranger":
                    SpellCastAbility.Text = "WIS";
                    AtkBonus.Text = "+ " + GetProficiency() + PrintSheet.getModifier(PC.Stats[4].ToString());
                    SaveDC.Text = ( 8 + GetProficiency() + int.Parse(PrintSheet.getModifier(PC.Stats[4].ToString())) ).ToString();
                    break;
                case "Fighter": case "Rogue": case "Wizard":
                    SpellCastAbility.Text = "INT";
                    AtkBonus.Text = "+ " + GetProficiency() + PrintSheet.getModifier(PC.Stats[3].ToString());
                    SaveDC.Text = ( 8 + GetProficiency() + int.Parse(PrintSheet.getModifier(PC.Stats[3].ToString())) ).ToString();
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
            Show();
            if(Engine.SpellCasters.Contains(PC.Class.Split("-")[0]) || Engine.SpellCasters.Contains(PC.Class)) {
                Panel panel = new();
                Graphics grp = panel.CreateGraphics();
                Size formsize = this.ClientSize;
                bmp = new(formsize.Width, formsize.Height, grp);
                grp = Graphics.FromImage(bmp);
                Point panelLocation = PointToScreen(panel.Location);
                grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formsize);

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.UseAntiAlias = true;
                printDocument1.Print();
            } else {
                Dispose();
                return;
            }
            Dispose();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            e.Graphics.DrawImage(bmp, 0, 0, (int) ( ClientSize.Width * 1.045m ), (int) ( ClientSize.Height * 1.045m ));
        }
    }
}
