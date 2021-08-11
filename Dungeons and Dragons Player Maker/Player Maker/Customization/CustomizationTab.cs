using System;
using System.Drawing;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker {
    public partial class CustomizationTab : TabPage {
        readonly PC PC;

        public event EventHandler OnReady;

        bool _ready = false;
        bool informationFilled { get { return _ready; } set { _ready = value; if (value) { OnReady.Invoke(this, EventArgs.Empty); } } }

        public CustomizationTab(PC Player) {
            PC = Player;
            Text = "Customize";
            BackColor = Color.White;
            InitializeComponent();
            Controls.Add(Pages);
            this.Enter += OnLoad;
        }

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
            Pages.TabPages.Add(ClassOptions);

        }

        readonly TabControl Pages = new() {
            Size = new Size(492, 540),
            Location = new Point(6, 6),
        };

        StatDataPage stats;

        private void CustomClass_Finished(object sender, EventArgs e) {
            if (!Pages.TabPages.Contains(stats)){ Pages.TabPages.Add(stats); }
        }

    }
}
