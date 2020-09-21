using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Idle : StateMachineBehaviour
{
    private Vector3 localScale;
    private Transform playerPos;
    Rigidbody2D rb;
    public int minTime;
    public int maxTime;
    Enemy1 enemy1;
    public float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        localScale = animator.transform.localScale;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        enemy1 = animator.GetComponent<Enemy1>();
        timer = Random.Range(minTime, maxTime);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy1.attack == true)
        {
            animator.SetTrigger("attack");
        }
        if (timer < 0)
        {
            animator.SetTrigger("run");
            Vector3 flipped = animator.transform.localScale;
            flipped.x *= -1;
            if (enemy1.isFlipped)
            {
                animator.transform.localScale = flipped;
                enemy1.isFlipped = false;
            }
            else if (!enemy1.isFlipped)
            {
                animator.transform.localScale = flipped;
                enemy1.isFlipped = true;
            }
        }
        else
        {
            timer -= Time.deltaTime;

        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("run");
        animator.ResetTrigger("attack");
    }
}
