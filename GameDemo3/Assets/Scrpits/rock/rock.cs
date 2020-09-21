using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    public Player2 player;
    public Animator animator;
    public float speed = 0.05f, changeDirection = -1;
    Vector2 Move;
    public bool isFlipped = false;

    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Move = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
    }
    private void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground") || col.collider.CompareTag("vien"))
        {
            speed *= changeDirection;
            if(speed < 0)
            {
                animator.SetTrigger("right");
            }
            if (speed > 0)
            {
                animator.SetTrigger("left");
            }
        }
    }
}
