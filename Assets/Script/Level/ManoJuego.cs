using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Spine.Unity;

public class ManoJuego : MonoBehaviour {

	public string nombre;
	public string nombre2;
	public float costo;
	public int cantidad;
	public UnityEngine.UI.Text cantidadT;
	public int cantidadTotal;

	public GameObject Barra;

	public UnityEngine.UI.Image imagen;

	//----IMAGENES DE CARTAS
	/*public Sprite a1;
	public Sprite a2;
	public Sprite a3;
	public Sprite a4;
	public Sprite a5;
	public Sprite a6;
	public Sprite a7;
	public Sprite a8;
	public Sprite a9;
	public Sprite a10;
	public Sprite a11;
	public Sprite a12;
	public Sprite a13;
	public Sprite a14;
	public Sprite a15;
	public Sprite a16;
	public Sprite a17;
	public Sprite a18;
	public Sprite a19;
	public Sprite a20;*/

	float efectos;
	public AudioClip nace;
	public AudioClip usa;

	// Use this for initialization
	void Start ()
	{
		nombre2 = nombre;
		cantidad = PlayerPrefs.GetInt("Mano"+nombre+"cantidad");

		efectos = PlayerPrefs.GetFloat("efects");

		nombre = PlayerPrefs.GetInt("Mano"+nombre).ToString();
		costo = PlayerPrefs.GetInt(""+nombre+"costo");

		PlayerPrefs.SetInt("1costo",20);
		PlayerPrefs.SetInt("2costo",25);
		PlayerPrefs.SetInt("3costo",25);
		PlayerPrefs.SetInt("4costo",30);
		PlayerPrefs.SetInt("5costo",50);
		PlayerPrefs.SetInt("6costo",50);
		PlayerPrefs.SetInt("7costo",20);
		PlayerPrefs.SetInt("8costo",20);
		PlayerPrefs.SetInt("9costo",30);
		PlayerPrefs.SetInt("10costo",50);
		PlayerPrefs.SetInt("11costo",50);
		PlayerPrefs.SetInt("12costo",90);
		PlayerPrefs.SetInt("13costo",40);
		PlayerPrefs.SetInt("14costo",40);
		PlayerPrefs.SetInt("15costo",40);
		PlayerPrefs.SetInt("16costo",80);
		PlayerPrefs.SetInt("17costo",80);
		PlayerPrefs.SetInt("18costo",100);
		PlayerPrefs.SetInt("19costo",95);
		PlayerPrefs.SetInt("20costo",100);

		animacion.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "inactiva", false);

		//UNO
		if(nombre == "1")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "1";
			//imagen.sprite = a1;
		}else if(nombre == "2")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "2";
			//imagen.sprite = a2;
		}else if(nombre == "3")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "3";
			//imagen.sprite = a3;
		}else if(nombre == "4")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "4";
			//imagen.sprite = a4;
		}else if(nombre == "5")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "5";
			//imagen.sprite = a5;
		}else if(nombre == "6")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "6";
			//imagen.sprite = a6;
		}else if(nombre == "7")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "7";
			//imagen.sprite = a7;
		}else if(nombre == "8")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "8";
			//imagen.sprite = a8;
		}else if(nombre == "9")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "9";
			//imagen.sprite = a9;
		}else if(nombre == "10")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "10";
			//imagen.sprite = a10;
		}else if(nombre == "11")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "11";
			//imagen.sprite = a11;
		}else if(nombre == "12")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "12";
			//imagen.sprite = a12;
		}else if(nombre == "13")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "13";
			//imagen.sprite = a13;
		}else if(nombre == "14")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "14";
			//imagen.sprite = a14;
		}else if(nombre == "15")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "15";
			//imagen.sprite = a15;
		}else if(nombre == "16")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "16";
			//imagen.sprite = a16;
		}else if(nombre == "17")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "17";
			//imagen.sprite = a17;
		}else if(nombre == "18")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "18";
			//imagen.sprite = a18;
		}else if(nombre == "19")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "19";
			//imagen.sprite = a19;
		}else if(nombre == "20")
		{
			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "20";
			//imagen.sprite = a20;
		}
		cantidadTotal = PlayerPrefs.GetInt("card"+nombre+"cantidad");
	}
	/*bool entrance;
	bool animandoentrada;
	bool exit;
	bool animandosalida;*/
	string nomm;
	// Update is called once per frame
	void Update ()
	{
		cantidadT.text = cantidad.ToString();

		if(cantidadTotal <= 0)
		{
			cantidadTotal = 0;
			PlayerPrefs.SetInt("card"+nombre, 0);
		}
		PlayerPrefs.SetInt("card"+nombre+"cantidad", cantidadTotal);

		PlayerPrefs.SetInt("Mano"+nombre2+"cantidad", cantidad);

		if(cantidad <= 0)
		{
			cantidadT.text = "";
			//PlayerPrefs.SetInt("card"+nombre, 0);
			PlayerPrefs.SetInt("Mano"+nombre2, 0);
			//PlayerPrefs.SetInt("card"+nombre+"cantidad", 0);
			PlayerPrefs.SetInt("Mano"+nombre2+"cantidad", 0);

			GetComponent<Button>().enabled = false;
			GetComponent<Image>().color = new Color32(100,100,100,100);

			if(nomm != "inactiva")
			{
				animacion.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "inactiva", false);
			}

			animacion.GetComponent<skinCarta>().skinsToCombine[0] = "default";

			nombre = "0";
		}


		nomm = animacion.GetComponent<SkeletonGraphic>().AnimationState.GetCurrent(0).Animation.Name;
		if(Barra.GetComponent<barra>().fill*100 >= costo && nomm == "inactiva" && cantidad >= 1)
		{
			GetComponent<AudioSource>().volume = efectos;
			GetComponent<AudioSource>().clip = nace;
			GetComponent<AudioSource>().Play();

			animacion.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "entrada", false);
			GetComponent<Button>().enabled = true;
			GetComponent<Image>().color = new Color32(255,255,255,255);
		}
		if(Barra.GetComponent<barra>().fill*100 < costo && cantidad >= 1)
		{
			GetComponent<Button>().enabled = false;
			GetComponent<Image>().color = new Color32(100,100,100,100);

			if(nomm != "inactiva")
			{
				animacion.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "inactiva", false);
			}
		}
	}

	/*public void OnMouseDrag ()
	{
		print("ARRASTRANDO");
	}*/

	Vector3 inicial;
	bool arrastrar;
	//public GameObject cursor;
	//bool preview;

	public void OnBeginDrag ()
	{
		if(GetComponent<Button>().enabled && nombre != "0")
		{
			inicial = transform.localPosition;
			arrastrar = true;

			animacion.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "arrastre", false);
		}
	}

	public void OnDrag ()//(PointerEventData eventData)
	{
		if(arrastrar)
		{
			//preview = true;

			transform.position = Input.mousePosition;
			if(nomm != "arrastre")
			{
				animacion.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "arrastre", false);
			}
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		/*if(preview)
		{
			if(piso.GetComponent<Collider>().Raycast (ray, out hit, Mathf.Infinity))
			{
				cursor.SetActive(true);
				cursor.transform.position = new Vector3(hit.point.x,hit.point.y+1,hit.point.z);//hit.point;
			}
		}*/
	}

	public Transform piso;
	public GameObject animacion;
	//OBJETOS A CREAR
	//ARMAS
	public GameObject fusil;
	public GameObject escopeta;
	public GameObject submetra;
	public GameObject metra;
	public GameObject sniper;
	public GameObject lansallamas;
	public GameObject granada;
	public GameObject balas;
	//PERSONAJES NORMALES
	public GameObject fusilero;
	public GameObject submetro;
	public GameObject escopeto;
	public GameObject lightTank;
	//PERSONAJES FUERTES
	public GameObject mg;
	public GameObject mortero;
	public GameObject bazokero;
	//PERSONAJES MUY FUERTES
	public GameObject metralleto;
	public GameObject llamero;
	public GameObject heavyTank;

	public void OnDragEnd ()//(PointerEventData eventData)
	{
		if(arrastrar)
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast (ray, out hit, Mathf.Infinity))//if(piso.GetComponent<Collider>().Raycast (ray, out hit, Mathf.Infinity))
			{
				GetComponent<AudioSource>().volume = efectos;
				GetComponent<AudioSource>().clip = usa;
				GetComponent<AudioSource>().Play();

				cantidad -= 1;
				cantidadTotal -= 1;

				Barra.GetComponent<barra>().fill -= costo/100;
				if(nombre == "1")
				{
					var objeto = (GameObject)Instantiate(fusil, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.x,hit.point.y+20,hit.point.z);

				}else if(nombre == "2")
				{
					var objeto = (GameObject)Instantiate(submetra, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);

				}else if(nombre == "3")
				{
					var objeto = (GameObject)Instantiate(escopeta, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);

				}else if(nombre == "4")
				{
					var objeto = (GameObject)Instantiate(metra, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);

				}else if(nombre == "5")
				{
					var objeto = (GameObject)Instantiate(sniper, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "6")
				{
					var objeto = (GameObject)Instantiate(lansallamas, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "7")
				{
					var objeto = (GameObject)Instantiate(granada, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "8")
				{
					var objeto = (GameObject)Instantiate(balas, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "9")
				{
					var objeto = (GameObject)Instantiate(fusilero, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "10")
				{
					var objeto = (GameObject)Instantiate(submetro, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "11")
				{
					var objeto = (GameObject)Instantiate(escopeto, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "12")
				{
					var objeto = (GameObject)Instantiate(lightTank, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "13")
				{
					var objeto = (GameObject)Instantiate(mg, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "14")
				{
					var objeto = (GameObject)Instantiate(mortero, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "15")
				{
					var objeto = (GameObject)Instantiate(bazokero, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "16")
				{
					var objeto = (GameObject)Instantiate(metralleto, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "17")
				{
					var objeto = (GameObject)Instantiate(llamero, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "18")
				{
					var objeto = (GameObject)Instantiate(heavyTank, transform.position, transform.rotation);
					objeto.transform.position = new Vector3(hit.point.x,-20,-142);//hit.point.y+20,hit.point.z);
				}else if(nombre == "19")
				{
					
				}else if(nombre == "20")
				{

				}
				print("Carta: "+nombre);
			}
			animacion.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "entrada", false);
			transform.localPosition = inicial;
		}
		arrastrar = false;
		//preview = false;
		//cursor.SetActive(false);
	}

	public void Over ()//(PointerEventData eventData)
	{
		if(Barra.GetComponent<barra>().fill*100 >= costo && nombre != "0")
		{
			animacion.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "mouse", false);
		}
	}

	public void Sale ()//(PointerEventData eventData)
	{
		if(Barra.GetComponent<barra>().fill*100 >= costo && nombre != "0")
		{
			animacion.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "normal", false);
		}
	}
}
