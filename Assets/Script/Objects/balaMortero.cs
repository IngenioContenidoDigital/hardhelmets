using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaMortero : MonoBehaviour {

	public GameObject explo;

	Transform Player;

	void Start ()
	{
		Player = GameObject.FindWithTag ("Player").transform;
	}

	//EVENTOS SPINE
	void bomba ()
	{
		var efect = (GameObject)Instantiate(explo, transform.position, transform.rotation);
		Destroy(efect, 2.0f);
		Destroy(gameObject);
	}
}
