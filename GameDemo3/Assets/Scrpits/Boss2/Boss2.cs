using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public GameObject dead;
    public Animator animator;
    public int MaxHealth = 100;
    public int curHealth;
    public HealthBar healthBar;
    public float offset;
    public Transform Target;
    Vector2 Direction;
    public GameObject bullet;
    public GameObject bullet2;
    public Transform Shootpoint;
    public float Force;
    public AudioSource audiosrc;
    public AudioClip dead_audio;
    public AudioClip attack_audio;
    public GameObject Door;
    [Header("Idel")]
    public float idelMovementSpeed;
    public Vector2 idelMovementDirection;
    [Header("Attack2")]
    public float attack2MovementSpeed;
    public Vector2 attack2MovementDirection;

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
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = curHealth;
        enemyRB = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        audiosrc = gameObject.GetComponent<AudioSource>();
        Door.SetActive(false);
        healthBar.SetMaxHealth(MaxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
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
    public void Attack2State()
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
        enemyRB.velocity = attack2MovementSpeed * attack2MovementDirection;
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
    public void targetPlayer()
    {
        Vector3 difference = Target.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, transform.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        audiosrc.PlayOneShot(attack_audio, 0.2f);
    }
    void shoot2()
    {
        Instantiate(bullet2, Shootpoint.position, transform.rotation);
        audiosrc.PlayOneShot(attack_audio, 0.2f);
    }
   
    public void Damage(int dmg)
    {
        curHealth -= dmg;
        CinemachineShake.Instance.ShakeCamera(2f, .1f);
        animator.SetTrigger("hit");
        audiosrc.PlayOneShot(dead_audio, 1f);
        healthBar.SetHealth(curHealth);
    }
}
