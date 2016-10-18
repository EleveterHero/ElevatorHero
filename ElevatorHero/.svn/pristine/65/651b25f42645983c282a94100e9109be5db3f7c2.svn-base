using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StepCount : MonoBehaviour {

	Text m_text = null;
	Text text
	{
		get
		{
			if(m_text == null)
			{
				m_text = GetComponent<Text>();
			}
			return m_text;
		}
	}

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

	
	// Update is called once per frame
	void Update () {
		text.text = ((int)(backsprite.floor)).ToString();
	}
}
