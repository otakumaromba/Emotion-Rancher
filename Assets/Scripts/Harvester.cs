using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : Building
{

	public float originalSize = 5f;
	public float delay = 0.5f;
	public float sizeScaler = 4f;

	public Criatura criatura1;

	public HarvesterImage img1;


	public override bool OnObjectDrop(Draggable draggable)
	{

		var criatura = draggable.GetComponent<Criatura>();

		return AddCreature(criatura, draggable);

	}

	private bool AddCreature(Criatura criatura, Draggable draggable)
	{
		if (criatura1)
		{
			return false;
		}
		else
		{
			img1.OnReceivingCreature(criatura);
			criatura1 = criatura;
		}

		draggable.criatura.SetActive(false); //desliga o bicho

		draggable.harvester.transform.DOScale(originalSize * sizeScaler, delay);
		draggable.harvester.transform.DOScale(originalSize, delay);

		return true;
	}
}
