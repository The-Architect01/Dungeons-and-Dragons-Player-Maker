using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Backgrounds;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Races;
using Dungeons_and_Dragons_Player_Maker.Player_Maker.Classes;
using Dungeons_and_Dragons_Player_Maker.Player_Maker;

namespace Dungeons_and_Dragons_Player_Maker {
    public partial class CreateCharacter : Form {
        private readonly PC Player = new();
        private RaceTab RT;
        private ClassTab CT;
        private BackgroundTab BT;
        private CustomizationTab FT;

        [Obsolete]
        public CreateCharacter() {
            InitializeComponent();
        }

        [Obsolete]
        private void CreateCharacter_Load(object sender, EventArgs e) {
            Player.creator = Properties.Settings.Default.Name;
            RT = new RaceTab(Player);
            CT = new ClassTab(Player);
            BT = new BackgroundTab(Player);
            FT = new CustomizationTab(Player);
            tabControl1.TabPages.Add(RT);
            RT.OnReady += RaceDataFilled;
            CT.OnReady += ClassDataFilled;
            BT.OnReady += BackgroundDataFilled;
            BT.OnReset += BackgroundDataReset;
            Scale(.75f);
            CenterToScreen();
        }

        private void RaceDataFilled(object sender, EventArgs e) {
            if (!tabControl1.TabPages.Contains(CT)) { tabControl1.TabPages.Add(CT); }
        }
        private void ClassDataFilled(object sender, EventArgs e) {
            if (!tabControl1.TabPages.Contains(BT)) { tabControl1.TabPages.Add(BT); }
        }
        private void BackgroundDataFilled(object sender, EventArgs e) {
            if (!tabControl1.TabPages.Contains(FT)) { tabControl1.TabPages.Add(FT); }
        }
        private void BackgroundDataReset(object sender, EventArgs e) {
            if (tabControl1.TabPages.Contains(FT)) { tabControl1.TabPages.Remove(FT); }
        }

        private void CreateCharacter_FormClosing(object sender, FormClosingEventArgs e) {
            var Answer = MessageBox.Show("Are you sure you want to close? All unsaved data will be lost.", "D&D Player Maker", MessageBoxButtons.YesNo);
            if (Answer == DialogResult.No) { e.Cancel = true; }
        }

    }
}
#pragma warning restore IDE1006 // Naming Styles
