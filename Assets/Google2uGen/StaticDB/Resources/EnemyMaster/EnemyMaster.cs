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
	public class EnemyMasterRow : IGoogle2uRow
	{
		public string _Name;
		public int _Level;
		public int _MaxHealth;
		public int _ATK;
		public System.Collections.Generic.List<string> _DropItem = new System.Collections.Generic.List<string>();
		public string _Sprite;
		public EnemyMasterRow(string __ID, string __Name, string __Level, string __MaxHealth, string __ATK, string __DropItem, string __Sprite) 
		{
			_Name = __Name.Trim();
			{
			int res;
				if(int.TryParse(__Level, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Level = res;
				else
					Debug.LogError("Failed To Convert _Level string: "+ __Level +" to int");
			}
			{
			int res;
				if(int.TryParse(__MaxHealth, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_MaxHealth = res;
				else
					Debug.LogError("Failed To Convert _MaxHealth string: "+ __MaxHealth +" to int");
			}
			{
			int res;
				if(int.TryParse(__ATK, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_ATK = res;
				else
					Debug.LogError("Failed To Convert _ATK string: "+ __ATK +" to int");
			}
			{
				string []result = __DropItem.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_DropItem.Add( result[i].Trim() );
				}
			}
			_Sprite = __Sprite.Trim();
		}

		public int Length { get { return 6; } }

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
					ret = _Level.ToString();
					break;
				case 2:
					ret = _MaxHealth.ToString();
					break;
				case 3:
					ret = _ATK.ToString();
					break;
				case 4:
					ret = _DropItem.ToString();
					break;
				case 5:
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
				case "Level":
					ret = _Level.ToString();
					break;
				case "MaxHealth":
					ret = _MaxHealth.ToString();
					break;
				case "ATK":
					ret = _ATK.ToString();
					break;
				case "DropItem":
					ret = _DropItem.ToString();
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
			ret += "{" + "Level" + " : " + _Level.ToString() + "} ";
			ret += "{" + "MaxHealth" + " : " + _MaxHealth.ToString() + "} ";
			ret += "{" + "ATK" + " : " + _ATK.ToString() + "} ";
			ret += "{" + "DropItem" + " : " + _DropItem.ToString() + "} ";
			ret += "{" + "Sprite" + " : " + _Sprite.ToString() + "} ";
			return ret;
		}
	}
	public sealed class EnemyMaster : IGoogle2uDB
	{
		public enum rowIds {
			Empty, ID_001, ID_002
		};
		public string [] rowNames = {
			"Empty", "ID_001", "ID_002"
		};
		public System.Collections.Generic.List<EnemyMasterRow> Rows = new System.Collections.Generic.List<EnemyMasterRow>();

		public static EnemyMaster Instance
		{
			get { return NestedEnemyMaster.instance; }
		}

		private class NestedEnemyMaster
		{
			static NestedEnemyMaster() { }
			internal static readonly EnemyMaster instance = new EnemyMaster();
		}

		private EnemyMaster()
		{
			Rows.Add( new EnemyMasterRow("Empty", "Empty", "1", "9999", "0", "", ""));
			Rows.Add( new EnemyMasterRow("ID_001", "ながーい", "1", "10", "3", "ID_001|100%", "Sprites/Enemy/Longie"));
			Rows.Add( new EnemyMasterRow("ID_002", "ふとーい", "1", "20", "4", "ID_002|20%", "Sprites/Enemy/Fattie"));
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
		public EnemyMasterRow GetRow(rowIds in_RowID)
		{
			EnemyMasterRow ret = null;
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
		public EnemyMasterRow GetRow(string in_RowString)
		{
			EnemyMasterRow ret = null;
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
