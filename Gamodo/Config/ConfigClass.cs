using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Gamodo.Config
{
    public class ConfigClass
    {
        #region singleton
        private static ConfigClass config;
        private ConfigClass() { ReadSettings(); }

        public static ConfigClass Config
        {
            get
            {
                if (config == null)
                {
                    config = new ConfigClass();
                }
                return config;
            }
        }
        #endregion

        private string configFile = "settings.config";
        private List<string> historyFileList = new List<string>();
        private Dictionary<string, string> settingsList = new Dictionary<string, string>();

        public List<string> HistoryFileList
        {
            get { return historyFileList; }
        }

        /// <summary>
        /// generates the default data for settings
        /// </summary>
        private void generateDefaultData()
        {
            settingsList.Add("HistoryLimit", "10");
            settingsList.Add("WindowState", "2");
            settingsList.Add("skin", "blue");

            if (CultureInfo.InstalledUICulture.Name == "de-DE")
                settingsList.Add("language", "de-DE");
            else
                settingsList.Add("language", "EN");
        }

        #region Read/Save settings to xml
        public void SaveSettings()
        {
            XmlTextWriter xmlWriter = new XmlTextWriter(Application.StartupPath + "\\" + configFile,
                                                 System.Text.Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.WriteStartDocument(true);

            #region <gamodo>
            xmlWriter.WriteStartElement("gamodo");

            #region <settings>
            xmlWriter.WriteStartElement("settings");
            foreach (var item in settingsList)
            {
                xmlWriter.WriteElementString(item.Key, item.Value);
            }
            xmlWriter.WriteEndElement();
            #endregion

            #region <history>
            xmlWriter.WriteStartElement("history");

            int begin = -1;

            begin = historyFileList.Count - int.Parse(GetSettingValue("HistoryLimit"));
            if (begin < -1)
                begin = 0;

            for (int i = begin; i < historyFileList.Count; i++)
            {
                xmlWriter.WriteElementString("file", historyFileList[i]);
            }


            xmlWriter.WriteEndElement();
            #endregion

            xmlWriter.WriteEndElement();
            #endregion

            xmlWriter.Flush();
            xmlWriter.Close();
        }

        private void ReadSettings()
        {
            string config = Application.StartupPath+"\\"+configFile;

            if (File.Exists(config))
            {
                XmlTextReader reader = new XmlTextReader(config);
                bool isInHistory = false, isInSettings = false;
                if (reader == null)
                    return;
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:

                            if (reader.Name == "history")
                            {
                                isInHistory = true;
                            }
                            else if (reader.Name == "settings")
                            {
                                isInSettings = true;
                            }

                            if (isInSettings && (reader.Name != "settings"))
                            {
                                settingsList.Add(reader.Name, reader.ReadInnerXml());
                            }
                            else if (isInHistory)
                            {
                                if (reader.Name == "file")
                                {
                                    string item = reader.ReadInnerXml();
                                    historyFileList.Add(item);
                                }
                            }
                            break;

                        case XmlNodeType.EndElement:
                            if (reader.Name == "history")
                                isInHistory = false;
                            else if (reader.Name == "settings")
                                isInSettings = false;
                            break;
                    }
                }
            }
            else
                generateDefaultData();
        }
        #endregion

        #region Settings methods
        public string GetSettingValue(string name)
        {
                return settingsList[name];
        }

        public void SetSettingValue(string name, string value)
        {
            settingsList[name] = value;
        }
        #endregion

        #region File History
        public void AddHistoryItem(string fileName)
        {
            if (File.Exists(fileName))
            {
                historyFileList.Remove(fileName);
                historyFileList.Add(fileName);
            }
        }

        #endregion
    }
}
