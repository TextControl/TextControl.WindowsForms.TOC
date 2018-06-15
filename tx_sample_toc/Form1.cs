using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tx_sample_toc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textControl1.ButtonBar = buttonBar1;
            textControl1.RulerBar = rulerBar1;
            textControl1.VerticalRulerBar = rulerBar2;
            textControl1.StatusBar = statusBar1;

            // Load the sample document
            textControl1.Load("sample.doc", TXTextControl.StreamType.MSWord);
        }

        private void tOCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // a new instance of the TOC
            TableOfContents toc = new TableOfContents(textControl1);

            progressBar1.Visible = true;
            progressBar1.Location = new Point((this.Location.X / 2) + progressBar1.Width / 2, 200);

            // connect a progress bar to the TOC
            toc.ProgressBar = progressBar1;

            // set the to be indexed style levels
            toc.MatchList = new string[] { "Heading 1", "Heading 2",};
            // create the TOC at the current input position
            toc.Create();

            progressBar1.Visible = false;
        }
        
    }
}