using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace CodeCompletition
{
    public class HtmlDefinitionReader
    {
        public static List<HtmlTag> ReadDefinition(string fileName)
        {
            List<HtmlTag> htmlTagList = new List<HtmlTag>();

            HtmlTag htmlTag = null;
            XmlTextReader reader = new XmlTextReader(fileName);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "tag")
                        {
                            htmlTag = new HtmlTag();
                            while (reader.MoveToNextAttribute())
                            {
                                switch (reader.Name)
                                {
                                    case "name":
                                        htmlTag.AddName(reader.Value);
                                        break;

                                    case "description":
                                        htmlTag.AddDescription(reader.Value);
                                        break;

                                    case "coreevents":
                                        htmlTag.AddHasCoreEvents(reader.Value == "true" ? true : false);
                                        break;

                                    case "coreattributes":
                                        htmlTag.AddHasCoreAttributes(reader.Value == "true" ? true : false);
                                        break;

                                    case "endtag":
                                        htmlTag.AddHasEndTag(reader.Value == "R" ? true : false);
                                        break;
                                }
                                
                            }
                            htmlTagList.Add(htmlTag);
                        }

                        if (reader.Name == "attribute")
                        {
                            if (htmlTag != null)
                            {
                                HtmlAttribute htmlAttribute = new HtmlAttribute();
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "name":
                                            htmlAttribute.AddName(reader.Value);
                                            break;

                                        case "description":
                                            htmlAttribute.AddDescription(reader.Value);
                                            break;

                                        case "values":
                                            htmlAttribute.AddValues(reader.Value);
                                            break;

                                        case "deprecated":
                                            htmlAttribute.AddIsDeprecated(reader.Value == "true" ? true : false);
                                            break;
                                    }
                                }
                                htmlTag.AddAttribute(htmlAttribute);
                            }
                        }
                        break;
                }
            }
            return htmlTagList;
        }
    }
}
