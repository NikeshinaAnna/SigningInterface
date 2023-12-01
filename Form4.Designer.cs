
namespace SigningInterface
{
    partial class Form4
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
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToAddRows = false;
            this.DataTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.DataTable.Location = new System.Drawing.Point(92, 0);
            this.DataTable.Name = "DataTable";
            this.DataTable.ReadOnly = true;
            this.DataTable.RowTemplate.Height = 25;
            this.DataTable.Size = new System.Drawing.Size(550, 440);
            this.DataTable.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.Font = new System.Drawing.Font("David Libre", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(11, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(642, 440);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.DataTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результаты измерений";
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataTable;
        private System.Windows.Forms.Button btnCancel;
    }
}