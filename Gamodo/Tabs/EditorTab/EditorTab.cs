using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Gamodo.Editor;
using Gamodo.Tabs.Interface;
using Gamodo.Tabs.EditorTab.Tools;
using ICSharpCode.TextEditor.Document;
using System.IO;
using Gamodo.Tabs.EditorTab.LanguageBindings;
using Gamodo.UserInterface;
using Gamodo.Dialogs;
using HtmlHelp;
using Gamodo.Tabs.EditorTab.Quicklet;
using Gamodo.Config;

namespace Gamodo.Tabs.EditorTab
{
    public partial class EditorTab : DocumentBase, IBaseTab, ISaveAble, ICloseAble,
        IEditCommands
    {
        #region variablen
        public EditorControl editor = null;

        private bool modified = false;
        public LanguageBinding languageBinding;
        #endregion

        #region Eigenschaften
        public string Title
        {
            get
            {
                if (TabText.IndexOf('*') > -1)
                    return this.TabText.Remove(TabText.IndexOf('*'));
                return TabText;
            }
            set
            {
                this.TabText = value;
            }
        }

        public bool Modified
        {
            get { return modified; }
            set {
                if (value)
                {
                    if (Title.IndexOf('*') == -1)
                        Title += "*";
                }
                modified = value; 
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Standart Konstruktor, sollte nicht zur öffnung oder erstellung eines 
        /// Dokuments verwendet werden
        /// </summary>
        public EditorTab(MainForm mf)
        {
            InitializeComponent();
            this.Title = "";
            editor = new EditorControl();
            editor.Parent = panel1;
            editor.Visible = true;
            editor.Dock = DockStyle.Fill;
            
            
            editor.ActiveTextAreaControl.TextArea.KeyDown += new KeyEventHandler(TextArea_KeyDown);
            editor.ActiveTextAreaControl.TextArea.DoProcessDialogKey += new ICSharpCode.TextEditor.DialogKeyProcessor(TextArea_DoProcessDialogKey);
            editor.TextChanged += new EventHandler(editor_TextChanged);

            editor.BringToFront();
            editor.Focus();
        }
        #endregion

        //Dokument öffnen/erstellen
        #region Neues Dokument erstellen
        /// <summary>
        /// Erstellt ein leeres Dokument
        /// </summary>
        /// <param name="title">Der Titel des Tabs</param>
        /// <param name="docLanguage">Der Document Typ</param>
        public void CreateEmptyDocument(string title, DocumentLanguage docLanguage)
        {
            TabText = title;
            switch (docLanguage)
            {
                case DocumentLanguage.HTML:
                case DocumentLanguage.PHP:
                    editor.SetHighlighting("HTML");
                    break;
                case DocumentLanguage.CSS:
                    editor.SetHighlighting("CSS");
                    break;
                case DocumentLanguage.JavaScript:
                    editor.SetHighlighting("JavaScript");
                    break;
            }
            languageBinding = new LanguageBinding(this);
        }

        /// <summary>
        /// Erstellt ein neues Dokument und läd das Template
        /// </summary>
        /// <param name="title">Der TabText</param>
        /// <param name="TemplateFile">Das zu ladende Template</param>
        public void CreateNewDocumentWithTemplate(string title, string TemplateFile)
        {
            TabText = title;
            TemplateLoader.LoadTemplateFromFile(TemplateFile, editor);
            languageBinding = new LanguageBinding(this);
        }
        #endregion

        #region Dokument öffnen
        public void OpenFile(string fileName)
        {
            editor.LoadFile(fileName, true, true);
            languageBinding = new LanguageBinding(this);
            Title = Path.GetFileName(fileName);
            Modified = false;

            if (editor.Document.FoldingManager.FoldingStrategy != null)
                editor.Document.FoldingManager.UpdateFoldings(null, null);
        }
        #endregion

        //Interfaces
        #region ISaveAble
        public bool CanSave()
        {
            return Modified;
        }
        /// <summary>
        /// Speichert das aktuelle Dokument
        /// </summary>
        /// <returns>Liefert True wenn das speichern erfolgreich war</returns>
        public bool Save()
        {
            if (editor.FileName != null)
            {
                editor.SaveFile(editor.FileName);
                Modified = false;
                this.TabText = Title;
                return true;
            }
            else
                return SaveAs();
        }

        public bool SaveAs()
        {
            MainForm.mainForm.saveFileDialog.FileName = this.Title;

            if (MainForm.mainForm.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                editor.SaveFile(MainForm.mainForm.saveFileDialog.FileName);
                Title = Path.GetFileName(editor.FileName);
                editor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategyForFile(editor.FileName);
                Modified = false;

                ConfigClass.Config.AddHistoryItem(MainForm.mainForm.saveFileDialog.FileName);

                return true;
            }
            else
                return false;
        }
        #endregion

        #region IEditCommands
        private bool HaveSelection()
        {
            return editor.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected;
        }

        public bool CanCut()
        {
            return HaveSelection();
        }

        public bool CanCopy()
        {
            return HaveSelection();
        }

        public bool CanPaste()
        {
            return editor.clipboard.EnablePaste;
        }

        public bool CanRedo()
        {
            return true;
        }

        public bool CanUndo()
        {
            return true;
        }

        public void Cut()
        {
            editor.clipboard.Cut(this, new EventArgs());
        }

        public void Copy()
        {
            editor.clipboard.Copy(this, new EventArgs());
        }

        public void Paste()
        {
            editor.clipboard.Paste(this, new EventArgs());
        }

        public void Redo()
        {
            editor.Redo();
        }

        public void Undo()
        {
            editor.Undo();
        }
        #endregion

        #region ICloseAble
        public bool CanCloseTab()
        {
            string currentFile;
            if (Modified)
            {
                if (editor.FileName == null)
                    currentFile = Title;
                else
                    currentFile = Path.GetFileName(editor.FileName);

                switch (MessageBox.Show(string.Format(MainForm.rm.GetString("save"), currentFile, "\n"), global.appName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3))
                {
                    case DialogResult.Yes:
                        return Save();
                    case DialogResult.No:
                        Modified = false;
                        return true;
                    case DialogResult.Cancel:
                        return false;
                }
            }
            else
                return true;
            return false;
        }
        #endregion


        #region FunctionsTab
        #region HTML Page
        private void tbHTMLTable_Click(object sender, EventArgs e)
        {

        }

        private void tbHTMLForm_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<form action=\"${cursor}\" method=\"\" accept-charset=\"utf-8\">\n" +
                "<p><input type=\"submit\" value=\"Continue\" /></p>\n" +
                "</form>", editor);
        }

        private void tbHTMLDiv_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<div>${selectedText}${cursor}</div>", editor);
        }

        private void tbHTMLSpan_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<span>${selectedText}${cursor}</span>", editor);
        }

        private void tbHTMLP_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<p>${selectedText}${cursor}</p>", editor);
        }

        private void tbHTMLH1_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<h1>${selectedText}${cursor}</h1>", editor);
        }

        private void tbHTMLH2_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<h2>${selectedText}${cursor}</h2>", editor);
        }

        private void tbHTMLH3_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<h3>${selectedText}${cursor}</h3>", editor);
        }

        private void tbHTMLB_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<b>${selectedText}${cursor}</b>", editor);
        }

        private void tbHTMLI_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<i>${selectedText}${cursor}</i>", editor);
        }

        private void tbHTMLU_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<u>${selectedText}${cursor}</u>", editor);
        }

        private void tbHTMLLink_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<a href=\"${selectedText}\">${selectedText}${cursor}</a>", editor);
        }

        private void tbHTMLImage_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<img src=\"${selectedText}\" alt=\"${cursor}\">", editor);
        }

        private void tbHTMLBullet_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<ul>${selectedText}${cursor}</ul>", editor);
        }

        private void tbHTMLOL_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("<ol>${selectedText}${cursor}</ol>", editor);
        }
        #endregion

        #region PHP Page
        private void tbPHPComment_Click(object sender, EventArgs e)
        {
            tbJSComment_Click(sender, e);
        }

        private void tbPHPFunction_Click(object sender, EventArgs e)
        {
            LanguageBinding.QuickTemplate.InsertQuickTemplate("func", editor.Caret.Offset, DocumentLanguage.PHP, editor, false);
        }

        private void tbPHPClass_Click(object sender, EventArgs e)
        {
            LanguageBinding.QuickTemplate.InsertQuickTemplate("class", editor.Caret.Offset, DocumentLanguage.PHP, editor, false);
        }

        private void tbPHPFor_Click(object sender, EventArgs e)
        {
            LanguageBinding.QuickTemplate.InsertQuickTemplate("for", editor.Caret.Offset, DocumentLanguage.PHP, editor, false);
        }

        private void tbPHPIf_Click(object sender, EventArgs e)
        {
            LanguageBinding.QuickTemplate.InsertQuickTemplate("if", editor.Caret.Offset, DocumentLanguage.PHP, editor, false);
        }

        private void tbPHPTry_Click(object sender, EventArgs e)
        {
            LanguageBinding.QuickTemplate.InsertQuickTemplate("try", editor.Caret.Offset, DocumentLanguage.PHP, editor, false);
        }

        private void tbPHPSwitch_Click(object sender, EventArgs e)
        {
            LanguageBinding.QuickTemplate.InsertQuickTemplate("switch", editor.Caret.Offset, DocumentLanguage.PHP, editor, false);
        }
        #endregion

        #region CSS Page
        private void tbColorChooser_Click(object sender, EventArgs e)
        {
            if (colorDialogEx1.ShowDialog() == DialogResult.OK)
                TemplateLoader.InsertString(HTMLColorConverter.convertColorToHtmlHexColor(colorDialogEx1.Color), editor);
        }

        private void tbColorPicker_Click(object sender, EventArgs e)
        {
            DesktopColor dc = new DesktopColor();
            MainForm.mainForm.TopMost = true;
            dc.Show(this);  
        }
        #endregion

        #region JavaScript Page
        private void tbJSID_Click(object sender, EventArgs e)
        {
            AddCodeDialogTemplate codeDialog = new AddCodeDialogTemplate();
            codeDialog.lblDescription.Text = MainForm.rm.GetString("getElementIDDescription");
            if (codeDialog.ShowDialog() == DialogResult.OK)
            {
                TemplateLoader.InsertString("document.getElementById(\"" + codeDialog.tbxEntry.Text + "\")${cursor}", editor);
            }
            codeDialog.Dispose();
        }

        private void tbJSComment_Click(object sender, EventArgs e)
        {
            TemplateLoader.WrapWithCode("/*\n${selectedText}${cursor}\n*/", editor);
        }

        private void tbJSFunction_Click(object sender, EventArgs e)
        {
            LanguageBinding.QuickTemplate.InsertQuickTemplate("func", editor.Caret.Offset, DocumentLanguage.JavaScript, editor, false);
        }

        private void tbJSFor_Click(object sender, EventArgs e)
        {
            LanguageBinding.QuickTemplate.InsertQuickTemplate("for", editor.Caret.Offset, DocumentLanguage.JavaScript, editor, false);
        }

        private void tbJSIF_Click(object sender, EventArgs e)
        {
            LanguageBinding.QuickTemplate.InsertQuickTemplate("if", editor.Caret.Offset, DocumentLanguage.JavaScript, editor, false);
        }

        private void tbJSTry_Click(object sender, EventArgs e)
        {
            LanguageBinding.QuickTemplate.InsertQuickTemplate("try", editor.Caret.Offset, DocumentLanguage.JavaScript, editor, false);
        }

        private void tbJSSwitch_Click(object sender, EventArgs e)
        {
            LanguageBinding.QuickTemplate.InsertQuickTemplate("switch", editor.Caret.Offset, DocumentLanguage.JavaScript, editor, false);
        }
        #endregion
        #endregion

        protected override string GetPersistString()
        {
            // Add extra information into the persist string for this document
            // so that it is available when deserialized.
            return GetType().ToString() + "," + editor.FileName;
        }

        private void LoadPHPContextualHelp()
        {
            if (MainForm.mainForm.phpHelp != null)
            {
                IndexItem item = MainForm.mainForm.phpHelp.Index.SearchIndex(
                    TextUtilities.GetWordAt(editor.ActiveTextAreaControl.Document, editor.ActiveTextAreaControl.Caret.Offset - 1) + "?", IndexType.KeywordLinks);
                if (item != null)
                {
                    HelpBrowserTab helpBrowserTab = HelpBrowserDock.FindHelpTab();
                    if (helpBrowserTab == null)
                    {
                        helpBrowserTab = new HelpBrowserTab();
                    }
                    helpBrowserTab.Show(MainForm.mainForm.dockPanel);
                    helpBrowserTab.webBrowser.Navigate((item.Topics[0] as IndexTopic).URL);
                }
            }
        }

        #region Event Handling
        bool TextArea_DoProcessDialogKey(Keys keyData)
        {
            bool result = false;
            result = languageBinding.DoProcessDialogKey(keyData);
            //result = LanguageBinding.QuickTemplate.TextArea_DoProcessDialogKey(keyData, editor);
            //result = LanguageBinding.HtmlCompletion.TextArea_DoProcessDialogKey(keyData);
            return result;
        }

        void TextArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LoadPHPContextualHelp();
            }
        }

        void editor_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void EditorTab_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CanCloseTab();
        }

        private void EditorTab_FormClosed(object sender, FormClosedEventArgs e)
        {
            languageBinding.Dispose();
            editor.Dispose();
            GC.Collect();
        }
        #endregion
    }
}
