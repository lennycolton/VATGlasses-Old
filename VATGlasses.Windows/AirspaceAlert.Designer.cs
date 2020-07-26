namespace VATGlasses
{
    partial class AirspaceAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AirspaceAlert));
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.TxtCID = new System.Windows.Forms.TextBox();
            this.LblCID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.Location = new System.Drawing.Point(12, 94);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(222, 23);
            this.BtnClose.TabIndex = 21;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(12, 65);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(222, 23);
            this.BtnSave.TabIndex = 22;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(90, 42);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(144, 17);
            this.chkActive.TabIndex = 23;
            this.chkActive.Text = "Activate Airspace Alerts?";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // TxtCID
            // 
            this.TxtCID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCID.Location = new System.Drawing.Point(46, 16);
            this.TxtCID.Name = "TxtCID";
            this.TxtCID.Size = new System.Drawing.Size(188, 20);
            this.TxtCID.TabIndex = 24;
            // 
            // LblCID
            // 
            this.LblCID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCID.AutoSize = true;
            this.LblCID.Location = new System.Drawing.Point(12, 19);
            this.LblCID.Name = "LblCID";
            this.LblCID.Size = new System.Drawing.Size(28, 13);
            this.LblCID.TabIndex = 25;
            this.LblCID.Text = "CID:";
            // 
            // AirspaceAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 129);
            this.Controls.Add(this.LblCID);
            this.Controls.Add(this.TxtCID);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AirspaceAlert";
            this.Text = "Alerts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox TxtCID;
        private System.Windows.Forms.Label LblCID;
    }
}