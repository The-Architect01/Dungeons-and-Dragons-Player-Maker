using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Dungeons_and_Dragons_Player_Maker {
    public static class Engine {

        public static readonly Random RNG = new();

        public static readonly string[] LANGUAGES = {"Common","Dwarvish","Elvish","Giant","Gnomish","Goblin","Halfling","Orc","Abyssal","Celestial",
        "Deep Speech","Draconic","Infernal","Primordial","Sylvan","Undercommon"};
        public static readonly string[] SKILLS = { "Athletics","Acrobatics","Sleight of Hand","Stealth","Arcana","History","Investigation","Nature","Religion",
        "Animal Handling","Insight","Medicine","Perception", "Survival","Deception","Intimidation","Performance","Persuasion"};
        public static readonly string[] TOOLS = { "Alchemist’s supplies", "Brewer’s supplies","Calligrapher's Supplies", "Carpenter’s tools",
        "Cartographer’s tools","Cobbler’s tools","Cook’s utensils","Glassblower’s tools","Jeweler’s tools","Leatherworker’s tools","Mason’s tools",
        "Painter’s supplies","Potter’s tools","Smith’s tools","Tinker’s tools","Weaver’s tools","Woodcarver’s tools","Dice set","Playing card set",
        "Bagpipes","Drum","Dulcimer","Flute","Lute","Lyre","Horn","Pan flute","Shawm","Viol","Navigator’s tools","Thieves’ tools","Vehicles (land or water)"};

        public static readonly string[] SIMPLE_WEAPONS = { "Club","Dagger","Greatclub","Handaxe","Javelin","Light Hammer","Mace","Quarterstaff","Sickle","Spear",
                                                           "Light Crossbow","Dart","Shortbow","Sling"};
        public static readonly string[] MARTIAL_WEAPONS = { "Battleaxe","Flail","Glaive","Greataxe","Greatsword","Halberd","Lance","Longsword","Maul",
                                                            "Morningstar","Pike","Rapier","Scimitar","Shortsword","Trident","War pick","Warhammer","Whip",
                                                            "Blowgun","Heavy Crossbow","Hand Crossbow","Longbow","Net"};
        public static readonly string[] INSTRUMENTS = { "Bagpipes", "Drum", "Dulcimer", "Flute", "Lute", "Lyre", "Horn", "Pan flute", "Shawm", "Viol" };

        public static readonly string[] MELEEWEAPONS = { "Club", "Dagger", "Greatclub", "Handaxe", "Javelin", "Light Hammer", "Mace", "Quarterstaff", "Sickle", "Spear",
                                                         "Battleaxe","Flail","Glaive","Greataxe","Greatsword","Halberd","Lance","Longsword","Maul",
                                                         "Morningstar","Pike","Rapier","Scimitar","Shortsword","Trident","War pick","Warhammer","Whip", };
        public static readonly string[] RANGEDWEAPONS = { "Light Crossbow", "Dart", "Shortbow", "Sling", "Blowgun", "Heavy Crossbow", "Hand Crossbow", "Longbow", "Net" };

        public static readonly List<string> SpellCasters = new(){ "Wizard","Bard","Cleric","Druid","Sorcerer","Paladin","Ranger","Warlock",
                                                                  "Fighter-Eldritch Knight", "Rogue-Arcane Trickster"};

        public static string[] AddChoose(string list) {
            List<string> value = new(){ "Select One"};
            if (list.SequenceEqual("Lang")) { value.AddRange(LANGUAGES); }
            else if (list.SequenceEqual("Skills")) { value.AddRange(SKILLS); }
            return value.ToArray();
        }

        public static string[] ClassOptions(string[] list, params string[] AdditionalOptions) {
            List<string> value = new() { "Select One" };
            value.AddRange(AdditionalOptions);
            value.AddRange(list);
            return value.ToArray();
        }

        [Obsolete]
        public static string[] CharacterList { get { return LoadCharacters().Keys.ToArray(); } } 

        [Obsolete]
        public static Dictionary<string, PC> Characters { get; set; } = LoadCharacters();

        [Obsolete]
        public static Dictionary<string, PC> LoadCharacters() {
            try {
                using MemoryStream ms = new(Convert.FromBase64String(Properties.Settings.Default.Characters)); BinaryFormatter bf = new();
                return (Dictionary<string, PC>)bf.Deserialize(ms);
            } catch (Exception) {
                return new Dictionary<string, PC>();
            }
        }

        [Obsolete]
        public static void SaveCharacters() {
            try {
                using MemoryStream ms = new(); BinaryFormatter bf = new();
                bf.Serialize(ms, Characters);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                Properties.Settings.Default.Characters = Convert.ToBase64String(buffer);
            } catch (Exception) { }
            Properties.Settings.Default.Save();
        }

        [Obsolete]
        public static void CheckSettings() {
            Characters = LoadCharacters();
        }
     
    }
}