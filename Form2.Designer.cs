
namespace SigningInterface
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbWeirCartes = new System.Windows.Forms.CheckBox();
            this.cbWeirProj = new System.Windows.Forms.CheckBox();
            this.cbEdwCartes = new System.Windows.Forms.CheckBox();
            this.cbEdwProj = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbWeirCartes);
            this.groupBox1.Controls.Add(this.cbWeirProj);
            this.groupBox1.Controls.Add(this.cbEdwCartes);
            this.groupBox1.Controls.Add(this.cbEdwProj);
            this.groupBox1.Font = new System.Drawing.Font("David Libre", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(45, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите хотя бы один вариант кривой";
            // 
            // cbWeirCartes
            // 
            this.cbWeirCartes.AutoSize = true;
            this.cbWeirCartes.Checked = true;
            this.cbWeirCartes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWeirCartes.Location = new System.Drawing.Point(8, 47);
            this.cbWeirCartes.Name = "cbWeirCartes";
            this.cbWeirCartes.Size = new System.Drawing.Size(264, 20);
            this.cbWeirCartes.TabIndex = 0;
            this.cbWeirCartes.Text = "В ф. Вейерштрасса (декартовы коорд.)";
            this.cbWeirCartes.UseVisualStyleBackColor = true;
            // 
            // cbWeirProj
            // 
            this.cbWeirProj.AutoSize = true;
            this.cbWeirProj.Location = new System.Drawing.Point(9, 72);
            this.cbWeirProj.Name = "cbWeirProj";
            this.cbWeirProj.Size = new System.Drawing.Size(278, 20);
            this.cbWeirProj.TabIndex = 1;
            this.cbWeirProj.Text = "В ф. Вейерштрасса (проективные коорд.)";
            this.cbWeirProj.UseVisualStyleBackColor = true;
            // 
            // cbEdwCartes
            // 
            this.cbEdwCartes.AutoSize = true;
            this.cbEdwCartes.Location = new System.Drawing.Point(9, 97);
            this.cbEdwCartes.Name = "cbEdwCartes";
            this.cbEdwCartes.Size = new System.Drawing.Size(235, 20);
            this.cbEdwCartes.TabIndex = 2;
            this.cbEdwCartes.Text = "В ф. Эдвардса (декартовы коорд.)";
            this.cbEdwCartes.UseVisualStyleBackColor = true;
            // 
            // cbEdwProj
            // 
            this.cbEdwProj.AutoSize = true;
            this.cbEdwProj.Location = new System.Drawing.Point(8, 122);
            this.cbEdwProj.Name = "cbEdwProj";
            this.cbEdwProj.Size = new System.Drawing.Size(249, 20);
            this.cbEdwProj.TabIndex = 3;
            this.cbEdwProj.Text = "В ф. Эдвардса (проективные коорд.)";
            this.cbEdwProj.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.Font = new System.Drawing.Font("David Libre", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(12, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOk.Font = new System.Drawing.Font("David Libre", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOk.Location = new System.Drawing.Point(257, 243);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 29);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Form2
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(356, 302);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите исследуемые кривые";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbEdwProj;
        private System.Windows.Forms.CheckBox cbEdwCartes;
        private System.Windows.Forms.CheckBox cbWeirProj;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox cbWeirCartes;
    }
}