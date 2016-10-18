using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingAnim : MonoBehaviour {

    Text[] children;

    public float circle_time = 0.1f;

    float start_time = 0;

    public float delta_posy;
    public float delta_time = 0.1f;
    public float gain = 5.0f;


    float start_posy;

    public float speed = 1.0f;
	// Use this for initialization
	void Awake () {

        children = transform.GetComponentsInChildren<Text>();
        

        start_time = Time.time;
        start_posy = children[0].rectTransform.anchoredPosition.y;
    }
	
	// Update is called once per frame
	void Update () {

        float time = 0;


            time = Time.time;
        
            if (float.IsNaN(time))
            {
                return;
            }

       


        for(int i = 0; i < children.Length; i++)
        {
            delta_posy = Mathf.Sin(((time - (start_time + i * delta_time) )*speed) / circle_time);

            Vector2 vec2 = children[i].rectTransform.anchoredPosition;

            vec2.y = start_posy + delta_posy * gain;

            children[i].rectTransform.anchoredPosition = vec2;
        }
        


    }
}
