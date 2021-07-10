namespace DynamicFilterControls
{
    partial class OperandBuilderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperandBuilderForm));
            this.operandBuilder = new DynamicFilterControls.OperandBuilder();
            this.SuspendLayout();
            // 
            // operandBuilder
            // 
            this.operandBuilder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operandBuilder.Location = new System.Drawing.Point(0, 0);
            this.operandBuilder.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.operandBuilder.Name = "operandBuilder";
            this.operandBuilder.Properties = null;
            this.operandBuilder.Property = null;
            this.operandBuilder.Size = new System.Drawing.Size(517, 102);
            this.operandBuilder.TabIndex = 0;
            // 
            // OperandBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 102);
            this.Controls.Add(this.operandBuilder);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1327, 149);
            this.MinimumSize = new System.Drawing.Size(533, 149);
            this.Name = "OperandBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка операнда";
            this.ResumeLayout(false);

        }

        #endregion

        private DynamicFilterControls.OperandBuilder operandBuilder;
    }
}