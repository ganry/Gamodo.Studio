using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gamodo.Tabs.EditorTab.Parser
{
    public class CssDocument: AbstractDocument
    {
        private ActiveWare.CSS.CSSDocument cssDoc = new ActiveWare.CSS.CSSDocument();
        private static ActiveWare.CSS.CSSParser parser = new ActiveWare.CSS.CSSParser();

        public ActiveWare.CSS.CSSDocument ParsedFile
        {
            get { return cssDoc; }
            set { cssDoc = value; }
        }

        public CssDocument(string fileName)
        {
            this.fileName = fileName;
        }

        public void ParseDocument(string text)
        {
            parser.ParseText(text);
            cssDoc = parser.CSSDocument;
        }

        private void generateClassIdList()
        {
            foreach (var item in cssDoc.RuleSets)
            {
                
            }
        }
    }
}
