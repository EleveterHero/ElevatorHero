using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;      //!< デプロイ時にEditorスクリプトが入るとエラーになるので
#endif

public class BackSprite : MonoBehaviour {

    float space = 10.75f;

	//背景に使用するかもしれない画像のデータ
	static Dictionary<string,Sprite> g_static_sprites = null;

	//移動処理を行うかどうか
	public bool move = false;

	//移動スピード（5.0ｆで１階を4秒ほど、画像の大きさによってプログラム側で調整）
	public float speed = 5.0f;

	
	//階数
	[SerializeField]
	public float floor = 1.0f;

    public int max_floor = 10;

	//背景のスプライトども
	GameObject[] backsprites = null;

	//ループフラグ
	public bool loop = false;

    Vector3 first_floor_pos;

    GameObject parent = null;

	void Awake()
	{
        parent = new GameObject("back_parent");
        parent.transform.SetParent(transform);
        parent.transform.localPosition = Vector3.zero;
        parent.gameObject.layer = LayerMask.NameToLayer("BackGround");
        
		//画像のロード
		if(g_static_sprites == null)
		{
		   g_static_sprites = new Dictionary<string, Sprite>();


			foreach (Sprite sp in Resources.LoadAll<Sprite>("Image/BattleBack"))
			{
				g_static_sprites.Add(sp.name, sp);
			}

		}
		//=============================


		//背景のスポーンと設定
		backsprites = new GameObject[max_floor];

		for(int i=0;i<backsprites.Length;i++)
		{ 
			backsprites[i] = new GameObject("back" + i);
			backsprites[i].transform.SetParent(parent.transform);

			SpriteRenderer renderer=
			backsprites[i].AddComponent<SpriteRenderer>();

			renderer.sprite = g_static_sprites["game_kari"];

			backsprites[i].layer = LayerMask.NameToLayer("BackGround");
			backsprites[i].transform.localPosition = new Vector3(0.0f,i*space,0.0f);
			backsprites[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			//backsprites[j].SetActive(false);
		}
        //==============================

        //if (backsprites[0] != null)
        //{
        //    first_floor_pos = backsprites[0].transform.localPosition;
        //}else
        //{
        //    first_floor_pos = Vector3.zero;
        //}

	}



	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update()
	{
        FloorUpdate();

		CalcurateLoop();

		SetPositions();


	}


    void FloorUpdate()
    {
        if (move)
        {
            floor += speed * Time.deltaTime;
        }
    }


	/// <summary>
	/// ループの判定と処理
	/// </summary>
	void CalcurateLoop()
	{
		if (loop)
		{

            if (floor > max_floor)
            {
                floor = 0.0f;
            }

			
		}
	}


	/// <summary>
	/// 背景画像を一括移動
	/// </summary>
	void SetPositions()
	{

        parent.transform.localPosition = new Vector3(0.0f, (-1.0f * floor * space) + space, 0.0f);

	}



	/// <summary>
	/// インスペクタービューの拡張
	/// </summary>
	//====================================================================================================


#if UNITY_EDITOR

	[CustomEditor(typeof(BackSprite))]
	public class BackSpriteEditor : Editor
	{

		public override void OnInspectorGUI()
		{

            serializedObject.Update();
            // 対象となるオブジェクト
            var backsprite = target as BackSprite;

			// プロパティ用のGUI追加
			EditorGUILayout.LabelField("ここで変更した内容は、");
			EditorGUILayout.LabelField("スプリクトにすぐに適応されます。");
			backsprite.move = EditorGUILayout.Toggle("Move", backsprite.move);
			backsprite.loop = EditorGUILayout.Toggle("Loop", backsprite.loop);
			backsprite.speed = EditorGUILayout.FloatField("Speed（1で1秒に１階）", backsprite.speed);
			backsprite.floor = EditorGUILayout.FloatField("Floor(地下は0Fから)", backsprite.floor);
            backsprite.max_floor = EditorGUILayout.IntField("最大階数", backsprite.max_floor);

            serializedObject.ApplyModifiedProperties();

            EditorUtility.SetDirty(target);

        }
	}


#endif






}
