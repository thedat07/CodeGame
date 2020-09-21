using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1Dead : StateMachineBehaviour
{
    Boss1 boss1;
    Vector3 Move;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (boss1.curHealth <= 0)
        {
            boss1.Door.SetActive(true);
            if (boss1.isFlipped) Instantiate(boss1.deadL, animator.transform.position, Quaternion.identity);
            else Instantiate(boss1.deadR, animator.transform.position, Quaternion.identity);
            Destroy(animator.gameObject);
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
