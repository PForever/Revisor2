
namespace WinFormsView
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.smiLists = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.smiBypasses = new System.Windows.Forms.ToolStripMenuItem();
            this.smiBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.smiAddresses = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiLists,
            this.smiBooks});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // smiLists
            // 
            this.smiLists.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiPeople,
            this.smiBypasses});
            this.smiLists.Name = "smiLists";
            this.smiLists.Size = new System.Drawing.Size(73, 24);
            this.smiLists.Text = "&Списки";
            // 
            // smiPeople
            // 
            this.smiPeople.Name = "smiPeople";
            this.smiPeople.Size = new System.Drawing.Size(147, 26);
            this.smiPeople.Text = "&Люди";
            this.smiPeople.Click += new System.EventHandler(this.OnPeople);
            // 
            // smiBypasses
            // 
            this.smiBypasses.Name = "smiBypasses";
            this.smiBypasses.Size = new System.Drawing.Size(147, 26);
            this.smiBypasses.Text = "&Обходы";
            // 
            // smiBooks
            // 
            this.smiBooks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiAddresses});
            this.smiBooks.Name = "smiBooks";
            this.smiBooks.Size = new System.Drawing.Size(117, 24);
            this.smiBooks.Text = "С&правочники";
            // 
            // smiAddresses
            // 
            this.smiAddresses.Name = "smiAddresses";
            this.smiAddresses.Size = new System.Drawing.Size(224, 26);
            this.smiAddresses.Text = "&Адреса";
            this.smiAddresses.Click += new System.EventHandler(this.OnAddresses);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem smiLists;
        private System.Windows.Forms.ToolStripMenuItem smiPeople;
        private System.Windows.Forms.ToolStripMenuItem smiBypasses;
        private System.Windows.Forms.ToolStripMenuItem smiBooks;
        private System.Windows.Forms.ToolStripMenuItem smiAddresses;
    }
}