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

		var combinatorComponent = combinator.GetComponent<Combinator>();

		if (combinatorComponent.criatura1 && combinatorComponent.criatura2)
		{

			var instance = Instantiate(criatura, m_pos, Quaternion.identity);
			instance.GetComponent<Draggable>().Initialize(combinator, harvester);

			combinator.transform.DOScale(20f, 0.5f);

			string name1 = combinatorComponent.criatura1.ID;
			string name2 = combinatorComponent.criatura2.ID;

			string newName = $"({name1}{name2})";

			var criaturaComponente = instance.GetComponent<Criatura>();
			criaturaComponente.Initialize(newName);

			combinator.transform.DOScale(5f, 0.5f);

			Debug.Log("Spawnada criatura " + criaturaComponente.ID);

			Destroy(combinatorComponent.criatura1.gameObject);
			Destroy(combinatorComponent.criatura2.gameObject);
		}
		else
		{
			Debug.Log("Caralho menor");
		}

	}

	public void OnPointerEnter(PointerEventData pointerEventData) { }
	public void OnPointerExit(PointerEventData pointerEventData) { }

}

