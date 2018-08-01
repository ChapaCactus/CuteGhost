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
	public class EnemyGroupRow : IGoogle2uRow
	{
		public string _Name;
		public string _Enemy1;
		public string _Enemy2;
		public string _Enemy3;
		public string _Enemy4;
		public string _Enemy5;
		public EnemyGroupRow(string __ID, string __Name, string __Enemy1, string __Enemy2, string __Enemy3, string __Enemy4, string __Enemy5) 
		{
			_Name = __Name.Trim();
			_Enemy1 = __Enemy1.Trim();
			_Enemy2 = __Enemy2.Trim();
			_Enemy3 = __Enemy3.Trim();
			_Enemy4 = __Enemy4.Trim();
			_Enemy5 = __Enemy5.Trim();
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
					ret = _Enemy1.ToString();
					break;
				case 2:
					ret = _Enemy2.ToString();
					break;
				case 3:
					ret = _Enemy3.ToString();
					break;
				case 4:
					ret = _Enemy4.ToString();
					break;
				case 5:
					ret = _Enemy5.ToString();
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
				case "Enemy1":
					ret = _Enemy1.ToString();
					break;
				case "Enemy2":
					ret = _Enemy2.ToString();
					break;
				case "Enemy3":
					ret = _Enemy3.ToString();
					break;
				case "Enemy4":
					ret = _Enemy4.ToString();
					break;
				case "Enemy5":
					ret = _Enemy5.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "Enemy1" + " : " + _Enemy1.ToString() + "} ";
			ret += "{" + "Enemy2" + " : " + _Enemy2.ToString() + "} ";
			ret += "{" + "Enemy3" + " : " + _Enemy3.ToString() + "} ";
			ret += "{" + "Enemy4" + " : " + _Enemy4.ToString() + "} ";
			ret += "{" + "Enemy5" + " : " + _Enemy5.ToString() + "} ";
			return ret;
		}
	}
	public sealed class EnemyGroup : IGoogle2uDB
	{
		public enum rowIds {
			ID_001, ID_002
		};
		public string [] rowNames = {
			"ID_001", "ID_002"
		};
		public System.Collections.Generic.List<EnemyGroupRow> Rows = new System.Collections.Generic.List<EnemyGroupRow>();

		public static EnemyGroup Instance
		{
			get { return NestedEnemyGroup.instance; }
		}

		private class NestedEnemyGroup
		{
			static NestedEnemyGroup() { }
			internal static readonly EnemyGroup instance = new EnemyGroup();
		}

		private EnemyGroup()
		{
			Rows.Add( new EnemyGroupRow("ID_001", "あるグループ", "ID_001", "ID_001", "ID_001", "", ""));
			Rows.Add( new EnemyGroupRow("ID_002", "あるグループ", "", "ID_002", "ID_002", "", ""));
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
		public EnemyGroupRow GetRow(rowIds in_RowID)
		{
			EnemyGroupRow ret = null;
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
		public EnemyGroupRow GetRow(string in_RowString)
		{
			EnemyGroupRow ret = null;
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
