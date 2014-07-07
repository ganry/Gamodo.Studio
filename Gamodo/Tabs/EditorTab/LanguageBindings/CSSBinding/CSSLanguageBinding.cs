using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gamodo.Editor;
using ICSharpCode.TextEditor.Document;
using Gamodo.Tabs.EditorTab.LanguageBindings;

namespace Gamodo.Tabs.EditorTab.LanguageBindings
{
    public class CSSLanguageBinding: IDisposable
    {
        IFormattingStrategy cssFormatting = null;
        IFoldingStrategy cssFolding = null;
        EditorControl editor;

        public CSSLanguageBinding(EditorControl edit)
        {
            editor = edit;
            cssFolding = new PHPFoldingStrategy();
            cssFormatting = new DefaultFormattingStrategy();
        }

        public void SetBinding()
        {
            if (!(editor.Document.FoldingManager.FoldingStrategy is PHPFoldingStrategy))
                editor.Document.FoldingManager.FoldingStrategy = cssFolding;

            if (!(editor.Document.FormattingStrategy is DefaultFormattingStrategy))
                editor.Document.FormattingStrategy = cssFormatting;
        }

        public void Dispose()
        {
            cssFolding = null;
            cssFormatting = null;
        }
    }
}
