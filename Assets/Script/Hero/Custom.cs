using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine.Unity.Modules.AttachmentTools; 

public class Custom : MonoBehaviour {

		[SpineSkin]
		public List<string> skinsToCombine;

		Spine.Skin combinedSkin;


		void Start ()
		{
			//PlayerPrefs.SetString("casco", "");
		}

		void FixedUpdate ()
		{
			skinsToCombine[0] = customTow.casco;//casco
			skinsToCombine[1] = customTow.cara;//cara
			skinsToCombine[2] = customTow.mascara;//cuerpo
			skinsToCombine[3] = customTow.uniforme;//uniforme
			skinsToCombine[4] = customTow.cuello;//cuello
			skinsToCombine[5] = customTow.cinturon;//cinturon
			skinsToCombine[6] = customTow.chaleco;//chaleco
			skinsToCombine[7] = customTow.maleta;//maleta

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


