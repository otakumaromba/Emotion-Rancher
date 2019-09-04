using UnityEngine;
using System.IO; //used when working with files in the OS
using System.Runtime.Serialization.Formatters.Binary; //access the binary formatter
using System.Collections.Generic;

public class SaveSystem : MonoBehaviour
{

	public static bool isGameToBeLoaded = false;

	public GameObject combinator;
	public GameObject harvester;
	public GameObject analyzer;
	public GameObject creaturePrefab;

	public CalendarSystem calendarSystem;
	public MakeGrana makeGrana;

	public void Start()
	{

		if (isGameToBeLoaded)
		{
			LoadGame();
		}
	}

	public void SaveGame()
	{
		var creatureList = Object.FindObjectsOfType<Criatura>();
		var player = Object.FindObjectOfType<PlayerMovement>();
		SaveGame(player, creatureList);
	}
  
	public void SaveGame(PlayerMovement player, IEnumerable<Criatura> criaturas)
	{
		BinaryFormatter formatter = new BinaryFormatter();

		string path = Application.persistentDataPath + "/game.savedata";

		FileStream stream = new FileStream(path, FileMode.Create);

		GameSaveData data = new GameSaveData(criaturas, player, makeGrana.grana, calendarSystem);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public void LoadGame()
	{
		string path = Application.persistentDataPath + "/game.savedata";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			GameSaveData data = formatter.Deserialize(stream) as GameSaveData;

			stream.Close(); //return data;

			ReloadCreatures(data);
			ReloadPlayer(data.player);

			makeGrana.grana = data.gems;

			calendarSystem.startTime = data.startTime;

		}
		else
		{
			Debug.LogError("Couldn't find save file in " + path);
			//return null;
		}
	}

	public void ReloadCreatures(GameSaveData data)
	{

		var todosBicho = FindObjectsOfType<Criatura>();

		foreach (var bicho in todosBicho)
		{
			Destroy(bicho.gameObject);
		}

		

		foreach (var c in data.creatures)
		{
			CreateCreature(c);
		}

		ReloadCombinatorCreatures(data);

		ReloadAnalyzerCreature(data);

		ReloadHarvesterCreature(data);

	}

	private GameObject CreateCreature(CreatureData c)
	{
		var instance = GameObject.Instantiate(creaturePrefab);
		instance.GetComponent<Criatura>().Initialize(c.ID);

		instance.transform.position = new Vector3(c.position[0], c.position[1], c.position[2]);

		instance.GetComponent<Draggable>().Initialize(combinator, harvester, analyzer);

		return instance;
	}

	public void ReloadCombinatorCreatures(GameSaveData data)
	{
		GameObject criatura1;
		GameObject criatura2;

		var combinatorComponent = combinator.GetComponent<Combinator>();

		if (combinatorComponent.criatura1)
		{
			Destroy(combinatorComponent.criatura1); //destroi criatura 1
		}
		if (combinatorComponent.criatura2)
		{
			Destroy(combinatorComponent.criatura2); //destrói criatura 2
		}

		if (data.combinatorCreature1 != null)
		{
			criatura1 = CreateCreature(data.combinatorCreature1); //recria criatura 1
			criatura1.SetActive(false);
			combinatorComponent.criatura1 = criatura1.GetComponent<Criatura>();
		}
		if (data.combinatorCreature2 != null)
		{
			criatura2 = CreateCreature(data.combinatorCreature2); //recria criatura 2
			criatura2.SetActive(false);
			combinatorComponent.criatura2 = criatura2.GetComponent<Criatura>();
		}
		
	}

	public void ReloadAnalyzerCreature(GameSaveData data)
	{

		GameObject criatura1;

		var analyzerComponent = analyzer.GetComponent<Analyzer>();

		if (analyzerComponent.criatura1)
		{
			Destroy(analyzerComponent.criatura1); //destrói criatura analyzer
		}

		if (data.analyzerCreature != null)
		{
			criatura1 = CreateCreature(data.analyzerCreature); //recria criatura analyzer
			criatura1.SetActive(false);
			analyzerComponent.criatura1 = criatura1.GetComponent<Criatura>();
		}


	}

	public void ReloadHarvesterCreature(GameSaveData data)
	{

		GameObject criatura1;

		var harvesterComponent = harvester.GetComponent<Harvester>();

		if (harvesterComponent.criatura1)
		{
			Destroy(harvesterComponent.criatura1); //destrói criatura harvester
		}

		if (data.harvesterCreature != null)
		{
			criatura1 = CreateCreature(data.harvesterCreature); //recria criatura harvester
			criatura1.SetActive(false);
			harvesterComponent.criatura1 = criatura1.GetComponent<Criatura>();
		}


	}


	public void ReloadPlayer(PlayerData playerData)
	{
		var player = FindObjectOfType<PlayerMovement>();

		player.transform.position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);

	}

}
