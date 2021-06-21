
namespace Dungeons_and_Dragons_Player_Maker {
    partial class CreateCharacter {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.RaceSkill2 = new System.Windows.Forms.ComboBox();
            this.RaceSkill1 = new System.Windows.Forms.ComboBox();
            this.RaceLang = new System.Windows.Forms.ComboBox();
            this.SubRaces = new System.Windows.Forms.ComboBox();
            this.R6 = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.R5 = new System.Windows.Forms.Label();
            this.R4 = new System.Windows.Forms.Label();
            this.R3 = new System.Windows.Forms.Label();
            this.R2 = new System.Windows.Forms.Label();
            this.R1 = new System.Windows.Forms.Label();
            this.RacePreview = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RacePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(512, 585);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.RaceSkill2);
            this.tabPage1.Controls.Add(this.RaceSkill1);
            this.tabPage1.Controls.Add(this.RaceLang);
            this.tabPage1.Controls.Add(this.SubRaces);
            this.tabPage1.Controls.Add(this.R6);
            this.tabPage1.Controls.Add(this.Info);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.R5);
            this.tabPage1.Controls.Add(this.R4);
            this.tabPage1.Controls.Add(this.R3);
            this.tabPage1.Controls.Add(this.R2);
            this.tabPage1.Controls.Add(this.R1);
            this.tabPage1.Controls.Add(this.RacePreview);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(504, 552);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Races";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Additional Options:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RaceSkill2
            // 
            this.RaceSkill2.Enabled = false;
            this.RaceSkill2.FormattingEnabled = true;
            this.RaceSkill2.Location = new System.Drawing.Point(346, 518);
            this.RaceSkill2.Name = "RaceSkill2";
            this.RaceSkill2.Size = new System.Drawing.Size(151, 28);
            this.RaceSkill2.TabIndex = 13;
            this.RaceSkill2.Text = "Select One";
            this.RaceSkill2.SelectedIndexChanged += new System.EventHandler(this.RaceSkill2_SelectedIndexChanged);
            // 
            // RaceSkill1
            // 
            this.RaceSkill1.Enabled = false;
            this.RaceSkill1.FormattingEnabled = true;
            this.RaceSkill1.Location = new System.Drawing.Point(176, 518);
            this.RaceSkill1.Name = "RaceSkill1";
            this.RaceSkill1.Size = new System.Drawing.Size(151, 28);
            this.RaceSkill1.TabIndex = 12;
            this.RaceSkill1.Text = "Select One";
            this.RaceSkill1.SelectedIndexChanged += new System.EventHandler(this.RaceSkill1_SelectedIndexChanged);
            // 
            // RaceLang
            // 
            this.RaceLang.Enabled = false;
            this.RaceLang.FormattingEnabled = true;
            this.RaceLang.Location = new System.Drawing.Point(6, 518);
            this.RaceLang.Name = "RaceLang";
            this.RaceLang.Size = new System.Drawing.Size(151, 28);
            this.RaceLang.TabIndex = 11;
            this.RaceLang.Text = "Select One";
            this.RaceLang.SelectedIndexChanged += new System.EventHandler(this.RaceLang_SelectedIndexChanged);
            // 
            // SubRaces
            // 
            this.SubRaces.Enabled = false;
            this.SubRaces.FormattingEnabled = true;
            this.SubRaces.Location = new System.Drawing.Point(6, 294);
            this.SubRaces.Name = "SubRaces";
            this.SubRaces.Size = new System.Drawing.Size(208, 28);
            this.SubRaces.TabIndex = 10;
            this.SubRaces.Text = "Natural";
            this.SubRaces.SelectedValueChanged += new System.EventHandler(this.SubRaces_SelectedValueChanged);
            // 
            // R6
            // 
            this.R6.Location = new System.Drawing.Point(6, 231);
            this.R6.Name = "R6";
            this.R6.Size = new System.Drawing.Size(211, 25);
            this.R6.TabIndex = 9;
            this.R6.Text = "Gnome";
            this.R6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.R6.Click += new System.EventHandler(this.Race_Click);
            this.R6.MouseEnter += new System.EventHandler(this.Race_Hover);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Info.Location = new System.Drawing.Point(6, 338);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(492, 158);
            this.Info.TabIndex = 8;
            this.Info.Text = "STR: +1 DEX: +1 CON: +1 WIS: +1 INT: +1 CHA: +1\r\nSize: Medium\r\nSpeed: 30\r\nLanguag" +
    "es: Common, Elvish\r\nProficiencies: None \r\nNotes: None";
            this.Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 259);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "DOWN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "UP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // R5
            // 
            this.R5.Location = new System.Drawing.Point(6, 194);
            this.R5.Name = "R5";
            this.R5.Size = new System.Drawing.Size(211, 25);
            this.R5.TabIndex = 5;
            this.R5.Text = "Dragonborn";
            this.R5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.R5.Click += new System.EventHandler(this.Race_Click);
            this.R5.MouseEnter += new System.EventHandler(this.Race_Hover);
            // 
            // R4
            // 
            this.R4.Location = new System.Drawing.Point(6, 157);
            this.R4.Name = "R4";
            this.R4.Size = new System.Drawing.Size(211, 25);
            this.R4.TabIndex = 4;
            this.R4.Text = "Human";
            this.R4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.R4.Click += new System.EventHandler(this.Race_Click);
            this.R4.MouseEnter += new System.EventHandler(this.Race_Hover);
            // 
            // R3
            // 
            this.R3.Location = new System.Drawing.Point(6, 120);
            this.R3.Name = "R3";
            this.R3.Size = new System.Drawing.Size(211, 25);
            this.R3.TabIndex = 3;
            this.R3.Text = "Halfling";
            this.R3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.R3.Click += new System.EventHandler(this.Race_Click);
            this.R3.MouseEnter += new System.EventHandler(this.Race_Hover);
            // 
            // R2
            // 
            this.R2.Location = new System.Drawing.Point(6, 83);
            this.R2.Name = "R2";
            this.R2.Size = new System.Drawing.Size(211, 25);
            this.R2.TabIndex = 2;
            this.R2.Text = "Elf";
            this.R2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.R2.Click += new System.EventHandler(this.Race_Click);
            this.R2.MouseEnter += new System.EventHandler(this.Race_Hover);
            // 
            // R1
            // 
            this.R1.Location = new System.Drawing.Point(6, 46);
            this.R1.Name = "R1";
            this.R1.Size = new System.Drawing.Size(211, 25);
            this.R1.TabIndex = 1;
            this.R1.Text = "Dwarf";
            this.R1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.R1.Click += new System.EventHandler(this.Race_Click);
            this.R1.MouseEnter += new System.EventHandler(this.Race_Hover);
            // 
            // RacePreview
            // 
            this.RacePreview.Image = global::Dungeons_and_Dragons_Player_Maker.Races.Half_Elf;
            this.RacePreview.Location = new System.Drawing.Point(223, 6);
            this.RacePreview.Name = "RacePreview";
            this.RacePreview.Size = new System.Drawing.Size(275, 329);
            this.RacePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RacePreview.TabIndex = 0;
            this.RacePreview.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(504, 552);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Classes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(504, 552);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Background";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(504, 552);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Confirm";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // CreateCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 609);
            this.Controls.Add(this.tabControl1);
            this.Name = "CreateCharacter";
            this.Text = "CreateCharacter";
            this.Load += new System.EventHandler(this.CreateCharacter_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RacePreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox RacePreview;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label R5;
        private System.Windows.Forms.Label R4;
        private System.Windows.Forms.Label R3;
        private System.Windows.Forms.Label R2;
        private System.Windows.Forms.Label R1;
        private System.Windows.Forms.Label R6;
        private System.Windows.Forms.ComboBox SubRaces;
        private System.Windows.Forms.ComboBox RaceSkill2;
        private System.Windows.Forms.ComboBox RaceSkill1;
        private System.Windows.Forms.ComboBox RaceLang;
        private System.Windows.Forms.Label label1;
    }
}