using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused = false;

	public GameObject menuCombinator;
	public GameObject menuTeleporter;
	public GameObject menuHarvester;
	public GameObject menuAnalyzer;
	public GameObject buildingPanel;

	public bool isMenuOpen = false;

	public GameObject pauseMenuUI;

	public void Update()
	{

		if (Input.GetKeyDown(KeyCode.Escape))
		{

			isMenuOpen = (menuCombinator.activeSelf) || (menuHarvester.activeSelf) || (menuTeleporter.activeSelf) || (menuAnalyzer.activeSelf) || (buildingPanel.activeSelf);

			if (!isMenuOpen)
			{
				if (GameIsPaused)
				{
					Resume();
				}
				else
				{
					Pause();
				}
			}

			if (isMenuOpen)
			{
				menuCombinator.SetActive(false);
				menuTeleporter.SetActive(false);
				menuHarvester.SetActive(false);
				menuAnalyzer.SetActive(false);


			}
		}
	}

	public void Resume()
	{

		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;

	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
