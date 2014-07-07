using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;
using Gamodo.Editor;
using DrawingEx.ColorManagement;
using Gamodo.Tabs.EditorTab.Tools;
using System.Windows.Forms;

namespace Gamodo.Tabs.EditorTab.LanguageBindings.HtmlCompletion
{
    public class HtmlValueCompletionData : ICompletionData
    {
        string description;
        string attributeName;
        string value;

        public int ImageIndex
        {
            get
            {
                int index = HtmlCompletionClass.GetHtmlValueImageIndex(Text);
                if (index > -1)
                    return index;

                return 0;
            }

        }

        public string Text
        {
            get
            {
                return value;
            }

            set
            {
            }
        }

        public virtual string Description
        {
            get
            {
                return description;
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
            if (!value.StartsWith("<"))
                textArea.InsertString(value);
            else
            {
                if (value == "<color>")
                {
                    using (ColorDialogEx cd = new ColorDialogEx())
                    {
                        if (cd.ShowDialog() == DialogResult.OK)
                            textArea.InsertString(HTMLColorConverter.convertColorToHtmlHexColor(cd.Color));
                    }
                }
            }
            //LanguageBinding.QuickTemplate.InsertQuickTemplate("=", textArea.Caret.Offset, QuickletEngine.HtmlTemplateList, false);
            return true;
        }

        public HtmlValueCompletionData(string value, string attributeName)
        {
            this.value = value;
            this.attributeName = attributeName;
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
