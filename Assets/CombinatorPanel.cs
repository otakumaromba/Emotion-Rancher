using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombinatorPanel : MonoBehaviour, IPointerClickHandler
{

	public GameObject menuCombinator;

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		menuCombinator.gameObject.SetActive(false);
		this.gameObject.SetActive(false);
	}
}
