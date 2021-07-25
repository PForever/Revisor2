
namespace WinFormsView.Lists
{
    partial class Peoples
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Peoples));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btFilter = new System.Windows.Forms.ToolStripSplitButton();
            this.btFilterClear = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.btRemove = new System.Windows.Forms.Button();
            this.btChange = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.bsPeople = new System.Windows.Forms.BindingSource(this.components);
            this.bsAddresses = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAddresses)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.dgvPeople);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btRemove);
            this.splitContainer1.Panel2.Controls.Add(this.btChange);
            this.splitContainer1.Panel2.Controls.Add(this.btAdd);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(800, 451);
            this.splitContainer1.SplitterDistance = 403;
            this.splitContainer1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btFilter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 376);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btFilter
            // 
            this.btFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btFilterClear});
            this.btFilter.Image = ((System.Drawing.Image)(resources.GetObject("btFilter.Image")));
            this.btFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(79, 24);
            this.btFilter.Text = "Фильтр";
            this.btFilter.ToolTipText = "Фильтр";
            this.btFilter.ButtonClick += new System.EventHandler(this.OnFilter);
            // 
            // btFilterClear
            // 
            this.btFilterClear.Name = "btFilterClear";
            this.btFilterClear.Size = new System.Drawing.Size(156, 26);
            this.btFilterClear.Text = "Очистить";
            this.btFilterClear.Click += new System.EventHandler(this.OnClear);
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPeople.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ContextMenuStrip = this.contextMenu;
            this.dgvPeople.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvPeople.GridColor = System.Drawing.SystemColors.HotTrack;
            this.dgvPeople.Location = new System.Drawing.Point(0, 0);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersWidth = 51;
            this.dgvPeople.Size = new System.Drawing.Size(800, 378);
            this.dgvPeople.TabIndex = 0;
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiPrint});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(128, 28);
            // 
            // smiPrint
            // 
            this.smiPrint.Name = "smiPrint";
            this.smiPrint.Size = new System.Drawing.Size(127, 24);
            this.smiPrint.Text = "Печать";
            this.smiPrint.Click += new System.EventHandler(this.OnPrint);
            // 
            // btRemove
            // 
            this.btRemove.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRemove.Location = new System.Drawing.Point(5, 5);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(94, 34);
            this.btRemove.TabIndex = 2;
            this.btRemove.Text = "Удалить";
            this.btRemove.UseVisualStyleBackColor = true;
            // 
            // btChange
            // 
            this.btChange.Dock = System.Windows.Forms.DockStyle.Right;
            this.btChange.Location = new System.Drawing.Point(607, 5);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(94, 34);
            this.btChange.TabIndex = 1;
            this.btChange.Text = "Изменить";
            this.btChange.UseVisualStyleBackColor = true;
            this.btChange.Click += new System.EventHandler(this.OnEdit);
            // 
            // btAdd
            // 
            this.btAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btAdd.Location = new System.Drawing.Point(701, 5);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(94, 34);
            this.btAdd.TabIndex = 0;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.OnAdd);
            // 
            // Peoples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Peoples";
            this.Text = "Peoples";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAddresses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.BindingSource bsPeople;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton btFilter;
        private System.Windows.Forms.ToolStripMenuItem btFilterClear;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem smiPrint;
        private System.Windows.Forms.BindingSource bsAddresses;
    }
}