using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCustom : MonoBehaviour {

	public static bool uno;
	Vector3 Pos1;
	public static bool dos;
	Vector3 Pos2;
	public static bool tres;
	Vector3 Pos3;

	// Use this for initialization
	void Start ()
	{
		Pos1 = new Vector3(508.7f,-27.9f,-162.51f);
		Pos2 = new Vector3(509.5f,-27.3f,-159f);
		Pos3 = new Vector3(510.3f,-26.5f,-156.5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(uno)
		{
			transform.position = Vector3.Lerp(transform.position, Pos1, Time.deltaTime * 2);
		}else if(dos)
		{
			transform.position = Vector3.Lerp(transform.position, Pos2, Time.deltaTime * 2);
		}else if(tres)
		{
			transform.position = Vector3.Lerp(transform.position, Pos3, Time.deltaTime * 2);
		}else
		{
			transform.position = Vector3.Lerp(transform.position, Pos1, Time.deltaTime * 2);
		}
	}
}
