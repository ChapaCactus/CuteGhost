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
	public class ShopMasterRow : IGoogle2uRow
	{
		public string _Name;
		public System.Collections.Generic.List<string> _Item = new System.Collections.Generic.List<string>();
		public ShopMasterRow(string __ID, string __Name, string __Item) 
		{
			_Name = __Name.Trim();
			{
				string []result = __Item.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_Item.Add( result[i].Trim() );
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
					ret = _Item.ToString();
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
				case "Item":
					ret = _Item.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "Item" + " : " + _Item.ToString() + "} ";
			return ret;
		}
	}
	public sealed class ShopMaster : IGoogle2uDB
	{
		public enum rowIds {
			ID_001, ID_002
		};
		public string [] rowNames = {
			"ID_001", "ID_002"
		};
		public System.Collections.Generic.List<ShopMasterRow> Rows = new System.Collections.Generic.List<ShopMasterRow>();

		public static ShopMaster Instance
		{
			get { return NestedShopMaster.instance; }
		}

		private class NestedShopMaster
		{
			static NestedShopMaster() { }
			internal static readonly ShopMaster instance = new ShopMaster();
		}

		private ShopMaster()
		{
			Rows.Add( new ShopMasterRow("ID_001", "ショップ1", "ID_001|ID_002|ID_003"));
			Rows.Add( new ShopMasterRow("ID_002", "ショップ2", "ID_001|ID_002|ID_003|ID_004|ID_005"));
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
		public ShopMasterRow GetRow(rowIds in_RowID)
		{
			ShopMasterRow ret = null;
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
		public ShopMasterRow GetRow(string in_RowString)
		{
			ShopMasterRow ret = null;
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
