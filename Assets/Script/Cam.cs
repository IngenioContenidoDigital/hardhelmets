using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityStandardAssets.ImageEffects;

public class Cam : MonoBehaviour {

	public GameObject Player;

	public GameObject Ocultar;

	public Vector3 nextPosition;

	//SNIPER
	public static bool sniper;
	Ray ray;
	RaycastHit hit;
	float horizontal = 2;
	float vertical = 2;
	public float h;
	public float v;


	//SONIDOS DE HAMBIENTE
	public static bool Area2;
	public static bool Area3;

	public AudioSource audio2;
	public AudioSource audio3;

	float musica;

	GameObject[] Explo;
	public static bool visible;
	bool sube;
	bool baja;
	bool loop;
	float intensidad;

	// Use this for initialization
	void Start ()
	{
		musica = PlayerPrefs.GetFloat("musica");
	}
	// Update is called once per frame
	void Update ()
	{
		Explo = GameObject.FindGameObjectsWithTag("explo");

		foreach(GameObject explo in Explo)
		{
			if(explo.GetComponent<Renderer>().isVisible && visible && !sube && !loop)
			{
				loop = true;
				sube = true;
			}
		}

		GetComponent<Bloom>().bloomIntensity = intensidad;

		if(sube)
		{
			ProCamera2DShake.Instance.Shake();
			intensidad += 10;
			GetComponent<Bloom>().bloomThreshold = 0;
			if(intensidad >= 50)
			{
				baja = true;
				sube = false;
			}
		}
		if(baja)
		{
			intensidad -= 10;
			GetComponent<Bloom>().bloomThreshold = 0.8f;
			if(intensidad <= 0.1f)
			{
				StartCoroutine(explo());
				baja = false;
			}
		}

		if(sniper)
		{
			Ocultar.SetActive(false);

			GetComponent<DirtyLensFlare>().enabled = true;
			GetComponent<ProCamera2D>().enabled = false;
			GetComponent<ProCamera2DForwardFocus>().enabled = false;
			//GetComponent<ProCamera2DSpeedBasedZoom>().enabled = false;

			GetComponent<Camera>().fieldOfView = 20.5f;

			h = horizontal * Input.GetAxis("Mouse X");
			v = vertical * Input.GetAxis("Mouse Y");

			if(Hero._currentDirection == "right")
			{
				if(transform.position.x >= Player.transform.position.x+130)
				{
					nextPosition = new Vector3(transform.position.x-0.5f, transform.position.y+v, transform.position.z);//zeta);
				}else if(transform.position.x <= Player.transform.position.x+9)
				{
					nextPosition = new Vector3(transform.position.x+2f, transform.position.y+v, transform.position.z);//zeta);
				}else
				{
					nextPosition = new Vector3(transform.position.x+h, transform.position.y+v, transform.position.z);//zeta);
				}
			}
			if(Hero._currentDirection == "left")
			{
				if(transform.position.x <= Player.transform.position.x-55)
				{
					nextPosition = new Vector3(transform.position.x+0.5f, transform.position.y+v, transform.position.z);//zeta);
				}else if(transform.position.x >= Player.transform.position.x-9)
				{
					nextPosition = new Vector3(transform.position.x-2f, transform.position.y+v, transform.position.z);//zeta);
				}else
				{
					nextPosition = new Vector3(transform.position.x+h, transform.position.y+v, transform.position.z);//zeta);
				}
			}
			transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * 20);
		}else
		{
			Ocultar.SetActive(true);

			GetComponent<DirtyLensFlare>().enabled = false;
			GetComponent<ProCamera2D>().enabled = true;
			GetComponent<ProCamera2DForwardFocus>().enabled = true;
			//GetComponent<ProCamera2DSpeedBasedZoom>().enabled = true;
		}

		//SONIDOS
		if(Area2 && !audio2.isPlaying)
		{
			print("DOS");
			audio2.volume = musica;
			audio2.Play();
		}else
		{
			audio2.Stop();
		}
		if(Area3 && !audio3.isPlaying)
		{
			print("TRES");
			audio3.volume = musica;
			audio3.Play();
		}else
		{
			audio3.Stop();
		}
	}
	IEnumerator explo()
	{
		yield return new WaitForSeconds(3);
		loop = false;
	}
}

