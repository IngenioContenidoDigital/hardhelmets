using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CajaCarta : MonoBehaviour {

	public GameObject carta;
	bool seleccionada;

	public void Carta ()
	{
		if(!seleccionada)
		{
			carta.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "destapar", false);
		}
		Cajas.abiertas += 1;
		seleccionada = true;
	}

	public void Over ()
	{
		if(!seleccionada)
		carta.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "mousecaja", false);
	}
	public void Exit ()
	{
		if(!seleccionada)
		carta.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "normalcaja", false);
	}
}
