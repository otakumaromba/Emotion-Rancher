using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClearSlotAnalyzer : MonoBehaviour, IPointerClickHandler
{

	public GameObject criatura;
	public GameObject combinator;
	public GameObject harvester;
	public GameObject analyzer;

	public void OnPointerClick(PointerEventData pointerEventData)
	{

		//respawns creature just below the analyzer

		transform.DOScale(8f, 0.5f);
		transform.DOScale(1f, 0.5f);

		Vector3 m_pos1 = analyzer.transform.position;
		m_pos1.y -= 3;

		var analyzerComponent = analyzer.GetComponent<Analyzer>();


		if (analyzerComponent.criatura1) // if slot is full
		{
			var instance = Instantiate(criatura, m_pos1, Quaternion.identity);
			instance.GetComponent<Draggable>().Initialize(combinator, harvester, analyzer);

			Debug.Log("instanciado");

			// criatura instanciada

			string name1 = analyzerComponent.criatura1.ID;  // pegou nome da criatura

			string Name = $"{name1}";

			var criaturaComponente = instance.GetComponent<Criatura>();
			criaturaComponente.Initialize(Name); // criatura inicializada com base no ID

			Destroy(analyzerComponent.criatura1.gameObject); // criatura destruída no analyzer

			analyzerComponent.img1.OnRemovingCreature(); // imagem da criatura removida no analyzer

		}

		else
		{
			Debug.Log("Caralho menor");
		}

	}
}


