using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker {
    public partial class CustomizationTab : TabPage {
        private readonly PC PC;

        public event EventHandler OnReady;

        private bool _ready = false;

        private bool InformationFilled { get { return _ready; } set { _ready = value; if (value) { OnReady.Invoke(this, EventArgs.Empty); } } }

        [Obsolete]
        public CustomizationTab(PC Player) {
            PC = Player;
            Text = "Customize";
            BackColor = Color.White;
            InitializeComponent();
            Controls.Add(Pages);
            this.Enter += OnLoad;
            Scale(.75f);
        }
        [Obsolete]
        public void OnLoad(object sender, EventArgs e) {
            stats = new StatDataPage(PC);
            TabPage ClassOptions = null;
            switch (PC.Class.Split(":")[0]) {
                case "Artificer":
                    //ClassOptions = new ARTIFICER(PC);
                    break;
                case "Bard":
                    ClassOptions = new BARD(PC);
                    ((BARD)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Druid":
                    //ClassOptions = new Druid(PC);
                    break;
                case "Monk":
                    //ClassOptions = new Monk(PC);
                    break;
                case "Warlock":
                    //ClassOptions = new Warlock(PC);
                    break;
                case "Rogue":
                    //ClassOptions = new Rogue(PC);
                    break;
                case "Cleric":
                    //ClassOptions = new Cleric(PC);
                    break;
                case "Fighter":
                    //ClassOptions = new Fighter(PC);
                    break;
                case "Paladin":
                    //ClassOptions = new Paladin(PC);
                    break;
                case "Ranger":
                    //ClassOptions = new Ranger(PC);
                    break;
                case "Sorcerer":
                    //ClassOptions = new Sorcerer(PC);
                    break;
                case "Wizard":
                    //ClassOptions = new Wizard(PC);
                    break;
                case "Barbarian":
                    //ClassOptions = new Barbarian(PC);
                    break;
            }
            if ((!Pages.TabPages.OfType<TabPage>().Any(i => ClassOptions.GetType() == i.GetType())) &&
                (!Pages.TabPages.Contains(stats))) 
            { Pages.TabPages.Add(ClassOptions); }

        }

        private readonly TabControl Pages = new() {
            Size = new Size(492, 540),
            Location = new Point(6, 6),
        };
        private StatDataPage stats;

        private void CustomClass_Finished(object sender, EventArgs e) {
            if (!Pages.TabPages.Contains(stats)){ Pages.TabPages.Add(stats); }
        }

    }
}
#pragma warning restore IDE1006 // Naming Styles
