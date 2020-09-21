using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 5;
    public float rotatingSpeed = 200;
    public GameObject target;
    public int dmg = 1;
    public GameObject Explosion;
    private Vector2 moveDirection;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;

        point2Target.Normalize();

        float value = Vector3.Cross(point2Target, transform.right).z;

        rb.angularVelocity = rotatingSpeed * value;


        rb.velocity = transform.right * speed;


    }
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //col.SendMessageUpwards("Damage", dmg);
            Destroy(Instantiate(Explosion, this.transform.position, this.transform.rotation) as GameObject, 0.3f);
            gameObject.SetActive(false);

        }
        if (col.CompareTag("Ground") || col.CompareTag("vien"))
        {
            Destroy(Instantiate(Explosion, this.transform.position, this.transform.rotation) as GameObject, 0.3f);
            gameObject.SetActive(false);
        }
    }

}
