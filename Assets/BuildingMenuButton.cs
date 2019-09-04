using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingMenuButton : MonoBehaviour, IPointerClickHandler
{

	public bool set = false;
	public GameObject buildingMenu;
	public RectTransform rT;
	private Vector2 pos;
	private Vector2 originalPos;


	public void Start()
	{
		originalPos = pos;
	}

	public void OnPointerClick(PointerEventData eventData)
    {
		pos = rT.anchoredPosition;

		if (set == true)
		{
			RevertBuildingButton();
		}

		if (set == false)
		{
			set = true;
			rT.anchoredPosition = new Vector3(pos.x, (pos.y + 130), 0);
		}
		
    }


	public void RevertBuildingButton()
	{
		
		rT.anchoredPosition = new Vector3(originalPos.x, (originalPos.y), 0);
		set = false;
	}
}
