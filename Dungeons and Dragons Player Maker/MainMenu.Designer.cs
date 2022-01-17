
namespace Dungeons_and_Dragons_Player_Maker {
    partial class MainMenu {
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
        [System.Obsolete]
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.NewCharacter = new System.Windows.Forms.Button();
            this.PrintOldCharacter = new System.Windows.Forms.Button();
            this.CharactersCreated = new System.Windows.Forms.ComboBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.LoadCharacter = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Settings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NewCharacter
            // 
            this.NewCharacter.Location = new System.Drawing.Point(12, 65);
            this.NewCharacter.Name = "NewCharacter";
            this.NewCharacter.Size = new System.Drawing.Size(151, 29);
            this.NewCharacter.TabIndex = 0;
            this.NewCharacter.Text = "New Character";
            this.NewCharacter.UseVisualStyleBackColor = true;
            this.NewCharacter.Click += new System.EventHandler(this.NewCharacter_Click);
            // 
            // PrintOldCharacter
            // 
            this.PrintOldCharacter.Enabled = false;
            this.PrintOldCharacter.Location = new System.Drawing.Point(12, 135);
            this.PrintOldCharacter.Name = "PrintOldCharacter";
            this.PrintOldCharacter.Size = new System.Drawing.Size(151, 29);
            this.PrintOldCharacter.TabIndex = 1;
            this.PrintOldCharacter.Text = "Print Old Character";
            this.PrintOldCharacter.UseVisualStyleBackColor = true;
            this.PrintOldCharacter.Click += new System.EventHandler(this.PrintOldCharacter_Click);
            // 
            // CharactersCreated
            // 
            this.CharactersCreated.Enabled = false;
            this.CharactersCreated.FormattingEnabled = true;
            this.CharactersCreated.Location = new System.Drawing.Point(12, 170);
            this.CharactersCreated.Name = "CharactersCreated";
            this.CharactersCreated.Size = new System.Drawing.Size(151, 28);
            this.CharactersCreated.TabIndex = 2;
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(12, 278);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(151, 27);
            this.UserName.TabIndex = 3;
            this.UserName.Visible = false;
            this.UserName.TextChanged += new System.EventHandler(this.UserName_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(12, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Creator Name";
            this.label1.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "\"Character Files\"|*.hro";
            this.openFileDialog1.InitialDirectory = "Desktop";
            this.openFileDialog1.Title = "Load Character";
            // 
            // LoadCharacter
            // 
            this.LoadCharacter.Location = new System.Drawing.Point(12, 100);
            this.LoadCharacter.Name = "LoadCharacter";
            this.LoadCharacter.Size = new System.Drawing.Size(151, 29);
            this.LoadCharacter.TabIndex = 5;
            this.LoadCharacter.Text = "Load Character";
            this.LoadCharacter.UseVisualStyleBackColor = true;
            this.LoadCharacter.Click += new System.EventHandler(this.LoadCharacter_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 62);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(12, 246);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(151, 29);
            this.Settings.TabIndex = 7;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoadCharacter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.CharactersCreated);
            this.Controls.Add(this.PrintOldCharacter);
            this.Controls.Add(this.NewCharacter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.VisibleChanged += new System.EventHandler(this.MainMenu_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewCharacter;
        private System.Windows.Forms.Button PrintOldCharacter;
        private System.Windows.Forms.ComboBox CharactersCreated;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button LoadCharacter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Settings;
    }
}