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
	public class FishPondMasterRow : IGoogle2uRow
	{
		public string _Name;
		public System.Collections.Generic.List<string> _Fishes = new System.Collections.Generic.List<string>();
		public FishPondMasterRow(string __ID, string __Name, string __Fishes) 
		{
			_Name = __Name.Trim();
			{
				string []result = __Fishes.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_Fishes.Add( result[i].Trim() );
				}
			}
		}

		public int Length { get { return 2; } }

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
					ret = _Fishes.ToString();
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
				case "Fishes":
					ret = _Fishes.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "Fishes" + " : " + _Fishes.ToString() + "} ";
			return ret;
		}
	}
	public sealed class FishPondMaster : IGoogle2uDB
	{
		public enum rowIds {
			ID_001, ID_002
		};
		public string [] rowNames = {
			"ID_001", "ID_002"
		};
		public System.Collections.Generic.List<FishPondMasterRow> Rows = new System.Collections.Generic.List<FishPondMasterRow>();

		public static FishPondMaster Instance
		{
			get { return NestedFishPondMaster.instance; }
		}

		private class NestedFishPondMaster
		{
			static NestedFishPondMaster() { }
			internal static readonly FishPondMaster instance = new FishPondMaster();
		}

		private FishPondMaster()
		{
			Rows.Add( new FishPondMasterRow("ID_001", "ふつうのつりぼり", "Small|Small|Small|Small|Small|Small|Big"));
			Rows.Add( new FishPondMasterRow("ID_002", "すごいつりぼり", "Small|Small|Small|Small|Big|Big"));
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
		public FishPondMasterRow GetRow(rowIds in_RowID)
		{
			FishPondMasterRow ret = null;
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
		public FishPondMasterRow GetRow(string in_RowString)
		{
			FishPondMasterRow ret = null;
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
