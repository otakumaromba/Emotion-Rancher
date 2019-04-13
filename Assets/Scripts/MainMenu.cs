using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void QuitGame()
	{
		Debug.Log("Quitting game");
		Application.Quit();
	}

	public void StartNewGame()
	{
		Debug.Log("Starting game");

		SaveSystem.isGameToBeLoaded = false;

		SceneManager.LoadScene("SampleScene");
	}

	public void ContinueGame()
	{
		Debug.Log("Loading game");

		SaveSystem.isGameToBeLoaded = true;

		SceneManager.LoadScene("SampleScene");
	}

}
