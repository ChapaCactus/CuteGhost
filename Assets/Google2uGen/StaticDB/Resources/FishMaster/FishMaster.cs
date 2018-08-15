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
	public class FishMasterRow : IGoogle2uRow
	{
		public string _Name;
		public float _BiteTime;
		public string _Sprite;
		public FishMasterRow(string __ID, string __Name, string __BiteTime, string __Sprite) 
		{
			_Name = __Name.Trim();
			{
			float res;
				if(float.TryParse(__BiteTime, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_BiteTime = res;
				else
					Debug.LogError("Failed To Convert _BiteTime string: "+ __BiteTime +" to float");
			}
			_Sprite = __Sprite.Trim();
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
					ret = _Name.ToString();
					break;
				case 1:
					ret = _BiteTime.ToString();
					break;
				case 2:
					ret = _Sprite.ToString();
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
				case "BiteTime":
					ret = _BiteTime.ToString();
					break;
				case "Sprite":
					ret = _Sprite.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "BiteTime" + " : " + _BiteTime.ToString() + "} ";
			ret += "{" + "Sprite" + " : " + _Sprite.ToString() + "} ";
			return ret;
		}
	}
	public sealed class FishMaster : IGoogle2uDB
	{
		public enum rowIds {
			Small, Big
		};
		public string [] rowNames = {
			"Small", "Big"
		};
		public System.Collections.Generic.List<FishMasterRow> Rows = new System.Collections.Generic.List<FishMasterRow>();

		public static FishMaster Instance
		{
			get { return NestedFishMaster.instance; }
		}

		private class NestedFishMaster
		{
			static NestedFishMaster() { }
			internal static readonly FishMaster instance = new FishMaster();
		}

		private FishMaster()
		{
			Rows.Add( new FishMasterRow("Small", "ちいさなサカナ", "3.0", "Fish"));
			Rows.Add( new FishMasterRow("Big", "おおきなサカナ", "0.7", "Fish"));
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
		public FishMasterRow GetRow(rowIds in_RowID)
		{
			FishMasterRow ret = null;
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
		public FishMasterRow GetRow(string in_RowString)
		{
			FishMasterRow ret = null;
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
