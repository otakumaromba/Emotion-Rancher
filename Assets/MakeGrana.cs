using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
		textGemas.text = "Quantidade de gemas: " + grana.ToString();
    }

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		grana += 1;
	}
}
