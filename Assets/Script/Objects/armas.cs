using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armas : MonoBehaviour {

	public GameObject polv;

	public AudioClip cae;
	public AudioClip coje;

	//AUDIO PLAY
	public AudioSource audio1;

	//VOLUMEN
	float efectos;


	// Use this for initialization
	void Start ()
	{
		efectos = PlayerPrefs.GetFloat("efects");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Piso" || col.gameObject.tag == "Water")
		{
			GetComponent<Animator>().SetBool("cae",true);

			audio1.volume = efectos;
			audio1.clip = cae;
			audio1.Play();
		}
		if(col.gameObject.name == "Hero")
		{
			gameObject.layer = LayerMask.NameToLayer("muerto");
			GetComponent<Animator>().SetBool("rompe",true);
			StartCoroutine(espera());

			audio1.volume = efectos;
			audio1.clip = coje;
			audio1.Play();
		}
	}

	IEnumerator espera ()
	{
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}

	void polvo ()
	{
		var efect = (GameObject)Instantiate(polv, transform.position, transform.rotation);
	}
}
