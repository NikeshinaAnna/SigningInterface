
namespace SigningInterface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmpSignGeneration = new System.Windows.Forms.Button();
            this.cmpSignVerification = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmpSignGeneration
            // 
            this.cmpSignGeneration.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmpSignGeneration.Font = new System.Drawing.Font("David Libre", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmpSignGeneration.Location = new System.Drawing.Point(141, 237);
            this.cmpSignGeneration.Name = "cmpSignGeneration";
            this.cmpSignGeneration.Size = new System.Drawing.Size(221, 72);
            this.cmpSignGeneration.TabIndex = 0;
            this.cmpSignGeneration.Text = "Измерить время генерации подписи";
            this.cmpSignGeneration.UseVisualStyleBackColor = false;
            this.cmpSignGeneration.Click += new System.EventHandler(this.cmpSignGeneration_Click);
            // 
            // cmpSignVerification
            // 
            this.cmpSignVerification.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmpSignVerification.Font = new System.Drawing.Font("David Libre", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmpSignVerification.Location = new System.Drawing.Point(141, 331);
            this.cmpSignVerification.Name = "cmpSignVerification";
            this.cmpSignVerification.Size = new System.Drawing.Size(221, 72);
            this.cmpSignVerification.TabIndex = 1;
            this.cmpSignVerification.Text = "Измерить время проверки подписи";
            this.cmpSignVerification.UseVisualStyleBackColor = false;
            this.cmpSignVerification.Click += new System.EventHandler(this.cmpSignVerification_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(501, 452);
            this.Controls.Add(this.cmpSignVerification);
            this.Controls.Add(this.cmpSignGeneration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmpSignGeneration;
        private System.Windows.Forms.Button cmpSignVerification;
    }
}

