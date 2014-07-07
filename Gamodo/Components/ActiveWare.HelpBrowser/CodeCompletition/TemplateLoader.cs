using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ICSharpCode.TextEditor;

namespace Gamodo.Tabs.EditorTab.Tools
{
    public class TemplateLoader
    {
        private const string CURSOR = "${cursor}";
        private const string SELECTEDTEXT = "${selectedText}";

        private const string AUTHOR = "${author}";
        private const string DATE = "${date}";
        private const string YEAR = "${year}";

        private static string replaceConstants(string text)
        {
            DateTime today = DateTime.Now;
            text = text.Replace(AUTHOR, SystemInformation.UserName);
            text = text.Replace(YEAR, today.ToString("yyyy"));
            text = text.Replace(DATE, today.ToString("yyyy-MM-dd"));
            return text;
        }

        private static void moveCaret(TextArea edit, bool scrollToBeginning = false)
        {
            int off = -1;
            TextLocation tl;
            off = edit.Document.TextContent.IndexOf(CURSOR);
            if (off > -1)
            {
                edit.Document.Remove(off, CURSOR.Length);
                tl = edit.Document.OffsetToPosition(off);
                edit.Caret.Position = tl;
                if (scrollToBeginning)
                    edit.ScrollTo(0);
            }
        }

        /// <summary>
        /// Fügt das übergebene Codefragment in den Editor ein
        /// </summary>
        /// <param name="text">Das einzufügende Codefragment</param>
        /// <param name="edit">Das EditControl in das eingefügt werden soll</param>
        public static void InsertString(string text, TextArea edit, int offset = 0)
        {
            string selectedText = edit.SelectionManager.SelectedText;
            text = text.Replace(SELECTEDTEXT, selectedText);
            edit.SelectionManager.ClearSelection();
            edit.SelectionManager.RemoveSelectedText();

            if (offset == 0)
                edit.Document.Insert(edit.Caret.Offset, text);
            else
                edit.Document.Insert(offset, text);
            moveCaret(edit);
        }
    }
}
