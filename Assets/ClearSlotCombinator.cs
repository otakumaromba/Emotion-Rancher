using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClearSlotCombinator : MonoBehaviour, IPointerClickHandler
{

	public GameObject criatura;
	public GameObject combinator;
	public GameObject harvester;
	public GameObject analyzer;

	public void OnPointerClick (PointerEventData pointerEventData)
	{

		//respawns creatures just below the combinator

		transform.DOScale(8f, 0.5f);
		transform.DOScale(1f, 0.5f);

		Vector3 m_pos1 = combinator.transform.position;
		Vector3 m_pos2 = combinator.transform.position;
		m_pos1.y -= 4;
		m_pos1.x -= 2;
		m_pos2.y -= 4;
		m_pos2.x += 2;


		var combinatorComponent = combinator.GetComponent<Combinator>();


		if (combinatorComponent.criatura2) // if the second slot is full
		{

			var instance = Instantiate(criatura, m_pos2, Quaternion.identity);
			instance.GetComponent<Draggable>().Initialize(combinator, harvester, analyzer);

			Debug.Log("instanciado2");

			// criatura 2 instanciada

			string name2 = combinatorComponent.criatura2.ID;  // pegou nome da criatura 2

			string Name = $"{name2}";

			var criaturaComponente = instance.GetComponent<Criatura>();
			criaturaComponente.Initialize(Name); // criatura 2 inicializada com base no ID

			Destroy(combinatorComponent.criatura2.gameObject); // criatura 2 destruída no combinator

			combinatorComponent.img2.OnRemovingCreature(); // imagem da criatura 2 removida no combinator

		}

		if (combinatorComponent.criatura1) // if the first slot is full
		{
			var instance = Instantiate(criatura, m_pos1, Quaternion.identity);
			instance.GetComponent<Draggable>().Initialize(combinator, harvester, analyzer);

			Debug.Log("instanciado1");

			// criatura 1 instanciada

			string name1 = combinatorComponent.criatura1.ID;  // pegou nome da criatura 2

			string Name = $"{name1}";

			var criaturaComponente = instance.GetComponent<Criatura>();
			criaturaComponente.Initialize(Name); // criatura 1 inicializada com base no ID

			Destroy(combinatorComponent.criatura1.gameObject); // criatura 1 destruída no combinator

			combinatorComponent.img1.OnRemovingCreature(); // imagem da criatura 1 removida no combinator
		}


		else
		{
			Debug.Log("Caralho menor");
		}

	}
}
