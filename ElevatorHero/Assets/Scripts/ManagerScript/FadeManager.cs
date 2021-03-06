﻿//唯一のシーン遷移クラス

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//シングルトンクラス継承
public class FadeManager : SingletonMonoBehaviour<FadeManager>
{

    //=====
    //Global関数
    //=====
    //public
    //暗転時の色
    public Color fadeColor = Color.black;
    //private
    //暗転するときの透明度
    private float fadeAlpha = 0;
    //暗転中かどうか
    private bool isFade = false;
    private static bool created = false;

    public static bool isDebug = false;


    //起動時に読み込む
    public void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /*
	 *関数名	:OnGUI
	 *内容	:暗転処理部分
	 *引数	:
	 *戻り値	:
	*/
    public void OnGUI()
    {

        //もし暗転中のフラグがたっていたら
        if (this.isFade)
        {
            //透明度を変更
            this.fadeColor.a = this.fadeAlpha;
            //色を変更
            GUI.color = this.fadeColor;
            //暗転の画像を表す
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
        }
        
             

    }

    /*
	 *関数名	:LoadLevel
	 *内容	:コルーチンの呼び出し:コルーチンを使えば一連の処理を一つの流れでかける
	 *引数	:
	 *戻り値	:
	*/

    //コルーチンは一定時間処理を中断することができる
    public void LoadLevel(string sceneName, float interval)
    {
        //コルーチんに二つ以上を引数を渡す
        //コルーチンの呼び出し・開始
        StartCoroutine(TransScene(sceneName, interval));
    }

    //シーン遷移用コルーチン
    private IEnumerator TransScene(string sceneName, float interval, bool autofadeout = true,bool use_load_scene = true)
    {
        //暗転開始
        this.isFade = true;
        //暗転管理用のローカル変数
        float time = 0;

        //任意のintervalまで処理を続ける
        while (time <= interval)
        {
            time = FadeInUpdate(time, interval);
            yield return 0;
        }

        if (use_load_scene)
        {

            ShowLoadScene();

            time = 0;

            //フェードアウト
            while (time <= 0.5f)
            {
                time = FadeOutUpdate(time, 0.5f);
                yield return 0;
            }


            //シーン遷移
            AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
            async.allowSceneActivation = false;

            while (async.progress < 0.9f)
            {
                if (isDebug)
                {
                    Debug.Log(async.progress);
                }
                yield return new WaitForEndOfFrame();
            }
            Debug.Log("Scene Loaded");
            yield return new WaitForSeconds(1);


            //フェードイン
            time = 0;
            while (time <= 0.5f)
            {
                time = FadeInUpdate(time, 0.5f);
                yield return 0;
            }


            //シーン遷移を完了
            async.allowSceneActivation = true;


        }
        else
        {
            //シーン遷移
            SceneManager.LoadScene(sceneName);
        }


        //自動フェード処理
        if (autofadeout)
        {

            //タイムを初期化
            time = 0;

            //
            while (time <= interval)
            {
                time = FadeOutUpdate(time, interval);
                yield return 0;
            }

        }
        //暗転処理終了
        this.isFade = false;
    }

    private float FadeInUpdate(float time,float interval)
    {
        //グローバル変数の透明度の値を
        //線形補完の計算式を使って変換する
        //Leap(a1,a2,float b1);
        //a1: 開始点 a2: 終了点 b1:比率分だけ進んだ値を返す
        this.fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
        //timeを加算
        time += Time.deltaTime;
        return time;
    }

    private float FadeOutUpdate(float time ,float interval)
    {
        //グローバル変数の透明度の値を
        //線形補完の計算式を使って変換する
        //Leap(a1,a2,float b1);
        //a1: 開始点 a2: 終了点 b1:比率分だけ進んだ値を返す
        this.fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
        //timeを加算
        time += Time.deltaTime;
        return time;
    }

    private void ShowLoadScene()
    {
        SceneManager.LoadScene("load");
    }


    public void Fade(bool is_fadein, float interval)
    {
        if (isFade)
        {
            StopCoroutine("TransFade");
            isFade = false;
        }

        StartCoroutine(TransFade(is_fadein, interval));
        

    }

    //ファード用コルーチン
    private IEnumerator TransFade(bool is_fadein,float interval)
    {
        //暗転開始
        this.isFade = true;
        //暗転管理用のローカル変数
        float time = 0;

        //フェードイン
        if (is_fadein)
        {
            //任意のintervalまで処理を続ける
            while (time <= interval)
            {
                //グローバル変数の透明度の値を
                //線形補完の計算式を使って変換する
                //Leap(a1,a2,float b1);
                //a1: 開始点 a2: 終了点 b1:比率分だけ進んだ値を返す
                this.fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
                //timeを加算
                time += Time.deltaTime;
                //一度処理を中断し、次フレームから再開
                yield return 0;
            }
        }

        //フェードアウト
        else {

            //
            while (time <= interval)
            {
                //1から０になるまで繰り返す
                this.fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
                time += Time.deltaTime;
                yield return 0;
            }

        }

        //暗転処理終了
        this.isFade = false;
    }



}
