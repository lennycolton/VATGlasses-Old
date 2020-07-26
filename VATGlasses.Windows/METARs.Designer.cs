namespace VATGlasses
{
    partial class METARs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(METARs));
            this.TxtMETAR = new System.Windows.Forms.TextBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.LblAirport = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.LblSearch = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtMETAR
            // 
            this.TxtMETAR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtMETAR.Location = new System.Drawing.Point(12, 56);
            this.TxtMETAR.Multiline = true;
            this.TxtMETAR.Name = "TxtMETAR";
            this.TxtMETAR.ReadOnly = true;
            this.TxtMETAR.Size = new System.Drawing.Size(226, 96);
            this.TxtMETAR.TabIndex = 21;
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.Location = new System.Drawing.Point(12, 158);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(226, 23);
            this.BtnClose.TabIndex = 20;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LblAirport
            // 
            this.LblAirport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAirport.Location = new System.Drawing.Point(12, 36);
            this.LblAirport.Name = "LblAirport";
            this.LblAirport.Size = new System.Drawing.Size(226, 13);
            this.LblAirport.TabIndex = 19;
            this.LblAirport.Text = "Enter an ICAO Code to Search for an Airport";
            this.LblAirport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearch.Location = new System.Drawing.Point(162, 10);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(76, 23);
            this.BtnSearch.TabIndex = 18;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // LblSearch
            // 
            this.LblSearch.AutoSize = true;
            this.LblSearch.Location = new System.Drawing.Point(9, 15);
            this.LblSearch.Name = "LblSearch";
            this.LblSearch.Size = new System.Drawing.Size(40, 13);
            this.LblSearch.TabIndex = 17;
            this.LblSearch.Text = "Airport:";
            // 
            // TxtSearch
            // 
            this.TxtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSearch.Location = new System.Drawing.Point(55, 12);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(101, 20);
            this.TxtSearch.TabIndex = 16;
            // 
            // METARs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 191);
            this.Controls.Add(this.TxtMETAR);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.LblAirport);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.LblSearch);
            this.Controls.Add(this.TxtSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "METARs";
            this.Text = "METARs";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtMETAR;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label LblAirport;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label LblSearch;
        private System.Windows.Forms.TextBox TxtSearch;
    }
}