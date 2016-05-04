using UnityEngine;
using System.Collections;

public class AnimatorScript : MonoBehaviour
{
    public Animator AnimatorComponent;
    public IK IKController;

    float ikWeight = 1;
	void Update ()
    {
        AnimatorComponent.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Vertical")));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AnimatorComponent.SetBool("IsCrouch", !AnimatorComponent.GetBool("IsCrouch"));
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            ikWeight = ikWeight == 1 ? 0 : 1;
            IKController.leftFootWeightPosition = ikWeight;

            IKController.leftFootWeightRotation = ikWeight;

            IKController.rightFootWeightPosition = ikWeight;
            IKController.rightFootWeightRotation = ikWeight;

            IKController.leftHandWeightPosition = ikWeight;
            IKController.leftHandWeightRotation = ikWeight;

            IKController.rightHandWeightPosition = ikWeight;
            IKController.rightHandWeightRotation = ikWeight;

            IKController.lookAtWeight = ikWeight;
        }
	}
}
