using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CamMenu : MonoBehaviour {

	public Vector3 nextPosition;

	float valor = 0.05f;

	public float h;
	public float v;

	Vector3 inicial;
	bool listo;

	public GameObject animacion;
	public GameObject animacion2;

	//POSICIONES DE CAMARA
	public static bool segundo;
	Vector3 secundaria;

	bool primera;

	public GameObject menu1;
	public GameObject menu2;

	//VOLUMEN
	float efectos;
	public AudioSource audio1;
	public AudioSource audio2;

	// Use this for initialization
	void Start ()
	{
		if(PlayerPrefs.GetInt("Primeravez") == 0)
		{
			//POR PRIMERA VEZ DESBLOQUEA TODO
			PlayerPrefs.SetFloat("voice",1);
			PlayerPrefs.SetFloat("efects",1);
			PlayerPrefs.SetFloat("musica",1);
			PlayerPrefs.SetInt("violencia",1);
			//DESBLOQUEA TODAS LAS CARTAS
			PlayerPrefs.SetInt("card1", 0);
			PlayerPrefs.SetInt("card2", 0);
			PlayerPrefs.SetInt("card3", 0);
			PlayerPrefs.SetInt("card4", 0);
			PlayerPrefs.SetInt("card5", 0);
			PlayerPrefs.SetInt("card6", 0);
			PlayerPrefs.SetInt("card7", 0);
			PlayerPrefs.SetInt("card8", 0);
			PlayerPrefs.SetInt("card9", 0);
			PlayerPrefs.SetInt("card10", 0);
			PlayerPrefs.SetInt("card11", 0);
			PlayerPrefs.SetInt("card12", 0);
			PlayerPrefs.SetInt("card13", 0);
			PlayerPrefs.SetInt("card14", 0);
			PlayerPrefs.SetInt("card15", 0);
			PlayerPrefs.SetInt("card16", 0);
			PlayerPrefs.SetInt("card17", 0);
			PlayerPrefs.SetInt("card18", 0);
			PlayerPrefs.SetInt("card19", 0);
			PlayerPrefs.SetInt("card20", 0);
			print(PlayerPrefs.GetInt("card1"));
			//SELECCIONA UNA BARAJA BASICA
			PlayerPrefs.SetInt("Mano1", 0);
			PlayerPrefs.SetInt("Mano2", 0);
			PlayerPrefs.SetInt("Mano3", 0);
			PlayerPrefs.SetInt("Mano4", 0);
			PlayerPrefs.SetInt("Mano5", 0);
			PlayerPrefs.SetInt("Mano6", 0);
			PlayerPrefs.SetInt("Mano7", 0);
			PlayerPrefs.SetInt("Mano8", 0);
			PlayerPrefs.SetInt("Mano9", 0);
			PlayerPrefs.SetInt("Mano10", 0);
			//CANTIDAD DE CARTAS EN LA MANO
			PlayerPrefs.SetInt("Mano1cantidad", 0);
			PlayerPrefs.SetInt("Mano2cantidad", 0);
			PlayerPrefs.SetInt("Mano3cantidad", 0);
			PlayerPrefs.SetInt("Mano4cantidad", 0);
			PlayerPrefs.SetInt("Mano5cantidad", 0);
			PlayerPrefs.SetInt("Mano6cantidad", 0);
			PlayerPrefs.SetInt("Mano7cantidad", 0);
			PlayerPrefs.SetInt("Mano8cantidad", 0);
			PlayerPrefs.SetInt("Mano9cantidad", 0);
			PlayerPrefs.SetInt("Mano10cantidad", 0);
			//MONEDAS
			PlayerPrefs.SetInt("monedas",0);
			//VALOR DE VENTA DE CARTAS
			PlayerPrefs.SetInt("card1valor", 60);
			PlayerPrefs.SetInt("card2valor", 80);
			PlayerPrefs.SetInt("card3valor", 80);
			PlayerPrefs.SetInt("card4valor", 80);
			PlayerPrefs.SetInt("card5valor", 100);
			PlayerPrefs.SetInt("card6valor", 100);
			PlayerPrefs.SetInt("card7valor", 60);
			PlayerPrefs.SetInt("card8valor", 50);
			PlayerPrefs.SetInt("card9valor", 60);
			PlayerPrefs.SetInt("card10valor", 60);
			PlayerPrefs.SetInt("card11valor", 60);
			PlayerPrefs.SetInt("card12valor", 120);
			PlayerPrefs.SetInt("card13valor", 90);
			PlayerPrefs.SetInt("card14valor", 90);
			PlayerPrefs.SetInt("card15valor", 90);
			PlayerPrefs.SetInt("card16valor", 120);
			PlayerPrefs.SetInt("card17valor", 120);
			PlayerPrefs.SetInt("card18valor", 150);
			//CANTIDAD DE CADA CARTA
			PlayerPrefs.SetInt("card1cantidad", 0);
			PlayerPrefs.SetInt("card2cantidad", 0);
			PlayerPrefs.SetInt("card3cantidad", 0);
			PlayerPrefs.SetInt("card4cantidad", 0);
			PlayerPrefs.SetInt("card5cantidad", 0);
			PlayerPrefs.SetInt("card6cantidad", 0);
			PlayerPrefs.SetInt("card7cantidad", 0);
			PlayerPrefs.SetInt("card8cantidad", 0);
			PlayerPrefs.SetInt("card9cantidad", 0);
			PlayerPrefs.SetInt("card10cantidad", 0);
			PlayerPrefs.SetInt("card11cantidad", 0);
			PlayerPrefs.SetInt("card12cantidad", 0);
			PlayerPrefs.SetInt("card13cantidad", 0);
			PlayerPrefs.SetInt("card14cantidad", 0);
			PlayerPrefs.SetInt("card15cantidad", 0);
			PlayerPrefs.SetInt("card16cantidad", 0);
			PlayerPrefs.SetInt("card17cantidad", 0);
			PlayerPrefs.SetInt("card18cantidad", 0);
			//CANTIDAD DE CARTAS APLICADAS A LA MANO
			PlayerPrefs.SetInt("card1cantidadUsadas", 0);
			PlayerPrefs.SetInt("card2cantidadUsadas", 0);
			PlayerPrefs.SetInt("card3cantidadUsadas", 0);
			PlayerPrefs.SetInt("card4cantidadUsadas", 0);
			PlayerPrefs.SetInt("card5cantidadUsadas", 0);
			PlayerPrefs.SetInt("card6cantidadUsadas", 0);
			PlayerPrefs.SetInt("card7cantidadUsadas", 0);
			PlayerPrefs.SetInt("card8cantidadUsadas", 0);
			PlayerPrefs.SetInt("card9cantidadUsadas", 0);
			PlayerPrefs.SetInt("card10cantidadUsadas", 0);
			PlayerPrefs.SetInt("card11cantidadUsadas", 0);
			PlayerPrefs.SetInt("card12cantidadUsadas", 0);
			PlayerPrefs.SetInt("card13cantidadUsadas", 0);
			PlayerPrefs.SetInt("card14cantidadUsadas", 0);
			PlayerPrefs.SetInt("card15cantidadUsadas", 0);
			PlayerPrefs.SetInt("card16cantidadUsadas", 0);
			PlayerPrefs.SetInt("card17cantidadUsadas", 0);
			PlayerPrefs.SetInt("card18cantidadUsadas", 0);
			//SELECCIONA EL SKIN BASICO
			PlayerPrefs.SetString("casco","Casco1");
			PlayerPrefs.SetString("cara","Cara1");
			//DEJA DE SER LA PRIMERA VEZ
			PlayerPrefs.SetInt("Primeravez",1);
		}

		efectos = PlayerPrefs.GetFloat("efects");

		inicial = new Vector3(1.23f,2.9f,-11);
		StartCoroutine(espera());

		secundaria = new Vector3(25.6f,transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(listo)
		{
			h = valor * Input.GetAxis("Mouse X");
			v = valor * Input.GetAxis("Mouse Y");

			nextPosition = new Vector3(transform.position.x+h, transform.position.y+v, transform.position.z);

			transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * 20);

			animacion.GetComponent<SkeletonAnimation>().AnimationName = "loop";

			animacion2.GetComponent<SkeletonAnimation>().AnimationName = "loopB";

			//LIMITES DE LA CAMARA
			if(transform.position.x >= 25.9f)
			{
				transform.position = new Vector3(25.9f, transform.position.y, transform.position.z);
			}
			if(transform.position.x <= -0.16f)
			{
				transform.position = new Vector3(-0.16f, transform.position.y, transform.position.z);
			}
			if(transform.position.y >= 3.4f)
			{
				transform.position = new Vector3(transform.position.x, 3.4f, transform.position.z);
			}
			if(transform.position.y <= 1.23f)
			{
				transform.position = new Vector3(transform.position.x, 1.23f, transform.position.z);
			}

		}else if(segundo)
		{
			menu1.GetComponent<Animator>().SetBool("salida",true);
			//menu1.GetComponent<Animator>().SetBool("entrada",false);
			menu2.GetComponent<Animator>().SetBool("entrada",true);

			transform.position = Vector3.Lerp(transform.position, secundaria, Time.deltaTime * 2);
		}else if(primera)
		{
			transform.position = Vector3.Lerp(transform.position, inicial, Time.deltaTime * 2);
		}else
		{
			transform.position = Vector3.Lerp(transform.position, inicial, Time.deltaTime * 0.5f);
		}

		if(primera && transform.position.x <= 1.3f)
		{
			listo = true;
			primera = false;
		}

		if(transform.position.x >= 25)
		{
			listo = true;
			segundo = false;
		}
	}

	IEnumerator espera ()
	{
		yield return new WaitForSeconds (3);
		listo = true;
	}

	public void Iniciar()
	{
		audio1.volume = efectos;
		audio1.Play();

		menu1.GetComponent<Animator>().SetBool("salida",true);
		menu1.GetComponent<Animator>().SetBool("entrada",false);

		menu2.GetComponent<Animator>().SetBool("entrada",true);
		menu2.GetComponent<Animator>().SetBool("salida",false);

		listo = false;
		segundo = true;
	}

	public void Regresar()
	{
		audio1.volume = efectos;
		audio1.Play();

		menu1.GetComponent<Animator>().SetBool("entrada",true);
		menu1.GetComponent<Animator>().SetBool("salida",false);

		menu2.GetComponent<Animator>().SetBool("salida",true);
		menu2.GetComponent<Animator>().SetBool("entrada",false);

		listo = false;
		primera = true;
	}

	public void Custom()
	{
		audio1.volume = efectos;
		audio1.Play();

		Application.LoadLevel("Load");
		loading.nombre = "Custom";
	}
	public void Cajas()
	{
		audio1.volume = efectos;
		audio1.Play();

		Application.LoadLevel("Load");
		loading.nombre = "cajas";
	}

	public void Cartas()
	{
		audio1.volume = efectos;
		audio1.Play();

		Application.LoadLevel("Load");
		loading.nombre = "Select";
	}

	public void Play()
	{
		audio1.volume = efectos;
		audio1.Play();

		Application.LoadLevel("Load");
		loading.nombre = "Level";
	}

	public void Over()
	{
		audio2.volume = efectos;
		audio2.Play();
		menu1.GetComponent<Animator>().SetBool("over",true);
	}
	public void Exit()
	{
		menu1.GetComponent<Animator>().SetBool("over",false);
	}

	public void Over2()
	{
		audio2.volume = efectos;
		audio2.Play();
		menu1.GetComponent<Animator>().SetBool("over2",true);
	}
	public void Exit2()
	{
		menu1.GetComponent<Animator>().SetBool("over2",false);
	}
}
