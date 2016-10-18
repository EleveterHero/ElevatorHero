using UnityEngine;
using System.Collections;

public class EnemyHoge : MonoBehaviour {

	EnemyMasterTable enemyMasterTable =new EnemyMasterTable ();
	public BackSprite sp=null;

	public GameObject[] enemy_Obj;
	public GameObject parent=null;
	private int prevFloor=0;

	enum EnemyNames
	{
		Rock,
		RockIce,
		Fire,
		Ruff,
		Ghost
	}
	// Use this for initialization
	void Start () {
		enemyMasterTable.Load ();
	}
	
	// Update is called once per frame
	void Update () {
		EnemyCreate ();

		Debug.Log ((int)sp.floor);
	}

	void EnemyCreate()
	{
		//調べる階層と一緒なら
		if (prevFloor == (int)sp.floor) {
			return;
		}
		//csvの中と一致しているか確認
		foreach (var enemyMaster in enemyMasterTable.All) {
			if (enemyMaster.Floor == (int)sp.floor) {
				//フロアが同じなら敵の生成実行
				Create (enemyMaster.Enemy_Rock,EnemyNames.Rock);
				Create (enemyMaster.Enemy_Rock_Ice,EnemyNames.RockIce);
				Create (enemyMaster.Enemy_Fire,EnemyNames.Fire);
				Create (enemyMaster.Enemy_Ruff,EnemyNames.Ruff);
				Create (enemyMaster.Enemy_Ghost,EnemyNames.Ghost);
				//現在の階を保存
				prevFloor = (int)sp.floor;
			}
		}

	}

	//HeroManagerから限界値を取得して範囲制御
	void Create(int val ,EnemyNames name)
	{
		//もし生成値が０なら
		if (val == 0) {
			return;
		}

		//ここから生成
		for (int i = 0; i < val; i++) {
			switch (name) {
			case EnemyNames.RockIce:
				RockIceCreate ();
				break;
			case EnemyNames.Rock:
				RockCreate ();
				break;
			case EnemyNames.Fire:
				FireCreate ();
				break;
			case EnemyNames.Ruff:
				RuffCreate ();
				break;
			case EnemyNames.Ghost:
				GhostCreate ();
				break;
			default:
				Debug.LogAssertion("ピピー！そんな敵はいないのだっ！");
				break;
			}
		}
	}


	//ディクショナリーを使ってキー、ハッシュを決めて探し出す(名前で呼び出す)

	void RockCreate()
	{
		GameObject rock = Instantiate (enemy_Obj [1]);

	}

	void RockIceCreate()
	{
		GameObject rockIce = Instantiate (enemy_Obj [0]);
		rockIce.transform.parent = parent.transform;
		rockIce.name = "Enemy_Ice";
		//rockIce.transform.position.x = Random.Range (0, 10);
		rockIce.layer = LayerMask.NameToLayer ("Main");
	}

	void FireCreate()
	{
		
	}

	void RuffCreate()
	{
		
	}

	void GhostCreate()
	{
		
	}



}
