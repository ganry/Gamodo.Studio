using System;
using System.Drawing;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

namespace Gamodo.Tabs.EditorTab.Tools
{
    /// <summary>
	/// HTMLColorConverter: Convert html hexcode into System.Drawing.Color and back.
    /// </summary>
	public static class HTMLColorConverter
    {
        /// <summary>
		/// Convert html hexcode into System.Drawing.Color.
		/// If hexacode equals null or hexacode is empty or
		/// hexacodes length is greater or less 6 character
		/// return a empty color.
        /// </summary>
		/// <param name="hexacode">The hexadecimal string with # first char. or the color word (like: blue or red ...).</param>
        /// <returns>System.Drawing.Color</returns>
        public static Color convertHtmlHexColorToColor(String hexacode)
        {			
			if (hexacode.StartsWith("#"))
			{
				if (hexacode == null || hexacode.Equals("") || (hexacode.Replace("#", "").Length < 6) || (hexacode.Replace("#", "").Length > 6) )
					return Color.Empty;

				String rgbStr = hexacode;
				String rgb = "";
				rgbStr = rgbStr.Replace("#", "");

				char[] c = rgbStr.ToCharArray();
				for (int i = 0; i < c.Length; i++)
				{
					int intVal = Int32.Parse(c[i].ToString() + c[i + 1].ToString(), NumberStyles.HexNumber);
					rgb += intVal.ToString() + ",";
					i++;
				}

				rgb = rgb.Replace(",", " ");

				int r = Int32.Parse(rgb.Split(' ')[0].ToString());
				int g = Int32.Parse(rgb.Split(' ')[1].ToString());
				int b = Int32.Parse(rgb.Split(' ')[2].ToString());

				Color rgbColor = Color.FromArgb(r, g, b);
				return rgbColor;
			}
			else
			{
				List<String> colorList = getColorList();
				for (int i = 0; i < colorList.Count; i++)
				{
					String coloString = colorList[i].ToString().Split(',')[0].ToString().ToLower();
					if (coloString.Equals(hexacode.ToLower()))
					{
						String hexString = colorList[i].ToString().Split(',')[1].ToString();
						return convertHtmlHexColorToColor("#" + hexString);
					}
				}
			}

			return Color.Empty;
        }

        /// <summary>
		/// Convert System.Drawing.Color into html hexcode.
		/// If color equals null or color is empty return a empty string.
        /// </summary>
        /// <param name="color">System.Drawing.Color</param>
        /// <returns>HTML hexcode.</returns>
        public static String convertColorToHtmlHexColor(Color color)
        {
			try
			{
				if (color == null || color.IsEmpty)
					return "";

				double red = Double.Parse(color.R.ToString());
				double _red = 0.0;

				red = (red / 16);
				_red = (red - (int)red) * 16;

				double green = Double.Parse(color.G.ToString());
				double _green = 0.0;

				green = (green / 16);
				_green = (green - (int)green) * 16;

				double blue = Double.Parse(color.B.ToString());
				double _blue = 0.0;

				blue = (blue / 16);
				_blue = (blue - (int)blue) * 16;

				String hexString = "";
				hexString += "#" + convertIntToHex((int)red);
				hexString += convertIntToHex((int)_red);
				hexString += convertIntToHex((int)green);
				hexString += convertIntToHex((int)_green);
				hexString += convertIntToHex((int)blue);
				hexString += convertIntToHex((int)_blue);

				return hexString;
			}
            catch (Exception ex)
			{
				return "";
			}
        }

        /// <summary>
        /// Convert a Int32 to hexadecimal number
        /// </summary>
        /// <param name="hexNum">The hexadecimal</param>
        /// <returns>The correct hexadecimal number</returns>
        private static String convertIntToHex(int hexNum)
        {
            String hexString = "";
            switch (hexNum)
            {
                case 10:
                    hexString = "A";
                    break;
                case 11:
                    hexString = "B";
                    break;
                case 12:
                    hexString = "C";
                    break;
                case 13:
                    hexString = "D";
                    break;
                case 14:
                    hexString = "E";
                    break;
                case 15:
                    hexString = "F";
                    break;
                default:
                    hexString = "" + hexNum;
                    break;
            }
            return hexString;
        }

		/// <summary>
		/// Create a color list
		/// </summary>
		/// <returns>List with all availabel html colors</returns>
		private static List<String> getColorList()
		{
			List<String> colorList = new List<String>();

			colorList.Clear();

			colorList.Add("Black,000000");
			colorList.Add("AliceBlue,F0F8FF");
			colorList.Add("BlueViolet,8A2BE2");
			colorList.Add("CadetBlue,5F9EA0");
			colorList.Add("CadetBlue1,98F5FF");
			colorList.Add("CadetBlue2,8EE5EE");
			colorList.Add("CadetBlue3,7AC5CD");
			colorList.Add("CadetBlue4,53868B");
			colorList.Add("CornflowerBlue,6495ED");
			colorList.Add("DarkBlue,00008B");
			colorList.Add("DarkCyan,008B8B");
			colorList.Add("DarkSlateBlue,483D8B");
			colorList.Add("DarkTurquoise,00CED1");
			colorList.Add("DeepSkyBlue,00BFFF");
			colorList.Add("DeepSkyBlue1,00BFFF");
			colorList.Add("DeepSkyBlue2,00B2EE");
			colorList.Add("DeepSkyBlue3,009ACD");
			colorList.Add("DeepSkyBlue4,00688B");
			colorList.Add("DodgerBlue,1E90FF");
			colorList.Add("DodgerBlue1,1E90FF");
			colorList.Add("DodgerBlue2,1C86EE");
			colorList.Add("DodgerBlue3,1874CD");
			colorList.Add("DodgerBlue4,104E8B");
			colorList.Add("LightBlue,Add8E6");
			colorList.Add("LightBlue1,BFEFFF");
			colorList.Add("LightBlue2,B2DFEE");
			colorList.Add("LightBlue3,9AC0CD");
			colorList.Add("LightBlue4,68838B");
			colorList.Add("LightCyan,E0FFFF");
			colorList.Add("LightCyan1,E0FFFF");
			colorList.Add("LightCyan2,D1EEEE");
			colorList.Add("LightCyan3,B4CDCD");
			colorList.Add("LightCyan4,7A8B8B");
			colorList.Add("LightSkyBlue,87CEFA");
			colorList.Add("LightSkyBlue1,B0E2FF");
			colorList.Add("LightSkyBlue2,A4D3EE");
			colorList.Add("LightSkyBlue3,8DB6CD");
			colorList.Add("LightSkyBlue4,607B8B");
			colorList.Add("LightSlateBlue,8470FF");
			colorList.Add("LightSteelBlue,B0C4DE");
			colorList.Add("LightSteelBlue1,CAE1FF");
			colorList.Add("LightSteelBlue2,BCD2EE");
			colorList.Add("LightSteelBlue3,A2B5CD");
			colorList.Add("LightSteelBlue4,6E7B8B");
			colorList.Add("MediumAquamarine,66CDAA");
			colorList.Add("MediumBlue,0000CD");
			colorList.Add("MediumSlateBlue,7B68EE");
			colorList.Add("MediumTurquoise,48D1CC");
			colorList.Add("MidnightBlue,191970");
			colorList.Add("NavyBlue,000080");
			colorList.Add("PaleTurquoise,AFEEEE");
			colorList.Add("PaleTurquoise1,BBFFFF");
			colorList.Add("PaleTurquoise2,AEEEEE");
			colorList.Add("PaleTurquoise3,96CDCD");
			colorList.Add("PaleTurquoise4,668B8B");
			colorList.Add("PowderBlue,B0E0E6");
			colorList.Add("RoyalBlue,4169E1");
			colorList.Add("RoyalBlue1,4876FF");
			colorList.Add("RoyalBlue2,436EEE");
			colorList.Add("RoyalBlue3,3A5FCD");
			colorList.Add("RoyalBlue4,27408B");
			colorList.Add("SkyBlue,87CEEB");
			colorList.Add("SkyBlue1,87CEFF");
			colorList.Add("SkyBlue2,7EC0EE");
			colorList.Add("SkyBlue3,6CA6CD");
			colorList.Add("SkyBlue4,4A708B");
			colorList.Add("SlateBlue,6A5ACD");
			colorList.Add("SlateBlue1,836FFF");
			colorList.Add("SlateBlue2,7A67EE");
			colorList.Add("SlateBlue3,6959CD");
			colorList.Add("SlateBlue4,473C8B");
			colorList.Add("SteelBlue,4682B4");
			colorList.Add("SteelBlue1,63B8FF");
			colorList.Add("SteelBlue2,5CACEE");
			colorList.Add("SteelBlue3,4F94CD");
			colorList.Add("SteelBlue4,36648B");
			colorList.Add("aquamarine,7FFFD4");
			colorList.Add("aquamarine1,7FFFD4");
			colorList.Add("aquamarine2,76EEC6");
			colorList.Add("aquamarine3,66CDAA");
			colorList.Add("aquamarine4,458B74");
			colorList.Add("azure,F0FFFF");
			colorList.Add("azure1,F0FFFF");
			colorList.Add("azure2,E0EEEE");
			colorList.Add("azure3,C1CDCD");
			colorList.Add("azure4,838B8B");
			colorList.Add("blue,0000FF");
			colorList.Add("blue1,0000FF");
			colorList.Add("blue2,0000EE");
			colorList.Add("blue3,0000CD");
			colorList.Add("blue4,00008B");
			colorList.Add("cyan,00FFFF");
			colorList.Add("cyan1,00FFFF");
			colorList.Add("cyan2,00EEEE");
			colorList.Add("cyan3,00CDCD");
			colorList.Add("cyan4,008B8B");
			colorList.Add("navy,000080");
			colorList.Add("turquoise,40E0D0");
			colorList.Add("turquoise1,00F5FF");
			colorList.Add("turquoise2,00E5EE");
			colorList.Add("turquoise3,00C5CD");
			colorList.Add("turquoise4,00868B");
			colorList.Add("RosyBrown,BC8F8F");
			colorList.Add("RosyBrown1,FFC1C1");
			colorList.Add("RosyBrown2,EEB4B4");
			colorList.Add("RosyBrown3,CD9B9B");
			colorList.Add("RosyBrown4,8B6969");
			colorList.Add("SAddleBrown,8B4513");
			colorList.Add("SandyBrown,F4A460");
			colorList.Add("beige,F5F5DC");
			colorList.Add("brown,A52A2A");
			colorList.Add("brown1,FF4040");
			colorList.Add("brown2,EE3B3B");
			colorList.Add("brown3,CD3333");
			colorList.Add("brown4,8B2323");
			colorList.Add("burlywood,DEB887");
			colorList.Add("burlywood1,FFD39B");
			colorList.Add("burlywood2,EEC591");
			colorList.Add("burlywood3,CDAA7D");
			colorList.Add("burlywood4,8B7355");
			colorList.Add("chocolate,D2691E");
			colorList.Add("chocolate1,FF7F24");
			colorList.Add("chocolate2,EE7621");
			colorList.Add("chocolate3,CD661D");
			colorList.Add("chocolate4,8B4513");
			colorList.Add("peru,CD853F");
			colorList.Add("tan,D2B48C");
			colorList.Add("tan1,FFA54F");
			colorList.Add("tan2,EE9A49");
			colorList.Add("tan3,CD853F");
			colorList.Add("tan4,8B5A2B");
			colorList.Add("DarkSlateGray,2F4F4F");
			colorList.Add("DarkSlateGray1,97FFFF");
			colorList.Add("DarkSlateGray2,8DEEEE");
			colorList.Add("DarkSlateGray3,79CDCD");
			colorList.Add("DarkSlateGray4,528B8B");
			colorList.Add("DarkSlateGrey,2F4F4F");
			colorList.Add("DimGray,696969");
			colorList.Add("DimGrey,696969");
			colorList.Add("LightGray,D3D3D3");
			colorList.Add("LightGrey,D3D3D3");
			colorList.Add("LightSlateGray,778899");
			colorList.Add("LightSlateGrey,778899");
			colorList.Add("SlateGray,708090");
			colorList.Add("SlateGray1,C6E2FF");
			colorList.Add("SlateGray2,B9D3EE");
			colorList.Add("SlateGray3,9FB6CD");
			colorList.Add("SlateGray4,6C7B8B");
			colorList.Add("SlateGrey,708090");
			colorList.Add("gray,BEBEBE");
			colorList.Add("gray0,000000");
			colorList.Add("gray1,030303");
			colorList.Add("gray2,050505");
			colorList.Add("gray3,080808");
			colorList.Add("gray4,0A0A0A");
			colorList.Add("gray5,0D0D0D");
			colorList.Add("gray6,0F0F0F");
			colorList.Add("gray7,121212");
			colorList.Add("gray8,141414");
			colorList.Add("gray9,171717");
			colorList.Add("gray10,1A1A1A");
			colorList.Add("gray11,1C1C1C");
			colorList.Add("gray12,1F1F1F");
			colorList.Add("gray13,212121");
			colorList.Add("gray14,242424");
			colorList.Add("gray15,262626");
			colorList.Add("gray16,292929");
			colorList.Add("gray17,2B2B2B");
			colorList.Add("gray18,2E2E2E");
			colorList.Add("gray19,303030");
			colorList.Add("gray20,333333");
			colorList.Add("gray21,363636");
			colorList.Add("gray22,383838");
			colorList.Add("gray23,3B3B3B");
			colorList.Add("gray24,3D3D3D");
			colorList.Add("gray25,404040");
			colorList.Add("gray26,424242");
			colorList.Add("gray27,454545");
			colorList.Add("gray28,474747");
			colorList.Add("gray29,4A4A4A");
			colorList.Add("gray30,4D4D4D");
			colorList.Add("gray31,4F4F4F");
			colorList.Add("gray32,525252");
			colorList.Add("gray33,545454");
			colorList.Add("gray34,575757");
			colorList.Add("gray35,595959");
			colorList.Add("gray36,5C5C5C");
			colorList.Add("gray37,5E5E5E");
			colorList.Add("gray38,616161");
			colorList.Add("gray39,636363");
			colorList.Add("gray40,666666");
			colorList.Add("gray41,696969");
			colorList.Add("gray42,6B6B6B");
			colorList.Add("gray43,6E6E6E");
			colorList.Add("gray44,707070");
			colorList.Add("gray45,737373");
			colorList.Add("gray46,757575");
			colorList.Add("gray47,787878");
			colorList.Add("gray48,7A7A7A");
			colorList.Add("gray49,7D7D7D");
			colorList.Add("gray50,7F7F7F");
			colorList.Add("gray51,828282");
			colorList.Add("gray52,858585");
			colorList.Add("gray53,878787");
			colorList.Add("gray54,8A8A8A");
			colorList.Add("gray55,8C8C8C");
			colorList.Add("gray56,8F8F8F");
			colorList.Add("gray57,919191");
			colorList.Add("gray58,949494");
			colorList.Add("gray59,969696");
			colorList.Add("gray60,999999");
			colorList.Add("gray61,9C9C9C");
			colorList.Add("gray62,9E9E9E");
			colorList.Add("gray63,A1A1A1");
			colorList.Add("gray64,A3A3A3");
			colorList.Add("gray65,A6A6A6");
			colorList.Add("gray66,A8A8A8");
			colorList.Add("gray67,ABABAB");
			colorList.Add("gray68,ADADAD");
			colorList.Add("gray69,B0B0B0");
			colorList.Add("gray70,B3B3B3");
			colorList.Add("gray71,B5B5B5");
			colorList.Add("gray72,B8B8B8");
			colorList.Add("gray73,BABABA");
			colorList.Add("gray74,BDBDBD");
			colorList.Add("gray75,BFBFBF");
			colorList.Add("gray76,C2C2C2");
			colorList.Add("gray77,C4C4C4");
			colorList.Add("gray78,C7C7C7");
			colorList.Add("gray79,C9C9C9");
			colorList.Add("gray80,CCCCCC");
			colorList.Add("gray81,CFCFCF");
			colorList.Add("gray82,D1D1D1");
			colorList.Add("gray83,D4D4D4");
			colorList.Add("gray84,D6D6D6");
			colorList.Add("gray85,D9D9D9");
			colorList.Add("gray86,DBDBDB");
			colorList.Add("gray87,DEDEDE");
			colorList.Add("gray88,E0E0E0");
			colorList.Add("gray89,E3E3E3");
			colorList.Add("gray90,E5E5E5");
			colorList.Add("gray91,E8E8E8");
			colorList.Add("gray92,EBEBEB");
			colorList.Add("gray93,EDEDED");
			colorList.Add("gray94,F0F0F0");
			colorList.Add("gray95,F2F2F2");
			colorList.Add("gray96,F5F5F5");
			colorList.Add("gray97,F7F7F7");
			colorList.Add("gray98,FAFAFA");
			colorList.Add("gray99,FCFCFC");
			colorList.Add("gray100,FFFFFF");
			colorList.Add("grey,BEBEBE");
			colorList.Add("grey0,000000");
			colorList.Add("grey1,030303");
			colorList.Add("grey2,050505");
			colorList.Add("grey3,080808");
			colorList.Add("grey4,0A0A0A");
			colorList.Add("grey5,0D0D0D");
			colorList.Add("grey6,0F0F0F");
			colorList.Add("grey7,121212");
			colorList.Add("grey8,141414");
			colorList.Add("grey9,171717");
			colorList.Add("grey10,1A1A1A");
			colorList.Add("grey11,1C1C1C");
			colorList.Add("grey12,1F1F1F");
			colorList.Add("grey13,212121");
			colorList.Add("grey14,242424");
			colorList.Add("grey15,262626");
			colorList.Add("grey16,292929");
			colorList.Add("grey17,2B2B2B");
			colorList.Add("grey18,2E2E2E");
			colorList.Add("grey19,303030");
			colorList.Add("grey20,333333");
			colorList.Add("grey21,363636");
			colorList.Add("grey22,383838");
			colorList.Add("grey23,3B3B3B");
			colorList.Add("grey24,3D3D3D");
			colorList.Add("grey25,404040");
			colorList.Add("grey26,424242");
			colorList.Add("grey27,454545");
			colorList.Add("grey28,474747");
			colorList.Add("grey29,4A4A4A");
			colorList.Add("grey30,4D4D4D");
			colorList.Add("grey31,4F4F4F");
			colorList.Add("grey32,525252");
			colorList.Add("grey33,545454");
			colorList.Add("grey34,575757");
			colorList.Add("grey35,595959");
			colorList.Add("grey36,5C5C5C");
			colorList.Add("grey37,5E5E5E");
			colorList.Add("grey38,616161");
			colorList.Add("grey39,636363");
			colorList.Add("grey40,666666");
			colorList.Add("grey41,696969");
			colorList.Add("grey42,6B6B6B");
			colorList.Add("grey43,6E6E6E");
			colorList.Add("grey44,707070");
			colorList.Add("grey45,737373");
			colorList.Add("grey46,757575");
			colorList.Add("grey47,787878");
			colorList.Add("grey48,7A7A7A");
			colorList.Add("grey49,7D7D7D");
			colorList.Add("grey50,7F7F7F");
			colorList.Add("grey51,828282");
			colorList.Add("grey52,858585");
			colorList.Add("grey53,878787");
			colorList.Add("grey54,8A8A8A");
			colorList.Add("grey55,8C8C8C");
			colorList.Add("grey56,8F8F8F");
			colorList.Add("grey57,919191");
			colorList.Add("grey58,949494");
			colorList.Add("grey59,969696");
			colorList.Add("grey60,999999");
			colorList.Add("grey61,9C9C9C");
			colorList.Add("grey62,9E9E9E");
			colorList.Add("grey63,A1A1A1");
			colorList.Add("grey64,A3A3A3");
			colorList.Add("grey65,A6A6A6");
			colorList.Add("grey66,A8A8A8");
			colorList.Add("grey67,ABABAB");
			colorList.Add("grey68,ADADAD");
			colorList.Add("grey69,B0B0B0");
			colorList.Add("grey70,B3B3B3");
			colorList.Add("grey71,B5B5B5");
			colorList.Add("grey72,B8B8B8");
			colorList.Add("grey73,BABABA");
			colorList.Add("grey74,BDBDBD");
			colorList.Add("grey75,BFBFBF");
			colorList.Add("grey76,C2C2C2");
			colorList.Add("grey77,C4C4C4");
			colorList.Add("grey78,C7C7C7");
			colorList.Add("grey79,C9C9C9");
			colorList.Add("grey80,CCCCCC");
			colorList.Add("grey81,CFCFCF");
			colorList.Add("grey82,D1D1D1");
			colorList.Add("grey83,D4D4D4");
			colorList.Add("grey84,D6D6D6");
			colorList.Add("grey85,D9D9D9");
			colorList.Add("grey86,DBDBDB");
			colorList.Add("grey87,DEDEDE");
			colorList.Add("grey88,E0E0E0");
			colorList.Add("grey89,E3E3E3");
			colorList.Add("grey90,E5E5E5");
			colorList.Add("grey91,E8E8E8");
			colorList.Add("grey92,EBEBEB");
			colorList.Add("grey93,EDEDED");
			colorList.Add("grey94,F0F0F0");
			colorList.Add("grey95,F2F2F2");
			colorList.Add("grey96,F5F5F5");
			colorList.Add("grey97,F7F7F7");
			colorList.Add("grey98,FAFAFA");
			colorList.Add("grey99,FCFCFC");
			colorList.Add("grey100,FFFFFF");
			colorList.Add("DarkGreen,006400");
			colorList.Add("DarkKhaki,BDB76B");
			colorList.Add("DarkOliveGreen,556B2F");
			colorList.Add("DarkOliveGreen1,CAFF70");
			colorList.Add("DarkOliveGreen2,BCEE68");
			colorList.Add("DarkOliveGreen3,A2CD5A");
			colorList.Add("DarkOliveGreen4,6E8B3D");
			colorList.Add("DarkSeaGreen,8FBC8F");
			colorList.Add("DarkSeaGreen1,C1FFC1");
			colorList.Add("DarkSeaGreen2,B4EEB4");
			colorList.Add("DarkSeaGreen3,9BCD9B");
			colorList.Add("DarkSeaGreen4,698B69");
			colorList.Add("ForestGreen,228B22");
			colorList.Add("GreenYellow,ADFF2F");
			colorList.Add("LawnGreen,7CFC00");
			colorList.Add("LightGreen,90EE90");
			colorList.Add("LightSeaGreen,20B2AA");
			colorList.Add("LimeGreen,32CD32");
			colorList.Add("MediumSeaGreen,3CB371");
			colorList.Add("MediumSpringGreen,00FA9A");
			colorList.Add("MintCream,F5FFFA");
			colorList.Add("OliveDrab,6B8E23");
			colorList.Add("OliveDrab1,C0FF3E");
			colorList.Add("OliveDrab2,B3EE3A");
			colorList.Add("OliveDrab3,9ACD32");
			colorList.Add("OliveDrab4,698B22");
			colorList.Add("PaleGreen,98FB98");
			colorList.Add("PaleGreen1,9AFF9A");
			colorList.Add("PaleGreen2,90EE90");
			colorList.Add("PaleGreen3,7CCD7C");
			colorList.Add("PaleGreen4,548B54");
			colorList.Add("SeaGreen,2E8B57");
			colorList.Add("SeaGreen1,54FF9F");
			colorList.Add("SeaGreen2,4EEE94");
			colorList.Add("SeaGreen3,43CD80");
			colorList.Add("SeaGreen4,2E8B57");
			colorList.Add("SpringGreen,00FF7F");
			colorList.Add("SpringGreen1,00FF7F");
			colorList.Add("SpringGreen2,00EE76");
			colorList.Add("SpringGreen3,00CD66");
			colorList.Add("SpringGreen4,008B45");
			colorList.Add("YellowGreen,9ACD32");
			colorList.Add("chartreuse,7FFF00");
			colorList.Add("chartreuse1,7FFF00");
			colorList.Add("chartreuse2,76EE00");
			colorList.Add("chartreuse3,66CD00");
			colorList.Add("chartreuse4,458B00");
			colorList.Add("green,00FF00");
			colorList.Add("green1,00FF00");
			colorList.Add("green2,00EE00");
			colorList.Add("green3,00CD00");
			colorList.Add("green4,008B00");
			colorList.Add("khaki,F0E68C");
			colorList.Add("khaki1,FFF68F");
			colorList.Add("khaki2,EEE685");
			colorList.Add("khaki3,CDC673");
			colorList.Add("khaki4,8B864E");
			colorList.Add("DarkOrange,FF8C00");
			colorList.Add("DarkOrange1,FF7F00");
			colorList.Add("DarkOrange2,EE7600");
			colorList.Add("DarkOrange3,CD6600");
			colorList.Add("DarkOrange4,8B4500");
			colorList.Add("DarkSalmon,E9967A");
			colorList.Add("LightCoral,F08080");
			colorList.Add("LightSalmon,FFA07A");
			colorList.Add("LightSalmon1,FFA07A");
			colorList.Add("LightSalmon2,EE9572");
			colorList.Add("LightSalmon3,CD8162");
			colorList.Add("LightSalmon4,8B5742");
			colorList.Add("PeachPuff,FFDAB9");
			colorList.Add("PeachPuff1,FFDAB9");
			colorList.Add("PeachPuff2,EECBAD");
			colorList.Add("PeachPuff3,CDAF95");
			colorList.Add("PeachPuff4,8B7765");
			colorList.Add("bisque,FFE4C4");
			colorList.Add("bisque1,FFE4C4");
			colorList.Add("bisque2,EED5B7");
			colorList.Add("bisque3,CDB79E");
			colorList.Add("bisque4,8B7D6B");
			colorList.Add("coral,FF7F50");
			colorList.Add("coral1,FF7256");
			colorList.Add("coral2,EE6A50");
			colorList.Add("coral3,CD5B45");
			colorList.Add("coral4,8B3E2F");
			colorList.Add("honeydew,F0FFF0");
			colorList.Add("honeydew1,F0FFF0");
			colorList.Add("honeydew2,E0EEE0");
			colorList.Add("honeydew3,C1CDC1");
			colorList.Add("honeydew4,838B83");
			colorList.Add("orange,FFA500");
			colorList.Add("orange1,FFA500");
			colorList.Add("orange2,EE9A00");
			colorList.Add("orange3,CD8500");
			colorList.Add("orange4,8B5A00");
			colorList.Add("salmon,FA8072");
			colorList.Add("salmon1,FF8C69");
			colorList.Add("salmon2,EE8262");
			colorList.Add("salmon3,CD7054");
			colorList.Add("salmon4,8B4C39");
			colorList.Add("sienna,A0522D");
			colorList.Add("sienna1,FF8247");
			colorList.Add("sienna2,EE7942");
			colorList.Add("sienna3,CD6839");
			colorList.Add("sienna4,8B4726");
			colorList.Add("DarkRed,8B0000");
			colorList.Add("DeepPink,FF1493");
			colorList.Add("DeepPink1,FF1493");
			colorList.Add("DeepPink2,EE1289");
			colorList.Add("DeepPink3,CD1076");
			colorList.Add("DeepPink4,8B0A50");
			colorList.Add("HotPink,FF69B4");
			colorList.Add("HotPink1,FF6EB4");
			colorList.Add("HotPink2,EE6AA7");
			colorList.Add("HotPink3,CD6090");
			colorList.Add("HotPink4,8B3A62");
			colorList.Add("IndianRed,CD5C5C");
			colorList.Add("IndianRed1,FF6A6A");
			colorList.Add("IndianRed2,EE6363");
			colorList.Add("IndianRed3,CD5555");
			colorList.Add("IndianRed4,8B3A3A");
			colorList.Add("LightPink,FFB6C1");
			colorList.Add("LightPink1,FFAEB9");
			colorList.Add("LightPink2,EEA2AD");
			colorList.Add("LightPink3,CD8C95");
			colorList.Add("LightPink4,8B5F65");
			colorList.Add("MediumVioletRed,C71585");
			colorList.Add("MistyRose,FFE4E1");
			colorList.Add("MistyRose1,FFE4E1");
			colorList.Add("MistyRose2,EED5D2");
			colorList.Add("MistyRose3,CDB7B5");
			colorList.Add("MistyRose4,8B7D7B");
			colorList.Add("OrangeRed,FF4500");
			colorList.Add("OrangeRed1,FF4500");
			colorList.Add("OrangeRed2,EE4000");
			colorList.Add("OrangeRed3,CD3700");
			colorList.Add("OrangeRed4,8B2500");
			colorList.Add("PaleVioletRed,DB7093");
			colorList.Add("PaleVioletRed1,FF82AB");
			colorList.Add("PaleVioletRed2,EE799F");
			colorList.Add("PaleVioletRed3,CD6889");
			colorList.Add("PaleVioletRed4,8B475D");
			colorList.Add("VioletRed,D02090");
			colorList.Add("VioletRed1,FF3E96");
			colorList.Add("VioletRed2,EE3A8C");
			colorList.Add("VioletRed3,CD3278");
			colorList.Add("VioletRed4,8B2252");
			colorList.Add("firebrick,B22222");
			colorList.Add("firebrick1,FF3030");
			colorList.Add("firebrick2,EE2C2C");
			colorList.Add("firebrick3,CD2626");
			colorList.Add("firebrick4,8B1A1A");
			colorList.Add("pink,FFC0CB");
			colorList.Add("pink1,FFB5C5");
			colorList.Add("pink2,EEA9B8");
			colorList.Add("pink3,CD919E");
			colorList.Add("pink4,8B636C");
			colorList.Add("red,FF0000");
			colorList.Add("red1,FF0000");
			colorList.Add("red2,EE0000");
			colorList.Add("red3,CD0000");
			colorList.Add("red4,8B0000");
			colorList.Add("tomato,FF6347");
			colorList.Add("tomato1,FF6347");
			colorList.Add("tomato2,EE5C42");
			colorList.Add("tomato3,CD4F39");
			colorList.Add("tomato4,8B3626");
			colorList.Add("DarkMagenta,8B008B");
			colorList.Add("DarkOrchid,9932CC");
			colorList.Add("DarkOrchid1,BF3EFF");
			colorList.Add("DarkOrchid2,B23AEE");
			colorList.Add("DarkOrchid3,9A32CD");
			colorList.Add("DarkOrchid4,68228B");
			colorList.Add("DarkViolet,9400D3");
			colorList.Add("LavenderBlush,FFF0F5");
			colorList.Add("LavenderBlush1,FFF0F5");
			colorList.Add("LavenderBlush2,EEE0E5");
			colorList.Add("LavenderBlush3,CDC1C5");
			colorList.Add("LavenderBlush4,8B8386");
			colorList.Add("MediumOrchid,BA55D3");
			colorList.Add("MediumOrchid1,E066FF");
			colorList.Add("MediumOrchid2,D15FEE");
			colorList.Add("MediumOrchid3,B452CD");
			colorList.Add("MediumOrchid4,7A378B");
			colorList.Add("MediumPurple,9370DB");
			colorList.Add("MediumPurple1,AB82FF");
			colorList.Add("MediumPurple2,9F79EE");
			colorList.Add("MediumPurple3,8968CD");
			colorList.Add("MediumPurple4,5D478B");
			colorList.Add("lavender,E6E6FA");
			colorList.Add("magenta,FF00FF");
			colorList.Add("magenta1,FF00FF");
			colorList.Add("magenta2,EE00EE");
			colorList.Add("magenta3,CD00CD");
			colorList.Add("magenta4,8B008B");
			colorList.Add("maroon,B03060");
			colorList.Add("maroon1,FF34B3");
			colorList.Add("maroon2,EE30A7");
			colorList.Add("maroon3,CD2990");
			colorList.Add("maroon4,8B1C62");
			colorList.Add("orchid,DA70D6");
			colorList.Add("orchid1,FF83FA");
			colorList.Add("orchid2,EE7AE9");
			colorList.Add("orchid3,CD69C9");
			colorList.Add("orchid4,8B4789");
			colorList.Add("plum,DDA0DD");
			colorList.Add("plum1,FFBBFF");
			colorList.Add("plum2,EEAEEE");
			colorList.Add("plum3,CD96CD");
			colorList.Add("plum4,8B668B");
			colorList.Add("purple,A020F0");
			colorList.Add("purple1,9B30FF");
			colorList.Add("purple2,912CEE");
			colorList.Add("purple3,7D26CD");
			colorList.Add("purple4,551A8B");
			colorList.Add("thistle,D8BFD8");
			colorList.Add("thistle1,FFE1FF");
			colorList.Add("thistle2,EED2EE");
			colorList.Add("thistle3,CDB5CD");
			colorList.Add("thistle4,8B7B8B");
			colorList.Add("violet,EE82EE");
			colorList.Add("AntiqueWhite,FAEBD7");
			colorList.Add("AntiqueWhite1,FFEFDB");
			colorList.Add("AntiqueWhite2,EEDFCC");
			colorList.Add("AntiqueWhite3,CDC0B0");
			colorList.Add("AntiqueWhite4,8B8378");
			colorList.Add("FloralWhite,FFFAF0");
			colorList.Add("GhostWhite,F8F8FF");
			colorList.Add("NavajoWhite,FFDEAD");
			colorList.Add("NavajoWhite1,FFDEAD");
			colorList.Add("NavajoWhite2,EECFA1");
			colorList.Add("NavajoWhite3,CDB38B");
			colorList.Add("NavajoWhite4,8B795E");
			colorList.Add("OldLace,FDF5E6");
			colorList.Add("WhiteSmoke,F5F5F5");
			colorList.Add("gainsboro,DCDCDC");
			colorList.Add("ivory,FFFFF0");
			colorList.Add("ivory1,FFFFF0");
			colorList.Add("ivory2,EEEEE0");
			colorList.Add("ivory3,CDCDC1");
			colorList.Add("ivory4,8B8B83");
			colorList.Add("linen,FAF0E6");
			colorList.Add("seashell,FFF5EE");
			colorList.Add("seashell1,FFF5EE");
			colorList.Add("seashell2,EEE5DE");
			colorList.Add("seashell3,CDC5BF");
			colorList.Add("seashell4,8B8682");
			colorList.Add("snow,FFFAFA");
			colorList.Add("snow1,FFFAFA");
			colorList.Add("snow2,EEE9E9");
			colorList.Add("snow3,CDC9C9");
			colorList.Add("snow4,8B8989");
			colorList.Add("wheat,F5DEB3");
			colorList.Add("wheat1,FFE7BA");
			colorList.Add("wheat2,EED8AE");
			colorList.Add("wheat3,CDBA96");
			colorList.Add("wheat4,8B7E66");
			colorList.Add("white,FFFFFF");
			colorList.Add("BlanchedAlmond,FFEBCD");
			colorList.Add("DarkGoldenrod,B8860B");
			colorList.Add("DarkGoldenrod1,FFB90F");
			colorList.Add("DarkGoldenrod2,EEAD0E");
			colorList.Add("DarkGoldenrod3,CD950C");
			colorList.Add("DarkGoldenrod4,8B6508");
			colorList.Add("LemonChiffon,FFFACD");
			colorList.Add("LemonChiffon1,FFFACD");
			colorList.Add("LemonChiffon2,EEE9BF");
			colorList.Add("LemonChiffon3,CDC9A5");
			colorList.Add("LemonChiffon4,8B8970");
			colorList.Add("LightGoldenrod,EEDD82");
			colorList.Add("LightGoldenrod1,FFEC8B");
			colorList.Add("LightGoldenrod2,EEDC82");
			colorList.Add("LightGoldenrod3,CDBE70");
			colorList.Add("LightGoldenrod4,8B814C");
			colorList.Add("LightGoldenrodYellow,FAFAD2");
			colorList.Add("LightYellow,FFFFE0");
			colorList.Add("LightYellow1,FFFFE0");
			colorList.Add("LightYellow2,EEEED1");
			colorList.Add("LightYellow3,CDCDB4");
			colorList.Add("LightYellow4,8B8B7A");
			colorList.Add("PaleGoldenrod,EEE8AA");
			colorList.Add("PapayaWhip,FFEFD5");
			colorList.Add("cornsilk,FFF8DC");
			colorList.Add("cornsilk1,FFF8DC");
			colorList.Add("cornsilk2,EEE8CD");
			colorList.Add("cornsilk3,CDC8B1");
			colorList.Add("cornsilk4,8B8878");
			colorList.Add("gold,FFD700");
			colorList.Add("gold1,FFD700");
			colorList.Add("gold2,EEC900");
			colorList.Add("gold3,CDAD00");
			colorList.Add("gold4,8B7500");
			colorList.Add("goldenrod,DAA520");
			colorList.Add("goldenrod1,FFC125");
			colorList.Add("goldenrod2,EEB422");
			colorList.Add("goldenrod3,CD9B1D");
			colorList.Add("goldenrod4,8B6914");
			colorList.Add("moccasin,FFE4B5");
			colorList.Add("yellow,FFFF00");
			colorList.Add("yellow1,FFFF00");
			colorList.Add("yellow2,EEEE00");
			colorList.Add("yellow3,CDCD00");
			colorList.Add("yellow4,8B8B00");

			return colorList;
		}
    }
}
