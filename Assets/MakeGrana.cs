using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class MakeGrana : MonoBehaviour, IPointerClickHandler
{

	public int grana;
	public Text textGemas;

    // Start is called before the first frame update
    void Start()
    {
		grana = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		textGemas.text = "$: " + grana.ToString();
    }

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		grana += 1;
		transform.DOScale(8f, 0.5f);
		transform.DOScale(1f, 0.5f);
	}
}
