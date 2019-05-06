using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvesterMenu : MonoBehaviour
{

	public Harvester harvester;

	public void OnOpenMenu()
	{
		if (harvester.criatura1)
		{
			harvester.img1.OnReceivingCreature(harvester.criatura1);
		}
	}
}
