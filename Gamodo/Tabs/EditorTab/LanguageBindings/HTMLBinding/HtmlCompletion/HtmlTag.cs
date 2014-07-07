﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gamodo.Tabs.EditorTab.LanguageBindings.HtmlCompletion
{
    public class HtmlTag
    {
        string name;
        string description;

        bool hasEndTag = false;
        bool hasCoreAttributes = false;
        bool hasCoreEvents = false;
        bool hasI18n = false;

        List<HtmlAttribute> attributeList = null;

        public List<HtmlAttribute> AttributeList
        {
            get { return attributeList; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
        }

        public bool HasEndTag
        {
            get { return hasEndTag; }
        }

        public bool HasCoreAttributes
        {
            get { return hasCoreAttributes; }
        }

        public bool HasCoreEvents
        {
            get { return hasCoreEvents; }
        }

        public bool HasI18n
        {
            get { return hasI18n; }
        }

        public HtmlTag()
        {
        }

        public HtmlTag(string name, string description, bool hasEndTag = false, bool hasCoreAttributes = false, bool hasCoreEvents = false)
        {
            this.name = name;
            this.description = description;
            this.hasEndTag = hasEndTag;
            this.hasCoreAttributes = hasCoreAttributes;
            this.hasCoreEvents = hasCoreEvents;
        }

        public void AddName(string name)
        {
            this.name = name;
        }

        public void AddDescription(string description)
        {
            this.description = description;
        }

        public void AddHasEndTag(bool hasEndTag)
        {
            this.hasEndTag = hasEndTag;
        }

        public void AddHasCoreAttributes(bool hasCoreAttributes)
        {
            this.hasCoreAttributes = hasCoreAttributes;
        }

        public void AddHasCoreEvents(bool hasCoreEvents)
        {
            this.hasCoreEvents = hasCoreEvents;
        }

        public void AddHasI18n(bool hasI18n)
        {
            this.hasI18n = hasI18n;
        }

        public void AddAttribute(HtmlAttribute htmlAttribute)
        {
            if (attributeList == null)
                attributeList = new List<HtmlAttribute>();

            attributeList.Add(htmlAttribute);
        }
    }
}
