using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine.Unity.Modules.AttachmentTools; 

public class CustomFinal : MonoBehaviour {

	[SpineSkin]
	public List<string> skinsToCombine;

	Spine.Skin combinedSkin;

	public string armaMano;
	public string armaEspalda;
	string cambio;
	string votar;
	//ARMAS
	public GameObject escopeta;
	public GameObject fusil;
	public GameObject submetra;
	public GameObject metra;
	public GameObject lansallamas;
	public GameObject sniper;
	//INSERVIBLES
	public GameObject escopeta2;
	public GameObject fusil2;
	public GameObject submetra2;
	public GameObject metra2;
	public GameObject lansallamas2;
	public GameObject sniper2;
	public Transform bulletSpawn;

	public Animator animator;

	public bool segunda = true;

	/*
	public GameObject RecojeGun;
	public string agarrar;
	bool pensar;
	*/

	void Start ()
	{
		
		//PlayerPrefs.SetString("casco", "casco1");
		//PlayerPrefs.SetString("cuerpo", "");
		//PlayerPrefs.SetString("uniforme","");
		//PlayerPrefs.SetString("cuello","");
		//PlayerPrefs.SetString("cinturon", "");
		//PlayerPrefs.SetString("chaleco", "");
		//PlayerPrefs.SetString("maleta", "Maleta");

		skinsToCombine[0] = PlayerPrefs.GetString("casco");
		skinsToCombine[1] = PlayerPrefs.GetString("cara");
		skinsToCombine[2] = PlayerPrefs.GetString("mascara");
		//skinsToCombine[1] = PlayerPrefs.GetString("cuerpo");
		skinsToCombine[3] = PlayerPrefs.GetString("uniforme");
		skinsToCombine[4] = PlayerPrefs.GetString("cuello");
		//skinsToCombine[4] = PlayerPrefs.GetString("cinturon");
		skinsToCombine[5] = PlayerPrefs.GetString("chaleco");
		skinsToCombine[6] = PlayerPrefs.GetString("maleta");
		skinsToCombine[7] = "";
		skinsToCombine[8] = "gun";

		var skeletonComponent = GetComponent<ISkeletonComponent>();
		if (skeletonComponent == null) return;
		var skeleton = skeletonComponent.Skeleton;
		if (skeleton == null) return;

		combinedSkin = combinedSkin ?? new Spine.Skin("combined");
		combinedSkin.Clear();
		foreach (var skinName in skinsToCombine) {
			var skin = skeleton.Data.FindSkin(skinName);
			if (skin != null) combinedSkin.Append(skin);
		}

		skeleton.SetSkin(combinedSkin);
		skeleton.SetToSetupPose();
		var animationStateComponent = skeletonComponent as IAnimationStateComponent;
		if (animationStateComponent != null) animationStateComponent.AnimationState.Apply(skeleton);
	}

	void FixedUpdate ()
	{
		Hero.arma = armaMano;
		if(Input.GetButtonUp("INTERAMBIO") && armaEspalda != "" && segunda && !animator.GetBool("cuchillando") && !animator.GetCurrentAnimatorStateInfo(0).IsName("backJump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasShot") && !animator.GetCurrentAnimatorStateInfo(0).IsName("cae"))
		{
			Hero.rafaga = true;
			segunda = false;
			StartCoroutine(espera());
			cambio = armaMano;
			Hero.rafaga = true;
			Hero.arma2 = false;
			animator.SetBool("cambio", true);
			if(armaEspalda == "escopeta2")
			{
				armaEspalda = cambio+"2";
				armaMano = "escopeta";
			}else if(armaEspalda == "fusil2")
			{
				armaEspalda = cambio+"2";
				armaMano = "fusil";
			}else if(armaEspalda == "submetra2")
			{
				armaEspalda = cambio+"2";
				armaMano = "submetra";
			}else if(armaEspalda == "metra2")
			{
				armaEspalda = cambio+"2";
				armaMano = "metra";
			}else if(armaEspalda == "lansallamas2")
			{
				armaEspalda = cambio+"2";
				armaMano = "lansallamas";
			}else if(armaEspalda == "sniper2")
			{
				armaEspalda = cambio+"2";
				armaMano = "sniper";
			}
		}
/*
		if(Input.GetButtonUp("G") && armaMano != "")
		{
			if(skinsToCombine[8] == "pistola")
			{
				
				Hero.arma2 = false;
				skinsToCombine[8] = armaMano;
			}else
			{
				Hero.arma2 = true;
				skinsToCombine[8] = "pistola";
			}
		}
		if(Hero.arma2)
		{
			skinsToCombine[8] = "pistola";
		}
*/

		//PONE PISTOLA
		if(armaMano == "escopeta" && Hero.balaEscopeta <= 0 && Hero.EscopetaTotales <= 0 && armaEspalda != "")
		{
			soltar();
			if(armaEspalda == "fusil2")
			{
				armaMano = "fusil";
				armaEspalda = "";
			}else if(armaEspalda == "submetra2")
			{
				armaMano = "submetra";
				armaEspalda = "";
			}else if(armaEspalda == "metra2")
			{
				armaMano = "metra";
				armaEspalda = "";
			}else if(armaEspalda == "lansallamas2")
			{
				armaMano = "lansallamas";
				armaEspalda = "";
			}else if(armaEspalda == "sniper2")
			{
				armaMano = "sniper";
				armaEspalda = "";
			}
		
		}else if(armaMano == "escopeta" && Hero.balaEscopeta <= 0 && Hero.EscopetaTotales <= 0 && armaEspalda == "")
		{
			soltar();
			skinsToCombine[8] = "gun";
			armaMano = "";
			armaEspalda = "";
		}
		if(armaMano == "fusil" && Hero.balaFusil <= 0 && Hero.FusilTotales <= 0 && armaEspalda != "")
		{
			soltar();
			if(armaEspalda == "escopeta2")
			{
				armaMano = "escopeta";
				armaEspalda = "";
			}else if(armaEspalda == "submetra2")
			{
				armaMano = "submetra";
				armaEspalda = "";
			}else if(armaEspalda == "metra2")
			{
				armaMano = "metra";
				armaEspalda = "";
			}else if(armaEspalda == "lansallamas2")
			{
				armaMano = "lansallamas";
				armaEspalda = "";
			}else if(armaEspalda == "sniper2")
			{
				armaMano = "sniper";
				armaEspalda = "";
			}
		}else if(armaMano == "fusil" && Hero.balaFusil <= 0 && Hero.FusilTotales <= 0 && armaEspalda == "")
		{
			soltar();
			skinsToCombine[8] = "gun";
			armaMano = "";
			armaEspalda = "";
		}
		if(armaMano == "submetra" && Hero.balaSubmetra <= 0 && Hero.SubmetraTotales <= 0 && armaEspalda != "")
		{
			soltar();
			if(armaEspalda == "fusil2")
			{
				armaMano = "fusil";
				armaEspalda = "";
			}else if(armaEspalda == "escopeta2")
			{
				armaMano = "escopeta";
				armaEspalda = "";
			}else if(armaEspalda == "metra2")
			{
				armaMano = "metra";
				armaEspalda = "";
			}else if(armaEspalda == "lansallamas2")
			{
				armaMano = "lansallamas";
				armaEspalda = "";
			}else if(armaEspalda == "sniper2")
			{
				armaMano = "sniper";
				armaEspalda = "";
			}
		}else if(armaMano == "submetra" && Hero.balaSubmetra <= 0 && Hero.SubmetraTotales <= 0 && armaEspalda == "")
		{
			soltar();
			skinsToCombine[8] = "gun";
			armaMano = "";
			armaEspalda = "";
		}
		if(armaMano == "metra" && Hero.balaMetra <= 0 && Hero.MetraTotales <= 0 && armaEspalda != "")
		{
			soltar();
			if(armaEspalda == "fusil2")
			{
				armaMano = "fusil";
				armaEspalda = "";
			}else if(armaEspalda == "submetra2")
			{
				armaMano = "submetra";
				armaEspalda = "";
			}else if(armaEspalda == "escopeta2")
			{
				armaMano = "escopeta";
				armaEspalda = "";
			}else if(armaEspalda == "lansallamas2")
			{
				armaMano = "lansallamas";
				armaEspalda = "";
			}else if(armaEspalda == "sniper2")
			{
				armaMano = "sniper";
				armaEspalda = "";
			}
		}else if(armaMano == "metra" && Hero.balaMetra <= 0 && Hero.MetraTotales <= 0 && armaEspalda == "")
		{
			soltar();
			skinsToCombine[8] = "gun";
			armaMano = "";
			armaEspalda = "";
		}
		if(armaMano == "lansallamas" && Hero.balaLlamas <= 0 && Hero.LlamasTotales <= 0 && armaEspalda != "")
		{
			Hero.lansallamas = false;
			soltar();
			if(armaEspalda == "fusil2")
			{
				armaMano = "fusil";
				armaEspalda = "";
			}else if(armaEspalda == "submetra2")
			{
				armaMano = "submetra";
				armaEspalda = "";
			}else if(armaEspalda == "escopeta2")
			{
				armaMano = "escopeta";
				armaEspalda = "";
			}else if(armaEspalda == "metra2")
			{
				armaMano = "metra";
				armaEspalda = "";
			}else if(armaEspalda == "sniper2")
			{
				armaMano = "sniper";
				armaEspalda = "";
			}
		}else if(armaMano == "lansallamas" && Hero.balaLlamas <= 0 && Hero.LlamasTotales <= 0 && armaEspalda == "")
		{
			soltar();
			Hero.lansallamas = false;
			skinsToCombine[8] = "gun";
			armaMano = "";
			armaEspalda = "";
		}
		if(armaMano == "sniper" && Hero.balaSniper <= 0 && Hero.SniperTotales <= 0 && armaEspalda != "")
		{
			soltar();
			if(armaEspalda == "fusil2")
			{
				armaMano = "fusil";
				armaEspalda = "";
			}else if(armaEspalda == "submetra2")
			{
				armaMano = "submetra";
				armaEspalda = "";
			}else if(armaEspalda == "escopeta2")
			{
				armaMano = "escopeta";
				armaEspalda = "";
			}else if(armaEspalda == "metra2")
			{
				armaMano = "metra";
				armaEspalda = "";
			}else if(armaEspalda == "lansallamas2")
			{
				armaMano = "lansallamas";
				armaEspalda = "";
			}
		}else if(armaMano == "sniper" && Hero.balaSniper <= 0 && Hero.SniperTotales <= 0 && armaEspalda == "")
		{
			soltar();
			skinsToCombine[8] = "gun";
			armaMano = "";
			armaEspalda = "";
		}

		if(armaMano == "")
		{
			Hero.arma2 = true;
			skinsToCombine[8] = "gun";
		}else
		{
			Hero.arma2 = false;
			skinsToCombine[8] = armaMano;
		}
		if(armaEspalda == "")
		{
			skinsToCombine[7] = "";
		}else
		{
			skinsToCombine[7] = armaEspalda;
		}
		if(armaMano == "lansallamas")
		{
			Hero.lansallamas = true;
		}else
		{
			Hero.lansallamas = false;
		}
		if(armaMano == "sniper")
		{
			Hero.sniper = true;
		}else
		{
			Hero.sniper = false;
		}


		var skeletonComponent = GetComponent<ISkeletonComponent>();
		if (skeletonComponent == null) return;
		var skeleton = skeletonComponent.Skeleton;
		if (skeleton == null) return;

		combinedSkin = combinedSkin ?? new Spine.Skin("combined");
		combinedSkin.Clear();
		foreach (var skinName in skinsToCombine) {
			var skin = skeleton.Data.FindSkin(skinName);
			if (skin != null) combinedSkin.Append(skin);
		}

		skeleton.SetSkin(combinedSkin);
		skeleton.SetToSetupPose();
		var animationStateComponent = skeletonComponent as IAnimationStateComponent;
		if (animationStateComponent != null) animationStateComponent.AnimationState.Apply(skeleton);
	}
	IEnumerator espera()
	{
		yield return new WaitForSeconds(0.3f);
		segunda = true;
	}
		
	void RecogeGun ()
	{
		skinsToCombine[8] = armaMano;
		if(votar == "escopeta")
		{
			var arma = (GameObject)Instantiate(escopeta, bulletSpawn.position, bulletSpawn.rotation); 
			arma.GetComponent<Rigidbody>().velocity = arma.transform.up * 20;
			arma.GetComponent<Rigidbody>().velocity = arma.transform.right * 3;
		}
		if(votar == "fusil")
		{
			var arma = (GameObject)Instantiate(fusil, bulletSpawn.position, bulletSpawn.rotation); 
			arma.GetComponent<Rigidbody>().velocity = arma.transform.up * 20;
			arma.GetComponent<Rigidbody>().velocity = arma.transform.right * 3;
		}
		if(votar == "submetra")
		{
			var arma = (GameObject)Instantiate(submetra, bulletSpawn.position, bulletSpawn.rotation); 
			arma.GetComponent<Rigidbody>().velocity = arma.transform.up * 20;
			arma.GetComponent<Rigidbody>().velocity = arma.transform.right * 3;
		}
		if(votar == "metra")
		{
			var arma = (GameObject)Instantiate(metra, bulletSpawn.position, bulletSpawn.rotation); 
			arma.GetComponent<Rigidbody>().velocity = arma.transform.up * 20;
			arma.GetComponent<Rigidbody>().velocity = arma.transform.right * 3;
		}
		if(votar == "lansallamas")
		{
			var arma = (GameObject)Instantiate(lansallamas, bulletSpawn.position, bulletSpawn.rotation); 
			arma.GetComponent<Rigidbody>().velocity = arma.transform.up * 20;
			arma.GetComponent<Rigidbody>().velocity = arma.transform.right * 3;
		}
		if(votar == "sniper")
		{
			var arma = (GameObject)Instantiate(sniper, bulletSpawn.position, bulletSpawn.rotation); 
			arma.GetComponent<Rigidbody>().velocity = arma.transform.up * 20;
			arma.GetComponent<Rigidbody>().velocity = arma.transform.right * 3;
		}
	}
	void soltar()
	{
		if(armaMano == "escopeta")
		{
			var arma = (GameObject)Instantiate(escopeta2, bulletSpawn.position, bulletSpawn.rotation); 
			arma.GetComponent<Rigidbody>().velocity = arma.transform.up * 20;
			arma.GetComponent<Rigidbody>().velocity = arma.transform.right * 3;
			Destroy(arma, 1.0f);
		}
		if(armaMano == "fusil")
		{
			var arma = (GameObject)Instantiate(fusil2, bulletSpawn.position, bulletSpawn.rotation); 
			arma.GetComponent<Rigidbody>().velocity = arma.transform.up * 20;
			arma.GetComponent<Rigidbody>().velocity = arma.transform.right * 3;
			Destroy(arma, 1.0f);
		}
		if(armaMano == "submetra")
		{
			var arma = (GameObject)Instantiate(submetra2, bulletSpawn.position, bulletSpawn.rotation); 
			arma.GetComponent<Rigidbody>().velocity = arma.transform.up * 20;
			arma.GetComponent<Rigidbody>().velocity = arma.transform.right * 3;
			Destroy(arma, 1.0f);
		}
		if(armaMano == "metra")
		{
			var arma = (GameObject)Instantiate(metra2, bulletSpawn.position, bulletSpawn.rotation); 
			arma.GetComponent<Rigidbody>().velocity = arma.transform.up * 20;
			arma.GetComponent<Rigidbody>().velocity = arma.transform.right * 3;
			Destroy(arma, 1.0f);
		}
		if(armaMano == "lansallamas")
		{
			var arma = (GameObject)Instantiate(lansallamas2, bulletSpawn.position, bulletSpawn.rotation); 
			arma.GetComponent<Rigidbody>().velocity = arma.transform.up * 20;
			arma.GetComponent<Rigidbody>().velocity = arma.transform.right * 3;
			Destroy(arma, 1.0f);
		}
		if(armaMano == "sniper")
		{
			var arma = (GameObject)Instantiate(sniper2, bulletSpawn.position, bulletSpawn.rotation); 
			arma.GetComponent<Rigidbody>().velocity = arma.transform.up * 20;
			arma.GetComponent<Rigidbody>().velocity = arma.transform.right * 3;
			Destroy(arma, 1.0f);
		}
	}
	void CambiaGun ()
	{
		print("INTERCAMBIO");
		skinsToCombine[7] = armaEspalda;
		skinsToCombine[8] = armaMano;
	}

	void OnCollisionEnter (Collision col)//OnTriggerEnter (Collider col)//
	{
		if(col.gameObject.tag == "escopeta" || col.gameObject.tag == "fusil" || col.gameObject.tag == "submetra" || col.gameObject.tag == "metra" || col.gameObject.tag == "lansallamas" || col.gameObject.tag == "sniper")
		{
			Hero.rafaga = true;
			Hero.arma2 = false;
			votar = armaMano;

			if(armaMano == "")
			{
				if(col.gameObject.tag == "escopeta")
				{
					armaMano = col.gameObject.tag;
					//skinsToCombine[8] = armaMano;
					Hero.balaEscopeta += 6;
					Hero.EscopetaTotales += Random.Range(10,150);
				}
				if(col.gameObject.tag == "fusil")
				{
					armaMano = col.gameObject.tag;
					//skinsToCombine[8] = armaMano;
					Hero.balaFusil += 5;
					Hero.FusilTotales += Random.Range(10,150);
				}
				if(col.gameObject.tag == "submetra")
				{
					armaMano = col.gameObject.tag;
					//skinsToCombine[8] = armaMano;
					Hero.balaSubmetra += 30;
					Hero.SubmetraTotales += Random.Range(10,150);
				}
				if(col.gameObject.tag == "metra")
				{
					armaMano = col.gameObject.tag;
					//skinsToCombine[8] = armaMano;
					Hero.balaMetra += 32;
					Hero.MetraTotales += Random.Range(10,150);
				}
				if(col.gameObject.tag == "lansallamas")
				{
					armaMano = col.gameObject.tag;
					//skinsToCombine[8] = armaMano;
					Hero.balaLlamas += 100;
					Hero.LlamasTotales += Random.Range(150,400);
				}
				if(col.gameObject.tag == "sniper")
				{
					armaMano = col.gameObject.tag;
					//skinsToCombine[8] = armaMano;
					Hero.SniperTotales += Random.Range(1,6);
					Hero.balaSniper = 1;
				}
				//Destroy(col.gameObject);
			}else if(armaEspalda == "" && col.gameObject.tag != armaMano)
			{
				if(col.gameObject.tag == "escopeta")
				{
					armaEspalda = "escopeta2";
					//skinsToCombine[7] = armaEspalda;
					Hero.EscopetaTotales += Random.Range(1,49);
				}
				if(col.gameObject.tag == "fusil")
				{
					armaEspalda = "fusil2";
					//skinsToCombine[7] = armaEspalda;
					Hero.FusilTotales += Random.Range(1,41);
				}
				if(col.gameObject.tag == "submetra")
				{
					armaEspalda = "submetra2";
					//skinsToCombine[7] = armaEspalda;
					Hero.SubmetraTotales += Random.Range(1,121);
				}
				if(col.gameObject.tag == "metra")
				{
					armaEspalda = "metra2";
					//skinsToCombine[7] = armaEspalda;
					Hero.MetraTotales += Random.Range(1,181);
				}
				if(col.gameObject.tag == "lansallamas")
				{
					armaEspalda = "lansallamas2";
					//skinsToCombine[8] = armaMano;
					Hero.LlamasTotales += Random.Range(150,400);
				}
				if(col.gameObject.tag == "sniper")
				{
					armaEspalda = "sniper2";
					//skinsToCombine[8] = armaMano;
					Hero.SniperTotales += Random.Range(1,6);
					Hero.balaSniper = 1;
				}
				//Destroy(col.gameObject);
			}else if(col.gameObject.tag == armaMano || col.gameObject.tag+"2" == armaEspalda)
			{
				//print("RECOGER BALAS");
				if(col.gameObject.tag == "escopeta")
				{
					Hero.EscopetaTotales += Random.Range(1,49);
				}
				if(col.gameObject.tag == "fusil")
				{
					Hero.FusilTotales += Random.Range(1,41);
				}
				if(col.gameObject.tag == "submetra")
				{
					Hero.SubmetraTotales += Random.Range(1,121);
				}
				if(col.gameObject.tag == "metra")
				{
					Hero.MetraTotales += Random.Range(1,181);
				}
				if(col.gameObject.tag == "lansallamas")
				{
					Hero.LlamasTotales += Random.Range(150,400);
				}
				if(col.gameObject.tag == "sniper")
				{
					Hero.SniperTotales += Random.Range(1,6);
					Hero.balaSniper = 1;
				}
				Destroy(col.gameObject);
			}else
			{
				armaMano = col.gameObject.tag;
				RecogeGun();
				Destroy(col.gameObject);
			}
		}
		if(col.gameObject.tag == "suplies")
		{
			Hero.EscopetaTotales += 1000;
			Hero.FusilTotales += 1000;
			Hero.SubmetraTotales += 1000;
			Hero.MetraTotales += 1000;
			Hero.LlamasTotales += 1000;
			Hero.SniperTotales += 1000;
			Hero.balaSniper = 1;
		}
	}

	/*
	void deacuerdo()
	{
		Destroy(GameObject.FindGameObjectWithTag("Respawn"));

		if(armaMano == "")
		{
			if(agarrar == "escopeta")
			{
				armaMano = agarrar;
				//skinsToCombine[8] = armaMano;
				Hero.EscopetaTotales += Random.Range(10,150);
			}
			if(agarrar == "fusil")
			{
				armaMano = agarrar;
				//skinsToCombine[8] = armaMano;
				Hero.FusilTotales += Random.Range(10,150);
			}
			if(agarrar == "submetra")
			{
				armaMano = agarrar;
				//skinsToCombine[8] = armaMano;
				Hero.SubmetraTotales += Random.Range(10,150);
			}
			if(agarrar == "metra")
			{
				armaMano = agarrar;
				//skinsToCombine[8] = armaMano;
				Hero.MetraTotales += Random.Range(10,150);
			}
			Destroy(GameObject.Find(agarrar));
		}else if(armaEspalda == "" && agarrar != armaMano)
		{
			if(agarrar == "escopeta")
			{
				armaEspalda = "escopeta2";
				//skinsToCombine[7] = armaEspalda;
				Hero.EscopetaTotales += Random.Range(1,49);
			}
			if(agarrar == "fusil")
			{
				armaEspalda = "fusil2";
				//skinsToCombine[7] = armaEspalda;
				Hero.FusilTotales += Random.Range(1,41);
			}
			if(agarrar == "submetra")
			{
				armaEspalda = "submetra2";
				//skinsToCombine[7] = armaEspalda;
				Hero.SubmetraTotales += Random.Range(1,121);
			}
			if(agarrar == "metra")
			{
				armaEspalda = "metra2";
				//skinsToCombine[7] = armaEspalda;
				Hero.MetraTotales += Random.Range(1,181);
			}
			Destroy(GameObject.Find(agarrar));
		}else
		{
			armaMano = agarrar;
			RecogeGun();
			Destroy(GameObject.Find(agarrar));
		}
	}
	void desacuerdo()
	{
		print("NO");
	}
	*/
}