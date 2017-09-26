using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine.Unity.Modules.AttachmentTools;

public class CustomEspecial : MonoBehaviour {

	[SpineSkin]
	public List<string> skinsToCombine;

	Spine.Skin combinedSkin;

	int cara;
	int casco;

	void Awake ()
	{
		cara = Random.Range(1,6);
		casco = Random.Range(1,4);
	}

	void Start ()
	{
		skinsToCombine[0] = "Cara"+cara.ToString();

		if(casco == 1)
		{
			skinsToCombine[1] = "Casco1";
			skinsToCombine[2] = "Maleta";
			skinsToCombine[3] = "Abrigo";
		}else if(casco == 2)
		{
			skinsToCombine[1] = "Casco2";
			skinsToCombine[2] = "Maleta";
			skinsToCombine[3] = "Shemag";
		}else
		{
			skinsToCombine[1] = "Casco3";
			skinsToCombine[2] = "Radio";
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
}
