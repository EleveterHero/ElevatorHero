using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;      //!< デプロイ時にEditorスクリプトが入るとエラーになるので
#endif

public class HeroManager : MonoBehaviour {

    public bool stopanimation = false;

   public enum HeroState{
        FirstInit,
        Play,
        Pose,
        Special,
        Damage,
    }

    StateMachine<HeroState> m_sm_hero = null;
    public StateMachine<HeroState> sm_hero
    {
        get
        {
            if(m_sm_hero == null)
            {

                m_sm_hero = new StateMachine<HeroState>();
                m_sm_hero.Add(HeroState.FirstInit, FirstInit);
                m_sm_hero.Add(HeroState.Play, PlayInit, null, PlayEnd);
                m_sm_hero.Add(HeroState.Pose, PoseInit, null, PoseEnd);
                m_sm_hero.Add(HeroState.Special, SpecialInit, SpecialUpdate, SpecialEnd);

                m_sm_hero.SetState(HeroState.Pose);
            }
            return m_sm_hero;
        }
    }


    [SerializeField]
    HeroController m_hero_controller = null;
    HeroController hero_controller
    {
        get
        {
            if (m_hero_controller == null)
            {
                m_hero_controller = GetComponent<HeroController>();
            }
            
            return m_hero_controller;
        }
    }

    [SerializeField]
    Status m_hero_status = null;
    public Status hero_status
    {
        get
        {
            if(m_hero_status == null)
            {
                m_hero_status = GetComponent<Status>();
            }
            return m_hero_status;
        }
    }

    SimpleModel m_hero_live2d_anim = null;
    public SimpleModel hero_live2d_anim
    {
        get
        {
            if(m_hero_live2d_anim == null)
            {
                m_hero_live2d_anim = GetComponent<SimpleModel>();
            }
            return m_hero_live2d_anim;
        }
    }

    Animator m_animator;
    Animator animator
    {
        get
        {
            if (m_animator == null)
            {
                m_animator = GetComponent<Animator>();
            }
            return m_animator;
        }
    }



    void Awake()
    {

    }

   

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
   

	}


    public void SetState(HeroState state)
    {
        sm_hero.SetState(state);
        return;
    }

    void FirstInit()
    {
        hero_status.ResetHP();
        hero_status.Special = 3;

        hero_controller.ResetToStartPosition();


        sm_hero.SetState(HeroState.Pose);
    }


    float downed_speed = 0.0f;

    void PoseInit()
    {
        hero_status.system_got = true;
        downed_speed = animator.speed;
        animator.speed = 0.0f;

        
    }

    void PoseEnd()
    {
        animator.speed = downed_speed;
        hero_status.system_got = false;

    }


    void PlayInit()
    {
        m_hero_controller.move = true;       
    }

    void PlayEnd()
    {     
        m_hero_controller.move = false;
    }

    void SpecialInit()
    {

    }

    void SpecialUpdate()
    {

    }

    void SpecialEnd()
    {

    }


    public HeroState GetState()
    {
        return sm_hero.GetStateName();
    }



    public enum HeroAnimState{
        walking,
        damage,
        freeze
    }
   public void ShotAnimation(HeroAnimState anim_state)
    {
        switch (anim_state)
        {
            case HeroAnimState.walking:
                {
                    animator.Play(Animator.StringToHash("Hero_Walking"), 0);
                    break;
                }
            case HeroAnimState.damage:
                {
                    animator.Play(Animator.StringToHash("Hero_Damage"), 0);
                    break;
                }
            case HeroAnimState.freeze:
                {
                    animator.Play(Animator.StringToHash("Hero_Freeze"), 0);
                    break;
                }
        }
        
    }



//==============================================================================

//#if UNITY_EDITOR

//    [CustomEditor(typeof(HeroManager))]
//    public class HeroManagerEditor : Editor
//    {
//        HeroManager manager = null;

//        HeroStatus m_status;
//        HeroStatus status
//        {
//            get
//            {
//                if(m_status == null)
//                {
//                    m_status = manager.hero_status;
//                }
//                return m_status;
//            }
//        }


//        HeroController m_controller;
//        HeroController controller
//        {
//            get
//            {
//                if(m_controller == null)
//                {
//                    m_controller = manager.hero_controller;
//                }
//                return m_controller;
//            }
//        }



//        public override void OnInspectorGUI()
//        {
//            manager = target as HeroManager;


//            serializedObject.Update();
//            // 対象となるオブジェクト

//            // プロパティ用のGUI追加
//            EditorGUILayout.LabelField("ここで編集することができるのは再生中のみです。");
//            EditorGUILayout.LabelField("再生時に初期化されるので注意してください。");
//            EditorGUILayout.LabelField("");

//            EditorGUILayout.LabelField("HeroManager");
//            EditorGUILayout.LabelField("現在のステート", manager.GetState().ToString());


//            EditorGUILayout.LabelField("");
//            EditorGUILayout.LabelField("HeroSatus");
//            if (status != null)
//            {
//                EditorGUILayout.Toggle("死亡(ReadOnly)", status.dead);
//                EditorGUILayout.Toggle("無敵（ｼｽﾃﾑReadOnly）", status.system_got);
//                status.got = EditorGUILayout.Toggle("無敵", status.got);
//                status.HP = EditorGUILayout.IntField("HP", status.HP);
//                status.Special = EditorGUILayout.IntField("必殺技数", status.Special);
//                status.max_special = EditorGUILayout.IntField("最大必殺技数", status.max_special);
//                status.reset_hp = EditorGUILayout.IntField("初期化HP", status.reset_hp);
//                status.max_HP = EditorGUILayout.IntField("最大HP", status.max_HP);
//            }



//            EditorGUILayout.LabelField("");
//            EditorGUILayout.LabelField("HeroController");
//            if (controller != null)
//            {
//                controller.move = EditorGUILayout.Toggle("移動(move)", controller.move);

//                controller.speed = EditorGUILayout.FloatField("移動速度(speed)", controller.speed);

//                controller.is_left = EditorGUILayout.Toggle("左を向いている", controller.is_left);

//                controller.left = EditorGUILayout.FloatField("左限界値", controller.left);

//                controller.right = EditorGUILayout.FloatField("右限界値", controller.right);

//            }


//            serializedObject.ApplyModifiedProperties();

//            EditorUtility.SetDirty(target);

//        }
//    }


//#endif
}
