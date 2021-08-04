using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Classes {
    public partial class ClassTab : TabPage {

        PC PC;

        #region Variables
        Label[] ClassName;
        static readonly string[] Classes = { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
        #endregion



        public event EventHandler OnReady;

        bool _ready = false;
        bool informationFilled { get { return _ready; } set { _ready = value; if (value) { OnReady.Invoke(this, EventArgs.Empty); } } }


        public ClassTab(PC Player) {
            PC = Player;
            InitializeComponent();
            ClassName = new Label[] { C1, C2, C3, C4, C5, C6 };
        }

        #region Controls
        #region Labels -- Class Names
        Label C1;
        Label C2;
        Label C3;
        Label C4;
        Label C5;
        Label C6;
        #endregion
        #endregion
    }
}
