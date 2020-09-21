using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttle2Boss2 : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject clown1, clown2;
     float velX = 0f;
    public float destroy = 5f;
    public float velY = -5f;
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
        Destroy(gameObject, destroy);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.SendMessageUpwards("Damage", dmg);
            Instantiate(clown1, transform.position, Quaternion.identity);
            Instantiate(clown2, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (col.CompareTag("Ground") || col.CompareTag("vien"))
        {
            Instantiate(clown1, transform.position, Quaternion.identity);
            Instantiate(clown2, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
