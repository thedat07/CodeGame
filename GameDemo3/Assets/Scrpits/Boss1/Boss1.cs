using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public GameObject deadL, deadR;
    public Player2 player;
    public Animator animator;
    public bool Ground;
    public float speed = 0.05f, changeDirection = -1;
    public int MaxHealth = 100;
    public int curHealth;
    public HealthBar healthBar;
    Vector2 Move;
    public bool isFlipped = false;
    public ParticleSystem dustCloud;
    public AudioSource audiosrc;
    public AudioClip dead_audio;
    public AudioClip attack_audio;
    public GameObject Door;
    [Header("Idel")]
    public float idelMovementSpeed;
    public Vector2 idelMovementDirection;
    [Header("Fall")]
    public float fallMovementSpeed;
    public Vector2 fallMovementDirection;
    [Header("Ground")] 
    public float groundMovementSpeed;
    public Vector2 groundMovementDirection;

    [Header("Other")]
    public Transform goundCheckUp;
    public Transform goundCheckDown;
    public Transform goundCheckWall;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingUp;
    public bool isTouchingDown;
    public bool isTouchingWall;
    public bool hasPlayerPositon;
    public bool facingLeft = true;
    public bool goingUp = true;
    public Rigidbody2D enemyRB;
    // Use this for initialization
    void Start()
    {
        MaxHealth = curHealth;
        Door.SetActive(false);
        enemyRB = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        Move = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
        audiosrc = gameObject.GetComponent<AudioSource>();
        healthBar.SetMaxHealth(MaxHealth);
    }
    private void Update()
    {
        isTouchingUp = Physics2D.OverlapCircle(goundCheckUp.position, groundCheckRadius, groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(goundCheckDown.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(goundCheckWall.position, groundCheckRadius, groundLayer);
    }
    public void IdelState()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }

        if (isTouchingWall)
        {
            if (facingLeft)
            {
                Flip();
            }
            else if (!facingLeft)
            {
                Flip();
            }
        }
        enemyRB.velocity = idelMovementSpeed * idelMovementDirection;
    }
    public void FallState()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }

        if (isTouchingWall)
        {
            if (facingLeft)
            {
                Flip();
            }
            else if (!facingLeft)
            {
                Flip();
            }
        }
        enemyRB.velocity = fallMovementSpeed * fallMovementDirection;
    }
    public void GroundState()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }

        if (isTouchingWall)
        {
            if (facingLeft)
            {
                Flip();
            }
            else if (!facingLeft)
            {
                Flip();
            }
        }
        enemyRB.velocity = groundMovementSpeed * groundMovementDirection;
    }
    void ChangeDirection()
    {
        goingUp = !goingUp;
        idelMovementDirection.y *= -1;
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        idelMovementDirection.x *= -1;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(goundCheckUp.position, groundCheckRadius);
        Gizmos.DrawWireSphere(goundCheckDown.position, groundCheckRadius);
        Gizmos.DrawWireSphere(goundCheckWall.position, groundCheckRadius);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Ground = true;
        }
    }
    public void Damage(int dmg)
    {
        curHealth -= dmg;
        CinemachineShake.Instance.ShakeCamera(2f, .1f);
        animator.SetTrigger("hit");
        audiosrc.PlayOneShot(dead_audio, 1f);
        healthBar.SetHealth(curHealth);
    }
    public void audio()
    {
        audiosrc.PlayOneShot(attack_audio, 0.2f);
    }
}



