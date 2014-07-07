using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCompletition
{
    public class HtmlAttribute
    {
        string name;
        string description;
        string values;

        bool isDeprecated = false;

        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
        }

        public string Values
        {
            get { return values; }
        }

        public bool IsDeprecated
        {
            get { return isDeprecated; }
        }

        public HtmlAttribute()
        {
        }

        public HtmlAttribute(string name, string description, string values, bool isDeprecated = false)
        {
            this.name = name;
            this.description = description;
            this.values = values;
            this.isDeprecated = isDeprecated;
        }

        public void AddName(string name)
        {
            this.name = name;
        }

        public void AddDescription(string description)
        {
            this.description = description;
        }

        public void AddValues(string values)
        {
            this.values = values;
        }

        public void AddIsDeprecated(bool isDeprecated)
        {
            this.isDeprecated = isDeprecated;
        }
    }
}
