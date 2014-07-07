using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace Gamodo.Tabs.EditorTab.LanguageBindings.HtmlCompletion
{
    public class HtmlDefinitionReader
    {
        static List<HtmlAttribute> htmlCoreEvents = null;
        static List<HtmlAttribute> htmlCoreAttributes = null;
        static List<HtmlAttribute> htmlCoreI18n = null;

        private static void AddCore(HtmlTag htmlTag)
        {
            if (htmlTag.HasCoreEvents)
            {
                foreach (var item in htmlCoreEvents)
                {
                    htmlTag.AddAttribute(item);
                }
            }
            if (htmlTag.HasCoreAttributes)
            {
                foreach (var item in htmlCoreAttributes)
                {
                    htmlTag.AddAttribute(item);
                }
            }
            if (htmlTag.HasI18n)
            {
                foreach (var item in htmlCoreI18n)
                {
                    htmlTag.AddAttribute(item);
                }
            }
        }

        public static List<HtmlTag> ReadDefinition(string fileName)
        {
            List<HtmlTag> htmlTagList = new List<HtmlTag>();
            HtmlAttribute htmlCoreAttribute = null;
            bool isInCoreEvents = false, isInI18n = false, isInCoreAttributes = false;

            HtmlTag htmlTag = null;
            XmlTextReader reader = new XmlTextReader(fileName);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:

                        #region Core Events/Attributes
                        if (reader.Name == "coreevents")
                        {
                            htmlCoreEvents = new List<HtmlAttribute>();
                            isInCoreEvents = true;
                        }
                        else if (reader.Name == "i18n")
                        {
                            htmlCoreI18n = new List<HtmlAttribute>();
                            isInI18n = true;
                        }
                        else if (reader.Name == "coreattributes")
                        {
                            htmlCoreAttributes = new List<HtmlAttribute>();
                            isInCoreAttributes = true;
                        }

                        if (isInCoreEvents || isInI18n || isInCoreAttributes)
                        {
                            if (reader.Name == "attribute")
                            {
                                htmlCoreAttribute = new HtmlAttribute();
                                    while (reader.MoveToNextAttribute())
                                    {
                                        switch (reader.Name)
                                        {
                                            case "name":
                                                htmlCoreAttribute.AddName(reader.Value);
                                                break;

                                            case "description":
                                                htmlCoreAttribute.AddDescription(reader.Value);
                                                break;

                                            case "values":
                                                htmlCoreAttribute.AddValues(reader.Value.Split('|'));
                                                break;
                                        }
                                    }

                                    if (isInCoreEvents)
                                        htmlCoreEvents.Add(htmlCoreAttribute);
                                    else if (isInI18n)
                                        htmlCoreI18n.Add(htmlCoreAttribute);
                                    else if (isInCoreAttributes)
                                        htmlCoreAttributes.Add(htmlCoreAttribute);
                                }
                            }
                        #endregion

                        #region HtmlTags
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

                                    case "i18n":
                                        htmlTag.AddHasI18n(reader.Value == "true" ? true : false);
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
                            AddCore(htmlTag);
                        }
                        #endregion

                        #region Html Attributes
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
                                            htmlAttribute.AddValues(reader.Value.Split('|'));
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
                    #endregion

                    case XmlNodeType.EndElement:
                        if (reader.Name == "coreevents")
                            isInCoreEvents = false;
                        else if (reader.Name == "i18n")
                            isInI18n = false;
                        else if (reader.Name == "coreattributes")
                            isInCoreAttributes = false;
                        break;
                }
            }
            htmlCoreEvents = null;
            htmlCoreI18n = null;
            htmlCoreAttributes = null;
            return htmlTagList;
        }
    }
}
