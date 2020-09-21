using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Run : StateMachineBehaviour
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

        enemy2.grounded = Physics2D.OverlapCircle(enemy2.groundPos.position, enemy2.checkRadius, enemy2.whatIsGround);
        enemy2.Enemycheck = Physics2D.OverlapCircle(enemy2.PlayerPos.position, enemy2.checkRadius, enemy2.whatIsGround);
        if (enemy2.grounded == true)
        {
            if (enemy2.isFlipped)
            {
                animator.transform.Translate(Vector2.right * enemy2.speed * Time.deltaTime);
            }
            else if (!enemy2.isFlipped)
            {

                animator.transform.Translate(Vector2.left * enemy2.speed * Time.deltaTime);
            }
        }
        if (enemy2.Enemycheck == true )
        {
            animator.SetTrigger("hitWall");
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("idle");
    }
}
