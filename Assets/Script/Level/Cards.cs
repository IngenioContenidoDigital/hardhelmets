using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cards : MonoBehaviour {

	public int carta;
	//public int level;
	public int cantidadTotal;
	public int cantidadUsadas;
	public int cantidad;

	public bool usada;

	public UnityEngine.UI.Text nivel;

	public UnityEngine.UI.Image imagen;

	void Start ()
	{
		carta = int.Parse(gameObject.name);

		cantidadTotal = PlayerPrefs.GetInt("card"+carta+"cantidad");

		StartCoroutine(cargausadas());
	}
	IEnumerator cargausadas()
	{
		yield return new WaitForSeconds(0.1f);
		cantidadUsadas = PlayerPrefs.GetInt("card"+carta+"cantidadUsadas");
		cantidad = cantidadTotal-cantidadUsadas;
	}

	public void click ()
	{
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = selec;
		GetComponent<AudioSource>().Play();

		if(Cartas.uno == 0 || Cartas.dos == 0 || Cartas.tres == 0 || Cartas.cuatro == 0 || Cartas.cinco == 0 ||
			Cartas.seis == 0 || Cartas.siete == 0 || Cartas.ocho == 0 || Cartas.nueve == 0 || Cartas.diez == 0)
		{
			//Cartas.libre = carta;
			//cantidad -=1;
			Cartas.seleccionada = carta;

			if(carta == Cartas.uno)
			{
				Cartas.unoCantidad += 1;
			}else if(carta == Cartas.dos)
			{
				Cartas.dosCantidad += 1;
			}else if(carta == Cartas.tres)
			{
				Cartas.tresCantidad += 1;
			}else if(carta == Cartas.cuatro)
			{
				Cartas.cuatroCantidad += 1;
			}else if(carta == Cartas.cinco)
			{
				Cartas.cincoCantidad += 1;
			}else if(carta == Cartas.seis)
			{
				Cartas.seisCantidad += 1;
			}else if(carta == Cartas.siete)
			{
				Cartas.sieteCantidad += 1;
			}else if(carta == Cartas.ocho)
			{
				Cartas.ochoCantidad += 1;
			}else if(carta == Cartas.nueve)
			{
				Cartas.nueveCantidad += 1;
			}else if(carta == Cartas.diez)
			{
				Cartas.diezCantidad += 1;
			}else
			{
				if(Cartas.uno == 0)
				{
					Cartas.uno = carta;
					Cartas.unoCantidad += 1;
				}else if(Cartas.dos == 0)
				{
					Cartas.dos = carta;
					Cartas.dosCantidad += 1;
				}else if(Cartas.tres == 0)
				{
					Cartas.tres = carta;
					Cartas.tresCantidad += 1;
				}else if(Cartas.cuatro == 0)
				{
					Cartas.cuatro = carta;
					Cartas.cuatroCantidad += 1;
				}else if(Cartas.cinco == 0)
				{
					Cartas.cinco = carta;
					Cartas.cincoCantidad += 1;
				}else if(Cartas.seis == 0)
				{
					Cartas.seis = carta;
					Cartas.seisCantidad += 1;
				}else if(Cartas.siete == 0)
				{
					Cartas.siete = carta;
					Cartas.sieteCantidad += 1;
				}else if(Cartas.ocho == 0)
				{
					Cartas.ocho = carta;
					Cartas.ochoCantidad += 1;
				}else if(Cartas.nueve == 0)
				{
					Cartas.nueve = carta;
					Cartas.nueveCantidad += 1;
				}else if(Cartas.diez == 0)
				{
					Cartas.diez = carta;
					Cartas.diezCantidad += 1;
				}
			}

			cantidad -= 1;
			if(cantidad <= 0)
			{
				usada = true;
			}
			//usada = true;
			//GetComponent<Button>().enabled = false;
			//GetComponent<Image>().color = new Color32(100,100,100,100);
		}
		if(Cartas.uno != 0 && Cartas.dos != 0 && Cartas.tres != 0 && Cartas.cuatro != 0 && Cartas.cinco != 0 &&
			Cartas.seis != 0 && Cartas.siete != 0 && Cartas.ocho != 0 && Cartas.nueve != 0 && Cartas.diez != 0)
		{
			Cartas.seleccionada = carta;

			if(carta == Cartas.uno)
			{
				cantidad -= 1;
				Cartas.unoCantidad += 1;
			}else if(carta == Cartas.dos)
			{
				cantidad -= 1;
				Cartas.dosCantidad += 1;
			}else if(carta == Cartas.tres)
			{
				cantidad -= 1;
				Cartas.tresCantidad += 1;
			}else if(carta == Cartas.cuatro)
			{
				cantidad -= 1;
				Cartas.cuatroCantidad += 1;
			}else if(carta == Cartas.cinco)
			{
				cantidad -= 1;
				Cartas.cincoCantidad += 1;
			}else if(carta == Cartas.seis)
			{
				cantidad -= 1;
				Cartas.seisCantidad += 1;
			}else if(carta == Cartas.siete)
			{
				cantidad -= 1;
				Cartas.sieteCantidad += 1;
			}else if(carta == Cartas.ocho)
			{
				cantidad -= 1;
				Cartas.ochoCantidad += 1;
			}else if(carta == Cartas.nueve)
			{
				cantidad -= 1;
				Cartas.nueveCantidad += 1;
			}else if(carta == Cartas.diez)
			{
				cantidad -= 1;
				Cartas.diezCantidad += 1;
			}
				
			if(cantidad <= 0)
			{
				usada = true;
			}
		}
	}
	public Sprite atras;
	public Sprite normal;
	public GameObject boton;

	void Update ()
	{
		cantidadUsadas = cantidadTotal-cantidad;

		//ACTUALIZA EL VALOR DE CARTAS TOTALES
		if(cantidadTotal != PlayerPrefs.GetInt("card"+carta+"cantidad"))
		{
			print("VALOR A CAMBIAR");
			cantidadTotal = PlayerPrefs.GetInt("card"+carta+"cantidad");
			cantidad = cantidadTotal-cantidadUsadas;
		}
		//SI LA CARTA EXISTE Y TIENE MAS DE 1
		if(PlayerPrefs.GetInt("card"+carta) == 1 && cantidad >= 1)
		{
			usada = false;
			//print("SI EXISTE");
			boton.SetActive(true);
			nivel.text = "X "+cantidad.ToString();
		}else if(PlayerPrefs.GetInt("card"+carta) == 1 && cantidad == 0)//SI LA CARTA EXISTE PERO LAS TIENE TODAS USADAS
		{
			usada = true;
			print("VOLTEAR CARTA");
			/*nivel.text = "";
			boton.SetActive(false);
		
			GetComponent<Button>().enabled = false;
			imagen.sprite = atras;
			//GetComponent<Image>().color = new Color32(100,100,100,100);*/
		}

		//SI LA CARTA NO EXISTE
		if(PlayerPrefs.GetInt("card"+carta) == 0)
		{
			nivel.text = "";
			boton.SetActive(false);
			GetComponent<Button>().enabled = false;
			GetComponent<Image>().color = new Color32(100,100,100,100);
		}

		if(usada)
		{
			nivel.text = "";
			boton.SetActive(false);
			GetComponent<Button>().enabled = false;
			//GetComponent<Image>().color = new Color32(150,150,150,150);
			imagen.sprite = atras;
		}else if(PlayerPrefs.GetInt("card"+carta) == 1)
		{
			boton.SetActive(true);
			GetComponent<Button>().enabled = true;
			GetComponent<Image>().color = new Color32(255,255,255,255);
			imagen.sprite = normal;
		}
	}

	public AudioClip selec;

	public GameObject sell;
	public GameObject ventana;

	public void Sell ()
	{
		sell.GetComponent<vender>().nombre = carta;
		sell.GetComponent<vender>().cantidad = cantidad;
		sell.GetComponent<vender>().cantidadUsadas = cantidadUsadas;
		ventana.SetActive(true);
	}
}
