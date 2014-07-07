using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gamodo.Tabs.EditorTab.Quicklet
{
    public class TemplateList: TemplateDefinitionList
    {
        public TemplateList()
        {

            this.LoadDefinationFile("templatelist.xml");
            /*

            #region JS Template


            //switch
            template =
                AddTemplateDefinition("switch", "switch ($expression$) {\n\tcase $value$:\n\tbreak;\n\t$end$\n}",
                2,
                DocumentLanguage.JavaScript);
            template.AddVariable("$expression$", "switch_on");
            template.AddVariable("$value$", "\"value\"");


            //try
            template =
                AddTemplateDefinition("try", "try {\n\t$end$\n} catch ($exception$) {\n\t\n}",
                1,
                DocumentLanguage.JavaScript);
            template.AddVariable("$exception$", "Err");

            //func
            template = AddTemplateDefinition("func", "function $name$($variable$) {\n\t$end$\n}",
                2,
                DocumentLanguage.JavaScript);
            template.AddVariable("$name$", "name");
            template.AddVariable("$variable$", "variable");
            #endregion
            */
        }
    }
}
