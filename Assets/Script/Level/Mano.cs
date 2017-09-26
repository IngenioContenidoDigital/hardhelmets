using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano : MonoBehaviour {

	public int uno;
	public int dos;
	public int tres;
	public int cuatro;
	public int cinco;
	public int seis;
	public int siete;
	public int ocho;
	public int nueve;
	public int diez;
	//CANTIDAD CARTAS A LLEVAR
	public int unoC;
	public int dosC;
	public int tresC;
	public int cuatroC;
	public int cincoC;
	public int seisC;
	public int sieteC;
	public int ochoC;
	public int nueveC;
	public int diezC;

	public GameObject listo;

	public UnityEngine.UI.Image primera;
	public UnityEngine.UI.Image segunda;
	public UnityEngine.UI.Image tercera;
	public UnityEngine.UI.Image cuarta;
	public UnityEngine.UI.Image quinta;
	public UnityEngine.UI.Image sexta;
	public UnityEngine.UI.Image septima;
	public UnityEngine.UI.Image octava;
	public UnityEngine.UI.Image novena;
	public UnityEngine.UI.Image decima;


	public GameObject vender;

	void Start ()
	{
		
	}

	void Update ()
	{
		if(Cartas.uno != 0 && Cartas.dos != 0 && Cartas.tres != 0 )//&& Cartas.cuatro != 0 && Cartas.cinco != 0 && Cartas.seis != 0 && Cartas.siete != 0 && Cartas.ocho != 0 && Cartas.nueve != 0 && Cartas.diez != 0)
		{
			listo.SetActive(true);
		}else
		{
			listo.SetActive(false);
		}
	}
	public AudioClip selec;
	public void finalizar ()
	{
		uno = Cartas.uno;
		dos = Cartas.dos;
		tres = Cartas.tres;
		cuatro = Cartas.cuatro;
		cinco = Cartas.cinco;
		seis = Cartas.seis;
		siete = Cartas.siete;
		ocho = Cartas.ocho;
		nueve = Cartas.nueve;
		diez = Cartas.diez;

		unoC = Cartas.unoCantidad;
		dosC = Cartas.dosCantidad;
		tresC = Cartas.tresCantidad;
		cuatroC = Cartas.cuatroCantidad;
		cincoC = Cartas.cincoCantidad;
		seisC = Cartas.seisCantidad;
		sieteC = Cartas.sieteCantidad;
		ochoC = Cartas.ochoCantidad;
		nueveC = Cartas.nueveCantidad;
		diezC = Cartas.diezCantidad;

		PlayerPrefs.SetInt("Mano1", uno);
		PlayerPrefs.SetInt("Mano2", dos);
		PlayerPrefs.SetInt("Mano3", tres);
		PlayerPrefs.SetInt("Mano4", cuatro);
		PlayerPrefs.SetInt("Mano5", cinco);
		PlayerPrefs.SetInt("Mano6", seis);
		PlayerPrefs.SetInt("Mano7", siete);
		PlayerPrefs.SetInt("Mano8", ocho);
		PlayerPrefs.SetInt("Mano9", nueve);
		PlayerPrefs.SetInt("Mano10", diez);

		PlayerPrefs.SetInt("Mano1cantidad", unoC);
		PlayerPrefs.SetInt("Mano2cantidad", dosC);
		PlayerPrefs.SetInt("Mano3cantidad", tresC);
		PlayerPrefs.SetInt("Mano4cantidad", cuatroC);
		PlayerPrefs.SetInt("Mano5cantidad", cincoC);
		PlayerPrefs.SetInt("Mano6cantidad", seisC);
		PlayerPrefs.SetInt("Mano7cantidad", sieteC);
		PlayerPrefs.SetInt("Mano8cantidad", ochoC);
		PlayerPrefs.SetInt("Mano9cantidad", nueveC);
		PlayerPrefs.SetInt("Mano10cantidad", diezC);

		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = selec;
		GetComponent<AudioSource>().Play();
	}
}
