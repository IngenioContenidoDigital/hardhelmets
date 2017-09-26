using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemy : MonoBehaviour {

	public int puntos;
	int costo;

	int azar;
	int azarTank;

	public Transform nace;

	//int[] objetos = {1,1,1,1,1,2,2,2,2,2,3,3,3,3,4,4,4,4,5,5,5,6,6,6,7,7,7,8,8,9,9};
	//OBJETOS A CREAR
	public GameObject Fusilero;//1
	public GameObject Escopeto;//2
	public GameObject Submetralleto;//3
	public GameObject Metralleto;//4

	public GameObject Bazuco;//5
	public GameObject Mortero;//6
	public GameObject MG;//7

	public GameObject Lighttank;//8
	public GameObject Heavytank;//9

	public bool fin;

	void Start ()
	{
		puntos = 0;
	}

	void Update ()
	{
		if(!fin)
		{
			if(nace == null)
			{
				nace = GameObject.FindWithTag ("enemyBase").transform;
			}

			puntos += 1;

			if(puntos >= 400)
			{
				azar = Random.Range(1,10);
				puntos = 0;
			}

			if(azar == 1)
			{
				var objeto = (GameObject)Instantiate(Fusilero, new Vector3(nace.position.x-15,-24,nace.position.z+Random.Range(-5,6)), nace.rotation);
				azar = 0;
			}else if(azar == 2)
			{
				var objeto = (GameObject)Instantiate(Escopeto, new Vector3(nace.position.x-15,-24,nace.position.z+Random.Range(-5,6)), nace.rotation);
				azar = 0;
			}else if(azar == 3)
			{
				var objeto = (GameObject)Instantiate(Submetralleto, new Vector3(nace.position.x-15,-24,nace.position.z+Random.Range(-5,6)), nace.rotation);
				azar = 0;
			}else if(azar == 4)
			{
				var objeto = (GameObject)Instantiate(Metralleto, new Vector3(nace.position.x-15,-24,nace.position.z+Random.Range(-5,6)), nace.rotation);
				azar = 0;
			}else if(azar == 5)
			{
				var objeto = (GameObject)Instantiate(Bazuco, new Vector3(nace.position.x-15,-24,nace.position.z+Random.Range(-5,6)), nace.rotation);
				azar = 0;
			}else if(azar == 6)
			{
				var objeto = (GameObject)Instantiate(Mortero, new Vector3(nace.position.x-15,-24,nace.position.z+Random.Range(-5,6)), nace.rotation);
				azar = 0;
			}else if(azar == 7)
			{
				var objeto = (GameObject)Instantiate(MG, new Vector3(nace.position.x-15,-24,nace.position.z+Random.Range(-5,6)), nace.rotation);
				azar = 0;
			}else if(azar == 8)
			{
				azarTank = Random.Range(1,3);
				if(azarTank == 1)
				{
					var objeto = (GameObject)Instantiate(Lighttank, new Vector3(nace.position.x-15,-24,nace.position.z+Random.Range(-5,6)), nace.rotation);
					azar = 0;
				}else
				{
					azar = Random.Range(1,8);
				}
			}else if(azar == 9)
			{
				azarTank = Random.Range(1,3);
				if(azarTank == 1)
				{
					var objeto = (GameObject)Instantiate(Heavytank, new Vector3(nace.position.x-15,-24,nace.position.z+Random.Range(-5,6)), nace.rotation);
					azar = 0;
				}else
				{
					azar = Random.Range(1,8);
				}
			}
		}
	}
}
