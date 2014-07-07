using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;
using Gamodo.Tabs.EditorTab.Tools;

namespace CodeCompletition
{
    public class HtmlAttributeCompletionData : ICompletionData
    {
        string description;
        string insertString;
        string parentName;

        HtmlAttribute attribute = null;

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
                return attribute.Name;
            }

            set
            {
            }
        }

        public virtual string Description
        {
            get
            {
                return "<b><"+parentName+"></b><br>"+attribute.Description;
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
            //textArea.InsertString(attribute.Name);
            TemplateLoader.InsertString(" "+insertString, textArea);
            return true;
        }

        public HtmlAttributeCompletionData(HtmlAttribute attribute, string parentName)
        {
            this.attribute = attribute;
            this.insertString = attribute.Name + "=\"${cursor}\"";
            this.parentName = parentName;
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
