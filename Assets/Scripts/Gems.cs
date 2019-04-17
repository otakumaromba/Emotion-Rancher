using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Gems : MonoBehaviour
{
	public int gemas;
	public Text text;
	public GameObject fazedorDeGrana;

    // Start is called before the first frame update
    void Start()
    {
		//Text text = GetComponent<Text>();
		//UpdateGemCount();
    }

    // Update is called once per frame
    void Update()
    {
		//gemas += fazedorDeGrana.GetComponent<MakeGrana>().grana;

		//UpdateGemCount();
		//gemas = UpdateGemCount();
		//int tempoEmSegundos = Mathf.FloorToInt(Time.timeSinceLevelLoad);
		//text.text = "Total de gemas: " + gemas;
		//Debug.Log(gemas);
    }

	/*public string UpdateGemCount() //aumenta a quantidade de gemas por segundo desde o carregamento da cena
	{
		float gemTotal = Time.timeSinceLevelLoad;
		gemTotal = Mathf.FloorToInt(gemTotal);
		string gemas = gemTotal.ToString();
		return gemas;
	}

	/*public int AddGems()
	{
		gemIncrease = 
	}*/

}
