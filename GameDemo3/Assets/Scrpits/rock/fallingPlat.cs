using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlat : MonoBehaviour
{
    public Rigidbody2D r2;
    public Animator animator;
    public float timedelay = 2;
    public Vector2 initialPosition;
    public int check = 0;
    // Use this for initialization
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        animator= gameObject.GetComponent<Animator>();
        initialPosition = transform.position;
    }
    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
            Destroy(gameObject, 5f);
        }
        if (check == 0 && col.gameObject.name.Equals("Player"))
        {
            PlatformManager.Instance.StartCoroutine("SpawnPlatform", new Vector2(transform.position.x, transform.position.y));
            check = 1;
        }
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(timedelay);
        animator.SetTrigger("Off");
        r2.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }


}
