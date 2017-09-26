using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMortero : MonoBehaviour {

	public string enemyName;
	public string tankName;
	Transform Player;

	public string _currentDirection = "right";

	//GROUND CHECHER
	public Transform groundCheck;
	float groundRadius = 0.3f;
	public LayerMask whatIsGround;
	public bool grounded = false;

	//OBJETOS DE DISPARO
	public Transform bulletSpawn;
	public GameObject luz;

	public Transform cascadoSpawn;
	public GameObject efecto;
	public GameObject efecto2;
	public GameObject efecto3;
	public GameObject efecto4;
	int efect;
	public GameObject carne;
	public GameObject sangre;
	public GameObject polv;

	public Animator animator;
	int azar;

	bool vivo = true;
	public int salud = 100;

	public int disp;
	bool shoot;
	bool contar;

	public GameObject bala;
	//CAMARA LENTA
	int matrix;
	bool matrix2;

	public GameObject textos;

	public GameObject mira;

	// Use this for initialization
	void Start ()
	{
		matrix = Random.Range(1,6);
		//Player = GameObject.FindWithTag ("Player").transform;
		_currentDirection = "right";
	}
	
	// Update is called once per frame
	void Update ()
	{
		grounded = Physics.CheckSphere(groundCheck.position, groundRadius, whatIsGround);
		animator.SetBool("grounded", grounded);

		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
		{
			animator.SetInteger("cascado", 0);
		}
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("KillBackJump") || animator.GetCurrentAnimatorStateInfo(0).IsName("KillSimple") ||animator.GetCurrentAnimatorStateInfo(0).IsName("KillSimple2"))
		{
			animator.SetInteger("muerte", 0);
		}
		if(vivo)
		{
			if(Player != null)
			{
				//MIRA AL JUGADOR
				Vector3 v3Dir = Player.position - transform.position;
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
				//SI ESTA LEJOS
				if(Vector3.Distance(transform.position,Player.position) >= 2 && disp < 1)//8f && Vector3.Distance(transform.position,Player.position) <= 30f && disp < 1)
				{
					shoot = true;
				}
				//DEMACIADO CERCA LE PUEDEN DAR CUCHILLO
				if(Vector3.Distance(transform.position,Player.position) <= 5)// && ajusteZ.z != Player.transform.position.z)
				{
					Hero.cuchillo = true;
				}
			}

			//SHOT
			if(shoot)
			{
				animator.SetInteger("disparo", 1);
				shoot = false;
			}
			if(disp >= 4)
			{
				animator.SetInteger("disparo", 0);
				StartCoroutine(tiempo());
			}
			if(salud <= 0)
			{
				//animator.SetBool("muerto", true);
				azar = Random.Range(1,3);
				animator.SetInteger("muerte", azar);
				vivo = false;
			}
		}else
		{
			mira.SetActive(false);
			if(matrix == 1 && !matrix2 && Player.name == "Hero")
			{
				Manager.lenta = true;
			}
			gameObject.layer = LayerMask.NameToLayer("muerto");
			gameObject.tag = "Untagged";
		}
	}
	IEnumerator tiempo ()
	{
		yield return new WaitForSeconds(Random.Range(3,10));
		disp = 0;
	}
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "cuchillo" && vivo)
		{
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
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 15;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "15";
		}
		if(col.gameObject.tag == "balaFusil" && vivo)
		{
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 40;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "40";
		}
		if(col.gameObject.tag == "balaEscopeta" && vivo)
		{
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 15;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "15";
		}
		if(col.gameObject.tag == "balaSubmetra" && vivo)
		{
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 20;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "20";
		}
		if(col.gameObject.tag == "balaMetra" && vivo)
		{
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 25;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "25";
		}
		if(col.gameObject.tag == "balaMG" && vivo)
		{
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 25;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "25";
		}
		if(col.gameObject.tag == "balaSniper" && vivo)
		{
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
			GetComponent<Rigidbody>().AddForce(transform.right * Random.Range(500,-500));
			GetComponent<Rigidbody>().velocity = (Vector2.up * Random.Range(10,25));
			animator.SetInteger("muerte", 3);
			salud -= 20;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "20";
		}
		if(col.gameObject.tag == tankName && vivo)
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
	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "mira" && vivo)
		{
			mira.SetActive(true);
			mira.GetComponent<Animator>().SetBool("entry",true);
		}
		if(col.gameObject.tag == enemyName)
		{
			Player = col.gameObject.transform;
		}
		if(col.gameObject.tag == tankName)
		{
			Player = col.gameObject.transform;
		}
		if(col.gameObject.tag == "balaLlamas" && vivo)
		{
			salud -= 10;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), Quaternion.Euler(0,0,0));
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "10";
		}
	}
	void OnTriggerExit (Collider col)
	{
		if(col.gameObject.tag == "mira" && vivo)
		{
			mira.SetActive(false);
		}
		if(col.gameObject.tag == enemyName)
		{
			Player = null;
		}
		if(col.gameObject.tag == tankName)
		{
			Player = null;
		}
	}

	//EVENTOS SPINE
	void mortero()
	{
		disp += 1;
		Instantiate(bala, new Vector3(Player.transform.position.x+Random.Range(10,-10),Player.transform.position.y,Player.transform.position.z+Random.Range(10,-10)), transform.rotation);
	}
	//EVENTOS SPINE
	void blood ()
	{
		Instantiate(sangre, transform.position, transform.rotation);
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
	//6513900
	//Jueves 27 Julio 8am liliana peña 127 autonorte 20 minutos antes.
}
