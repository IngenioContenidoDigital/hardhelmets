using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour {

	public GameObject efecto;
	int efect;

	// Use this for initialization
	void Start ()
	{
		GetComponent<AudioSource>().pitch = Random.Range(0.8f,1.3f);
	}


	void OnCollisionEnter (Collision col)
	{
		efect = Random.Range(1,3);
		if(col.gameObject.tag == "Player" || col.gameObject.tag == "enemy")
		{
			var explo = (GameObject)Instantiate(efecto, col.gameObject.transform.position, transform.rotation);
			explo.GetComponent<Animator>().SetInteger("efect",efect);
			Destroy(explo, 2.0f);
		}else
		{
			var explo = (GameObject)Instantiate(efecto, transform.position, transform.rotation);
			explo.GetComponent<Animator>().SetInteger("efect",efect);
			Destroy(explo, 2.0f);
		}
		Destroy(gameObject);
	}
}