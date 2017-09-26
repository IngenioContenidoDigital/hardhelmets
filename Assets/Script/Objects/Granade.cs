using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour {

	public GameObject explocion;

	public Light luz;
	int total;
	bool mas;
	bool menos;

	bool contar;
	int tiempo;

	void Update ()
	{
		if(contar)
		{
			tiempo++;
			if(total <= 0)
			{
				menos = false;
				mas = true;
			}
			if(total >= 50)
			{
				mas = false;
				menos = true;
			}
			if(mas)
			{
				total += 5;
			}
			if(menos)
			{
				total -= 5;
			}
		}
		if(tiempo >= 100)
		{
			var explo = (GameObject)Instantiate(explocion, transform.position, Quaternion.identity); 
			Destroy(gameObject);
		}
		luz.intensity = total;
	}

	void OnCollisionEnter (Collision col)
	{
		contar = true;
		if(col.gameObject.tag == "explo")
		{
			var explo = (GameObject)Instantiate(explocion, transform.position, Quaternion.identity); 
			Destroy(gameObject);
		}
		//var explo = (GameObject)Instantiate(explocion, transform.position, Quaternion.identity); 
		//Destroy(explo, 2.0f);
		//Destroy(gameObject);
	}
}
