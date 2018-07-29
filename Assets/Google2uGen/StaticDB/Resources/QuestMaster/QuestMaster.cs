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
	public class QuestMasterRow : IGoogle2uRow
	{
		public string _Name;
		public string _Type;
		public int _Target;
		public string _Description;
		public QuestMasterRow(string __ID, string __Name, string __Type, string __Target, string __Description) 
		{
			_Name = __Name.Trim();
			_Type = __Type.Trim();
			{
			int res;
				if(int.TryParse(__Target, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Target = res;
				else
					Debug.LogError("Failed To Convert _Target string: "+ __Target +" to int");
			}
			_Description = __Description.Trim();
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
					ret = _Type.ToString();
					break;
				case 2:
					ret = _Target.ToString();
					break;
				case 3:
					ret = _Description.ToString();
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
				case "Type":
					ret = _Type.ToString();
					break;
				case "Target":
					ret = _Target.ToString();
					break;
				case "Description":
					ret = _Description.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "Type" + " : " + _Type.ToString() + "} ";
			ret += "{" + "Target" + " : " + _Target.ToString() + "} ";
			ret += "{" + "Description" + " : " + _Description.ToString() + "} ";
			return ret;
		}
	}
	public sealed class QuestMaster : IGoogle2uDB
	{
		public enum rowIds {
			ID_001
		};
		public string [] rowNames = {
			"ID_001"
		};
		public System.Collections.Generic.List<QuestMasterRow> Rows = new System.Collections.Generic.List<QuestMasterRow>();

		public static QuestMaster Instance
		{
			get { return NestedQuestMaster.instance; }
		}

		private class NestedQuestMaster
		{
			static NestedQuestMaster() { }
			internal static readonly QuestMaster instance = new QuestMaster();
		}

		private QuestMaster()
		{
			Rows.Add( new QuestMasterRow("ID_001", "ねむけ、さむけ", "Talk", "1", ""));
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
		public QuestMasterRow GetRow(rowIds in_RowID)
		{
			QuestMasterRow ret = null;
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
		public QuestMasterRow GetRow(string in_RowString)
		{
			QuestMasterRow ret = null;
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
