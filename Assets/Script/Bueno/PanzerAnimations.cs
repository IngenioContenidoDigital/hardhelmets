using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanzerAnimations : MonoBehaviour {

	public Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("jump2"))
		{
			animator.SetBool("falling", false);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("panzerwalk"))
		{
			animator.SetBool("walk", false);
			animator.SetBool("walking", true);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("KillSimple"))
		{
			animator.SetInteger("muerte", 0);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("KillSimple2"))
		{
			animator.SetInteger("muerte", 0);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("KillJump"))
		{
			animator.SetInteger("muerte", 0);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
		{
			animator.SetInteger("cascado", 0);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("panzerShot"))
		{
			animator.SetBool("disparo", false);
		}
	}
}
