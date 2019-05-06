using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinatorMenu : MonoBehaviour
{

	public Combinator combinator;


	public void OnOpenMenu()
	{
		if (combinator.criatura1)
		{
			combinator.img1.OnReceivingCreature(combinator.criatura1);
		}

		if (combinator.criatura2)
		{
			combinator.img2.OnReceivingCreature(combinator.criatura2);
		}
	}
}
