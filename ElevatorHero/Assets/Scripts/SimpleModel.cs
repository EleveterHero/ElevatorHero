using UnityEngine;
using System;
using live2d;

[ExecuteInEditMode]
public class SimpleModel : MonoBehaviour 
{
    public bool auto = false;
    public bool link_animator = true;
    public float speed = 1.0f;
    public float start_timer;
    public float temp_real_timer;
    public float delta_timer;
    public float timer;

    private Live2DModelUnity live2DModel;
    private Live2DMotion motion;
    private MotionQueueManager motionMgr;

    private Matrix4x4 live2DCanvasPos;

    public TextAsset mocFile;
    public Texture2D[] textureFiles;
    public TextAsset motionFile;

    private string temp_motionFile_name = null;


    


    void Start()
    {


        Live2D.init();
        live2DModel = Live2DModelUnity.loadModel(mocFile.bytes);


        live2DModel.setRenderMode(Live2D.L2D_RENDER_DRAW_MESH);
        live2DModel.setLayer(gameObject.layer);


        for (int i = 0; i < textureFiles.Length; i++)
        {
            live2DModel.setTexture(i, textureFiles[i]);
        }




        float modelWidth = live2DModel.getCanvasWidth();
        live2DCanvasPos = Matrix4x4.Ortho(0, modelWidth, modelWidth, 0, -50.0f, 50.0f);

        motionMgr = new MotionQueueManager();
        if (motionFile != null)
        {
            motion = Live2DMotion.loadMotion(motionFile.bytes);
        }





    }

    void Update()
    {
        if (live2DModel == null) return;




        if (auto)
        {

            if (link_animator)
            {
                AnimatorStateInfo state = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
                timer = state.length * state.normalizedTime;


                //timer = (float)GetComponent<Animator>().GetTime();
                UtSystem.setUserTimeMSec((long)(timer * 1000.0f));
            }
            else
            {

                delta_timer = (Time.time - temp_real_timer) * speed;

                timer += delta_timer;

                UtSystem.setUserTimeMSec((long)(timer * 1000.0f));

                temp_real_timer = Time.time;
            }
        }

        bool motion_chenged = false;

        if(motionFile == null)
        {
            motion = null;


            temp_motionFile_name = "";
        }
        else
        {
            if (temp_motionFile_name != motionFile.name)
            {
                motion = Live2DMotion.loadMotion(motionFile.bytes);
                motion_chenged = true;
            }

            temp_motionFile_name = motionFile.name;
        }
        





        if (live2DModel.getLayer() != gameObject.layer)
        {
            live2DModel.setLayer(gameObject.layer);
        }


        live2DModel.setMatrix(transform.localToWorldMatrix * live2DCanvasPos);

        if (!Application.isPlaying)
        {
            live2DModel.update();
            return;
        }



        if (motion != null)
        {
            motion.setLoop(true);
            motion.setFadeIn(0);
            motion.setFadeOut(0);

            if (motionMgr.isFinished())
            {
                motionMgr.startMotion(motion);
            }

            if (motion_chenged)
            {
                motionMgr.stopAllMotions();
                motionMgr.startMotion(motion);
            }


            motionMgr.updateParam(live2DModel);
        }
        else
        {
            motionMgr.stopAllMotions();

            if (motionFile != null)
            {
                motion = Live2DMotion.loadMotion(motionFile.bytes);
            }
        }



        live2DModel.update();

        if (live2DModel.getRenderMode() == Live2D.L2D_RENDER_DRAW_MESH)
        {
            Render();
        }
    }
	
	void OnRenderObject()
	{
        if(live2DModel == null)
        {
            return;
        }

        if (live2DModel.getRenderMode() == Live2D.L2D_RENDER_DRAW_MESH_NOW)
        {
            Render();
        }
    }

    void Render()
    {
        if (live2DModel == null) return;
        live2DModel.draw();
    }

}