using System.Windows.Forms;
using Gamodo.Config;

namespace Gamodo
{
	public class global
	{
		// Editor
		static public string textChanged = "ge�ndert";

		static public string overwriteMode = "�berschreiben";
		static public string insertMode = "Einf�gen";

		// Programm Informationen
		static public string appName = Application.ProductName;
		static public string appVer = "0.1";
		static public string appNameVer = appName+ " v"+appVer;

        static public string htmlDef = ConfigClass.Config.GetSettingValue("language")+"\\html4.01_def.xml";
	}
}
