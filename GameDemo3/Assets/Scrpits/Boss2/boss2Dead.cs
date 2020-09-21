using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2Dead : StateMachineBehaviour
{
    Boss2 boss2;
    Vector3 Move;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss2 = animator.GetComponent<Boss2>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (boss2.curHealth <= 0)
        {
            boss2.Door.SetActive(true);
        
            Instantiate(boss2.dead, animator.transform.position, Quaternion.identity);
            Destroy(animator.gameObject);
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
