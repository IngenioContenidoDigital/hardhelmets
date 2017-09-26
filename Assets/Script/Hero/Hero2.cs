using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2 : MonoBehaviour {

	public Animator animator;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("DISPARO"))
		{
			disparo();
		}
		if(Input.GetButtonUp("left"))
		{
			
		}
	}
	void disparo()
	{
		animator.SetInteger("disparo", 5);
	}
}
