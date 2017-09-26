using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Com.LuisPedroFonseca.ProCamera2D;

public class secundario : MonoBehaviour {

	public Transform Player;

	public Transform objetivo;

	public Vector3 inicial;
	public Vector3 nextPosition;

	public GameObject camara;

	// Use this for initialization
	void Start ()
	{
		inicial = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(objetivo != null)
		{
			camara.GetComponent<ProCamera2DSpeedBasedZoom>().enabled = false;
			nextPosition = new Vector3(objetivo.transform.position.x, transform.position.y, transform.position.z);//objetivo.transform.position;
		}else
		{
			camara.GetComponent<ProCamera2DSpeedBasedZoom>().enabled = true;
			nextPosition = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);//Player.position;
		}

		transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * 2);
	}
}
