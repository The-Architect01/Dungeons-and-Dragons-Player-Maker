using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Dungeons_and_Dragons_Player_Maker {
    public static class Engine {

        public static readonly string[] LANGUAGES = {"Common","Dwarvish","Elvish","Giant","Gnomish","Goblin","Halfling","Orc","Abyssal","Celestial",
        "Deep Speech","Draconic","Infernal","Primordial","Sylvan","Undercommon"};
        public static readonly string[] SKILLS = { "Athletics","Acrobatics","Sleight of Hand","Stealth","Arcana","History","Investigation","Nature","Religion",
        "Animal Handling","Insight","Medicine","Perception", "Survival","Deception","Intimidation","Performance","Persuasion"};

        public static string[] AddChoose(string list) {
            List<string> value = new(){ "Select One"};
            if (list.SequenceEqual("Lang")) { value.AddRange(LANGUAGES); }
            else if (list.SequenceEqual("Skills")) { value.AddRange(SKILLS); }
            return value.ToArray();
        }

        public static List<PC> Characters {
            get { return Characters; }
            set { Characters = value; }
        }
    
        [Obsolete]
        public static void LoadCharacters() {
            using MemoryStream ms = new(Convert.FromBase64String(Properties.Settings.Default.Characters)); BinaryFormatter bf = new();
            Characters = (List<PC>)bf.Deserialize(ms);
        }

        [Obsolete]
        public static void SaveCharacters() {
            using MemoryStream ms = new(); BinaryFormatter bf = new();
            bf.Serialize(ms, Characters);
            ms.Position = 0;
            byte[] buffer = new byte[(int)ms.Length];
            ms.Read(buffer, 0, buffer.Length);
            Properties.Settings.Default.Characters = Convert.ToBase64String(buffer);
            Properties.Settings.Default.Save();
        }


    }
}
