using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaciones : MonoBehaviour {

	public Animator animator;

	//TIEMPO QUIETO
	public float quieto = 0.0f;
	public int azar;

	//EFECTOS
	public GameObject sangre;
	public GameObject polv;
	public GameObject gota;
	public GameObject splash;
	bool inwater;
	public GameObject Ondas;
	public GameObject soul;

	public Transform PasoD;
	public Transform PasoI;
	public GameObject pasopolvo;
	public GameObject pasopolvo2;

	public GameObject strikearma;
	public GameObject strikeescopeta;
	public GameObject strikegun;
	public Transform strikeSpawn;
	public Transform strikeSpawnPistola;
	public Transform strikeSpawnMetra;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//QUIETO AL AZAR
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("GunIdle"))
		{
			quieto += 0.1f;
			animator.SetBool("walking", false);
			animator.SetBool("cubierto", false);
		}else
		{
			quieto = 0;
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Descanso") || animator.GetCurrentAnimatorStateInfo(0).IsName("Descanso2"))
		{
			animator.SetInteger("descanso", 0);
			azar = 0;
		}
		//MOVIMIENTOS BASICOS
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("walk") || animator.GetCurrentAnimatorStateInfo(0).IsName("GunWalk"))
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
		//CAE AL PISO
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("jump3"))
		{
			animator.SetBool("falling2", false);
			Hero.rafaga = true;
		}
		//DISPARO
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("FusilShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("SubmetraShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("MetraShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("Granada") || animator.GetCurrentAnimatorStateInfo(0).IsName("GunShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("sniper"))
		{
			animator.SetInteger("disparo", 0);
			animator.SetBool("cubierto", false);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("FusilShotWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunShotWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("SubmetraShotWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("MetraShotWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("GranadaWalk")
			|| animator.GetCurrentAnimatorStateInfo(0).IsName("jumpShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("jumpShotUp") || animator.GetCurrentAnimatorStateInfo(0).IsName("jumpShotDown") || animator.GetCurrentAnimatorStateInfo(0).IsName("backJumpShot"))
		{
			animator.SetInteger("disparo", 0);
		}

		//RECARGA
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("FusilRecarga") || animator.GetCurrentAnimatorStateInfo(0).IsName("GunRecarga") || animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunRecarga") || animator.GetCurrentAnimatorStateInfo(0).IsName("RecargaMetraySub") || animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasrecarga"))
		{
			animator.SetBool("recargando", true);
			animator.SetBool("cubierto", false);
			Hero.rafaga = true;
			//Hero.cargando = true;
			animator.SetInteger("recarga", 0);
		}else if(!animator.GetCurrentAnimatorStateInfo(0).IsName("GunIRecarga"))
		{
			animator.SetBool("recargando", false);
			//Hero.cargando = false;
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("FusilRecargaWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("GunRecargaWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunRecargaWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("RecargaMetraySubWalk"))
		{
			animator.SetBool("recargando", true);
			animator.SetInteger("recarga", 0);
			animator.SetBool("cubierto", false);
		}
		//PISTOLA
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("GunIdle"))
		{
			//animator.SetBool("walk", false);
			animator.SetBool("pistolando", true);
			animator.SetBool("cubierto", false);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("GunIRecarga"))
		{
			animator.SetBool("recargando", true);
			Hero.cargando = true;
		}
		//LANSA LLAMAS
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasPose") || animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasPoseWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasrecarga"))
		{
			animator.SetBool("flameando", true);
			Hero.rafaga = true;
		}else
		{
			animator.SetBool("flameando", false);
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
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Hit") || animator.GetCurrentAnimatorStateInfo(0).IsName("HitKnife") || animator.GetCurrentAnimatorStateInfo(0).IsName("KillJump"))
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
		//SALTO ATRAS
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("backJump"))
		{
			animator.SetBool("jumpback", false);
			animator.SetBool("cubrirse", false);
			animator.SetBool("cubierto", false);
			animator.SetBool("movimiento", true);
		}

		if(animator.GetCurrentAnimatorStateInfo(0).IsName("cae"))
		{
			animator.SetBool("granada", false);

			animator.SetBool("jumpback", false);
			animator.SetBool("falling2", false);
			animator.SetBool("cubrirse", false);
			animator.SetBool("cubierto", false);
			animator.SetInteger("disparo", 0);
			if(animator.GetBool("grounded"))
			{
				animator.SetBool("movimiento", false);
			}
			Hero.rafaga = true;
		}
		//TIEMPO QUIETO
		if(quieto >= 12)
		{
			azar = Random.Range(1,3);
			animator.SetInteger("descanso", azar);
			quieto = 0;
		}
		if(inwater)
		{
			Ondass.activas = true;
			Ondas.SetActive(true);
		}else
		{
			Ondass.activas = false;
			Ondas.SetActive(false);
		}
	}
	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "Water")
		{
			if(GetComponent<Rigidbody>().velocity.y <= -4f)
			{
				var efect = (GameObject)Instantiate(splash, new Vector3(PasoD.transform.position.x, col.gameObject.transform.position.y+0.1f, PasoD.transform.position.z), Quaternion.Euler(90,0,0));
			}
			Ondass.posOndas = col.gameObject.transform.position.y;
			inwater = true;
		}
	}
	void OnTriggerExit (Collider col)
	{
		if(col.gameObject.tag == "Water")
		{
			if(GetComponent<Rigidbody>().velocity.y >= 4f)
			{
				var efect = (GameObject)Instantiate(splash, new Vector3(PasoD.transform.position.x, col.gameObject.transform.position.y+0.1f, PasoD.transform.position.z), Quaternion.Euler(90,0,0));
			}
			inwater = false;
		}
	}
	//EVENTOS SPINE
	void load ()
	{
		Hero.load = true;
	}
	void blood ()
	{
		if(PlayerPrefs.GetInt("violencia") == 1)
		{
			var efect = (GameObject)Instantiate(sangre, transform.position, transform.rotation);
		}
		var efect2 = (GameObject)Instantiate(soul, transform.position, transform.rotation);
		//Destroy(efect, 10.0f);
	}
	void muerto ()
	{
		Destroy(gameObject);
	}
	void polvo ()
	{
		if(!Hero.water)
		{
			var efect = (GameObject)Instantiate(polv, transform.position, transform.rotation);
		}
	}

	void paso()
	{
		if(!Hero.water)
		{
			var efect = (GameObject)Instantiate(pasopolvo, PasoD.transform.position, PasoD.transform.rotation);
		}else
		{
			var efect = (GameObject)Instantiate(gota, transform.position, transform.rotation);
		}
	}
	void paso2()
	{
		if(!Hero.water)
		{
			var efect = (GameObject)Instantiate(pasopolvo2, PasoI.transform.position, PasoI.transform.rotation);
		}else
		{
			var efect = (GameObject)Instantiate(gota, transform.position, transform.rotation);
		}
	}
	void rafagaarma ()
	{
		if(Hero._currentDirection == "right")
		{
			var efect = (GameObject)Instantiate(strikearma, strikeSpawn.transform.position, strikeSpawn.rotation);//Quaternion.Euler(0,0,strikeSpawn.rotation.z));
		}else
		{
			var efect = (GameObject)Instantiate(strikearma, strikeSpawn.transform.position, Quaternion.Euler(0,180,strikeSpawn.rotation.z));//Quaternion.Euler(0,0,strikeSpawn.rotation.z));
		}
	}
	void rafagaarmametra ()
	{
		if(Hero._currentDirection == "right")
		{
			var efect = (GameObject)Instantiate(strikearma, strikeSpawnMetra.transform.position, strikeSpawnMetra.rotation);//Quaternion.Euler(0,0,strikeSpawn.rotation.z));
		}else
		{
			var efect = (GameObject)Instantiate(strikearma, strikeSpawnMetra.transform.position, Quaternion.Euler(0,180,strikeSpawnMetra.rotation.z));//Quaternion.Euler(0,0,strikeSpawn.rotation.z));
		}
	}
	void rafagagun ()
	{
		
		if(Hero._currentDirection == "right")
		{
			var efect = (GameObject)Instantiate(strikegun, strikeSpawnPistola.transform.position, strikeSpawnPistola.rotation);//Quaternion.Euler(strikeSpawn.rotation.x,strikeSpawn.rotation.y,strikeSpawn.rotation.z-90));//strikeSpawn.rotation);//Quaternion.Euler(0,0,strikeSpawn.rotation.z));
		}else
		{
			var efect = (GameObject)Instantiate(strikegun, strikeSpawnPistola.transform.position, Quaternion.Euler(0,0,strikeSpawnPistola.rotation.z-180));//Quaternion.Euler(0,0,strikeSpawn.rotation.z));
		}
	}
	void rafagaescopeta ()
	{
		if(Hero._currentDirection == "right")
		{
			var efect = (GameObject)Instantiate(strikeescopeta, strikeSpawn.transform.position, strikeSpawn.rotation);//Quaternion.Euler(0,0,strikeSpawn.rotation.z));
		}else
		{
			var efect = (GameObject)Instantiate(strikeescopeta, strikeSpawn.transform.position, Quaternion.Euler(0,0,strikeSpawnPistola.rotation.z-180));//Quaternion.Euler(0,0,strikeSpawn.rotation.z));
		}
	}
	void cuchillo ()
	{
		Hero.rafaga = true;
	}
	void cuchillob ()
	{
		Hero.rafaga = true;
	}
}
