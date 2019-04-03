using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Spawner : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

	public GameObject criatura;
	public GameObject combinator;
	public GameObject harvester;

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

		transform.DOScale(8f, 0.5f);
		transform.DOScale(1f, 0.5f);

		Vector3 m_pos = combinator.transform.position;
		m_pos.y -= 4;

		combinator.transform.DOScale(20f, 0.5f);

		var instance = Instantiate(criatura, m_pos, Quaternion.identity);
		instance.GetComponent<Draggable>().Initialize(combinator, harvester);

		combinator.transform.DOScale(5f, 0.5f);
	}

	public void OnPointerEnter(PointerEventData pointerEventData) { }
	public void OnPointerExit(PointerEventData pointerEventData) { }


}
