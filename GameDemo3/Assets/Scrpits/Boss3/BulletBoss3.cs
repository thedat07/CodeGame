using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss3 : MonoBehaviour
{
    private Vector2 moveDirection;
    public int dmg = 1;
    public GameObject Explosion;
    public GameObject target;
    Rigidbody2D rb;
    Vector3 dir;
    Quaternion rotateToTarget;

    public float rotationSpeed = 1f;
    void Start()
    {
    }
    private void OnEnable()
    {
        Invoke("Destroy", 3f);
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {

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
    public void SetDir(Vector2 dir)
    {
        moveDirection = dir;
    }

}
