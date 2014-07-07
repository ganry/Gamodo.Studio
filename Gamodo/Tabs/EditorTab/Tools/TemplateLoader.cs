using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Gamodo.Editor;
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

        private static void moveCaret(EditorControl edit, bool scrollToBeginning = false)
        {
            int off = -1;
            TextLocation tl;
            off = edit.Document.TextContent.IndexOf(CURSOR);
            if (off > -1)
            {
                edit.Document.Remove(off, CURSOR.Length);
                tl = edit.Document.OffsetToPosition(off);
                edit.ActiveTextAreaControl.Caret.Position = tl;
                if (scrollToBeginning)
                    edit.ActiveTextAreaControl.ScrollTo(0);
            }
        }
        /// <summary>
        /// Öffnet eine Template Datei
        /// </summary>
        /// <param name="fileName">Die zu ladende Template Datei</param>
        /// <param name="edit">Das EditControl in das, das Template, geladen werden soll</param>
        public static void LoadTemplateFromFile(string fileName, EditorControl edit)
        {
            edit.LoadFile(fileName, true, true);
            edit.FileName = null;
            edit.Document.TextContent = replaceConstants(edit.Document.TextContent);
            moveCaret(edit, true);
        }

        /// <summary>
        /// Fügt das übergebene Codefragment in den Editor ein
        /// </summary>
        /// <param name="text">Das einzufügende Codefragment</param>
        /// <param name="edit">Das EditControl in das eingefügt werden soll</param>
        public static void InsertString(string text, EditorControl edit)
        {
            string selectedText = edit.ActiveTextAreaControl.SelectionManager.SelectedText;
            text = text.Replace(SELECTEDTEXT, selectedText);
            edit.ActiveTextAreaControl.SelectionManager.ClearSelection();
            edit.ActiveTextAreaControl.SelectionManager.RemoveSelectedText();

            edit.Document.Insert(edit.Caret.Offset, text);
            moveCaret(edit);
        }

        public static void WrapWithCode(string text, EditorControl edit)
        {
            InsertString(text, edit);
        }
    }
}
