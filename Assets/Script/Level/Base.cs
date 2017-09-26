using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

	public float sangre;

	public UnityEngine.UI.Image salud;

	void Start ()
	{

	}

	void Update ()
	{
		salud.fillAmount = sangre/100;

		if(sangre <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "bala")
		{
			sangre -= 10;
		}
		if(col.gameObject.tag == "balaFusil")
		{
			sangre -= 25;
		}
		if(col.gameObject.tag == "balaEscopeta")
		{
			sangre -= 10;
		}
		if(col.gameObject.tag == "balaSubmetra")
		{
			sangre -= 20;
		}
		if(col.gameObject.tag == "balaMetra")
		{
			sangre -= 25;
		}
		if(col.gameObject.tag == "balaMG")
		{
			sangre -= 50;
		}
		if(col.gameObject.tag == "explo")
		{
			sangre -= 100;
		}
	}
}
