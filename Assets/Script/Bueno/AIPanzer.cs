using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPanzer : MonoBehaviour {

	public bool pelea;

	public string BuscarBase;
	public string NameEnemy;
	public string NameEnemyTank;

	public Transform Player;

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

	public Transform bulletSpawn;
	public GameObject luz;

	int azar;

	public Transform cascadoSpawn;
	public GameObject efecto;
	public GameObject efecto2;
	public GameObject efecto3;
	public GameObject efecto4;
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

	//QUE TAN LEJOS DE LA BASE DISPARA
	float lejos;

	public GameObject textos;

	public GameObject mira;

	// Use this for initialization
	void Start ()
	{
		mira.SetActive(false);

		animator.SetBool("falling", true);

		matrix = Random.Range(1,6);
		_currentDirection = "right";

		lejos = Random.Range(25,31);
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
					animator.SetBool("falling", false);

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

					if(Player.tag != NameEnemyTank)
					{
						if(Mathf.Abs((transform.position - Player.position).x) >= 15.01f && !actuando && !alejarce && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
						{
							Funciones();
							actuando = true;
						}
						if(Mathf.Abs((transform.position - Player.position).x) <= 15 && !cubrirse && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
						{
							animator.SetBool("walk", true);
							caminar = false;
							shoot = false;
							alejarce2 = true;
							dist2 = Random.Range(2,4);
							StartCoroutine(esperaAleja2());
							actuando = true;
						}																															
					}else
					{
						if(Mathf.Abs((transform.position - Player.position).x) >= 25.01f && !shoot && !actuando && !alejarce && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
						{
							FuncionesTanque();
						}
						if(Mathf.Abs((transform.position - Player.position).x) <= 25 && !cubrirse && !alejarce2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
						{
							animator.SetBool("walk", true);
							caminar = false;
							shoot = false;
							alejarce2 = true;
							dist2 = Random.Range(3,6);
							StartCoroutine(esperaAleja2());
							actuando = true;
						}	
					}

					//ACCIONES UPDATE
					//ALEJARCE
					if(alejarce)
					{
						print("ALEJARCE");
						animator.SetBool("disparo", false);

						shoot = false;
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
						print("ALEJARCE 2");
						animator.SetBool("disparo", false);

						shoot = false;
						if(animator.GetCurrentAnimatorStateInfo(0).IsName("panzerwalk"))
						{
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
							transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * 10);
						}
					}else
					{
						dir = Random.Range(1,3);
					}
					//CAMINAR
					if(caminar)
					{
						print("CAMINAR");
						animator.SetBool("disparo", false);
						if(animator.GetCurrentAnimatorStateInfo(0).IsName("panzerwalk"))
						{
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
					}
					if(animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
					{
						actuando = false;
					}
					//DISPARO
					if(shoot && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
					{
						print("DISPARO");
						seguir.GetComponent<vista>().arriba = false;
						seguir.GetComponent<vista>().abajo = false;

						shoot = false;
						actuando = false;
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
				mira.SetActive(false);
				if(matrix == 1 && !matrix2 && Player.name == "Hero")
				{
					matrix2 = true;
					Manager.lenta = true;
				}
				gameObject.layer = LayerMask.NameToLayer("muerto");
				gameObject.tag = "Untagged";
			}
		}else
		{
			if(vivo)
			{
				if(grounded)
				{
					animator.SetBool("falling", false);
				}
				if(grounded && target == null)
				{
					target = GameObject.FindWithTag (BuscarBase).transform;
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

				if(grounded && target != null)
				{
					//SI ESTA MUY LEJOS
					if(Mathf.Abs((transform.position - target.position).x) >= lejos && !caminar2)
					{
						animator.SetBool("walk", true);
						animator.SetBool("walking", false);
						caminar2 = true;
					}
					if(Mathf.Abs((transform.position - target.position).x) <= lejos-0.1f && !actuando2)
					{
						shoot2 = true;
					}
				}
				if(caminar2)
				{
					print("CAMINANDO A BASE");
					animator.SetBool("walk", true);
					animator.SetBool("disparo", false);
					if(animator.GetCurrentAnimatorStateInfo(0).IsName("panzerwalk"))
					{
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
				}
				//DISPARO
				if(shoot2 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
				{
					caminar2 = false;
					animator.SetBool("walk", false);
					animator.SetBool("walking", false);

					if(disparos2 >= 1)
					{
						disparos2 = 0;
					}else
					{
						disparos2 += 1;
						animator.SetBool("disparo", true);
					}

					shoot2 = false;
				}
				if(animator.GetCurrentAnimatorStateInfo(0).IsName("panzerShot"))
				{
					actuando2 = true;
				}else
				{
					actuando2 = false;
				}
			}else
			{
				mira.SetActive(false);
				gameObject.layer = LayerMask.NameToLayer("muerto");
				gameObject.tag = "Untagged";
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
			disparar();
		}else if(random == 5)
		{
			random = 0;
			disparar();
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
		animator.SetBool("walk", true);
		animator.SetBool("walking", true);
		dist = Random.Range(0.5f,1.5f);
		StartCoroutine(esperaCamina());
		caminar = true;
	}
	//ALEJARCE
	void alejar()
	{
		animator.SetBool("walk", true);
		animator.SetBool("walking", true);
		dist = Random.Range(2,4);
		StartCoroutine(esperaAleja());
		alejarce = true;
	}
	//DISPARO
	void disparar()
	{
		animator.SetBool("disparo", true);
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
		animator.SetBool("walk", false);
		animator.SetBool("walking", false);
		alejarce = false;
		actuando = false;
	}
	IEnumerator esperaAleja2()
	{
		yield return new WaitForSeconds(dist2);
		animator.SetBool("walk", false);
		animator.SetBool("walking", false);
		alejarce2 = false;
		actuando = false;
	}
	IEnumerator esperaCamina()
	{
		yield return new WaitForSeconds(dist);
		animator.SetBool("walk", false);
		animator.SetBool("walking", false);
		caminar = false;
		actuando = false;
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "cuchillo" && vivo)
		{
			animator.SetBool("walk", false);
			animator.SetBool("walking", false);
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

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "50";
		}
		if(col.gameObject.tag == "bala" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk", false);
			animator.SetBool("walking", false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 15;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "15";
		}
		if(col.gameObject.tag == "balaFusil" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk", false);
			animator.SetBool("walking", false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 40;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "40";
		}
		if(col.gameObject.tag == "balaEscopeta" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk", false);
			animator.SetBool("walking", false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 15;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "15";
		}
		if(col.gameObject.tag == "balaSubmetra" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk", false);
			animator.SetBool("walking", false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 20;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "20";
		}
		if(col.gameObject.tag == "balaMetra" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk", false);
			animator.SetBool("walking", false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 25;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "25";
		}
		if(col.gameObject.tag == "balaMG" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk", false);
			animator.SetBool("walking", false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 25;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "25";
		}
		if(col.gameObject.tag == "balaSniper" && vivo)
		{
			//caminar = true;
			random = Random.Range(0,4);
			animator.SetBool("walk", false);
			animator.SetBool("walking", false);
			caminar = false;
			alejarce = false;
			animator.SetInteger("cascado", 1);
			col.gameObject.SetActive(false);
			salud -= 100;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "100";
		}
		if(col.gameObject.tag == "explo" && vivo)
		{
			vivo = false;
			Instantiate(carne, cascadoSpawn.position, cascadoSpawn.rotation);
			GetComponent<Rigidbody>().AddForce(transform.right * Random.Range(900,-900));
			GetComponent<Rigidbody>().velocity = (Vector2.up * Random.Range(20,35));
			animator.SetInteger("muerte", 3);
			salud -= 50;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "50";
		}
		if(col.gameObject.tag == "pared" && vivo)
		{
			alejarce = false;
			animator.SetBool("walk", false);
			animator.SetBool("walking", false);
		}
		if(col.gameObject.tag == NameEnemyTank && vivo)
		{
			print(col.gameObject.GetComponent<Rigidbody>().velocity.x);
			if(col.gameObject.GetComponent<Rigidbody>().velocity.x > 2.5f)
			{
				salud -= 100;

				var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
				letras.transform.parent = transform;
				letras.GetComponent<TextMesh>().text = "100";

				if(PlayerPrefs.GetInt("violencia") == 1)
				{
					efect = Random.Range(1,3);
					if(efect == 1)
					{
						var explo = (GameObject)Instantiate(efecto2, cascadoSpawn.position, cascadoSpawn.rotation);
					}else
					{
						var explo = (GameObject)Instantiate(efecto3, cascadoSpawn.position, cascadoSpawn.rotation);
					}
				}
			}
		}
	}

	void OnCollisionStay (Collision col)
	{
		if(col.gameObject.tag == "pared" && vivo)
		{
			animator.SetBool("walk", false);
			animator.SetBool("walking", false);
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "mira" && vivo)
		{
			mira.SetActive(true);
			mira.GetComponent<Animator>().SetBool("entry",true);
		}
		if(col.gameObject.tag == "cobertura" && vivo)
		{
			animator.SetBool("walk", false);
			animator.SetBool("walking", false);
			caminar = false;
			coverPosition = new Vector3(col.gameObject.transform.position.x, transform.position.y, col.gameObject.transform.position.z);
			cubrirse = true;
		}
		if(col.gameObject.tag == "balaLlamas" && vivo)
		{
			salud -= 10;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "10";
		}
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
		if(col.gameObject.tag == "mira" && vivo)
		{
			mira.SetActive(false);
		}
		if(col.gameObject.tag == "cobertura" && vivo)
		{
			cubrirse = false;
			cubierto = false;
		}
		if(col.gameObject.tag == NameEnemy)
		{
			pelea = false;
		}
		if(col.gameObject.tag == NameEnemyTank)
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
	public void cancel ()
	{
		shoot = false;
		actuando = false;
	}
	public void muerto ()
	{
		Destroy(gameObject);
	}
	void rocket ()
	{
		luz.SetActive(true);
		StartCoroutine(apaga());

		var granade = (GameObject)Instantiate(bulletPref, bulletSpawn.position, bulletSpawn.rotation);
		granade.GetComponent<Rigidbody>().velocity = (Vector2.up * Random.Range(20,30));

		if(gameObject.transform.localScale.x >= 1)
		{
			granade.GetComponent<Rigidbody>().AddForce(transform.right * Random.Range(35,66));
		}else
		{
			granade.GetComponent<Rigidbody>().AddForce(transform.right * Random.Range(-35,-66));
		}

		shoot = false;
		actuando = false;
	}
}
