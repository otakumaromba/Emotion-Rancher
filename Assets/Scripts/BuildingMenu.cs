using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingMenu : MonoBehaviour, IPointerClickHandler
{

	public GameObject buildingMenu;
	public RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
    }

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, null))
			{
				buildingMenu.SetActive(false);
			}

		}

	}

	public void CloseMenuButton()
	{
		buildingMenu.SetActive(false);
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
