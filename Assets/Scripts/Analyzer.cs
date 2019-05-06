using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analyzer : Building
{

	public float originalSize = 5f;
	public float delay = 0.5f;
	public float sizeScaler = 4f;

	public Criatura criatura1;

	public AnalyzerImage img1;


	public override bool OnObjectDrop(Draggable draggable)
	{

		var criatura = draggable.GetComponent<Criatura>();

		return AddCreature(criatura, draggable);

		//string creatureType = GetComponent<CreatureType>().ID;

	}

	private bool AddCreature(Criatura criatura, Draggable draggable)
	{
		if (!criatura1)
		{
			Debug.Log("chegou aqui");
			img1.OnReceivingCreature(criatura);
			criatura1 = criatura;
		}
		else
		{
			return false;
		}

		draggable.criatura.SetActive(false); //desliga o bicho

		draggable.analyzer.transform.DOScale(originalSize * sizeScaler, delay);
		draggable.analyzer.transform.DOScale(originalSize, delay);

		return true;
	}
}
