
namespace WinFormsView.Cards
{
    partial class BypassCard
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
            this.dgvRepeated = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.chbIsComplited = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtMonth = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btAddAddres = new System.Windows.Forms.Button();
            this.cbAddress = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btRemoveContribution = new System.Windows.Forms.Button();
            this.btChangeContribution = new System.Windows.Forms.Button();
            this.btAddContribution = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvPersonTime = new System.Windows.Forms.DataGridView();
            this.btRemovePersonTime = new System.Windows.Forms.Button();
            this.btChangePersonTime = new System.Windows.Forms.Button();
            this.btAddPersonTime = new System.Windows.Forms.Button();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.btSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sbBypassed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepeated)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRepeated
            // 
            this.dgvRepeated.AllowUserToAddRows = false;
            this.dgvRepeated.AllowUserToDeleteRows = false;
            this.dgvRepeated.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvRepeated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepeated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRepeated.Location = new System.Drawing.Point(0, 0);
            this.dgvRepeated.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRepeated.Name = "dgvRepeated";
            this.dgvRepeated.ReadOnly = true;
            this.dgvRepeated.RowHeadersWidth = 51;
            this.dgvRepeated.Size = new System.Drawing.Size(686, 216);
            this.dgvRepeated.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 297);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.chbIsComplited);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 269);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Общее";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbDescription);
            this.groupBox4.Location = new System.Drawing.Point(8, 142);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(676, 121);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Комментарий";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(9, 22);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(661, 93);
            this.tbDescription.TabIndex = 0;
            // 
            // chbIsComplited
            // 
            this.chbIsComplited.AutoSize = true;
            this.chbIsComplited.Location = new System.Drawing.Point(14, 117);
            this.chbIsComplited.Name = "chbIsComplited";
            this.chbIsComplited.Size = new System.Drawing.Size(82, 19);
            this.chbIsComplited.TabIndex = 0;
            this.chbIsComplited.Text = "Завершён";
            this.chbIsComplited.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpStart);
            this.groupBox3.Location = new System.Drawing.Point(188, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 51);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Дата";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(6, 19);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 23);
            this.dtpStart.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtMonth);
            this.groupBox2.Location = new System.Drawing.Point(11, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 51);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Месячник";
            // 
            // dtMonth
            // 
            this.dtMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtMonth.FormattingEnabled = true;
            this.dtMonth.Location = new System.Drawing.Point(3, 19);
            this.dtMonth.Name = "dtMonth";
            this.dtMonth.Size = new System.Drawing.Size(165, 23);
            this.dtMonth.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btAddAddres);
            this.groupBox1.Controls.Add(this.cbAddress);
            this.groupBox1.Location = new System.Drawing.Point(11, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 51);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Адрес";
            // 
            // btAddAddres
            // 
            this.btAddAddres.Location = new System.Drawing.Point(530, 21);
            this.btAddAddres.Name = "btAddAddres";
            this.btAddAddres.Size = new System.Drawing.Size(137, 24);
            this.btAddAddres.TabIndex = 1;
            this.btAddAddres.Text = "Добавить";
            this.btAddAddres.UseVisualStyleBackColor = true;
            // 
            // cbAddress
            // 
            this.cbAddress.FormattingEnabled = true;
            this.cbAddress.Location = new System.Drawing.Point(6, 22);
            this.cbAddress.Name = "cbAddress";
            this.cbAddress.Size = new System.Drawing.Size(518, 23);
            this.cbAddress.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 269);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Результат";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvRepeated);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btRemoveContribution);
            this.splitContainer1.Panel2.Controls.Add(this.btChangeContribution);
            this.splitContainer1.Panel2.Controls.Add(this.btAddContribution);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Size = new System.Drawing.Size(686, 263);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 2;
            // 
            // btRemoveContribution
            // 
            this.btRemoveContribution.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRemoveContribution.Location = new System.Drawing.Point(4, 4);
            this.btRemoveContribution.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRemoveContribution.Name = "btRemoveContribution";
            this.btRemoveContribution.Size = new System.Drawing.Size(82, 36);
            this.btRemoveContribution.TabIndex = 2;
            this.btRemoveContribution.Text = "Удалить";
            this.btRemoveContribution.UseVisualStyleBackColor = true;
            // 
            // btChangeContribution
            // 
            this.btChangeContribution.Dock = System.Windows.Forms.DockStyle.Right;
            this.btChangeContribution.Location = new System.Drawing.Point(518, 4);
            this.btChangeContribution.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btChangeContribution.Name = "btChangeContribution";
            this.btChangeContribution.Size = new System.Drawing.Size(82, 36);
            this.btChangeContribution.TabIndex = 1;
            this.btChangeContribution.Text = "Изменить";
            this.btChangeContribution.UseVisualStyleBackColor = true;
            // 
            // btAddContribution
            // 
            this.btAddContribution.Dock = System.Windows.Forms.DockStyle.Right;
            this.btAddContribution.Location = new System.Drawing.Point(600, 4);
            this.btAddContribution.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAddContribution.Name = "btAddContribution";
            this.btAddContribution.Size = new System.Drawing.Size(82, 36);
            this.btAddContribution.TabIndex = 0;
            this.btAddContribution.Text = "Добавить";
            this.btAddContribution.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.splitContainer3);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(692, 269);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Время";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvPersonTime);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btRemovePersonTime);
            this.splitContainer3.Panel2.Controls.Add(this.btChangePersonTime);
            this.splitContainer3.Panel2.Controls.Add(this.btAddPersonTime);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainer3.Size = new System.Drawing.Size(686, 263);
            this.splitContainer3.SplitterDistance = 218;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 4;
            // 
            // dgvPersonTime
            // 
            this.dgvPersonTime.AllowUserToAddRows = false;
            this.dgvPersonTime.AllowUserToDeleteRows = false;
            this.dgvPersonTime.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPersonTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonTime.Location = new System.Drawing.Point(0, 0);
            this.dgvPersonTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPersonTime.Name = "dgvPersonTime";
            this.dgvPersonTime.ReadOnly = true;
            this.dgvPersonTime.RowHeadersWidth = 51;
            this.dgvPersonTime.Size = new System.Drawing.Size(686, 218);
            this.dgvPersonTime.TabIndex = 0;
            // 
            // btRemovePersonTime
            // 
            this.btRemovePersonTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRemovePersonTime.Location = new System.Drawing.Point(4, 4);
            this.btRemovePersonTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRemovePersonTime.Name = "btRemovePersonTime";
            this.btRemovePersonTime.Size = new System.Drawing.Size(82, 34);
            this.btRemovePersonTime.TabIndex = 2;
            this.btRemovePersonTime.Text = "Удалить";
            this.btRemovePersonTime.UseVisualStyleBackColor = true;
            // 
            // btChangePersonTime
            // 
            this.btChangePersonTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.btChangePersonTime.Location = new System.Drawing.Point(518, 4);
            this.btChangePersonTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btChangePersonTime.Name = "btChangePersonTime";
            this.btChangePersonTime.Size = new System.Drawing.Size(82, 34);
            this.btChangePersonTime.TabIndex = 1;
            this.btChangePersonTime.Text = "Изменить";
            this.btChangePersonTime.UseVisualStyleBackColor = true;
            // 
            // btAddPersonTime
            // 
            this.btAddPersonTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.btAddPersonTime.Location = new System.Drawing.Point(600, 4);
            this.btAddPersonTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAddPersonTime.Name = "btAddPersonTime";
            this.btAddPersonTime.Size = new System.Drawing.Size(82, 34);
            this.btAddPersonTime.TabIndex = 0;
            this.btAddPersonTime.Text = "Добавить";
            this.btAddPersonTime.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btSave);
            this.splitContainer4.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainer4.Size = new System.Drawing.Size(700, 338);
            this.splitContainer4.SplitterDistance = 297;
            this.splitContainer4.TabIndex = 4;
            // 
            // btSave
            // 
            this.btSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSave.Location = new System.Drawing.Point(614, 4);
            this.btSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(82, 29);
            this.btSave.TabIndex = 1;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // BypassCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.splitContainer4);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BypassCard";
            this.Text = "BypassCard";
            ((System.ComponentModel.ISupportInitialize)(this.sbBypassed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepeated)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonTime)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource sbBypassed;
        private System.Windows.Forms.DataGridView dgvRepeated;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dgvPersonTime;
        private System.Windows.Forms.Button btRemovePersonTime;
        private System.Windows.Forms.Button btChangePersonTime;
        private System.Windows.Forms.Button btAddPersonTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox dtMonth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbAddress;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.CheckBox chbIsComplited;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btRemoveContribution;
        private System.Windows.Forms.Button btChangeContribution;
        private System.Windows.Forms.Button btAddContribution;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button btAddAddres;
    }
}