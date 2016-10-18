using UnityEngine;
using System.Collections;

public class EnemyMasterTable : MasterTableBase<EnemyMaster> {

	private static readonly string FileName="test";
	public void Load()
	{
		Load (FileName);
	}

}


public class EnemyMaster : MasterBase{
	public int Floor{ get; private set;}
	public int Enemy_Rock{ get; private set;}
	public int Enemy_Rock_Ice{ get; private set;}
	public int Enemy_Fire{ get; private set;}
	public int Enemy_Ruff{ get; private set;}
	public int Enemy_Ghost{ get; private set;}
}
