using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClearSlotHarvester : MonoBehaviour, IPointerClickHandler
{

	public GameObject criatura;
	public GameObject combinator;
	public GameObject harvester;
	public GameObject analyzer;

	public void OnPointerClick(PointerEventData pointerEventData)
	{

		//respawns creature just below the harvester

		transform.DOScale(8f, 0.5f);
		transform.DOScale(1f, 0.5f);

		Vector3 m_pos1 = harvester.transform.position;
		m_pos1.y -= 3;

		var harvesterComponent = harvester.GetComponent<Harvester>();


		if (harvesterComponent.criatura1) // if slot is full
		{
			var instance = Instantiate(criatura, m_pos1, Quaternion.identity);
			instance.GetComponent<Draggable>().Initialize(combinator, harvester, analyzer);

			Debug.Log("instanciado");

			// criatura instanciada

			string name1 = harvesterComponent.criatura1.ID;  // pegou nome da criatura

			string Name = $"{name1}";

			var criaturaComponente = instance.GetComponent<Criatura>();
			criaturaComponente.Initialize(Name); // criatura inicializada com base no ID

			Destroy(harvesterComponent.criatura1.gameObject); // criatura destruída no harvester

			harvesterComponent.img1.OnRemovingCreature(); // imagem da criatura removida no harvester

		}

		else
		{
			Debug.Log("Caralho menor");
		}

	}
}

