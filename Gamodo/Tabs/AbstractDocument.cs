using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gamodo.Tabs
{
    public abstract class AbstractDocument
    {
        protected string fileName;
        public string FileName
        {
            get { return fileName; }
        }

        public void ChangeFileName(string newFileName)
        {
            this.fileName = newFileName;
        }
    }
}
