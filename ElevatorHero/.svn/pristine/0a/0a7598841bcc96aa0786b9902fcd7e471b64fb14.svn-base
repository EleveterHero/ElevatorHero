using UnityEngine;
using System.Collections;

class Keys : MonoBehaviour
{

    KeyCode[] m_and_keys = null;
    int[] m_and_buttons = null;


    bool m_is_button_mode = false;

    public bool is_button_mode
    {
        get
        {
            return m_is_button_mode;
        }
    }


    Keys(params KeyCode[] _key_codes)
    {
        m_and_keys = new KeyCode[_key_codes.Length];
        _key_codes.CopyTo(m_and_keys, 0);
        m_is_button_mode = false;
    }

    Keys(params int[] _button_codes)
    {
        m_and_buttons = new int[_button_codes.Length];
        _button_codes.CopyTo(m_and_buttons, 0);
        m_is_button_mode = true;
    }





    bool IsPressed()
    {
        bool pressed = true;


        if (!m_is_button_mode)
        {
            for (int i = 0; i < m_and_keys.Length; i++)
            {
                pressed &= Input.GetKeyDown(m_and_keys[i]);
                if (!pressed)
                {
                    return false;
                }
            }
            return true;

        }


        else
        {

            for (int i = 0; i < m_and_buttons.Length; i++)
            {
                pressed &= Input.GetMouseButtonDown(m_and_buttons[i]);
                if (!pressed)
                {
                    return false;
                }
            }
            return true;

        }




    }

    bool IsReleased()
    {

        bool pressed = true;

        if (!m_is_button_mode)
        {
            for (int i = 0; i < m_and_keys.Length; i++)
            {
                pressed &= Input.GetKeyUp(m_and_keys[i]);
                if (!pressed)
                {
                    return false;
                }
            }
            return true;

        }

        else
        {

            for (int i = 0; i < m_and_buttons.Length; i++)
            {
                pressed &= Input.GetMouseButtonUp(m_and_buttons[i]);
                if (!pressed)
                {
                    return false;
                }
            }
            return true;

        }

    }


    bool IsPressing()
    {

        bool pressed = true;

        if (!m_is_button_mode)
        {
            for (int i = 0; i < m_and_keys.Length; i++)
            {
                pressed &= Input.GetKey(m_and_keys[i]);
                if (!pressed)
                {
                    return false;
                }
            }
            return true;

        }

        else
        {

            for (int i = 0; i < m_and_buttons.Length; i++)
            {
                pressed &= Input.GetMouseButton(m_and_buttons[i]);
                if (!pressed)
                {

                    return false;
                }
            }
            return true;

        }
    }

}