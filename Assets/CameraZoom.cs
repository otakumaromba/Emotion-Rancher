using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		const int orthographicSizeMin = 4;
		const int orthographicSizeMax = 16;


		if (Input.GetAxis("Mouse ScrollWheel") < 0) // forward
 {
			Camera.main.orthographicSize+=2;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // back
 {
			Camera.main.orthographicSize-=2;
		}
		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax);


	}
}
