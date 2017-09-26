using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelect : MonoBehaviour {

	public Vector3 nextPosition;

	float valor = 0.05f;

	public float h;
	public float v;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		h = valor * Input.GetAxis("Mouse X");
		v = valor * Input.GetAxis("Mouse Y");

		nextPosition = new Vector3(transform.position.x+h, transform.position.y+v, transform.position.z);

		transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * 20);

		//LIMITES DE LA CAMARA
		if(transform.position.x >= 0.31f)
		{
			transform.position = new Vector3(0.31f, transform.position.y, transform.position.z);
		}
		if(transform.position.x <= -0.22f)
		{
			transform.position = new Vector3(-0.22f, transform.position.y, transform.position.z);
		}
		if(transform.position.y >= 1.22f)
		{
			transform.position = new Vector3(transform.position.x, 1.22f, transform.position.z);
		}
		if(transform.position.y <= 0.83f)
		{
			transform.position = new Vector3(transform.position.x, 0.83f, transform.position.z);
		}
	}

	public void Regresar ()
	{
		CamMenu.segundo = true;
		Application.LoadLevel("Menu");
	}
}
