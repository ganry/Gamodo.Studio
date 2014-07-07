using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using Gamodo.Editor;
using Gamodo.Tabs.EditorTab.Quicklet;
using System.Diagnostics;


namespace Gamodo.Tabs.EditorTab.LanguageBindings.HtmlCompletion
{
    public class HtmlCompletionClass
    {
        static HtmlCompletionDataProvider htmlDataProvider;
        CodeCompletionWindow windowHtml = null;

        private EditorControl editor;
        private bool handleKey = false;

        public HtmlCompletionClass(EditorControl edit)
        {
            this.editor = edit;
            htmlDataProvider = new HtmlCompletionDataProvider();
            htmlDataProvider.imageList = MainForm.mainForm.imgHtmlCompletion;

            //editor.ActiveTextAreaControl.TextArea.DoProcessDialogKey += new DialogKeyProcessor(TextArea_DoProcessDialogKey);
            editor.ActiveTextAreaControl.TextArea.KeyPress += new KeyPressEventHandler(TextArea_KeyPress);
            editor.ActiveTextAreaControl.TextArea.MouseWheel += new MouseEventHandler(TextArea_MouseWheel);
        }

        #region DoProcessDialogKey
        public bool TextArea_DoProcessDialogKey(Keys keyData)
        {
            if (keyData == (Keys.Space | Keys.Control))
            {
                string tagBeforeCaret = getHtmlTagAtCaret(editor.ActiveTextAreaControl.TextArea);
                string html = GetHTMLTag(editor.ActiveTextAreaControl.TextArea);
                string attribute = String.Empty;

                //string html = GetHTMLTag(editor.ActiveTextAreaControl.TextArea);
                if (tagBeforeCaret != String.Empty && tagBeforeCaret != "<")
                    windowHtml = CodeCompletionWindow.ShowCompletionWindow(MainForm.mainForm, editor, global.htmlDef, htmlDataProvider, '<', tagBeforeCaret);
                else if (tagBeforeCaret == "<")
                    windowHtml = CodeCompletionWindow.ShowCompletionWindow(MainForm.mainForm, editor, global.htmlDef, htmlDataProvider, '<');
                else if (html != String.Empty)
                {
                    attribute = GetAttribute(editor.ActiveTextAreaControl.TextArea);
                    string attributeAtCaret = getWordBeforeCaret();
                    char charTyped = '\0';
                    if (attribute != string.Empty)
                    {
                        html += "|" + attribute;
                        charTyped = '"';
                    }
                    else if (attributeAtCaret != string.Empty)
                    {
                        html += "|" + attributeAtCaret;
                        charTyped = ' ';
                    } else
                        charTyped = ' ';

                    windowHtml = ShowAttributeList(windowHtml, editor, charTyped, html);
                }


                return true;
            }
            return false;
        }
        #endregion

        void TextArea_MouseWheel(object sender, MouseEventArgs e)
        {
            if (windowHtml != null && windowHtml.Visible)
            {
                windowHtml.HandleMouseWheel(e);
            }
            
        }

        public void HandleKey(bool value)
        {
            handleKey = value;
        }

        #region private functions

        #region getWordBeforeCaret
        private string getWordBeforeCaret()
        {
            string s;
            TextLocation tl = editor.Caret.Position;
            if (tl.Column > 0)
            {
                tl.Column -= 1;
                s = TextUtilities.GetWordAt(editor.Document, editor.Document.PositionToOffset(tl));
            } else
                s = TextUtilities.GetWordAt(editor.Document, editor.Caret.Offset);
            return s;
        }
        #endregion

        #region getHtmlTagAtCaret
        private string getHtmlTagAtCaret(TextArea area)
        {
            int beginOffset = area.Caret.Column;
            string text = TextUtilities.GetLineAsString(area.Document, area.Caret.Line);
            for (int i = beginOffset - 1; i > -1; i--)
            {
                switch (text[i])
                {
                    case ' ':
                        return String.Empty;
                    case '<':
                            int startIndex = i;
                            string htmlTag = String.Empty;

                            if (startIndex + 1 == beginOffset)
                                htmlTag = "<";
                            else
                            {
                                for (int x = startIndex + 1; x < beginOffset; x++)
                                {
                                    if (!Char.IsWhiteSpace(text[x]))
                                        htmlTag += text[x];
                                    else
                                    {
                                        return htmlTag;
                                    }
                                }
                            }

                            return htmlTag;
                    case '>':
                        if (i != 0)
                        {
                            return String.Empty;
                        }
                        break;
                    default:
                        break;
                }
            }
            return String.Empty;
        }
        #endregion

        #region GetHtmlTag
        private string GetHTMLTag(TextArea area)
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
        #endregion

        #region GetHtmlImageIndex
        public static int GetHtmlImageIndex(string tag)
        {
            switch (tag)
            {
                case "h1":
                    return 1;

                case "h2":
                    return 2;

                case "h3":
                    return 3;

                case "h4":
                    return 4;

                case "h5":
                    return 5;

                case "h6":
                    return 6;

                case "b":
                    return 7;

                case "i":
                    return 8;

                case "u":
                    return 9;

                case "ul":
                    return 10;

                case "ol":
                    return 11;

                case "li":
                    return 12;

                case "table":
                    return 13;

                case "img":
                    return 14;

                case "a":
                    return 15;

                case "div":
                    return 16;

                case "span":
                    return 17;

                case "form":
                    return 18;

                case "hr":
                    return 19;

                case "input":
                    return 20;

                case "center":
                    return 21;

                case "font":
                    return 22;

                case "html":
                    return 23;

                case "frameset":
                    return 24;

                case "script":
                    return 25;

                case "style":
                    return 36;

                case "sub":
                    return 27;

                case "sup":
                    return 28;

                case "strike":
                    return 29;

                case "iframe":
                    return 30;

                case "frame":
                    return 30;


                default:
                    return 0;
            }
        }
        #endregion

        #region GetHtmlValueImageIndex
        public static int GetHtmlValueImageIndex(string value)
        {
            switch (value)
            {
                case "<color>":
                    return 32;
                case "<event>":
                    return 35;
                case "<url>":
                    return 15;
                case "<style>":
                case "<class>":
                case "<id>":
                    return 36;
                default:
                    return -1;
            }
        }
        #endregion

        #region getAttributeAtCaret
        private string getAttributeAtCaret(TextArea area)
        {
            int beginOffset = area.Caret.Column;
            string lineText = TextUtilities.GetLineAsString(area.Document, area.Caret.Line);
            string attribute = string.Empty;

            for (int i = beginOffset -1; i > -1; i--)
            {
                if (Char.IsLetter(lineText[i]))
                {
                    attribute += lineText[i];
                }
                else if (Char.IsWhiteSpace(lineText[i]))
                    return attribute;
                else if (lineText[i] == '<')
                    return string.Empty;
                else if (lineText[i] == '>')
                    return string.Empty;
                else if (lineText[i] == '=')
                    return string.Empty;
                else if (lineText[i] == '\'')
                    return string.Empty;
                else if (lineText[i] == '"')
                    return string.Empty;
            }
            return string.Empty;
        }
        #endregion

        #region GetAttribute
        private static string GetAttribute(TextArea area)
        {
            int beginOffset = area.Caret.Column;
            string lineText = TextUtilities.GetLineAsString(area.Document, area.Caret.Line);
            string attribute = String.Empty;
            int counter = 0;

            for (int i = beginOffset - 1; i > -1; i--)
            {
                if (lineText[i] == '=')
                {
                    if (counter < 2)
                    {
                        TextLocation tl = area.Caret.Position;
                        tl.Column = i - 1;
                        attribute = TextUtilities.GetWordAt(area.Document, area.Document.PositionToOffset(tl));
                        return attribute;
                    }
                    else
                        return String.Empty;
                }
                else if (lineText[i] == '"')
                    counter++;
            }
            return attribute;
        }
        #endregion

        #region ShowAttributeList
        private CodeCompletionWindow ShowAttributeList(CodeCompletionWindow window, EditorControl editor, char keyChar, string tagName)
        {
            if (window != null && !window.Visible)
                return CodeCompletionWindow.ShowCompletionWindow(MainForm.mainForm, editor, global.htmlDef, htmlDataProvider, keyChar, tagName);
            else if (window == null)
                return CodeCompletionWindow.ShowCompletionWindow(MainForm.mainForm, editor, global.htmlDef, htmlDataProvider, keyChar, tagName);

            return window;
        }
        #endregion

        #endregion


        void TextArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (handleKey)
            {
                if (e.KeyChar == '<')
                {
                    e.KeyChar = '\0';
                    editor.Document.Insert(editor.Caret.Offset, "<");
                    editor.Caret.Position = editor.Document.OffsetToPosition(editor.Caret.Offset + 1);
                    string html = GetHTMLTag(editor.ActiveTextAreaControl.TextArea);
                    if (html == String.Empty)
                        windowHtml = CodeCompletionWindow.ShowCompletionWindow(MainForm.mainForm, editor, global.htmlDef, htmlDataProvider, '<');

                }
                else if (Char.IsWhiteSpace(e.KeyChar))
                {

                    string html = GetHTMLTag(editor.ActiveTextAreaControl.TextArea);
                    string attribute = String.Empty;
                    attribute = GetAttribute(editor.ActiveTextAreaControl.TextArea);

                    e.KeyChar = '\0';
                    editor.Document.Insert(editor.Caret.Offset, " ");
                    editor.Caret.Position = editor.Document.OffsetToPosition(editor.Caret.Offset + 1);

                    if ((html != String.Empty) && (attribute == string.Empty))
                    {
                        windowHtml = ShowAttributeList(windowHtml, editor, ' ', html);
                    }
                }
                else if (e.KeyChar == '"')
                {
                    string html = GetHTMLTag(editor.ActiveTextAreaControl.TextArea);
                    string attribute = String.Empty;
                    if (html != String.Empty)
                    {
                        attribute = GetAttribute(editor.ActiveTextAreaControl.TextArea);
                        html += "|" + attribute;
                    }
                    e.KeyChar = '\0';
                    editor.Document.Insert(editor.Caret.Offset, "\"");
                    editor.Caret.Position = editor.Document.OffsetToPosition(editor.Caret.Offset + 1);
                    if (attribute != string.Empty)
                        windowHtml = ShowAttributeList(windowHtml, editor, '"', html);
                }
            }
        }
    }
}
