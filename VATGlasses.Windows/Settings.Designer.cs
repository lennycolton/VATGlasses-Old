namespace VATGlasses
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.radCentre = new System.Windows.Forms.RadioButton();
            this.radMouseCentre = new System.Windows.Forms.RadioButton();
            this.radMouseNoCentre = new System.Windows.Forms.RadioButton();
            this.BtnSave = new System.Windows.Forms.Button();
            this.radDark = new System.Windows.Forms.RadioButton();
            this.radLight = new System.Windows.Forms.RadioButton();
            this.BtnClose = new System.Windows.Forms.Button();
            this.gbZoom = new System.Windows.Forms.GroupBox();
            this.gbColour = new System.Windows.Forms.GroupBox();
            this.gbMinimise = new System.Windows.Forms.GroupBox();
            this.radTaskbar = new System.Windows.Forms.RadioButton();
            this.radTray = new System.Windows.Forms.RadioButton();
            this.gbZoom.SuspendLayout();
            this.gbColour.SuspendLayout();
            this.gbMinimise.SuspendLayout();
            this.SuspendLayout();
            // 
            // radCentre
            // 
            this.radCentre.AutoSize = true;
            this.radCentre.Location = new System.Drawing.Point(6, 19);
            this.radCentre.Name = "radCentre";
            this.radCentre.Size = new System.Drawing.Size(105, 17);
            this.radCentre.TabIndex = 1;
            this.radCentre.TabStop = true;
            this.radCentre.Text = "Centre of Screen";
            this.radCentre.UseVisualStyleBackColor = true;
            // 
            // radMouseCentre
            // 
            this.radMouseCentre.AutoSize = true;
            this.radMouseCentre.Location = new System.Drawing.Point(6, 42);
            this.radMouseCentre.Name = "radMouseCentre";
            this.radMouseCentre.Size = new System.Drawing.Size(185, 17);
            this.radMouseCentre.TabIndex = 2;
            this.radMouseCentre.TabStop = true;
            this.radMouseCentre.Text = "Mouse Position - Centre on Cursor";
            this.radMouseCentre.UseVisualStyleBackColor = true;
            // 
            // radMouseNoCentre
            // 
            this.radMouseNoCentre.AutoSize = true;
            this.radMouseNoCentre.Location = new System.Drawing.Point(6, 65);
            this.radMouseNoCentre.Name = "radMouseNoCentre";
            this.radMouseNoCentre.Size = new System.Drawing.Size(165, 17);
            this.radMouseNoCentre.TabIndex = 3;
            this.radMouseNoCentre.TabStop = true;
            this.radMouseNoCentre.Text = "Mouse Position - Don\'t Centre";
            this.radMouseNoCentre.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(12, 248);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(194, 23);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // radDark
            // 
            this.radDark.AutoSize = true;
            this.radDark.Location = new System.Drawing.Point(6, 42);
            this.radDark.Name = "radDark";
            this.radDark.Size = new System.Drawing.Size(48, 17);
            this.radDark.TabIndex = 7;
            this.radDark.TabStop = true;
            this.radDark.Text = "Dark";
            this.radDark.UseVisualStyleBackColor = true;
            // 
            // radLight
            // 
            this.radLight.AutoSize = true;
            this.radLight.Location = new System.Drawing.Point(6, 19);
            this.radLight.Name = "radLight";
            this.radLight.Size = new System.Drawing.Size(48, 17);
            this.radLight.TabIndex = 6;
            this.radLight.TabStop = true;
            this.radLight.Text = "Light";
            this.radLight.UseVisualStyleBackColor = true;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(12, 277);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(194, 23);
            this.BtnClose.TabIndex = 8;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // gbZoom
            // 
            this.gbZoom.Controls.Add(this.radCentre);
            this.gbZoom.Controls.Add(this.radMouseCentre);
            this.gbZoom.Controls.Add(this.radMouseNoCentre);
            this.gbZoom.Location = new System.Drawing.Point(12, 12);
            this.gbZoom.Name = "gbZoom";
            this.gbZoom.Size = new System.Drawing.Size(194, 88);
            this.gbZoom.TabIndex = 9;
            this.gbZoom.TabStop = false;
            this.gbZoom.Text = "Zoom Mode";
            // 
            // gbColour
            // 
            this.gbColour.Controls.Add(this.radLight);
            this.gbColour.Controls.Add(this.radDark);
            this.gbColour.Location = new System.Drawing.Point(12, 106);
            this.gbColour.Name = "gbColour";
            this.gbColour.Size = new System.Drawing.Size(194, 65);
            this.gbColour.TabIndex = 0;
            this.gbColour.TabStop = false;
            this.gbColour.Text = "Colour Theme";
            // 
            // gbMinimise
            // 
            this.gbMinimise.Controls.Add(this.radTaskbar);
            this.gbMinimise.Controls.Add(this.radTray);
            this.gbMinimise.Location = new System.Drawing.Point(12, 177);
            this.gbMinimise.Name = "gbMinimise";
            this.gbMinimise.Size = new System.Drawing.Size(194, 65);
            this.gbMinimise.TabIndex = 8;
            this.gbMinimise.TabStop = false;
            this.gbMinimise.Text = "Minimise To";
            // 
            // radTaskbar
            // 
            this.radTaskbar.AutoSize = true;
            this.radTaskbar.Location = new System.Drawing.Point(6, 19);
            this.radTaskbar.Name = "radTaskbar";
            this.radTaskbar.Size = new System.Drawing.Size(64, 17);
            this.radTaskbar.TabIndex = 6;
            this.radTaskbar.TabStop = true;
            this.radTaskbar.Text = "Taskbar";
            this.radTaskbar.UseVisualStyleBackColor = true;
            // 
            // radTray
            // 
            this.radTray.AutoSize = true;
            this.radTray.Location = new System.Drawing.Point(6, 42);
            this.radTray.Name = "radTray";
            this.radTray.Size = new System.Drawing.Size(83, 17);
            this.radTray.TabIndex = 7;
            this.radTray.TabStop = true;
            this.radTray.Text = "System Tray";
            this.radTray.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 312);
            this.Controls.Add(this.gbMinimise);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.gbZoom);
            this.Controls.Add(this.gbColour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.gbZoom.ResumeLayout(false);
            this.gbZoom.PerformLayout();
            this.gbColour.ResumeLayout(false);
            this.gbColour.PerformLayout();
            this.gbMinimise.ResumeLayout(false);
            this.gbMinimise.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton radCentre;
        private System.Windows.Forms.RadioButton radMouseCentre;
        private System.Windows.Forms.RadioButton radMouseNoCentre;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.RadioButton radDark;
        private System.Windows.Forms.RadioButton radLight;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.GroupBox gbZoom;
        private System.Windows.Forms.GroupBox gbColour;
        private System.Windows.Forms.GroupBox gbMinimise;
        private System.Windows.Forms.RadioButton radTaskbar;
        private System.Windows.Forms.RadioButton radTray;
    }
}