using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinatorImage1 : MonoBehaviour
{

	Image m_Image; 
	public Combinator combinator;
	public Sprite m_Sprite;


    void Start()
    {
		m_Image = GetComponent<Image>();		
	}

    public void OnReceivingCreature(Criatura criatura)
    {
		m_Image.sprite = criatura.GetComponent<Image>().sprite;
	}
}
