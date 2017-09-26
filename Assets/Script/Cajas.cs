using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.EventSystems;
using Spine.Unity;

public class Cajas : MonoBehaviour {

	public static int abiertas;
	public GameObject regresar;
	public GameObject otra;

	public int deb1;
	public int deb2;
	public int deb3;
	public int deb4;
	public int deb5;
	public int deb6;

	bool listo1;
	bool listo2;
	bool listo3;
	bool listo4;
	bool listo5;
	bool listo6;

	public GameObject card1;
	public GameObject card2;
	public GameObject card3;
	public GameObject card4;
	public GameObject card5;
	public GameObject card6;

	//CANTIDAD DE CARTAS
	int carta1;
	int carta2;
	int carta3;
	int carta4;
	int carta5;
	int carta6;

	//DE QUE A QUE CARTA PUEDE DESTAPAR
	public int minima;
	public int maxima;//1,2,7,8,9,11,15

	int cajas;
	public UnityEngine.UI.Text cajasT;

	// Use this for initialization
	void Start ()
	{
		abiertas = 0;
		deb1 = Random.Range(minima,maxima);
		deb2 = Random.Range(minima,maxima);
		deb3 = Random.Range(minima,maxima);
		deb4 = Random.Range(minima,maxima);
		deb5 = Random.Range(minima,maxima);
		deb6 = Random.Range(minima,maxima);
		listo1 = true;

		cajas = PlayerPrefs.GetInt("caja1");
	}
	
	// Update is called once per frame
	void Update ()
	{
		cajasT.text = cajas.ToString();
		PlayerPrefs.SetInt("caja1", cajas);
		if(listo1)
		{
			print("TODOS DEBERIAN SER DIFERENTES");
			card1.GetComponent<skinCarta>().skinsToCombine[0] = deb1.ToString();
			card2.GetComponent<skinCarta>().skinsToCombine[0] = deb2.ToString();
			card3.GetComponent<skinCarta>().skinsToCombine[0] = deb3.ToString();
			card4.GetComponent<skinCarta>().skinsToCombine[0] = deb4.ToString();
			card5.GetComponent<skinCarta>().skinsToCombine[0] = deb5.ToString();
			card6.GetComponent<skinCarta>().skinsToCombine[0] = deb6.ToString();

			PlayerPrefs.SetInt("card"+deb1, 1);
			PlayerPrefs.SetInt("card"+deb2, 1);
			PlayerPrefs.SetInt("card"+deb3, 1);
			PlayerPrefs.SetInt("card"+deb4, 1);
			PlayerPrefs.SetInt("card"+deb5, 1);
			PlayerPrefs.SetInt("card"+deb6, 1);

			//CANTIDAD DE CARTAS
			carta1 = PlayerPrefs.GetInt("card"+deb1+"cantidad");
			PlayerPrefs.SetInt("card"+deb1+"cantidad", carta1+1);
			carta2 = PlayerPrefs.GetInt("card"+deb2+"cantidad");
			PlayerPrefs.SetInt("card"+deb2+"cantidad", carta2+1);
			carta3 = PlayerPrefs.GetInt("card"+deb3+"cantidad");
			PlayerPrefs.SetInt("card"+deb3+"cantidad", carta3+1);
			carta4 = PlayerPrefs.GetInt("card"+deb4+"cantidad");
			PlayerPrefs.SetInt("card"+deb4+"cantidad", carta4+1);
			carta5 = PlayerPrefs.GetInt("card"+deb5+"cantidad");
			PlayerPrefs.SetInt("card"+deb5+"cantidad", carta5+1);
			carta6 = PlayerPrefs.GetInt("card"+deb6+"cantidad");
			PlayerPrefs.SetInt("card"+deb6+"cantidad", carta6+1);

			listo1 = false;
		}
		/*if(listo1)
		{
			deb2 = Random.Range(1,19);
			if(deb2 == deb1)
			{
				deb2 = Random.Range(1,19);
			}else
			{
				listo2 = true;
				listo1 = false;
			}
		}
		if(listo2)
		{
			deb3 = Random.Range(1,19);
			if(deb3 == deb1 || deb3 == deb2)
			{
				deb3 = Random.Range(1,19);
			}else
			{
				listo3 = true;
				listo2 = false;
			}
		}
		if(listo3)
		{
			deb4 = Random.Range(1,19);
			if(deb4 == deb1 || deb4 == deb2 || deb4 == deb3)
			{
				deb4 = Random.Range(1,19);
			}else
			{
				listo4 = true;
				listo3 = false;
			}
		}
		if(listo4)
		{
			deb5 = Random.Range(1,19);
			if(deb5 == deb1 || deb5 == deb2 || deb5 == deb3 || deb5 == deb4)
			{
				deb5 = Random.Range(1,19);
			}else
			{
				listo5 = true;
				listo4 = false;
			}
		}
		if(listo5)
		{
			deb6 = Random.Range(1,19);
			if(deb6 == deb1 || deb6 == deb2 || deb6 == deb3 || deb6 == deb4 || deb6 == deb5)
			{
				deb6 = Random.Range(1,19);
			}else
			{
				print("TODOS DEBERIAN SER DIFERENTES");
				card1.GetComponent<skinCarta>().skinsToCombine[0] = deb1.ToString();
				card2.GetComponent<skinCarta>().skinsToCombine[0] = deb2.ToString();
				card3.GetComponent<skinCarta>().skinsToCombine[0] = deb3.ToString();
				card4.GetComponent<skinCarta>().skinsToCombine[0] = deb4.ToString();
				card5.GetComponent<skinCarta>().skinsToCombine[0] = deb5.ToString();
				card6.GetComponent<skinCarta>().skinsToCombine[0] = deb6.ToString();

				PlayerPrefs.SetInt("card"+deb1, 1);
				PlayerPrefs.SetInt("card"+deb2, 1);
				PlayerPrefs.SetInt("card"+deb3, 1);
				PlayerPrefs.SetInt("card"+deb4, 1);
				PlayerPrefs.SetInt("card"+deb5, 1);
				PlayerPrefs.SetInt("card"+deb6, 1);

				//CANTIDAD DE CARTAS
				carta1 = PlayerPrefs.GetInt("card"+deb1+"cantidad");
				carta2 = PlayerPrefs.GetInt("card"+deb2+"cantidad");
				carta3 = PlayerPrefs.GetInt("card"+deb3+"cantidad");
				carta4 = PlayerPrefs.GetInt("card"+deb4+"cantidad");
				carta5 = PlayerPrefs.GetInt("card"+deb5+"cantidad");
				carta6 = PlayerPrefs.GetInt("card"+deb6+"cantidad");
				//SET CANTIDAD DE CARTAS

				PlayerPrefs.SetInt("card"+deb1+"cantidad", carta1+1);
				PlayerPrefs.SetInt("card"+deb2+"cantidad", carta2+1);
				PlayerPrefs.SetInt("card"+deb3+"cantidad", carta3+1);
				PlayerPrefs.SetInt("card"+deb4+"cantidad", carta4+1);
				PlayerPrefs.SetInt("card"+deb5+"cantidad", carta5+1);
				PlayerPrefs.SetInt("card"+deb6+"cantidad", carta6+1);

				listo5 = false;
			}
		}*/
			

		if(abiertas >= 6)
		{
			regresar.SetActive(true);
		}
		if(abiertas >= 6 && cajas >= 1)
		{
			regresar.SetActive(true);
			otra.SetActive(true);
		}
	}

	public void animar ()
	{
		GetComponent<PlayableDirector>().Play();
	}

	public void Reopen()
	{
		if(cajas >= 1)
		{
			//otra.SetActive(false);
			cajas -= 1;
			loading.nombre = "cajas";
			Application.LoadLevel("Load");
		}
	}

	public void salir ()
	{
		CamMenu.segundo = true;
		Application.LoadLevel("Menu");
	}
}
