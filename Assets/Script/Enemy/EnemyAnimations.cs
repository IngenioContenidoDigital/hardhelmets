using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour {

	public Animator animator;

	string _currentDirection = "right";

	//TIEMPO QUIETO
	//public float quieto = 0.0f;
	public int azar;

	//EFECTOS
	public GameObject sangre;
	public GameObject polv;

	public Transform PasoD;
	public Transform PasoI;
	public GameObject pasopolvo;
	public GameObject pasopolvo2;

	public GameObject strike;
	public GameObject strikearma;
	public GameObject strikeescopeta;
	public GameObject strikegun;
	public Transform strikeSpawn;

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		//QUIETO AL AZAR
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("GunIdle") || animator.GetCurrentAnimatorStateInfo(0).IsName("panzerpose"))
		{
			//quieto += 0.1f;
			animator.SetBool("walking", false);
		}else
		{
			//quieto = 0;
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Descanso") || animator.GetCurrentAnimatorStateInfo(0).IsName("Descanso2"))
		{
			animator.SetInteger("descanso", 0);
			azar = 0;
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("panzerShot"))
		{
			animator.SetBool("panzerShot", false);
		}
		//MOVIMIENTOS BASICOS
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("walk") || animator.GetCurrentAnimatorStateInfo(0).IsName("GunWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("panzerwalk"))
		{
			//animator.SetBool("walk", false);
			animator.SetBool("walking", true);
			//Hero.cuchillo = false;
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("jump1"))
		{
			animator.SetBool("jump", false);
		}
		//CALLENDO
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("jump2"))
		{
			animator.SetBool("falling2", true);
		}
		//DISPARO
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("FusilShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("SubmetraShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("MetraShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("Granada"))
		{
			animator.SetInteger("disparo", 0);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("FusilShotWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunShotWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("SubmetraShotWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("MetraShotWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("GranadaWalk")
			|| animator.GetCurrentAnimatorStateInfo(0).IsName("jumpShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("jumpShotUp") || animator.GetCurrentAnimatorStateInfo(0).IsName("jumpShotDown"))
		{
			animator.SetInteger("disparo", 0);
		}

		//RECARGA
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("FusilRecarga") || animator.GetCurrentAnimatorStateInfo(0).IsName("GunRecarga") || animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunRecarga") || animator.GetCurrentAnimatorStateInfo(0).IsName("RecargaMetraySub"))
		{
			animator.SetBool("recargando", true);
			//Enemy.cargando = true;
			animator.SetInteger("recarga", 0);
		}else if(!animator.GetCurrentAnimatorStateInfo(0).IsName("GunIRecarga"))
		{
			animator.SetBool("recargando", false);
			//Enemy.cargando = false;
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("FusilRecargaWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("GunRecargaWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunRecargaWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("RecargaMetraySubWalk"))
		{
			animator.SetInteger("recarga", 0);
		}
		//PISTOLA
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("GunIdle"))
		{
			//animator.SetBool("walk", false);
			animator.SetBool("pistolando", true);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("GunIRecarga"))
		{
			animator.SetBool("recargando", true);
			//Enemy.cargando = true;
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("KillJump"))
		{
			animator.SetInteger("muerte", 0);
		}
		//CUCHILLO
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Knife1") || animator.GetCurrentAnimatorStateInfo(0).IsName("KnifeWalk"))
		{
			animator.SetBool("cuchillo", false);
			animator.SetBool("cuchillando", true);
		}else if(animator.GetCurrentAnimatorStateInfo(0).IsName("Knife2"))
		{
			animator.SetBool("cuchillo2", false);
			animator.SetBool("cuchillando", true);
		}else
		{
			animator.SetBool("cuchillando", false);
		}
		//CAMBIO ARMA
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Cambio"))
		{
			animator.SetBool("cambio", false);
		}
		//MUERTE
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("KillSimple") || animator.GetCurrentAnimatorStateInfo(0).IsName("KillSimple2") || animator.GetCurrentAnimatorStateInfo(0).IsName("KillBackJump"))
		{
			animator.SetBool("muerto", true);
			animator.SetInteger("muerte", 0);
		}
		//CASCADO
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Hit") || animator.GetCurrentAnimatorStateInfo(0).IsName("HitKnife")|| animator.GetCurrentAnimatorStateInfo(0).IsName("MGHit"))
		{
			animator.SetBool("walk", false);
			animator.SetInteger("cascado", 0);
		}
		//AGACHADO
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Agachado"))
		{
			animator.SetBool("cubrirse", false);
			animator.SetBool("cubierto", true);
		}
		/*
		if(quieto >= 12)
		{
			azar = Random.Range(1,3);
			animator.SetInteger("descanso", azar);
			quieto = 0;
		}
		*/
	}
	//EVENTOS SPINE
	void blood ()
	{
		if(PlayerPrefs.GetInt("violencia") == 1)
		{
			var efect = (GameObject)Instantiate(sangre, transform.position, transform.rotation);
		}
	}
	void muerto ()
	{
		Destroy(gameObject);
	}
	void polvo ()
	{
		var efect = (GameObject)Instantiate(polv, transform.position, transform.rotation);
		Destroy(efect, 1.0f);
	}
	void paso()
	{
		var efect = (GameObject)Instantiate(pasopolvo, PasoD.transform.position, PasoD.transform.rotation);
	}
	void paso2()
	{
		var efect = (GameObject)Instantiate(pasopolvo2, PasoI.transform.position, PasoI.transform.rotation);
	}
	void rafaga ()
	{
		if(transform.localScale.x == 1)
		{
			var efect = (GameObject)Instantiate(strike, strikeSpawn.transform.position, transform.rotation);
		}else
		{
			var efect = (GameObject)Instantiate(strike, strikeSpawn.transform.position, Quaternion.Euler(0,0,strikeSpawn.transform.rotation.z-180));
		}
	}
	void rafagaarma ()
	{
		if(transform.localScale.x == 1)
		{
			var efect = (GameObject)Instantiate(strikearma, strikeSpawn.transform.position, strikeSpawn.rotation);
		}else
		{
			var efect = (GameObject)Instantiate(strikearma, strikeSpawn.transform.position, Quaternion.Euler(0,0,strikeSpawn.transform.rotation.z-180));
		}
	}
	void rafagaarmametra ()
	{
		if(transform.localScale.x == 1)
		{
			var efect = (GameObject)Instantiate(strikearma, strikeSpawn.transform.position, Quaternion.Euler(0,0,strikeSpawn.transform.rotation.z));
		}else
		{
			var efect = (GameObject)Instantiate(strikearma, strikeSpawn.transform.position, Quaternion.Euler(0,0,strikeSpawn.transform.rotation.z-180));
		}
		//var efect = (GameObject)Instantiate(strikearma, strikeSpawn.transform.position, strikeSpawn.rotation);
	}
	void rafagagun ()
	{
		if(transform.localScale.x == 1)
		{
			var efect = (GameObject)Instantiate(strikegun, strikeSpawn.transform.position,strikeSpawn.rotation);
		}else
		{
			var efect = (GameObject)Instantiate(strikegun, strikeSpawn.transform.position, Quaternion.Euler(0,0,strikeSpawn.transform.rotation.z-180));
		}
	}
	void rafagaescopeta ()
	{
		if(transform.localScale.x == 1)
		{
			var efect = (GameObject)Instantiate(strikeescopeta, strikeSpawn.transform.position, strikeSpawn.rotation);
		}else
		{
			var efect = (GameObject)Instantiate(strikeescopeta, strikeSpawn.transform.position, Quaternion.Euler(0,0,strikeSpawn.transform.rotation.z-180));
		}
	}
}
