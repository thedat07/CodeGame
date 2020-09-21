using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public GameObject deadL, deadR;
    private Transform player;
    public bool isFlipped = false;
    public float curHealth = 100f;
    Rigidbody2D rb;
    private Animator anim;
    public bool movingRight = true;
    public bool grounded = true;
    public GameObject boomL;
    public GameObject boomR;

    public bool shoot;
    public Transform shotPoint;
    public Transform endPos;
    public AudioSource audiosrc;
    public AudioClip shoot_audio;
    public AudioClip dead_audio;
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
            if (hit == true) shoot = true;
            else shoot = false;
            Debug.DrawLine(shotPoint.position, endPos.position, Color.yellow);
        }
        else
        {
            shoot = false;
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
        if (isFlipped == true) Emeny3Manager.Instance.StartCoroutine("SpawnEnemy3R", new Vector2(transform.position.x, transform.position.y));
        if (isFlipped == false) Emeny3Manager.Instance.StartCoroutine("SpawnEnemy3L", new Vector2(transform.position.x, transform.position.y));
    }
    void BulletFire()
    {
        if (isFlipped == true) Instantiate(boomR, shotPoint.position, transform.rotation); audiosrc.PlayOneShot(shoot_audio, 0.1f);
        if (isFlipped == false) Instantiate(boomL, shotPoint.position, transform.rotation); audiosrc.PlayOneShot(shoot_audio, 0.1f);

    }

}
