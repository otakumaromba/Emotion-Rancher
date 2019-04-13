using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : Building
{

	public float originalSize = 3f;
	public float delay = 0.5f;
	public float sizeScaler = 4f;

	public override bool OnObjectDrop(Draggable draggable)
	{
		Debug.Log("Hora de chupar");
		draggable.criatura.SetActive(false); //desliga o bicho
		transform.DOScale(originalSize * sizeScaler, delay);
		transform.DOScale(originalSize, delay);
		return true;
	}
}
