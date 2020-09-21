using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{

    public int key = 0;
    public ParticleSystem dust;
    public int ourHealth;
    private BoxCollider2D bc;
    public gamemaster gm;
    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public Vector2 direction;
    private bool facingRight = true;

    [Header("Vertical Movement")]
    public float jumpSpeed = 15f;
    public float jumpDelay = 0.25f;
    public bool doubleJump;
    private float jumpTimer;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject characterHolder;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;
    public float gravity = 1f;
    public float fallMultiplier = 5f;


    [Header("Ground Check")]
    public Transform groundCheck;
    public float footOffest = 0.4f;
    public float groundDistance = 0.1f;
    public LayerMask groundLayer;
    public bool onGround;

    [Header("Wall")]
    public bool onWall;
    public Vector3 wallOffset;
    public float wallRadius;
    public float maxFallSpeed = -1;
    public float wallJumpDuration = 0.25f;
    public bool jumpFromWall;
    public float jumpFinish;
    public LayerMask wallLayer;
    public float horizontalJumpForce = 6;
    [Header("Audio")]
    public AudioSource audiosrc;
    public AudioClip jump;
    public AudioClip dead_audio;
    public AudioClip iteam_audio;
    private void Awake()
    {
        audiosrc = gameObject.GetComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
    }
    void Update()
    {
        PhysicsCheck();
        bool wasOnGround = onGround;

        if (!wasOnGround && onGround)
        {
            StartCoroutine(JumpSqueeze(1.25f, 0.8f, 0.05f));
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpTimer = Time.time + jumpDelay;
            
        }
        animator.SetBool("onGround", onGround);
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {
        moveCharacter(direction.x);
        if (jumpTimer > Time.time && onGround)
        {
            Jump();
            doubleJump = true;
        }
        if (jumpTimer > Time.time && !onGround || !onWall)
        {
            if(jumpTimer > Time.time && doubleJump)
            {
                doubleJump = false;
                animator.SetTrigger("doubleJump");
                Jump();
            }
        }
        if (jumpTimer > Time.time && onWall)
        {
            JumpWall();
            doubleJump = true;
        }
        modifyPhysics();
        if (ourHealth <= 0)
        {
            Death();
            
            GetComponent<BoxCollider2D>().enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
    void moveCharacter(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);

        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }

            
        animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("vertical", rb.velocity.y);
    }
    void Jump()
    {
            CreateDust();
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jumpTimer = 0;
            StartCoroutine(JumpSqueeze(0.5f, 1.2f, 0.1f));
            audiosrc.PlayOneShot(jump, 0.5f);
    }
    public void JumpWall()
    {
        CreateDust();
        rb.velocity = new Vector2(rb.velocity.x, 0);
        if(facingRight) rb.AddForce(Vector2.left * horizontalJumpForce, ForceMode2D.Impulse);
        else rb.AddForce(Vector2.right * horizontalJumpForce, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * horizontalJumpForce, ForceMode2D.Impulse);
        jumpTimer = 0;
        StartCoroutine(JumpSqueeze(0.5f, 1.2f, 0.1f));
        audiosrc.PlayOneShot(jump, 0.5f);
        Flip();
    }
    public void JumpAttack()
    {
        Jump();
    }
    void modifyPhysics()
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if (onGround)
        {
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections)
            {
                rb.drag = linearDrag;
            }
            else
            {
                rb.drag = 0f;
            }
            rb.gravityScale = 1;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;
            if (rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }
    void Flip()
    {
        CreateDust();
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }
    IEnumerator JumpSqueeze(float xSqueeze, float ySqueeze, float seconds)
    {
        Vector3 originalSize = Vector3.one;
        Vector3 newSize = new Vector3(xSqueeze, ySqueeze, originalSize.z);
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            characterHolder.transform.localScale = Vector3.Lerp(originalSize, newSize, t);
            yield return null;
        }
        t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            characterHolder.transform.localScale = Vector3.Lerp(newSize, originalSize, t);
            yield return null;
        }

    }
    void CreateDust()
    {
        if(ourHealth>0) dust.Play();

    }
    void PhysicsCheck()
    {
        onGround = false;
        onWall = false;

        RaycastHit2D leftFoot = Raycast(groundCheck.position + new Vector3(-footOffest, 0), Vector2.down, groundDistance, groundLayer);
        RaycastHit2D rightFoot = Raycast(groundCheck.position + new Vector3(footOffest, 0), Vector2.down, groundDistance, groundLayer);

        if (leftFoot || rightFoot)
        {
            onGround = true;
        }

        bool rightWall = Physics2D.OverlapCircle(transform.position + new Vector3(wallOffset.x, 0), wallRadius, wallLayer);
        bool leftWall = Physics2D.OverlapCircle(transform.position + new Vector3(-wallOffset.x, 0), wallRadius, wallLayer);

        if (rightWall || leftWall)
        {
            onWall = true;
            doubleJump = false;
        }

        if (onWall)
        {
            if (rb.velocity.y < maxFallSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
            }
        }
        animator.SetBool("OnWall", onWall);


    }
    public RaycastHit2D Raycast(Vector2 origin, Vector2 rayDirection, float length, LayerMask mask, bool drawRay = true)
    {

        //Send out the desired raycasr and record the result
        RaycastHit2D hit = Physics2D.Raycast(origin, rayDirection, length, mask);

        //If we want to show debug raycasts in the scene...

        if (drawRay)
        {
            Color color = hit ? Color.red : Color.green;
            //...and draw the ray in the scene view
            Debug.DrawRay(origin, rayDirection * length, color);
        }
        //...determine the color based on if the raycast hit...

        //Return the results of the raycast
        return hit;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + new Vector3(wallOffset.x, 0), wallRadius);
        Gizmos.DrawWireSphere(transform.position + new Vector3(-wallOffset.x, 0), wallRadius);
    }
    public void Death()
    {
        jumpSpeed = 0;
        moveSpeed = 0;
        animator.SetTrigger("hit");

    }
    public void Damage(int damage)
    {
        ourHealth -= damage;
        audiosrc.PlayOneShot(dead_audio, 1f);
        CinemachineShake.Instance.ShakeCamera(2f, .1f);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Key"))
        {

            if (key == 0) { audiosrc.PlayOneShot(iteam_audio, 0.3f); key = 1; }
        }
        if (col.CompareTag("Coins"))
        {
            audiosrc.PlayOneShot(iteam_audio, 0.3f);
            Destroy(col.gameObject);
            gm.points += 1;
            if (gm.points % 50 == 0)
            {
                gm.life += 1;
            }
        }
    }
}
