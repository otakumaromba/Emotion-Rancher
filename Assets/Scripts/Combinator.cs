﻿using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinator : Building
{

	public float originalSize = 5f;
	public float delay = 0.5f;
	public float sizeScaler = 4f;

	public Criatura criatura1, criatura2;

	public CombinatorImage img1, img2;


	public override bool OnObjectDrop(Draggable draggable)
	{

		var criatura = draggable.GetComponent<Criatura>();

		return AddCreature(criatura, draggable);

		//string creatureType = GetComponent<CreatureType>().ID;

	}

	private bool AddCreature(Criatura criatura, Draggable draggable)
	{
		if (criatura1)
		{
			if (criatura2){
				return false;
			}
			else
			{
				img2.OnReceivingCreature(criatura);
				criatura2 = criatura;
			}
		}
		else
		{
			img1.OnReceivingCreature(criatura);
			criatura1 = criatura;
		}

		draggable.criatura.SetActive(false); //desliga o bicho

		draggable.combinator.transform.DOScale(originalSize * sizeScaler, delay);
		draggable.combinator.transform.DOScale(originalSize, delay);

		return true;
	}
}
