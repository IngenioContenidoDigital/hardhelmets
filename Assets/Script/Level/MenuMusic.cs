using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour {

	float musica;

	void Awake ()
	{
		musica = PlayerPrefs.GetFloat("musica");

		GetComponent<AudioSource>().volume = musica;

		DontDestroyOnLoad(gameObject);

		if(FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Application.loadedLevelName == "Level")
		{
			Destroy(gameObject);
		}
	}
}
