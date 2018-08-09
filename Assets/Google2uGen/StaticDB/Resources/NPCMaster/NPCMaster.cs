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
	public class NPCMasterRow : IGoogle2uRow
	{
		public string _Name;
		public string _Quest;
		public string _NotOfferTalk;
		public string _OfferedTalk;
		public NPCMasterRow(string __ID, string __Name, string __Quest, string __NotOfferTalk, string __OfferedTalk) 
		{
			_Name = __Name.Trim();
			_Quest = __Quest.Trim();
			_NotOfferTalk = __NotOfferTalk.Trim();
			_OfferedTalk = __OfferedTalk.Trim();
		}

		public int Length { get { return 4; } }

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
					ret = _Name.ToString();
					break;
				case 1:
					ret = _Quest.ToString();
					break;
				case 2:
					ret = _NotOfferTalk.ToString();
					break;
				case 3:
					ret = _OfferedTalk.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "Name":
					ret = _Name.ToString();
					break;
				case "Quest":
					ret = _Quest.ToString();
					break;
				case "NotOfferTalk":
					ret = _NotOfferTalk.ToString();
					break;
				case "OfferedTalk":
					ret = _OfferedTalk.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "Quest" + " : " + _Quest.ToString() + "} ";
			ret += "{" + "NotOfferTalk" + " : " + _NotOfferTalk.ToString() + "} ";
			ret += "{" + "OfferedTalk" + " : " + _OfferedTalk.ToString() + "} ";
			return ret;
		}
	}
	public sealed class NPCMaster : IGoogle2uDB
	{
		public enum rowIds {
			ID_001, ID_002, ID_003, ID_004, Monjiro, Maguro
		};
		public string [] rowNames = {
			"ID_001", "ID_002", "ID_003", "ID_004", "Monjiro", "Maguro"
		};
		public System.Collections.Generic.List<NPCMasterRow> Rows = new System.Collections.Generic.List<NPCMasterRow>();

		public static NPCMaster Instance
		{
			get { return NestedNPCMaster.instance; }
		}

		private class NestedNPCMaster
		{
			static NestedNPCMaster() { }
			internal static readonly NPCMaster instance = new NPCMaster();
		}

		private NPCMaster()
		{
			Rows.Add( new NPCMasterRow("ID_001", "ダイコンちゃん", "ID_001", "ID_001", "ID_002"));
			Rows.Add( new NPCMasterRow("ID_002", "せかいのはてちゃん", "None", "ID_003", "None"));
			Rows.Add( new NPCMasterRow("ID_003", "バトルまねーちゃん", "None", "ID_004", "None"));
			Rows.Add( new NPCMasterRow("ID_004", "NPC", "None", "ID_007", "None"));
			Rows.Add( new NPCMasterRow("Monjiro", "もんじろう", "None", "Monjiro_Talk1", "None"));
			Rows.Add( new NPCMasterRow("Maguro", "まぐろにんげん", "None", "Monjiro_Talk1", "None"));
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
		public NPCMasterRow GetRow(rowIds in_RowID)
		{
			NPCMasterRow ret = null;
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
		public NPCMasterRow GetRow(string in_RowString)
		{
			NPCMasterRow ret = null;
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
