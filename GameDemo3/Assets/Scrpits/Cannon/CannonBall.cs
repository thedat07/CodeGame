using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    Rigidbody2D rb;
    public float velX = 5f;
    float velY = 0f;
    public int dmg = 1;
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
       
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.SendMessageUpwards("Damage", dmg);
            Destroy(Instantiate(Explosion, this.transform.position, this.transform.rotation) as GameObject, 0.3f);
            Destroy(gameObject);
        }
        if (col.CompareTag("Ground") || col.CompareTag("vien"))
        {
            Destroy(Instantiate(Explosion, this.transform.position, this.transform.rotation) as GameObject, 0.3f);
            Destroy(gameObject);
        }
    }
}
