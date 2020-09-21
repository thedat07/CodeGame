using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Idle : StateMachineBehaviour
{
    private Vector3 localScale;
    private Transform playerPos;
    Rigidbody2D rb;
    public int minTime;
    public int maxTime;
    Enemy2 enemy2;
    public float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        localScale = animator.transform.localScale;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        enemy2 = animator.GetComponent<Enemy2>();
        timer = Random.Range(minTime, maxTime);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy2.attack == true)
        {
            animator.SetTrigger("run");
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
