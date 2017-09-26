using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour {

	public UnityEngine.UI.Image loadingBar;
	//public UnityEngine.UI.Image puntos;

	private AsyncOperation Async = null;

	public static string nombre;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(espera());
	}

	void Update ()
	{
		/*puntos.fillAmount += 0.02f;
		if(puntos.fillAmount >= 1)
		{
			puntos.fillAmount = 0;
		}*/
	}

	public void ClickAsync (string level)
	{
		StartCoroutine(LoadLevelWithBar(level));
	}

	IEnumerator LoadLevelWithBar(string level)
	{
		Async = SceneManager.LoadSceneAsync(level);
		//Async.allowSceneActivation = false;

		while (!Async.isDone)
		{
			if(Async.progress < 0.9f)
			{
				loadingBar.fillAmount = Async.progress/0.9f;

			}else
			{
				loadingBar.fillAmount = Async.progress/0.9f;
				Async.allowSceneActivation = true;
			}

			yield return null;
		}
		yield return Async;
	}

	public void Iniciar()
	{
		ClickAsync(nombre);
	}

	IEnumerator espera()
	{
		yield return new WaitForSeconds(1);
		Iniciar();
	}
}
