using UnityEngine;
using System.IO; //used when working with files in the OS
using System.Runtime.Serialization.Formatters.Binary; //access the binary formatter

public static class SaveSystem
{
  
	public static void SavePlayer(PlayerMovement player)
	{
		BinaryFormatter formatter = new BinaryFormatter();

		string path = Application.persistentDataPath + "/player.fun";

		FileStream stream = new FileStream(path, FileMode.Create);

		PlayerData data = new PlayerData(player);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public	static PlayerData LoadPlayer()
	{
		string path = Application.persistentDataPath + "/player.fun";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			PlayerData data = formatter.Deserialize(stream) as PlayerData;

			stream.Close();

			return data;

		}
		else
		{
			Debug.LogError("Couldn't find save file in " + path);
			return null;
		}
	}

	/*public static void SaveCreatures(PlayerMovement player)
	{
		BinaryFormatter formatter = new BinaryFormatter();

		string path = Application.persistentDataPath + "/creatures.fun";

		FileStream stream = new FileStream(path, FileMode.Create);

		FindGameObjectsWithTag("Other");

Creature.transform

		CreatureData data = new CreatureData(criatura);

		formatter.Serialize(stream, data);
		stream.Close();
	}
	*/

}
