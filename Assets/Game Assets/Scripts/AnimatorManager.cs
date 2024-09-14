using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator anim;
    private int horizontal;
    private int vertical;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimValues(float horizontalMovement, float verticalMovement, bool isSpriting)
    {
        float snappedHorizontal;
        float snappedVertical;

        #region Snapped Horizontal  
        if (horizontalMovement > 0 && horizontalMovement < 0.55f) //Joystick thì có thể lên 0.55
        {
            snappedHorizontal = 0.5f;
        }

        else if (horizontalMovement > 0.55f) 
        {
            snappedHorizontal = 1f;
        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            snappedHorizontal = -0.5f;
        }
        else if (horizontalMovement < -0.55f) 
        {
            snappedHorizontal = -1f;
        }
        else
            snappedHorizontal = 0;
        #endregion

        #region Snapped Vertical  
        if (verticalMovement > 0 && verticalMovement < 0.55f) //Joystick thì có thể lên 0.55
        {
            snappedVertical = 0.5f;
        }

        else if (verticalMovement > 0.55f)
        {
            snappedVertical = 1f;
        }
        else if (verticalMovement < 0 && verticalMovement > -0.55f)
        {
            snappedVertical = -0.5f;
        }
        else if (verticalMovement < -0.55f)
        {
            snappedVertical = -1f;
        }
        else
            snappedVertical = 0;
        #endregion
        if (isSpriting)
        {
            snappedHorizontal = horizontalMovement;
            snappedVertical = 2;
        }
        anim.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime);
        anim.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);
    }

    public void PlayTargetAnim(string targetAnim,bool isInteracting)
    {
        anim.SetBool("isInteracting", isInteracting);
        anim.CrossFade(targetAnim,0.2f);
    }
}
