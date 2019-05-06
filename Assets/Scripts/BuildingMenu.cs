using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingMenu : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

	public GameObject buildingMenu;


    // Start is called before the first frame update
    void Start()
    {
    }

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		//Output to console the GameObject's name and the following message
		Debug.Log("Cursor Entering " + name + " GameObject");
	}

	//Detect when Cursor leaves the GameObject
	public void OnPointerExit(PointerEventData pointerEventData)
	{
		//Output the following message with the GameObject's name
		Debug.Log("Cursor Exiting " + name + " GameObject");
		if (buildingMenu.activeSelf == true)
		{
			buildingMenu.SetActive(false);
		}
	}

	//Detect if a click occurs
	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (buildingMenu.activeSelf == false)
		{
			buildingMenu.SetActive(true);

			var bidoof = buildingMenu.GetComponent<CombinatorMenu>();
			if (bidoof)
				bidoof.OnOpenMenu();

			var bidoof2 = buildingMenu.GetComponent<AnalyzerMenu>();
			if (bidoof2)
				bidoof2.OnOpenMenu();

			var bidoof3 = buildingMenu.GetComponent<HarvesterMenu>();
			if (bidoof3)
				bidoof3.OnOpenMenu();

		}


	}
}
