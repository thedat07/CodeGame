using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1fail : StateMachineBehaviour
{
    Boss1 boss1;
    Vector3 Move;
    public int minTime;
    public int maxTime;
    public float timer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
        timer = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {



            boss1.FallState();

            if (boss1.Ground==true)
            {
                animator.SetTrigger("Ground");
            }

        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Ground");
    }

}
