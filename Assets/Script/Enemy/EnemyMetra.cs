using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMetra : MonoBehaviour {

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

	//float inicial;
	public Transform bulletSpawn;
	public GameObject bala1;
	public GameObject bala2;
	//CAMARA LENTA
	int matrix;
	bool matrix2;

	public GameObject textos;

	public GameObject mira;

	//MUERE CON EXPLOCION
	bool explocion;
	public GameObject Huesos;

	public GameObject[] sangreCuchillo;

	// Use this for initialization
	void Start ()
	{
		mira.SetActive(false);
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

				if(Vector3.Distance(transform.position,Player.position) >= 1)//5.1f) && Vector3.Distance(transform.position,Player.position) <= 30f)
				{
					animator.SetInteger("disparo", 1);
				}else if(Vector3.Distance(transform.position,Player.position) <= 5)// && ajusteZ.z != Player.transform.position.z)
				{
					Hero.cuchillo = true;
				}else
				{
					animator.SetInteger("disparo", -1);
				}
			}else
			{
				animator.SetInteger("disparo", -1);
			}
				
			if(salud <= 0)
			{
				if(explocion)
				{
					animator.SetInteger("muerte", 3);
					var bones = (GameObject)Instantiate(Huesos, transform.position, transform.rotation); 
				}else
				{
					int azar = Random.Range(1,3);
					animator.SetInteger("muerte", azar);
				}
				vivo = false;
			}
		}else
		{
			explocion = false;
			mira.SetActive(false);
			if(matrix == 1 && !matrix2 && Player.name == "Hero")
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
			animator.SetInteger("cascado", 4);
			efect = Random.Range(3,5);
			if(PlayerPrefs.GetInt("violencia") == 1)
			{
				var sangre2 = (GameObject)Instantiate(sangreCuchillo[Random.Range(0,sangreCuchillo.Length)], cascadoSpawn.position, cascadoSpawn.rotation); 
				var explo = (GameObject)Instantiate(efecto, cascadoSpawn.position, cascadoSpawn.rotation); 
			}
			salud -= 50;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "50";
		}
		if(col.gameObject.tag == "bala" && vivo)
		{
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 15;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "15";
		}
		if(col.gameObject.tag == "balaFusil" && vivo)
		{
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 40;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "40";
		}
		if(col.gameObject.tag == "balaEscopeta" && vivo)
		{
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 15;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "15";
		}
		if(col.gameObject.tag == "balaSubmetra" && vivo)
		{
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 20;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "20";
		}
		if(col.gameObject.tag == "balaMetra" && vivo)
		{
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 25;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "25";
		}
		if(col.gameObject.tag == "balaMG" && vivo)
		{
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 25;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "25";
		}
		if(col.gameObject.tag == "balaSniper" && vivo)
		{
			animator.SetInteger("cascado", 1);
			col.gameObject.SetActive(false);
			salud -= 100;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "100";
		}
		if(col.gameObject.tag == "explo" && vivo)
		{
			if(PlayerPrefs.GetInt("violencia") == 1)
			{
				explocion = true;
			}
			/*vivo = false;
			Instantiate(carne, cascadoSpawn.position, cascadoSpawn.rotation);
			GetComponent<Rigidbody>().AddForce(transform.right * Random.Range(500,-500));
			GetComponent<Rigidbody>().velocity = (Vector2.up * Random.Range(10,25));
			animator.SetInteger("muerte", 3);*/
			salud -= 50;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "50";
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

	//APAGA LA LUZ
	IEnumerator apaga ()
	{
		yield return new WaitForSeconds(0.1f);
		luz.SetActive(false);
	}

	//EVENTOS SPINE
	void mg1 ()
	{
		luz.SetActive(true);
		StartCoroutine(apaga());
		//var bullet = (GameObject)Instantiate(bala1, bulletSpawn.position, bulletSpawn.rotation); 
		if(transform.localScale.x == 1)
		{
			var bullet = (GameObject)Instantiate(bala1, bulletSpawn.position, Quaternion.Euler(0,0,0));//bulletSpawn.rotation); 
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
			Destroy(bullet, 5.0f);
		}else
		{
			var bullet = (GameObject)Instantiate(bala1, bulletSpawn.position, Quaternion.Euler(0,180,0));
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
			Destroy(bullet, 5.0f);
		}

		/*inicial = Player.transform.position.x;
		if(gameObject.transform.localScale.x >= 1)
		{
			Instantiate(bala1, new Vector3(inicial-10, transform.position.y, Player.transform.position.z), transform.rotation);//inicial+10
		}else
		{
			Instantiate(bala1, new Vector3(inicial+10, transform.position.y, Player.transform.position.z), transform.rotation);//inicial+10
		}*/
	}
	void mg2 ()
	{
		mg1();
		/*if(gameObject.transform.localScale.x >= 1)
		{
			Instantiate(bala2, new Vector3(inicial-8, transform.position.y, Player.transform.position.z), transform.rotation);//inicial+8
		}else
		{
			Instantiate(bala2, new Vector3(inicial+8, transform.position.y, Player.transform.position.z), transform.rotation);//inicial+8
		}*/
	}
	void mg3 ()
	{
		mg1();
		/*if(gameObject.transform.localScale.x >= 1)
		{
			Instantiate(bala1, new Vector3(inicial-6, transform.position.y, Player.transform.position.z), transform.rotation);//inicial+6
		}else
		{
			Instantiate(bala1, new Vector3(inicial+6, transform.position.y, Player.transform.position.z), transform.rotation);//inicial+6
		}*/
	}
	void mg4 ()
	{
		mg1();
		/*if(gameObject.transform.localScale.x >= 1)
		{
			Instantiate(bala2, new Vector3(inicial-4, transform.position.y, Player.transform.position.z), transform.rotation);//inicial+4
		}else
		{
			Instantiate(bala2, new Vector3(inicial+4, transform.position.y, Player.transform.position.z), transform.rotation);//inicial+4
		}*/
	}
	void mg5 ()
	{
		mg1();
		/*if(gameObject.transform.localScale.x >= 1)
		{
			Instantiate(bala1, new Vector3(inicial-2, transform.position.y, Player.transform.position.z), transform.rotation);//inicial+2
		}else
		{
			Instantiate(bala1, new Vector3(inicial+2, transform.position.y, Player.transform.position.z), transform.rotation);//inicial+2
		}*/
	}
	void mg6 ()
	{
		mg1();
		/*if(gameObject.transform.localScale.x >= 1)
		{
			Instantiate(bala2, new Vector3(inicial, transform.position.y, Player.transform.position.z), transform.rotation);//inicial
		}else
		{
			Instantiate(bala2, new Vector3(inicial, transform.position.y, Player.transform.position.z), transform.rotation);//inicial
		}*/
	}
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
}
