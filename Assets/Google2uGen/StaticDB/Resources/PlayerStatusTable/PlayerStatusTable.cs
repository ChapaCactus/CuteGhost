//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;
using System.Globalization;

namespace Google2u
{
	[System.Serializable]
	public class PlayerStatusTableRow : IGoogle2uRow
	{
		public int _Exp;
		public int _Health;
		public int _SpecialPoint;
		public int _Attack;
		public int _Defense;
		public int _Speed;
		public int _Luck;
		public PlayerStatusTableRow(string __ID, string __Exp, string __Health, string __SpecialPoint, string __Attack, string __Defense, string __Speed, string __Luck) 
		{
			{
			int res;
				if(int.TryParse(__Exp, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Exp = res;
				else
					Debug.LogError("Failed To Convert _Exp string: "+ __Exp +" to int");
			}
			{
			int res;
				if(int.TryParse(__Health, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Health = res;
				else
					Debug.LogError("Failed To Convert _Health string: "+ __Health +" to int");
			}
			{
			int res;
				if(int.TryParse(__SpecialPoint, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_SpecialPoint = res;
				else
					Debug.LogError("Failed To Convert _SpecialPoint string: "+ __SpecialPoint +" to int");
			}
			{
			int res;
				if(int.TryParse(__Attack, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Attack = res;
				else
					Debug.LogError("Failed To Convert _Attack string: "+ __Attack +" to int");
			}
			{
			int res;
				if(int.TryParse(__Defense, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Defense = res;
				else
					Debug.LogError("Failed To Convert _Defense string: "+ __Defense +" to int");
			}
			{
			int res;
				if(int.TryParse(__Speed, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Speed = res;
				else
					Debug.LogError("Failed To Convert _Speed string: "+ __Speed +" to int");
			}
			{
			int res;
				if(int.TryParse(__Luck, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Luck = res;
				else
					Debug.LogError("Failed To Convert _Luck string: "+ __Luck +" to int");
			}
		}

		public int Length { get { return 7; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _Exp.ToString();
					break;
				case 1:
					ret = _Health.ToString();
					break;
				case 2:
					ret = _SpecialPoint.ToString();
					break;
				case 3:
					ret = _Attack.ToString();
					break;
				case 4:
					ret = _Defense.ToString();
					break;
				case 5:
					ret = _Speed.ToString();
					break;
				case 6:
					ret = _Luck.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "Exp":
					ret = _Exp.ToString();
					break;
				case "Health":
					ret = _Health.ToString();
					break;
				case "SpecialPoint":
					ret = _SpecialPoint.ToString();
					break;
				case "Attack":
					ret = _Attack.ToString();
					break;
				case "Defense":
					ret = _Defense.ToString();
					break;
				case "Speed":
					ret = _Speed.ToString();
					break;
				case "Luck":
					ret = _Luck.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Exp" + " : " + _Exp.ToString() + "} ";
			ret += "{" + "Health" + " : " + _Health.ToString() + "} ";
			ret += "{" + "SpecialPoint" + " : " + _SpecialPoint.ToString() + "} ";
			ret += "{" + "Attack" + " : " + _Attack.ToString() + "} ";
			ret += "{" + "Defense" + " : " + _Defense.ToString() + "} ";
			ret += "{" + "Speed" + " : " + _Speed.ToString() + "} ";
			ret += "{" + "Luck" + " : " + _Luck.ToString() + "} ";
			return ret;
		}
	}
	public sealed class PlayerStatusTable : IGoogle2uDB
	{
		public enum rowIds {
			Level_01, Level_02, Level_03, Level_04, Level_05, Level_06, Level_07, Level_08, Level_09, Level_10, Level_11, Level_12, Level_13, Level_14, Level_15, Level_16, Level_17, Level_18
			, Level_19, Level_20, Level_21, Level_22, Level_23, Level_24, Level_25, Level_26, Level_27, Level_28, Level_29, Level_30, Level_31, Level_32, Level_33, Level_34, Level_35, Level_36, Level_37, Level_38
			, Level_39, Level_40, Level_41, Level_42, Level_43, Level_44, Level_45, Level_46, Level_47, Level_48, Level_49, Level_50, Level_51, Level_52, Level_53, Level_54, Level_55, Level_56, Level_57, Level_58
			, Level_59, Level_60, Level_61, Level_62, Level_63, Level_64, Level_65, Level_66, Level_67, Level_68, Level_69, Level_70, Level_71, Level_72, Level_73, Level_74, Level_75, Level_76, Level_77, Level_78
			, Level_79, Level_80, Level_81, Level_82, Level_83, Level_84, Level_85, Level_86, Level_87, Level_88, Level_89, Level_90, Level_91, Level_92, Level_93, Level_94, Level_95, Level_96, Level_97, Level_98
			, Level_99
		};
		public string [] rowNames = {
			"Level_01", "Level_02", "Level_03", "Level_04", "Level_05", "Level_06", "Level_07", "Level_08", "Level_09", "Level_10", "Level_11", "Level_12", "Level_13", "Level_14", "Level_15", "Level_16", "Level_17", "Level_18"
			, "Level_19", "Level_20", "Level_21", "Level_22", "Level_23", "Level_24", "Level_25", "Level_26", "Level_27", "Level_28", "Level_29", "Level_30", "Level_31", "Level_32", "Level_33", "Level_34", "Level_35", "Level_36", "Level_37", "Level_38"
			, "Level_39", "Level_40", "Level_41", "Level_42", "Level_43", "Level_44", "Level_45", "Level_46", "Level_47", "Level_48", "Level_49", "Level_50", "Level_51", "Level_52", "Level_53", "Level_54", "Level_55", "Level_56", "Level_57", "Level_58"
			, "Level_59", "Level_60", "Level_61", "Level_62", "Level_63", "Level_64", "Level_65", "Level_66", "Level_67", "Level_68", "Level_69", "Level_70", "Level_71", "Level_72", "Level_73", "Level_74", "Level_75", "Level_76", "Level_77", "Level_78"
			, "Level_79", "Level_80", "Level_81", "Level_82", "Level_83", "Level_84", "Level_85", "Level_86", "Level_87", "Level_88", "Level_89", "Level_90", "Level_91", "Level_92", "Level_93", "Level_94", "Level_95", "Level_96", "Level_97", "Level_98"
			, "Level_99"
		};
		public System.Collections.Generic.List<PlayerStatusTableRow> Rows = new System.Collections.Generic.List<PlayerStatusTableRow>();

		public static PlayerStatusTable Instance
		{
			get { return NestedPlayerStatusTable.instance; }
		}

		private class NestedPlayerStatusTable
		{
			static NestedPlayerStatusTable() { }
			internal static readonly PlayerStatusTable instance = new PlayerStatusTable();
		}

		private PlayerStatusTable()
		{
			Rows.Add( new PlayerStatusTableRow("Level_01", "0", "30", "10", "2", "2", "2", "2"));
			Rows.Add( new PlayerStatusTableRow("Level_02", "4", "32", "12", "4", "2", "2", "2"));
			Rows.Add( new PlayerStatusTableRow("Level_03", "17", "45", "15", "5", "3", "2", "2"));
			Rows.Add( new PlayerStatusTableRow("Level_04", "44", "46", "17", "9", "3", "4", "4"));
			Rows.Add( new PlayerStatusTableRow("Level_05", "109", "60", "20", "9", "3", "4", "4"));
			Rows.Add( new PlayerStatusTableRow("Level_06", "236", "62", "21", "11", "3", "4", "4"));
			Rows.Add( new PlayerStatusTableRow("Level_07", "449", "75", "25", "12", "5", "4", "4"));
			Rows.Add( new PlayerStatusTableRow("Level_08", "772", "76", "25", "16", "6", "5", "7"));
			Rows.Add( new PlayerStatusTableRow("Level_09", "1229", "90", "30", "16", "6", "5", "7"));
			Rows.Add( new PlayerStatusTableRow("Level_10", "1884", "91", "31", "18", "6", "5", "7"));
			Rows.Add( new PlayerStatusTableRow("Level_11", "2611", "105", "33", "20", "6", "6", "7"));
			Rows.Add( new PlayerStatusTableRow("Level_12", "3644", "108", "40", "22", "8", "6", "9"));
			Rows.Add( new PlayerStatusTableRow("Level_13", "4877", "120", "42", "23", "8", "6", "9"));
			Rows.Add( new PlayerStatusTableRow("Level_14", "6364", "122", "42", "24", "8", "7", "9"));
			Rows.Add( new PlayerStatusTableRow("Level_15", "8129", "135", "45", "26", "9", "7", "9"));
			Rows.Add( new PlayerStatusTableRow("Level_16", "10703", "136", "45", "31", "10", "9", "11"));
			Rows.Add( new PlayerStatusTableRow("Level_17", "13241", "138", "47", "31", "10", "9", "11"));
			Rows.Add( new PlayerStatusTableRow("Level_18", "16214", "150", "50", "32", "10", "9", "12"));
			Rows.Add( new PlayerStatusTableRow("Level_19", "19673", "152", "52", "32", "12", "9", "12"));
			Rows.Add( new PlayerStatusTableRow("Level_20", "23699", "195", "65", "35", "14", "9", "14"));
			Rows.Add( new PlayerStatusTableRow("Level_21", "28253", "196", "65", "35", "14", "10", "14"));
			Rows.Add( new PlayerStatusTableRow("Level_22", "33476", "199", "67", "37", "14", "10", "14"));
			Rows.Add( new PlayerStatusTableRow("Level_23", "39389", "201", "68", "39", "15", "10", "14"));
			Rows.Add( new PlayerStatusTableRow("Level_24", "46043", "204", "70", "42", "15", "11", "16"));
			Rows.Add( new PlayerStatusTableRow("Level_25", "53489", "210", "70", "43", "16", "11", "16"));
			Rows.Add( new PlayerStatusTableRow("Level_26", "61778", "211", "72", "45", "16", "11", "17"));
			Rows.Add( new PlayerStatusTableRow("Level_27", "70961", "225", "74", "47", "17", "12", "17"));
			Rows.Add( new PlayerStatusTableRow("Level_28", "81089", "228", "80", "49", "18", "13", "18"));
			Rows.Add( new PlayerStatusTableRow("Level_29", "92213", "229", "81", "50", "18", "13", "18"));
			Rows.Add( new PlayerStatusTableRow("Level_30", "104384", "240", "83", "52", "18", "13", "19"));
			Rows.Add( new PlayerStatusTableRow("Level_31", "117653", "243", "85", "54", "19", "13", "19"));
			Rows.Add( new PlayerStatusTableRow("Level_32", "132071", "270", "90", "56", "19", "15", "22"));
			Rows.Add( new PlayerStatusTableRow("Level_33", "147689", "271", "92", "57", "20", "15", "22"));
			Rows.Add( new PlayerStatusTableRow("Level_34", "164558", "272", "94", "58", "20", "15", "22"));
			Rows.Add( new PlayerStatusTableRow("Level_35", "182729", "273", "95", "60", "20", "15", "22"));
			Rows.Add( new PlayerStatusTableRow("Level_36", "202270", "300", "96", "65", "22", "16", "24"));
			Rows.Add( new PlayerStatusTableRow("Level_37", "223249", "302", "100", "65", "22", "16", "24"));
			Rows.Add( new PlayerStatusTableRow("Level_38", "245734", "303", "102", "65", "22", "16", "24"));
			Rows.Add( new PlayerStatusTableRow("Level_39", "269793", "315", "105", "67", "22", "17", "24"));
			Rows.Add( new PlayerStatusTableRow("Level_40", "295494", "316", "105", "73", "25", "17", "25"));
			Rows.Add( new PlayerStatusTableRow("Level_41", "322905", "330", "110", "73", "25", "17", "26"));
			Rows.Add( new PlayerStatusTableRow("Level_42", "352094", "333", "111", "73", "25", "17", "26"));
			Rows.Add( new PlayerStatusTableRow("Level_43", "383129", "345", "113", "76", "25", "18", "26"));
			Rows.Add( new PlayerStatusTableRow("Level_44", "416078", "347", "125", "78", "25", "20", "29"));
			Rows.Add( new PlayerStatusTableRow("Level_45", "451009", "360", "125", "79", "26", "20", "29"));
			Rows.Add( new PlayerStatusTableRow("Level_46", "487990", "362", "127", "81", "26", "20", "29"));
			Rows.Add( new PlayerStatusTableRow("Level_47", "527089", "364", "127", "82", "26", "20", "29"));
			Rows.Add( new PlayerStatusTableRow("Level_48", "568374", "390", "128", "86", "28", "21", "30"));
			Rows.Add( new PlayerStatusTableRow("Level_49", "611913", "392", "130", "86", "28", "21", "30"));
			Rows.Add( new PlayerStatusTableRow("Level_50", "657774", "394", "130", "88", "28", "21", "31"));
			Rows.Add( new PlayerStatusTableRow("Level_51", "706025", "405", "135", "89", "29", "22", "32"));
			Rows.Add( new PlayerStatusTableRow("Level_52", "756734", "407", "140", "94", "29", "22", "32"));
			Rows.Add( new PlayerStatusTableRow("Level_53", "809969", "410", "140", "94", "30", "22", "33"));
			Rows.Add( new PlayerStatusTableRow("Level_54", "865798", "420", "140", "94", "30", "22", "33"));
			Rows.Add( new PlayerStatusTableRow("Level_55", "924289", "421", "140", "97", "31", "23", "34"));
			Rows.Add( new PlayerStatusTableRow("Level_56", "985510", "450", "155", "100", "32", "25", "35"));
			Rows.Add( new PlayerStatusTableRow("Level_57", "1049529", "452", "157", "100", "32", "25", "35"));
			Rows.Add( new PlayerStatusTableRow("Level_58", "1116414", "454", "159", "102", "32", "25", "36"));
			Rows.Add( new PlayerStatusTableRow("Level_59", "1186233", "465", "159", "103", "33", "25", "36"));
			Rows.Add( new PlayerStatusTableRow("Level_60", "1259054", "466", "159", "107", "33", "26", "37"));
			Rows.Add( new PlayerStatusTableRow("Level_61", "1335030", "480", "161", "107", "33", "26", "37"));
			Rows.Add( new PlayerStatusTableRow("Level_62", "1414314", "481", "161", "109", "34", "26", "38"));
			Rows.Add( new PlayerStatusTableRow("Level_63", "1497059", "495", "162", "111", "35", "26", "38"));
			Rows.Add( new PlayerStatusTableRow("Level_64", "1583418", "510", "170", "114", "36", "27", "40"));
			Rows.Add( new PlayerStatusTableRow("Level_65", "1673544", "512", "170", "114", "36", "27", "40"));
			Rows.Add( new PlayerStatusTableRow("Level_66", "1767590", "514", "170", "115", "37", "27", "41"));
			Rows.Add( new PlayerStatusTableRow("Level_67", "1865709", "516", "175", "117", "38", "28", "41"));
			Rows.Add( new PlayerStatusTableRow("Level_68", "1968054", "540", "175", "122", "39", "29", "43"));
			Rows.Add( new PlayerStatusTableRow("Level_69", "2074778", "543", "175", "122", "39", "29", "43"));
			Rows.Add( new PlayerStatusTableRow("Level_70", "2186034", "544", "180", "124", "39", "29", "43"));
			Rows.Add( new PlayerStatusTableRow("Level_71", "2301975", "555", "185", "125", "39", "29", "43"));
			Rows.Add( new PlayerStatusTableRow("Level_72", "2422754", "570", "186", "128", "41", "31", "46"));
			Rows.Add( new PlayerStatusTableRow("Level_73", "2548524", "572", "190", "129", "41", "31", "46"));
			Rows.Add( new PlayerStatusTableRow("Level_74", "2679438", "573", "190", "131", "41", "31", "46"));
			Rows.Add( new PlayerStatusTableRow("Level_75", "2815649", "576", "195", "132", "42", "31", "46"));
			Rows.Add( new PlayerStatusTableRow("Level_76", "2957310", "600", "196", "137", "43", "33", "47"));
			Rows.Add( new PlayerStatusTableRow("Level_77", "3104574", "603", "196", "137", "43", "33", "47"));
			Rows.Add( new PlayerStatusTableRow("Level_78", "3257594", "604", "200", "138", "43", "33", "47"));
			Rows.Add( new PlayerStatusTableRow("Level_79", "3416523", "607", "205", "139", "43", "33", "48"));
			Rows.Add( new PlayerStatusTableRow("Level_80", "3581514", "645", "207", "143", "46", "33", "49"));
			Rows.Add( new PlayerStatusTableRow("Level_81", "3752720", "646", "208", "143", "46", "34", "49"));
			Rows.Add( new PlayerStatusTableRow("Level_82", "3930294", "649", "210", "144", "46", "34", "50"));
			Rows.Add( new PlayerStatusTableRow("Level_83", "4114389", "651", "210", "148", "46", "34", "50"));
			Rows.Add( new PlayerStatusTableRow("Level_84", "4305158", "653", "220", "149", "46", "36", "52"));
			Rows.Add( new PlayerStatusTableRow("Level_85", "4502754", "660", "220", "150", "47", "36", "52"));
			Rows.Add( new PlayerStatusTableRow("Level_86", "4707330", "661", "221", "151", "47", "36", "53"));
			Rows.Add( new PlayerStatusTableRow("Level_87", "4919039", "675", "223", "154", "47", "36", "53"));
			Rows.Add( new PlayerStatusTableRow("Level_88", "5138034", "676", "230", "158", "49", "37", "55"));
			Rows.Add( new PlayerStatusTableRow("Level_89", "5364468", "690", "232", "158", "49", "37", "55"));
			Rows.Add( new PlayerStatusTableRow("Level_90", "5598494", "693", "233", "160", "49", "37", "55"));
			Rows.Add( new PlayerStatusTableRow("Level_91", "5840265", "695", "234", "162", "49", "38", "56"));
			Rows.Add( new PlayerStatusTableRow("Level_92", "6089934", "720", "240", "165", "51", "38", "57"));
			Rows.Add( new PlayerStatusTableRow("Level_93", "6347654", "723", "242", "165", "51", "38", "57"));
			Rows.Add( new PlayerStatusTableRow("Level_94", "6613578", "725", "244", "166", "51", "38", "57"));
			Rows.Add( new PlayerStatusTableRow("Level_95", "6887859", "735", "244", "169", "51", "38", "58"));
			Rows.Add( new PlayerStatusTableRow("Level_96", "7170650", "738", "250", "172", "54", "41", "59"));
			Rows.Add( new PlayerStatusTableRow("Level_97", "7462104", "750", "251", "172", "54", "41", "59"));
			Rows.Add( new PlayerStatusTableRow("Level_98", "7762374", "752", "252", "174", "54", "41", "59"));
			Rows.Add( new PlayerStatusTableRow("Level_99", "8071613", "765", "255", "175", "54", "41", "60"));
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public PlayerStatusTableRow GetRow(rowIds in_RowID)
		{
			PlayerStatusTableRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public PlayerStatusTableRow GetRow(string in_RowString)
		{
			PlayerStatusTableRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
