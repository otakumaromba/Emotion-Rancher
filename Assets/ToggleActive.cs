using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    public void ToggleStatus()
    {
        if (this.gameObject.activeSelf == true)
		{
			this.gameObject.SetActive(false);
		}
		else
		{
			this.gameObject.SetActive(true);
		}
    }
}
