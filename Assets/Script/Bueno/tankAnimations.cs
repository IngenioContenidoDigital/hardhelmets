using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankAnimations : MonoBehaviour {

	public GameObject polv;

	public Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("TankShoot"))
		{
			animator.SetBool("disparo", false);
			animator.SetBool("frenando", false);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("accel") || animator.GetCurrentAnimatorStateInfo(0).IsName("accelBack"))
		{
			animator.SetBool("walk", false);
			animator.SetBool("walking", true);
			animator.SetBool("frenando", false);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("drive"))
		{
			animator.SetBool("walking", true);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("muerto"))
		{
			animator.SetBool("muerto", false);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("frenada"))
		{
			animator.SetBool("frenando", true);
		}
	}

	void polvo ()
	{
		var efect = (GameObject)Instantiate(polv, transform.position, transform.rotation);
	}
}
