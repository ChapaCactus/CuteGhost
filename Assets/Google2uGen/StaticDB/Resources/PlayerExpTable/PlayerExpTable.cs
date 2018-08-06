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
	public class PlayerExpTableRow : IGoogle2uRow
	{
		public int _Exp;
		public PlayerExpTableRow(string __ID, string __Exp) 
		{
			{
			int res;
				if(int.TryParse(__Exp, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Exp = res;
				else
					Debug.LogError("Failed To Convert _Exp string: "+ __Exp +" to int");
			}
		}

		public int Length { get { return 1; } }

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
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Exp" + " : " + _Exp.ToString() + "} ";
			return ret;
		}
	}
	public sealed class PlayerExpTable : IGoogle2uDB
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
		public System.Collections.Generic.List<PlayerExpTableRow> Rows = new System.Collections.Generic.List<PlayerExpTableRow>();

		public static PlayerExpTable Instance
		{
			get { return NestedPlayerExpTable.instance; }
		}

		private class NestedPlayerExpTable
		{
			static NestedPlayerExpTable() { }
			internal static readonly PlayerExpTable instance = new PlayerExpTable();
		}

		private PlayerExpTable()
		{
			Rows.Add( new PlayerExpTableRow("Level_01", "0"));
			Rows.Add( new PlayerExpTableRow("Level_02", "4"));
			Rows.Add( new PlayerExpTableRow("Level_03", "17"));
			Rows.Add( new PlayerExpTableRow("Level_04", "44"));
			Rows.Add( new PlayerExpTableRow("Level_05", "109"));
			Rows.Add( new PlayerExpTableRow("Level_06", "236"));
			Rows.Add( new PlayerExpTableRow("Level_07", "449"));
			Rows.Add( new PlayerExpTableRow("Level_08", "772"));
			Rows.Add( new PlayerExpTableRow("Level_09", "1,229"));
			Rows.Add( new PlayerExpTableRow("Level_10", "1,884"));
			Rows.Add( new PlayerExpTableRow("Level_11", "2,611"));
			Rows.Add( new PlayerExpTableRow("Level_12", "3,644"));
			Rows.Add( new PlayerExpTableRow("Level_13", "4,877"));
			Rows.Add( new PlayerExpTableRow("Level_14", "6,364"));
			Rows.Add( new PlayerExpTableRow("Level_15", "8,129"));
			Rows.Add( new PlayerExpTableRow("Level_16", "10,703"));
			Rows.Add( new PlayerExpTableRow("Level_17", "13,241"));
			Rows.Add( new PlayerExpTableRow("Level_18", "16,214"));
			Rows.Add( new PlayerExpTableRow("Level_19", "19,673"));
			Rows.Add( new PlayerExpTableRow("Level_20", "23,699"));
			Rows.Add( new PlayerExpTableRow("Level_21", "28,253"));
			Rows.Add( new PlayerExpTableRow("Level_22", "33,476"));
			Rows.Add( new PlayerExpTableRow("Level_23", "39,389"));
			Rows.Add( new PlayerExpTableRow("Level_24", "46,043"));
			Rows.Add( new PlayerExpTableRow("Level_25", "53,489"));
			Rows.Add( new PlayerExpTableRow("Level_26", "61,778"));
			Rows.Add( new PlayerExpTableRow("Level_27", "70,961"));
			Rows.Add( new PlayerExpTableRow("Level_28", "81,089"));
			Rows.Add( new PlayerExpTableRow("Level_29", "92,213"));
			Rows.Add( new PlayerExpTableRow("Level_30", "104,384"));
			Rows.Add( new PlayerExpTableRow("Level_31", "117,653"));
			Rows.Add( new PlayerExpTableRow("Level_32", "132,071"));
			Rows.Add( new PlayerExpTableRow("Level_33", "147,689"));
			Rows.Add( new PlayerExpTableRow("Level_34", "164,558"));
			Rows.Add( new PlayerExpTableRow("Level_35", "182,729"));
			Rows.Add( new PlayerExpTableRow("Level_36", "202,270"));
			Rows.Add( new PlayerExpTableRow("Level_37", "223,249"));
			Rows.Add( new PlayerExpTableRow("Level_38", "245,734"));
			Rows.Add( new PlayerExpTableRow("Level_39", "269,793"));
			Rows.Add( new PlayerExpTableRow("Level_40", "295,494"));
			Rows.Add( new PlayerExpTableRow("Level_41", "322,905"));
			Rows.Add( new PlayerExpTableRow("Level_42", "352,094"));
			Rows.Add( new PlayerExpTableRow("Level_43", "383,129"));
			Rows.Add( new PlayerExpTableRow("Level_44", "416,078"));
			Rows.Add( new PlayerExpTableRow("Level_45", "451,009"));
			Rows.Add( new PlayerExpTableRow("Level_46", "487,990"));
			Rows.Add( new PlayerExpTableRow("Level_47", "527,089"));
			Rows.Add( new PlayerExpTableRow("Level_48", "568,374"));
			Rows.Add( new PlayerExpTableRow("Level_49", "611,913"));
			Rows.Add( new PlayerExpTableRow("Level_50", "657,774"));
			Rows.Add( new PlayerExpTableRow("Level_51", "706,025"));
			Rows.Add( new PlayerExpTableRow("Level_52", "756,734"));
			Rows.Add( new PlayerExpTableRow("Level_53", "809,969"));
			Rows.Add( new PlayerExpTableRow("Level_54", "865,798"));
			Rows.Add( new PlayerExpTableRow("Level_55", "924,289"));
			Rows.Add( new PlayerExpTableRow("Level_56", "985,510"));
			Rows.Add( new PlayerExpTableRow("Level_57", "1,049,529"));
			Rows.Add( new PlayerExpTableRow("Level_58", "1,116,414"));
			Rows.Add( new PlayerExpTableRow("Level_59", "1,186,233"));
			Rows.Add( new PlayerExpTableRow("Level_60", "1,259,054"));
			Rows.Add( new PlayerExpTableRow("Level_61", "1,335,030"));
			Rows.Add( new PlayerExpTableRow("Level_62", "1,414,314"));
			Rows.Add( new PlayerExpTableRow("Level_63", "1,497,059"));
			Rows.Add( new PlayerExpTableRow("Level_64", "1,583,418"));
			Rows.Add( new PlayerExpTableRow("Level_65", "1,673,544"));
			Rows.Add( new PlayerExpTableRow("Level_66", "1,767,590"));
			Rows.Add( new PlayerExpTableRow("Level_67", "1,865,709"));
			Rows.Add( new PlayerExpTableRow("Level_68", "1,968,054"));
			Rows.Add( new PlayerExpTableRow("Level_69", "2,074,778"));
			Rows.Add( new PlayerExpTableRow("Level_70", "2,186,034"));
			Rows.Add( new PlayerExpTableRow("Level_71", "2,301,975"));
			Rows.Add( new PlayerExpTableRow("Level_72", "2,422,754"));
			Rows.Add( new PlayerExpTableRow("Level_73", "2,548,524"));
			Rows.Add( new PlayerExpTableRow("Level_74", "2,679,438"));
			Rows.Add( new PlayerExpTableRow("Level_75", "2,815,649"));
			Rows.Add( new PlayerExpTableRow("Level_76", "2,957,310"));
			Rows.Add( new PlayerExpTableRow("Level_77", "3,104,574"));
			Rows.Add( new PlayerExpTableRow("Level_78", "3,257,594"));
			Rows.Add( new PlayerExpTableRow("Level_79", "3,416,523"));
			Rows.Add( new PlayerExpTableRow("Level_80", "3,581,514"));
			Rows.Add( new PlayerExpTableRow("Level_81", "3,752,720"));
			Rows.Add( new PlayerExpTableRow("Level_82", "3,930,294"));
			Rows.Add( new PlayerExpTableRow("Level_83", "4,114,389"));
			Rows.Add( new PlayerExpTableRow("Level_84", "4,305,158"));
			Rows.Add( new PlayerExpTableRow("Level_85", "4,502,754"));
			Rows.Add( new PlayerExpTableRow("Level_86", "4,707,330"));
			Rows.Add( new PlayerExpTableRow("Level_87", "4,919,039"));
			Rows.Add( new PlayerExpTableRow("Level_88", "5,138,034"));
			Rows.Add( new PlayerExpTableRow("Level_89", "5,364,468"));
			Rows.Add( new PlayerExpTableRow("Level_90", "5,598,494"));
			Rows.Add( new PlayerExpTableRow("Level_91", "5,840,265"));
			Rows.Add( new PlayerExpTableRow("Level_92", "6,089,934"));
			Rows.Add( new PlayerExpTableRow("Level_93", "6,347,654"));
			Rows.Add( new PlayerExpTableRow("Level_94", "6,613,578"));
			Rows.Add( new PlayerExpTableRow("Level_95", "6,887,859"));
			Rows.Add( new PlayerExpTableRow("Level_96", "7,170,650"));
			Rows.Add( new PlayerExpTableRow("Level_97", "7,462,104"));
			Rows.Add( new PlayerExpTableRow("Level_98", "7,762,374"));
			Rows.Add( new PlayerExpTableRow("Level_99", "8,071,613"));
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
		public PlayerExpTableRow GetRow(rowIds in_RowID)
		{
			PlayerExpTableRow ret = null;
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
		public PlayerExpTableRow GetRow(string in_RowString)
		{
			PlayerExpTableRow ret = null;
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
