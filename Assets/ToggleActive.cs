using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
	public RectTransform rectTransform;
	public GameObject buildingPanel;
	int strike;

	public void Update()
	{

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (this.gameObject.activeSelf == true)
			{
				this.gameObject.SetActive(false);
			}
		}

		if (Input.GetButtonDown("Fire1"))
		{
			if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, null))
			{
				buildingPanel.SetActive(false);
				strike = 1;
			}
		}

	}


	public void ToggleStatus()
    {
        if (this.gameObject.activeSelf == true)
		{
			this.gameObject.SetActive(false);
		}
		else
		{
			if (strike != 1)
			{
				this.gameObject.SetActive(true);
			}
			else
			{
				strike = 0;
			}
		}
    }
}
