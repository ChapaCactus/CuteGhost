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
	public class FriendExpTableRow : IGoogle2uRow
	{
		public int _Exp;
		public FriendExpTableRow(string __ID, string __Exp) 
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
	public sealed class FriendExpTable : IGoogle2uDB
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
		public System.Collections.Generic.List<FriendExpTableRow> Rows = new System.Collections.Generic.List<FriendExpTableRow>();

		public static FriendExpTable Instance
		{
			get { return NestedFriendExpTable.instance; }
		}

		private class NestedFriendExpTable
		{
			static NestedFriendExpTable() { }
			internal static readonly FriendExpTable instance = new FriendExpTable();
		}

		private FriendExpTable()
		{
			Rows.Add( new FriendExpTableRow("Level_01", "0"));
			Rows.Add( new FriendExpTableRow("Level_02", "8"));
			Rows.Add( new FriendExpTableRow("Level_03", "32"));
			Rows.Add( new FriendExpTableRow("Level_04", "80"));
			Rows.Add( new FriendExpTableRow("Level_05", "178"));
			Rows.Add( new FriendExpTableRow("Level_06", "352"));
			Rows.Add( new FriendExpTableRow("Level_07", "628"));
			Rows.Add( new FriendExpTableRow("Level_08", "1,032"));
			Rows.Add( new FriendExpTableRow("Level_09", "1,590"));
			Rows.Add( new FriendExpTableRow("Level_10", "2,328"));
			Rows.Add( new FriendExpTableRow("Level_11", "3,272"));
			Rows.Add( new FriendExpTableRow("Level_12", "4,448"));
			Rows.Add( new FriendExpTableRow("Level_13", "5,882"));
			Rows.Add( new FriendExpTableRow("Level_14", "7,600"));
			Rows.Add( new FriendExpTableRow("Level_15", "9,628"));
			Rows.Add( new FriendExpTableRow("Level_16", "12,023"));
			Rows.Add( new FriendExpTableRow("Level_17", "14,842"));
			Rows.Add( new FriendExpTableRow("Level_18", "18,142"));
			Rows.Add( new FriendExpTableRow("Level_19", "21,980"));
			Rows.Add( new FriendExpTableRow("Level_20", "26,413"));
			Rows.Add( new FriendExpTableRow("Level_21", "31,498"));
			Rows.Add( new FriendExpTableRow("Level_22", "37,292"));
			Rows.Add( new FriendExpTableRow("Level_23", "43,852"));
			Rows.Add( new FriendExpTableRow("Level_24", "51,235"));
			Rows.Add( new FriendExpTableRow("Level_25", "59,498"));
			Rows.Add( new FriendExpTableRow("Level_26", "68,698"));
			Rows.Add( new FriendExpTableRow("Level_27", "78,892"));
			Rows.Add( new FriendExpTableRow("Level_28", "90,137"));
			Rows.Add( new FriendExpTableRow("Level_29", "102,490"));
			Rows.Add( new FriendExpTableRow("Level_30", "116,008"));
			Rows.Add( new FriendExpTableRow("Level_31", "130,748"));
			Rows.Add( new FriendExpTableRow("Level_32", "146,767"));
			Rows.Add( new FriendExpTableRow("Level_33", "164,122"));
			Rows.Add( new FriendExpTableRow("Level_34", "182,870"));
			Rows.Add( new FriendExpTableRow("Level_35", "203,068"));
			Rows.Add( new FriendExpTableRow("Level_36", "224,789"));
			Rows.Add( new FriendExpTableRow("Level_37", "248,106"));
			Rows.Add( new FriendExpTableRow("Level_38", "273,092"));
			Rows.Add( new FriendExpTableRow("Level_39", "299,820"));
			Rows.Add( new FriendExpTableRow("Level_40", "328,363"));
			Rows.Add( new FriendExpTableRow("Level_41", "358,794"));
			Rows.Add( new FriendExpTableRow("Level_42", "391,186"));
			Rows.Add( new FriendExpTableRow("Level_43", "425,612"));
			Rows.Add( new FriendExpTableRow("Level_44", "462,145"));
			Rows.Add( new FriendExpTableRow("Level_45", "500,858"));
			Rows.Add( new FriendExpTableRow("Level_46", "541,824"));
			Rows.Add( new FriendExpTableRow("Level_47", "585,116"));
			Rows.Add( new FriendExpTableRow("Level_48", "630,807"));
			Rows.Add( new FriendExpTableRow("Level_49", "678,970"));
			Rows.Add( new FriendExpTableRow("Level_50", "729,678"));
			Rows.Add( new FriendExpTableRow("Level_51", "783,004"));
			Rows.Add( new FriendExpTableRow("Level_52", "839,021"));
			Rows.Add( new FriendExpTableRow("Level_53", "897,802"));
			Rows.Add( new FriendExpTableRow("Level_54", "959,420"));
			Rows.Add( new FriendExpTableRow("Level_55", "1,023,948"));
			Rows.Add( new FriendExpTableRow("Level_56", "1,091,459"));
			Rows.Add( new FriendExpTableRow("Level_57", "1,162,026"));
			Rows.Add( new FriendExpTableRow("Level_58", "1,235,722"));
			Rows.Add( new FriendExpTableRow("Level_59", "1,312,620"));
			Rows.Add( new FriendExpTableRow("Level_60", "1,392,793"));
			Rows.Add( new FriendExpTableRow("Level_61", "1,476,442"));
			Rows.Add( new FriendExpTableRow("Level_62", "1,563,768"));
			Rows.Add( new FriendExpTableRow("Level_63", "1,654,972"));
			Rows.Add( new FriendExpTableRow("Level_64", "1,750,255"));
			Rows.Add( new FriendExpTableRow("Level_65", "1,849,818"));
			Rows.Add( new FriendExpTableRow("Level_66", "1,953,862"));
			Rows.Add( new FriendExpTableRow("Level_67", "2,062,588"));
			Rows.Add( new FriendExpTableRow("Level_68", "2,176,197"));
			Rows.Add( new FriendExpTableRow("Level_69", "2,294,890"));
			Rows.Add( new FriendExpTableRow("Level_70", "2,418,868"));
			Rows.Add( new FriendExpTableRow("Level_71", "2,548,332"));
			Rows.Add( new FriendExpTableRow("Level_72", "2,683,483"));
			Rows.Add( new FriendExpTableRow("Level_73", "2,824,522"));
			Rows.Add( new FriendExpTableRow("Level_74", "2,971,650"));
			Rows.Add( new FriendExpTableRow("Level_75", "3,125,068"));
			Rows.Add( new FriendExpTableRow("Level_76", "3,284,977"));
			Rows.Add( new FriendExpTableRow("Level_77", "3,451,578"));
			Rows.Add( new FriendExpTableRow("Level_78", "3,625,072"));
			Rows.Add( new FriendExpTableRow("Level_79", "3,805,660"));
			Rows.Add( new FriendExpTableRow("Level_80", "3,993,543"));
			Rows.Add( new FriendExpTableRow("Level_81", "4,188,922"));
			Rows.Add( new FriendExpTableRow("Level_82", "4,391,998"));
			Rows.Add( new FriendExpTableRow("Level_83", "4,602,972"));
			Rows.Add( new FriendExpTableRow("Level_84", "4,822,045"));
			Rows.Add( new FriendExpTableRow("Level_85", "5,049,418"));
			Rows.Add( new FriendExpTableRow("Level_86", "5,285,292"));
			Rows.Add( new FriendExpTableRow("Level_87", "5,529,868"));
			Rows.Add( new FriendExpTableRow("Level_88", "5,783,347"));
			Rows.Add( new FriendExpTableRow("Level_89", "6,045,930"));
			Rows.Add( new FriendExpTableRow("Level_90", "6,317,818"));
			Rows.Add( new FriendExpTableRow("Level_91", "6,599,212"));
			Rows.Add( new FriendExpTableRow("Level_92", "6,890,313"));
			Rows.Add( new FriendExpTableRow("Level_93", "7,191,322"));
			Rows.Add( new FriendExpTableRow("Level_94", "7,502,440"));
			Rows.Add( new FriendExpTableRow("Level_95", "7,823,868"));
			Rows.Add( new FriendExpTableRow("Level_96", "8,155,807"));
			Rows.Add( new FriendExpTableRow("Level_97", "8,498,458"));
			Rows.Add( new FriendExpTableRow("Level_98", "8,852,022"));
			Rows.Add( new FriendExpTableRow("Level_99", "9,216,700"));
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
		public FriendExpTableRow GetRow(rowIds in_RowID)
		{
			FriendExpTableRow ret = null;
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
		public FriendExpTableRow GetRow(string in_RowString)
		{
			FriendExpTableRow ret = null;
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
