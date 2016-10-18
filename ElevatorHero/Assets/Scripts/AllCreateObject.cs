/*
 * 必要なマネージャーをすべて作成するクラス
 * 
  */

using UnityEngine;
using System.Collections;

public class AllCreateObject : MonoBehaviour {

    private static bool created=false;
   
    private GameObject kinectmanager;
    private GameObject fadeManager;
    private GameObject audioManager;
    private GameObject scoreManager;

    private GameObject mainCamera;

    public GameObject text;
    void Awake()
    {
        //一度作成
        if (!created)
        {
            

            /*Object of fadeManager is Creating*/
            fadeManager = new GameObject("FadeManager");
            //Add script
            fadeManager.AddComponent<FadeManager>();
            ///fadeManager detail;
            //Fade color is black
            fadeManager.GetComponent<FadeManager>().fadeColor = Color.black;

            /*Audio Manager is Creating*/
            audioManager = new GameObject("AudioManager");
            //Add script
            audioManager.AddComponent<AudioManager>();
            ///audioManager detail
            //DebugMode
            audioManager.GetComponent<AudioManager>().DebugMode = false;
            //When FadeIn/Out play?
            audioManager.GetComponent<AudioManager>().TimeToFade = 1.5f;
            //volume
            audioManager.GetComponent<AudioManager>().TargetVolume = 1;


            /*ScoreManager is Creating*/
            scoreManager = new GameObject("ScoreManager");
            //Add script
            scoreManager.AddComponent<ScoreManager>();

            //Add Script


            /*MainCamera Creating*/
            mainCamera = new GameObject("MainCamera");
            //Add Component
            mainCamera.AddComponent<Camera>();
			mainCamera.GetComponent<Camera> ().farClipPlane = 100;
            mainCamera.AddComponent<GUILayer>();
           // mainCamera.AddComponent<AudioListener>();
            //details
            mainCamera.transform.position = new Vector3(0,1,-10);
            //Add Script
            mainCamera.AddComponent<aspectControll>();
            //details
			//mainCamera.GetComponent<aspectControll>()
            mainCamera.GetComponent<aspectControll>().aspect.x = 4;
            mainCamera.GetComponent<aspectControll>().aspect.y = 3;
            mainCamera.GetComponent<aspectControll>().backGroundColor = Color.black;
            //Add Script
            mainCamera.AddComponent<AllSceneChanger>();
            mainCamera.AddComponent<TextObjectSet>();
            //details

            created = true;
        }
    }

	// Use this for initialization
	/*void Start () {
  

    }*/
	
	// Update is called once per frame
	void Update () {
        
	}
}
