
namespace WinFormsView.Cards
{
    partial class AddressCard
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
            this.bsBypass = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.btRemovePerson = new System.Windows.Forms.Button();
            this.btChangePerson = new System.Windows.Forms.Button();
            this.btAddPerson = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dgvPorch = new System.Windows.Forms.DataGridView();
            this.btRemovePorch = new System.Windows.Forms.Button();
            this.btChangePorch = new System.Windows.Forms.Button();
            this.btAddPorch = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvBypass = new System.Windows.Forms.DataGridView();
            this.btRemoveBypass = new System.Windows.Forms.Button();
            this.btChangeBypass = new System.Windows.Forms.Button();
            this.btAddBypass = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btSave = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.bsPeople = new System.Windows.Forms.BindingSource(this.components);
            this.bsAddress = new System.Windows.Forms.BindingSource(this.components);
            this.bsPorch = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsBypass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorch)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBypass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPorch)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvPeople);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btRemovePerson);
            this.splitContainer1.Panel2.Controls.Add(this.btChangePerson);
            this.splitContainer1.Panel2.Controls.Add(this.btAddPerson);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Size = new System.Drawing.Size(686, 265);
            this.splitContainer1.SplitterDistance = 218;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeople.Location = new System.Drawing.Point(0, 0);
            this.dgvPeople.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersWidth = 51;
            this.dgvPeople.Size = new System.Drawing.Size(686, 218);
            this.dgvPeople.TabIndex = 0;
            // 
            // btRemovePerson
            // 
            this.btRemovePerson.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRemovePerson.Location = new System.Drawing.Point(4, 4);
            this.btRemovePerson.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRemovePerson.Name = "btRemovePerson";
            this.btRemovePerson.Size = new System.Drawing.Size(82, 36);
            this.btRemovePerson.TabIndex = 2;
            this.btRemovePerson.Text = "Удалить";
            this.btRemovePerson.UseVisualStyleBackColor = true;
            this.btRemovePerson.Click += new System.EventHandler(this.OnRemovePerson);
            // 
            // btChangePerson
            // 
            this.btChangePerson.Dock = System.Windows.Forms.DockStyle.Right;
            this.btChangePerson.Location = new System.Drawing.Point(518, 4);
            this.btChangePerson.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btChangePerson.Name = "btChangePerson";
            this.btChangePerson.Size = new System.Drawing.Size(82, 36);
            this.btChangePerson.TabIndex = 1;
            this.btChangePerson.Text = "Изменить";
            this.btChangePerson.UseVisualStyleBackColor = true;
            this.btChangePerson.Click += new System.EventHandler(this.OnChangePerson);
            // 
            // btAddPerson
            // 
            this.btAddPerson.Dock = System.Windows.Forms.DockStyle.Right;
            this.btAddPerson.Location = new System.Drawing.Point(600, 4);
            this.btAddPerson.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAddPerson.Name = "btAddPerson";
            this.btAddPerson.Size = new System.Drawing.Size(82, 36);
            this.btAddPerson.TabIndex = 0;
            this.btAddPerson.Text = "Добавить";
            this.btAddPerson.UseVisualStyleBackColor = true;
            this.btAddPerson.Click += new System.EventHandler(this.OnAddPerson);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 299);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 271);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основное";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbDescription);
            this.groupBox2.Location = new System.Drawing.Point(8, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(676, 114);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Комментарий";
            // 
            // tbDescription
            // 
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(3, 19);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(670, 92);
            this.tbDescription.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Улица Дом";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.splitContainer4);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(692, 271);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Подъезды";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dgvPorch);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btRemovePorch);
            this.splitContainer4.Panel2.Controls.Add(this.btChangePorch);
            this.splitContainer4.Panel2.Controls.Add(this.btAddPorch);
            this.splitContainer4.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainer4.Size = new System.Drawing.Size(686, 265);
            this.splitContainer4.SplitterDistance = 219;
            this.splitContainer4.SplitterWidth = 3;
            this.splitContainer4.TabIndex = 3;
            // 
            // dgvPorch
            // 
            this.dgvPorch.AllowUserToAddRows = false;
            this.dgvPorch.AllowUserToDeleteRows = false;
            this.dgvPorch.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPorch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPorch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPorch.Location = new System.Drawing.Point(0, 0);
            this.dgvPorch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPorch.Name = "dgvPorch";
            this.dgvPorch.ReadOnly = true;
            this.dgvPorch.RowHeadersWidth = 51;
            this.dgvPorch.Size = new System.Drawing.Size(686, 219);
            this.dgvPorch.TabIndex = 0;
            // 
            // btRemovePorch
            // 
            this.btRemovePorch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRemovePorch.Location = new System.Drawing.Point(4, 4);
            this.btRemovePorch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRemovePorch.Name = "btRemovePorch";
            this.btRemovePorch.Size = new System.Drawing.Size(82, 35);
            this.btRemovePorch.TabIndex = 2;
            this.btRemovePorch.Text = "Удалить";
            this.btRemovePorch.UseVisualStyleBackColor = true;
            this.btRemovePorch.Click += new System.EventHandler(this.OnRemovePorch);
            // 
            // btChangePorch
            // 
            this.btChangePorch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btChangePorch.Location = new System.Drawing.Point(518, 4);
            this.btChangePorch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btChangePorch.Name = "btChangePorch";
            this.btChangePorch.Size = new System.Drawing.Size(82, 35);
            this.btChangePorch.TabIndex = 1;
            this.btChangePorch.Text = "Изменить";
            this.btChangePorch.UseVisualStyleBackColor = true;
            this.btChangePorch.Click += new System.EventHandler(this.OnChangePorch);
            // 
            // btAddPorch
            // 
            this.btAddPorch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btAddPorch.Location = new System.Drawing.Point(600, 4);
            this.btAddPorch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAddPorch.Name = "btAddPorch";
            this.btAddPorch.Size = new System.Drawing.Size(82, 35);
            this.btAddPorch.TabIndex = 0;
            this.btAddPorch.Text = "Добавить";
            this.btAddPorch.UseVisualStyleBackColor = true;
            this.btAddPorch.Click += new System.EventHandler(this.OnAddPorch);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 271);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Люди";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(692, 271);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Обходы";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.splitContainer3.Panel1.Controls.Add(this.dgvBypass);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btRemoveBypass);
            this.splitContainer3.Panel2.Controls.Add(this.btChangeBypass);
            this.splitContainer3.Panel2.Controls.Add(this.btAddBypass);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainer3.Size = new System.Drawing.Size(686, 265);
            this.splitContainer3.SplitterDistance = 219;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 3;
            // 
            // dgvBypass
            // 
            this.dgvBypass.AllowUserToAddRows = false;
            this.dgvBypass.AllowUserToDeleteRows = false;
            this.dgvBypass.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvBypass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBypass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBypass.Location = new System.Drawing.Point(0, 0);
            this.dgvBypass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBypass.Name = "dgvBypass";
            this.dgvBypass.ReadOnly = true;
            this.dgvBypass.RowHeadersWidth = 51;
            this.dgvBypass.Size = new System.Drawing.Size(686, 219);
            this.dgvBypass.TabIndex = 0;
            // 
            // btRemoveBypass
            // 
            this.btRemoveBypass.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRemoveBypass.Location = new System.Drawing.Point(4, 4);
            this.btRemoveBypass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRemoveBypass.Name = "btRemoveBypass";
            this.btRemoveBypass.Size = new System.Drawing.Size(82, 35);
            this.btRemoveBypass.TabIndex = 2;
            this.btRemoveBypass.Text = "Удалить";
            this.btRemoveBypass.UseVisualStyleBackColor = true;
            this.btRemoveBypass.Click += new System.EventHandler(this.OnRemoveBypass);
            // 
            // btChangeBypass
            // 
            this.btChangeBypass.Dock = System.Windows.Forms.DockStyle.Right;
            this.btChangeBypass.Location = new System.Drawing.Point(518, 4);
            this.btChangeBypass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btChangeBypass.Name = "btChangeBypass";
            this.btChangeBypass.Size = new System.Drawing.Size(82, 35);
            this.btChangeBypass.TabIndex = 1;
            this.btChangeBypass.Text = "Изменить";
            this.btChangeBypass.UseVisualStyleBackColor = true;
            this.btChangeBypass.Click += new System.EventHandler(this.OnChangeBypass);
            // 
            // btAddBypass
            // 
            this.btAddBypass.Dock = System.Windows.Forms.DockStyle.Right;
            this.btAddBypass.Location = new System.Drawing.Point(600, 4);
            this.btAddBypass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAddBypass.Name = "btAddBypass";
            this.btAddBypass.Size = new System.Drawing.Size(82, 35);
            this.btAddBypass.TabIndex = 0;
            this.btAddBypass.Text = "Добавить";
            this.btAddBypass.UseVisualStyleBackColor = true;
            this.btAddBypass.Click += new System.EventHandler(this.OnAddBypass);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btSave);
            this.splitContainer2.Size = new System.Drawing.Size(700, 338);
            this.splitContainer2.SplitterDistance = 299;
            this.splitContainer2.TabIndex = 4;
            // 
            // btSave
            // 
            this.btSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSave.Location = new System.Drawing.Point(618, 0);
            this.btSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(82, 35);
            this.btSave.TabIndex = 1;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(3, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(670, 23);
            this.tbName.TabIndex = 0;
            // 
            // AddressCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddressCard";
            this.Text = "AddressCard";
            ((System.ComponentModel.ISupportInitialize)(this.bsBypass)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorch)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBypass)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPorch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsBypass;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Button btRemovePerson;
        private System.Windows.Forms.Button btChangePerson;
        private System.Windows.Forms.Button btAddPerson;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dgvBypass;
        private System.Windows.Forms.Button btRemoveBypass;
        private System.Windows.Forms.Button btChangeBypass;
        private System.Windows.Forms.Button btAddBypass;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView dgvPorch;
        private System.Windows.Forms.Button btRemovePorch;
        private System.Windows.Forms.Button btChangePorch;
        private System.Windows.Forms.Button btAddPorch;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.BindingSource bsPeople;
        private System.Windows.Forms.BindingSource bsAddress;
        private System.Windows.Forms.BindingSource bsPorch;
    }
}