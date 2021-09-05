
namespace Dungeons_and_Dragons_Player_Maker {
    partial class SpellSheet {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && ( components != null )) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpellSheet));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SpellCastAbility = new System.Windows.Forms.Label();
            this.SaveDC = new System.Windows.Forms.Label();
            this.AtkBonus = new System.Windows.Forms.Label();
            this.ClassName = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // SpellCastAbility
            // 
            this.SpellCastAbility.BackColor = System.Drawing.Color.Transparent;
            this.SpellCastAbility.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SpellCastAbility.Location = new System.Drawing.Point(382, 74);
            this.SpellCastAbility.Name = "SpellCastAbility";
            this.SpellCastAbility.Size = new System.Drawing.Size(78, 34);
            this.SpellCastAbility.TabIndex = 1;
            this.SpellCastAbility.Text = "CHA";
            this.SpellCastAbility.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveDC
            // 
            this.SaveDC.BackColor = System.Drawing.Color.Transparent;
            this.SaveDC.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveDC.Location = new System.Drawing.Point(517, 74);
            this.SaveDC.Name = "SaveDC";
            this.SaveDC.Size = new System.Drawing.Size(78, 34);
            this.SaveDC.TabIndex = 2;
            this.SaveDC.Text = "13";
            this.SaveDC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AtkBonus
            // 
            this.AtkBonus.BackColor = System.Drawing.Color.Transparent;
            this.AtkBonus.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AtkBonus.Location = new System.Drawing.Point(652, 74);
            this.AtkBonus.Name = "AtkBonus";
            this.AtkBonus.Size = new System.Drawing.Size(78, 34);
            this.AtkBonus.TabIndex = 3;
            this.AtkBonus.Text = "+ 4";
            this.AtkBonus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClassName
            // 
            this.ClassName.BackColor = System.Drawing.Color.Transparent;
            this.ClassName.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ClassName.Location = new System.Drawing.Point(55, 77);
            this.ClassName.Name = "ClassName";
            this.ClassName.Size = new System.Drawing.Size(285, 43);
            this.ClassName.TabIndex = 4;
            this.ClassName.Tag = "0";
            this.ClassName.Text = "Sample Character";
            this.ClassName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClassName.UseCompatibleTextRendering = true;
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
            // SpellSheet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Dungeons_and_Dragons_Player_Maker.Classes.Spell_Sheet;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(814, 1055);
            this.Controls.Add(this.ClassName);
            this.Controls.Add(this.AtkBonus);
            this.Controls.Add(this.SaveDC);
            this.Controls.Add(this.SpellCastAbility);
            this.Name = "SpellSheet";
            this.Text = "SpellSheet";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label SpellCastAbility;
        private System.Windows.Forms.Label SaveDC;
        private System.Windows.Forms.Label AtkBonus;
        private System.Windows.Forms.Label ClassName;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}