using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	enum BattleState
	{
		First,
		Main,
		GameOver,
        GameClear,
		Pause
	}


    // バトルシーンで使用するメインのUI
	Canvas m_battle_ui = null;
	Canvas battle_ui
	{
		get
		{
			if (m_battle_ui == null)
			{
				m_battle_ui = GameObject.Find("UI/BattleUI").GetComponent<Canvas>();
			}
			return m_battle_ui;
		}
		
	}


    // ポーズUI
	Canvas m_pause_ui = null;
	Canvas pause_ui
	{
		get
		{
			if(m_pause_ui == null)
			{
				m_pause_ui = GameObject.Find("UI/PoseUI").GetComponent<Canvas>();
			}
			return m_pause_ui;
		}
	}


    // ゲームオーバーのUI
    Canvas m_gameover_ui = null;
    Canvas gameover_ui
    {
        get
        {
            if (m_gameover_ui == null)
            {
                m_gameover_ui = GameObject.Find("UI/GameOverUI").GetComponent<Canvas>();
            }
            return m_gameover_ui;
        }
    }

    //バトルUIのあたり判定用レイキャスター
    GraphicRaycaster m_raycaster_battle = null;
	GraphicRaycaster raycaster_battle
	{
		get
		{
			if(m_raycaster_battle == null)
			{
				m_raycaster_battle = battle_ui.GetComponent<GraphicRaycaster>();
			}
			return m_raycaster_battle;
		}
	}

    //ポーズUIのあたり判定用レイキャスター
    GraphicRaycaster m_raycaster_pose = null;
	GraphicRaycaster raycaster_pose
	{
		get
		{
			if(m_raycaster_pose == null)
			{
				m_raycaster_pose = pause_ui.GetComponent<GraphicRaycaster>();
			}
			return m_raycaster_pose;
		}
	}

    //ゲームオーバーUIのあたり判定用レイキャスター
    GraphicRaycaster m_raycaster_gameover = null;
    GraphicRaycaster raycaster_gameover
    {
        get
        {
            if (m_raycaster_gameover == null)
            {
                m_raycaster_gameover = gameover_ui.GetComponent<GraphicRaycaster>();
            }
            return m_raycaster_gameover;
        }
    }

    //主人公オブジェクト
    GameObject m_hero = null;
	GameObject hero
	{
		get
		{
			if(m_hero == null)
			{
				m_hero = transform.FindChild("Hero").gameObject;
			}
			return m_hero;
		}
	}

    //主人公のマネージャー
    HeroManager m_hero_manager = null;
    HeroManager hero_manager
    {
        get
        {
            if (m_hero_manager == null)
            {
                m_hero_manager = hero.GetComponent<HeroManager>();
            }
            return m_hero_manager;
        }
    }

    //背景を担当するクラス
	BackSprite m_backsprite = null;
	BackSprite backsprite
	{
		get
		{
			if (m_backsprite == null)
			{
				m_backsprite = GameObject.Find("BackGround/BackGround").GetComponent<BackSprite>();
			}
			return m_backsprite;
		}
	}

    //カウントの再生だけをするクラス
    BattleUIReadyAnimMgr m_battle_ui_ready_manager = null;
    BattleUIReadyAnimMgr ready_anim
    {
        get
        {
            if(m_battle_ui_ready_manager == null)
            {
                m_battle_ui_ready_manager = battle_ui.GetComponent<BattleUIReadyAnimMgr>();
            }
            return m_battle_ui_ready_manager;
        }
    }


    //このシーンのステート管理ステートマシン
	StateMachine<BattleState> sm_battlestate = null;





	void Awake()
	{
		sm_battlestate = new StateMachine<BattleState>();
		sm_battlestate.Add(BattleState.First, FirstInit, FirstUpdate);
		sm_battlestate.Add(BattleState.Main, MainInit, MainUpdate,MainEnd);

        sm_battlestate.Add(BattleState.GameOver, GameOverInit, GameOverUpdate, GameOverEnd);
        sm_battlestate.Add(BattleState.GameClear, GameClearInit);

		sm_battlestate.Add(BattleState.Pause, PoseInit, null, PoseEnd);

		
	}

	// Use this for initialization
	void Start () {
		sm_battlestate.SetState(BattleState.First);
	}
	
	// Update is called once per frame
	void Update () {
		if (sm_battlestate != null)
		{
			sm_battlestate.Update();
		}
	}

	void FirstInit()
	{
		pause_ui.gameObject.SetActive(false);
        gameover_ui.gameObject.SetActive(false);

		raycaster_battle.enabled = true;

        hero_manager.sm_hero.SetState(HeroManager.HeroState.FirstInit);

		
		backsprite.move = false;


        hero_manager.hero_status.ResetHP();

        backsprite.floor = 1.0f;

        FadeManager.Instance.Fade(false, 0.5f);

        StartCoroutine(StartCount(0.5f));

	}

    IEnumerator StartCount(float start_waitsec)
    {
        yield return new WaitForSeconds(start_waitsec);
        ready_anim.ShotReadyAnim();
        yield return new WaitForSeconds(2.20f);
        sm_battlestate.SetState(BattleState.Main);
    }

    void StopCount()
    {
        StopCoroutine("StartCount");
        ready_anim.StopReadyAnim();
    }


    void FirstUpdate()
	{
		//if (Input.GetMouseButtonUp(0))
		//{
		//	sm_battlestate.SetState(BattleState.Main);
		//}
	}

	void MainInit()
	{
        hero_manager.sm_hero.SetState(HeroManager.HeroState.Play);
		
		backsprite.move = true;
	}

	void MainUpdate()
	{
       if( backsprite.floor >= backsprite.max_floor)
        {
            sm_battlestate.SetState(BattleState.GameClear);
        }

        if (hero_manager.hero_status.dead)
        {
            sm_battlestate.SetState(BattleState.GameOver);
        }
	}

	void MainEnd()
	{
        hero_manager.sm_hero.SetState(HeroManager.HeroState.Pose);
		backsprite.move = false;
        

	}


	void PoseInit()
	{
		raycaster_battle.enabled = false;

		pause_ui.gameObject.SetActive(true);
		raycaster_pose.enabled = true;
	}


	void PoseEnd()
	{

		raycaster_pose.enabled = false;
		pause_ui.gameObject.SetActive(false);
        raycaster_battle.enabled = true;

    }


    void GameOverInit()
    {
        raycaster_gameover.enabled = true;
        gameover_ui.gameObject.SetActive(true);

    }

    void GameOverUpdate()
    {

    }

    void GameOverEnd()
    {

    }

    void GameClearInit()
    {
        FadeManager.Instance.LoadLevel("clear",0.5f);
    }




    //Button======================================

    public void ShowPose()
    {
        if(sm_battlestate.GetStateName() != BattleState.Main)
        {
            return;
        }

        sm_battlestate.SetState(BattleState.Pause);

    }



    public void GameContinue()
    {
        raycaster_gameover.enabled = false;
        raycaster_pose.enabled = false;

        FadeManager.Instance.Fade(true, 0.5f);

        StartCoroutine(WaitSetState(BattleState.First,0.5f));

    }

    IEnumerator WaitSetState(BattleState state,float sec)
    {
        yield return new WaitForSeconds(sec);
        sm_battlestate.SetState(state);
    }

    public void GameKeep()
    {
        raycaster_gameover.enabled = false;
        raycaster_pose.enabled = false;

        sm_battlestate.SetState(BattleState.Main);
    }

    public void GameReturnTitle()
    {
        FadeManager.Instance.LoadLevel("title", 0.5f);
        raycaster_battle.enabled = false;
        raycaster_gameover.enabled = false;
        raycaster_pose.enabled = false;
    }

    

}
