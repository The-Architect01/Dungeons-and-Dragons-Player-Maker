
namespace Dungeons_and_Dragons_Player_Maker {
    partial class PrintSheet {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintSheet));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.Character_Name = new System.Windows.Forms.Label();
            this.Player_Name = new System.Windows.Forms.Label();
            this.XP = new System.Windows.Forms.Label();
            this.Background = new System.Windows.Forms.Label();
            this.Alignment = new System.Windows.Forms.Label();
            this.Class = new System.Windows.Forms.Label();
            this.Race = new System.Windows.Forms.Label();
            this.Proficency = new System.Windows.Forms.Label();
            this.AC = new System.Windows.Forms.Label();
            this.Initiative = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.Label();
            this.STR_Mod = new System.Windows.Forms.Label();
            this.Dex_Mod = new System.Windows.Forms.Label();
            this.Con_Mod = new System.Windows.Forms.Label();
            this.Int_Mod = new System.Windows.Forms.Label();
            this.Wis_Mod = new System.Windows.Forms.Label();
            this.Cha_Mod = new System.Windows.Forms.Label();
            this.Passive_Wis = new System.Windows.Forms.Label();
            this.Strength = new System.Windows.Forms.Label();
            this.Dextarity = new System.Windows.Forms.Label();
            this.Constitution = new System.Windows.Forms.Label();
            this.Intelligence = new System.Windows.Forms.Label();
            this.Wisdom = new System.Windows.Forms.Label();
            this.Charisma = new System.Windows.Forms.Label();
            this.Str_Save = new System.Windows.Forms.Label();
            this.Athletics = new System.Windows.Forms.Label();
            this.Acrobatics = new System.Windows.Forms.Label();
            this.Dex_Save = new System.Windows.Forms.Label();
            this.Sleight = new System.Windows.Forms.Label();
            this.Stealth = new System.Windows.Forms.Label();
            this.Con_Save = new System.Windows.Forms.Label();
            this.Performance = new System.Windows.Forms.Label();
            this.Intimidation = new System.Windows.Forms.Label();
            this.Deception = new System.Windows.Forms.Label();
            this.Cha_Save = new System.Windows.Forms.Label();
            this.Persuasion = new System.Windows.Forms.Label();
            this.Perception = new System.Windows.Forms.Label();
            this.Medicine = new System.Windows.Forms.Label();
            this.Insight = new System.Windows.Forms.Label();
            this.Animal = new System.Windows.Forms.Label();
            this.Wis_Save = new System.Windows.Forms.Label();
            this.Survival = new System.Windows.Forms.Label();
            this.Religion = new System.Windows.Forms.Label();
            this.Nature = new System.Windows.Forms.Label();
            this.Investigation = new System.Windows.Forms.Label();
            this.History = new System.Windows.Forms.Label();
            this.Arcana = new System.Windows.Forms.Label();
            this.Int_Save = new System.Windows.Forms.Label();
            this.HD_Num = new System.Windows.Forms.Label();
            this.HitDie = new System.Windows.Forms.Label();
            this.HP = new System.Windows.Forms.Label();
            this.Abilities = new System.Windows.Forms.Label();
            this.Equip = new System.Windows.Forms.Label();
            this.Prof = new System.Windows.Forms.Label();
            this.Personality = new System.Windows.Forms.Label();
            this.Ideal = new System.Windows.Forms.Label();
            this.Bond = new System.Windows.Forms.Label();
            this.Flaw = new System.Windows.Forms.Label();
            this.Weapons = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Character_Name
            // 
            this.Character_Name.BackColor = System.Drawing.Color.Transparent;
            this.Character_Name.Font = new System.Drawing.Font("Book Antiqua", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Character_Name.Location = new System.Drawing.Point(57, 74);
            this.Character_Name.Name = "Character_Name";
            this.Character_Name.Size = new System.Drawing.Size(285, 43);
            this.Character_Name.TabIndex = 0;
            this.Character_Name.Tag = "0";
            this.Character_Name.Text = "Sample Character";
            this.Character_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Character_Name.UseCompatibleTextRendering = true;
            // 
            // Player_Name
            // 
            this.Player_Name.BackColor = System.Drawing.Color.Transparent;
            this.Player_Name.Font = new System.Drawing.Font("Book Antiqua", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Player_Name.Location = new System.Drawing.Point(622, 61);
            this.Player_Name.Name = "Player_Name";
            this.Player_Name.Size = new System.Drawing.Size(135, 25);
            this.Player_Name.TabIndex = 1;
            this.Player_Name.Tag = "0";
            this.Player_Name.Text = "The Architect";
            this.Player_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Player_Name.UseCompatibleTextRendering = true;
            // 
            // XP
            // 
            this.XP.BackColor = System.Drawing.Color.Transparent;
            this.XP.Font = new System.Drawing.Font("Book Antiqua", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.XP.Location = new System.Drawing.Point(643, 89);
            this.XP.Name = "XP";
            this.XP.Size = new System.Drawing.Size(118, 43);
            this.XP.TabIndex = 2;
            this.XP.Tag = "0";
            this.XP.Text = "0";
            this.XP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.XP.UseCompatibleTextRendering = true;
            // 
            // Background
            // 
            this.Background.BackColor = System.Drawing.Color.Transparent;
            this.Background.Font = new System.Drawing.Font("Book Antiqua", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Background.Location = new System.Drawing.Point(491, 61);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(123, 25);
            this.Background.TabIndex = 3;
            this.Background.Tag = "0";
            this.Background.Text = "Charlatan";
            this.Background.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Background.UseCompatibleTextRendering = true;
            // 
            // Alignment
            // 
            this.Alignment.BackColor = System.Drawing.Color.Transparent;
            this.Alignment.Font = new System.Drawing.Font("Book Antiqua", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Alignment.Location = new System.Drawing.Point(491, 95);
            this.Alignment.Name = "Alignment";
            this.Alignment.Size = new System.Drawing.Size(156, 25);
            this.Alignment.TabIndex = 4;
            this.Alignment.Tag = "0";
            this.Alignment.Text = "Chaotic Neutral";
            this.Alignment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Alignment.UseCompatibleTextRendering = true;
            // 
            // Class
            // 
            this.Class.BackColor = System.Drawing.Color.Transparent;
            this.Class.Font = new System.Drawing.Font("Book Antiqua", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Class.Location = new System.Drawing.Point(350, 61);
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(154, 25);
            this.Class.TabIndex = 5;
            this.Class.Tag = "0";
            this.Class.Text = "Rogue/Warlock";
            this.Class.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Class.UseCompatibleTextRendering = true;
            // 
            // Race
            // 
            this.Race.BackColor = System.Drawing.Color.Transparent;
            this.Race.Font = new System.Drawing.Font("Book Antiqua", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Race.Location = new System.Drawing.Point(350, 95);
            this.Race.Name = "Race";
            this.Race.Size = new System.Drawing.Size(135, 25);
            this.Race.TabIndex = 6;
            this.Race.Tag = "0";
            this.Race.Text = "Half-Elf";
            this.Race.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Race.UseCompatibleTextRendering = true;
            // 
            // Proficency
            // 
            this.Proficency.BackColor = System.Drawing.Color.Transparent;
            this.Proficency.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Proficency.Location = new System.Drawing.Point(46, 177);
            this.Proficency.Name = "Proficency";
            this.Proficency.Size = new System.Drawing.Size(70, 43);
            this.Proficency.TabIndex = 7;
            this.Proficency.Tag = "0";
            this.Proficency.Text = "+ 6";
            this.Proficency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Proficency.UseCompatibleTextRendering = true;
            // 
            // AC
            // 
            this.AC.BackColor = System.Drawing.Color.Transparent;
            this.AC.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AC.Location = new System.Drawing.Point(299, 190);
            this.AC.Name = "AC";
            this.AC.Size = new System.Drawing.Size(59, 43);
            this.AC.TabIndex = 9;
            this.AC.Tag = "0";
            this.AC.Text = "30";
            this.AC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AC.UseCompatibleTextRendering = true;
            // 
            // Initiative
            // 
            this.Initiative.BackColor = System.Drawing.Color.Transparent;
            this.Initiative.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Initiative.Location = new System.Drawing.Point(368, 193);
            this.Initiative.Name = "Initiative";
            this.Initiative.Size = new System.Drawing.Size(70, 43);
            this.Initiative.TabIndex = 10;
            this.Initiative.Tag = "0";
            this.Initiative.Text = "+ 15";
            this.Initiative.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Initiative.UseCompatibleTextRendering = true;
            // 
            // Speed
            // 
            this.Speed.BackColor = System.Drawing.Color.Transparent;
            this.Speed.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Speed.Location = new System.Drawing.Point(447, 194);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(70, 43);
            this.Speed.TabIndex = 11;
            this.Speed.Tag = "0";
            this.Speed.Text = "50";
            this.Speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Speed.UseCompatibleTextRendering = true;
            // 
            // STR_Mod
            // 
            this.STR_Mod.BackColor = System.Drawing.Color.Transparent;
            this.STR_Mod.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.STR_Mod.Location = new System.Drawing.Point(54, 254);
            this.STR_Mod.Name = "STR_Mod";
            this.STR_Mod.Size = new System.Drawing.Size(59, 43);
            this.STR_Mod.TabIndex = 12;
            this.STR_Mod.Tag = "0";
            this.STR_Mod.Text = "- 10";
            this.STR_Mod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.STR_Mod.UseCompatibleTextRendering = true;
            // 
            // Dex_Mod
            // 
            this.Dex_Mod.BackColor = System.Drawing.Color.Transparent;
            this.Dex_Mod.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Dex_Mod.Location = new System.Drawing.Point(54, 345);
            this.Dex_Mod.Name = "Dex_Mod";
            this.Dex_Mod.Size = new System.Drawing.Size(59, 43);
            this.Dex_Mod.TabIndex = 13;
            this.Dex_Mod.Tag = "0";
            this.Dex_Mod.Text = "- 10";
            this.Dex_Mod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Dex_Mod.UseCompatibleTextRendering = true;
            // 
            // Con_Mod
            // 
            this.Con_Mod.BackColor = System.Drawing.Color.Transparent;
            this.Con_Mod.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Con_Mod.Location = new System.Drawing.Point(54, 435);
            this.Con_Mod.Name = "Con_Mod";
            this.Con_Mod.Size = new System.Drawing.Size(59, 43);
            this.Con_Mod.TabIndex = 14;
            this.Con_Mod.Tag = "0";
            this.Con_Mod.Text = "- 10";
            this.Con_Mod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Con_Mod.UseCompatibleTextRendering = true;
            // 
            // Int_Mod
            // 
            this.Int_Mod.BackColor = System.Drawing.Color.Transparent;
            this.Int_Mod.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Int_Mod.Location = new System.Drawing.Point(54, 525);
            this.Int_Mod.Name = "Int_Mod";
            this.Int_Mod.Size = new System.Drawing.Size(59, 43);
            this.Int_Mod.TabIndex = 15;
            this.Int_Mod.Tag = "0";
            this.Int_Mod.Text = "- 10";
            this.Int_Mod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Int_Mod.UseCompatibleTextRendering = true;
            // 
            // Wis_Mod
            // 
            this.Wis_Mod.BackColor = System.Drawing.Color.Transparent;
            this.Wis_Mod.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Wis_Mod.Location = new System.Drawing.Point(54, 616);
            this.Wis_Mod.Name = "Wis_Mod";
            this.Wis_Mod.Size = new System.Drawing.Size(59, 43);
            this.Wis_Mod.TabIndex = 16;
            this.Wis_Mod.Tag = "0";
            this.Wis_Mod.Text = "- 10";
            this.Wis_Mod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Wis_Mod.UseCompatibleTextRendering = true;
            // 
            // Cha_Mod
            // 
            this.Cha_Mod.BackColor = System.Drawing.Color.Transparent;
            this.Cha_Mod.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Cha_Mod.Location = new System.Drawing.Point(54, 707);
            this.Cha_Mod.Name = "Cha_Mod";
            this.Cha_Mod.Size = new System.Drawing.Size(59, 43);
            this.Cha_Mod.TabIndex = 17;
            this.Cha_Mod.Tag = "0";
            this.Cha_Mod.Text = "- 10";
            this.Cha_Mod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Cha_Mod.UseCompatibleTextRendering = true;
            // 
            // Passive_Wis
            // 
            this.Passive_Wis.BackColor = System.Drawing.Color.Transparent;
            this.Passive_Wis.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Passive_Wis.Location = new System.Drawing.Point(55, 797);
            this.Passive_Wis.Name = "Passive_Wis";
            this.Passive_Wis.Size = new System.Drawing.Size(59, 43);
            this.Passive_Wis.TabIndex = 18;
            this.Passive_Wis.Tag = "0";
            this.Passive_Wis.Text = "6";
            this.Passive_Wis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Passive_Wis.UseCompatibleTextRendering = true;
            // 
            // Strength
            // 
            this.Strength.BackColor = System.Drawing.Color.Transparent;
            this.Strength.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Strength.Location = new System.Drawing.Point(49, 285);
            this.Strength.Name = "Strength";
            this.Strength.Size = new System.Drawing.Size(70, 43);
            this.Strength.TabIndex = 19;
            this.Strength.Tag = "0";
            this.Strength.Text = "30";
            this.Strength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Strength.UseCompatibleTextRendering = true;
            // 
            // Dextarity
            // 
            this.Dextarity.BackColor = System.Drawing.Color.Transparent;
            this.Dextarity.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Dextarity.Location = new System.Drawing.Point(49, 376);
            this.Dextarity.Name = "Dextarity";
            this.Dextarity.Size = new System.Drawing.Size(70, 43);
            this.Dextarity.TabIndex = 20;
            this.Dextarity.Tag = "0";
            this.Dextarity.Text = "30";
            this.Dextarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Dextarity.UseCompatibleTextRendering = true;
            // 
            // Constitution
            // 
            this.Constitution.BackColor = System.Drawing.Color.Transparent;
            this.Constitution.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Constitution.Location = new System.Drawing.Point(49, 467);
            this.Constitution.Name = "Constitution";
            this.Constitution.Size = new System.Drawing.Size(70, 43);
            this.Constitution.TabIndex = 21;
            this.Constitution.Tag = "0";
            this.Constitution.Text = "30";
            this.Constitution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Constitution.UseCompatibleTextRendering = true;
            // 
            // Intelligence
            // 
            this.Intelligence.BackColor = System.Drawing.Color.Transparent;
            this.Intelligence.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Intelligence.Location = new System.Drawing.Point(49, 558);
            this.Intelligence.Name = "Intelligence";
            this.Intelligence.Size = new System.Drawing.Size(70, 43);
            this.Intelligence.TabIndex = 22;
            this.Intelligence.Tag = "0";
            this.Intelligence.Text = "30";
            this.Intelligence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Intelligence.UseCompatibleTextRendering = true;
            // 
            // Wisdom
            // 
            this.Wisdom.BackColor = System.Drawing.Color.Transparent;
            this.Wisdom.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Wisdom.Location = new System.Drawing.Point(49, 649);
            this.Wisdom.Name = "Wisdom";
            this.Wisdom.Size = new System.Drawing.Size(70, 43);
            this.Wisdom.TabIndex = 23;
            this.Wisdom.Tag = "0";
            this.Wisdom.Text = "30";
            this.Wisdom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Wisdom.UseCompatibleTextRendering = true;
            // 
            // Charisma
            // 
            this.Charisma.BackColor = System.Drawing.Color.Transparent;
            this.Charisma.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Charisma.Location = new System.Drawing.Point(49, 741);
            this.Charisma.Name = "Charisma";
            this.Charisma.Size = new System.Drawing.Size(70, 43);
            this.Charisma.TabIndex = 24;
            this.Charisma.Tag = "0";
            this.Charisma.Text = "30";
            this.Charisma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Charisma.UseCompatibleTextRendering = true;
            // 
            // Str_Save
            // 
            this.Str_Save.BackColor = System.Drawing.Color.Transparent;
            this.Str_Save.Font = new System.Drawing.Font("Blackadder ITC", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Str_Save.Location = new System.Drawing.Point(131, 264);
            this.Str_Save.Name = "Str_Save";
            this.Str_Save.Size = new System.Drawing.Size(72, 25);
            this.Str_Save.TabIndex = 25;
            this.Str_Save.Text = "🔸";
            this.Str_Save.Visible = false;
            // 
            // Athletics
            // 
            this.Athletics.BackColor = System.Drawing.Color.Transparent;
            this.Athletics.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Athletics.Location = new System.Drawing.Point(135, 283);
            this.Athletics.Name = "Athletics";
            this.Athletics.Size = new System.Drawing.Size(72, 25);
            this.Athletics.TabIndex = 26;
            this.Athletics.Text = "⚫";
            this.Athletics.Visible = false;
            // 
            // Acrobatics
            // 
            this.Acrobatics.BackColor = System.Drawing.Color.Transparent;
            this.Acrobatics.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Acrobatics.Location = new System.Drawing.Point(135, 374);
            this.Acrobatics.Name = "Acrobatics";
            this.Acrobatics.Size = new System.Drawing.Size(72, 25);
            this.Acrobatics.TabIndex = 28;
            this.Acrobatics.Text = "⚫";
            this.Acrobatics.Visible = false;
            // 
            // Dex_Save
            // 
            this.Dex_Save.BackColor = System.Drawing.Color.Transparent;
            this.Dex_Save.Font = new System.Drawing.Font("Blackadder ITC", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Dex_Save.Location = new System.Drawing.Point(131, 355);
            this.Dex_Save.Name = "Dex_Save";
            this.Dex_Save.Size = new System.Drawing.Size(72, 25);
            this.Dex_Save.TabIndex = 27;
            this.Dex_Save.Text = "🔸";
            this.Dex_Save.Visible = false;
            // 
            // Sleight
            // 
            this.Sleight.BackColor = System.Drawing.Color.Transparent;
            this.Sleight.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Sleight.Location = new System.Drawing.Point(135, 386);
            this.Sleight.Name = "Sleight";
            this.Sleight.Size = new System.Drawing.Size(72, 25);
            this.Sleight.TabIndex = 29;
            this.Sleight.Text = "⚫";
            this.Sleight.Visible = false;
            // 
            // Stealth
            // 
            this.Stealth.BackColor = System.Drawing.Color.Transparent;
            this.Stealth.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stealth.Location = new System.Drawing.Point(135, 399);
            this.Stealth.Name = "Stealth";
            this.Stealth.Size = new System.Drawing.Size(72, 25);
            this.Stealth.TabIndex = 30;
            this.Stealth.Text = "⚫";
            this.Stealth.Visible = false;
            // 
            // Con_Save
            // 
            this.Con_Save.BackColor = System.Drawing.Color.Transparent;
            this.Con_Save.Font = new System.Drawing.Font("Blackadder ITC", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Con_Save.Location = new System.Drawing.Point(131, 446);
            this.Con_Save.Name = "Con_Save";
            this.Con_Save.Size = new System.Drawing.Size(72, 25);
            this.Con_Save.TabIndex = 31;
            this.Con_Save.Text = "🔸";
            this.Con_Save.Visible = false;
            // 
            // Performance
            // 
            this.Performance.BackColor = System.Drawing.Color.Transparent;
            this.Performance.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Performance.Location = new System.Drawing.Point(135, 761);
            this.Performance.Name = "Performance";
            this.Performance.Size = new System.Drawing.Size(72, 25);
            this.Performance.TabIndex = 35;
            this.Performance.Text = "⚫";
            this.Performance.Visible = false;
            // 
            // Intimidation
            // 
            this.Intimidation.BackColor = System.Drawing.Color.Transparent;
            this.Intimidation.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Intimidation.Location = new System.Drawing.Point(135, 749);
            this.Intimidation.Name = "Intimidation";
            this.Intimidation.Size = new System.Drawing.Size(72, 25);
            this.Intimidation.TabIndex = 34;
            this.Intimidation.Text = "⚫";
            this.Intimidation.Visible = false;
            // 
            // Deception
            // 
            this.Deception.BackColor = System.Drawing.Color.Transparent;
            this.Deception.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Deception.Location = new System.Drawing.Point(135, 736);
            this.Deception.Name = "Deception";
            this.Deception.Size = new System.Drawing.Size(72, 25);
            this.Deception.TabIndex = 33;
            this.Deception.Text = "⚫";
            this.Deception.Visible = false;
            // 
            // Cha_Save
            // 
            this.Cha_Save.BackColor = System.Drawing.Color.Transparent;
            this.Cha_Save.Font = new System.Drawing.Font("Blackadder ITC", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Cha_Save.Location = new System.Drawing.Point(131, 717);
            this.Cha_Save.Name = "Cha_Save";
            this.Cha_Save.Size = new System.Drawing.Size(72, 25);
            this.Cha_Save.TabIndex = 32;
            this.Cha_Save.Text = "🔸";
            this.Cha_Save.Visible = false;
            // 
            // Persuasion
            // 
            this.Persuasion.BackColor = System.Drawing.Color.Transparent;
            this.Persuasion.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Persuasion.Location = new System.Drawing.Point(135, 774);
            this.Persuasion.Name = "Persuasion";
            this.Persuasion.Size = new System.Drawing.Size(72, 25);
            this.Persuasion.TabIndex = 36;
            this.Persuasion.Text = "⚫";
            this.Persuasion.Visible = false;
            // 
            // Perception
            // 
            this.Perception.BackColor = System.Drawing.Color.Transparent;
            this.Perception.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Perception.Location = new System.Drawing.Point(135, 684);
            this.Perception.Name = "Perception";
            this.Perception.Size = new System.Drawing.Size(72, 25);
            this.Perception.TabIndex = 41;
            this.Perception.Text = "⚫";
            this.Perception.Visible = false;
            // 
            // Medicine
            // 
            this.Medicine.BackColor = System.Drawing.Color.Transparent;
            this.Medicine.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Medicine.Location = new System.Drawing.Point(135, 671);
            this.Medicine.Name = "Medicine";
            this.Medicine.Size = new System.Drawing.Size(72, 25);
            this.Medicine.TabIndex = 40;
            this.Medicine.Text = "⚫";
            this.Medicine.Visible = false;
            // 
            // Insight
            // 
            this.Insight.BackColor = System.Drawing.Color.Transparent;
            this.Insight.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Insight.Location = new System.Drawing.Point(135, 658);
            this.Insight.Name = "Insight";
            this.Insight.Size = new System.Drawing.Size(72, 25);
            this.Insight.TabIndex = 39;
            this.Insight.Text = "⚫";
            this.Insight.Visible = false;
            // 
            // Animal
            // 
            this.Animal.BackColor = System.Drawing.Color.Transparent;
            this.Animal.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Animal.Location = new System.Drawing.Point(135, 646);
            this.Animal.Name = "Animal";
            this.Animal.Size = new System.Drawing.Size(72, 25);
            this.Animal.TabIndex = 38;
            this.Animal.Text = "⚫";
            this.Animal.Visible = false;
            // 
            // Wis_Save
            // 
            this.Wis_Save.BackColor = System.Drawing.Color.Transparent;
            this.Wis_Save.Font = new System.Drawing.Font("Blackadder ITC", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Wis_Save.Location = new System.Drawing.Point(131, 627);
            this.Wis_Save.Name = "Wis_Save";
            this.Wis_Save.Size = new System.Drawing.Size(72, 25);
            this.Wis_Save.TabIndex = 37;
            this.Wis_Save.Text = "🔸";
            this.Wis_Save.Visible = false;
            // 
            // Survival
            // 
            this.Survival.BackColor = System.Drawing.Color.Transparent;
            this.Survival.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Survival.Location = new System.Drawing.Point(135, 696);
            this.Survival.Name = "Survival";
            this.Survival.Size = new System.Drawing.Size(72, 25);
            this.Survival.TabIndex = 42;
            this.Survival.Text = "⚫";
            this.Survival.Visible = false;
            // 
            // Religion
            // 
            this.Religion.BackColor = System.Drawing.Color.Transparent;
            this.Religion.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Religion.Location = new System.Drawing.Point(135, 605);
            this.Religion.Name = "Religion";
            this.Religion.Size = new System.Drawing.Size(72, 25);
            this.Religion.TabIndex = 48;
            this.Religion.Text = "⚫";
            this.Religion.Visible = false;
            // 
            // Nature
            // 
            this.Nature.BackColor = System.Drawing.Color.Transparent;
            this.Nature.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Nature.Location = new System.Drawing.Point(135, 593);
            this.Nature.Name = "Nature";
            this.Nature.Size = new System.Drawing.Size(72, 25);
            this.Nature.TabIndex = 47;
            this.Nature.Text = "⚫";
            this.Nature.Visible = false;
            // 
            // Investigation
            // 
            this.Investigation.BackColor = System.Drawing.Color.Transparent;
            this.Investigation.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Investigation.Location = new System.Drawing.Point(135, 580);
            this.Investigation.Name = "Investigation";
            this.Investigation.Size = new System.Drawing.Size(72, 25);
            this.Investigation.TabIndex = 46;
            this.Investigation.Text = "⚫";
            this.Investigation.Visible = false;
            // 
            // History
            // 
            this.History.BackColor = System.Drawing.Color.Transparent;
            this.History.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.History.Location = new System.Drawing.Point(135, 567);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(72, 25);
            this.History.TabIndex = 45;
            this.History.Text = "⚫";
            this.History.Visible = false;
            // 
            // Arcana
            // 
            this.Arcana.BackColor = System.Drawing.Color.Transparent;
            this.Arcana.Font = new System.Drawing.Font("Blackadder ITC", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Arcana.Location = new System.Drawing.Point(135, 555);
            this.Arcana.Name = "Arcana";
            this.Arcana.Size = new System.Drawing.Size(72, 25);
            this.Arcana.TabIndex = 44;
            this.Arcana.Text = "⚫";
            this.Arcana.Visible = false;
            // 
            // Int_Save
            // 
            this.Int_Save.BackColor = System.Drawing.Color.Transparent;
            this.Int_Save.Font = new System.Drawing.Font("Blackadder ITC", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Int_Save.Location = new System.Drawing.Point(131, 536);
            this.Int_Save.Name = "Int_Save";
            this.Int_Save.Size = new System.Drawing.Size(72, 25);
            this.Int_Save.TabIndex = 43;
            this.Int_Save.Text = "🔸";
            this.Int_Save.Visible = false;
            // 
            // HD_Num
            // 
            this.HD_Num.BackColor = System.Drawing.Color.Transparent;
            this.HD_Num.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HD_Num.Location = new System.Drawing.Point(326, 421);
            this.HD_Num.Name = "HD_Num";
            this.HD_Num.Size = new System.Drawing.Size(59, 27);
            this.HD_Num.TabIndex = 49;
            this.HD_Num.Tag = "0";
            this.HD_Num.Text = "20";
            this.HD_Num.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HD_Num.UseCompatibleTextRendering = true;
            // 
            // HitDie
            // 
            this.HitDie.BackColor = System.Drawing.Color.Transparent;
            this.HitDie.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HitDie.Location = new System.Drawing.Point(320, 445);
            this.HitDie.Name = "HitDie";
            this.HitDie.Size = new System.Drawing.Size(59, 43);
            this.HitDie.TabIndex = 50;
            this.HitDie.Tag = "0";
            this.HitDie.Text = "d12";
            this.HitDie.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HitDie.UseCompatibleTextRendering = true;
            // 
            // HP
            // 
            this.HP.BackColor = System.Drawing.Color.Transparent;
            this.HP.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HP.Location = new System.Drawing.Point(418, 254);
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(59, 40);
            this.HP.TabIndex = 51;
            this.HP.Tag = "0";
            this.HP.Text = "240";
            this.HP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HP.UseCompatibleTextRendering = true;
            // 
            // Abilities
            // 
            this.Abilities.BackColor = System.Drawing.Color.White;
            this.Abilities.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Abilities.Location = new System.Drawing.Point(546, 515);
            this.Abilities.Name = "Abilities";
            this.Abilities.Size = new System.Drawing.Size(227, 316);
            this.Abilities.TabIndex = 67;
            this.Abilities.Tag = "1";
            this.Abilities.UseCompatibleTextRendering = true;
            // 
            // Equip
            // 
            this.Equip.BackColor = System.Drawing.Color.White;
            this.Equip.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Equip.Location = new System.Drawing.Point(294, 866);
            this.Equip.Name = "Equip";
            this.Equip.Size = new System.Drawing.Size(479, 142);
            this.Equip.TabIndex = 69;
            this.Equip.Tag = "1";
            this.Equip.UseCompatibleTextRendering = true;
            // 
            // Prof
            // 
            this.Prof.BackColor = System.Drawing.Color.White;
            this.Prof.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Prof.Location = new System.Drawing.Point(42, 864);
            this.Prof.Name = "Prof";
            this.Prof.Size = new System.Drawing.Size(228, 142);
            this.Prof.TabIndex = 70;
            this.Prof.Tag = "1";
            this.Prof.UseCompatibleTextRendering = true;
            // 
            // Personality
            // 
            this.Personality.BackColor = System.Drawing.Color.White;
            this.Personality.Font = new System.Drawing.Font("Book Antiqua", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Personality.Location = new System.Drawing.Point(561, 187);
            this.Personality.Name = "Personality";
            this.Personality.Size = new System.Drawing.Size(197, 68);
            this.Personality.TabIndex = 72;
            this.Personality.Tag = "1";
            this.Personality.UseCompatibleTextRendering = true;
            // 
            // Ideal
            // 
            this.Ideal.BackColor = System.Drawing.Color.White;
            this.Ideal.Font = new System.Drawing.Font("Book Antiqua", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Ideal.Location = new System.Drawing.Point(561, 278);
            this.Ideal.Name = "Ideal";
            this.Ideal.Size = new System.Drawing.Size(197, 49);
            this.Ideal.TabIndex = 73;
            this.Ideal.Tag = "1";
            this.Ideal.UseCompatibleTextRendering = true;
            // 
            // Bond
            // 
            this.Bond.BackColor = System.Drawing.Color.White;
            this.Bond.Font = new System.Drawing.Font("Book Antiqua", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Bond.Location = new System.Drawing.Point(561, 353);
            this.Bond.Name = "Bond";
            this.Bond.Size = new System.Drawing.Size(197, 49);
            this.Bond.TabIndex = 74;
            this.Bond.Tag = "1";
            this.Bond.UseCompatibleTextRendering = true;
            // 
            // Flaw
            // 
            this.Flaw.BackColor = System.Drawing.Color.White;
            this.Flaw.Font = new System.Drawing.Font("Book Antiqua", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Flaw.Location = new System.Drawing.Point(561, 425);
            this.Flaw.Name = "Flaw";
            this.Flaw.Size = new System.Drawing.Size(197, 49);
            this.Flaw.TabIndex = 75;
            this.Flaw.Tag = "1";
            this.Flaw.UseCompatibleTextRendering = true;
            // 
            // Weapons
            // 
            this.Weapons.BackColor = System.Drawing.Color.White;
            this.Weapons.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Weapons.Location = new System.Drawing.Point(294, 522);
            this.Weapons.Name = "Weapons";
            this.Weapons.Size = new System.Drawing.Size(228, 309);
            this.Weapons.TabIndex = 76;
            this.Weapons.Tag = "1";
            this.Weapons.UseCompatibleTextRendering = true;
            // 
            // PrintSheet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Dungeons_and_Dragons_Player_Maker.Properties.Resources.Character_Sheet___Alternative___Form_Fillable_page_001;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(814, 1055);
            this.Controls.Add(this.XP);
            this.Controls.Add(this.Weapons);
            this.Controls.Add(this.Flaw);
            this.Controls.Add(this.Bond);
            this.Controls.Add(this.Ideal);
            this.Controls.Add(this.Personality);
            this.Controls.Add(this.Prof);
            this.Controls.Add(this.Equip);
            this.Controls.Add(this.Abilities);
            this.Controls.Add(this.HP);
            this.Controls.Add(this.HitDie);
            this.Controls.Add(this.HD_Num);
            this.Controls.Add(this.Religion);
            this.Controls.Add(this.Nature);
            this.Controls.Add(this.Investigation);
            this.Controls.Add(this.History);
            this.Controls.Add(this.Arcana);
            this.Controls.Add(this.Int_Save);
            this.Controls.Add(this.Survival);
            this.Controls.Add(this.Perception);
            this.Controls.Add(this.Medicine);
            this.Controls.Add(this.Insight);
            this.Controls.Add(this.Animal);
            this.Controls.Add(this.Wis_Save);
            this.Controls.Add(this.Persuasion);
            this.Controls.Add(this.Performance);
            this.Controls.Add(this.Intimidation);
            this.Controls.Add(this.Deception);
            this.Controls.Add(this.Cha_Save);
            this.Controls.Add(this.Con_Save);
            this.Controls.Add(this.Stealth);
            this.Controls.Add(this.Sleight);
            this.Controls.Add(this.Acrobatics);
            this.Controls.Add(this.Dex_Save);
            this.Controls.Add(this.Athletics);
            this.Controls.Add(this.Str_Save);
            this.Controls.Add(this.Passive_Wis);
            this.Controls.Add(this.Cha_Mod);
            this.Controls.Add(this.Wis_Mod);
            this.Controls.Add(this.Int_Mod);
            this.Controls.Add(this.Con_Mod);
            this.Controls.Add(this.Dex_Mod);
            this.Controls.Add(this.STR_Mod);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.Initiative);
            this.Controls.Add(this.AC);
            this.Controls.Add(this.Proficency);
            this.Controls.Add(this.Race);
            this.Controls.Add(this.Background);
            this.Controls.Add(this.Player_Name);
            this.Controls.Add(this.Character_Name);
            this.Controls.Add(this.Alignment);
            this.Controls.Add(this.Class);
            this.Controls.Add(this.Strength);
            this.Controls.Add(this.Dextarity);
            this.Controls.Add(this.Constitution);
            this.Controls.Add(this.Intelligence);
            this.Controls.Add(this.Wisdom);
            this.Controls.Add(this.Charisma);
            this.Font = new System.Drawing.Font("Book Antiqua", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label Character_Name;
        private System.Windows.Forms.Label Player_Name;
        private System.Windows.Forms.Label XP;
        private System.Windows.Forms.Label Background;
        private System.Windows.Forms.Label Alignment;
        private System.Windows.Forms.Label Class;
        private System.Windows.Forms.Label Race;
        private System.Windows.Forms.Label Proficency;
        private System.Windows.Forms.Label AC;
        private System.Windows.Forms.Label Initiative;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.Label STR_Mod;
        private System.Windows.Forms.Label Dex_Mod;
        private System.Windows.Forms.Label Con_Mod;
        private System.Windows.Forms.Label Int_Mod;
        private System.Windows.Forms.Label Wis_Mod;
        private System.Windows.Forms.Label Cha_Mod;
        private System.Windows.Forms.Label Passive_Wis;
        private System.Windows.Forms.Label Strength;
        private System.Windows.Forms.Label Dextarity;
        private System.Windows.Forms.Label Constitution;
        private System.Windows.Forms.Label Intelligence;
        private System.Windows.Forms.Label Wisdom;
        private System.Windows.Forms.Label Charisma;
        private System.Windows.Forms.Label Str_Save;
        private System.Windows.Forms.Label Athletics;
        private System.Windows.Forms.Label Acrobatics;
        private System.Windows.Forms.Label Dex_Save;
        private System.Windows.Forms.Label Sleight;
        private System.Windows.Forms.Label Stealth;
        private System.Windows.Forms.Label Con_Save;
        private System.Windows.Forms.Label Performance;
        private System.Windows.Forms.Label Intimidation;
        private System.Windows.Forms.Label Deception;
        private System.Windows.Forms.Label Cha_Save;
        private System.Windows.Forms.Label Persuasion;
        private System.Windows.Forms.Label Perception;
        private System.Windows.Forms.Label Medicine;
        private System.Windows.Forms.Label Insight;
        private System.Windows.Forms.Label Animal;
        private System.Windows.Forms.Label Wis_Save;
        private System.Windows.Forms.Label Survival;
        private System.Windows.Forms.Label Religion;
        private System.Windows.Forms.Label Nature;
        private System.Windows.Forms.Label Investigation;
        private System.Windows.Forms.Label History;
        private System.Windows.Forms.Label Arcana;
        private System.Windows.Forms.Label Int_Save;
        private System.Windows.Forms.Label HD_Num;
        private System.Windows.Forms.Label HitDie;
        private System.Windows.Forms.Label HP;
        private System.Windows.Forms.Label Abilities;
        private System.Windows.Forms.Label Equip;
        private System.Windows.Forms.Label Prof;
        private System.Windows.Forms.Label Personality;
        private System.Windows.Forms.Label Ideal;
        private System.Windows.Forms.Label Bond;
        private System.Windows.Forms.Label Flaw;
        private System.Windows.Forms.Label Weapons;
    }
}

