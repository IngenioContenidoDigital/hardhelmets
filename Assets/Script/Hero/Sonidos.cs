using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour {

	//DISPAROS
	public AudioClip pistola;
	public AudioClip escopeta;
	public AudioClip fusil;
	public AudioClip submetra;
	public AudioClip metra;
	public AudioClip mg;

	//AUDIO PLAYER

	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;

	//VOLUMEN
	float efectos;

	void Start ()
	{
		efectos = PlayerPrefs.GetFloat("efects");
		gritar();
	}

	//DISPAROS ------------------
	void gunshot ()
	{
		audio1.volume = efectos;
		audio1.clip = pistola;
		audio1.Play();
	}
	void metrashot()
	{
		audio1.volume = efectos;
		audio1.clip = metra;
		audio1.Play();
	}
	void shotshotgun()
	{
		audio1.volume = efectos;
		audio1.clip = escopeta;
		audio1.Play();
	}
	void submetrashot()
	{
		audio1.volume = efectos;
		audio1.clip = submetra;
		audio1.Play();
	}
	void fusilshot()
	{
		audio1.volume = efectos;
		audio1.clip = fusil;
		audio1.Play();
	}
	void mgshot()
	{
		audio1.volume = efectos;
		audio1.clip = mg;
		audio1.Play();
	}
	//AIRE
	void tiro()
	{
		if(Hero.arma == "escopeta")
		{
			audio1.volume = efectos;
			audio1.clip = escopeta;
			audio1.Play();
		}else if(Hero.arma == "fusil")
		{
			audio1.volume = efectos;
			audio1.clip = fusil;
			audio1.Play();
		}else if(Hero.arma == "submetra")
		{
			audio1.volume = efectos;
			audio1.clip = submetra;
			audio1.Play();
		}else if(Hero.arma == "metra")
		{
			audio1.volume = efectos;
			audio1.clip = metra;
			audio1.Play();
		}else
		{
			audio1.volume = efectos;
			audio1.clip = pistola;
			audio1.Play();
		}
	}

	//RECARGAS --------------------
	public AudioClip rfusil;
	public AudioClip rgun;
	public AudioClip rshotgun;
	public AudioClip rshotgun2;
	public AudioClip rsuelta;
	public AudioClip rmetra;
	public AudioClip rbusmetra;

	void fusilrecarga ()
	{
		audio2.volume = efectos;
		audio2.clip = rfusil;
		audio2.Play();
	}
	void suelta ()
	{
		audio2.volume = efectos;
		audio2.clip = rsuelta;
		audio2.Play();
	}
	void gunreload()
	{
		audio2.volume = efectos;
		audio2.clip = rgun;
		audio2.Play();
	}
	void lodshotgun()
	{
		audio2.volume = efectos;
		audio2.clip = rshotgun;
		audio2.Play();
	}
	void reshotgun()
	{
		audio2.volume = efectos;
		audio2.clip = rshotgun2;
		audio2.Play();
	}
	void metrareload()
	{
		if(Hero.arma == "metra")
		{
			audio2.volume = efectos;
			audio2.clip = rmetra;
			audio2.Play();
		}else
		{
			audio2.volume = efectos;
			audio2.clip = rbusmetra;
			audio2.Play();
		}
	}
	public AudioClip cuchillo1;
	public AudioClip cuchillo2;
	public AudioClip reloadmg;
	public AudioClip inmortero;
	public AudioClip outmortero;
	void cuchillo()
	{
		audio1.volume = efectos;
		audio1.clip = cuchillo1;
		audio1.Play();
	}
	void cuchillob()
	{
		audio1.volume = efectos;
		audio1.clip = cuchillo2;
		audio1.Play();
	}
	void mgreload()
	{
		audio2.volume = efectos;
		audio2.clip = reloadmg;
		audio2.Play();
	}
	void morteroin()
	{
		audio1.volume = efectos;
		audio1.clip = inmortero;
		audio1.Play();
	}
	void morteroout()
	{
		audio1.volume = efectos;
		audio1.clip = outmortero;
		audio1.Play();
	}
	//VOZ -----------------------
	public AudioClip[] dead;
	public AudioClip[] attack;
	public AudioClip[] damage;
	public AudioClip[] idle;
	public AudioClip[] muerto;
	public AudioClip[] xx;

	void Smuerto()
	{
		audio3.volume = efectos;
		audio3.clip = dead[Random.Range(0,dead.Length)];
		audio3.Play();
	}
	void Sattack()
	{
		audio3.volume = efectos;
		audio3.clip = attack[Random.Range(0,attack.Length)];
		audio3.Play();
	}
	void Sdamage()
	{
		audio3.volume = efectos;
		audio3.clip = damage[Random.Range(0,damage.Length)];
		audio3.Play();
	}
	void Sidle()
	{
		audio3.volume = efectos;
		audio3.clip = idle[Random.Range(0,idle.Length)];
		audio3.Play();
	}
	void Smuertob()
	{
		audio3.volume = efectos;
		audio3.clip = muerto[Random.Range(0,muerto.Length)];
		audio3.Play();
	}
	void Sxx()
	{
		audio3.volume = efectos;
		audio3.clip = xx[Random.Range(0,xx.Length)];
		audio3.Play();
	}
	public AudioClip[] grito;

	public void gritar ()
	{
		audio3.volume = efectos;
		audio3.clip = grito[Random.Range(0,grito.Length)];
		audio3.Play();
	}
}
