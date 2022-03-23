using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeons_and_Dragons_Player_Maker.Homebrew {
    public partial class HomebrewEngine : Form {
        public HomebrewEngine() {
            InitializeComponent();
            PopulateRaceArrays();
        }

        [Obsolete]
        private void HomebrewEngine_Load(object sender, EventArgs e) {
            Scale(.75f);
            CenterToScreen();
            #region Races
            Size.SelectedItem = "Medium";
            #endregion
        }

        #region Races
        void PopulateRaceArrays() {
            Armor.Items.Clear();
            Armor.Items.AddRange(Engine.ARMORS);
            Lang.Items.Clear();
            Lang.Items.AddRange(Engine.LANGUAGES);
            Skills.Items.Clear();
            Skills.Items.AddRange(Engine.SKILLS);
            Tools.Items.Clear();
            Tools.Items.AddRange(Engine.TOOLS);
            Weapons.Items.Clear();
            Weapons.Items.AddRange(Engine.SIMPLE_WEAPONS);
            Weapons.Items.AddRange(Engine.MARTIAL_WEAPONS);

        }

        private void Speed_TextChanged(object sender, EventArgs e) {
            foreach(char character in Speed.Text.ToCharArray()) {
                if (!char.IsNumber(character)) {
                    MessageBox.Show("Please enter only numeric characters!");
                    Speed.Text = "30";
                }
            }
        }

        private void test() { }

        private void button2_Click(object sender, EventArgs e) {
            Traits.Text = "";
            RaceName.Text = "Human";
            Subrace.Text = "Natural";
            PopulateRaceArrays();
            Speed.Text = "30";
            Size.SelectedItem = "Medium";
        }
        #endregion
    }

    #region Homebrew

    [Serializable]
    public class HomebrewRace {
        static string HomebrewRaceData { get; } = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Star Interactive\Homebrew\Races";

        //STR_DEX_CON_WIS_INT_CHA_SPEED_SIZE_LANGUAGE_PROFICINCY_BONUS

        string Name;
        string StatBonus;
        string Speed;
        string Size;
        string Languages;
        string Proficincy;
        string Bonus;

        public static void AddHomebrewRace(HomebrewRace race) {
            ResXResourceReader reader = new(@".\Races.resx");
            ResXResourceWriter writer = new(@".\Races.resx");
            //writer.AddResource("")
        }

    }
    [Serializable]
    public class HomebrewClass {
        static string HomebrewClassData { get; } = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Star Interactive\Homebrew\Classes";

    }
    [Serializable]
    public class HomebrewBackground {
        static string HomebrewBackgroundData { get; } = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Star Interactive\Homebrew\Backgrounds";
       
    }

    [Serializable]
    public static class Homebrew {

        public static List<HomebrewRace> HomebrewRaces { get; } = new();
        public static List<HomebrewClass> HomebrewClases { get; } = new();
        public static List<HomebrewBackground> HomebrewBackgrounds { get; } = new();

        static Homebrew() {

        }

        public static void SaveToDisk() {

        }

    }
    #endregion
}