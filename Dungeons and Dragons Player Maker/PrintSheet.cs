using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Dungeons_and_Dragons_Player_Maker {
    public partial class PrintSheet : Form {
        private Bitmap bitMap;

        public PrintSheet() {
            InitializeComponent();        
        }

        private readonly Label[] skills;
        private readonly List<string> Skills;
        private readonly PC player;

        [Obsolete]
        public PrintSheet(PC pc) {
            InitializeComponent();
            
            player = pc;
            Skills = pc.Skills;
            Race.Text = player.Race.Split(":")[0];
            
            skills = new Label[] { Athletics, Acrobatics,Sleight,Stealth, Arcana, History, Investigation,Nature,Religion,
            Animal, Insight, Medicine,Perception, Survival, Deception, Intimidation, Performance, Persuasion};

            foreach(Label skill in skills) {skill.Visible = Skills.Contains(skill.Name);}

            Skills.RemoveAll(i => Engine.SKILLS.Contains(i));

            //player.Skills.RemoveAll(i => Engine.SKILLS.Contains(i));
            Character_Name.Text = player.Name;
            Background.Text = player.Background;
            Class.Text = player.Class;
            Player_Name.Text = player.creator;
            XP.Text = player.XP.ToString();
            Alignment.Text = player.Alignment;
            
            setProficiencyBonus();
            Strength.Text = player.Stats[0].ToString();
            Dextarity.Text = player.Stats[1].ToString();
            Constitution.Text = player.Stats[2].ToString();
            Intelligence.Text = player.Stats[3].ToString();
            Wisdom.Text = player.Stats[4].ToString();
            Charisma.Text = player.Stats[5].ToString();
            
            SetStatMod();
            populateRace();
            populateClass();
            populateBackground();
            
            foreach(string skill in Skills) { if (!Prof.Text.Contains(skill)) { Prof.Text += skill + ", "; } }
            foreach(string item in player.Inventory) { Equip.Text += item + ", "; }
            foreach (string item in player.Weapons) { 
                WeaponName.Text += item + "\n";
                if (Engine.RANGEDWEAPONS.Contains(item)) { WeaponDamage.Text += (int.Parse(Dex_Mod.Text)) + "\n";  }
                else if (Engine.RANGEDWEAPONS.Contains(item) && 
                    (player.Skills.Contains(item)||
                    (player.Skills.Contains("Simple Weapons")&& Engine.SIMPLE_WEAPONS.Contains(item)) ||
                    (player.Skills.Contains("Martial Weapons") && Engine.MARTIAL_WEAPONS.Contains(item)))) { WeaponDamage.Text += (int.Parse(Dex_Mod.Text) + int.Parse(Proficency.Text)).ToString() + "\n"; }
                else if (Engine.MELEEWEAPONS.Contains(item)) { WeaponDamage.Text += (int.Parse(STR_Mod.Text)) + "\n"; }
                else if (Engine.MELEEWEAPONS.Contains(item) && (player.Skills.Contains(item) ||
                    (player.Skills.Contains("Simple Weapons") && Engine.SIMPLE_WEAPONS.Contains(item)) ||
                    (player.Skills.Contains("Martial Weapons") && Engine.MARTIAL_WEAPONS.Contains(item))))
                    { WeaponDamage.Text += (int.Parse(STR_Mod.Text) + int.Parse(Proficency.Text)).ToString() + "\n"; }
                WeaponDamageType.Text += Weapons.ResourceManager.GetString(item) + "\n";
            }

            populateAC();
            Scale(.75f);
            CenterToScreen();
        }

        private void populateRace() {
            Speed.Text = Races.ResourceManager.GetString(player.Race).Split("_")[6];
            List<string> abilities = new();
            abilities.AddRange(Races.ResourceManager.GetString(player.Race).Split("_")[10].Split(", "));
            abilities.Remove("None");
            foreach(string ability in abilities) {Abilities.Text += ability + "\n";}
        }
        
        private void populateClass() {
            string[] abilities = Classes.ResourceManager.GetString(player.Class.Split(":")[0] + ":Base").Split("_");
            foreach(string ability in abilities) {Abilities.Text += ability + "\n";}
            string[] subAbilitites = Classes.ResourceManager.GetString(player.Class).Split("_");
            foreach(string ability in subAbilitites) {Abilities.Text += ability + "\n";}
            switch (player.Class.Split(":")[0]) {
                case "Artificer":
                    HitDie.Text = "d8";
                    break;
                case "Bard":
                    Cha_Save.Visible = true;
                    Dex_Save.Visible = true;
                    HitDie.Text = "d8";
                    break;
                case "Druid":
                    Int_Save.Visible = true;
                    Wis_Save.Visible = true;
                    HitDie.Text = "d8";
                    break;
                case "Monk":
                    Str_Save.Visible = true;
                    Dex_Save.Visible = true;
                    HitDie.Text = "d8";
                    break;
                case "Warlock":
                    Wis_Save.Visible = true;
                    Cha_Save.Visible = true;
                    HitDie.Text = "d8";
                    break;
                case "Rogue":
                    Dex_Save.Visible = true;
                    Int_Save.Visible = true;
                    HitDie.Text = "d8";
                    break;
                case "Cleric":
                    Wis_Save.Visible = true;
                    Cha_Save.Visible = true;
                    HitDie.Text = "d8";
                    break;
                case "Fighter":
                    Str_Save.Visible = true;
                    Con_Save.Visible = true;
                    HitDie.Text = "d10";
                    break;
                case "Paladin":
                    Wis_Save.Visible = true;
                    Cha_Save.Visible = true;
                    HitDie.Text = "d10";
                    break;
                case "Ranger":
                    Str_Save.Visible = true;
                    Dex_Save.Visible = true;
                    HitDie.Text = "d10";
                    break;
                case "Sorcerer":
                    Con_Save.Visible = true;
                    Cha_Save.Visible = true;
                    HitDie.Text = "d6";
                    break;
                case "Wizard":
                    Int_Save.Visible = true;
                    Wis_Save.Visible = true;
                    HitDie.Text = "d6";
                    break;
                case "Barbarian":
                    Str_Save.Visible = true;
                    Con_Save.Visible = true;
                    HitDie.Text = "d12";
                    break;
            }
            player.Skills.AddRange(Classes.ResourceManager.GetString(player.Class.Split(":")[0] + ":Skills").Split("_"));
            player.Inventory.AddRange(Classes.ResourceManager.GetString(player.Class.Split(":")[0] + ":Items").Split("_"));
            foreach(string item in player.Inventory) {
                if(Engine.SIMPLE_WEAPONS.Contains(item) || Engine.MARTIAL_WEAPONS.Contains(item)) {
                    player.Weapons.Add(item);
                }
            }

        }
        private void populateBackground() {
            Abilities.Text += Backgrounds.ResourceManager.GetString(Background.Text).Split(":")[0];
            Personality.Text = player.Personality[0];
            Ideal.Text = player.Personality[1];
            Bond.Text = player.Personality[2];
            Flaw.Text = player.Personality[3];
        }
        private void SetStatMod() {
            STR_Mod.Text = getModifier(Strength.Text);
            Dex_Mod.Text = getModifier(Dextarity.Text);
            Con_Mod.Text = getModifier(Constitution.Text);
            Wis_Mod.Text = getModifier(Wisdom.Text);
            Int_Mod.Text = getModifier(Intelligence.Text);
            Cha_Mod.Text = getModifier(Charisma.Text);
        }
        private static string getModifier(string stat) {
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
            Text = player.Name;
            Passive_Wis.Text = (10 + int.Parse(Wis_Mod.Text)).ToString();
            Passive_Wis.Text = Perception.Visible ? (int.Parse(Passive_Wis.Text) + int.Parse(Proficency.Text)).ToString() : Passive_Wis.Text;
            Initiative.Text = Dex_Mod.Text;
            Speed.Text = Races.ResourceManager.GetString(player.Race).Split("_")[6];
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

        private void populateAC() {
            if (player.Inventory.Contains("Padded Armor") || player.Inventory.Contains("Leather Armor") || player.Inventory.Contains("Studded Leather Armor")) {
                AC.Text = (int.Parse(Dex_Mod.Text) + 11).ToString();
            }else if (player.Inventory.Contains("Hide Armor")) {
                AC.Text = int.Parse(Dex_Mod.Text) > 2 ? "14" : (int.Parse(Dex_Mod.Text) + 12).ToString();  
            }else if (player.Inventory.Contains("Chain Shirt")) {
                AC.Text = int.Parse(Dex_Mod.Text) > 2 ? "15" : (int.Parse(Dex_Mod.Text) + 13).ToString();
            }else if (player.Inventory.Contains("Scale Mail") || player.Inventory.Contains("Breastplate")) {
                AC.Text = int.Parse(Dex_Mod.Text) > 2 ? "16" : (int.Parse(Dex_Mod.Text) + 14).ToString();
            }else if (player.Inventory.Contains("Half Plate")) {
                AC.Text = int.Parse(Dex_Mod.Text) > 2 ? "17" : (int.Parse(Dex_Mod.Text) + 15).ToString();
            }else if (player.Inventory.Contains("Ring Mail")){ AC.Text = "14"; 
            }else if (player.Inventory.Contains("Chain Mail")) { AC.Text = "16";
            }else if (player.Inventory.Contains("Splint")) { AC.Text = "17"; 
            }else if (player.Inventory.Contains("Plate Armor")) { AC.Text = "18";
            }else { AC.Text = (int.Parse(Dex_Mod.Text) + 10).ToString(); }
            
            if (player.Inventory.Contains("Shield")) { AC.Text = (int.Parse(AC.Text) + 2).ToString(); }
        }

    }
}
