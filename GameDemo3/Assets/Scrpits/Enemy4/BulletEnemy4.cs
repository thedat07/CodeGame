using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy4 : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject clown1, clown2;
    public float velX = 5f;
    public float destroy = 5f;
    float velY = 0f;
    public int dmg = 1;
    public float fade = 1f;
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        destroy -= Time.deltaTime;
        if (destroy <= 0)
        {
            DestroyProjectile();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.SendMessageUpwards("Damage", dmg);
            DestroyProjectile();
            Destroy(gameObject);
        }
        if (col.CompareTag("Ground")||col.CompareTag("vien"))
        {
            DestroyProjectile();
            Destroy(gameObject);
        }
    }
    void DestroyProjectile()
    {
        Instantiate(clown1, transform.position, Quaternion.identity);
        Instantiate(clown2, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
