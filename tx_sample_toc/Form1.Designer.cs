namespace tx_sample_toc
{
    partial class Form1
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
            this.textControl1 = new TXTextControl.TextControl();
            this.buttonBar1 = new TXTextControl.ButtonBar();
            this.rulerBar1 = new TXTextControl.RulerBar();
            this.rulerBar2 = new TXTextControl.RulerBar();
            this.statusBar1 = new TXTextControl.StatusBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tOCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.DocumentTargetMarkers = true;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.HideSelection = false;
            this.textControl1.Location = new System.Drawing.Point(25, 100);
            this.textControl1.Name = "textControl1";
            this.textControl1.Size = new System.Drawing.Size(549, 305);
            this.textControl1.TabIndex = 0;
            this.textControl1.Text = "textControl1";
            this.textControl1.ViewMode = TXTextControl.ViewMode.PageView;
            // 
            // buttonBar1
            // 
            this.buttonBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBar1.Location = new System.Drawing.Point(0, 24);
            this.buttonBar1.Name = "buttonBar1";
            this.buttonBar1.Size = new System.Drawing.Size(574, 28);
            this.buttonBar1.TabIndex = 1;
            this.buttonBar1.Text = "buttonBar1";
            // 
            // rulerBar1
            // 
            this.rulerBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rulerBar1.Location = new System.Drawing.Point(0, 52);
            this.rulerBar1.Name = "rulerBar1";
            this.rulerBar1.Size = new System.Drawing.Size(574, 25);
            this.rulerBar1.TabIndex = 2;
            this.rulerBar1.Text = "rulerBar1";
            // 
            // rulerBar2
            // 
            this.rulerBar2.Alignment = TXTextControl.RulerBarAlignment.Left;
            this.rulerBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.rulerBar2.Location = new System.Drawing.Point(0, 77);
            this.rulerBar2.Name = "rulerBar2";
            this.rulerBar2.Size = new System.Drawing.Size(25, 328);
            this.rulerBar2.TabIndex = 3;
            this.rulerBar2.Text = "rulerBar2";
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 405);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(574, 19);
            this.statusBar1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tOCToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(574, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tOCToolStripMenuItem
            // 
            this.tOCToolStripMenuItem.Name = "tOCToolStripMenuItem";
            this.tOCToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.tOCToolStripMenuItem.Text = "TOC";
            this.tOCToolStripMenuItem.Click += new System.EventHandler(this.tOCToolStripMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(25, 77);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(549, 23);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 424);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.rulerBar2);
            this.Controls.Add(this.rulerBar1);
            this.Controls.Add(this.buttonBar1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TX Text Control Sample: Table of Contents";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TXTextControl.TextControl textControl1;
        private TXTextControl.ButtonBar buttonBar1;
        private TXTextControl.RulerBar rulerBar1;
        private TXTextControl.RulerBar rulerBar2;
        private TXTextControl.StatusBar statusBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tOCToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

