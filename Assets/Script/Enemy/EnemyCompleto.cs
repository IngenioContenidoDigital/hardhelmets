using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCompleto : MonoBehaviour {

	public bool pelea;

	public Transform Player;

	public int Tipo;

	public Transform target;

	public Animator animator;
	string _currentDirection = "right";

	public bool vivo = true;
	public int salud;

	//FUNCIONES
	bool actuando2;
	bool caminar2;
	bool shoot2;
	int disparos2;


	//ESQUIVAR OBSTACULOS
	Vector3 nextPosition;
	public Transform seguir;


	//GROUND CHECHER
	public Transform groundCheck;
	float groundRadius = 0.3f;
	public LayerMask whatIsGround;
	public bool grounded = false;

	//SEGUNDO SCRIPT
	//OBJETOS DE DISPARO
	public GameObject bulletPref;
	public GameObject bulletPrefFusil;
	public GameObject bulletPrefEscopeta;
	public GameObject bulletPrefSubmetra;
	public GameObject bulletPrefMetra;

	public Transform bulletSpawn;
	public GameObject casquilloPref;
	public Transform casquilloSpawn;
	public GameObject granadePref;
	public GameObject luz;

	int azar;

	public Transform cascadoSpawn;
	public GameObject efecto;
	int efect;
	public GameObject carne;

	//FUNCIONES ALEATORIAS
	bool actuando;

	bool cubrirse;
	bool cubierto;
	public Vector3 coverPosition;
	bool shoot;
	int disparos;
	public bool alejarce;
	public bool alejarce2;
	public bool caminar;
	float dist;
	int dist2;
	int random;
	int tiempo;
	int tiempocover;

	bool rafaga = true;
	bool recarga;
	bool cargando = false;

	//CAMARA LENTA
	int matrix;
	bool matrix2;

	Vector3 v3;
	int dir;

	bool mirando;

	// Use this for initialization
	void Start ()
	{
		animator.SetBool("falling", true);

		matrix = Random.Range(1,6);
		_currentDirection = "right";
	}
	
	// Update is called once per frame
	void Update ()
	{
		//CHECA SI ESTA EN EL PISO
		grounded = Physics.CheckSphere(groundCheck.position, groundRadius, whatIsGround);
		animator.SetBool("grounded", grounded);

		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
		{
			caminar = false;
			caminar2 = false;
			alejarce = false;
		}
		if(Player == null)
		{
			pelea = false;
		}
		if(pelea)
		{
			if(vivo)
			{
				if(grounded)
				{
					//MIRA AL OBJKETIVO
					Vector3 v3Dir = Player.position - transform.position;
					float angle = Mathf.Atan2(0, v3Dir.x) * Mathf.Rad2Deg;
					if(angle == 180 && !alejarce && !alejarce2)
					{
						_currentDirection = "left";
						gameObject.transform.localScale = new Vector3(-1,1,1);
					}else if(!alejarce && !alejarce2)
					{
						_currentDirection = "right";
						gameObject.transform.localScale = new Vector3(1,1,1);
					}

					animator.SetBool("falling", false);
					animator.SetBool("falling2", false);

					if(Player.name != "UTank")
					{
						if(Mathf.Abs((transform.position - Player.position).x) >= 5.01f && Mathf.Abs((transform.position - Player.position).x) <= 35f && !actuando && !alejarce && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))//(Vector3.Distance(transform.position.x, Player.position.x) >= 8.01f && Vector3.Distance(transform.position.x, Player.position.x) <= 25f && !actuando && !alejarce && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
						{
							Funciones();
						}
						if(Mathf.Abs((transform.position - Player.position).x) <= 5 && !cubrirse && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))//(Vector3.Distance(transform.position.x, Player.position.x) <= 5 && !cubrirse && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
						{
							caminar = false;
							shoot = false;
							alejarce2 = true;
							dist2 = Random.Range(1,3);
							StartCoroutine(esperaAleja2());
							actuando = true;
						}																															
					}else
					{
						if(Mathf.Abs((transform.position - Player.position).x) >= 25.01f && !shoot && !actuando && !alejarce && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))// && Mathf.Abs((transform.position - Player.position).x) <= 35f && !shoot && !actuando && !alejarce && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))//(Vector3.Distance(transform.position.x, Player.position.x) >= 8.01f && Vector3.Distance(transform.position.x, Player.position.x) <= 25f && !actuando && !alejarce && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
						{
							FuncionesTanque();
						}
						if(Mathf.Abs((transform.position - Player.position).x) <= 25 && !cubrirse && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))//(Vector3.Distance(transform.position.x, Player.position.x) <= 5 && !cubrirse && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
						{
							caminar = false;
							shoot = false;
							alejarce2 = true;
							dist2 = Random.Range(1,3);
							StartCoroutine(esperaAleja2());
							actuando = true;
						}	
					}

					//ACCIONES UPDATE
					//ALEJARCE
					if(alejarce)
					{
						shoot = false;
						animator.SetBool("walk",true);
						if(_currentDirection == "left")
						{
							GetComponent<Rigidbody>().velocity = (Vector2.right * 8);
							gameObject.transform.localScale = new Vector3(1,1,1);
						}else
						{
							GetComponent<Rigidbody>().velocity = (Vector2.left * 8);
							gameObject.transform.localScale = new Vector3(-1,1,1);
						}
						nextPosition = new Vector3(transform.position.x, transform.position.y, seguir.transform.position.z);
						transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * 20);
					}
					//ALEJARCE
					if(alejarce2)
					{
						shoot = false;
						animator.SetBool("walk",true);
						if(_currentDirection == "left")
						{
							GetComponent<Rigidbody>().velocity = (Vector2.right * 8);
							gameObject.transform.localScale = new Vector3(1,1,1);
						}else
						{
							GetComponent<Rigidbody>().velocity = (Vector2.left * 8);
							gameObject.transform.localScale = new Vector3(-1,1,1);
						}

						nextPosition = new Vector3(transform.position.x, transform.position.y, seguir.transform.position.z);
						transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * 20);
					}else
					{
						dir = Random.Range(1,3);
					}
					/*if(v3 != Vector3.zero)
				{
					GetComponent<Rigidbody>().velocity = (8 * v3.normalized);
				}*/
					//CAMINAR
					if(caminar)
					{
						animator.SetInteger("descanso",0);
						animator.SetBool("walk",true);
						if(_currentDirection == "right")
						{
							GetComponent<Rigidbody>().velocity = (Vector2.right * 8);
						}else
						{
							GetComponent<Rigidbody>().velocity = (Vector2.left * 8);
						}
						if(Player.transform.position.z > transform.position.z)
						{
							seguir.GetComponent<vista>().arriba = true;
						}else if(Player.transform.position.z < transform.position.z)
						{
							seguir.GetComponent<vista>().abajo = true;
						}
						nextPosition = new Vector3(transform.position.x, transform.position.y, seguir.transform.position.z);
						transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * 20);
					}
					if(animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
					{
						actuando = false;
					}
					//DISPARO
					if(shoot && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit") || animator.GetCurrentAnimatorStateInfo(0).IsName("FusilShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("SubmetraShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("MetraShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("Granada"))
					{
						seguir.GetComponent<vista>().arriba = false;
						seguir.GetComponent<vista>().abajo = false;

						if(disparos >= 2)//2
						{
							disparos = 0;
							animator.SetInteger("recarga", Tipo);
						}else
						{
							disparos += 1;
							animator.SetInteger("disparo", Tipo);
							actuando = false;
						}
						shoot = false;
					}
				}else if(!grounded)
				{
					alejarce = false;
				}
				//ANIMACION CAYENDO
				if(GetComponent<Rigidbody>().velocity.y < -4f)
				{
					animator.SetBool("falling", true);
				}else
				{
					animator.SetBool("falling", false);
				}

				if(salud <= 0)
				{
					animator.SetBool("muerto", true);
					azar = Random.Range(1,3);
					animator.SetInteger("muerte", azar);
					vivo = false;
				}
			}else
			{
				if(matrix == 1 && !matrix2)
				{
					matrix2 = true;
					Manager.lenta = true;
				}
				gameObject.layer = LayerMask.NameToLayer("muerto");
				gameObject.tag = "Untagged";
			}
		}else
		{
			if(grounded && target == null)
			{
				target = GameObject.FindWithTag ("base").transform;
			}
			if(target != null)
			{
				//MIRA AL OBJKETIVO
				Vector3 v3Dir = target.position - transform.position;
				float angle = Mathf.Atan2(0, v3Dir.x) * Mathf.Rad2Deg;

				if(angle == 180)
				{
					_currentDirection = "left";
					gameObject.transform.localScale = new Vector3(-1,1,1);
				}else
				{
					_currentDirection = "right";
					gameObject.transform.localScale = new Vector3(1,1,1);
				}
			}

			if(salud <= 0)
			{
				animator.SetBool("muerto", true);
				int azar = Random.Range(1,3);
				animator.SetInteger("muerte", azar);
				vivo = false;

				gameObject.layer = LayerMask.NameToLayer("muerto");
				gameObject.tag = "Untagged";
			}

			//SI ESTA MUY LEJOS
			if(Mathf.Abs((transform.position - target.position).x) >= 30 && !caminar2)
			{
				caminar2 = true;
			}
			if(Mathf.Abs((transform.position - target.position).x) <= 29.9f && !actuando2)
			{
				shoot2 = true;
			}

			if(caminar2)
			{
				animator.SetInteger("descanso",0);
				animator.SetBool("walk",true);

				if(_currentDirection == "right")
				{
					GetComponent<Rigidbody>().velocity = (Vector2.right * 8);
				}else
				{
					GetComponent<Rigidbody>().velocity = (Vector2.left * 8);
				}

				nextPosition = new Vector3(transform.position.x, transform.position.y, seguir.transform.position.z);
				transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * 20);
			}
			//DISPARO
			if(shoot2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
			{
				shoot2 = false;

				caminar2 = false;
				animator.SetBool("walk",false);

				if(disparos2 >= 2)
				{
					disparos2 = 0;
					animator.SetInteger("recarga", Tipo);
				}else
				{
					disparos2 += 1;
					animator.SetInteger("disparo", Tipo);
				}
			}
			if(animator.GetCurrentAnimatorStateInfo(0).IsName("FusilShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("SubmetraShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("MetraShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("Granada") ||
				animator.GetCurrentAnimatorStateInfo(0).IsName("FusilRecarga") || animator.GetCurrentAnimatorStateInfo(0).IsName("GunRecarga") || animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunRecarga") || animator.GetCurrentAnimatorStateInfo(0).IsName("RecargaMetraySub"))
			{
				actuando2 = true;
			}else
			{
				actuando2 = false;
			}
		}
	}

	void FuncionesTanque()
	{
		actuando = true;
		random = Random.Range(3,6);
		movimientos();
		return;
	}
	void Funciones()
	{
		actuando = true;
		if(cubrirse)
		{
			random = Random.Range(6,10);
		}else
		{
			random = Random.Range(1,6);
		}
		movimientos();
		return;
	}
	void movimientos()
	{
		//RANDOM FUNCTIONS
		if(random == 1)
		{
			random = 0;
			camina();
		}else if(random == 2)
		{
			random = 0;
			disparar();
		}else if(random == 3)
		{
			random = 0;
			disparar();
		}else if(random == 4)
		{
			random = 0;
			if(Player.transform.position.z-3 > transform.position.z || Player.transform.position.z+3 < transform.position.z)
			{
				camina();
			}else
			{
				disparar();
			}
		}else if(random == 5)
		{
			random = 0;
			if(Player.transform.position.z-3 > transform.position.z || Player.transform.position.z+3 < transform.position.z)
			{
				camina();
			}else
			{
				disparar();
			}
		}else if(random == 6)
		{
			random = 0;
			disparar();
			//alejar();
		}else if(random == 7)
		{
			random = 0;
			if(cubrirse)
			{
				cover();
			}
		}else if(random == 8)
		{
			random = 0;
			if(cubrirse)
			{
				cover();
			}
		}else if(random == 9)
		{
			random = 0;
			disparar();
		}else if(random == 10)
		{
			random = 0;
			disparar();
		}
	}
	//MOVIMIENTOS DE PERSONAJE
	//CUBRIRSE
	void cover()
	{
		cubierto = true;
		animator.SetBool("cubrirse", true);
		StartCoroutine(esperacover());
	}
	//CAMINAR
	void camina()
	{
		dist = Random.Range(0.5f,1.5f);
		StartCoroutine(esperaCamina());
		caminar = true;
	}
	//ALEJARCE
	void alejar()
	{
		dist = Random.Range(2,4);
		StartCoroutine(esperaAleja());
		alejarce = true;
	}
	//DISPARO
	void disparar()
	{
		shoot = true;
	}
	//TIEMPOS DE ESPERA
	IEnumerator esperacover()
	{
		yield return new WaitForSeconds(4);
		animator.SetBool("cubierto", false);
		animator.SetBool("cubrirse", false);
		cubierto = false;
		actuando = false;
	}
	IEnumerator esperaAleja()
	{
		yield return new WaitForSeconds(dist);
		animator.SetBool("walk",false);
		alejarce = false;
		actuando = false;
	}
	IEnumerator esperaAleja2()
	{
		yield return new WaitForSeconds(dist2);
		animator.SetBool("walk",false);
		alejarce2 = false;
		actuando = false;
	}
	IEnumerator esperaCamina()
	{
		yield return new WaitForSeconds(dist);
		animator.SetBool("walk",false);
		caminar = false;
		actuando = false;
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
			salud -= 50;
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
		if(col.gameObject.tag == "pared" && vivo)
		{
			alejarce = false;
			animator.SetBool("walk", false);
		}
		if(col.gameObject.tag == "tank" && vivo)
		{
			salud -= 100;
		}
	}

	void OnCollisionStay (Collision col)
	{
		if(col.gameObject.tag == "pared" && vivo)
		{
			animator.SetBool("walk", false);
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "cobertura" && vivo)
		{
			animator.SetBool("walk",false);
			caminar = false;
			coverPosition = new Vector3(col.gameObject.transform.position.x, transform.position.y, col.gameObject.transform.position.z);
			cubrirse = true;
		}
		if(col.gameObject.tag == "balaLlamas" && vivo)
		{
			salud -= 10;
		}
		if(col.gameObject.tag == "Player" && vivo)
		{
			pelea = true;
			Player = col.gameObject.transform;
		}
		if(col.gameObject.tag == "tank" && vivo)
		{
			pelea = true;
			Player = col.gameObject.transform;
		}
	}
	void OnTriggerExit (Collider col)
	{
		if(col.gameObject.tag == "cobertura" && vivo)
		{
			cubrirse = false;
			cubierto = false;
		}
		if(col.gameObject.tag == "Player")
		{
			pelea = false;
		}
		if(col.gameObject.tag == "tank")
		{
			pelea = false;
		}
	}

	//APAGA LA LUZ
	IEnumerator apaga ()
	{
		yield return new WaitForSeconds(0.1f);
		luz.SetActive(false);
	}

	//EVENTOS SPINE
	void Shot ()
	{
		shoot = false;
		rafaga = false;
		luz.SetActive(true);
		StartCoroutine(apaga());
		var bullet = (GameObject)Instantiate(bulletPref, bulletSpawn.position, bulletSpawn.rotation); 
		if(_currentDirection == "right")
		{
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 10;
		}else
		{
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * -10;
		}
		Destroy(bullet, 5.0f);
		//CASQUILLO
		var casquillo = (GameObject)Instantiate(casquilloPref, casquilloSpawn.position, casquilloSpawn.rotation); 
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.right * Random.Range(-10,-50);//-50;
		casquillo.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-0.0f,-0.2f));
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.up * Random.Range(-1,-6);//-5;
	}
	void ShotA ()//FUSIL
	{
		luz.SetActive(true);
		StartCoroutine(apaga());
		var bullet = (GameObject)Instantiate(bulletPrefFusil, bulletSpawn.position, bulletSpawn.rotation); 
		if(_currentDirection == "right")
		{
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 10;
		}else
		{
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * -10;
		}
		Destroy(bullet, 5.0f);
		//CASQUILLOS}
		var casquillo = (GameObject)Instantiate(casquilloPref, casquilloSpawn.position, casquilloSpawn.rotation); 
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.right * Random.Range(-10,-50);//-50;
		casquillo.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-0.0f,-0.2f));
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.up * Random.Range(-1,-6);//-5;
	}
	void ShotB ()//ESCOPETA
	{
		luz.SetActive(true);
		StartCoroutine(apaga());
		if(_currentDirection == "right")
		{
			var bulletB = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,0,40)); 
			bulletB.GetComponent<Rigidbody>().velocity = bulletB.transform.right * 80;
			Destroy(bulletB, 0.1f);
			var bulletB2 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,0,20)); 
			bulletB2.GetComponent<Rigidbody>().velocity = bulletB2.transform.right * 80;
			Destroy(bulletB2, 0.1f);
			var bulletB4 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,0,-20)); 
			bulletB4.GetComponent<Rigidbody>().velocity = bulletB4.transform.right * 80;
			Destroy(bulletB4, 0.1f);
			var bulletB5 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,0,-40)); 
			bulletB5.GetComponent<Rigidbody>().velocity = bulletB5.transform.right * 80;
			Destroy(bulletB5, 0.1f);
		}else
		{
			var bulletB = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,180,40)); 
			bulletB.GetComponent<Rigidbody>().velocity = bulletB.transform.right * 80;
			Destroy(bulletB, 0.1f);
			var bulletB2 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,180,20)); 
			bulletB2.GetComponent<Rigidbody>().velocity = bulletB2.transform.right * 80;
			Destroy(bulletB2, 0.1f);
			var bulletB4 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,180,-20)); 
			bulletB4.GetComponent<Rigidbody>().velocity = bulletB4.transform.right * 80;
			Destroy(bulletB4, 0.1f);
			var bulletB5 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,180,-40)); 
			bulletB5.GetComponent<Rigidbody>().velocity = bulletB5.transform.right * 80;
			Destroy(bulletB5, 0.1f);
		}
		var bulletB3 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, bulletSpawn.rotation); 
		if(_currentDirection == "right")
		{
			bulletB3.GetComponent<Rigidbody>().velocity = bulletB3.transform.right * 100;
		}else
		{
			bulletB3.GetComponent<Rigidbody>().velocity = bulletB3.transform.right * -100;
		}
		Destroy(bulletB3, 0.1f);
		//CASQUILLOS}
		var casquillo = (GameObject)Instantiate(casquilloPref, casquilloSpawn.position, casquilloSpawn.rotation); 
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.right * Random.Range(-10,-50);//-50;
		casquillo.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-0.0f,-0.2f));
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.up * Random.Range(-1,-6);//-5;
	}
	void ShotC ()//SUBMETRA
	{
		luz.SetActive(true);
		StartCoroutine(apaga());
		var bullet = (GameObject)Instantiate(bulletPrefSubmetra, bulletSpawn.position, bulletSpawn.rotation); 
		if(_currentDirection == "right")
		{
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 10;
		}else
		{
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * -10;
		}
		Destroy(bullet, 5.0f);
		//CASQUILLOS}
		var casquillo = (GameObject)Instantiate(casquilloPref, casquilloSpawn.position, casquilloSpawn.rotation); 
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.right * Random.Range(-10,-50);//-50;
		casquillo.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-0.0f,-0.2f));
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.up * Random.Range(-1,-6);//-5;
	}
	void ShotD ()//METRA
	{
		luz.SetActive(true);
		StartCoroutine(apaga());
		var bullet = (GameObject)Instantiate(bulletPrefMetra, bulletSpawn.position, bulletSpawn.rotation); 
		if(_currentDirection == "right")
		{
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 10;
		}else
		{
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * -10;
		}
		Destroy(bullet, 5.0f);
		//CASQUILLOS}
		var casquillo = (GameObject)Instantiate(casquilloPref, casquilloSpawn.position, casquilloSpawn.rotation); 
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.right * Random.Range(-10,-50);//-50;
		casquillo.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-0.0f,-0.2f));
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.up * Random.Range(-1,-6);//-5;
	}
	void load2 ()
	{
		disparos = 0;
		actuando = false;
		shoot = false;
	}
	void granada ()
	{
		var granade = (GameObject)Instantiate(granadePref, bulletSpawn.position, bulletSpawn.rotation);
		granade.GetComponent<Rigidbody>().velocity = granade.transform.up * 20;
		if(_currentDirection == "right")
		{
			granade.GetComponent<Rigidbody>().AddForce(transform.right * 30);
		}else
		{
			granade.GetComponent<Rigidbody>().AddForce(transform.right * -30);
		}
	}
}
