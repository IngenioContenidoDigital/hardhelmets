using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPanzer : MonoBehaviour {

	Transform Player;

	public bool pelea;

	public string BuscarBase;
	public string NameEnemy;
	public string NameEnemyTank;

	public string _currentDirection = "right";

	//GROUND CHECHER
	public Transform groundCheck;
	float groundRadius = 0.3f;
	public LayerMask whatIsGround;
	public bool grounded = false;

	//OBJETOS DE DISPARO
	public GameObject bulletPref;
	public Transform bulletSpawn;
	public GameObject luz;

	public Animator animator;
	int azar;

	bool vivo = true;
	public int salud = 100;

	public Transform cascadoSpawn;
	public GameObject efecto;
	int efect;
	public GameObject carne;

	public Vector3 ajusteZ;

	//FUNCIONES ALEATORIAS
	public bool shoot;
	public bool alejarce;
	public bool caminar;
	int dist;
	int random;
	int tiempo;

	public float alto;
	//CAMARA LENTA
	int matrix;
	bool matrix2;

	// Use this for initialization
	void Start ()
	{
		matrix = Random.Range(1,6);
		//Player = GameObject.FindWithTag ("Player").transform;
		_currentDirection = "right";
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		grounded = Physics.CheckSphere(groundCheck.position, groundRadius, whatIsGround);
		animator.SetBool("grounded", grounded);

		if(vivo)
		{
			if(pelea)
			{
				
			}
			if(animator.GetCurrentAnimatorStateInfo(0).IsName("panzerShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
			{
				caminar = false;
				alejarce = false;
			}
			ajusteZ = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z);

			if(grounded && !alejarce)
			{
				if(Player != null)
				{
					//MIRA AL JUGADOR
					Vector3 v3Dir = Player.position - transform.position;
					float angle = Mathf.Atan2(0, v3Dir.x) * Mathf.Rad2Deg;
					if(angle == 180 && !alejarce)
					{
						_currentDirection = "left";
						gameObject.transform.localScale = new Vector3(-alto,alto,alto);
					}else if(!alejarce)
					{
						_currentDirection = "right";
						gameObject.transform.localScale = new Vector3(alto,alto,alto);
					}

					animator.SetBool("falling", false);
					//animator.SetBool("falling2", false);
					//SI ESTA MUY LEJOS
					if(Vector3.Distance(transform.position,Player.position) >= 25.01f)
					{
						animator.SetBool("walk",false);
					}
					//SI ESTA LEJOS
					if(Vector3.Distance(transform.position,Player.position) >= 15.01f && Vector3.Distance(transform.position,Player.position) <= 25f && !caminar && !shoot && !alejarce && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))// && ajusteZ.z != Player.transform.position.z)
					{
						tiempo = Random.Range(2,5);
						random = Random.Range(1,6);
					}
					//SI ESTA CERCA
					if(Vector3.Distance(transform.position,Player.position) <= 15 && Vector3.Distance(transform.position,Player.position) >= 9.1f && !alejarce && !caminar && !shoot && !alejarce && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
					{
						tiempo = Random.Range(2,5);
						random = Random.Range(1,6);
					}
					//SI ESTA CERCA MUY CERCA
					if(Vector3.Distance(transform.position,Player.position) <= 9 && !shoot && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))// && ajusteZ.z != Player.transform.position.z)
					{
						caminar = false;
						//Hero.cuchillo = true;
						alejarce = true;
						dist = Random.Range(3,6);
					}
					//DEMACIADO CERCA LE PUEDEN DAR CUCHILLO
					if(Vector3.Distance(transform.position,Player.position) <= 5)// && ajusteZ.z != Player.transform.position.z)
					{
						Hero.cuchillo = true;
					}
				}
				//CAMINAR
				if(caminar && !alejarce && !shoot && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
				{
					animator.SetInteger("descanso",0);
					animator.SetBool("walk",true);
					if(Player.transform.position.z-1 > transform.position.z || Player.transform.position.z+1 < transform.position.z)
					{
						transform.position = Vector3.Lerp(transform.position, ajusteZ, Time.deltaTime * 1);
					}
					if(_currentDirection == "right")
					{
						GetComponent<Rigidbody>().velocity = (Vector2.right * 10);
					}else
					{
						GetComponent<Rigidbody>().velocity = (Vector2.left * 10);
					}
				}
				//SHOOT
				if(shoot && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
				{
					animator.SetBool("panzerShot", true);
				}
			}else if(!grounded)
			{
				alejarce = false;
			}
			//ANIMACION CAYENDO
			if(GetComponent<Rigidbody>().velocity.y < -0.1f)
			{
				animator.SetBool("falling", true);
			}else
			{
				animator.SetBool("falling", false);
			}
			//ALEJARCE
			if(alejarce && !shoot && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
			{
				animator.SetBool("walk",true);
				caminar = false;
				if(_currentDirection == "left")
				{
					GetComponent<Rigidbody>().velocity = (Vector2.right * 10);
					gameObject.transform.localScale = new Vector3(alto,alto,alto);
				}else
				{
					GetComponent<Rigidbody>().velocity = (Vector2.left * 10);
					gameObject.transform.localScale = new Vector3(-alto,alto,alto);
				}
				StartCoroutine(esperaAleja());
			}

			if(salud <= 0)
			{
				animator.SetBool("muerto", true);
				azar = Random.Range(1,3);
				animator.SetInteger("muerte", azar);
				vivo = false;
			}
			//RANDOM FUNCTIONS
			if(random == 1)
			{
				random = 0;
				StartCoroutine(espera());
				caminar = true;
			}else if(random == 2)
			{
				random = 0;
				if(Player.transform.position.z-2 > transform.position.z || Player.transform.position.z+2 < transform.position.z)
				{
					caminar = true;
					StartCoroutine(espera());
					//random = Random.Range(1,6);
				}else
				{
					shoot = true;
				}
				//shoot = true;
			}else if(random == 3)
			{
				random = 0;
				//NO HACE NADA
			}else if(random == 4)
			{
				random = 0;
				if(Player.transform.position.z-3 > transform.position.z || Player.transform.position.z+3 < transform.position.z)
				{
					caminar = true;
					StartCoroutine(espera());
					//random = Random.Range(1,6);
				}else
				{
					shoot = true;
				}
			}else if(random == 5)
			{
				random = 0;
				//NO HACE NADA
			}
		}else
		{
			if(matrix == 1 && !matrix2  && Player.name == "Hero")
			{
				Manager.lenta = true;
			}
			gameObject.layer = LayerMask.NameToLayer("muerto");
			gameObject.tag = "Untagged";
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "cuchillo" && vivo)
		{
			animator.SetBool("walk",false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 4);
			efect = Random.Range(3,5);
			if(PlayerPrefs.GetInt("violencia") == 1)
			{
				var explo = (GameObject)Instantiate(efecto, cascadoSpawn.position, cascadoSpawn.rotation); 
				explo.GetComponent<Animator>().SetInteger("efect",efect);
				Destroy(explo, 2.0f);
			}
			Hero.cuchillo = false;
			salud -= 25;
		}
		if(col.gameObject.tag == "bala" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk",false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 10;
		}
		if(col.gameObject.tag == "balaFusil" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk",false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 25;
		}
		if(col.gameObject.tag == "balaEscopeta" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk",false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 10;
		}
		if(col.gameObject.tag == "balaSubmetra" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk",false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 20;
		}
		if(col.gameObject.tag == "balaMetra" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk",false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 25;
		}
		if(col.gameObject.tag == "balaMG" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk",false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 50;
		}
		if(col.gameObject.tag == "balaSniper" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk",false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			col.gameObject.SetActive(false);
			salud -= 100;
		}
		if(col.gameObject.tag == "explo" && vivo)
		{
			vivo = false;
			Instantiate(carne, cascadoSpawn.position, cascadoSpawn.rotation);
			GetComponent<Rigidbody>().AddForce(transform.right * Random.Range(900,-900));
			GetComponent<Rigidbody>().velocity = (Vector2.up * Random.Range(20,35));
			animator.SetInteger("muerte", 3);
			salud -= 100;
		}
	}
	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == NameEnemy && vivo)
		{
			pelea = true;
			Player = col.gameObject.transform;
		}
		if(col.gameObject.tag == NameEnemyTank && vivo)
		{
			pelea = true;
			Player = col.gameObject.transform;
		}
	}

	void OnTriggerExit (Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			Player = null;
		}
		if(col.gameObject.tag == "Tank")
		{
			Player = null;
		}
	}
	//deja de alejarce
	IEnumerator esperaAleja()
	{
		yield return new WaitForSeconds(dist);
		//animator.SetBool("walk",false);
		alejarce = false;
	}
	//APAGA LA LUZ
	IEnumerator apaga ()
	{
		yield return new WaitForSeconds(0.1f);
		luz.SetActive(false);
	}

	IEnumerator espera()
	{
		yield return new WaitForSeconds(tiempo);
		//animator.SetBool("walk",false);
		caminar = false;
	}

	//EVENTOS SPINE
	public void cancel ()
	{
		shoot = false;
	}
	void rocket ()
	{
		Instantiate(bulletPref, bulletSpawn.position, bulletSpawn.rotation);
	}
}
