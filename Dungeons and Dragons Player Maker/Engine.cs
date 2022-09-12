using System;
using System.Collections.Generic;
using System.IO;
using IWshRuntimeLibrary;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Dungeons_and_Dragons_Player_Maker;
using Dungeons_and_Dragons_Player_Maker.Homebrew;

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

        public static readonly string[] ARMORS = { "Light", "Medium", "Heavy", "Shields" };

        public static readonly List<string> SpellCasters = new(){ "Wizard","Bard","Cleric","Druid","Sorcerer","Paladin","Ranger","Warlock",
                                                                  "Fighter:Eldritch Knight", "Rogue:Arcane Trickster"};

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
 
        public static SaveData SaveData { get; } = IO.LoadSaveFromDisk();
        public static Homebrew.Homebrew Homebrew { get; } = IO.LoadHomebrew();

        public static string[] AddChoose(this string[] List) {
            return List = new string[] { "Select One" }.Union(List).ToArray();
        }

    }
}

public static class IO {

    public static string SaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Star Interactive\file0";
    public static string HomebrewPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Star Interactive\file1";

    public static SaveData LoadSaveFromDisk() {
        try {
            using (StreamReader reader = new(SaveLocation)) {
                string Filecontents = reader.ReadToEnd();
                return JsonSerializer.Deserialize<SaveData>(Filecontents, new JsonSerializerOptions() { WriteIndented = true });
            }
        } catch (Exception e) when (e is DirectoryNotFoundException || e is FileNotFoundException) {
            return new SaveData();
        }
    }

    public static Homebrew LoadHomebrew() {
        try {
            using (StreamReader reader = new(HomebrewPath)) {
                string contents = reader.ReadToEnd();
                return JsonSerializer.Deserialize<Homebrew>(contents, new JsonSerializerOptions() { WriteIndented = true });
            }
        } catch (Exception e) when (e is DirectoryNotFoundException || e is FileNotFoundException) {
            return new Homebrew();
        }
    }

    public static void SaveDataToDisk() {
        try {
            System.IO.File.WriteAllText(SaveLocation, JsonSerializer.Serialize<SaveData>(Engine.SaveData, new JsonSerializerOptions() { WriteIndented = true }));
            System.IO.File.WriteAllText(HomebrewPath, JsonSerializer.Serialize<Homebrew>(Engine.Homebrew, new JsonSerializerOptions() { WriteIndented = true }));
        } catch {
            Directory.CreateDirectory(SaveLocation.Remove(SaveLocation.Length - 6));
            SaveDataToDisk();
        }
    }

    public static void CreateShortcut() {
        object ShortcutDesktop = (object)"Desktop";
        WshShell shell = new();
        string shortcutaddress = shell.SpecialFolders.Item(ref ShortcutDesktop) + @"\Dungeons and Dragons Player Maker.lnk";
        if (System.IO.File.Exists(shortcutaddress)) { return; }
        IWshShortcut NewShortcut = shell.CreateShortcut(shortcutaddress);
        NewShortcut.Description = "Dungeons and Dragons Player Maker";
        NewShortcut.TargetPath = SaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Star Interactive\Player Maker\Dungeons and Dragons Player Maker.exe";
        NewShortcut.IconLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Star Interactive\Player Maker\D202.ico";
        NewShortcut.Save();
    }
}

public class SaveData {
    public string Name { get; set; }
    public string CurrentVersion { get; set; } = "0.0.0.0";
    public DateTime LastUpdated { get; set; }
    public Dictionary<string, bool> SourceBooks { get; set; } = new Dictionary<string, bool>() { { "PHB", true },{ "HBW", false } };
    public string[] CharacterList { get { return Characters.Keys.ToArray<string>(); } }
    public Dictionary<string, Dungeons_and_Dragons_Player_Maker.PC> Characters { get; set; } = new Dictionary<string, Dungeons_and_Dragons_Player_Maker.PC>();
}
public static class SourceBooks {
    #region Sourcebook Data
    #region PHB
    private static readonly List<string> PHB_Races = new() {
        "Dwarf:Hill",
        "Dwarf:Mountain",
        "Elf:High",
        "Elf:Wood",
        "Elf:Drow",
        "Halfling:Lightfoot",
        "Halfling:Stout",
        "Human:Natural",
        "Human:Variant",
        "Dragonborn:Black",
        "Dragonborn:Blue",
        "Dragonborn:Brass",
        "Dragonborn:Bronze",
        "Dragonborn:Copper",
        "Dragonborn:Gold",
        "Dragonborn:Green",
        "Dragonborn:Red",
        "Dragonborn:Red",
        "Dragonborn:Silver",
        "Dragonborn:White",
        "Gnome:Forest",
        "Gnome:Rock",
        "Half-Elf:Natural",
        "Half-Orc:Natural",
        "Tiefling:Natural"
    };
    private static readonly List<string> PHB_Classes = new() {
        "Barbarian:Berserker",
        "Barbarian:Totem Warrior",
        "Bard:Lore",
        "Bard:Valor",
        "Cleric:Knowledge",
        "Cleric:Life",
        "Cleric:Light",
        "Cleric:Nature",
        "Cleric:Tempest",
        "Cleric:Trickery",
        "Cleric:War",
        "Druid:Circle of the Land",
        "Druid:Circle of the Moon",
        "Fighter:Champion",
        "Fighter:Battle Master",
        "Fighter:Eldritch Knight",
        "Monk:Way of the Open Hand",
        "Monk:Way of Shadow",
        "Monk:Way of the Four Elements",
        "Paladin:Oath of Devotion",
        "Paladin:Oath of the Ancients",
        "Paladin:Oath of Vengeance",
        "Ranger:Hunter",
        "Ranger:Beast Master",
        "Rogue:Thief",
        "Rogue:Assassin",
        "Rogue:Arcane Trickster",
        "Sorcerer:Draconic Bloodline",
        "Sorcerer:Wild Magic",
        "Warlock:The Archfey",
        "Warlock:The Fiend",
        "Warlock:The Great Old One",
        "Wizard:Abjuration",
        "Wizard:Conjuration",
        "Wizard:Divination",
        "Wizard:Enchantment",
        "Wizard:Evocation",
        "Wizard:Illusion",
        "Wizard:Necromancy",
        "Wizard:Transmutation"
    };
    private static readonly List<string> PHB_Backgrounds = new() {
        "Acolyte",
        "Charlatan",
        "Criminal/Spy",
        "Entertainer",
        "Folk Hero",
        "Guild Artisan",
        "Hermit",
        "Knight",
        "Noble",
        "Outlander",
        "Pirate",
        "Sage",
        "Sailor",
        "Soldier",
        "Urchin"
    };
    #endregion
    #region CRC
    private static readonly List<string> CRC_Races = new() { "Orc" };
    private static readonly List<string> CRC_Classes = new() { "Blood Hunter:Order of the Ghostslayer",
        "Blood Hunter:Order of the Lycan",
        "Blood Hunter:Order of the Mutant",
        "Blood Hunter:Order of the Profane Soul",
    };
    private static readonly List<string> CRC_Backgrounds = new() { "Grinner", "Volstrucker Agent" };
    #endregion
    #endregion
    #region Sourcebook Access
    private static readonly Dictionary<string, List<string>> PHB = new() { { "Races", PHB_Races }, { "Classes", PHB_Classes }, { "Backgrounds", PHB_Backgrounds } };
    private static readonly Dictionary<string, List<string>> CRC = new() { { "Races",CRC_Races },{ "Classes", CRC_Classes },{ "Backgrounds", CRC_Backgrounds } };
    private static readonly Dictionary<string, List<string>> HBW = new() { 
        { "Races", Engine.Homebrew.HomebrewRaces.Keys.ToList() }, 
        { "Classes", Engine.Homebrew.HomebrewClasses.Keys.ToList() }, 
        { "Backgrounds", Engine.Homebrew.HomebrewBackgrounds.Keys.ToList() } 
    };
    #endregion
    public static Dictionary<string, List<string>> Sourcebook(string sourcebook) {
        if (sourcebook != "HBW") {
            return (Dictionary<string, List<string>>)
                typeof(SourceBooks).GetField(sourcebook.ToUpper(),
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static).
                GetValue(typeof(SourceBooks));
        } else {
            return new Dictionary<string, List<string>>() {
                { "Races", Engine.Homebrew.HomebrewRaces.Keys.ToList() },
                { "Classes",Engine.Homebrew.HomebrewClasses.Keys.ToList() },
                { "Backgrounds", Engine.Homebrew.HomebrewBackgrounds.Keys.ToList() }
            };
        }
    }
}
