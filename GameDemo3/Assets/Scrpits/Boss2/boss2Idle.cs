using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2Idle : StateMachineBehaviour
{
    Boss2 boss2;
    Vector3 Move;
    public int minTime;
    public int maxTime;
    public float timer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss2 = animator.GetComponent<Boss2>();
        timer = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss2.IdelState();
        if (timer < 0)
        {
            animator.SetTrigger("Attack");
        }
        else if (timer > 8)
        {
            animator.SetTrigger("Attack2");
        }
        else
        {
            timer -= Time.deltaTime;

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Attack2");
    }
}
