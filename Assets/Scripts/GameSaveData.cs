﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSaveData
{
	public List<CreatureData>  creatures;

	public PlayerData player;

	public CreatureData combinatorCreature1;
	public CreatureData combinatorCreature2;

	public int gems;

	public GameSaveData(IEnumerable<Criatura> criaturas, PlayerMovement player, int gems)
	{
		this.player = new PlayerData(player);

		this.gems = gems;

		creatures = new List<CreatureData>();

		foreach (var c in criaturas)
		{
			creatures.Add(new CreatureData(c));
		}

		Combinator combinator = GameObject.FindObjectOfType<Combinator>();

		if (combinator.criatura1)
		{
			combinatorCreature1 = new CreatureData(combinator.criatura1);
		}
		if (combinator.criatura2)
		{
			combinatorCreature2 = new CreatureData(combinator.criatura2);
		}
	}
}

[System.Serializable]
public class CreatureData
{

	public string ID;

	public float[] position;

	public CreatureData(Criatura criatura)
	{
		ID = criatura.ID;
		position = new float[3];
		position[0] = criatura.transform.position.x;
		position[1] = criatura.transform.position.y;
		position[2] = criatura.transform.position.z;
	}
}

[System.Serializable] //can save it in a file
public class PlayerData
{
	public float[] position;

	public PlayerData(PlayerMovement player)
	{
		position = new float[3];
		position[0] = player.transform.position.x;
		position[1] = player.transform.position.y;
		position[2] = player.transform.position.z;
	}

}
