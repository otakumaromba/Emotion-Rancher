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

	public void StartGame()
	{
		Debug.Log("Starting game");
		SceneManager.LoadScene("SampleScene");
	}

}
