using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Collections.Specialized;

namespace tx_sample_toc
{
    class TableOfContents
    {
        private TXTextControl.TextControl tx;
        private int iLevels;
        private int initialPos;

        public string[] MatchList = new string[9];

        public System.Windows.Forms.ProgressBar _progressBar;
        public int IndentValue = 400;
        public bool ShowPageNumbers = true;
        public bool RightAlignPageNumbers = true;
        public string PageNumberPrefix = "Page ";
        public string SeparatorString = "\t";
        public string Title = "Table of contents\r\n";
        public string TitleFormattingStyle = "Style1";
        public string EntriesFormattingStyle = "[Normal]";

        // a TX Text Control instance will be passed in the constructor
        public TableOfContents(TXTextControl.TextControl TextControl)
        {
            tx = TextControl;
            Levels = 1;
            initialPos = tx.Selection.Start;

            tx.DocumentLinkClicked += new TXTextControl.DocumentLinkEventHandler(tx_DocumentLinkClicked);
        }

        // a ProgressBar for a long documents
        public System.Windows.Forms.ProgressBar ProgressBar
        {
            get { return _progressBar; }
            set
            {
                _progressBar = value;
                _progressBar.Step = 1;
            }
        }

        // scroll to the target
        void tx_DocumentLinkClicked(object sender, TXTextControl.DocumentLinkEventArgs e)
        {
            e.DocumentLink.DocumentTarget.ScrollTo();
            tx.Selection.Length = 0;
        }

        public int Levels
        {
            get { return iLevels; }
            set
            {
                if (value > 0 && value < 10)
                {
                    iLevels = value;
                }
                else
                    throw new Exception("The value must be between 1 and 9");
            }
        }

        public void Create()
        {
            Remove();
            MarkTOCParagraphs();
            CreateTOC();

            if(ShowPageNumbers == true)
                GetPageNumbers();

            tx.Select(initialPos, 0);
        }

        // this method removes an existing TOC in the document
        public void Remove()
        {
            ProgressBar.Value = 0;

            int startValue = 0;
            int endValue = 0;

            TXTextControl.DocumentTargetCollection.TextFieldEnumerator targetEnum = tx.DocumentTargets.GetEnumerator();
            int targetCounter = tx.DocumentTargets.Count;

            ProgressBar.Maximum = targetCounter;

            targetEnum.Reset();
            targetEnum.MoveNext();

            for (int i = 0; i < targetCounter; i++)
            {
                ProgressBar.PerformStep();
                ProgressBar.Refresh();

                targetEnum.Reset();
                targetEnum.MoveNext();

                TXTextControl.DocumentTarget curTarget = (TXTextControl.DocumentTarget)targetEnum.Current;

                if (curTarget.TargetName == "TOC_Start")
                {
                    startValue = curTarget.Start - 1;
                    tx.DocumentTargets.Remove(curTarget);
                }

                if (curTarget.TargetName == "TOC_End")
                {
                    endValue = curTarget.Start - 1;
                    tx.DocumentTargets.Remove(curTarget);
                }

                if (curTarget.TargetName.StartsWith("target,") == true)
                {
                    tx.DocumentTargets.Remove(curTarget);
                }
            }

            tx.Select(startValue, endValue - startValue);
            tx.Selection.Text = "";
        }

        private void CreateTOC()
        {
            ProgressBar.Value = 0;

            // we use targets to mark the start and end positions of the TOC
            tx.Select(initialPos, 0);
            tx.DocumentTargets.Add(new TXTextControl.DocumentTarget("TOC_Start"));

            tx.Selection.FormattingStyle = TitleFormattingStyle;
            tx.Selection.Text = Title + "\r\n";

            ProgressBar.Maximum = tx.DocumentTargets.Count;

            foreach (TXTextControl.DocumentTarget curTarget in tx.DocumentTargets)
            {
                ProgressBar.PerformStep();
                ProgressBar.Refresh();

                if (curTarget.TargetName.StartsWith("target,") == false)
                    continue;

                string linkName = curTarget.TargetName.Split(',').GetValue(3).ToString();

                TXTextControl.DocumentLink newLink = new TXTextControl.DocumentLink(linkName, curTarget);

                tx.DocumentLinks.Add(newLink);

                tx.Selection.FormattingStyle = EntriesFormattingStyle;
                tx.Selection.ListFormat.Type = TXTextControl.ListType.Numbered;
                tx.Selection.ListFormat.Level = Convert.ToInt32(curTarget.TargetName.Split(',').GetValue(1).ToString());
                
                if (RightAlignPageNumbers == true)
                {
                    // remove all tabs in order to insert 1 right aligned tab
                    tx.Selection.ParagraphFormat.TabPositions = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    tx.Selection.ParagraphFormat.TabTypes = new TXTextControl.TabType[] { TXTextControl.TabType.RightBorderTab };
                }

                if (tx.Selection.ListFormat.Level != 1)
                {
                    // set the indent level, if nested level
                    tx.Selection.ListFormat.LeftIndent = IndentValue * tx.Selection.ListFormat.Level;
                    
                }
                else
                {
                    tx.Selection.ListFormat.LeftIndent = 0;
                }

                tx.Selection.Text = "\r\n";
            }

            tx.Selection.ListFormat.Type = TXTextControl.ListType.None;
            tx.Selection.Text = "\r\n";
            tx.DocumentTargets.Add(new TXTextControl.DocumentTarget("TOC_End"));
        }

        private void GetPageNumbers()
        {
            ProgressBar.Value = 0;
            ProgressBar.Maximum = tx.DocumentLinks.Count;

            // iterate again through all targets to get the page numbers
            foreach (TXTextControl.DocumentLink curLink in tx.DocumentLinks)
            {
                ProgressBar.PerformStep();
                ProgressBar.Refresh();

                if (curLink.DocumentTarget.TargetName.StartsWith("target,") == false)
                    continue;

                tx.Selection.Start = curLink.DocumentTarget.Start - 1;
                curLink.Text += SeparatorString + PageNumberPrefix + tx.InputPosition.Page.ToString();
            }
        }

        private void MarkTOCParagraphs()
        {
            // mark all paragraphs that will be indexed
            ProgressBar.Value = 0;

            Paragraphs myPars = new Paragraphs(tx);
            ArrayList pars = myPars.GetParagraphs();

            ProgressBar.Maximum = pars.Count;

            foreach (Paragraph curPar in pars)
            {
                ProgressBar.PerformStep();
                ProgressBar.Refresh();

                int styleCount = 1;

                foreach (string style in MatchList)
                {
                    if (curPar.Style == style)
                    {
                        TXTextControl.DocumentTarget newTarget =
                            new TXTextControl.DocumentTarget("target," + 
                            styleCount.ToString() + "," + style + "," + curPar.Text + "," + curPar.Start.ToString());

                        tx.Select(curPar.Start, 0);
                        tx.DocumentTargets.Add(newTarget);
                    }

                    styleCount++;
                }
            }
        }

        // a custom ParagraphCollection implementation
        private class Paragraphs
        {
            private TXTextControl.TextControl TX;
            ArrayList m_par = new ArrayList();

            public Paragraphs(TXTextControl.TextControl tx)
            {
                TX = tx;
            }

            public ArrayList GetParagraphs()
            {
                int startPos = 0;
                int newPos = 0;

                do
                {
                    newPos = TX.Find("\n", startPos, TXTextControl.FindOptions.NoMessageBox);

                    if (newPos == -1) break;


                    Paragraph newPar = new Paragraph();

                    newPar.Start = startPos;
                    newPar.Length = newPos - startPos;

                    TX.Select(startPos, newPos - startPos);

                    if (newPos != startPos)
                    {
                        newPar.Text = TX.Selection.Text;
                    }
                    else
                    {
                        newPar.Text = "";
                    }

                    newPar.Style = TX.Selection.FormattingStyle;
                    newPar.Page = TX.InputPosition.Page;

                    m_par.Add(newPar);
                    startPos = newPos + 1;
                }
                while (true);

                return m_par;
            }
        }

        // a paragraph class that contains the required information of a single paragraph
        private class Paragraph
        {
            string m_text;
            int m_start;
            int m_length;
            string m_style;
            int m_page;

            public string Text
            {
                get { return m_text; }
                set { m_text = value; }
            }

            public int Start
            {
                get { return m_start; }
                set { m_start = value; }
            }

            public int Length
            {
                get { return m_length; }
                set { m_length = value; }
            }

            public string Style
            {
                get { return m_style; }
                set { m_style = value; }
            }

            public int Page
            {
                get { return m_page; }
                set { m_page = value; }
            }
        }
    }
}
