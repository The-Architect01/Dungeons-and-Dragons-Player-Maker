using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization.Classes;
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
                    ClassOptions = new ARTIFICER(PC);
                    ((ARTIFICER)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Bard":
                    ClassOptions = new BARD(PC);
                    ((BARD)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Druid":
                    ClassOptions = new DRUID(PC);
                    ((DRUID)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Monk":
                    ClassOptions = new MONK(PC); 
                    ((MONK)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Warlock":
                    ClassOptions = new WARLOCK(PC);
                    ((WARLOCK)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Rogue":
                    ClassOptions = new ROGUE(PC);
                    ((ROGUE)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Cleric":
                    ClassOptions = new CLERIC(PC);
                    ((CLERIC)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Fighter":
                    ClassOptions = new FIGHTER(PC);
                    ((FIGHTER)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Paladin":
                    ClassOptions = new PALADIN(PC);
                    ((PALADIN)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Ranger":
                    ClassOptions = new RANGER(PC);
                    ((RANGER)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Sorcerer":
                    ClassOptions = new SORCERER(PC);
                    ((SORCERER)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Wizard":
                    ClassOptions = new WIZARD(PC);
                    ((WIZARD)ClassOptions).OnReady += CustomClass_Finished;
                    break;
                case "Barbarian":
                    ClassOptions = new BARBARIAN(PC);
                    ((BARBARIAN)ClassOptions).OnReady += CustomClass_Finished;
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