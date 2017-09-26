using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mascara : MonoBehaviour{

	public static int item;

	//COMPRAS
	public static string compra;
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

	//PRUEBA PERZONALIZACION SOLDADO
	public string mascara;

	public GameObject atras;
	public GameObject adelante;
	public static bool activo;

	// Use this for initialization
	void Start ()
	{
		mascara = PlayerPrefs.GetString("mascara");

		if(mascara == "")
		{
			item = 1;
		}
		if(mascara == "Mascara")
		{
			item = 2;
		}
		if(mascara == "Mascara2")
		{
			item = 3;
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
		if(item > 3)
		{
			item = 3;
		}

		if(item == 1)
		{
			compra = "";
			costoC = 0;
			costoD = 0;
		}
		if(item == 2)
		{
			compra = "Mascara";
			costoC = 0;
			costoD = 0;
		}
		if(item == 3)
		{
			compra = "Mascara2";
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

		if(PlayerPrefs.GetString("mascara") == compra)
		{
			selecB.SetActive(false);
		}

		//--------------SET ON CUSTODE-----------
		customTow.mascara = compra;
	}

	public void prev ()
	{
		s_cambia();
		item -= 1;
	}

	public void next ()
	{
		s_cambia();
		item += 1;
	}

	public void select ()
	{
		PlayerPrefs.SetString("mascara",compra);
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
		Casco.activo = false;
		Chaleco.activo = false;
		Cinturon.activo = false;
		Cuello.activo = false;
		Maleta.activo = false;
		Cara.activo = false;
		Uniform.activo = false;
	}
	//SONIDOS
	public AudioClip comprado;
	public AudioClip cambio;

	public void s_cambia ()
	{
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = cambio;
		GetComponent<AudioSource>().Play();
	}

	public void s_compra ()
	{
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = comprado;
		GetComponent<AudioSource>().Play();
	}
}