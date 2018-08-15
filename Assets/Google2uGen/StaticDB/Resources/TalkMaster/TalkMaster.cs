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
	public class TalkMasterRow : IGoogle2uRow
	{
		public System.Collections.Generic.List<string> _Message = new System.Collections.Generic.List<string>();
		public System.Collections.Generic.List<string> _Battle = new System.Collections.Generic.List<string>();
		public System.Collections.Generic.List<string> _Choises = new System.Collections.Generic.List<string>();
		public TalkMasterRow(string __ID, string __Message, string __Battle, string __Choises) 
		{
			{
				string []result = __Message.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_Message.Add( result[i].Trim() );
				}
			}
			{
				string []result = __Battle.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_Battle.Add( result[i].Trim() );
				}
			}
			{
				string []result = __Choises.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_Choises.Add( result[i].Trim() );
				}
			}
		}

		public int Length { get { return 3; } }

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
					ret = _Message.ToString();
					break;
				case 1:
					ret = _Battle.ToString();
					break;
				case 2:
					ret = _Choises.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "Message":
					ret = _Message.ToString();
					break;
				case "Battle":
					ret = _Battle.ToString();
					break;
				case "Choises":
					ret = _Choises.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Message" + " : " + _Message.ToString() + "} ";
			ret += "{" + "Battle" + " : " + _Battle.ToString() + "} ";
			ret += "{" + "Choises" + " : " + _Choises.ToString() + "} ";
			return ret;
		}
	}
	public sealed class TalkMaster : IGoogle2uDB
	{
		public enum rowIds {
			ID_001, ID_002, ID_003, ID_004, ID_005, ID_006, ID_007, Monjiro_Talk1
		};
		public string [] rowNames = {
			"ID_001", "ID_002", "ID_003", "ID_004", "ID_005", "ID_006", "ID_007", "Monjiro_Talk1"
		};
		public System.Collections.Generic.List<TalkMasterRow> Rows = new System.Collections.Generic.List<TalkMasterRow>();

		public static TalkMaster Instance
		{
			get { return NestedTalkMaster.instance; }
		}

		private class NestedTalkMaster
		{
			static NestedTalkMaster() { }
			internal static readonly TalkMaster instance = new TalkMaster();
		}

		private TalkMaster()
		{
			Rows.Add( new TalkMasterRow("ID_001", "あのぉ|たのみがあるんです|このところ　さむくてさむくて|あたたかくなるものを\nとってきてください！", "None", "None"));
			Rows.Add( new TalkMasterRow("ID_002", "たのみました", "None", "None"));
			Rows.Add( new TalkMasterRow("ID_003", "ここは、せかいのはてです\nおわりです", "None", "None"));
			Rows.Add( new TalkMasterRow("ID_004", "たたかいますか？", "None", "ID_005|ID_006"));
			Rows.Add( new TalkMasterRow("ID_005", "よしたたかえ！", "ID_001|ID_002", "None"));
			Rows.Add( new TalkMasterRow("ID_006", "やめとくのね", "None", "None"));
			Rows.Add( new TalkMasterRow("ID_007", "わからない", "None", "None"));
			Rows.Add( new TalkMasterRow("Monjiro_Talk1", "おれ・・・|・・・|いぬ、やめちまったんだ。|・・・", "None", "None"));
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
		public TalkMasterRow GetRow(rowIds in_RowID)
		{
			TalkMasterRow ret = null;
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
		public TalkMasterRow GetRow(string in_RowString)
		{
			TalkMasterRow ret = null;
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
