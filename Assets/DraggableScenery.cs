using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class DraggableScenery : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, /*IEndDragHandler, */ IInitializePotentialDragHandler
{
	public GameObject scenery;

	EdgeCollider2D m_Collider;
	public Vector3 originalPos;
	public Vector3 newPos;

	public bool collided = false;

	private SpriteRenderer m_spriteRenderer;
	private Color m_NewColor;


	private bool onHover;
	private bool clickedStatus;

	private Color originalColor;

	void Start()
	{
		//cam = Camera.main;
		m_Collider = GetComponent<EdgeCollider2D>();
		m_spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		originalPos = scenery.transform.position; //pega a posição inicial do scenery
		originalColor = this.m_spriteRenderer.color;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		onHover = true;

	}

	public void OnPointerExit(PointerEventData pointerEventData)
	{
		onHover = false;
	}

	public void OnPointerDown(PointerEventData pointerEventData)
	{
		scenery.transform.DOScale(1.5f, 0.1f);
	}

	public void OnPointerUp(PointerEventData pointerEventData)
	{
		EndDrag();
	}


	public void OnInitializePotentialDrag(PointerEventData eventData)
	{
		originalPos = scenery.transform.position;
		scenery.transform.DOScaleX(12f, 0.1f); //aumenta a criatura usando o dotween em 0.1s
		scenery.transform.DOScaleY(7.2f, 0.1f);
		m_Collider.enabled = false; //desliga o colisor e permite arrastar por cima de outros objetos
	}

	public void OnDrag(PointerEventData eventData)
	{

		if (eventData.dragging)
		{
			//pra fazer o objeto arrastado acompanhar a câmera

			var cam = eventData.pressEventCamera;
			var oldZ = scenery.transform.position.z;
			var newPos = cam.ScreenToWorldPoint(eventData.position);

			newPos.z = oldZ;

			scenery.transform.position = newPos;

			Vector3 oldPos = new Vector3(originalPos.x, originalPos.y, oldZ);

		}

		/*Vector2 direction = new Vector2(0f, 0f);
		var cast = Physics2D.CircleCast(scenery.transform.position, 1f, direction);


		if ((cast == true) && (cast.transform.tag != "Background")) //se tiver algo embaixo que não o chão
		{
			m_spriteRenderer.color = Color.red; //pinta o sprite de vermelho
			m_spriteRenderer.material.color = new Color(1f, 1f, 1f, 0.6f); //ajusta a opacidade pra 60%
		}

		else if (cast != true) //se nao tiver nada embaixo
		{
			m_spriteRenderer.color = originalColor; //retorna para a cor original do sprite
			m_spriteRenderer.material.color = new Color(1f, 1f, 1f, 1f); //retorna a opacidade pra 100%
		}*/


	}

	void OnCollisionEnter2D(Collision2D col)
	{
		collided = true;
		Debug.Log("sbarro");
		m_spriteRenderer.color = Color.red; //pinta o sprite de vermelho
		m_spriteRenderer.material.color = new Color(1f, 1f, 1f, 0.6f); //ajusta a opacidade pra 60%
	}

	void OnCollisionExit2D(Collision2D col)
	{
		collided = false;
		Debug.Log("desesbarro");
		m_spriteRenderer.color = originalColor; //retorna para a cor original do sprite
		m_spriteRenderer.material.color = new Color(1f, 1f, 1f, 1f); //retorna a opacidade pra 100%
	}

	public void EndDrag()
	{
		Vector2 direction = new Vector2(0f, 0f);
		var cast = Physics2D.CircleCast(scenery.transform.position, 1f, direction);

		if (collided == true)
		{

			ReturnToOriginalPosition();
		}
		if (collided == false)
		{
			scenery.transform.DOScaleX(10f, 0.1f);
			scenery.transform.DOScaleY(6f, 0.1f);
			m_Collider.enabled = true;
		}
	}

	private void ReturnToOriginalPosition()
	{

		scenery.transform.position = originalPos; //leva o cenário de volta pra onde ele estava
		scenery.transform.DOScaleX(10f, 0.1f);
		scenery.transform.DOScaleY(6f, 0.1f);
		m_spriteRenderer.color = originalColor; //retorna para a cor original do sprite
		m_spriteRenderer.material.color = new Color(1f, 1f, 1f, 1f); //retorna a opacidade pra 100%
		m_Collider.enabled = true;
		collided = false;
	}
}
