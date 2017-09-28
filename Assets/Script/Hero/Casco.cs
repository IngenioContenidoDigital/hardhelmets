using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casco : MonoBehaviour{

	public static int item;

	//COMPRAS
	public string compra;
	//BOTON SELECT SI ESTA COMPRADO
	public GameObject selecB;
	//BOTON COMPRA SI NO ESTA COMPRADO
	public GameObject compM;
	public GameObject compD;

	//CREDITOS DISPONIBLE
	public int Coins;
	public int Diamonds;


	//COSTO DE ITEM
	int costoC;
	int costoD;
	public UnityEngine.UI.Text costoCoins;
	public UnityEngine.UI.Text CostoDiamonds;

	public GameObject atras;
	public GameObject adelante;
	public static bool activo;

	//PRUEBA PERZONALIZACION SOLDADO
	public string casco;

	// Use this for initialization
	void Start ()
	{
		casco = PlayerPrefs.GetString("casco");

		if(casco == "Casco1")
		{
			item = 1;
		}
		if(casco == "Casco2")
		{
			item = 2;
		}
		if(casco == "Casco3")
		{
			item = 3;
		}
		if(casco == "Casco4")
		{
			item = 4;
		}
		//ESPECIALES
		if(casco == "sombrero")
		{
			item = 5;
		}
		if(casco == "sombrero2")
		{
			item = 6;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(activo)
		{
			atras.SetActive(true);
			adelante.SetActive(true);
		}else
		{
			atras.SetActive(false);
			adelante.SetActive(false);
		}

		Coins = dinero.Coins;
		Diamonds = dinero.Diamonds;
		//COSTO DE ITEM
		costoCoins.text = costoC.ToString();
		CostoDiamonds.text =  costoD.ToString();

		if(item < 1)
		{
			item = 1;
		}
		if(item > 7)
		{
			item = 7;
		}

		if(item == 1)
		{
			compra = "Casco1";
			costoC = 0;
			costoD = 0;
		}
		if(item == 2)
		{
			compra = "Casco2";
			costoC = 1000;
			costoD = 10;
		}
		if(item == 3)
		{
			compra = "Casco3";
			costoC = 0;
			costoD = 0;
		}
		if(item == 4)
		{
			compra = "Casco4";
			costoC = 0;
			costoD = 0;
		}
		if(item == 5)
		{
			compra = "sombrero";
			costoC = 0;
			costoD = 0;
		}
		if(item == 6)
		{
			compra = "sombrero2";
			costoC = 0;
			costoD = 0;
		}
		//COMPRAS
		//PlayerPrefs.SetInt(compra,0);
		if(PlayerPrefs.GetInt(compra) == 1 || costoC == 0 || costoD == 0)
		{
			compM.SetActive(false);
			compD.SetActive(false);
			selecB.SetActive(true);
		}else
		{
			compM.SetActive(true);
			compD.SetActive(true);
			selecB.SetActive(false);
		}

		if(PlayerPrefs.GetString("casco") == compra)
		{
			selecB.SetActive(false);
		}

		//--------------SET ON CUSTODE-----------
		customTow.casco = compra;
	}

	public void prev ()
	{
		if(item == 1)
		{
			item = 6;
		}else
		{
			item -= 1;
		}
		s_cambia();
	}

	public void next ()
	{
		if(item == 6)
		{
			item = 1;
		}else
		{
			item += 1;
		}
		s_cambia();
	}

	public void select ()
	{
		PlayerPrefs.SetString("casco",compra);
	}
	public void GLOBAL ()
	{
		s_compra();

		PlayerPrefs.SetString("casco",compra);

		PlayerPrefs.SetString("cara",Cara.compra);
		PlayerPrefs.SetString("chaleco",Chaleco.compra);
		//PlayerPrefs.SetString("cinturon",Cinturon.compra);
		PlayerPrefs.SetString("cuello",Cuello.compra);
		PlayerPrefs.SetString("maleta",Maleta.compra);
		PlayerPrefs.SetString("uniforme",Uniform.compra);
		PlayerPrefs.SetString("mascara",Mascara.compra);
	}
	public void SALIR ()
	{
		CamMenu.segundo = true;
		Application.LoadLevel("Menu");
	}
	//COMPRAR CON COINS
	public void comprarC ()
	{
		if(Coins >= costoC)
		{
			Coins -= costoC;
			PlayerPrefs.SetInt("Coins",Coins);
			s_compra();
			PlayerPrefs.SetInt(compra,1);
		}else
		{
			print("No alcanza la plata");
		}
	}
	//COMPRAR CON DIAMANTES
	public void comprarD ()
	{
		if(Diamonds >= costoD)
		{
			Diamonds -= costoD;
			PlayerPrefs.SetInt("Diamonds",Diamonds);
			s_compra();
			PlayerPrefs.SetInt(compra,1);
		}else
		{
			print("No alcanza la plata");
		}
	}
	//SELECCIONAR
	public void activar ()
	{
		CamCustom.uno = false;
		CamCustom.dos = false;
		CamCustom.tres = true;

		activo = true;
		Cara.activo = false;
		Chaleco.activo = false;
		Cinturon.activo = false;
		Cuello.activo = false;
		Maleta.activo = false;
		Mascara.activo = false;
		Uniform.activo = false;
	}

	//SONIDOS
	public AudioClip comprado;
	public AudioClip cambio;

	public void s_compra ()
	{
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = comprado;
		GetComponent<AudioSource>().Play();
	}

	public void s_cambia ()
	{
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = cambio;
		GetComponent<AudioSource>().Play();
	}
}