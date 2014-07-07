using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using HtmlAgilityPack;
using ICSharpCode.TextEditor;
using Gamodo.Editor;
using Gamodo.Tabs.EditorTab.Quicklet;
using Gamodo.Tabs.Interface;
using Gamodo.Tabs.EditorTab.LanguageBindings;
using Gamodo.Tabs.EditorTab.LanguageBindings.HtmlCompletion;

using Gamodo.Tabs.EditorTab.Tools;
using Gamodo.Tabs.EditorTab.Parser;

namespace Gamodo.Tabs.EditorTab.LanguageBindings
{
    public class LanguageBinding: IDisposable
    {
        private Stopwatch stopWatch = null;
        private EditorTab editorTab;
        
        private bool canParseFolding = false;
        private bool canParseCode = false;

        public PHPLanguageBinding PHPBinding;
        public HTMLLanguageBinding HTMLBinding;
        public JSLanguageBinding JSBinding;
        public CSSLanguageBinding CSSBinding;
        public static QuickletEngine QuickTemplate = null;

        public static HtmlCompletionClass HtmlCompletion;

        public static HtmlParserClass HTMLParser = new HtmlParserClass(MainForm.mainForm.codeBrowser.codeBrowserControl);
        public static CssParser CSSParser = new CssParser(MainForm.mainForm.codeBrowser.codeBrowserControl);
        public ParserClass parser = new ParserClass();

        #region ctor
        public LanguageBinding(EditorTab editorTab)
        {
            this.editorTab = editorTab;
            stopWatch = new Stopwatch();
            editorTab.editor.TextChanged += new EventHandler(editor_TextChanged);
            editorTab.editor.Caret.PositionChanged += new EventHandler(Caret_PositionChanged);
            editorTab.editor.OnHighlighterChangedHandler += new HighlighterChangedEventHandler(editor_OnHighlighterChangedHandler);
            editorTab.editor.ActiveTextAreaControl.TextArea.KeyPress += new KeyPressEventHandler(TextArea_KeyPress);
            Application.Idle += new EventHandler(Application_Idle);

            #region Create Language bindings
            PHPBinding = new PHPLanguageBinding(editorTab.editor);
            HTMLBinding = new HTMLLanguageBinding(editorTab.editor);
            JSBinding = new JSLanguageBinding(editorTab.editor);
            CSSBinding = new CSSLanguageBinding(editorTab.editor);
            #endregion

            HtmlCompletion = new HtmlCompletionClass(editorTab.editor);
            QuickTemplate = new QuickletEngine();

            //Aktiviert das richtige Binding
            editor_OnHighlighterChangedHandler(null, new HighlighterChangedEventArgs(editorTab.editor.DocLanguage));

            if (editorTab.editor.Document.FoldingManager.FoldingStrategy != null)
                editorTab.editor.Document.FoldingManager.UpdateFoldings(null, null);
        }
#endregion

        #region Functions called after Highlighter changed
        #region SelectLanguageTab
        private void selectLanguageTab(DocumentLanguage docLang)
        {
            
            switch (docLang)
            {
                case DocumentLanguage.PHP:
                    if (editorTab.languageHelp.SelectedTabPageIndex != 1)
                    {
                        editorTab.languageHelp.SelectedTabPageIndex = 1;
                        editorTab.editor.Focus();
                    }
                    break;
                case DocumentLanguage.HTML:
                    if (editorTab.languageHelp.SelectedTabPageIndex != 0)
                    {
                        editorTab.languageHelp.SelectedTabPageIndex = 0;
                        editorTab.editor.Focus();
                    }
                    break;
                case DocumentLanguage.CSS:
                    if (editorTab.languageHelp.SelectedTabPageIndex != 2)
                    {
                        editorTab.languageHelp.SelectedTabPageIndex = 2;
                        editorTab.editor.Focus();

                    }
                    break;
                case DocumentLanguage.JavaScript:
                    if (editorTab.languageHelp.SelectedTabPageIndex != 3)
                    {
                        editorTab.languageHelp.SelectedTabPageIndex = 3;
                        editorTab.editor.Focus();
                    }
                    break;
                default:
                    break;
            }
             
        }
        #endregion

        #region SetBinding
        private void setBinding(DocumentLanguage docLang)
        {
            switch (docLang)
            {
                case DocumentLanguage.PHP:
                    PHPBinding.SetBinding();

                    HtmlCompletion.HandleKey(false);
                    break;
                case DocumentLanguage.HTML:
                    HTMLBinding.SetBinding();

                    HtmlCompletion.HandleKey(true);
                    break;
                case DocumentLanguage.CSS:
                    CSSBinding.SetBinding();

                    HtmlCompletion.HandleKey(false);
                    break;
                case DocumentLanguage.JavaScript:
                    JSBinding.SetBinding();

                    HtmlCompletion.HandleKey(true);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Event HighlighterChanged
        void editor_OnHighlighterChangedHandler(object sender, HighlighterChangedEventArgs e)
        {
            setBinding(e.DocLang);
            selectLanguageTab(e.DocLang);
        }
        #endregion
        #endregion

        #region Parser & Folding related functions
        private void updateTimer()
        {
            canParseCode = true;
            canParseFolding = true;
            if (stopWatch.IsRunning)
            {
                stopWatch.Stop();
                stopWatch.Reset();
            }
            stopWatch.Start();
        }

        private void mustUpdateFoldings()
        {
            if (canParseFolding)
            {
                if (stopWatch.ElapsedMilliseconds > 1200)
                {
                    canParseFolding = false;
                    if (editorTab.editor.Document.FoldingManager.FoldingStrategy != null)
                    {
                        editorTab.editor.Document.FoldingManager.UpdateFoldings(null, null);
                        editorTab.editor.Refresh();
                    }
                }
            }
        }

        private void mustParse()
        {
            if (canParseCode)
            {
                if (stopWatch.ElapsedMilliseconds > 1200)
                {
                    canParseCode = false;
                    Parse();
                }
            }
        }

        public void Parse()
        {
            switch (HighlighterUtils.GetDocumentLanguageFromHighlighter(editorTab.editor))
            {
                case DocumentLanguage.HTML:
                    ParserClass.HtmlParser.Parse(editorTab.editor.FileName, editorTab.editor.Text, true, MainForm.mainForm.codeBrowser.codeBrowserControl);
                    //LanguageBinding.HTMLParser.Parse(editorTab.editor.Text);
                    if (HTMLParser.StyleNodes != null)
                    {
                        foreach (var item in LanguageBinding.HTMLParser.StyleNodes)
                        {
                            HtmlNode styleNode = (item.Object as HtmlNode);
                            LanguageBinding.CSSParser.Parse(styleNode.InnerText, item);
                        }

                    }
                    break;
                case DocumentLanguage.CSS:
                    LanguageBinding.CSSParser.Parse(editorTab.editor.Text);
                    break;
            }
        }

        public static void ClearAll()
        {
            LanguageBinding.HTMLParser.ClearAll();
            LanguageBinding.CSSParser.ClearAll();
        }
#endregion

        #region Application Idle
        void Application_Idle(object sender, EventArgs e)
        {
            if (MainForm.mainForm.ActiveDocumentTab != null)
                if (MainForm.mainForm.ActiveDocumentTab is EditorTab)
                    if ((MainForm.mainForm.ActiveDocumentTab as EditorTab) == editorTab)
                    {
                        mustUpdateFoldings();
                        mustParse();
                    }
                    else
                        canParseCode = false;
        }
        #endregion

        #region DoProcessDialogKey
        public bool DoProcessDialogKey(Keys keyData)
        {
            bool[] results = new bool[2];
            results[0] = QuickTemplate.TextArea_DoProcessDialogKey(keyData, editorTab.editor);
            results[1] = HtmlCompletion.TextArea_DoProcessDialogKey(keyData);

            foreach (var item in results)
            {
                if (item == true)
                    return true;
            }
            return false;
        }
        #endregion

        #region event handling
        void Caret_PositionChanged(object sender, EventArgs e)
        {
            QuickTemplate.Caret_PositionChanged(editorTab.editor);
        }

        void editor_TextChanged(object sender, EventArgs e)
        {
            updateTimer();
        }

        void TextArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '"':
                    QuickTemplate.InsertString("\"$end$", editorTab.editor.Caret.Offset, editorTab.editor);
                    break;
                case '\'':
                    QuickTemplate.InsertString("'$end$", editorTab.editor.Caret.Offset, editorTab.editor);
                    break;
                case '(':
                    QuickTemplate.InsertString(")$end$", editorTab.editor.Caret.Offset, editorTab.editor);
                    break;
            }
        }
        #endregion

        public void Dispose()
        {
            Application.Idle -= editor_TextChanged;
            stopWatch = null;
            PHPBinding = null;
            HTMLBinding.Dispose();
        }
    }
}
