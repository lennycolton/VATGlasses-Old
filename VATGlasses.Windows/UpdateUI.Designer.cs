namespace VATGlasses
{
    partial class UpdateUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateUI));
            this.LblUpdate = new System.Windows.Forms.Label();
            this.pbUpdate = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // LblUpdate
            // 
            this.LblUpdate.AutoSize = true;
            this.LblUpdate.Location = new System.Drawing.Point(12, 9);
            this.LblUpdate.Name = "LblUpdate";
            this.LblUpdate.Size = new System.Drawing.Size(68, 13);
            this.LblUpdate.TabIndex = 0;
            this.LblUpdate.Text = "Processing...";
            // 
            // pbUpdate
            // 
            this.pbUpdate.Location = new System.Drawing.Point(12, 25);
            this.pbUpdate.Name = "pbUpdate";
            this.pbUpdate.Size = new System.Drawing.Size(345, 23);
            this.pbUpdate.TabIndex = 1;
            // 
            // UpdateUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 57);
            this.Controls.Add(this.pbUpdate);
            this.Controls.Add(this.LblUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateUI";
            this.Text = "VATGlasses - Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblUpdate;
        private System.Windows.Forms.ProgressBar pbUpdate;
    }
}