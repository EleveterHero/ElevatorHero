using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuffList{

    List<Buff> m_buff_list;
    List<Buff> buff_list
    {
        get
        {
            if (m_buff_list == null)
            {
                m_buff_list = new List<Buff>();
            }
            return m_buff_list;
        }
    }

	// Update is called once per frame
	public void Update () {

        for(int i=buff_list.Count-1;i >= 0; i--)
        {
            buff_list[i].Update();
        }

	}

    public void Add(Buff _buff,bool init=true)
    {
        if(_buff == null)
        {
            return;
        }

        buff_list.Add(_buff);
        _buff.parentlist = this;

        if (init)
        {
            _buff.Init();
        }
        _buff.TimerInit();
    }

    public void Remove(Buff _buff)
    {
        _buff.End();

        buff_list.Remove(_buff);
    }

    public void RemoveAll()
    {
        buff_list.Clear();
    }
}
