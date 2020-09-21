using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3hit : StateMachineBehaviour
{
    Boss3 boss3;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss3 = animator.GetComponent<Boss3>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss3.Attack1State();
        if (boss3.curHealth <= 0)
        {
            animator.SetTrigger("dead");
        }
        if (boss3.facingLeft) { animator.transform.rotation = Quaternion.Euler(0f, 0f, 0f); }
        else { animator.transform.rotation = Quaternion.Euler(0f, -180f, 0f); }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("dead");
    }
}
