using System;
using System.Drawing;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Classes;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker.Customization {
    public partial class ClassDataTab : TabPage {

        PC PC;
        
        public ClassDataTab(PC Player) {
            PC = Player;
            Text = "Class Customization Options";
            BackColor = Color.White;
            InitializeComponent();
        }
    }
}
