using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBoss : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject Explosion;
    float velX = 0f;
    public float destroy = 5f;
    public float velY = -10f;
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
            Destroy(Instantiate(Explosion, new Vector3(this.transform.position.x, this.transform.position.y - 0.2f, 0f), this.transform.rotation) as GameObject, 0.3f);
            Destroy(gameObject);
        }
        if (col.CompareTag("Ground") || col.CompareTag("vien"))
        {
            Destroy(Instantiate(Explosion, new Vector3(this.transform.position.x, this.transform.position.y - 0.2f, 0f), this.transform.rotation) as GameObject, 0.3f);
            Destroy(gameObject);
        }
    }
}
