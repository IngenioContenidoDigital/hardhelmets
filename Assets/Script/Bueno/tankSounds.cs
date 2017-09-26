using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankSounds : MonoBehaviour {

	//DISPAROS
	public AudioClip acelera;
	public AudioClip desacelera;
	public AudioClip maneja;
	public AudioClip motor;
	public AudioClip prende;
	public AudioClip apaga;

	//SOURCE
	public AudioSource audio1;
	public AudioSource audio2;

	//VOLUMEN
	float efectos;

	void Start ()
	{
		efectos = PlayerPrefs.GetFloat("efects");
	}

	void Update ()
	{
		
	}

	void Accelerate()
	{
		audio1.volume = efectos;
		audio1.clip = acelera;
		audio1.Play();
		audio1.loop = false;
	}

	void Decelerate()
	{
		audio1.volume = efectos;
		audio1.clip = desacelera;
		audio1.Play();
		audio1.loop = false;
	}

	void drive()
	{
		audio1.volume = efectos;
		audio1.clip = maneja;
		audio1.Play();
		audio1.loop = true;
	}

	void TankEngine()
	{
		audio2.volume = efectos;
		audio2.clip = motor;
		audio2.Play();
		audio2.loop = true;
	}

	void TurnOff()
	{
		audio1.volume = efectos;
		audio1.clip = apaga;
		audio1.Play();
		audio1.loop = false;
	}

	void TurnOn()
	{
		audio1.volume = efectos;
		audio1.clip = prende;
		audio1.Play();
		audio1.loop = false;
	}
}
