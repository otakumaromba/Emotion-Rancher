using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

	public GameObject criatura;
	public GameObject combinator;

    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnPointerClick(PointerEventData pointerEventData)
	{

		//spawns a new criature just below the combinator

		Debug.Log(name + " Spawner Clicked!");
		Vector3 m_pos = combinator.transform.position;
		m_pos.y -= 4;

		var instance = Instantiate(criatura, m_pos, Quaternion.identity);

		instance.GetComponent<Draggable>().Initialize(combinator);
	}

	public void OnPointerEnter(PointerEventData pointerEventData) { }
	public void OnPointerExit(PointerEventData pointerEventData) { }


}
