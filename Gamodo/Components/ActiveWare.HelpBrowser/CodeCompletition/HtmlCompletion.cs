using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Gui.CompletionWindow;

namespace CodeCompletition
{
    public class HtmlCompletion
    {
        HtmlCompletionDataProvider htmlDataProvider;
        CodeCompletionWindow window = null;
        private TextArea textArea;

        public HtmlCompletion(TextArea textArea)
        {
            this.textArea = textArea;
            htmlDataProvider = new HtmlCompletionDataProvider();
            //htmlDataProvider.imageList = imageList1;

            textArea.KeyPress += new KeyPressEventHandler(TextArea_KeyPress);
        }

        public string GetHTMLTag(TextArea area)
        {
            int beginOffset = area.Caret.Offset;
            bool phpTagOpen = false;
            string text = area.Document.TextContent;
            for (int i = beginOffset - 1; i > -1; i--)
            {
                switch (text[i])
                {
                    case '<':
                        if (phpTagOpen)
                        {
                            if (text[i + 1] == '?')
                                phpTagOpen = false;
                        }
                        else
                        {
                            int startIndex = i;
                            string htmlTag = String.Empty;
                            for (int x = startIndex + 1; x < beginOffset; x++)
                            {
                                if (!Char.IsWhiteSpace(text[x]))
                                    htmlTag += text[x];
                                else
                                    return htmlTag;
                            }

                            return htmlTag;
                        }
                        break;
                    case '>':
                        if (i != 0)
                        {
                            if (text[i - 1] == '?')
                                phpTagOpen = true;
                            else
                                return String.Empty;
                        }
                        break;
                    default:
                        break;
                }
            }
            return String.Empty;
        }


        void TextArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Console.WriteLine(e.KeyChar);
            if (e.KeyChar == '<')
            {
                string html = GetHTMLTag(textArea.TextArea);
                if (html == String.Empty)
                    window = CodeCompletionWindow.ShowCompletionWindow(this, textEditorControl1, "html4.01_def.xml", test, '<');

            }
            else if (Char.IsLetter(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
            {
                string html = GetHTMLTag(textEditorControl1.ActiveTextAreaControl.TextArea);
                if (html != String.Empty)
                {
                    if (window != null && !window.Visible)
                        window = CodeCompletionWindow.ShowCompletionWindow(this, textEditorControl1, "html4.01_def.xml", test, e.KeyChar, html);

                }
            }
        }
    }
}
