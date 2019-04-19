using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Criatura : MonoBehaviour
{
	public Text text;

	public string ID;

	public Image image;

	public Sprite sprite;

    void Start()
    {
		sprite = GetComponent<SpriteRenderer>().sprite;
		image = GetComponent<Image>();
    }

    void Update()
    {
        
    }

	public void Initialize(string ID)
	{
		this.ID = ID;
		text.text = ("É um " + ID + "!");
	}
}
