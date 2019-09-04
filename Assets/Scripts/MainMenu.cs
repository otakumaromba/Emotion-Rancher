﻿using System.Collections;
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
		Application.Quit();
	}

	public void StartNewGame()
	{

		SaveSystem.isGameToBeLoaded = false;

		SceneManager.LoadScene("SampleScene");
	}

	public void ContinueGame()
	{

		SaveSystem.isGameToBeLoaded = true;

		SceneManager.LoadScene("SampleScene");
	}

}
