using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;
using System.Windows.Forms;

namespace CodeCompletition
{
    public class HtmlTagCompletionData : ICompletionData
    {
        string description;

        HtmlTag htmlTag = null;

        private const string SELECTEDTEXT = "${selectedText}";
        private const string CURSOR = "${cursor}";

        public int ImageIndex
        {
            get
            {
                return 0;
            }
        }
        

        public string Text
        {
            get
            {
                return htmlTag.Name;
            }

            set
            {
            }
        }

        public virtual string Description
        {
            get
            {
                string path = Application.StartupPath;
                return "<b>XHTML 1.0 <" + htmlTag.Name + "></b><br>" + htmlTag.Description;
            }
            set
            {
                description = value;
            }
        }

        double priority;

        public double Priority
        {
            get
            {
                return priority;
            }
            set
            {
                priority = value;
            }
        }

        public virtual bool InsertAction(TextArea textArea, char ch)
        {
            textArea.InsertString("<"+htmlTag.Name);
            //InsertString(insertText, textArea);
            return true;
        }

        public HtmlTagCompletionData(HtmlTag htmlTag)
        {
            this.htmlTag = htmlTag;
        }

        public static int Compare(ICompletionData a, ICompletionData b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            return string.Compare(a.Text, b.Text, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
