
namespace WinFormsView.Lists
{
    partial class Template
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
            this.sbBypassed = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvByPassed = new System.Windows.Forms.DataGridView();
            this.btRemove = new System.Windows.Forms.Button();
            this.btChange = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sbBypassed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByPassed)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvByPassed);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btRemove);
            this.splitContainer1.Panel2.Controls.Add(this.btChange);
            this.splitContainer1.Panel2.Controls.Add(this.btAdd);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 401;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvByPassed
            // 
            this.dgvByPassed.AllowUserToAddRows = false;
            this.dgvByPassed.AllowUserToDeleteRows = false;
            this.dgvByPassed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvByPassed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvByPassed.Location = new System.Drawing.Point(0, 0);
            this.dgvByPassed.Name = "dgvByPassed";
            this.dgvByPassed.ReadOnly = true;
            this.dgvByPassed.RowHeadersWidth = 51;
            this.dgvByPassed.Size = new System.Drawing.Size(800, 401);
            this.dgvByPassed.TabIndex = 0;
            // 
            // btRemove
            // 
            this.btRemove.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRemove.Location = new System.Drawing.Point(5, 5);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(94, 35);
            this.btRemove.TabIndex = 2;
            this.btRemove.Text = "Удалить";
            this.btRemove.UseVisualStyleBackColor = true;
            // 
            // btChange
            // 
            this.btChange.Dock = System.Windows.Forms.DockStyle.Right;
            this.btChange.Location = new System.Drawing.Point(607, 5);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(94, 35);
            this.btChange.TabIndex = 1;
            this.btChange.Text = "Изменить";
            this.btChange.UseVisualStyleBackColor = true;
            // 
            // btAdd
            // 
            this.btAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btAdd.Location = new System.Drawing.Point(701, 5);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(94, 35);
            this.btAdd.TabIndex = 0;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = true;
            // 
            // Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Template";
            this.Text = "Template";
            ((System.ComponentModel.ISupportInitialize)(this.sbBypassed)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvByPassed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource sbBypassed;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvByPassed;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.Button btAdd;
    }
}