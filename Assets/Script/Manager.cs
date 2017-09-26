﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public UnityEngine.UI.Text balas;
	public UnityEngine.UI.Text granadas;

	public static bool lenta;

	public AudioClip matrix;
	public AudioSource audioM;

	public GameObject Player;

	public UnityEngine.UI.Image mano;
	public UnityEngine.UI.Image espalda;

	public Sprite nada;

	public Sprite pistola;
	public Sprite fusil;
	public Sprite escopeta;
	public Sprite submetra;
	public Sprite metra;
	public Sprite sniper;
	public Sprite llamas;

	public Sprite pistola2;
	public Sprite fusil2;
	public Sprite escopeta2;
	public Sprite submetra2;
	public Sprite metra2;
	public Sprite sniper2;
	public Sprite llamas2;
	// Use this for initialization

	//VOLUMEN
	float efectos;

	void Start ()
	{
		efectos = PlayerPrefs.GetFloat("efects");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Player.GetComponent<CustomFinal>().armaEspalda == "fusil2")
		{
			espalda.sprite = fusil2;
		}else if(Player.GetComponent<CustomFinal>().armaEspalda == "escopeta2")
		{
			espalda.sprite = escopeta2;
		}else if(Player.GetComponent<CustomFinal>().armaEspalda == "submetra2")
		{
			espalda.sprite = submetra2;
		}else if(Player.GetComponent<CustomFinal>().armaEspalda == "metra2")
		{
			espalda.sprite = metra2;
		}else if(Player.GetComponent<CustomFinal>().armaEspalda == "sniper2")
		{
			espalda.sprite = sniper2;
		}else if(Player.GetComponent<CustomFinal>().armaEspalda == "lansallamas2")
		{
			espalda.sprite = llamas2;
		}else
		{
			espalda.sprite = nada;
		}

		if(Player.GetComponent<CustomFinal>().armaMano == "gun")
		{
			mano.sprite = pistola;
		}else if(Player.GetComponent<CustomFinal>().armaMano == "fusil")
		{
			mano.sprite = fusil;
		}else if(Player.GetComponent<CustomFinal>().armaMano == "escopeta")
		{
			mano.sprite = escopeta;
		}else if(Player.GetComponent<CustomFinal>().armaMano == "submetra")
		{
			mano.sprite = submetra;
		}else if(Player.GetComponent<CustomFinal>().armaMano == "metra")
		{
			mano.sprite = metra;
		}else if(Player.GetComponent<CustomFinal>().armaMano == "sniper")
		{
			mano.sprite = sniper;
		}else if(Player.GetComponent<CustomFinal>().armaMano == "lansallamas")
		{
			mano.sprite = llamas;
		}else
		{
			mano.sprite = pistola;
		}

		//CAMARA LENTA
		if(lenta)
		{
			lenta = false;
			audioM.volume = efectos;
			audioM.clip = matrix;
			audioM.Play();
			//GetComponent<AudioSource>().pitch = 0.5f;
			Time.timeScale = 0.5f;
			StartCoroutine(espera());
		}

		if(Hero.arma2)
		{
			balas.text = "∞"+"/"+Hero.balas.ToString();
		}else
		{
			balas.text = ""+Hero.balasTotales.ToString()+"/"+Hero.balas.ToString();
		}

		granadas.text = ""+Hero.granadas.ToString();
	}

	IEnumerator espera ()
	{
		yield return new WaitForSeconds(1);
		Time.timeScale = 1;
	}
}
