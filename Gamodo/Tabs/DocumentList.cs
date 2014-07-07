using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gamodo.Tabs
{
    public static class DocumentList
    {
        private static List<AbstractDocument> documentList = new List<AbstractDocument>();

        public static void AddDocument(AbstractDocument doc)
        {
            documentList.Add(doc);
        }

        public static void RemoveDoc(AbstractDocument doc)
        {
            documentList.Remove(doc);
        }

        public static void RemoveDoc(string fileName)
        {
            foreach (var item in documentList)
            {
                if (item.FileName == fileName)
                    documentList.Remove(item);
            }
        }

        public static AbstractDocument GetDocument(string fileName)
        {
            foreach (var item in documentList)
            {
                if (item.FileName == fileName)
                    return item;
            }
            return null;
        }
    }
}
