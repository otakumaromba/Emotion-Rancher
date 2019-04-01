using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Draggable : MonoBehaviour, IDragHandler, IEndDragHandler, IInitializePotentialDragHandler
{

	public GameObject criatura;
	public GameObject combinator;

	public GameObject under;

	BoxCollider2D m_Collider;
	public LayerMask layerMask;
	public Vector2 originalPos;

	private SpriteRenderer m_spriteRenderer;
	private Color m_NewColor;


	void Start()
    {
		
		//cam = Camera.main;
		m_Collider = GetComponent<BoxCollider2D>();
		m_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		var originalPos = criatura.transform.position; //pega a posição inicial do bicho

	}

	public void Initialize(GameObject combinator)
	{
		this.combinator = combinator;
	}


    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnInitializePotentialDrag(PointerEventData eventData)
	{
		originalPos = criatura.transform.position;
		criatura.transform.localScale *= 1.5f; //aumenta em 50% o tamanho do sprite quando clicado
		m_Collider.enabled = false; //desliga o colisor e permite arrastar por cima de outros objetos
	}

	public void OnDrag(PointerEventData eventData)
	{

		//var oldColor = m_spriteRenderer.color;

		if (eventData.dragging)
		{

			//pra fazer a criatura arrastada acompanhar a câmera

			var cam = eventData.pressEventCamera;
			var oldZ = criatura.transform.position.z;
			var newPos = cam.ScreenToWorldPoint(eventData.position);
			newPos.z = oldZ;
			criatura.transform.position = newPos;

		}

		Vector2 direction = new Vector2(0f, 0f);
		var cast = Physics2D.CircleCast(criatura.transform.position, 1f, direction);

		if (cast == true && cast.transform.tag == "Combinator")
		{
			Debug.Log("Em cima do Combinator");
		}
		
			if (cast == true && cast.transform.tag != "Combinator") //se no hover estiver encostando no collider de algo que não for o combinator
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

	public void OnEndDrag(PointerEventData pointerEventData)
	{
		Vector2 direction = new Vector2(0f, 0f);
		var cast = Physics2D.CircleCast(criatura.transform.position, 1f, direction);

		if (cast)
		{
			if (cast.transform.tag == "Combinator")
			{
				Debug.Log("Hora de morfar");
				criatura.SetActive(false); //desliga o bicho

				combinator.transform.DOScale(10f, 0.5f);
				combinator.transform.DOScale(5f, 0.5f);
			}

			if (cast.transform.tag == "Other")
			{
				Debug.Log("Touched something bad");
				criatura.transform.position = originalPos; //leva o bichinho de volta pra onde ele estava
				m_spriteRenderer.color = Color.cyan; //retorna para a cor original do sprite
				m_spriteRenderer.material.color = new Color(1f, 1f, 1f, 1f); //retorna a opacidade pra 100%
			}
		}

		else
		{
			Debug.Log("Chão");
		}

		Debug.Log("Dropou");
		m_Collider.enabled = true;
		criatura.transform.localScale /= 1.5f; //retorna o sprite ao tamanho normal 

	}

}
