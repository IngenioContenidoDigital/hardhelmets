using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaTank : MonoBehaviour {

	public GameObject explocion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
	{
		var explo = (GameObject)Instantiate(explocion, transform.position, Quaternion.identity); 
		Destroy(explo, 2.0f);
		Destroy(gameObject);
	}
}
