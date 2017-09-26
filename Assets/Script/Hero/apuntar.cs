using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apuntar : MonoBehaviour {
	/*
	//HUESOS A ROTAR
	public Transform hueso;
	public float target;
	public float AngleDeg;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		target = Mathf.Atan2(Input.mousePosition.y - transform.position.y, Input.mousePosition.x - transform.position.x);
		AngleDeg = (180 / Mathf.PI) * target;
		hueso.transform.rotation = Quaternion.Euler(0,0, AngleDeg);
	}
	*/

	public GameObject Player;
	public Animator animator;

	public bool listo;

	Vector3 mousePosition;
	Vector2 todo;
	float ye;

	public static Vector3 Inicial;



	Ray ray;
	RaycastHit hit;


	void Update ()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		ye = hit.point.y;

		if(Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			if(listo)
			{
				if(Hero._currentDirection == "right")
				{
					transform.position = new Vector3(Player.transform.position.x+15, ye, Player.transform.position.z);
				}else
				{
					transform.position = new Vector3(Player.transform.position.x-15, ye, Player.transform.position.z);
				}
			}else
			{
				if (Hero._currentDirection == "right")
				{
					Inicial = new Vector3(Player.transform.position.x+15, Player.transform.position.y+4.1f, Player.transform.position.z);
				}else
				{
					Inicial = new Vector3(Player.transform.position.x-15, Player.transform.position.y+4.1f, Player.transform.position.z);
				}

				transform.position = Vector3.Lerp(transform.position, Inicial, Time.deltaTime * 5);
			}
		}

		//todo = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		//ye = todo.y*20;

		/*if(listo)
		{
			if(Hero._currentDirection == "right")
			{
				transform.position = new Vector3(Player.transform.position.x+18, ye, Player.transform.position.z);
			}else
			{
				transform.position = new Vector3(Player.transform.position.x-18, ye, Player.transform.position.z);
			}
		}else
		{
			if (Hero._currentDirection == "right")
			{
				Inicial = new Vector3(Player.transform.position.x+18, 4.1f, Player.transform.position.z);
			}else
			{
				Inicial = new Vector3(Player.transform.position.x-18, 4.1f, Player.transform.position.z);
			}

			transform.position = Vector3.Lerp(transform.position, Inicial, Time.deltaTime * 2);
		}*/

		if(animator.GetCurrentAnimatorStateInfo(0).IsName("FusilShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunShot") ||
			animator.GetCurrentAnimatorStateInfo(0).IsName("SubmetraShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("MetraShot") ||
			animator.GetCurrentAnimatorStateInfo(0).IsName("GunShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("FusilShotWalk") ||
			animator.GetCurrentAnimatorStateInfo(0).IsName("ShotgunShotWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("SubmetraShotWalk") ||
			animator.GetCurrentAnimatorStateInfo(0).IsName("MetraShotWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("GunShotWalk") ||
			animator.GetCurrentAnimatorStateInfo(0).IsName("GunPose") || animator.GetCurrentAnimatorStateInfo(0).IsName("GunPoseWalk") ||
			animator.GetCurrentAnimatorStateInfo(0).IsName("Pose") || animator.GetCurrentAnimatorStateInfo(0).IsName("PoseWalk") ||
			animator.GetCurrentAnimatorStateInfo(0).IsName("jump1") || animator.GetCurrentAnimatorStateInfo(0).IsName("jump2") ||
			animator.GetCurrentAnimatorStateInfo(0).IsName("jumpShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasShot") ||
			animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasShot") || animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasPose") ||
			animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasPoseWalk") || animator.GetCurrentAnimatorStateInfo(0).IsName("lansallamasrecarga"))
		{
			listo = true;
		}else
		{
			listo = false;
		}
	}
}
