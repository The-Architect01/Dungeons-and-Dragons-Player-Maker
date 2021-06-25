using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace Dungeons_and_Dragons_Player_Maker {
    [Serializable]
    public class PC {
        public string Name { get; private set; }

        public string Race { get; private set; }
        public string Class { get; private set; }
        public string Background { get; private set; }

        public string[] Inventory { get; private set; }
        public string[] Personality { get; private set; }
        public List<string> Skills { get; private set; }
        public string Alignment { get; private set; }
        public int[] Stats { get; private set; }

        public int XP { get; private set; }
        public int Level { get; private set; }
        public string creator { get; private set; }

        public PC(string Race,string Class,string Background,string[] Personality,int XP,params string[] Inventory) {
            this.Race = Race;
            this.Class = Class;
            this.Background = Background;
            this.Personality = Personality;
            this.Inventory = Inventory;
            this.XP = XP;
            this.Level = getLevel();
        }

        public int getLevel() {
            if      (XP >= 0  && 300 > XP) { return 1; }
            else if (XP >= 300 && 900 > XP) { return 2; } 
            else if (XP >= 900 && 2700 > XP) { return 3; }
            else if (XP >= 2700 && 6500 > XP) { return 4; }
            else if (XP >= 6500 && 14000 > XP) { return 5; }
            else if (XP >= 14000 && 23000 > XP) { return 6; }
            else if (XP >= 23000 && 34000 > XP) { return 7; }
            else if (XP >= 34000 && 48000 > XP) { return 8; }
            else if (XP >= 48000 && 64000 > XP) { return 9; }
            else if (XP >= 64000 && 85000 > XP) { return 10; }
            else if (XP >= 85000 && 100000 > XP) { return 11; }
            else if (XP >= 100000 && 120000 > XP) { return 12; }
            else if (XP >= 120000 && 140000 > XP) { return 13; }
            else if (XP >= 140000 && 165000 > XP) { return 14; }
            else if (XP >= 165000 && 195000 > XP) { return 15; }
            else if (XP >= 195000 && 225000 > XP) { return 16; }
            else if (XP >= 225000 && 265000 > XP) { return 17; }
            else if (XP >= 265000 && 305000 > XP) { return 18; }
            else if (XP >= 305000 && 355000 > XP) { return 19; }
            else { return 20; }
        }

        public void gainXP(int XP) { if (XP <= 355000) { this.XP += XP; } else { showError(); } }      
        public void showError() { System.Windows.Forms.MessageBox.Show("You can't gain anymore XP!"); }

        [Obsolete]
        public void save() {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Name + " " +Class + ".hro";
            using (FileStream fs = File.Create(path)) {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(fs, this);
            }
            MessageBox.Show("The data was saved to your desktop.");
        }

        [Obsolete]
        public static PC openCharacter(string location) {
            using Stream stream = File.Open(location, FileMode.Open); BinaryFormatter bin = new BinaryFormatter();
            return (PC)bin.Deserialize(stream);
        }
    }
}
