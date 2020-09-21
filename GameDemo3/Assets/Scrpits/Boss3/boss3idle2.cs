using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3idle2 : StateMachineBehaviour
{
    Boss3 boss3;
    public int minTime;
    public int maxTime;
    public float timer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss3 = animator.GetComponent<Boss3>();
        timer = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss3.IdelState();
        if (timer < 0)
        {
            animator.SetTrigger("idle");
        }
        else
        {
            timer -= Time.deltaTime;

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("idle");
        animator.ResetTrigger("hit");
    }
}
