using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class TemporarySpawner : MonoBehaviour, IPointerClickHandler
{

	public GameObject criatura;
	public GameObject combinator;
	public GameObject harvester;
	public GameObject analyzer;
	public GameObject playermodel;

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

		//spawns a new creature

		Debug.Log(name + " Spawner Clicked!");

		transform.DOScale(8f, 0.5f);
		transform.DOScale(1f, 0.5f);

		Vector3 m_pos = playermodel.transform.position;
		m_pos.x += 4;


		var instance = Instantiate(criatura, m_pos, Quaternion.identity);
		instance.GetComponent<Draggable>().Initialize(combinator, harvester, analyzer);

		string newName = "(a)";

		var criaturaComponente = instance.GetComponent<Criatura>();
		criaturaComponente.Initialize(newName);

		Debug.Log("Spawnada criatura " + criaturaComponente.ID);
	}


}

