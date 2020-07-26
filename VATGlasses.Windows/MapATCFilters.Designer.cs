namespace VATGlasses
{
    partial class MapATCFilters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapATCFilters));
            this.gbAltitude = new System.Windows.Forms.GroupBox();
            this.BtnAltReset = new System.Windows.Forms.Button();
            this.LblUpperFt = new System.Windows.Forms.Label();
            this.LblAnd = new System.Windows.Forms.Label();
            this.LblLowerFt = new System.Windows.Forms.Label();
            this.nudUpper = new System.Windows.Forms.NumericUpDown();
            this.nudLower = new System.Windows.Forms.NumericUpDown();
            this.gbOwners = new System.Windows.Forms.GroupBox();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.TxtAdd = new System.Windows.Forms.TextBox();
            this.cbOwners = new System.Windows.Forms.ComboBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.gbAltitude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLower)).BeginInit();
            this.gbOwners.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAltitude
            // 
            this.gbAltitude.Controls.Add(this.BtnAltReset);
            this.gbAltitude.Controls.Add(this.LblUpperFt);
            this.gbAltitude.Controls.Add(this.LblAnd);
            this.gbAltitude.Controls.Add(this.LblLowerFt);
            this.gbAltitude.Controls.Add(this.nudUpper);
            this.gbAltitude.Controls.Add(this.nudLower);
            this.gbAltitude.Location = new System.Drawing.Point(12, 12);
            this.gbAltitude.Name = "gbAltitude";
            this.gbAltitude.Size = new System.Drawing.Size(194, 88);
            this.gbAltitude.TabIndex = 3;
            this.gbAltitude.TabStop = false;
            this.gbAltitude.Text = "Covers Aircraft Flying Between";
            // 
            // BtnAltReset
            // 
            this.BtnAltReset.Location = new System.Drawing.Point(113, 57);
            this.BtnAltReset.Name = "BtnAltReset";
            this.BtnAltReset.Size = new System.Drawing.Size(75, 23);
            this.BtnAltReset.TabIndex = 5;
            this.BtnAltReset.Text = "Reset";
            this.BtnAltReset.UseVisualStyleBackColor = true;
            this.BtnAltReset.Click += new System.EventHandler(this.BtnAltReset_Click);
            // 
            // LblUpperFt
            // 
            this.LblUpperFt.AutoSize = true;
            this.LblUpperFt.Location = new System.Drawing.Point(93, 61);
            this.LblUpperFt.Name = "LblUpperFt";
            this.LblUpperFt.Size = new System.Drawing.Size(13, 13);
            this.LblUpperFt.TabIndex = 4;
            this.LblUpperFt.Text = "ft";
            // 
            // LblAnd
            // 
            this.LblAnd.AutoSize = true;
            this.LblAnd.Location = new System.Drawing.Point(6, 42);
            this.LblAnd.Name = "LblAnd";
            this.LblAnd.Size = new System.Drawing.Size(25, 13);
            this.LblAnd.TabIndex = 3;
            this.LblAnd.Text = "and";
            // 
            // LblLowerFt
            // 
            this.LblLowerFt.AutoSize = true;
            this.LblLowerFt.Location = new System.Drawing.Point(93, 21);
            this.LblLowerFt.Name = "LblLowerFt";
            this.LblLowerFt.Size = new System.Drawing.Size(13, 13);
            this.LblLowerFt.TabIndex = 2;
            this.LblLowerFt.Text = "ft";
            // 
            // nudUpper
            // 
            this.nudUpper.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudUpper.Location = new System.Drawing.Point(6, 59);
            this.nudUpper.Name = "nudUpper";
            this.nudUpper.Size = new System.Drawing.Size(81, 20);
            this.nudUpper.TabIndex = 1;
            this.nudUpper.ValueChanged += new System.EventHandler(this.nudUpper_ValueChanged);
            // 
            // nudLower
            // 
            this.nudLower.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudLower.Location = new System.Drawing.Point(6, 19);
            this.nudLower.Name = "nudLower";
            this.nudLower.Size = new System.Drawing.Size(81, 20);
            this.nudLower.TabIndex = 0;
            this.nudLower.ValueChanged += new System.EventHandler(this.nudLower_ValueChanged);
            // 
            // gbOwners
            // 
            this.gbOwners.Controls.Add(this.BtnClear);
            this.gbOwners.Controls.Add(this.BtnRemove);
            this.gbOwners.Controls.Add(this.TxtAdd);
            this.gbOwners.Controls.Add(this.cbOwners);
            this.gbOwners.Controls.Add(this.BtnAdd);
            this.gbOwners.Location = new System.Drawing.Point(12, 106);
            this.gbOwners.Name = "gbOwners";
            this.gbOwners.Size = new System.Drawing.Size(194, 102);
            this.gbOwners.TabIndex = 5;
            this.gbOwners.TabStop = false;
            this.gbOwners.Text = "Owned By";
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(6, 72);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(181, 23);
            this.BtnClear.TabIndex = 10;
            this.BtnClear.Text = "Show All";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(112, 44);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(75, 23);
            this.BtnRemove.TabIndex = 9;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // TxtAdd
            // 
            this.TxtAdd.Location = new System.Drawing.Point(6, 19);
            this.TxtAdd.Name = "TxtAdd";
            this.TxtAdd.Size = new System.Drawing.Size(100, 20);
            this.TxtAdd.TabIndex = 6;
            // 
            // cbOwners
            // 
            this.cbOwners.FormattingEnabled = true;
            this.cbOwners.Location = new System.Drawing.Point(6, 45);
            this.cbOwners.Name = "cbOwners";
            this.cbOwners.Size = new System.Drawing.Size(100, 21);
            this.cbOwners.TabIndex = 7;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(112, 18);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 8;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // MapATCFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 220);
            this.Controls.Add(this.gbOwners);
            this.Controls.Add(this.gbAltitude);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MapATCFilters";
            this.Text = "Filters";
            this.gbAltitude.ResumeLayout(false);
            this.gbAltitude.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLower)).EndInit();
            this.gbOwners.ResumeLayout(false);
            this.gbOwners.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbAltitude;
        private System.Windows.Forms.Label LblUpperFt;
        private System.Windows.Forms.Label LblAnd;
        private System.Windows.Forms.Label LblLowerFt;
        private System.Windows.Forms.NumericUpDown nudUpper;
        private System.Windows.Forms.NumericUpDown nudLower;
        private System.Windows.Forms.Button BtnAltReset;
        private System.Windows.Forms.GroupBox gbOwners;
        private System.Windows.Forms.TextBox TxtAdd;
        private System.Windows.Forms.ComboBox cbOwners;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnClear;
    }
}