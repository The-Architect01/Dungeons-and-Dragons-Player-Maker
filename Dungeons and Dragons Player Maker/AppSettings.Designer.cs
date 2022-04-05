
namespace Dungeons_and_Dragons_Player_Maker {
    partial class AppSettings {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HBW = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PHB = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Revert = new System.Windows.Forms.Button();
            this.Hbws = new System.Windows.Forms.Button();
            this.hbwe = new System.Windows.Forms.Button();
            this.hbwi = new System.Windows.Forms.Button();
            this.FileInput = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HBW);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PHB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 326);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Books";
            // 
            // HBW
            // 
            this.HBW.Location = new System.Drawing.Point(6, 62);
            this.HBW.Name = "HBW";
            this.HBW.Size = new System.Drawing.Size(238, 30);
            this.HBW.TabIndex = 6;
            this.HBW.Text = "Homebrew";
            this.HBW.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 173);
            this.label2.TabIndex = 5;
            this.label2.Text = "More Coming Soon!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PHB
            // 
            this.PHB.Checked = true;
            this.PHB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PHB.Enabled = false;
            this.PHB.Location = new System.Drawing.Point(6, 26);
            this.PHB.Name = "PHB";
            this.PHB.Size = new System.Drawing.Size(238, 30);
            this.PHB.TabIndex = 5;
            this.PHB.Text = "Player\'s Handbook";
            this.PHB.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(268, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 27);
            this.textBox1.TabIndex = 1;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(331, 97);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(94, 29);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(268, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Creator Name";
            // 
            // Revert
            // 
            this.Revert.Location = new System.Drawing.Point(331, 132);
            this.Revert.Name = "Revert";
            this.Revert.Size = new System.Drawing.Size(94, 29);
            this.Revert.TabIndex = 4;
            this.Revert.Text = "Revert";
            this.Revert.UseVisualStyleBackColor = true;
            this.Revert.Click += new System.EventHandler(this.Revert_Click);
            // 
            // Hbws
            // 
            this.Hbws.Location = new System.Drawing.Point(331, 167);
            this.Hbws.Name = "Hbws";
            this.Hbws.Size = new System.Drawing.Size(94, 64);
            this.Hbws.TabIndex = 5;
            this.Hbws.Text = "Create Homebrew";
            this.Hbws.UseVisualStyleBackColor = true;
            this.Hbws.Click += new System.EventHandler(this.button1_Click);
            // 
            // hbwe
            // 
            this.hbwe.Location = new System.Drawing.Point(383, 262);
            this.hbwe.Name = "hbwe";
            this.hbwe.Size = new System.Drawing.Size(94, 60);
            this.hbwe.TabIndex = 6;
            this.hbwe.Text = "Export Homebrew";
            this.hbwe.UseVisualStyleBackColor = true;
            this.hbwe.Click += new System.EventHandler(this.hbwe_Click);
            // 
            // hbwi
            // 
            this.hbwi.Location = new System.Drawing.Point(283, 262);
            this.hbwi.Name = "hbwi";
            this.hbwi.Size = new System.Drawing.Size(94, 60);
            this.hbwi.TabIndex = 7;
            this.hbwi.Text = "Import Homebrew";
            this.hbwi.UseVisualStyleBackColor = true;
            this.hbwi.Click += new System.EventHandler(this.hbwi_Click);
            // 
            // FileInput
            // 
            this.FileInput.Filter = "\"Homebrew Files\"|*.brew";
            // 
            // AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.hbwi);
            this.Controls.Add(this.hbwe);
            this.Controls.Add(this.Hbws);
            this.Controls.Add(this.Revert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppSettings_FormClosing);
            this.Load += new System.EventHandler(this.AppSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Revert;
        private System.Windows.Forms.CheckBox PHB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Hbws;
        private System.Windows.Forms.CheckBox HBW;
        private System.Windows.Forms.Button hbwe;
        private System.Windows.Forms.Button hbwi;
        private System.Windows.Forms.OpenFileDialog FileInput;
    }
}