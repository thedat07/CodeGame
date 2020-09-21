using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float left;
    public float right;
    public float velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }
    public void Push()
    {
        if(transform.rotation.z > 0
            && transform.rotation.z < right
            &&(rb.angularVelocity > 0)
            && rb.angularVelocity < velocity)
        {
            rb.angularVelocity = velocity;
        } else if (transform.rotation.z < 0
            && transform.rotation.z > left
            && (rb.angularVelocity < 0)
            && rb.angularVelocity > velocity*-1)
        {
            rb.angularVelocity = velocity*-1;
        }
    }
}
