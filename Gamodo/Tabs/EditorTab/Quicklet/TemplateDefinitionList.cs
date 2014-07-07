using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Gamodo.Tabs.EditorTab.Quicklet
{
    public class TemplateDefinitionList
    {
        List<TemplateDefinition> templates = new List<TemplateDefinition>();

        private string ReplaceLineBreak(string text)
        {
            return text.Replace("\\n", "\n").Replace("\\t", "\t");
        }

        public TemplateDefinition AddTemplateDefinition(string shortCut, string templateText, int variablesInText, DocumentLanguage docLang)
        {
            TemplateDefinition template = new TemplateDefinition(shortCut, templateText, variablesInText, docLang);
            templates.Add(template);
            return template;
        }

        public TemplateDefinition GetTemplateDefinition(string shortcut, DocumentLanguage docLang)
        {
            foreach (var item in templates)
            {
                if ((item.Shortcut == shortcut) && (item.DocLang == docLang))
                    return item;
            }
            return null;
        }

        public void LoadDefinationFile(string fileName)
        {
            XmlTextReader reader = new XmlTextReader(fileName);
            TemplateDefinition template = null;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:

                        if (reader.Name == "Template")
                        {
                            string shortCut = string.Empty;
                            string templateText = string.Empty;
                            int variablesInText = -1;
                            DocumentLanguage docLang = DocumentLanguage.NULL;

                            while (reader.MoveToNextAttribute())
                            {
                                switch (reader.Name)
                                {
                                    case "shortcut":
                                        shortCut = reader.Value;
                                        break;

                                    case "text":
                                        templateText = ReplaceLineBreak(reader.Value);
                                        break;

                                    case "variables":
                                        variablesInText = int.Parse(reader.Value);
                                        break;

                                    case "docLang":
                                        docLang = (DocumentLanguage)Enum.Parse(typeof(DocumentLanguage), reader.Value);
                                        Console.WriteLine(docLang.ToString());
                                        break;
                                }

                            }
                            template = AddTemplateDefinition(shortCut, templateText, variablesInText, docLang);
                        }

                        if (reader.Name == "Variable")
                        {
                            if (template != null)
                            {
                                string name = string.Empty;
                                string value = string.Empty;

                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "name":
                                            name = reader.Value;
                                            break;

                                        case "value":
                                            value = reader.Value;
                                            break;
                                    }
                                }
                                template.AddVariable(name, value);
                            }
                        }
                        break;




                    case XmlNodeType.EndElement:
                        break;
                }
            }
        }

        public void SaveDefinationFile(string fileName)
        {
        }
    }
}
