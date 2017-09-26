using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake2 : MonoBehaviour {
	
	public Vector3 nextPosition;
	float movimiento;
	float movimiento2;

	bool mover = true;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Cam.sniper)
		{
			//transform.localPosition = Random.insideUnitSphere * 0.7f;
			nextPosition = new Vector3(transform.position.x+movimiento, transform.position.y+movimiento2, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * 1);
			if(mover)
			{
				mover = false;
				StartCoroutine(espera());
			}
		}
	}

	IEnumerator espera ()
	{
		yield return new WaitForSeconds(3);
		movimiento = Random.Range(-1.5f,1.5f);
		movimiento2 = Random.Range(-1.5f,1.5f);
		mover = true;
	}
}
