using UnityEngine;
using System;
using System.Collections;
  
[RequireComponent(typeof(Animator))]
[ExecuteInEditMode]
public class IK : MonoBehaviour 
{
	public Animator Avatar;
	
	public Transform bodyObj = null;
	public Transform leftFootObj = null;
	public Transform rightFootObj = null;
	public Transform leftHandObj = null;
	public Transform rightHandObj = null;
	public Transform lookAtObj = null;
	
	public float leftFootWeightPosition = 1;
	public float leftFootWeightRotation = 1;

	public float rightFootWeightPosition = 1;
	public float rightFootWeightRotation = 1;
	
	public float leftHandWeightPosition = 1;
	public float leftHandWeightRotation = 1;
	
	public float rightHandWeightPosition = 1;
	public float rightHandWeightRotation = 1;

	public float lookAtWeight = 1.0f;
    
	void OnAnimatorIK(int layerIndex)
	{		
		if(Avatar)
		{
			Avatar.SetIKPositionWeight(AvatarIKGoal.LeftFoot,leftFootWeightPosition);
			Avatar.SetIKRotationWeight(AvatarIKGoal.LeftFoot,leftFootWeightRotation);
							
			Avatar.SetIKPositionWeight(AvatarIKGoal.RightFoot,rightFootWeightPosition);
			Avatar.SetIKRotationWeight(AvatarIKGoal.RightFoot,rightFootWeightRotation);
	
			Avatar.SetIKPositionWeight(AvatarIKGoal.LeftHand,leftHandWeightPosition);
			Avatar.SetIKRotationWeight(AvatarIKGoal.LeftHand,leftHandWeightRotation);
							
			Avatar.SetIKPositionWeight(AvatarIKGoal.RightHand,rightHandWeightPosition);
			Avatar.SetIKRotationWeight(AvatarIKGoal.RightHand,rightHandWeightRotation);
				
			Avatar.SetLookAtWeight(lookAtWeight,0.3f,0.6f,1.0f,0.5f);
				
			if(bodyObj != null)
			{
				Avatar.bodyPosition = bodyObj.position;
				Avatar.bodyRotation = bodyObj.rotation;
			}				

			if(leftFootObj != null)
			{
				Avatar.SetIKPosition(AvatarIKGoal.LeftFoot,leftFootObj.position);
				Avatar.SetIKRotation(AvatarIKGoal.LeftFoot,leftFootObj.rotation);
			}				
			
			if(rightFootObj != null)
			{
				Avatar.SetIKPosition(AvatarIKGoal.RightFoot,rightFootObj.position);
				Avatar.SetIKRotation(AvatarIKGoal.RightFoot,rightFootObj.rotation);
			}				

			if(leftHandObj != null)
			{
				Avatar.SetIKPosition(AvatarIKGoal.LeftHand,leftHandObj.position);
				Avatar.SetIKRotation(AvatarIKGoal.LeftHand,leftHandObj.rotation);
			}				
			
			if(rightHandObj != null)
			{
				Avatar.SetIKPosition(AvatarIKGoal.RightHand,rightHandObj.position);
				Avatar.SetIKRotation(AvatarIKGoal.RightHand,rightHandObj.rotation);
			}				
				
			if(lookAtObj != null)
			{
				Avatar.SetLookAtPosition(lookAtObj.position);
			}				
		}
	}  
}
