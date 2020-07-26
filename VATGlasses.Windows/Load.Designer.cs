namespace VATGlasses
{
    partial class Load
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Load));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.LblProgress = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.InitialImage = null;
            this.pbLogo.Location = new System.Drawing.Point(12, 41);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(176, 176);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(12, 223);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(176, 23);
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgress.TabIndex = 1;
            // 
            // LblProgress
            // 
            this.LblProgress.AutoSize = true;
            this.LblProgress.Location = new System.Drawing.Point(9, 249);
            this.LblProgress.Name = "LblProgress";
            this.LblProgress.Size = new System.Drawing.Size(54, 13);
            this.LblProgress.TabIndex = 2;
            this.LblProgress.Text = "Loading...";
            // 
            // LblName
            // 
            this.LblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.Location = new System.Drawing.Point(12, 9);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(176, 29);
            this.LblName.TabIndex = 13;
            this.LblName.Text = "VATGlasses";
            this.LblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 268);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.LblProgress);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Load";
            this.Text = "Load";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label LblProgress;
        private System.Windows.Forms.Label LblName;
    }
}