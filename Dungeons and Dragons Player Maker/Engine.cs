using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Dungeons_and_Dragons_Player_Maker {
    public static class Engine {
        public static List<PC> Characters {
            get { return Characters; }
            set { Characters = value; }
        }
    
        [Obsolete]
        public static void LoadCharacters() {
            using MemoryStream ms = new MemoryStream(Convert.FromBase64String(Properties.Settings.Default.Characters)); BinaryFormatter bf = new BinaryFormatter();
            Characters = (List<PC>)bf.Deserialize(ms);
        }

        [Obsolete]
        public static void SaveCharacters() {
            using MemoryStream ms = new MemoryStream(); BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, Characters);
            ms.Position = 0;
            byte[] buffer = new byte[(int)ms.Length];
            ms.Read(buffer, 0, buffer.Length);
            Properties.Settings.Default.Characters = Convert.ToBase64String(buffer);
            Properties.Settings.Default.Save();
        }


    }
}
