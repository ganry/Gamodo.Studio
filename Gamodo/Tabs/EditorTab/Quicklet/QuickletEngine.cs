using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gamodo.Editor;
using System.Windows.Forms;

using ICSharpCode.TextEditor.Document;
using Gamodo.Tabs.EditorTab.Tools;
using ICSharpCode.TextEditor;
using System.Text.RegularExpressions;
using System.Drawing;
using Gamodo.Tabs.EditorTab.Quicklet;

namespace Gamodo.Tabs.EditorTab.Quicklet
{
    
    public class QuickletEngine
    {
        private EditorControl tmpEditor = null;
        private TemplateDefinition currentTemplate = null;
        private QuickletMarker mouseEndPosition = null;
        private bool processTemplate = false;

        public static TemplateList TemplateList = new TemplateList();

        #region Properties
        public TemplateDefinition CurrentTemplate
        {
            get { return currentTemplate; }
            set
            {
                if (value != null)
                {
                    if (currentTemplate != null)
                    {
                        currentTemplate = null;
                    }
                }
                currentTemplate = value;
            }
        }
        #endregion

        private void ClearMarkers(EditorControl editor)
        {
            if (currentTemplate != null)
            currentTemplate.ClearMarkers(editor);
        }

        #region ctor
        public QuickletEngine()
        {
        }
        #endregion

        private void removeMouseEndPosition(EditorControl editor)
        {
            editor.Document.MarkerStrategy.RemoveMarker(mouseEndPosition);
            mouseEndPosition = null;
            editor.Refresh();
        }

        #region Public insert template function
        public void InsertString(string text, int offset, EditorControl editor)
        {
            if (mouseEndPosition != null)
            {
                removeMouseEndPosition(editor);
            }
            int indexOfEndMarker = text.IndexOf("$end$");
            if (indexOfEndMarker > -1)
            {
                text = text.Replace("$end$", "");
                TextLocation tl = editor.Document.OffsetToPosition(offset);
                tl.Column += indexOfEndMarker;

                editor.Document.Insert(offset, text);
                mouseEndPosition = new QuickletMarker(editor.Document.PositionToOffset(tl), 1, TextMarkerType.QuickMark, Color.Red, MainForm.rm.GetString("EndMarkerToolTip"));
                editor.Document.MarkerStrategy.AddMarker(mouseEndPosition);
            }
        }

        public bool InsertQuickTemplate(string shortcut, int offset, DocumentLanguage docLang, EditorControl editor,  bool removeWordBefore = true)
        {
            if (tmpEditor != null && tmpEditor != editor)
            {
                ClearMarkers(tmpEditor);
            }
            tmpEditor = editor;
            if (TemplateList != null)
            {
                CurrentTemplate = TemplateList.GetTemplateDefinition(shortcut, docLang);

                if (CurrentTemplate != null)
                {

                    if (removeWordBefore)
                    {
                        editor.Document.Remove(offset, shortcut.Length);
                        editor.Caret.Position = editor.Document.OffsetToPosition(offset);
                    }


                    processTemplate = CurrentTemplate.InsertTemplate(offset, editor);
                    if (!processTemplate)
                        CurrentTemplate = null;
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Events
        public bool TextArea_DoProcessDialogKey(Keys keyData, EditorControl editor)
        {
            if ((CurrentTemplate != null) && keyData == Keys.Enter)
            {
                foreach (var item in CurrentTemplate.List)
                {
                    if (item.HasChilds)
                    {
                        List<CopyMarker> copyMarkerList = CurrentTemplate.GetChildsOfParent(item.VariableName);
                        if (copyMarkerList.Count > 0)
                        {
                            string currentText = editor.Text.Substring(item.Expression.Offset, item.Expression.Length);
                            foreach (var copyItem in copyMarkerList)
                            {
                                //string copyText 
                                editor.Document.Remove(copyItem.Expression.Offset, copyItem.Expression.Length);
                                editor.Document.Insert(copyItem.Expression.Offset, currentText);
                            }
                        }
                    }
                }

                CurrentTemplate.GoToEndMarker(editor);
                ClearMarkers(editor);
                CurrentTemplate = null;
                processTemplate = false;
                return true;
            }
            if ((keyData == Keys.Tab) && (CurrentTemplate != null))
            {
                bool canSwitch = CurrentTemplate.SwitchBetweenExpressions(editor);

                if (canSwitch)
                    return canSwitch;
                else
                {
                    CurrentTemplate.GoToEndMarker(editor);
                    return true;
                }
            }
            else if (keyData == Keys.Tab)
            {
                if (mouseEndPosition != null)
                {
                    editor.Caret.Position = editor.Document.OffsetToPosition(mouseEndPosition.Offset);

                    removeMouseEndPosition(editor);
                    return true;
                }
                else
                {
                    int shortcutOffset = TextUtilities.FindPrevWordStart(editor.Document, editor.Caret.Offset);
                    string shortcut = TextUtilities.GetWordAt(editor.Document, shortcutOffset);
                    switch (HighlighterUtils.GetDocumentLanguage(editor))
                    {
                        case DocumentLanguage.PHP:
                            return InsertQuickTemplate(shortcut, shortcutOffset, DocumentLanguage.PHP, editor);;
                        case DocumentLanguage.JavaScript:
                            return InsertQuickTemplate(shortcut, shortcutOffset, DocumentLanguage.JavaScript, editor);
                    }
                    
                }
          }
                 
            return false;
        }


        public void Caret_PositionChanged(EditorControl editor)
        {
            if (tmpEditor != null && tmpEditor != editor)
            {
                ClearMarkers(tmpEditor);
            }

            if (mouseEndPosition != null)
            {
                TextLocation tl = editor.Document.OffsetToPosition(mouseEndPosition.Offset);
                
                if ((tl.Line != editor.Caret.Position.Line) || (editor.Caret.Position.Column >= tl.Column))
                    removeMouseEndPosition(editor);
            }

            if (processTemplate)
            {
                if (CurrentTemplate != null)
                {
                    ExpressionMarker expression = CurrentTemplate.GetExpressionMarkerAtPos(editor.Caret.Offset, editor);
                    if (expression != null)
                    {
                        expression.ReplaceExpressionMarker(editor);
                    }
                    else
                    {
                        ClearMarkers(editor);
                        CurrentTemplate = null;
                        processTemplate = false;
                    }
                }
            }
        }
        #endregion
    }
}
