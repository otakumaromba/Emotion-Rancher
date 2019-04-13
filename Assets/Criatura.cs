using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Criatura : MonoBehaviour
{
	public Text text;

	public string ID;

    void Start()
    {
        
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
