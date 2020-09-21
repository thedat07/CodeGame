using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject deadL, deadR;
    private Transform player;
    public bool isFlipped = false;
    public float curHealth = 100f;
    Rigidbody2D rb;
    public Animator anim;
    public float speed;
    public bool movingRight = true;
    public bool grounded = true;
    public bool Enemycheck = false;
    public Transform groundPos;
    public Transform PlayerPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool attack;
    public Transform shotPoint;
    public Transform endPos;
    public AudioSource audiosrc;
    public AudioClip dead_audio;
    public AudioClip attack_audio;
    public float jumpPower;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audiosrc = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
        bool hit = Physics2D.Linecast(shotPoint.position, endPos.position, 1 << LayerMask.NameToLayer("Grounded"));
        if (hit == false)
        {
            hit = Physics2D.Linecast(shotPoint.position, endPos.position, 1 << LayerMask.NameToLayer("Player"));
            if (hit == true) attack = true;
            else attack = false;
            Debug.DrawLine(shotPoint.position, endPos.position, Color.yellow);
        }
        else
        {
            attack = false;
            Debug.DrawLine(shotPoint.position, endPos.position, Color.blue);
        }
        if (curHealth <= 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.x *= -1;
        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            isFlipped = true;
        }
    }


    public void Damage(int dmg)
    {
        curHealth -= dmg;
        CinemachineShake.Instance.ShakeCamera(2f, .1f);
        anim.SetTrigger("hit");
        audiosrc.PlayOneShot(dead_audio, 1f);
        if (isFlipped == true) Emeny2Manager.Instance.StartCoroutine("SpawnEnemy2R", new Vector2(transform.position.x, transform.position.y));
        if (isFlipped == false) Emeny2Manager.Instance.StartCoroutine("SpawnEnemy2L", new Vector2(transform.position.x, transform.position.y));
    }
    public void audio()
    {
        audiosrc.PlayOneShot(attack_audio, 1f);
    }
    public void jump()
    {
        Vector3 flipped = transform.localScale;
        flipped.x *= -1;
        if (isFlipped) { rb.AddForce(Vector2.left * 2, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            transform.localScale = flipped;
            isFlipped = false;
        }
        else { rb.AddForce(Vector2.right * 2, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            transform.localScale = flipped;
           isFlipped = true;
        }
        
      
    }
}
