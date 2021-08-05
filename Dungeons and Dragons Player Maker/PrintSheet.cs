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

        Label[] skills;
        PC player;

        public PrintSheet(PC pc) {
            InitializeComponent();
            player = pc;
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
            foreach(string skill in player.Skills) { Prof.Text += skill + ", "; }
            foreach(string item in player.Inventory) { Equip.Text += item + ", "; }
            foreach (string item in player.Weapons) { Weapons.Text += Dungeons_and_Dragons_Player_Maker.Weapons.ResourceManager.GetString(item) + "\n";}
        }
        private void populateRace() {
            Speed.Text = Races.ResourceManager.GetString(Race.Text).Split("_")[6];
            string[] abilities = Races.ResourceManager.GetString(Race.Text).Split("_")[10].Split(", ");
            foreach(string ability in abilities) {Abilities.Text += ability + "\n";}
        }
        private void populateClass() {
            string[] abilities = Classes.ResourceManager.GetString(Class.Text.Split("-")[0] + "-Base").Split("_");
            foreach(string ability in abilities) {
                string[] ability1 = ability.Split(" - ");
                string[] levels = ability1[1].Split(", ");
                bool canhave = false;
                foreach(string level in levels) { if(int.Parse(level)==player.Level) { canhave = true; break; } }
                if (canhave) { Abilities.Text += ability1[0] + "\n"; }
            }
            string[] subAbilitites = Classes.ResourceManager.GetString(Class.Text).Split("_");
            foreach(string ability in subAbilitites) {
                string[] ability1 = ability.Split(" - ");
                string[] levels = ability1[1].Split(", ");
                bool canhave = false;
                foreach (string level in levels) { if (int.Parse(level) == player.Level) { canhave = true; break; } }
                if (canhave) { Abilities.Text +=ability1[0] + "\n"; }
            }
        }
        private void populateBackground() {
            Abilities.Text += Backgrounds.ResourceManager.GetString(Background.Text);
            Persona.Text += "Personality: " + player.Personality[0] + "\n";
            Persona.Text += "Ideal: " + player.Personality[1] + "\n";
            Persona.Text += "Bond: " + player.Personality[2] + "\n";
            Persona.Text += "Flaw: " + player.Personality[3];
        }
        private void setStatMod() {
            STR_Mod.Text = getModifier(Strength.Text);
            Dex_Mod.Text = getModifier(Dextarity.Text);
            Con_Mod.Text = getModifier(Constitution.Text);
            Wis_Mod.Text = getModifier(Wisdom.Text);
            Int_Mod.Text = getModifier(Intelligence.Text);
            Cha_Mod.Text = getModifier(Charisma.Text);
        }
        private string getModifier(string stat) {
            int statvalue = int.Parse(stat);
            if (statvalue == 1)  { return "-5";  } 
            if (4 > statvalue)   { return "-4";  }
            if (6 > statvalue)   { return "-3";  }
            if (8 > statvalue)   { return "-2";  }
            if (10 > statvalue)  { return "-1";  }
            if (12 > statvalue)  { return "0";   }
            if (14 > statvalue)  { return "+1";  }
            if (16 > statvalue)  { return "+2";  }
            if (18 > statvalue)  { return "+3";  }
            if (20 > statvalue)  { return "+4";  }
            if (22 > statvalue)  { return "+5";  }
            if (24 > statvalue)  { return "+6";  }
            if (26 > statvalue)  { return "+7";  }
            if (28 > statvalue)  { return "+8";  }
            if (30 > statvalue)  { return "+9";  }
            if (30 == statvalue) { return "+10"; }
            return "-10";
        }
        private void setProficiencyBonus() { 
            if (5 > player.Level) { Proficency.Text = "+2"; return; }
            if (9 > player.Level) { Proficency.Text = "+3"; return; }
            if (13 > player.Level) { Proficency.Text = "+4"; return; }
            if (17 > player.Level) { Proficency.Text = "+5";return; }
            Proficency.Text = "+6";
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
            Panel panel = new();
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
        }

        private void PrintSheet_Shown(object sender, EventArgs e) {
            
        }
    }
}
