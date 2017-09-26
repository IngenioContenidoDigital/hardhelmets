using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vista : MonoBehaviour {

	Vector3 nextPosition;
	float zeta;

	public bool arriba;
	public bool abajo;

	float tiempo;

	int random;

	// Use this for initialization
	void Start ()
	{
		zeta = transform.position.z;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(arriba)
		{
			zeta += 0.2f;
		}
		if(abajo)
		{
			zeta -= 0.2f;
		}

		if(random == 1)
		{
			arriba = true;
		}if(random == 2)
		{
			abajo = true;
		}

		nextPosition = new Vector3(transform.position.x, transform.position.y, zeta);
		transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * 10);
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "pared")
		{
			//random = Random.Range(1,3);
			arriba = false;
			abajo = true;
		}
		if(col.gameObject.tag == "Frente")
		{
			abajo = false;
			arriba = true;
		}
		if(col.gameObject.tag == "obstaculo1")
		{
			arriba = true;
			abajo = false;
		}
		if(col.gameObject.tag == "obstaculo2")
		{
			abajo = true;
			arriba = false;
		}
		if(col.gameObject.name == "PuazD")
		{
			arriba = true;
			abajo = false;
		}
	}

	void OnTriggerExit (Collider col)
	{
		if(col.gameObject.tag == "pared")
		{
			tiempo = Random.Range(0.2f, 1.5f);
			StartCoroutine(espera());
			//abajo = false;
			//arriba = false;
		}
		if(col.gameObject.tag == "Frente")
		{
			tiempo = Random.Range(0.5f, 2.0f);
			StartCoroutine(espera());
			//abajo = false;
			//arriba = false;
		}
		if(col.gameObject.tag == "obstaculo1")
		{
			tiempo = Random.Range(0.5f, 2.0f);
			StartCoroutine(espera());
			//abajo = false;
			//arriba = false;
		}
		if(col.gameObject.tag == "obstaculo2")
		{
			tiempo = Random.Range(0.5f, 2.0f);
			StartCoroutine(espera());
			//abajo = false;
			//arriba = false;
		}
		if(col.gameObject.name == "PuazD")
		{
			tiempo = Random.Range(0.5f, 2.0f);
			StartCoroutine(espera());
			//abajo = false;
			//arriba = false;
		}
	}

	IEnumerator espera ()
	{
		yield return new WaitForSeconds (tiempo);
		abajo = false;
		arriba = false;
	}
}
