using UnityEngine;
using System.Collections;

public class HeroController:MonoBehaviour
{

    public bool move = false;

    [SerializeField]
    public float speed = 1.0f;

    public bool is_left = true;

    public float left = -7.5f;

    public float right = 7.5f;

    private Vector3 start_position = Vector3.zero;
    private Vector3 changed_position = Vector3.zero;

    GameObject m_controllObject = null;
    GameObject controllObject
    {
        get
        {
            if(m_controllObject == null)
            {
                m_controllObject = this.gameObject;
            }
            return m_controllObject;
        }
    }

    public void Awake()
    {
        start_position = transform.localPosition;
    }

    // Use this for initialization
    public void Start()
    {

        SetRotate();
        

    }

    // Update is called once per frame
    public void Update()
    {
        if (move)
        {
            HeroMove();

            if (Input.GetMouseButtonUp(0))
            {
                is_left = !is_left;
            }
        }

    }

   

    void HeroMove()
    {
        float delta_time = Time.deltaTime;


        if (is_left)
        {
            //移動量計算
            controllObject.transform.localPosition += new Vector3(delta_time * speed * -1.0f, 0.0f, 0.0f);

            //向き変更とそれに伴う移動
            if (controllObject.transform.localPosition.x < left)
            {
                is_left = false;
                controllObject.transform.localPosition += new Vector3(left - controllObject.transform.localPosition.x, 0.0f, 0.0f);
            }
        }
        else
        {
            //移動量計算
            controllObject.transform.localPosition += new Vector3(delta_time * speed, 0.0f, 0.0f);

            //向き変更とそれに伴う移動
            if (controllObject.transform.localPosition.x > right)
            {
                is_left = true;
                controllObject.transform.localPosition += new Vector3(right - controllObject.transform.localPosition.x, 0.0f, 0.0f);
            }
        }

        SetRotate();

    }

    void SetRotate()
    {
        if (is_left)
        {
            controllObject.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else
        {
            controllObject.transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
    }


    public void ResetToStartPosition()
    {
        controllObject.transform.localPosition = start_position;
    }

    public void SetPosition(Vector3 pos)
    {
        changed_position = pos;
        ResetToChangedPosition();
    }
    
    public void ResetToChangedPosition()
    {
        controllObject.transform.localPosition = changed_position;
    }

    public void SetControllObject(GameObject _object)
    {
        m_controllObject = _object;
        start_position = controllObject.transform.localPosition;
    }
}