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
	public class ItemMasterRow : IGoogle2uRow
	{
		public string _Name;
		public int _Price;
		public ItemMasterRow(string __ID, string __Name, string __Price) 
		{
			_Name = __Name.Trim();
			{
			int res;
				if(int.TryParse(__Price, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Price = res;
				else
					Debug.LogError("Failed To Convert _Price string: "+ __Price +" to int");
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
					ret = _Price.ToString();
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
				case "Price":
					ret = _Price.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "Price" + " : " + _Price.ToString() + "} ";
			return ret;
		}
	}
	public sealed class ItemMaster : IGoogle2uDB
	{
		public enum rowIds {
			ID_001, ID_002, ID_003
		};
		public string [] rowNames = {
			"ID_001", "ID_002", "ID_003"
		};
		public System.Collections.Generic.List<ItemMasterRow> Rows = new System.Collections.Generic.List<ItemMasterRow>();

		public static ItemMaster Instance
		{
			get { return NestedItemMaster.instance; }
		}

		private class NestedItemMaster
		{
			static NestedItemMaster() { }
			internal static readonly ItemMaster instance = new ItemMaster();
		}

		private ItemMaster()
		{
			Rows.Add( new ItemMasterRow("ID_001", "コロッケ", "100"));
			Rows.Add( new ItemMasterRow("ID_002", "クリームコロッケ", "200"));
			Rows.Add( new ItemMasterRow("ID_003", "サンダークリームコロッケ", "1000"));
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
		public ItemMasterRow GetRow(rowIds in_RowID)
		{
			ItemMasterRow ret = null;
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
		public ItemMasterRow GetRow(string in_RowString)
		{
			ItemMasterRow ret = null;
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
