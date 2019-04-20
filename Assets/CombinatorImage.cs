using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinatorImage : MonoBehaviour
{

	public Image m_Image; 
	public Combinator combinator;
	public Sprite m_Sprite;


  

    public void OnReceivingCreature(Criatura criatura)
    {
		m_Image.enabled = true;
		m_Image.sprite = criatura.sprite;
		m_Image.color = criatura.GetComponent<SpriteRenderer>().color;
		
	}

	public void OnRemovingCreature()
	{
		m_Image.enabled = false;
	}

}
