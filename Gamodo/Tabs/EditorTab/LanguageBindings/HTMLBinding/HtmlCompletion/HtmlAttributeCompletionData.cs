using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;
using Gamodo.Tabs.EditorTab.Tools;
using Gamodo.Tabs.EditorTab.Quicklet;
using Gamodo.Editor;

namespace Gamodo.Tabs.EditorTab.LanguageBindings.HtmlCompletion
{
    public class HtmlAttributeCompletionData : ICompletionData
    {
        string description;
        string deprecated = "";
        string parentName;

        HtmlAttribute attribute = null;

        public int ImageIndex
        {
            get
            {
                int index = HtmlCompletionClass.GetHtmlValueImageIndex(attribute.Values[0]);
                if (index > -1)
                    return index;

                return 31;
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
                return "<b>< "+parentName+" ></b><br>"+deprecated+attribute.Description;
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
            textArea.InsertString(attribute.Name);
            //LanguageBinding.QuickTemplate.InsertQuickTemplate("=", textArea.Caret.Offset, QuickletEngine.HtmlTemplateList, false);
            
            return true;
        }

        public HtmlAttributeCompletionData(HtmlAttribute attribute, string parentName)
        {
            this.attribute = attribute;
            this.parentName = parentName;
            if (attribute.IsDeprecated)
                deprecated = "[<i>"+MainForm.rm.GetString("deprecated")+"</i>] ";
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
