using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gamodo.Editor;
using ICSharpCode.TextEditor.Document;

namespace Gamodo.Tabs.EditorTab.Tools
{
    public class HighlighterUtils
    {
        #region Static functions to get the current Language
        public static DocumentLanguage GetDocumentLanguage(EditorControl editor)
        {
            IHighlightingStrategy highlighter = editor.Document.HighlightingStrategy;
            if (highlighter != null)
            {
                if (highlighter.Name == "JavaScript")
                    return DocumentLanguage.JavaScript;
                else if (highlighter.Name == "Cascading Style Sheet")
                    return DocumentLanguage.CSS;
                else if ((highlighter.Name == "HTML") || (highlighter.Name == "PHP"))
                {
                    DocumentLanguage docLang = LanguageFinder.GetLanguageFromSegment(editor.Document.GetLineSegmentForOffset(editor.Caret.Offset), editor);
                    return docLang;
                }
            }
            return DocumentLanguage.HTML;
        }

        public static DocumentLanguage GetDocumentLanguageFromHighlighter(EditorControl editor)
        {
            IHighlightingStrategy highlighter = editor.Document.HighlightingStrategy;
            if (highlighter != null)
            {
                if (highlighter.Name == "JavaScript")
                    return DocumentLanguage.JavaScript;
                else if (highlighter.Name == "Cascading Style Sheet")
                    return DocumentLanguage.CSS;
                else if (highlighter.Name == "HTML")
                    return DocumentLanguage.HTML;
                else if (highlighter.Name == "PHP")
                    return DocumentLanguage.PHP;
            }
            return DocumentLanguage.HTML;
        }
        #endregion
    }
}
