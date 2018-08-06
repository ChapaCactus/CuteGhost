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
	public class FriendStatusTableRow : IGoogle2uRow
	{
		public int _Exp;
		public int _Health;
		public int _SpecialPoint;
		public int _Attack;
		public int _Defense;
		public int _Speed;
		public int _Luck;
		public FriendStatusTableRow(string __ID, string __Exp, string __Health, string __SpecialPoint, string __Attack, string __Defense, string __Speed, string __Luck) 
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
	public sealed class FriendStatusTable : IGoogle2uDB
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
		public System.Collections.Generic.List<FriendStatusTableRow> Rows = new System.Collections.Generic.List<FriendStatusTableRow>();

		public static FriendStatusTable Instance
		{
			get { return NestedFriendStatusTable.instance; }
		}

		private class NestedFriendStatusTable
		{
			static NestedFriendStatusTable() { }
			internal static readonly FriendStatusTable instance = new FriendStatusTable();
		}

		private FriendStatusTable()
		{
			Rows.Add( new FriendStatusTableRow("Level_01", "0", "30", "10", "2", "2", "2", "2"));
			Rows.Add( new FriendStatusTableRow("Level_02", "4", "31", "10", "3", "2", "2", "2"));
			Rows.Add( new FriendStatusTableRow("Level_03", "17", "32", "15", "4", "2", "3", "3"));
			Rows.Add( new FriendStatusTableRow("Level_04", "44", "33", "20", "6", "3", "4", "3"));
			Rows.Add( new FriendStatusTableRow("Level_05", "109", "35", "22", "6", "3", "4", "3"));
			Rows.Add( new FriendStatusTableRow("Level_06", "236", "45", "25", "7", "3", "6", "4"));
			Rows.Add( new FriendStatusTableRow("Level_07", "449", "46", "30", "9", "3", "6", "5"));
			Rows.Add( new FriendStatusTableRow("Level_08", "772", "47", "31", "11", "4", "8", "5"));
			Rows.Add( new FriendStatusTableRow("Level_09", "1229", "49", "35", "11", "4", "8", "5"));
			Rows.Add( new FriendStatusTableRow("Level_10", "1884", "50", "40", "13", "4", "9", "6"));
			Rows.Add( new FriendStatusTableRow("Level_11", "2611", "60", "45", "13", "4", "10", "6"));
			Rows.Add( new FriendStatusTableRow("Level_12", "3644", "62", "46", "16", "6", "11", "8"));
			Rows.Add( new FriendStatusTableRow("Level_13", "4877", "63", "47", "16", "6", "11", "8"));
			Rows.Add( new FriendStatusTableRow("Level_14", "6364", "66", "50", "16", "6", "12", "8"));
			Rows.Add( new FriendStatusTableRow("Level_15", "8129", "67", "55", "19", "6", "12", "8"));
			Rows.Add( new FriendStatusTableRow("Level_16", "10703", "75", "65", "20", "7", "14", "10"));
			Rows.Add( new FriendStatusTableRow("Level_17", "13241", "76", "65", "21", "7", "14", "10"));
			Rows.Add( new FriendStatusTableRow("Level_18", "16214", "77", "65", "21", "7", "15", "10"));
			Rows.Add( new FriendStatusTableRow("Level_19", "19673", "79", "70", "24", "7", "16", "11"));
			Rows.Add( new FriendStatusTableRow("Level_20", "23699", "90", "75", "25", "7", "17", "11"));
			Rows.Add( new FriendStatusTableRow("Level_21", "28253", "92", "76", "25", "7", "17", "11"));
			Rows.Add( new FriendStatusTableRow("Level_22", "33476", "93", "85", "27", "7", "18", "12"));
			Rows.Add( new FriendStatusTableRow("Level_23", "39389", "95", "85", "28", "8", "19", "13"));
			Rows.Add( new FriendStatusTableRow("Level_24", "46043", "105", "95", "30", "9", "20", "13"));
			Rows.Add( new FriendStatusTableRow("Level_25", "53489", "106", "96", "30", "9", "20", "13"));
			Rows.Add( new FriendStatusTableRow("Level_26", "61778", "108", "97", "31", "9", "22", "14"));
			Rows.Add( new FriendStatusTableRow("Level_27", "70961", "110", "98", "33", "9", "22", "15"));
			Rows.Add( new FriendStatusTableRow("Level_28", "81089", "111", "110", "34", "11", "24", "15"));
			Rows.Add( new FriendStatusTableRow("Level_29", "92213", "112", "112", "35", "11", "24", "16"));
			Rows.Add( new FriendStatusTableRow("Level_30", "104384", "114", "113", "36", "11", "25", "16"));
			Rows.Add( new FriendStatusTableRow("Level_31", "117653", "120", "114", "38", "11", "25", "16"));
			Rows.Add( new FriendStatusTableRow("Level_32", "132071", "123", "120", "40", "11", "28", "18"));
			Rows.Add( new FriendStatusTableRow("Level_33", "147689", "126", "121", "40", "11", "28", "18"));
			Rows.Add( new FriendStatusTableRow("Level_34", "164558", "128", "121", "40", "11", "28", "18"));
			Rows.Add( new FriendStatusTableRow("Level_35", "182729", "131", "125", "42", "12", "28", "19"));
			Rows.Add( new FriendStatusTableRow("Level_36", "202270", "135", "135", "46", "12", "30", "20"));
			Rows.Add( new FriendStatusTableRow("Level_37", "223249", "137", "136", "46", "12", "30", "20"));
			Rows.Add( new FriendStatusTableRow("Level_38", "245734", "140", "136", "46", "12", "31", "20"));
			Rows.Add( new FriendStatusTableRow("Level_39", "269793", "141", "137", "47", "12", "32", "21"));
			Rows.Add( new FriendStatusTableRow("Level_40", "295494", "150", "155", "50", "14", "34", "21"));
			Rows.Add( new FriendStatusTableRow("Level_41", "322905", "151", "156", "50", "14", "34", "22"));
			Rows.Add( new FriendStatusTableRow("Level_42", "352094", "154", "158", "51", "14", "34", "22"));
			Rows.Add( new FriendStatusTableRow("Level_43", "383129", "155", "158", "51", "14", "34", "23"));
			Rows.Add( new FriendStatusTableRow("Level_44", "416078", "156", "165", "55", "15", "38", "23"));
			Rows.Add( new FriendStatusTableRow("Level_45", "451009", "158", "167", "55", "15", "38", "24"));
			Rows.Add( new FriendStatusTableRow("Level_46", "487990", "161", "167", "56", "15", "38", "24"));
			Rows.Add( new FriendStatusTableRow("Level_47", "527089", "165", "170", "57", "15", "38", "25"));
			Rows.Add( new FriendStatusTableRow("Level_48", "568374", "168", "175", "58", "16", "41", "25"));
			Rows.Add( new FriendStatusTableRow("Level_49", "611913", "169", "175", "59", "16", "41", "25"));
			Rows.Add( new FriendStatusTableRow("Level_50", "657774", "171", "180", "60", "16", "41", "25"));
			Rows.Add( new FriendStatusTableRow("Level_51", "706025", "172", "180", "61", "16", "42", "27"));
			Rows.Add( new FriendStatusTableRow("Level_52", "756734", "180", "195", "64", "18", "43", "27"));
			Rows.Add( new FriendStatusTableRow("Level_53", "809969", "181", "196", "64", "18", "43", "27"));
			Rows.Add( new FriendStatusTableRow("Level_54", "865798", "183", "196", "65", "18", "43", "27"));
			Rows.Add( new FriendStatusTableRow("Level_55", "924289", "185", "198", "66", "18", "45", "28"));
			Rows.Add( new FriendStatusTableRow("Level_56", "985510", "195", "205", "69", "18", "46", "31"));
			Rows.Add( new FriendStatusTableRow("Level_57", "1049529", "198", "207", "69", "18", "46", "31"));
			Rows.Add( new FriendStatusTableRow("Level_58", "1116414", "201", "209", "70", "19", "47", "31"));
			Rows.Add( new FriendStatusTableRow("Level_59", "1186233", "203", "209", "70", "19", "48", "31"));
			Rows.Add( new FriendStatusTableRow("Level_60", "1259054", "210", "215", "74", "20", "50", "31"));
			Rows.Add( new FriendStatusTableRow("Level_61", "1335030", "212", "220", "74", "20", "50", "31"));
			Rows.Add( new FriendStatusTableRow("Level_62", "1414314", "215", "222", "75", "20", "50", "32"));
			Rows.Add( new FriendStatusTableRow("Level_63", "1497059", "217", "225", "75", "20", "51", "32"));
			Rows.Add( new FriendStatusTableRow("Level_64", "1583418", "225", "230", "78", "21", "52", "34"));
			Rows.Add( new FriendStatusTableRow("Level_65", "1673544", "227", "230", "78", "21", "53", "34"));
			Rows.Add( new FriendStatusTableRow("Level_66", "1767590", "228", "235", "80", "21", "54", "34"));
			Rows.Add( new FriendStatusTableRow("Level_67", "1865709", "229", "237", "81", "21", "54", "35"));
			Rows.Add( new FriendStatusTableRow("Level_68", "1968054", "232", "250", "83", "22", "57", "35"));
			Rows.Add( new FriendStatusTableRow("Level_69", "2074778", "235", "252", "83", "22", "57", "35"));
			Rows.Add( new FriendStatusTableRow("Level_70", "2186034", "236", "253", "85", "22", "57", "35"));
			Rows.Add( new FriendStatusTableRow("Level_71", "2301975", "238", "255", "86", "22", "58", "37"));
			Rows.Add( new FriendStatusTableRow("Level_72", "2422754", "255", "260", "87", "24", "59", "37"));
			Rows.Add( new FriendStatusTableRow("Level_73", "2548524", "257", "262", "88", "24", "59", "38"));
			Rows.Add( new FriendStatusTableRow("Level_74", "2679438", "260", "263", "89", "24", "60", "38"));
			Rows.Add( new FriendStatusTableRow("Level_75", "2815649", "261", "265", "90", "24", "61", "39"));
			Rows.Add( new FriendStatusTableRow("Level_76", "2957310", "264", "275", "93", "25", "62", "39"));
			Rows.Add( new FriendStatusTableRow("Level_77", "3104574", "267", "277", "93", "25", "62", "39"));
			Rows.Add( new FriendStatusTableRow("Level_78", "3257594", "270", "278", "93", "25", "63", "40"));
			Rows.Add( new FriendStatusTableRow("Level_79", "3416523", "273", "280", "96", "25", "63", "41"));
			Rows.Add( new FriendStatusTableRow("Level_80", "3581514", "276", "290", "97", "26", "66", "41"));
			Rows.Add( new FriendStatusTableRow("Level_81", "3752720", "278", "290", "98", "26", "66", "42"));
			Rows.Add( new FriendStatusTableRow("Level_82", "3930294", "279", "290", "99", "26", "66", "42"));
			Rows.Add( new FriendStatusTableRow("Level_83", "4114389", "281", "295", "100", "26", "66", "42"));
			Rows.Add( new FriendStatusTableRow("Level_84", "4305158", "285", "300", "103", "27", "70", "44"));
			Rows.Add( new FriendStatusTableRow("Level_85", "4502754", "287", "302", "103", "27", "70", "44"));
			Rows.Add( new FriendStatusTableRow("Level_86", "4707330", "289", "302", "103", "27", "70", "44"));
			Rows.Add( new FriendStatusTableRow("Level_87", "4919039", "291", "305", "105", "27", "70", "45"));
			Rows.Add( new FriendStatusTableRow("Level_88", "5138034", "292", "320", "106", "28", "72", "46"));
			Rows.Add( new FriendStatusTableRow("Level_89", "5364468", "294", "322", "106", "28", "72", "46"));
			Rows.Add( new FriendStatusTableRow("Level_90", "5598494", "296", "322", "109", "28", "72", "46"));
			Rows.Add( new FriendStatusTableRow("Level_91", "5840265", "300", "325", "110", "29", "74", "47"));
			Rows.Add( new FriendStatusTableRow("Level_92", "6089934", "301", "330", "111", "29", "75", "48"));
			Rows.Add( new FriendStatusTableRow("Level_93", "6347654", "303", "332", "112", "29", "75", "48"));
			Rows.Add( new FriendStatusTableRow("Level_94", "6613578", "304", "335", "113", "29", "76", "48"));
			Rows.Add( new FriendStatusTableRow("Level_95", "6887859", "305", "337", "114", "29", "76", "48"));
			Rows.Add( new FriendStatusTableRow("Level_96", "7170650", "315", "345", "116", "31", "79", "50"));
			Rows.Add( new FriendStatusTableRow("Level_97", "7462104", "318", "345", "116", "31", "79", "50"));
			Rows.Add( new FriendStatusTableRow("Level_98", "7762374", "321", "347", "117", "31", "79", "50"));
			Rows.Add( new FriendStatusTableRow("Level_99", "8071613", "323", "349", "119", "31", "80", "51"));
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
		public FriendStatusTableRow GetRow(rowIds in_RowID)
		{
			FriendStatusTableRow ret = null;
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
		public FriendStatusTableRow GetRow(string in_RowString)
		{
			FriendStatusTableRow ret = null;
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
