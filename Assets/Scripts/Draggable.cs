using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class Draggable : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, /*IEndDragHandler, */ IInitializePotentialDragHandler
{
	public GameObject criatura;
	public GameObject combinator;
	public GameObject harvester;
	public GameObject analyzer;

	public GameObject under;

	BoxCollider2D m_Collider;
	public LayerMask layerMask;
	public Vector2 originalPos;
	public Vector3 newPos;

	
	public GameObject creatureName;

	private SpriteRenderer m_spriteRenderer;
	private Color m_NewColor;


	private bool onHover;
	private bool clickedStatus;

	void Start()
    {
		//cam = Camera.main;
		m_Collider = GetComponent<BoxCollider2D>();
		m_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		var originalPos = criatura.transform.position; //pega a posição inicial do bicho
	}

	public void Initialize(GameObject combinator, GameObject harvester, GameObject analyzer)
	{
		this.combinator = combinator;
		this.harvester = harvester;
		this.analyzer = analyzer;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		Debug.Log("Hover na criatura");
		onHover = true;
		StartCoroutine("WaitForName");
		
	}

	public void OnPointerExit(PointerEventData pointerEventData)
	{
		Debug.Log("Saiu do hover na criatura");
		onHover = false;
		if (creatureName.activeSelf == true)
		{
			creatureName.SetActive(false);
		}
	}

	IEnumerator WaitForName()
	{
		Debug.Log("Esperando para mostrar o nome");
		yield return new WaitForSecondsRealtime(0.5f);
		if (onHover == true)
		{
			if (creatureName.activeSelf == false)
			{
				creatureName.SetActive(true);
			}
		}
	}

	public void OnPointerDown(PointerEventData pointerEventData)
	{
		criatura.transform.DOScale(1.5f, 0.1f);
	}

	public void OnPointerUp(PointerEventData pointerEventData)
	{
		EndDrag();
	}


	public void OnInitializePotentialDrag(PointerEventData eventData)
	{
		originalPos = criatura.transform.position;
		//criatura.transform.DOScale(1.5f, 0.1f); //aumenta a criatura usando o dotween em 0.1s
		m_Collider.enabled = false; //desliga o colisor e permite arrastar por cima de outros objetos
	}

	public void OnDrag(PointerEventData eventData)
	{

		if (eventData.dragging)
		{
			//pra fazer a criatura arrastada acompanhar a câmera

			var cam = eventData.pressEventCamera;
			var oldZ = criatura.transform.position.z;
			var newPos = cam.ScreenToWorldPoint(eventData.position);

			newPos.z = oldZ;

			criatura.transform.position = newPos;

			Vector3 oldPos = new Vector3(originalPos.x, originalPos.y, oldZ);

		}

		Vector2 direction = new Vector2(0f, 0f);
		var cast = Physics2D.CircleCast(criatura.transform.position, 1f, direction);


		if (cast == true && cast.transform.tag == "Other") //se no hover estiver encostando no collider de algo que não for o combinator ou o harvester)
		{
			Debug.Log("Há algo ruim embaixo");
			m_spriteRenderer.color = Color.red; //pinta o sprite de vermelho
			m_spriteRenderer.material.color = new Color(1f, 1f, 1f, 0.6f); //ajusta a opacidade pra 60%
		}

		else if (cast != true)
		{
			Debug.Log("Não há nada embaixo");
			m_spriteRenderer.color = Color.cyan; //retorna para a cor original do sprite
			m_spriteRenderer.material.color = new Color(1f, 1f, 1f, 1f); //retorna a opacidade pra 100%
		}


	}

	public void EndDrag()
	{
		Vector2 direction = new Vector2(0f, 0f);
		var cast = Physics2D.CircleCast(criatura.transform.position, 1f, direction);

		if (cast)
		{

			var building = cast.collider.GetComponent<Building>();
			if (building)
			{
				if (!building.OnObjectDrop(this))
				{
					ReturnToOriginalPosition();
				}
			}

			else
			{
				ReturnToOriginalPosition();
			}
			
		}

		else
		{
			Debug.Log("Chão");
			m_Collider.enabled = true;
			criatura.transform.DOScale(1f, 0.1f);
		}
	}

	private void ReturnToOriginalPosition()
	{
		Debug.Log("Touched something bad");

		criatura.transform.position = originalPos; //leva o bichinho de volta pra onde ele estava
		criatura.transform.DOScale(1f, 0.1f);
		m_spriteRenderer.color = Color.cyan; //retorna para a cor original do sprite
		m_spriteRenderer.material.color = new Color(1f, 1f, 1f, 1f); //retorna a opacidade pra 100%
		m_Collider.enabled = true;
	}
}
