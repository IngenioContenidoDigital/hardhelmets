using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textos : MonoBehaviour {

	int random;

	// Use this for initialization
	void Start ()
	{
		random = Random.Range(1,4);
		GetComponent<Animator>().SetInteger("inicio", random);
		//transform.parent = null;
		if(transform.parent.transform.localScale.x <= -1)
		{
			transform.rotation = Quaternion.Euler(0,180,0);
		}
	}
	
	public void destruir()
	{
		Destroy(gameObject);
	}
}
