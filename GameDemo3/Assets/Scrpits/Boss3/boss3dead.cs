using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3dead : StateMachineBehaviour
{
    Boss3 boss3;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss3 = animator.GetComponent<Boss3>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (boss3.curHealth <= 0)
        {

            Instantiate(boss3.dead, animator.transform.position, Quaternion.identity);
            boss3.Door.SetActive(true);
            Destroy(animator.gameObject);
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
