using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnalyzerImage : MonoBehaviour
{

	public Image m_Image;
	public Analyzer analyzer;
	public Sprite m_Sprite;

	public void OnReceivingCreature(Criatura criatura)
	{
		var spriteRenderer = criatura.GetComponent<SpriteRenderer>();

		m_Image.enabled = true;
		m_Image.sprite = spriteRenderer.sprite;
		m_Image.color = spriteRenderer.color;

	}

	public void OnRemovingCreature()
	{
		m_Image.enabled = false;
	}

}
