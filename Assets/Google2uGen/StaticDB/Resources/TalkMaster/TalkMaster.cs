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
		public string _Message;
		public TalkMasterRow(string __ID, string __Message) 
		{
			_Message = __Message.Trim();
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
					ret = _Message.ToString();
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
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Message" + " : " + _Message.ToString() + "} ";
			return ret;
		}
	}
	public sealed class TalkMaster : IGoogle2uDB
	{
		public enum rowIds {
			ID_001
		};
		public string [] rowNames = {
			"ID_001"
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
			Rows.Add( new TalkMasterRow("ID_001", "あのぉ…"));
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
