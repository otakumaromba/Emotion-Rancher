using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

		Debug.Log(Camera.main.orthographicSize);

    }

    // Update is called once per frame
    void Update()
    {

		const int orthographicSizeMin = 4;
		const int orthographicSizeMax = 16;

		var curVal = Camera.main.orthographicSize;


		if (Input.GetAxis("Mouse ScrollWheel") < 0) // forward
 {
			//Camera.main.orthographicSize+=2;
			//DOTween.To(() => Camera.main.ortographicSize, x => Camera.main.ortographicSize = x, Camera.main.ortographicSize + 2;
			

			if (Camera.main.orthographicSize >= orthographicSizeMin)
			{
				Camera.main.DOOrthoSize((Mathf.Clamp(curVal + 2, orthographicSizeMin, orthographicSizeMax)), 0.3f);
			}

			

		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // back
 {
			//Camera.main.orthographicSize-=2;
			if (Camera.main.orthographicSize <= orthographicSizeMax)
			{
				Camera.main.DOOrthoSize((Mathf.Clamp(curVal - 2, orthographicSizeMin, orthographicSizeMax)), 0.3f);
			}

		}
		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax);


	}
}
