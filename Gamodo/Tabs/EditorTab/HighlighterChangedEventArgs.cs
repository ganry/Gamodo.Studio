using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gamodo.Tabs.EditorTab
{
    public class HighlighterChangedEventArgs: EventArgs
    {
        private DocumentLanguage docLang;
        public DocumentLanguage DocLang
        {
            get { return docLang; }
        }

        public HighlighterChangedEventArgs(DocumentLanguage docLang)
        {
            this.docLang = docLang;
        }
    }
}
