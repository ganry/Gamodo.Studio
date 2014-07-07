using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using System.Drawing;
using System.Windows.Forms;
using Gamodo.Tabs;
using Gamodo.Tabs.EditorTab;
using Gamodo.Tabs.EditorTab.Tools;

namespace Gamodo.Editor
{
    public delegate void HighlighterChangedEventHandler(object sender, HighlighterChangedEventArgs e);

    /// <summary>
    /// Zusammendfassende Beschreibung für EditControl.
    /// </summary>
    public class EditorControl : TextEditorControl
    {
        private DocumentLanguage docLang = DocumentLanguage.NULL;
        public TextAreaClipboardHandler clipboard;

        #region OnHighlighterChanged
        public event HighlighterChangedEventHandler OnHighlighterChangedHandler;
        public void OnHighlighterChanged(object sender, HighlighterChangedEventArgs e)
        {
            if (OnHighlighterChangedHandler != null)
                OnHighlighterChangedHandler(sender, e);
        }
        #endregion

        public DocumentLanguage DocLanguage
        {
            get { return docLang; }
        }

        public Caret Caret
        {
            get { return ActiveTextAreaControl.Caret; }
        }


        public EditorControl()
        {
            this.Encoding = System.Text.Encoding.Default;
            clipboard = ActiveTextAreaControl.TextArea.ClipboardHandler;
            ActiveTextAreaControl.Caret.PositionChanged += new EventHandler(Caret_PositionChanged);

            #region Editor Einstellungen
            this.ShowEOLMarkers = false;
            this.ShowHRuler = false;
            this.ShowInvalidLines = false;
            this.ShowSpaces = false;
            this.ShowTabs = false;
            this.ShowVRuler = false;
            this.ShowMatchingBracket = true;
            this.IsIconBarVisible = true;
            this.ConvertTabsToSpaces = true;
            this.ActiveTextAreaControl.TextArea.TextEditorProperties.EnableFolding = true;
            ActiveTextAreaControl.Document.TextEditorProperties.IndentStyle = ICSharpCode.TextEditor.Document.IndentStyle.Smart;
            #endregion
        }

        void Caret_PositionChanged(object sender, EventArgs e)
        {
            if (ActiveTextAreaControl.SelectionManager.SelectedText == "")
            {
                DocumentLanguage tmpLang = HighlighterUtils.GetDocumentLanguage(this);
                if (tmpLang != docLang)
                {
                    docLang = tmpLang;
                    OnHighlighterChanged(this, new HighlighterChangedEventArgs(docLang));
                }
            }
        }
    }
}
