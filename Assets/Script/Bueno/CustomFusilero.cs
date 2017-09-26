using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine.Unity.Modules.AttachmentTools; 

public class CustomFusilero : MonoBehaviour {

	[SpineSkin]
	public List<string> skinsToCombine;

	Spine.Skin combinedSkin;

	int cara;

	void Awake ()
	{
		cara = Random.Range(1,6);
	}

	void Start ()
	{
		skinsToCombine[0] = "Cara"+cara.ToString();

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


