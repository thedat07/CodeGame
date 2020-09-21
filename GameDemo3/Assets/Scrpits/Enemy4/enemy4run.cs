using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy4run : StateMachineBehaviour
{
    private Vector3 localScale;
    private Transform playerPos;
    Rigidbody2D rb;
    public int minTime;
    public int maxTime;
    Enemy4 enemy4;
    public float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        localScale = animator.transform.localScale;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        enemy4 = animator.GetComponent<Enemy4>();
        timer = Random.Range(minTime, maxTime);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy4.attack == true)
        {
            animator.SetTrigger("attack");
        }
        enemy4.grounded = Physics2D.OverlapCircle(enemy4.groundPos.position, enemy4.checkRadius, enemy4.whatIsGround);
        enemy4.Enemycheck = Physics2D.OverlapCircle(enemy4.PlayerPos.position, enemy4.checkRadius, enemy4.whatIsGround);
        if (enemy4.grounded == true)
        {
            if (enemy4.isFlipped)
            {
                animator.transform.Translate(Vector2.right * enemy4.speed * Time.deltaTime);
            }
            else if (!enemy4.isFlipped)
            {

                animator.transform.Translate(Vector2.left * enemy4.speed * Time.deltaTime);
            }
        }
        if (enemy4.grounded == false || enemy4.Enemycheck == true)
        {
            Vector3 flipped = animator.transform.localScale;
            flipped.x *= -1;
            if (enemy4.isFlipped)
            {
                animator.transform.localScale = flipped;
                enemy4.isFlipped = false;
            }
            else if (!enemy4.isFlipped)
            {
                animator.transform.localScale = flipped;
                enemy4.isFlipped = true;
            }
        }
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
    }
}
