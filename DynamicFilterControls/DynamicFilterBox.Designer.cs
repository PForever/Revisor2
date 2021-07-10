﻿namespace DynamicFilterControls
{
    partial class DynamicFilterBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btBack = new System.Windows.Forms.Button();
            this.btHome = new System.Windows.Forms.Button();
            this.lbPath = new System.Windows.Forms.Label();
            this.dgvFilters = new System.Windows.Forms.DataGridView();
            this.tbDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPropertyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFilters = new System.Windows.Forms.BindingSource(this.components);
            this.tvOperands = new System.Windows.Forms.TreeView();
            this.btBuild = new System.Windows.Forms.Button();
            this.tbPrint = new System.Windows.Forms.TextBox();
            this.cmsNodeEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmsFilterEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.проверкаНаличияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFilters)).BeginInit();
            this.cmsNodeEdit.SuspendLayout();
            this.cmsFilterEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btBuild);
            this.splitContainer1.Panel2.Controls.Add(this.tbPrint);
            this.splitContainer1.Size = new System.Drawing.Size(863, 414);
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tvOperands);
            this.splitContainer2.Size = new System.Drawing.Size(863, 377);
            this.splitContainer2.SplitterDistance = 454;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btBack);
            this.splitContainer3.Panel1.Controls.Add(this.btHome);
            this.splitContainer3.Panel1.Controls.Add(this.lbPath);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvFilters);
            this.splitContainer3.Size = new System.Drawing.Size(454, 377);
            this.splitContainer3.SplitterDistance = 37;
            this.splitContainer3.SplitterWidth = 6;
            this.splitContainer3.TabIndex = 1;
            // 
            // btBack
            // 
            this.btBack.Enabled = false;
            this.btBack.Location = new System.Drawing.Point(36, 0);
            this.btBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(37, 34);
            this.btBack.TabIndex = 2;
            this.btBack.Text = "<";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.OnBack);
            // 
            // btHome
            // 
            this.btHome.Enabled = false;
            this.btHome.Location = new System.Drawing.Point(0, 0);
            this.btHome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btHome.Name = "btHome";
            this.btHome.Size = new System.Drawing.Size(37, 34);
            this.btHome.TabIndex = 1;
            this.btHome.Text = "<<";
            this.btHome.UseVisualStyleBackColor = true;
            this.btHome.Click += new System.EventHandler(this.OnHome);
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(81, 8);
            this.lbPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(39, 20);
            this.lbPath.TabIndex = 0;
            this.lbPath.Text = "path";
            // 
            // dgvFilters
            // 
            this.dgvFilters.AllowUserToAddRows = false;
            this.dgvFilters.AllowUserToDeleteRows = false;
            this.dgvFilters.AutoGenerateColumns = false;
            this.dgvFilters.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tbDisplayName,
            this.tbPropertyType});
            this.dgvFilters.DataSource = this.bsFilters;
            this.dgvFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFilters.Location = new System.Drawing.Point(0, 0);
            this.dgvFilters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvFilters.MultiSelect = false;
            this.dgvFilters.Name = "dgvFilters";
            this.dgvFilters.ReadOnly = true;
            this.dgvFilters.RowHeadersWidth = 51;
            this.dgvFilters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFilters.Size = new System.Drawing.Size(454, 334);
            this.dgvFilters.TabIndex = 0;
            this.dgvFilters.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnDoubleClick);
            this.dgvFilters.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnCellFormatting);
            this.dgvFilters.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellMouseUp);
            this.dgvFilters.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.OnFilterRowsAdded);
            // 
            // tbDisplayName
            // 
            this.tbDisplayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tbDisplayName.DataPropertyName = "DisplayName";
            this.tbDisplayName.HeaderText = "Имя";
            this.tbDisplayName.MinimumWidth = 6;
            this.tbDisplayName.Name = "tbDisplayName";
            this.tbDisplayName.ReadOnly = true;
            // 
            // tbPropertyType
            // 
            this.tbPropertyType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tbPropertyType.DataPropertyName = "PropertyType";
            this.tbPropertyType.HeaderText = "Тип";
            this.tbPropertyType.MinimumWidth = 6;
            this.tbPropertyType.Name = "tbPropertyType";
            this.tbPropertyType.ReadOnly = true;
            // 
            // bsFilters
            // 
            this.bsFilters.DataSource = typeof(DynamicFilter.Abstract.Filters.IFilterData);
            // 
            // tvOperands
            // 
            this.tvOperands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOperands.FullRowSelect = true;
            this.tvOperands.Location = new System.Drawing.Point(0, 0);
            this.tvOperands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tvOperands.Name = "tvOperands";
            this.tvOperands.Size = new System.Drawing.Size(404, 377);
            this.tvOperands.TabIndex = 0;
            this.tvOperands.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnNodeClicked);
            this.tvOperands.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnNodeDoubleClicked);
            this.tvOperands.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnOperandsKeyUp);
            // 
            // btBuild
            // 
            this.btBuild.Dock = System.Windows.Forms.DockStyle.Right;
            this.btBuild.Location = new System.Drawing.Point(738, 0);
            this.btBuild.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btBuild.Name = "btBuild";
            this.btBuild.Size = new System.Drawing.Size(125, 31);
            this.btBuild.TabIndex = 3;
            this.btBuild.Text = "Построить";
            this.btBuild.UseVisualStyleBackColor = true;
            this.btBuild.Click += new System.EventHandler(this.OnBuilt);
            // 
            // tbPrint
            // 
            this.tbPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPrint.Location = new System.Drawing.Point(4, -68);
            this.tbPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.ReadOnly = true;
            this.tbPrint.Size = new System.Drawing.Size(731, 27);
            this.tbPrint.TabIndex = 2;
            // 
            // cmsNodeEdit
            // 
            this.cmsNodeEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsNodeEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInvert,
            this.tsmiEdit,
            this.tsmiDelete});
            this.cmsNodeEdit.Name = "cmsNodeEdit";
            this.cmsNodeEdit.ShowImageMargin = false;
            this.cmsNodeEdit.Size = new System.Drawing.Size(156, 76);
            // 
            // tsmiInvert
            // 
            this.tsmiInvert.Name = "tsmiInvert";
            this.tsmiInvert.Size = new System.Drawing.Size(155, 24);
            this.tsmiInvert.Text = "Инверсия";
            this.tsmiInvert.Click += new System.EventHandler(this.OnInvertClick);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(155, 24);
            this.tsmiEdit.Text = "Редактировать";
            this.tsmiEdit.Click += new System.EventHandler(this.OnUpdateOperand);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(155, 24);
            this.tsmiDelete.Text = "Удалить";
            this.tsmiDelete.Click += new System.EventHandler(this.OnDeleteOperand);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 0;
            // 
            // cmsFilterEdit
            // 
            this.cmsFilterEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsFilterEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проверкаНаличияToolStripMenuItem});
            this.cmsFilterEdit.Name = "cmsNodeEdit";
            this.cmsFilterEdit.ShowImageMargin = false;
            this.cmsFilterEdit.Size = new System.Drawing.Size(186, 28);
            this.cmsFilterEdit.Opened += new System.EventHandler(this.OnOpenedFilterEdit);
            // 
            // проверкаНаличияToolStripMenuItem
            // 
            this.проверкаНаличияToolStripMenuItem.Name = "проверкаНаличияToolStripMenuItem";
            this.проверкаНаличияToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.проверкаНаличияToolStripMenuItem.Text = "Проверка наличия";
            this.проверкаНаличияToolStripMenuItem.Click += new System.EventHandler(this.OnCheck);
            // 
            // DynamicFilterBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DynamicFilterBox";
            this.Size = new System.Drawing.Size(863, 414);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFilters)).EndInit();
            this.cmsNodeEdit.ResumeLayout(false);
            this.cmsFilterEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvFilters;
        private System.Windows.Forms.BindingSource bsFilters;
        private System.Windows.Forms.TreeView tvOperands;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btHome;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbPropertyType;
        private System.Windows.Forms.Button btBuild;
        private System.Windows.Forms.TextBox tbPrint;
        private System.Windows.Forms.TreeNode tnEmpty;
        private System.Windows.Forms.ContextMenuStrip cmsNodeEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiInvert;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip cmsFilterEdit;
        private System.Windows.Forms.ToolStripMenuItem проверкаНаличияToolStripMenuItem;
    }
}
