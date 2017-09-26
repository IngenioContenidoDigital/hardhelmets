using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityStandardAssets.CinematicEffects;
using Com.LuisPedroFonseca.ProCamera2D;

public class Hero : MonoBehaviour {

	GameObject[] Enemy;

	public GameObject textos;

	public float salud;
	public float saludMax;
	public bool saludSumar;

	public static string _currentDirection = "right";

	public static int maxspeed;
	//AMBIENTES
	public static bool water;

	//GROUND CHECHER
	public Transform groundCheck;
	float groundRadius = 0.3f;
	public LayerMask whatIsGround;
	public bool grounded = false;
	//Physics hitColliders;

	public Animator animator;

	//Texturas Normal
	public GameObject Girar;
	public GameObject Girar2;

	//ACCIONES DE PERSONAJE
	Vector3 v3;
	bool caminarI = false;
	bool caminarD = false;
	bool caminarU = false;
	bool caminarA = false;
	public static bool cubrirse = false;
	bool agachado;
	public Vector3 coverPosition;
	bool cubierto = false;
	public float velocidad;

	bool shoot;

	//ARMAS
	public static string arma;
	public static bool arma2;
	//LANSA LLAMAS
	public static bool llamas;
	public static bool lansallamas;
	//OBJETOS DE DISPARO
	public GameObject bulletPref;
	public GameObject bulletPrefFusil;
	public GameObject bulletPrefEscopeta;
	public GameObject bulletPrefSubmetra;
	public GameObject bulletPrefMetra;
	public GameObject bulletPrefLlamas;
	public GameObject bulletPrefSniper;
	public GameObject PartLlamas;
	//DONDE APARECEN
	public Transform bulletSpawn;
	public Transform FlameSpawn;
	public Transform granadaSpawn;
	public GameObject casquilloPref;
	public GameObject casquilloPrefB;
	public Transform casquilloSpawn;
	public GameObject granadePref;
	public GameObject luz;
	//BALAS POR PISTOLA
	public static bool rafaga = true;
	bool Gready = true;
	public static int balaPistola = 12;
	public static int balaEscopeta = 6;
	public static int balaFusil = 5;
	public static int balaSubmetra = 30;
	public static int balaMetra = 32;
	public static int balaLlamas = 100;
	public static int balaSniper = 1;
	public static int balas;//arma activa}
	public static int granadas;
	public static bool load = false;
	bool autoload = false;
	public static bool cargando = false;
	//BALAS TOTALES
	//public static int PistolaTotales = 1;
	public static int EscopetaTotales = 1;
	public static int FusilTotales = 1;
	public static int SubmetraTotales = 1;
	public static int MetraTotales = 1;
	public static int LlamasTotales = 1; //800
	public static int SniperTotales = 1; //5
	public static int balasTotales;//arma activa}

	//DISTANCIA
	public static bool cuchillo;
	//MUERTES
	bool vivo = true;
	int muerte;

	//SNIPER
	public static bool sniper;
	bool sniperListo;
	public GameObject SniperTexture;
	public GameObject SniperCam;

	public UnityEngine.UI.Image Health;
	//MOUSE CAMERA POSITION
	Vector3 point;

	//EFECTO DISPARO
	bool efectodisparo;
	bool efectodisparosumar;

	// Use this for initialization
	void Start ()
	{
		muerte = Random.Range(1,3);
		_currentDirection = "right";
	}
	
	// Update is called once per frame
	void Update ()
	{
		//BARRA DE SANGRE
		Health.fillAmount = salud/saludMax;

		if(salud >= saludMax)
		{
			salud = saludMax;
			saludSumar = false;
		}

		if(salud <= saludMax*50/100)
		{
			if(PlayerPrefs.GetInt("violencia") == 1)
			{
				print("Violento");
				SniperCam.GetComponent<BleedBehavior>().EdgeSharpness = 0.8f;
				SniperCam.GetComponent<BleedBehavior>().minAlpha = 0.6f+0-salud/100;//0.2
			}
			Health.color = new Color32(255,0,0,255);
		}else
		{
			SniperCam.GetComponent<BleedBehavior>().minAlpha = 0;
			SniperCam.GetComponent<BleedBehavior>().EdgeSharpness = 3;
			Health.color = new Color32(0,255,0,255);
		}

		// EFECTO DIPARO
		if(efectodisparo)
		{
			SniperCam.GetComponent<LensAberrations>().chromaticAberration.amount -= 8;
			if(SniperCam.GetComponent<LensAberrations>().chromaticAberration.amount <= -20)
			{
				efectodisparosumar = true;
				efectodisparo = false;
			}
		}else if(efectodisparosumar)
		{
			SniperCam.GetComponent<LensAberrations>().chromaticAberration.amount += 8;
			if(SniperCam.GetComponent<LensAberrations>().chromaticAberration.amount >= 0)
			{
				SniperCam.GetComponent<LensAberrations>().chromaticAberration.amount = 0;
				efectodisparosumar = false;
				efectodisparo = false;
			}
		}else
		{
			SniperCam.GetComponent<LensAberrations>().chromaticAberration.amount = 0;
		}

		point = Camera.main.ScreenToViewportPoint(Input.mousePosition);//POSICION DEL MOUSE EN LA CAMARA EMPIEZA ESQUINA INFERIOR IZQUIERDA

		grounded = Physics.CheckSphere(groundCheck.position, groundRadius, whatIsGround);
		animator.SetBool("grounded", grounded);

		if(vivo)
		{
			if(saludSumar)
			{
				salud += 1;
			}

			Enemy = GameObject.FindGameObjectsWithTag("enemy");

			foreach(GameObject malo in Enemy)
			{
				if(Vector3.Distance(transform.position, malo.transform.position) <= 5)
				{
					cuchillo = true;
				}else if (cuchillo && Vector3.Distance(transform.position, malo.transform.position) >= 5.1f && Vector3.Distance(transform.position, malo.transform.position) <= 5.2)
				{
					cuchillo = false;
				}
			}

			if(grounded && !cargando && !animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasShot") && !animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasrecarga"))
			{
				//SALTO
				if(Input.GetButtonDown("Jump") && !animator.GetBool("cuchillando") && !lansallamas && !sniperListo && !agachado && !cubierto && !animator.GetCurrentAnimatorStateInfo(0).IsName("cae") && !caminarA && !caminarU && !caminarD && !caminarI)
				{
					GetComponent<Rigidbody>().AddForce (Vector2.up * 1000);//1500
					animator.SetBool("jump", true);
				}
				//CAMINAR
				//IZQUIERDA
				if(Input.GetButtonDown("left") && !sniperListo && !agachado && !animator.GetCurrentAnimatorStateInfo(0).IsName("backJump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("cae"))
				{
					if(_currentDirection == "right")
					{
						changeDirection ("left");
						v3 = Vector3.zero;
						caminarD = false;
					}
					if(caminarD && v3 != Vector3.zero)
					{
						v3 = Vector3.zero;
						caminarD = false;
					}
					//caminarD = false;
					//caminarU = false;
					//caminarA = false;
					caminarI = true;
				}else if(Input.GetButtonDown("left") && !sniperListo && agachado)
				{
					if(_currentDirection == "right")
					{
						animator.SetBool("jumpback", true);
						animator.SetBool("movimiento", true);
						animator.SetBool("grounded", false);
						GetComponent<Rigidbody>().AddForce (Vector2.up * 900);
						GetComponent<Rigidbody>().AddForce (Vector2.left * 900);
					}
					agachado = false;
				}
				//DERECHA
				if(Input.GetButtonDown("right") && !sniperListo && !agachado && !animator.GetCurrentAnimatorStateInfo(0).IsName("backJump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("cae"))
				{
					if(_currentDirection == "left")
					{
						changeDirection ("right");
						v3 = Vector3.zero;
						caminarI = false;
					}
					if(caminarI && v3 != Vector3.zero)
					{
						v3 = Vector3.zero;
						caminarI = false;
					}
					//caminarI = false;
					//caminarA = false;
					//caminarU = false;
					caminarD = true;
				}else if(Input.GetButtonDown("right") && !sniperListo && agachado)
				{
					if(_currentDirection == "right")
					{
						
					}else
					{
						animator.SetBool("jumpback", true);
						animator.SetBool("movimiento", true);
						animator.SetBool("grounded", false);
						GetComponent<Rigidbody>().AddForce (Vector2.up * 900);
						GetComponent<Rigidbody>().AddForce (Vector2.right * 900);
					}
					agachado = false;
				}

				//ARRIBA
				if(Input.GetButtonDown("up") && !sniperListo && !agachado  && !animator.GetCurrentAnimatorStateInfo(0).IsName("backJump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("cae"))
				{
					//caminarA = false;
					//caminarI = false;
					//caminarD = false;
					if(caminarA && v3 != Vector3.zero)
					{
						v3 = Vector3.zero;
						caminarA = false;
					}
					caminarU = true;
				}
				//ABAJO
				if(Input.GetButtonDown("down") && !sniperListo && !agachado  && !animator.GetCurrentAnimatorStateInfo(0).IsName("backJump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("cae"))
				{
					//caminarU = false;
					//caminarD = false;
					//caminarI = false;
					if(caminarU && v3 != Vector3.zero)
					{
						v3 = Vector3.zero;
						caminarU = false;
					}
					caminarA = true;
				}
				//CUBRIRSE
				if(cubrirse && !sniperListo)
				{
					if(Input.GetButtonDown("USAR"))
					{
						agachado = false;
						animator.SetBool("cubrirse", true);
						cubierto = true;
					}
				}
				if(cubierto)
				{
					transform.position = Vector3.Lerp(transform.position, coverPosition, Time.deltaTime * 5);
					StartCoroutine(coverTiempo());
				}
				if(animator.GetCurrentAnimatorStateInfo(0).IsName("Agachado"))
				{
					gameObject.layer = LayerMask.NameToLayer("PlayerAgachado");
				}else if(vivo)
				{
					gameObject.layer = LayerMask.NameToLayer("Player");
				}
				if(Input.GetButtonDown("USAR") && !sniperListo && !cubrirse)
				{
					animator.SetBool("cubrirse", true);
					agachado = true;
				}

				//DISPARO
				if(shoot && rafaga)
				{
					rafaga = false;
					disparo();
				}

				if(Input.GetButtonDown("DISPARO") && point.y > 0.14f && rafaga && !animator.GetCurrentAnimatorStateInfo(0).IsName("cae"))
				{
					agachado = false;
					cubierto = false;
					if(animator.GetBool("cuchillando"))
					{
						animator.SetBool("cuchillo2", true);
					}else if(cuchillo)
					{
						animator.SetBool("cuchillo", true);
						caminarA = false;
						caminarD = false;
						caminarI = false;
						caminarU = false;
						cuchillo = false;
					}else if(sniperListo)
					{
						disparoSniper();
					}else
					{
						//animator.SetBool("cuchillo", true);
						shoot = true;
					}
				}
				if(Input.GetButtonDown("RECARGA") && !animator.GetBool("cuchillando") && !animator.GetCurrentAnimatorStateInfo(0).IsName("backJump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("cae") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
				{
					rafaga = true;
					autoload = true;
					if(arma2)
					{
						animator.SetInteger("recarga", 5);
					}
					if(lansallamas)
					{
						animator.SetInteger("recarga", 12);
					}
					if(!arma2 && !lansallamas)
					{
						if(arma == "escopeta")
						{
							animator.SetInteger("recarga", 1);
						}
						if(arma == "fusil")
						{
							animator.SetInteger("recarga", 2);
						}
						if(arma == "submetra")
						{
							animator.SetInteger("recarga", 3);
						}
						if(arma == "metra")
						{
							animator.SetInteger("recarga", 3);
						}
					}
				}

				if(Input.GetButtonDown("APUNTAR") && sniper && !animator.GetCurrentAnimatorStateInfo(0).IsName("cae"))
				{
					rafaga = true;
					cuchillo = false;
					sniperListo = true;

					Cam.sniper = true;

					SniperTexture.SetActive(true);
					SniperCam.GetComponent<LensAberrations>().distortion.enabled = true;
					animator.SetInteger("disparo",20);
				}

				if(Input.GetButtonDown("GRANADA") && granadas >= 1 && !sniperListo && Gready && !animator.GetBool("cuchillando") && !animator.GetCurrentAnimatorStateInfo(0).IsName("backJump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("cae"))
				{
					granadas -= 1;
					Gready = false;
					agachado = false;
					animator.SetInteger("disparo", 6);
					StartCoroutine(esperaG());
				}
					
				if(caminarI && !sniperListo && !cargando && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
				{
					caminarD = false;
					animator.SetBool("walk", true);
					velocidad += 1f;
					if(velocidad >= maxspeed)
					{
						velocidad = maxspeed;
					}
					v3 += Vector3.left;
					//GetComponent<Rigidbody>().velocity = (Vector2.left * velocidad);//13
				}
				if(caminarD && !sniperListo && !cargando && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
				{
					caminarI = false;
					animator.SetBool("walk", true);
					velocidad += 1f;
					if(velocidad >= maxspeed)
					{
						velocidad = maxspeed;
					}
					v3 += Vector3.right;
					//GetComponent<Rigidbody>().velocity = (Vector2.right * velocidad);//13
				}
				if(caminarU && !sniperListo && !cargando && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
				{
					caminarA = false;
					animator.SetBool("walk", true);
					velocidad += 1f;
					if(velocidad >= maxspeed)
					{
						velocidad = maxspeed;
					}
					v3 += Vector3.forward;
					//GetComponent<Rigidbody>().velocity = (Vector3.forward * velocidad);//10
				}
				if(caminarA && !sniperListo && !cargando && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
				{
					caminarU = false;
					animator.SetBool("walk", true);
					velocidad += 1f;
					if(velocidad >= maxspeed)
					{
						velocidad = maxspeed;
					}
					v3 += Vector3.back;
					//GetComponent<Rigidbody>().velocity = (Vector3.back * velocidad);//10
				}
				if(v3 != Vector3.zero)
				{
					GetComponent<Rigidbody>().velocity = (velocidad * v3.normalized);
					//transform.Translate(velocidad * v3.normalized * Time.deltaTime);  
				}

			}else if(!cargando && !sniperListo)//DISPARO EN EL AIRE
			{
				if(Input.GetButtonDown("up"))
				{
					caminarU = true;
				}
				if(Input.GetButtonDown("down"))
				{
					caminarA = true;
				}
				if(Input.GetButtonDown("DISPARO") && rafaga)
				{
					rafaga = false;
					//ARRIBA
					if(caminarU)
					{
						if(arma2 && balaPistola >= 1)
						{
							StartCoroutine(resetArma());
							animator.SetInteger("disparo", 9);
							StartCoroutine(esperaPistolaAire());
						}else if(!arma2)
						{
							if(arma == "escopeta" && balaEscopeta >= 1)
							{
								animator.SetInteger("disparo", 9);
								StartCoroutine(esperaEscopeta());
							}
							if(arma == "fusil" && balaFusil >= 1)
							{
								animator.SetInteger("disparo", 9);
								StartCoroutine(esperaFusil());
							}
							if(arma == "submetra" && balaSubmetra >= 1)
							{
								animator.SetInteger("disparo", 9);
								StartCoroutine(esperaSubmetra());
							}
							if(arma == "metra" && balaMetra >= 1)
							{
								animator.SetInteger("disparo", 9);
								StartCoroutine(esperaMetra());
							}
						}
					}else if(caminarA)
					{
						if(arma2 && balaPistola >= 1)
						{
							StartCoroutine(resetArma());
							animator.SetInteger("disparo", 10);
							StartCoroutine(esperaPistolaAire());
						}else if(!arma2)
						{
							if(arma == "escopeta" && balaEscopeta >= 1)
							{
								animator.SetInteger("disparo", 10);
								StartCoroutine(esperaEscopeta());
							}
							if(arma == "fusil" && balaFusil >= 1)
							{
								animator.SetInteger("disparo", 10);
								StartCoroutine(esperaFusil());
							}
							if(arma == "submetra" && balaSubmetra >= 1)
							{
								animator.SetInteger("disparo", 10);
								StartCoroutine(esperaSubmetra());
							}
							if(arma == "metra" && balaMetra >= 1)
							{
								animator.SetInteger("disparo", 10);
								StartCoroutine(esperaMetra());
							}
						}
					}else if(!animator.GetCurrentAnimatorStateInfo(0).IsName("backJump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("cae"))
					{
						if(arma2 && balaPistola >= 1)
						{
							StartCoroutine(resetArma());
							animator.SetInteger("disparo", 8);
							StartCoroutine(esperaPistolaAire());
						}else
						{
							if(arma == "escopeta" && balaEscopeta >= 1)
							{
								animator.SetInteger("disparo", 8);
								StartCoroutine(esperaEscopeta());
							}
							if(arma == "fusil" && balaFusil >= 1)
							{
								animator.SetInteger("disparo", 8);
								StartCoroutine(esperaFusil());
							}
							if(arma == "submetra" && balaSubmetra >= 1)
							{
								animator.SetInteger("disparo", 8);
								StartCoroutine(esperaSubmetra());
							}
							if(arma == "metra" && balaMetra >= 1)
							{
								animator.SetInteger("disparo", 8);
								StartCoroutine(esperaMetra());
							}
						}
					}else
					{
						if(arma2 && balaPistola >= 1)
						{
							StartCoroutine(resetArma());
							animator.SetInteger("disparo", 11);
							StartCoroutine(esperaPistolaAire());
						}else
						{
							if(arma == "escopeta" && balaEscopeta >= 1)
							{
								animator.SetInteger("disparo", 11);
								StartCoroutine(esperaEscopeta());
							}
							if(arma == "fusil" && balaFusil >= 1)
							{
								animator.SetInteger("disparo", 11);
								StartCoroutine(esperaFusil());
							}
							if(arma == "submetra" && balaSubmetra >= 1)
							{
								animator.SetInteger("disparo", 11);
								StartCoroutine(esperaSubmetra());
							}
							if(arma == "metra" && balaMetra >= 1)
							{
								animator.SetInteger("disparo", 11);
								StartCoroutine(esperaMetra());
							}
						}
					}
				}
			}
			//DISPARO LLAMAS
			if(llamas)
			{
				PartLlamas.transform.parent = FlameSpawn.transform;

				if(_currentDirection == "right")
				{
					PartLlamas.transform.localPosition = new Vector3(1.8f, 0, 0);
					PartLlamas.transform.localRotation = Quaternion.Euler (0, 90, 0);
				}else
				{
					PartLlamas.transform.localPosition = new Vector3(1.8f, 0, 0);
					//PartLlamas.transform.Rotate (0, -180, 0);
					PartLlamas.transform.localRotation = Quaternion.Euler (0, 90, 0);
				}
				if(balaLlamas >= 1)
				{
					PartLlamas.GetComponent<ParticleSystem>().Play();
					var bulletB = (GameObject)Instantiate(bulletPrefLlamas, bulletSpawn.position, bulletSpawn.rotation); 
					bulletB.GetComponent<Rigidbody>().velocity = bulletB.transform.right * 10;
					Destroy(bulletB, 1.35f);
					balaLlamas -= 1;
				}else
				{
					rafaga = true;
					llamas = false;
				}
			}else
			{

				PartLlamas.GetComponent<ParticleSystem>().Stop();
				PartLlamas.transform.parent = null;
			}

			if(Input.GetButtonUp("DISPARO"))
			{
				shoot = false;
				animator.SetBool("llamas", false);
				llamas= false;
				//rafaga = true;
			}
			if(Input.GetButtonUp("APUNTAR"))
			{
				animator.SetInteger("disparo", -2);

				sniperListo = false;

				SniperCam.GetComponent<ProCamera2DForwardFocus>().RightFocus = 0.001f;
				SniperCam.GetComponent<ProCamera2DSpeedBasedZoom>().MaxZoomInAmount = 1.4f;
				SniperCam.GetComponent<ProCamera2DSpeedBasedZoom>().MaxZoomOutAmount = 1;
				Cam.sniper = false;

				SniperTexture.SetActive(false);
				SniperCam.GetComponent<LensAberrations>().distortion.enabled = false;
			}
			if(Input.GetButtonUp("left"))
			{
				if(!caminarD  && !caminarU && !caminarA)
				{
					velocidad = 0;
					animator.SetBool("walking", false);
					animator.SetBool("walk", false);
				}
				v3 = Vector3.zero;
				caminarI = false;
			}
			if(Input.GetButtonUp("right"))
			{
				if(!caminarI && !caminarU && !caminarA)
				{
					velocidad = 0;
					animator.SetBool("walking", false);
					animator.SetBool("walk", false);
				}
				v3 = Vector3.zero;
				caminarD = false;
			}
			if(Input.GetButtonUp("up"))
			{
				if(!caminarA && !caminarI && !caminarD)
				{
					velocidad = 0;
					animator.SetBool("walking", false);
					animator.SetBool("walk", false);
				}
				v3 = Vector3.zero;
				caminarU = false;
			}
			if(Input.GetButtonUp("down"))
			{
				if(!caminarU && !caminarI && !caminarD)
				{
					velocidad = 0;
					animator.SetBool("walking", false);
					animator.SetBool("walk", false);
				}
				v3 = Vector3.zero;
				caminarA = false;
			}
			if(Input.GetButtonUp("USAR"))
			{
				animator.SetBool("cubrirse", false);
				animator.SetBool("cubierto", false);
				agachado = false;
			}
			//FALLING
			if(GetComponent<Rigidbody>().velocity.y < -4f && !animator.GetCurrentAnimatorStateInfo(0).IsName("cae") && !animator.GetCurrentAnimatorStateInfo(0).IsName("backJump"))
			{
				animator.SetBool("falling", true);
			}else
			{
				animator.SetBool("falling", false);
			}

			if(arma2)
			{
				animator.SetBool("pistola", true);
				balas = balaPistola;
				//balasTotales = 0;
			}else
			{
				animator.SetBool("pistolando", false);
				animator.SetBool("pistola", false);
			}
			if(lansallamas)
			{
				animator.SetBool("flamas", true);
			}else
			{
				animator.SetBool("flamas", false);
			}
			if(arma == "escopeta" && !arma2)
			{
				balas = balaEscopeta;
				balasTotales = EscopetaTotales;
			}
			if(arma == "fusil" && !arma2)
			{
				balas = balaFusil;
				balasTotales = FusilTotales;
			}
			if(arma == "submetra" && !arma2)
			{
				balas = balaSubmetra;
				balasTotales = SubmetraTotales;
			}
			if(arma == "metra" && !arma2)
			{
				balas = balaMetra;
				balasTotales = MetraTotales;
			}
			if(arma == "lansallamas" && !arma2)
			{
				balas = balaLlamas;
				balasTotales = LlamasTotales;
			}
			if(arma == "sniper" && !arma2)
			{
				balas = balaSniper;
				balasTotales = SniperTotales;
			}
			//RECARGA
			if(load)
			{
				int totales;
				rafaga = true;
				load = false;
				if(autoload)
				{
					if(arma2)//animator = 5
					{
						balaPistola = 12;
					}else
					{
						if(arma == "escopeta")//animator = 1
						{
							totales = 6-balaEscopeta;

							EscopetaTotales -= totales;
							balaEscopeta = 6;
						}
						if(arma == "fusil")//animator = 2
						{
							totales = 5-balaFusil;

							FusilTotales -= totales;
							balaFusil += 5;
						}
						if(arma == "submetra")//animator = 3
						{
							totales = 30-balaSubmetra;

							SubmetraTotales -= totales;
							balaSubmetra = 30;
						}
						if(arma == "metra")//animator = 4
						{
							totales = 60-balaMetra;

							MetraTotales -= totales;
							balaMetra = 60;
						}
						if(arma == "lansallamas")
						{
							totales = 100-balaLlamas;

							LlamasTotales -= totales;
							balaLlamas = 100;
						}
					}
					autoload = false;
				}else
				{
					if(arma2)//animator = 5
					{
						balaPistola = 12;
					}
					if(!arma2)
					{
						if(arma == "escopeta" && EscopetaTotales >= 6)//animator = 1
						{
							balaEscopeta = 6;
							EscopetaTotales -= 6;
						}else if(EscopetaTotales < 6)
						{
							balaEscopeta = EscopetaTotales;
							EscopetaTotales -= EscopetaTotales;
						}
						if(arma == "fusil" && FusilTotales >= 5)//animator = 2
						{
							balaFusil += 5;
							FusilTotales -= 5;
						}else if(FusilTotales < 5)
						{
							balaFusil = FusilTotales;
							FusilTotales -= FusilTotales;
						}
						if(arma == "submetra" && SubmetraTotales >= 30)//animator = 3
						{
							balaSubmetra = 30;
							SubmetraTotales -= 30;
						}else if(SubmetraTotales < 30)
						{
							balaSubmetra = SubmetraTotales;
							SubmetraTotales -= SubmetraTotales;
						}
						if(arma == "metra" && MetraTotales >= 60)//animator = 4
						{
							balaMetra = 60;
							MetraTotales -= 60;
						}else if(MetraTotales < 60 && MetraTotales > 0)
						{
							balaMetra = MetraTotales;
							MetraTotales -= MetraTotales;
						}
						if(arma == "lansallamas" && LlamasTotales >= 100)
						{
							balaLlamas = 100;
							LlamasTotales -= 100;
						}else if(LlamasTotales < 100 && LlamasTotales > 0)
						{
							balaLlamas = LlamasTotales;
							LlamasTotales -= LlamasTotales;
						}
						if(arma == "sniper" && SniperTotales >= 1)
						{
							balaSniper = 1;
							SniperTotales -= 1;
						}
					}
				}
			}
			//BALAS NO PUEDE SER MENOS DE CERO
			if(balaPistola < 0)
			{
				balaPistola = 0;
			}
			if(balaFusil < 0)
			{
				balaFusil = 0;
			}
			if(balaEscopeta < 0)
			{
				balaEscopeta = 0;
			}
			if(balaSubmetra < 0)
			{
				balaSubmetra = 0;
			}
			if(balaMetra < 0)
			{
				balaMetra = 0;
			}
			if(balaLlamas < 0)
			{
				balaLlamas = 0;
			}
			if(balaSniper < 0)
			{
				balaSniper = 0;
			}
			//BALAS MAXIMAS POR ARMA
			if(balaPistola >= 12)
			{
				balaPistola = 12;
			}
			if(balaFusil >= 5)
			{
				balaFusil = 5;
			}
			if(balaEscopeta >= 6)
			{
				balaEscopeta = 6;
			}
			if(balaSubmetra >= 30)
			{
				balaSubmetra = 30;
			}
			if(balaMetra >= 32)
			{
				balaMetra = 32;
			}
			if(balaLlamas >= 100)
			{
				balaLlamas = 100;
			}
			if(balaSniper >= 5)
			{
				balaSniper = 5;
			}
			//BALAS MAXIMAS TOTALES POR ARMA
			if(EscopetaTotales >= 48)
			{
				EscopetaTotales = 48;
			}
			if(FusilTotales >= 40)
			{
				FusilTotales = 40;
			}
			if(SubmetraTotales >= 120)
			{
				SubmetraTotales = 120;
			}
			if(MetraTotales >= 180)
			{
				MetraTotales = 180;
			}
			if(LlamasTotales >= 800)
			{
				LlamasTotales = 800;
			}
			if(SniperTotales >= 5)
			{
				SniperTotales = 5;
			}
			//SI SE MUERE
			if(salud <= 0)
			{
				animator.SetBool("muerto", true);
				muerte = Random.Range(1,3);
				animator.SetInteger("muerte", muerte);
				vivo = false;
				StartCoroutine(muertee());
			}
			//SI ESTA EN SNIPER
			if(sniperListo)
			{
				cuchillo = false;
				caminarA = false;
				caminarD = false;
				caminarI = false;
				caminarU = false;
			}
		}else
		{
			gameObject.layer = LayerMask.NameToLayer("muerto");
			//gameObject.tag = "Untagged";
		}
	}
	void disparoSniper()
	{
		ProCamera2DShake.Instance.Shake();
		animator.SetInteger("disparo",2);
		if(balaSniper > 0)
		{
			bulletPrefSniper.SetActive(true);
			balaSniper -= 1;
			sonidoSpiper();
		}
		sniperListo = false;

		//SniperCam.GetComponent<ProCamera2D>().enabled = true;
		//Cam.sniper = false;
		//SniperTexture.SetActive(false);
		//SniperCam.GetComponent<LensAberrations>().distortion.enabled = false;

		if(SniperTotales > 0)
		{
			animator.SetInteger("recarga", 2);
		}
		StartCoroutine(esperaSniper());
	}
	void disparo()
	{
		//shoot = false;
		if(arma2)
		{
			if(balaPistola >= 1)
			{
				StartCoroutine(resetArma());
				animator.SetInteger("disparo", 5);
				StartCoroutine(esperaPistola());
			}else if(balaPistola <= 0)
			{
				rafaga = true;
				animator.SetInteger("recarga", -1);
			}
		}
		if(lansallamas)
		{
			if(balaLlamas >= 1)
			{
				Llamas.sonar = true;
				llamas = true;
				animator.SetBool("llamas", true);
			}else if(balaLlamas <= 0)
			{
				rafaga = true;
				animator.SetInteger("recarga", 12);
			}
		}
		if(!arma2 && !lansallamas)
		{
			if(arma == "escopeta" && balaEscopeta >= 1)
			{
				animator.SetInteger("disparo", 1);
				StartCoroutine(esperaEscopeta());
			}else if(arma == "escopeta" && balaEscopeta == 0 && EscopetaTotales >= 1)
			{
				animator.SetInteger("recarga", 1);
			}else if(arma == "escopeta" && EscopetaTotales == 0)
			{
				rafaga = true;
			}
			if(arma == "fusil" && balaFusil >= 1)
			{
				animator.SetInteger("disparo", 2);
				StartCoroutine(esperaFusil());
			}else if(arma == "fusil" && balaFusil == 0 && FusilTotales >= 1)
			{
				animator.SetInteger("recarga", 2);
			}else if(arma == "fusil" && balaFusil == 0 && FusilTotales == 0)
			{
				rafaga = true;
			}
			if(arma == "submetra" && balaSubmetra >= 1)
			{
				animator.SetInteger("disparo", 3);
				StartCoroutine(esperaSubmetra());
			}else if(arma == "submetra" && balaSubmetra == 0 && SubmetraTotales >= 1)
			{
				animator.SetInteger("recarga", 3);
			}else if(arma == "submetra" && SubmetraTotales == 0)
			{
				rafaga = true;
			}
			if(arma == "metra" && balaMetra >= 1)
			{
				animator.SetInteger("disparo", 4);
				StartCoroutine(esperaMetra());
			}else if(arma == "metra" && balaMetra == 0 && MetraTotales >= 1)
			{
				animator.SetInteger("recarga", 3);
			}else if(arma == "metra" && MetraTotales == 0)
			{
				rafaga = true;
			}
		}
	}
	//TIEMPOS DE ESPERA SIGUIENTE DISPARO
	IEnumerator muertee ()
	{
		yield return new WaitForSeconds(5f);
		Application.LoadLevel("Menu");
	}
	IEnumerator resetArma ()
	{
		yield return new WaitForSeconds(0.1f);
		animator.SetInteger("disparo", 0);
	}
	IEnumerator esperaPistola ()
	{
		yield return new WaitForSeconds(0.2f);
		rafaga = true;
	}
	IEnumerator esperaPistolaAire ()
	{
		yield return new WaitForSeconds(0.5f);
		rafaga = true;
	}
	IEnumerator esperaEscopeta ()
	{
		yield return new WaitForSeconds(1f);
		rafaga = true;
	}
	IEnumerator esperaFusil ()
	{
		yield return new WaitForSeconds(0.8f);
		rafaga = true;
	}
	IEnumerator esperaSubmetra ()
	{
		yield return new WaitForSeconds(0.5f);
		rafaga = true;
	}
	IEnumerator esperaMetra ()
	{
		yield return new WaitForSeconds(0.4f);
		rafaga = true;
	}
	IEnumerator esperaG ()//GRANADA
	{
		yield return new WaitForSeconds(1f);
		Gready = true;
	}
	IEnumerator esperaSniper ()//SNIPER
	{
		yield return new WaitForSeconds(0.4f);
		rafaga = true;
		bulletPrefSniper.SetActive(false);
	}
	//TIEMPO POSICION CUBRIRSE
	IEnumerator coverTiempo ()
	{
		yield return new WaitForSeconds(0.7f);
		cubierto = false;
	}

	//CAMBIAR DIRECCION
	void changeDirection(string direction)
	{
		if (_currentDirection != direction)
		{
			if (direction == "right")
			{
				GetComponent<ISkeletonComponent>().Skeleton.FlipX = false;
				Girar.transform.Rotate (0, 180, 0);
				Girar2.transform.Rotate (0, 180, 0);
				//transform.Rotate (0, 180, 0);
				_currentDirection = "right";
			} 
			else if (direction == "left") 
			{
				GetComponent<ISkeletonComponent>().Skeleton.FlipX = true;
				Girar.transform.Rotate (0, -180, 0);
				Girar2.transform.Rotate (0, -180, 0);
				//transform.Rotate (0, -180, 0);
				_currentDirection = "left";
			}
		}
	}
	//COLLISIONS
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Water")
		{
			water = true;
			maxspeed = 8;
		}
		if(col.gameObject.tag == "Piso")
		{
			water = false;
			maxspeed = 13;
		}
		if(col.gameObject.tag == "bala")
		{
			rafaga = true;
			animator.SetBool("walk", false);
			caminarA = false;
			caminarD = false;
			caminarI = false;
			caminarU = false;
			salud -= 15;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "15";
			StartCoroutine(sumar());
			efectodisparo = true;
		}
		if(col.gameObject.tag == "balaFusil" && vivo)
		{
			animator.SetBool("walk",false);
			caminarA = false;
			caminarD = false;
			caminarI = false;
			caminarU = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 40;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "40";
			StartCoroutine(sumar());
			efectodisparo = true;
		}
		if(col.gameObject.tag == "balaEscopeta" && vivo)
		{
			animator.SetBool("walk",false);
			caminarA = false;
			caminarD = false;
			caminarI = false;
			caminarU = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 15;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "15";
			StartCoroutine(sumar());
			efectodisparo = true;
		}
		if(col.gameObject.tag == "balaSubmetra" && vivo)
		{
			animator.SetBool("walk",false);
			caminarA = false;
			caminarD = false;
			caminarI = false;
			caminarU = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 20;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "20";
			StartCoroutine(sumar());
			efectodisparo = true;
		}
		if(col.gameObject.tag == "balaMetra" && vivo)
		{
			animator.SetBool("walk",false);
			caminarA = false;
			caminarD = false;
			caminarI = false;
			caminarU = false;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);
			salud -= 25;

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "25";
			StartCoroutine(sumar());
			efectodisparo = true;
		}
		if(col.gameObject.tag == "balaMG" && vivo)
		{
			rafaga = true;
			animator.SetBool("walk", false);
			caminarA = false;
			caminarD = false;
			caminarI = false;
			caminarU = false;
			salud -= 25;
			animator.SetInteger("cascado", 1);
			Destroy(col.gameObject);

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "25";
			StartCoroutine(sumar());
			efectodisparo = true;
		}
		if(col.gameObject.tag == "explo")
		{
			salud -= 50;
			animator.SetBool("granada", true);
			animator.SetInteger("cascado", 10);
			//vivo = false;
			//animator.SetInteger("muerte", 3);
			//GetComponent<Rigidbody>().AddForce(transform.right * -500);
			//GetComponent<Rigidbody>().velocity = (Vector2.up * 20);

			var letras = (GameObject)Instantiate(textos, new Vector3(transform.position.x, transform.position.y+9,transform.position.z), transform.rotation);
			letras.transform.parent = transform;
			letras.GetComponent<TextMesh>().text = "50";
			StartCoroutine(sumar());
			efectodisparo = true;
		}
		if(col.gameObject.tag == "granade")
		{
			granadas += 1;
		}
	}
	void OnTriggerEnter (Collider col)
	{
		/*if(col.gameObject.tag == "cobertura" && vivo)
		{
			coverPosition = new Vector3(col.gameObject.transform.position.x, transform.position.y, col.gameObject.transform.position.z);
			cubrirse = true;
			cuchillo = true;
		}*/
		if(col.gameObject.name == "uno")
		{
			Cam.Area2 = !Cam.Area2;
		}
		if(col.gameObject.name == "dos")
		{
			Cam.Area3 = !Cam.Area3;
		}
	}
	void OnTriggerExit (Collider col)
	{
		if(col.gameObject.tag == "cobertura" && vivo)
		{
			cuchillo = false;
			cubrirse = false;
		}
	}

	IEnumerator sumar()
	{
		yield return new WaitForSeconds(5);
		saludSumar = true;
	}

	//EVENTOS SPINE
	void Shot ()//PISTOLA
	{
		/*if(!grounded && caminarU)//animator.GetInteger("disparo") == 9)
		{
			luz.SetActive(true);
			StartCoroutine(apaga());
			if(arma2)
			{
				balaPistola -= 1;
				var bullet2 = (GameObject)Instantiate(bulletPref, bulletSpawnU.position, Quaternion.Euler(0,0,90)); 
				bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.right * 100;
				Destroy(bullet2, 1.0f);
			}else
			{
				if(arma == "escopeta")
				{
					balaEscopeta -= 1;
					var bulletB = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawnU.position, Quaternion.Euler(0,0,130)); //40
					bulletB.GetComponent<Rigidbody>().velocity = bulletB.transform.right * 100;
					Destroy(bulletB, 0.1f);
					var bulletB2 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawnU.position, Quaternion.Euler(0,0,110)); //20
					bulletB2.GetComponent<Rigidbody>().velocity = bulletB2.transform.right * 100;
					Destroy(bulletB2, 0.1f);
					var bulletB3 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawnU.position, Quaternion.Euler(0,0,90)); 
					bulletB3.GetComponent<Rigidbody>().velocity = bulletB3.transform.right * 100;
					Destroy(bulletB3, 0.1f);
					var bulletB4 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawnU.position, Quaternion.Euler(0,0,70)); 
					bulletB4.GetComponent<Rigidbody>().velocity = bulletB4.transform.right * 100;
					Destroy(bulletB4, 0.1f);
					var bulletB5 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawnU.position, Quaternion.Euler(0,0,50)); 
					bulletB5.GetComponent<Rigidbody>().velocity = bulletB5.transform.right * 100;
					Destroy(bulletB5, 0.1f);
				}
				if(arma == "fusil")
				{
					balaFusil -= 1;
					var bullet = (GameObject)Instantiate(bulletPrefFusil, bulletSpawnU.position, Quaternion.Euler(0,0,90)); 
					bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
					Destroy(bullet, 1.0f);
				}
				if(arma == "submetra")
				{
					balaSubmetra -= 1;
					var bullet = (GameObject)Instantiate(bulletPrefSubmetra, bulletSpawnU.position, Quaternion.Euler(0,0,90)); 
					bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
					Destroy(bullet, 1.0f);
				}
				if(arma == "metra")
				{
					balaMetra -= 1;
					var bullet = (GameObject)Instantiate(bulletPrefMetra, bulletSpawnU.position, Quaternion.Euler(0,0,90)); 
					bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
					Destroy(bullet, 1.0f);
				}
			}
			var casquillo = (GameObject)Instantiate(casquilloPref, casquilloSpawn.position, casquilloSpawn.rotation); 
			casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.right * Random.Range(-10,-50);//-50;
			casquillo.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-0.0f,-0.2f));
			casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.up * Random.Range(-1,-6);//-5;
		}else if(!grounded && caminarA)//animator.GetInteger("disparo") == 10)
		{
			luz.SetActive(true);
			StartCoroutine(apaga());
			if(arma2)
			{
				balaPistola -= 1;
				var bullet3 = (GameObject)Instantiate(bulletPref, bulletSpawnD.position, Quaternion.Euler(0,0,-90)); 
				bullet3.GetComponent<Rigidbody>().velocity = bullet3.transform.right * 100;
				Destroy(bullet3, 1.0f);
			}else
			{
				if(arma == "escopeta")
				{
					balaEscopeta -= 1;
					var bulletB = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawnD.position, Quaternion.Euler(0,0,-130)); //40
					bulletB.GetComponent<Rigidbody>().velocity = bulletB.transform.right * 100;
					Destroy(bulletB, 0.1f);
					var bulletB2 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawnD.position, Quaternion.Euler(0,0,-110)); //20
					bulletB2.GetComponent<Rigidbody>().velocity = bulletB2.transform.right * 100;
					Destroy(bulletB2, 0.1f);
					var bulletB3 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawnD.position, Quaternion.Euler(0,0,-90)); 
					bulletB3.GetComponent<Rigidbody>().velocity = bulletB3.transform.right * 100;
					Destroy(bulletB3, 0.1f);
					var bulletB4 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawnD.position, Quaternion.Euler(0,0,-70)); 
					bulletB4.GetComponent<Rigidbody>().velocity = bulletB4.transform.right * 100;
					Destroy(bulletB4, 0.1f);
					var bulletB5 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawnD.position, Quaternion.Euler(0,0,-50)); 
					bulletB5.GetComponent<Rigidbody>().velocity = bulletB5.transform.right * 100;
					Destroy(bulletB5, 0.1f);
				}
				if(arma == "fusil")
				{
					balaFusil -= 1;
					var bullet = (GameObject)Instantiate(bulletPrefFusil, bulletSpawnD.position, Quaternion.Euler(0,0,-90)); 
					bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
					Destroy(bullet, 1.0f);
				}
				if(arma == "submetra")
				{
					balaSubmetra -= 1;
					var bullet = (GameObject)Instantiate(bulletPrefSubmetra, bulletSpawnD.position, Quaternion.Euler(0,0,-90)); 
					bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
					Destroy(bullet, 1.0f);
				}
				if(arma == "metra")
				{
					balaMetra -= 1;
					var bullet = (GameObject)Instantiate(bulletPrefMetra, bulletSpawnD.position, Quaternion.Euler(0,0,-90)); 
					bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
					Destroy(bullet, 1.0f);
				}
			}
		}else */if(!grounded)// && animator.GetInteger("disparo") == 8)
		{
			luz.SetActive(true);
			StartCoroutine(apaga());
			if(arma2)
			{
				ProCamera2DShake.Instance.Shake();
				balaPistola -= 1;
				var bullet4 = (GameObject)Instantiate(bulletPref, bulletSpawn.position, bulletSpawn.rotation); 
				bullet4.GetComponent<Rigidbody>().velocity = bullet4.transform.right * 100;
				Destroy(bullet4, 1.0f);
			}else
			{
				ProCamera2DShake.Instance.Shake();
				if(arma == "escopeta")
				{
					balaEscopeta -= 1;
					if(Hero._currentDirection == "right")
					{
						var bulletB = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,0,10)); 
						bulletB.GetComponent<Rigidbody>().velocity = bulletB.transform.right * 100;
						Destroy(bulletB, 0.1f);
						var bulletB2 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,0,5)); 
						bulletB2.GetComponent<Rigidbody>().velocity = bulletB2.transform.right * 100;
						Destroy(bulletB2, 0.1f);
						var bulletB4 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,0,-5)); 
						bulletB4.GetComponent<Rigidbody>().velocity = bulletB4.transform.right * 100;
						Destroy(bulletB4, 0.1f);
						var bulletB5 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,0,-10)); 
						bulletB5.GetComponent<Rigidbody>().velocity = bulletB5.transform.right * 100;
						Destroy(bulletB5, 0.1f);
					}else
					{
						var bulletB = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,180,9)); 
						bulletB.GetComponent<Rigidbody>().velocity = bulletB.transform.right * 100;
						Destroy(bulletB, 0.1f);
						var bulletB2 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,180,3)); 
						bulletB2.GetComponent<Rigidbody>().velocity = bulletB2.transform.right * 100;
						Destroy(bulletB2, 0.1f);
						var bulletB4 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,180,-3)); 
						bulletB4.GetComponent<Rigidbody>().velocity = bulletB4.transform.right * 100;
						Destroy(bulletB4, 0.1f);
						var bulletB5 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,180,-9)); 
						bulletB5.GetComponent<Rigidbody>().velocity = bulletB5.transform.right * 100;
						Destroy(bulletB5, 0.1f);
					}
					var bulletB3 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, bulletSpawn.rotation); 
					bulletB3.GetComponent<Rigidbody>().velocity = bulletB3.transform.right * 100;
					Destroy(bulletB3, 0.1f);
				}
				if(arma == "fusil")
				{
					balaFusil -= 1;
					var bullet = (GameObject)Instantiate(bulletPrefFusil, bulletSpawn.position, bulletSpawn.rotation); 
					bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
					Destroy(bullet, 1.0f);
				}
				if(arma == "submetra")
				{
					balaSubmetra -= 1;
					var bullet = (GameObject)Instantiate(bulletPrefSubmetra, bulletSpawn.position, bulletSpawn.rotation); 
					bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
					Destroy(bullet, 1.0f);
				}
				if(arma == "metra")
				{
					balaMetra -= 1;
					var bullet = (GameObject)Instantiate(bulletPrefMetra, bulletSpawn.position, bulletSpawn.rotation); 
					bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
					Destroy(bullet, 1.0f);
				}
			}
		}else
		{
			ProCamera2DShake.Instance.Shake();
			luz.SetActive(true);
			StartCoroutine(apaga());
			balaPistola -= 1;
			var bullet = (GameObject)Instantiate(bulletPref, bulletSpawn.position, bulletSpawn.rotation); 
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
			Destroy(bullet, 1.0f);
			//CASQUILLOS}
			var casquillo = (GameObject)Instantiate(casquilloPref, casquilloSpawn.position, casquilloSpawn.rotation); 
			casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.right * Random.Range(-10,-50);//-50;
			casquillo.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-0.0f,-0.2f));
			casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.up * Random.Range(-1,-6);//-5;
		}
	}
	void ShotA ()//FUSIL
	{
		ProCamera2DShake.Instance.Shake();
		luz.SetActive(true);
		StartCoroutine(apaga());
		balaFusil -= 1;
		var bullet = (GameObject)Instantiate(bulletPrefFusil, bulletSpawn.position, bulletSpawn.rotation); 
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
		Destroy(bullet, 1.0f);
		//CASQUILLOS}
		var casquillo = (GameObject)Instantiate(casquilloPref, casquilloSpawn.position, casquilloSpawn.rotation); 
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.right * Random.Range(-10,-50);//-50;
		casquillo.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-0.0f,-0.2f));
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.up * Random.Range(-1,-6);//-5;
	}
	void ShotB ()//ESCOPETA
	{
		ProCamera2DShake.Instance.Shake();
		luz.SetActive(true);
		StartCoroutine(apaga());
		balaEscopeta -= 1;
		if(Hero._currentDirection == "right")
		{
			var bulletB = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,0,10)); 
			bulletB.GetComponent<Rigidbody>().velocity = bulletB.transform.right * 100;
			Destroy(bulletB, 0.3f);
			var bulletB2 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,0,5)); 
			bulletB2.GetComponent<Rigidbody>().velocity = bulletB2.transform.right * 100;
			Destroy(bulletB2, 0.3f);
			var bulletB4 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,0,-5)); 
			bulletB4.GetComponent<Rigidbody>().velocity = bulletB4.transform.right * 100;
			Destroy(bulletB4, 0.3f);
			var bulletB5 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,0,-10)); 
			bulletB5.GetComponent<Rigidbody>().velocity = bulletB5.transform.right * 100;
			Destroy(bulletB5, 0.3f);
		}else
		{
			var bulletB = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,180,9)); 
			bulletB.GetComponent<Rigidbody>().velocity = bulletB.transform.right * 100;
			Destroy(bulletB, 0.3f);
			var bulletB2 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,180,3)); 
			bulletB2.GetComponent<Rigidbody>().velocity = bulletB2.transform.right * 100;
			Destroy(bulletB2, 0.3f);
			var bulletB4 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,180,-3)); 
			bulletB4.GetComponent<Rigidbody>().velocity = bulletB4.transform.right * 100;
			Destroy(bulletB4, 0.3f);
			var bulletB5 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, Quaternion.Euler(0,180,-9)); 
			bulletB5.GetComponent<Rigidbody>().velocity = bulletB5.transform.right * 100;
			Destroy(bulletB5, 0.3f);
		}
		var bulletB3 = (GameObject)Instantiate(bulletPrefEscopeta, bulletSpawn.position, bulletSpawn.rotation); 
		bulletB3.GetComponent<Rigidbody>().velocity = bulletB3.transform.right * 100;
		Destroy(bulletB3, 0.3f);
		//CASQUILLOS}
		var casquillo = (GameObject)Instantiate(casquilloPrefB, casquilloSpawn.position, casquilloSpawn.rotation); 
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.right * Random.Range(-10,-50);//-50;
		casquillo.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-0.0f,-0.2f));
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.up * Random.Range(-1,-6);//-5;
	}
	void ShotC ()//SUBMETRA
	{
		ProCamera2DShake.Instance.Shake();
		luz.SetActive(true);
		StartCoroutine(apaga());
		balaSubmetra -= 1;
		var bullet = (GameObject)Instantiate(bulletPrefSubmetra, bulletSpawn.position, bulletSpawn.rotation); 
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
		Destroy(bullet, 1.0f);
		//CASQUILLOS}
		var casquillo = (GameObject)Instantiate(casquilloPref, casquilloSpawn.position, casquilloSpawn.rotation); 
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.right * Random.Range(-10,-50);//-50;
		casquillo.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-0.0f,-0.2f));
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.up * Random.Range(-1,-6);//-5;
	}
	void ShotD ()//METRA
	{
		ProCamera2DShake.Instance.Shake();
		luz.SetActive(true);
		StartCoroutine(apaga());
		balaMetra -= 1;
		var bullet = (GameObject)Instantiate(bulletPrefMetra, bulletSpawn.position, bulletSpawn.rotation); 
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 100;
		Destroy(bullet, 1.0f);
		//CASQUILLOS}
		var casquillo = (GameObject)Instantiate(casquilloPref, casquilloSpawn.position, casquilloSpawn.rotation); 
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.right * Random.Range(-10,-50);//-50;
		casquillo.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-0.0f,-0.2f));
		casquillo.GetComponent<Rigidbody>().velocity = casquillo.transform.up * Random.Range(-1,-6);//-5;
	}
	IEnumerator apaga ()
	{
		yield return new WaitForSeconds(0.1f);
		luz.SetActive(false);
	}
	//VOLUMEN
	public AudioSource audio1;
	public AudioClip sniperShot;
	float efectos;

	void sonidoSpiper()
	{
		efectos = PlayerPrefs.GetFloat("efects");
		audio1.volume = efectos;
		audio1.clip = sniperShot;
		audio1.Play();
	}
	//EVENTOS SPINE
	void granada ()
	{
		var granade = (GameObject)Instantiate(granadePref, granadaSpawn.position, granadaSpawn.rotation);
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
