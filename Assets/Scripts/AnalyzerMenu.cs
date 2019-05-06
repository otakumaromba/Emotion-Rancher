using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyzerMenu : MonoBehaviour
{

	public Analyzer analyzer;

	public void OnOpenMenu()
	{
		if (analyzer.criatura1)
		{
			analyzer.img1.OnReceivingCreature(analyzer.criatura1);
		}
	}
}
