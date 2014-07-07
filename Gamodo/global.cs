using System.Windows.Forms;
using Gamodo.Config;

namespace Gamodo
{
	public class global
	{
		// Editor
		static public string textChanged = "geändert";

		static public string overwriteMode = "Überschreiben";
		static public string insertMode = "Einfügen";

		// Programm Informationen
		static public string appName = Application.ProductName;
		static public string appVer = "0.1";
		static public string appNameVer = appName+ " v"+appVer;

        static public string htmlDef = ConfigClass.Config.GetSettingValue("language")+"\\html4.01_def.xml";
	}
}
