using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class barra : MonoBehaviour {

	public int nivel;

	public float fill;

	// Use this for initialization
	void Start ()
	{
		fill = 0;
		GetComponent<Image>().fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		fill += 0.0005f;
		GetComponent<Image>().fillAmount = fill;

		if(fill >= 1)
		{
			fill = 1;
		}
		if(fill <= 0)
		{
			fill = 0;
		}
	}
}
