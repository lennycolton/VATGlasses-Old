namespace VATGlasses
{
    partial class MapPilotFilters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapPilotFilters));
            this.gbAltitude = new System.Windows.Forms.GroupBox();
            this.BtnAltReset = new System.Windows.Forms.Button();
            this.LblUpperFt = new System.Windows.Forms.Label();
            this.LblAnd = new System.Windows.Forms.Label();
            this.LblLowerFt = new System.Windows.Forms.Label();
            this.nudUpper = new System.Windows.Forms.NumericUpDown();
            this.nudLower = new System.Windows.Forms.NumericUpDown();
            this.gbDep = new System.Windows.Forms.GroupBox();
            this.BtnDepClear = new System.Windows.Forms.Button();
            this.BtnDepRemove = new System.Windows.Forms.Button();
            this.TxtDep = new System.Windows.Forms.TextBox();
            this.cbDep = new System.Windows.Forms.ComboBox();
            this.BtnDepAdd = new System.Windows.Forms.Button();
            this.gbArr = new System.Windows.Forms.GroupBox();
            this.BtnArrClear = new System.Windows.Forms.Button();
            this.BtnArrRemove = new System.Windows.Forms.Button();
            this.TxtArr = new System.Windows.Forms.TextBox();
            this.cbArr = new System.Windows.Forms.ComboBox();
            this.BtnArrAdd = new System.Windows.Forms.Button();
            this.gbAirportChoice = new System.Windows.Forms.GroupBox();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbArr = new System.Windows.Forms.RadioButton();
            this.rbDep = new System.Windows.Forms.RadioButton();
            this.gbAltitude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLower)).BeginInit();
            this.gbDep.SuspendLayout();
            this.gbArr.SuspendLayout();
            this.gbAirportChoice.SuspendLayout();
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
            this.gbAltitude.Text = "Currently Between";
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
            // gbDep
            // 
            this.gbDep.Controls.Add(this.BtnDepClear);
            this.gbDep.Controls.Add(this.BtnDepRemove);
            this.gbDep.Controls.Add(this.TxtDep);
            this.gbDep.Controls.Add(this.cbDep);
            this.gbDep.Controls.Add(this.BtnDepAdd);
            this.gbDep.Location = new System.Drawing.Point(12, 106);
            this.gbDep.Name = "gbDep";
            this.gbDep.Size = new System.Drawing.Size(194, 102);
            this.gbDep.TabIndex = 5;
            this.gbDep.TabStop = false;
            this.gbDep.Text = "Departure Airport";
            // 
            // BtnDepClear
            // 
            this.BtnDepClear.Location = new System.Drawing.Point(6, 72);
            this.BtnDepClear.Name = "BtnDepClear";
            this.BtnDepClear.Size = new System.Drawing.Size(181, 23);
            this.BtnDepClear.TabIndex = 10;
            this.BtnDepClear.Text = "Clear";
            this.BtnDepClear.UseVisualStyleBackColor = true;
            this.BtnDepClear.Click += new System.EventHandler(this.BtnDepClear_Click);
            // 
            // BtnDepRemove
            // 
            this.BtnDepRemove.Location = new System.Drawing.Point(112, 44);
            this.BtnDepRemove.Name = "BtnDepRemove";
            this.BtnDepRemove.Size = new System.Drawing.Size(75, 23);
            this.BtnDepRemove.TabIndex = 9;
            this.BtnDepRemove.Text = "Remove";
            this.BtnDepRemove.UseVisualStyleBackColor = true;
            this.BtnDepRemove.Click += new System.EventHandler(this.BtnDepRemove_Click);
            // 
            // TxtDep
            // 
            this.TxtDep.Location = new System.Drawing.Point(6, 19);
            this.TxtDep.Name = "TxtDep";
            this.TxtDep.Size = new System.Drawing.Size(100, 20);
            this.TxtDep.TabIndex = 6;
            this.TxtDep.Text = "Enter ICAO Code...";
            this.TxtDep.GotFocus += new System.EventHandler(this.TxtDep_GotFocus);
            this.TxtDep.LostFocus += new System.EventHandler(this.TxtDep_LostFocus);
            // 
            // cbDep
            // 
            this.cbDep.FormattingEnabled = true;
            this.cbDep.Location = new System.Drawing.Point(6, 45);
            this.cbDep.Name = "cbDep";
            this.cbDep.Size = new System.Drawing.Size(100, 21);
            this.cbDep.TabIndex = 7;
            // 
            // BtnDepAdd
            // 
            this.BtnDepAdd.Location = new System.Drawing.Point(112, 18);
            this.BtnDepAdd.Name = "BtnDepAdd";
            this.BtnDepAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnDepAdd.TabIndex = 8;
            this.BtnDepAdd.Text = "Add";
            this.BtnDepAdd.UseVisualStyleBackColor = true;
            this.BtnDepAdd.Click += new System.EventHandler(this.BtnDepAdd_Click);
            // 
            // gbArr
            // 
            this.gbArr.Controls.Add(this.BtnArrClear);
            this.gbArr.Controls.Add(this.BtnArrRemove);
            this.gbArr.Controls.Add(this.TxtArr);
            this.gbArr.Controls.Add(this.cbArr);
            this.gbArr.Controls.Add(this.BtnArrAdd);
            this.gbArr.Location = new System.Drawing.Point(12, 214);
            this.gbArr.Name = "gbArr";
            this.gbArr.Size = new System.Drawing.Size(194, 102);
            this.gbArr.TabIndex = 11;
            this.gbArr.TabStop = false;
            this.gbArr.Text = "Arrival Airport";
            // 
            // BtnArrClear
            // 
            this.BtnArrClear.Location = new System.Drawing.Point(6, 72);
            this.BtnArrClear.Name = "BtnArrClear";
            this.BtnArrClear.Size = new System.Drawing.Size(181, 23);
            this.BtnArrClear.TabIndex = 10;
            this.BtnArrClear.Text = "Clear";
            this.BtnArrClear.UseVisualStyleBackColor = true;
            this.BtnArrClear.Click += new System.EventHandler(this.BtnArrClear_Click);
            // 
            // BtnArrRemove
            // 
            this.BtnArrRemove.Location = new System.Drawing.Point(112, 44);
            this.BtnArrRemove.Name = "BtnArrRemove";
            this.BtnArrRemove.Size = new System.Drawing.Size(75, 23);
            this.BtnArrRemove.TabIndex = 9;
            this.BtnArrRemove.Text = "Remove";
            this.BtnArrRemove.UseVisualStyleBackColor = true;
            this.BtnArrRemove.Click += new System.EventHandler(this.BtnArrRemove_Click);
            // 
            // TxtArr
            // 
            this.TxtArr.Location = new System.Drawing.Point(6, 19);
            this.TxtArr.Name = "TxtArr";
            this.TxtArr.Size = new System.Drawing.Size(100, 20);
            this.TxtArr.TabIndex = 6;
            this.TxtArr.Text = "Enter ICAO Code...";
            this.TxtArr.GotFocus += new System.EventHandler(this.TxtArr_GotFocus);
            this.TxtArr.LostFocus += new System.EventHandler(this.TxtArr_LostFocus);
            // 
            // cbArr
            // 
            this.cbArr.FormattingEnabled = true;
            this.cbArr.Location = new System.Drawing.Point(6, 45);
            this.cbArr.Name = "cbArr";
            this.cbArr.Size = new System.Drawing.Size(100, 21);
            this.cbArr.TabIndex = 7;
            // 
            // BtnArrAdd
            // 
            this.BtnArrAdd.Location = new System.Drawing.Point(112, 18);
            this.BtnArrAdd.Name = "BtnArrAdd";
            this.BtnArrAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnArrAdd.TabIndex = 8;
            this.BtnArrAdd.Text = "Add";
            this.BtnArrAdd.UseVisualStyleBackColor = true;
            this.BtnArrAdd.Click += new System.EventHandler(this.BtnArrAdd_Click);
            // 
            // gbAirportChoice
            // 
            this.gbAirportChoice.Controls.Add(this.rbNone);
            this.gbAirportChoice.Controls.Add(this.rbBoth);
            this.gbAirportChoice.Controls.Add(this.rbArr);
            this.gbAirportChoice.Controls.Add(this.rbDep);
            this.gbAirportChoice.Location = new System.Drawing.Point(12, 322);
            this.gbAirportChoice.Name = "gbAirportChoice";
            this.gbAirportChoice.Size = new System.Drawing.Size(194, 111);
            this.gbAirportChoice.TabIndex = 11;
            this.gbAirportChoice.TabStop = false;
            this.gbAirportChoice.Text = "Activate Airport Filter Lists";
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(6, 88);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(51, 17);
            this.rbNone.TabIndex = 3;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Location = new System.Drawing.Point(6, 65);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(47, 17);
            this.rbBoth.TabIndex = 2;
            this.rbBoth.TabStop = true;
            this.rbBoth.Text = "Both";
            this.rbBoth.UseVisualStyleBackColor = true;
            this.rbBoth.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbArr
            // 
            this.rbArr.AutoSize = true;
            this.rbArr.Location = new System.Drawing.Point(6, 42);
            this.rbArr.Name = "rbArr";
            this.rbArr.Size = new System.Drawing.Size(54, 17);
            this.rbArr.TabIndex = 1;
            this.rbArr.TabStop = true;
            this.rbArr.Text = "Arrival";
            this.rbArr.UseVisualStyleBackColor = true;
            this.rbArr.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbDep
            // 
            this.rbDep.AutoSize = true;
            this.rbDep.Location = new System.Drawing.Point(6, 19);
            this.rbDep.Name = "rbDep";
            this.rbDep.Size = new System.Drawing.Size(72, 17);
            this.rbDep.TabIndex = 0;
            this.rbDep.TabStop = true;
            this.rbDep.Text = "Departure";
            this.rbDep.UseVisualStyleBackColor = true;
            this.rbDep.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // MapPilotFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 445);
            this.Controls.Add(this.gbAirportChoice);
            this.Controls.Add(this.gbArr);
            this.Controls.Add(this.gbDep);
            this.Controls.Add(this.gbAltitude);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MapPilotFilters";
            this.Text = "Filters";
            this.gbAltitude.ResumeLayout(false);
            this.gbAltitude.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLower)).EndInit();
            this.gbDep.ResumeLayout(false);
            this.gbDep.PerformLayout();
            this.gbArr.ResumeLayout(false);
            this.gbArr.PerformLayout();
            this.gbAirportChoice.ResumeLayout(false);
            this.gbAirportChoice.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbDep;
        private System.Windows.Forms.TextBox TxtDep;
        private System.Windows.Forms.ComboBox cbDep;
        private System.Windows.Forms.Button BtnDepAdd;
        private System.Windows.Forms.Button BtnDepRemove;
        private System.Windows.Forms.Button BtnDepClear;
        private System.Windows.Forms.GroupBox gbArr;
        private System.Windows.Forms.Button BtnArrClear;
        private System.Windows.Forms.Button BtnArrRemove;
        private System.Windows.Forms.TextBox TxtArr;
        private System.Windows.Forms.ComboBox cbArr;
        private System.Windows.Forms.Button BtnArrAdd;
        private System.Windows.Forms.GroupBox gbAirportChoice;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.RadioButton rbArr;
        private System.Windows.Forms.RadioButton rbDep;
    }
}